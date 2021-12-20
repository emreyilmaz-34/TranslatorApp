using System.ComponentModel.DataAnnotations;

namespace TranslatorApp.API.DTOs
{
    public class LanguageDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="{0} is a required field")]
        public string Name { get; set; }
    }
}
