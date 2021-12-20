using System.Threading.Tasks;
using TranslatorApp.Core.Models;

namespace TranslatorApp.Core.Service
{
    public interface ILanguageService : IService<Language>
    {
        Task<Language> GetWithTranslations(int languageId);
    }
}
