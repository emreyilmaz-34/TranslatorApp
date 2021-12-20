using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TranslatorApp.Core.Models;
using TranslatorApp.Core.Repositories;

namespace TranslatorApp.Data.Repositories
{
    public class LanguageRepository : Repository<Language>, ILanguageRepository
    {
        private AppDbContext appDbContext { get => _context as AppDbContext; }

        // i added this constructor because i inherited the Repository
        // and there is a constructor in the Repository
        public LanguageRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Language> GetWithTranslations(int languageId)
            => await appDbContext.Languages.Include(x => x.Translations).SingleOrDefaultAsync(x => x.Id == languageId);
    }
}
