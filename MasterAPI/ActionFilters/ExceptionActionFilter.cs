using MasterAPI.ApiResponseModel;
using MasterAPI.Exceptions;
using MasterAPI.Application.Common.Exceptions;

    using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ValidationException = FluentValidation.ValidationException;

namespace MasterAPI.ActionFilters
{
    public class ExceptionActionFilter : ExceptionFilterAttribute
    {

        private readonly ILogger<ExceptionActionFilter> _logger;

        public ExceptionActionFilter(ILogger<ExceptionActionFilter> logger)
        {
            _logger = logger;
        }

        public override async Task OnExceptionAsync(ExceptionContext context)
        {
            ApiException apiException;
            var errorList = new List<ApiErrorResponse>();
            //if (!context.HttpContext.Items.TryGetValue(HeaderConstants.CorrelationId, out var correlationId))
            //{
            //    correlationId = string.Empty;
            //}
            var correlationId = Activity.Current.TraceId.ToString();
            if (context.Exception is ArgumentNullException || context.Exception is ArgumentException)
            {
                apiException = new InvalidRequestParamApiException(context.Exception.Message);
                //new ApiException(correlationId?.ToString() ?? string.Empty, context.Exception);
                errorList.Add(ToApiResponse(apiException, correlationId?.ToString()));
                if (context.Exception.InnerException != null)
                {
                    var innerException = new ApiException(apiException.ErrorId, context.Exception.InnerException);
                    errorList.Add(ToApiResponse(innerException, correlationId?.ToString()));
                }
            }
            else if (context.Exception is ValidationException)
            {
                apiException = new ValidationApiException(context.Exception.Message);

                var ve = context.Exception as ValidationException;
                var exceptions = ve.Errors.Select(e => new ValidationApiException(e.ErrorMessage));
                if (exceptions != null)
                    errorList.AddRange(exceptions.Select(e => ToApiResponse(e, correlationId?.ToString())));

                if (context.Exception.InnerException != null && !string.IsNullOrEmpty(context.Exception.InnerException.Message))
                {
                    apiException = new ValidationApiException(context.Exception.InnerException.Message);
                    var innerException = new ApiException(apiException.ErrorId, context.Exception.InnerException);
                    errorList.Add(ToApiResponse(innerException, correlationId?.ToString()));
                }

            }
            else if (context.Exception is DuplicateEntityException)
            {
                apiException = new ApiException(HttpStatusCode.Conflict, "Conflict", context.Exception.Message);
                errorList.Add(ToApiResponse(apiException, correlationId?.ToString()));
            }
            else if (context.Exception is EntityDeleteNotAllowedException)
            {
                apiException = new ApiException(HttpStatusCode.Conflict, "Conflict", context.Exception.Message);
                errorList.Add(ToApiResponse(apiException, correlationId?.ToString()));
            }
            else if (context.Exception is EntityNotFoundException)
            {
                apiException = new NotFoundApiException(context.Exception.Message);
                errorList.Add(ToApiResponse(apiException, correlationId?.ToString()));
            }
            else
            {
                switch (context.Exception)
                {
                    case AggregateApiException aggException:
                        apiException = aggException;
                        errorList = aggException.ApiExceptions.Select(a => ToApiResponse(a, correlationId?.ToString())).ToList();
                        break;
                    case ApiException exception:
                        apiException = exception;
                        errorList.Add(ToApiResponse(apiException, correlationId?.ToString()));
                        if (apiException.InnerException != null)
                        {
                            var innerException = new ApiException(apiException.ErrorId, apiException.InnerException);
                            errorList.Add(ToApiResponse(innerException, correlationId?.ToString()));
                        }

                        break;
                    default:
                        apiException = new ApiException(correlationId?.ToString() ?? string.Empty, context.Exception);
                        errorList.Add(ToApiResponse(apiException, correlationId?.ToString()));
                        if (apiException.InnerException != null)
                        {
                            var innerException = new ApiException(apiException.ErrorId, apiException.InnerException);
                            errorList.Add(ToApiResponse(innerException, correlationId?.ToString()));
                        }

                        break;
                }
            }

            var errorsResponse = new ApiErrorsResponse { Errors = errorList };
            var objectResult = new ObjectResult(errorsResponse) { StatusCode = (int)apiException.ApiHttpStatusCode };
            context.Result = objectResult;
            _logger.LogError(context.Exception, $"An exception has occurred while executing {context.HttpContext.Request.Method} : {context.HttpContext.Request.GetEncodedUrl()}");
            if (context.HttpContext.Request.Method == "POST" || context.HttpContext.Request.Method == "PATCH")
            {
                var requestBody = string.Empty;
                using (StreamReader sr = new StreamReader(context.HttpContext.Request.Body))
                {
                    if (context.HttpContext.Request.Body.CanSeek) context.HttpContext.Request.Body.Seek(0, SeekOrigin.Begin);
                    if (context.HttpContext.Request.Body.CanRead) requestBody = await sr.ReadToEndAsync();
                    _logger.LogError($"Request body from Exception: {requestBody}");
                }
            }
        }

        private static ApiErrorResponse ToApiResponse(ApiException apiException, string errorId)
        {
            return new ApiErrorResponse(apiException.ApiHttpStatusCode,
                errorId,
                apiException.ErrorTitle,
                apiException.Message,
                apiException.ErrorCode,
                source: string.IsNullOrWhiteSpace(apiException.ErrorPointer) ? null : new ApiResponseErrorSource { Pointer = apiException.ErrorPointer });
        }
    }
}
