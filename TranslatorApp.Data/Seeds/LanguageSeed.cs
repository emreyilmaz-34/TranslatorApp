using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslatorApp.Core.Models;

namespace TranslatorApp.Data.Seeds
{
    public class LanguageSeed : IEntityTypeConfiguration<Language>
    {
        public LanguageSeed()
        { }

        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasData(
                    new Language { Id = 1, Name = "dothraki" },
                    new Language { Id = 2, Name = "valyrian" }
                );
        }
    }
}
