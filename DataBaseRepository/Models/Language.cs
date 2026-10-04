using System.ComponentModel.DataAnnotations;

namespace DataBaseRepository.Models
{
    public class Language
    {
        [Key]
        public string Code { get; set; } = "";
        public string Icon { get; set; } = "";
        public string FileName { get; set; } = "";
        public string Version { get; set; } = "";
        public string JSON { get; set; } = "";
        public bool IsDefault { get; set; }
    }
}