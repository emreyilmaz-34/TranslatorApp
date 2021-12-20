using System.Collections.Generic;

namespace TranslatorApp.Web.DTOs
{
    public class LanguageWithTranslationsDto : LanguageDto
    {
        public ICollection<TranslationDto> Translations { get; set; }
    }
}
