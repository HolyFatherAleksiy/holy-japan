using DataBaseRepository.Models;

namespace DataBaseRepository.Services.Interfaces
{
    public interface IUserDataService
    {
        Task<UserData> Create(string name, string codeLanguage);
        Task<UserData?> GetData();
        Task SetLocalisation(string code);
        Task SetNotify(bool value);
    }
}