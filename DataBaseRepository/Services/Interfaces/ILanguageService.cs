using DataBaseRepository.Models;

namespace DataBaseRepository.Services.Interfaces
{
    public interface ILanguageService
    {
        Task<List<Language>> GetAllData();
        Task<Language> AddAsync(string code, string filename, string icon, string version, string json, bool isDefault = false);
        Task<Language> UpdateAsync(string code, string filename, string icon, string version, string json, bool isDefault = false);
        Task Delete(string code);
        Task SetLocalisation(Language language);
        Action? OnChanges { get; set; }
        void InvokeChanges();
    }
}