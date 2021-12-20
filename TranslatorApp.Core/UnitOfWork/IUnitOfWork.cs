using System.Threading.Tasks;
using TranslatorApp.Core.Repositories;

namespace TranslatorApp.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        ITranslationRepository Translations { get; }
        ILanguageRepository Languages { get; }
        Task CommitAsync();
        void Commit();
    }
}
