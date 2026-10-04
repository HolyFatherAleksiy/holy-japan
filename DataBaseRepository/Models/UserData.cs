using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseRepository.Models
{
    public class UserData
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = "";
        public byte[] BackgroundImage { get; set; } = [];
        public TimeSpan AppUseTime { get; set; }
        public bool EnableNottify { get; set; }
        public string CurrentLanguageCode { get; set; } = "";
        [ForeignKey(nameof(CurrentLanguageCode))]
        public Language? CurrentLanguage { get; set; }
    }
}