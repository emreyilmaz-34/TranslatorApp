using System.Threading.Tasks;
using TranslatorApp.Core.Models;
using TranslatorApp.Core.Repositories;
using TranslatorApp.Core.Service;
using TranslatorApp.Core.UnitOfWork;

namespace TranslatorApp.Service.Services
{
    public class TranslationService : Service<Translation>, ITranslationService
    {
        public TranslationService(IUnitOfWork unitOfWork, IRepository<Translation> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Translation> GetWithLanguageAsync(int translationId)
            => await _unitOfWork.Translations.GetWithLanguageAsync(translationId);
    }
}
