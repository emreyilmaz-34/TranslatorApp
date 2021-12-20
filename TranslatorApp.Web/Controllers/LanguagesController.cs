using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TranslatorApp.Web.ApiService;
using TranslatorApp.Web.DTOs;
using TranslatorApp.Web.Filters;

namespace TranslatorApp.Web.Controllers
{
    public class LanguagesController : Controller
    {
        private readonly LanguageApiService _languageApiService;
        private readonly IMapper _mapper;

        public LanguagesController(IMapper mapper, LanguageApiService languageApiService)
        {
            _mapper = mapper;
            _languageApiService = languageApiService;
        }

        public async Task<IActionResult> Index()
        {
            var languages = await _languageApiService.GetAllAsync();

            return View(_mapper.Map<IEnumerable<LanguageDto>>(languages));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(LanguageDto languageDto)
        {
            await _languageApiService.AddAsync(languageDto);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var language = await _languageApiService.GetByIdAsync(id);

            return View(_mapper.Map<LanguageDto>(language));
        }

        [HttpPost]
        public async Task<IActionResult> Update(LanguageDto languageDto)
        {
            await _languageApiService.Update(languageDto);

            return RedirectToAction("Index");
        }

        [ServiceFilter(typeof(LanguageNotFoundFilter))]
        public async Task<IActionResult> Delete(int id)
        {
            await _languageApiService.Remove(id);

            return RedirectToAction("Index");
        }
    }
}
