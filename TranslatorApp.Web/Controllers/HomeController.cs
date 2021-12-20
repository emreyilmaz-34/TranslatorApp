using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using TranslatorApp.Web.ApiService;
using TranslatorApp.Web.DTOs;

namespace TranslatorApp.Web.Controllers
{
    public class HomeController : Controller
    {
        readonly LanguageApiService _languageApiService;
        readonly TranslationApiService _translationApiService;
        readonly ILogger<HomeController> _logger;
        readonly IMapper _mapper;


        public HomeController(ILogger<HomeController> logger, 
                            IMapper mapper, 
                            LanguageApiService languageApiService,
                            TranslationApiService translationApiService)
        {
            _logger = logger;
            _mapper = mapper;
            _languageApiService = languageApiService;
            _translationApiService = translationApiService;
        }

        public async Task<IActionResult> Index()
        {
            List<SelectListItem> languageList = new List<SelectListItem>();

            var languages = await _languageApiService.GetAllAsync();

            foreach (var language in languages)
            {
                languageList.Add(new SelectListItem { Text = language.Name, Value = language.Id.ToString() });
            }
            
            ViewBag.LanguageList = languageList;

            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> Create(TranslationDto translationDto)
        {
            var translated = await _translationApiService.AddAsync(translationDto);

            if (translated is null)
                return NoContent();

            var translationWithLanguage = await _translationApiService.GetWithLanguageAsync(translated.Id);

            return View("Translation", translationWithLanguage);
        }
    }
}
