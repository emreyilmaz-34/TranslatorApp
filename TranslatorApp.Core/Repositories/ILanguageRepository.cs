using System.Threading.Tasks;
using TranslatorApp.Core.Models;

namespace TranslatorApp.Core.Repositories
{
    public interface ILanguageRepository : IRepository<Language>
    {
        Task<Language> GetWithTranslations(int languageId);
    }
}
