using DataBaseRepository.Context;
using DataBaseRepository.Services;
using DataBaseRepository.Services.Interfaces;
using MAUI.Services;
using MAUI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HolyJapan
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

            #if DEBUG
                builder.Services.AddBlazorWebViewDeveloperTools();
                builder.Logging.AddDebug();
            #endif

            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "app.db3");
            builder.Services.AddDbContextFactory<SQLiteDbContext>(options =>
                options.UseSqlite($"Data Source={dbPath}"));

            builder.Services.AddScoped<IUserDataService, UserDataService>();
            builder.Services.AddScoped<ILanguageFileService, LanguageFileService>();
            builder.Services.AddScoped<ILanguageService, LanguageService>();
            builder.Services.AddScoped<IInitializeService, InitializeService>();
            builder.Services.AddScoped<IResizeService, ResizeService>();
            
            
            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var service = scope.ServiceProvider.GetRequiredService<IInitializeService>();
                service.Initialize();
            }

            return app;
        }
    }
}
