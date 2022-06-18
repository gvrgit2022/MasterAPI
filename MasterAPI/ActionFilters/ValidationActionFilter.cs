using MasterAPI.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterAPI.ActionFilters
{
    public class ValidationActionFilter : ActionFilterAttribute
    {
        private readonly ILogger<ValidationActionFilter> _logger;

        public ValidationActionFilter(ILogger<ValidationActionFilter> logger)
        {
            _logger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            var modelState = actionContext.ModelState;
            var errorTitle = "Failed to deserialize api request body.";
            if (!modelState.IsValid)
            {
                _logger.LogCritical(errorTitle);
                var validationsError = new ValidationsApiException(errorTitle);
                foreach (var m in modelState.Values)
                {
                    foreach (var e in m.Errors)
                    {
                        validationsError.AddValidationException(e.Exception != null ? e.Exception.Message : e.ErrorMessage);
                        _logger.LogError(e.Exception != null ? e.Exception.Message : e.ErrorMessage);
                    }

                }
                throw validationsError;
            }
        }
    }
}
