using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TranslatorApp.Core.Models;
using TranslatorApp.Core.Repositories;

namespace TranslatorApp.Data.Repositories
{
    public class TranslationRepository : Repository<Translation>, ITranslationRepository
    {
        private AppDbContext appDbContext { get => _context as AppDbContext; }

        public TranslationRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Translation> GetWithLanguageAsync(int translationId)
            => await appDbContext.Translations.Include(x => x.Language).SingleOrDefaultAsync(x => x.Id == translationId);
    }
}
