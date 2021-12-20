using System.Collections.Generic;
using TranslatorApp.Shared.Entity;

namespace TranslatorApp.Core.Models
{
    public class Language : EntityBase
    {
        public string Name { get; set; }
        public ICollection<Translation> Translations { get; set; }
    }
}
