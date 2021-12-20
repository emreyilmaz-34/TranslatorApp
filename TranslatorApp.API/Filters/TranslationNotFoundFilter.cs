using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;
using TranslatorApp.API.DTOs;
using TranslatorApp.Core.Service;

namespace TranslatorApp.API.Filters
{
    public class TranslationNotFoundFilter : ActionFilterAttribute
    {
        readonly ITranslationService _translationService;

        public TranslationNotFoundFilter(ITranslationService translationService)
        {
            _translationService = translationService;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault();

            var translation = await _translationService.GetByIdAsync(id);

            if (translation != null)
                await next();

            else
            {
                ErrorDto errorDto = new();
                errorDto.Status = 404;

                errorDto.Errors.Add($"The Translation with {id} id was not found in database");
                context.Result = new NotFoundObjectResult(errorDto);
            }
        }
    }
}
