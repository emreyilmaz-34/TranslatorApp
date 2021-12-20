using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslatorApp.Core.Models;

namespace TranslatorApp.Data.Configurations
{
    class TranslationConfiguration : IEntityTypeConfiguration<Translation>
    {
        public void Configure(EntityTypeBuilder<Translation> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Text).IsRequired();
            builder.Property(x => x.LanguageId).IsRequired();
            builder.ToTable("Translations");

        }
    }
}
