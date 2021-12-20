using AutoMapper;
using TranslatorApp.API.DTOs;
using TranslatorApp.Core.Models;

namespace TranslatorApp.API.Mapping
{
    public class MapProfile: Profile
    {
        public MapProfile()
        {
            CreateMap<Language, LanguageDto>();
            CreateMap<LanguageDto, Language>();

            CreateMap<LanguageWithTranslationsDto, Language>();
            CreateMap<Language, LanguageWithTranslationsDto>();

            CreateMap<Translation, TranslationDto>();
            CreateMap<TranslationDto, Translation>();

            CreateMap<TranslationWithLanguageDto, TranslationDto>();
            CreateMap<TranslationDto, TranslationWithLanguageDto>();

            CreateMap<Translation, TranslationWithLanguageDto>();
            CreateMap<TranslationWithLanguageDto, Translation>();
        }
    }
}
