using System.ComponentModel.DataAnnotations;

namespace DataBaseRepository.Models
{
    public class Language
    {
        [Key]
        public string Code { get; set; } = "";
        public string JSON { get; set; } = "";
    }
}