using System.Text.Json;
using System.Text.Json.Serialization;
using HolyJapan;
using MAUI.Models;
using MAUI.Services.Interfaces;

namespace MAUI.Services
{
    public class LanguageFileService : ILanguageFileService
    {

        public async Task<FileResult> PickJsonFile()
        {
            var result = await FilePicker.Default.PickAsync(new PickOptions
            {
                PickerTitle = "Выберите JSON",
                FileTypes = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    { DevicePlatform.WinUI,   new[] { ".json" } },
                    { DevicePlatform.Android, new[] { "application/json" } },
                    { DevicePlatform.iOS,     new[] { "public.json" } },
                })
            });

            if (result is null)
                throw new Exception(Localisation.GetValue(InterfaceElements.EmptyFile));

            return result;
        }
        public async Task<string> GetJson(FileResult file)
        {
            using var stream = await file.OpenReadAsync();

            const long maxSize = 10 * 1024 * 1024;
            if (stream.Length > maxSize)
                throw new Exception(Localisation.GetValue(InterfaceElements.LargeFile));

            using var reader = new StreamReader(stream);
            return await reader.ReadToEndAsync();
        }
        public LanguageDTO SerializeLanguage(string json)
        {
            var options = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() }
            };

            var data = JsonSerializer.Deserialize<LanguageDTO>(json, options);
            if(data?.Data == null && string.IsNullOrWhiteSpace(data?.Code)) 
                throw new Exception(Localisation.GetValue(InterfaceElements.JsonSerializeError));

            return data;
        }
    }
}