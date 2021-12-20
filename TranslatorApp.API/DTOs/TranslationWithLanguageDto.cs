namespace TranslatorApp.API.DTOs
{
    public class TranslationWithLanguageDto : TranslationDto
    {
        public LanguageDto Language { get; set; }
    }
}
