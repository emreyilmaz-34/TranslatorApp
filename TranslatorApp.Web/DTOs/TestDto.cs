using System.ComponentModel.DataAnnotations;

namespace TranslatorApp.Web.DTOs
{
    public class TestDto
    {
        [Required(ErrorMessage = "{0} is a required field")]
        public string Text { get; set; }
        [Required(ErrorMessage = "{0} is a required field")]
        public int LanguageId { get; set; }
    }
}
