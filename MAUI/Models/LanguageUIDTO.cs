using DataBaseRepository.Models;

namespace MAUI.Models
{
    public class LanguageUIDTO(Language language)
    {
        public Language Language { get; set; } = language;
        public bool MenuIsOppened { get; set; }
        public bool IsSelected { get; set; }
    }
}