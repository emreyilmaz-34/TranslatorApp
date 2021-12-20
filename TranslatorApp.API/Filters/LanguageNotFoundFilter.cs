using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;
using TranslatorApp.API.DTOs;
using TranslatorApp.Core.Service;

namespace TranslatorApp.API.Filters
{
    public class LanguageNotFoundFilter : ActionFilterAttribute
    {
        readonly ILanguageService _languageService;

        public LanguageNotFoundFilter(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault();

            var language = await _languageService.GetByIdAsync(id);

            if (language != null)
                await next();

            else
            {
                ErrorDto errorDto = new();
                errorDto.Status = 404;

                errorDto.Errors.Add($"The Language with {id} id was not found in database");
                context.Result = new NotFoundObjectResult(errorDto);
            }
        }
    }
}
