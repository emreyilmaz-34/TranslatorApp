using System.Threading.Tasks;
using TranslatorApp.Core.Models;

namespace TranslatorApp.Core.Service
{
    public interface ITranslationService: IService<Translation>
    {
        Task<Translation> GetWithLanguageAsync(int translationId);
    }
}
