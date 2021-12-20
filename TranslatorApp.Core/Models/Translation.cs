using TranslatorApp.Shared.Entity;

namespace TranslatorApp.Core.Models
{
    public class Translation : EntityBase
    {
        public string Translated { get; set; }
        public string Text { get; set; }
        public int LanguageId { get; set; }
        public virtual Language Language { get; set; }
    }
}
