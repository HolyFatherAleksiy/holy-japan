using HolyJapan;
using MAUI.Models;
using Microsoft.AspNetCore.Components.Forms;

namespace MAUI.Services.Interfaces
{
    public interface ILanguageFileService
    {
        Task<string> GetJson(FileResult file);
        LanguageDTO SerializeLanguage(string json);
        Task<FileResult> PickJsonFile();
    }
}