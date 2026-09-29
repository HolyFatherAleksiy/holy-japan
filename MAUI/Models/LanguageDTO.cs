using Shared;

namespace MAUI.Models
{
    public class LanguageDTO
    {
        public string Code { get; set; } = "";
        public string Icon { get; set; } = "";
        public Dictionary<InterfaceElements, string> Data { get; set; } = [];
    }
}