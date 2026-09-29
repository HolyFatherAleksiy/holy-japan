using MAUI.Models;

namespace MAUI.Services.Interfaces
{
    public interface ILanguageFileService
    {
        Task<string> GetJson(FileResult file);
        Task<string> GetJsonByFileNameAsync(string filename);
        LanguageDTO SerializeLanguage(string json);
        Task<FileResult> PickJsonFile();
    }
}