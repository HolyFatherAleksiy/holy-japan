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

        public async Task<List<Language>> GetAllData()
        {
            return await _context.Languages.AsNoTracking().ToListAsync();
        }
        public async Task<Language> AddAsync(string code, string filename, string json)
        {
            var checkData = await _context.Languages.FirstOrDefaultAsync(p=>p.Code == code && p.FileName == filename);
            if(checkData != null)
                throw new KeyNotFoundException($"{code} - {Localisation.GetValue(InterfaceElements.KeyFound)}");

            var newData = new Language
            {
                Code = code,
                FileName = filename,
                JSON = json  
            };

            await _context.Languages.AddAsync(newData);
            await _context.SaveChangesAsync();
            return newData;
        }
        public async Task Delete(string code)
        {
            var dbData = await _context.Languages.FirstOrDefaultAsync(p=>p.Code == code)
                    ?? throw new KeyNotFoundException(Localisation.GetValue(InterfaceElements.KeyNotFound));
            _context.Remove(dbData);
            await _context.SaveChangesAsync();
        }
        public async Task SetLocalisation(Language language)
        {
            await _userDataService.SetLocalisation(language.Code);            
        }
    }
}