using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TranslatorApp.API.DTOs;
using TranslatorApp.API.Filters;
using TranslatorApp.Core.Models;
using TranslatorApp.Core.Service;

namespace TranslatorApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        readonly ILanguageService _languageService;
        readonly IMapper _mapper;

        public LanguagesController(ILanguageService languageService, IMapper mapper)
        {
            _languageService = languageService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var languages = await _languageService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<LanguageDto>>(languages));
        }

        [ServiceFilter(typeof(LanguageNotFoundFilter))]
        [HttpGet("{id}/translations")]
        public async Task<IActionResult> GetWithTranslations(int id)
        {
            var language = await _languageService.GetWithTranslations(id);

            return Ok(_mapper.Map<LanguageWithTranslationsDto>(language));

        }

        [ServiceFilter(typeof(LanguageNotFoundFilter))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var language = await _languageService.GetByIdAsync(id);
            return Ok(_mapper.Map<LanguageDto>(language));
        }
        [HttpPost]
        public async Task<IActionResult> Save(LanguageDto languageDto)
        {
            var newLanguage = await _languageService.AddAsync(_mapper.Map<Language>(languageDto));
            return Created(string.Empty, _mapper.Map<LanguageDto>(newLanguage));
        }

        [HttpPut]
        public IActionResult Update(LanguageDto languageDto)
        {
            _languageService.Update(_mapper.Map<Language>(languageDto));
            return NoContent();
        }

        [ServiceFilter(typeof(LanguageNotFoundFilter))]
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var language = _languageService.GetByIdAsync(id).Result;
            _languageService.Remove(language);
            return NoContent();
        }
    }
}
