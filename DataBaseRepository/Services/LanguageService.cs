using System.Runtime.CompilerServices;
using DataBaseRepository.Context;
using DataBaseRepository.Models;
using DataBaseRepository.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Shared;

namespace DataBaseRepository.Services
{
    public class LanguageService(IDbContextFactory<SQLiteDbContext> contextFactory, IUserDataService userDataService) : ILanguageService
    {
        readonly SQLiteDbContext _context = contextFactory.CreateDbContext();
        readonly IUserDataService _userDataService = userDataService;
        public Action? OnChanges { get; set; }

        public async Task<List<Language>> GetAllData()
        {
            return await _context.Languages.AsNoTracking().ToListAsync();
        }
        public async Task<Language> AddAsync(string code, string filename, string icon, string version, string json, bool isDefault = false)
        {
            var checkData = await _context.Languages.FirstOrDefaultAsync(p=>p.Code == code && p.FileName == filename);
            if(checkData != null)
                throw new KeyNotFoundException($"{code} - {Localisation.GetValue(InterfaceElements.KeyFound)}");

            var newData = new Language
            {
                Code = code,
                Icon = icon,
                Version = version,
                FileName = filename,
                JSON = json,
                IsDefault = isDefault
            };

            await _context.Languages.AddAsync(newData);
            await _context.SaveChangesAsync();
            return newData;
        }
        public async Task<Language> UpdateAsync(string code, string filename, string icon, string version, string json, bool isDefault = false)
        {
            var dbData = await _context.Languages.FirstOrDefaultAsync(p => p.Code == code && p.FileName == filename) 
                    ?? throw new KeyNotFoundException($"{code} - {Localisation.GetValue(InterfaceElements.KeyNotFound)}");
            if (dbData.Version == version)
            {
                throw new KeyNotFoundException($"{version} - {Localisation.GetValue(InterfaceElements.KeyFound)}");
            }

            var newData = new Language
            {
                Code = code,
                Icon = icon,
                Version = version,
                FileName = filename,
                JSON = json,
                IsDefault = isDefault
            };

            await _context.Languages.AddAsync(newData);
            await _context.SaveChangesAsync();
            return newData;
        }

        public async Task Delete(string code)
        {
            var dbData = await _context.Languages.FirstOrDefaultAsync(p=>p.Code == code)
                    ?? throw new KeyNotFoundException($"{code} - {Localisation.GetValue(InterfaceElements.KeyNotFound)}");
            _context.Remove(dbData);
            await _context.SaveChangesAsync();
        }
        public async Task SetLocalisation(Language language)
        {
            await _userDataService.SetLocalisation(language.Code);   
            InvokeChanges();
        }

        public void InvokeChanges()
        {
            OnChanges?.Invoke();
        }

    }
}