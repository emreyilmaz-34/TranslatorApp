using System.Collections.Generic;

namespace TranslatorApp.API.DTOs
{
    public class LanguageWithTranslationsDto : LanguageDto
    {
        public ICollection<TranslationDto> Translations { get; set; }
    }
}
