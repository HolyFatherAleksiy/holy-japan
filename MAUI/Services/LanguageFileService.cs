using System.Reflection;
using MAUI.Models;
using MAUI.Services.Interfaces;
using Newtonsoft.Json;
using Shared;

namespace MAUI.Services
{
    public class LanguageFileService : ILanguageFileService
    {

        public async Task<FileResult> PickJsonFile()
        {
            var result = await FilePicker.Default.PickAsync(new PickOptions
            {
                PickerTitle = "JSON",
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
        private async Task<string> GetString(Stream stream)
        {            
            using var reader = new StreamReader(stream);
            return await reader.ReadToEndAsync();
        }
        public async Task<string> GetJson(FileResult file)
        {
            using var stream = await file.OpenReadAsync();

            const long maxSize = 10 * 1024 * 1024;
            if (stream.Length > maxSize)
                throw new Exception(Localisation.GetValue(InterfaceElements.LargeFile));

            return await GetString(stream);
        }
        public async Task<string> GetJsonByFileNameAsync(string filename)
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync(filename);
            return await GetString(stream);
        }
        public LanguageDTO SerializeLanguage(string json)
        {
            var data = JsonConvert.DeserializeObject<LanguageDTO>(json);
            if(data?.Data == null || string.IsNullOrWhiteSpace(data?.Code) || string.IsNullOrWhiteSpace(data?.Version)) 
                throw new Exception(Localisation.GetValue(InterfaceElements.JsonSerializeError));

            return data;
        }
    }
}