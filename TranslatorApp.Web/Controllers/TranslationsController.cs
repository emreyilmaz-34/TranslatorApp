using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TranslatorApp.Web.ApiService;
using TranslatorApp.Web.DTOs;
using TranslatorApp.Web.Filters;

namespace TranslatorApp.Web.Controllers
{
    public class TranslationsController : Controller
    {
        private readonly TranslationApiService _translationApiService;
        private readonly IMapper _mapper;

        public TranslationsController(IMapper mapper, TranslationApiService translationApiService)
        {
            _mapper = mapper;
            _translationApiService = translationApiService;
        }

        public async Task<IActionResult> Index()
        {
            var translations = await _translationApiService.GetAllAsync();

            return View(_mapper.Map<IEnumerable<TranslationWithLanguageDto>>(translations));
        }

        [HttpPost]
        public async Task<IActionResult> Create(TranslationDto translationDto)
        {
            await _translationApiService.AddAsync(translationDto);

            return RedirectToAction("Index");
        }

        //public async Task<IActionResult> Update(int id)
        //{
        //    var translation = await _translationApiService.GetByIdAsync(id);

        //    return View(_mapper.Map<TranslationDto>(translation));
        //}

        //[HttpPost]
        //public async Task<IActionResult> Update(TranslationDto translationDto)
        //{
        //    await _translationApiService.Update(translationDto);

        //    return RedirectToAction("Index");
        //}

        [ServiceFilter(typeof(TranslationNotFoundFilter))]
        public async Task<IActionResult> Delete(int id)
        {
            await _translationApiService.Remove(id);

            return RedirectToAction("Index");
        }
    }
}
