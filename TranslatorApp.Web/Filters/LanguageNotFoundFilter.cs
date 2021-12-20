using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;
using TranslatorApp.Web.ApiService;
using TranslatorApp.Web.DTOs;

namespace TranslatorApp.Web.Filters
{
    public class LanguageNotFoundFilter:ActionFilterAttribute
    {
        private readonly LanguageApiService _languageApiService;

        public LanguageNotFoundFilter(LanguageApiService languageApiService)
        {
            _languageApiService = languageApiService;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault();

            var language = await _languageApiService.GetByIdAsync(id);

            if (language != null)
                await next();

            else 
            { 
                ErrorDto errorDto = new();
                errorDto.Status = 404;

                errorDto.Errors.Add($"The language with id {id} was not found in the database");
                context.Result = new RedirectToActionResult("Error", "Home", errorDto);
            }
        }
    }
}
