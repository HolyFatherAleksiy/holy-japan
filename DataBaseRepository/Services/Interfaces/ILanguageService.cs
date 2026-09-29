using DataBaseRepository.Models;

namespace DataBaseRepository.Services.Interfaces
{
    public interface ILanguageService
    {
        Task<List<Language>> GetAllData();
        Task<Language> AddAsync(string code, string filename, string json);
        Task Delete(string code);
        Task SetLocalisation(Language language);
    }
}