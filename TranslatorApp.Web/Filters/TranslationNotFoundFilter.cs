using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;
using TranslatorApp.Web.ApiService;
using TranslatorApp.Web.DTOs;

namespace TranslatorApp.Web.Filters
{
    public class TranslationNotFoundFilter : ActionFilterAttribute
    {
        private readonly TranslationApiService _translationApiService;

        public TranslationNotFoundFilter(TranslationApiService translationApiService)
        {
            _translationApiService = translationApiService;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault();

            var translation = await _translationApiService.GetByIdAsync(id);

            if (translation != null)
                await next();

            else
            {
                ErrorDto errorDto = new();
                errorDto.Status = 404;

                errorDto.Errors.Add($"The translation with id {id} was not found in the database");
                context.Result = new RedirectToActionResult("Error", "Home", errorDto);
            }
        }
    }
}
