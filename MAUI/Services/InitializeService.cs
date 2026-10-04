using System.Net.Http.Json;
using DataBaseRepository.Context;
using DataBaseRepository.Services.Interfaces;
using MAUI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace MAUI.Services
{
    public class InitializeService(
        IDbContextFactory<SQLiteDbContext> contextFactory,
        IUserDataService userDataService,
        ILanguageFileService languageFileService,
        ILanguageService languageService
    ) : IInitializeService
    {

        readonly IDbContextFactory<SQLiteDbContext> _contextFactory = contextFactory;
        readonly IUserDataService _userDataService = userDataService;
        readonly ILanguageFileService _languageFileService = languageFileService;
        readonly ILanguageService _languageService = languageService;

        public void Initialize()
        {
            using var db = _contextFactory.CreateDbContext();
            db.Database.Migrate();

            var list = db.Languages.Where(p=>p.IsDefault).ToList();
            if(list.Count != 0)
            {
                db.Languages.RemoveRange(list);
                db.SaveChanges();
            }

            Task.Run(async () =>
            {
                await InitializeLanguage("english.json");
                await InitializeLanguage("russian.json");
            }).GetAwaiter().GetResult(); 
        }

        async Task InitializeLanguage(string filename)
        {
            var fileJSON = await _languageFileService.GetJsonByFileNameAsync(filename);
            var data = _languageFileService.SerializeLanguage(fileJSON);
            var dataJSON = JsonConvert.SerializeObject(data.Data);
            var language = await _languageService.AddAsync(data.Code, filename, data.Icon, data.Version, dataJSON, true);
        }
    }
}