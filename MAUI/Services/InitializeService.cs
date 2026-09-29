using DataBaseRepository.Context;
using DataBaseRepository.Services.Interfaces;
using MAUI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

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

            var list = db.Languages.ToList();
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
            var json = await _languageFileService.GetJsonByFileNameAsync(filename);
            var data = _languageFileService.SerializeLanguage(json);
            var language = await _languageService.AddAsync(data.Code, filename, json);
        }
    }
}