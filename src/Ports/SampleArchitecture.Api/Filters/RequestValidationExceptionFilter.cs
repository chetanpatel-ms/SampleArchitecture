using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SampleArchitecture.Api.Exceptions;
using System.Collections;

namespace SampleArchitecture.Api.Filters
{
    /// <summary>
    /// The request validation exception filter.
    /// </summary>
    /// <seealso cref="IExceptionFilter" />
    /// .
    internal class RequestValidationExceptionFilter : IExceptionFilter
    {
        /// <inheritdoc />
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is not RequestValidationException)
            {
                return;
            }

            ModelStateDictionary modelState = new();

            foreach (DictionaryEntry entry in context.Exception.Data)
            {
                modelState.AddModelError(entry.Key.ToString(), entry.Value.ToString());
            }

            context.Result = new BadRequestObjectResult(modelState);
            context.ExceptionHandled = true;
        }
    }
}