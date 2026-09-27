using System.Drawing;
using System.Runtime.CompilerServices;
using DataBaseRepository.Context;
using DataBaseRepository.Models;
using DataBaseRepository.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataBaseRepository.Services
{
    public class LanguageService(IDbContextFactory<SQLiteDbContext> contextFactory) : ILanguageService
    {
        readonly SQLiteDbContext _context = contextFactory.CreateDbContext();

        public async Task<List<Language>> GetAllData()
        {
            return await _context.Languages.AsNoTracking().ToListAsync();
        }
        public async Task Add(string code, string json)
        {
            var newData = new Language
            {
                Code = code,
                JSON = json  
            };
            await _context.Languages.AddAsync(newData);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(string code)
        {
            var dbData = await _context.Languages.FirstOrDefaultAsync(p=>p.Code == code)
                    ?? throw new KeyNotFoundException(Localisa);
        }
    }
}