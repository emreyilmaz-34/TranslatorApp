using System.Threading.Tasks;
using TranslatorApp.Core.Repositories;
using TranslatorApp.Core.UnitOfWork;
using TranslatorApp.Data.Repositories;

namespace TranslatorApp.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private LanguageRepository _languageRepository;
        private TranslationRepository _translationRepository;

        public UnitOfWork(AppDbContext appDbContext)
            => _context = appDbContext;
        public ILanguageRepository Languages => _languageRepository = _languageRepository ?? new LanguageRepository(_context);
        public ITranslationRepository Translations => _translationRepository = _translationRepository ?? new TranslationRepository(_context);
        public void Commit()
            => _context.SaveChanges();
        public async Task CommitAsync()
            => await _context.SaveChangesAsync();
    }
}
