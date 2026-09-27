using System.ComponentModel.DataAnnotations;
using HolyJapan;

namespace MAUI.Models
{
    public class LanguageDTO
    {
        public string Code { get; set; } = "";
        public Dictionary<InterfaceElements, string> Data { get; set; } = [];
    }
}