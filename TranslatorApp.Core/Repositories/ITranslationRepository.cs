using System.Threading.Tasks;
using TranslatorApp.Core.Models;

namespace TranslatorApp.Core.Repositories
{
    // although we have IGenericRepository, i added ITranslationRepository because
    // some code specific to this model may need to be written in the future.
    public interface ITranslationRepository : IRepository<Translation>
    {
        Task<Translation> GetWithLanguageAsync(int translationId);
    }
}
