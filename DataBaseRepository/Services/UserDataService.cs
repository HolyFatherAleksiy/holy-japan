using DataBaseRepository.Context;
using DataBaseRepository.Models;
using DataBaseRepository.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace DataBaseRepository.Services
{
    public class UserDataService(IDbContextFactory<SQLiteDbContext> contextFactory)  : IUserDataService
    {
        readonly SQLiteDbContext _context = contextFactory.CreateDbContext();

        public async Task<UserData> Create(string name, string codeLanguage)
        {
            var userData = new UserData()
            {
                Name = name,
                CurrentLanguageCode = codeLanguage
            };
            await _context.UserDatas.AddAsync(userData);
            await _context.SaveChangesAsync();
            return userData;
        }
        public async Task<UserData> GetData()
        {
            return await _context.UserDatas.FirstOrDefaultAsync()
                ?? throw new KeyNotFoundException($"{Localisation.GetValue(InterfaceElements.UserDataText)} - {Localisation.GetValue(InterfaceElements.KeyNotFound)}");
        }
        public async Task SetLocalisation(string code)
        {
            var userData = await GetData();
            userData.CurrentLanguageCode = code;
            await _context.SaveChangesAsync();
        }
        public async Task SetNotify(bool value)
        {
            var userData = await GetData();
            userData.EnableNottify = value;
            await _context.SaveChangesAsync();
        }
        public async Task SetBackgroundImage(byte[] image)
        {
            var userData = await GetData();
            userData.BackgroundImage = image;
            await _context.SaveChangesAsync();
        }

    }
}