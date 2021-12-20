using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TranslatorApp.API.DTOs;
using TranslatorApp.API.Filters;
using TranslatorApp.Core.Models;
using TranslatorApp.Core.Service;
using TranslatorApp.FunTranslation;

namespace TranslatorApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranslationsController : ControllerBase
    {
        readonly ITranslationService _translationService;
        readonly ILanguageService _languageService;
        readonly IMapper _mapper;
        FunTranslationClient _funTranslationClient = new();

        public TranslationsController(ITranslationService translationService, 
            IMapper mapper, 
            ILanguageService languageService)
        {
            _translationService = translationService;
            _languageService = languageService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<TranslationWithLanguageDto> translationsWithLanguage = new();

            var languages = await _languageService.GetAllAsync();
            var translations = await _translationService.GetAllAsync();

            foreach (var translation in translations)
            {
                translation.Language = languages.First(x => x.Id == translation.LanguageId);

                translationsWithLanguage.Add(_mapper.Map<TranslationWithLanguageDto>(translation));
            }

            return Ok(translationsWithLanguage);
        }

        [ServiceFilter(typeof(TranslationNotFoundFilter))]
        [HttpGet("{id}/language")]
        public async Task<IActionResult> GetWithTranslations(int id)
        {
            var translation = await _translationService.GetWithLanguageAsync(id);

            return Ok(_mapper.Map<TranslationWithLanguageDto>(translation));

        }

        [ServiceFilter(typeof(TranslationNotFoundFilter))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var translation = await _translationService.GetByIdAsync(id);
            return Ok(_mapper.Map<TranslationDto>(translation));
        }

        [HttpPost]
        public async Task<IActionResult> Save(TranslationDto translationDto)
        {
            var language = await _languageService.GetByIdAsync(translationDto.LanguageId);

            var translatedText = _funTranslationClient.DoTranslate(translationDto.Text, language.Name);

            translationDto.Translated = translatedText;

            var newTranslation = await _translationService.AddAsync(_mapper.Map<Translation>(translationDto));

            return Created(string.Empty, _mapper.Map<TranslationDto>(newTranslation));
        }

        //[HttpPut]
        //public IActionResult Update(TranslationDto translationDto)
        //{
        //    _translationService.Update(_mapper.Map<Translation>(translationDto));
        //    return NoContent();
        //}

        [ServiceFilter(typeof(TranslationNotFoundFilter))]
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var translation = _translationService.GetByIdAsync(id).Result;
            _translationService.Remove(translation);
            return NoContent();
        }
    }
}
