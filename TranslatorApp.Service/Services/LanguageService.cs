using System.Threading.Tasks;
using TranslatorApp.Core.Models;
using TranslatorApp.Core.Repositories;
using TranslatorApp.Core.Service;
using TranslatorApp.Core.UnitOfWork;

namespace TranslatorApp.Service.Services
{
    public class LanguageService : Service<Language>, ILanguageService
    {
        public LanguageService(IUnitOfWork unitOfWork, IRepository<Language> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Language> GetWithTranslations(int languageId)
            => await _unitOfWork.Languages.GetWithTranslations(languageId);
    }
}
