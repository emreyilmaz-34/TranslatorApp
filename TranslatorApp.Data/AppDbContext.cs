using Microsoft.EntityFrameworkCore;
using TranslatorApp.Core.Models;
using TranslatorApp.Data.Configurations;
using TranslatorApp.Data.Seeds;

namespace TranslatorApp.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Language> Languages { get; set; }
        public DbSet<Translation> Translations { get; set; }
        public DbSet<TestModel> TestModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LanguageConfiguration());
            modelBuilder.ApplyConfiguration(new TranslationConfiguration());

            modelBuilder.ApplyConfiguration(new LanguageSeed());
        }
    }
}
