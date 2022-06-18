using MasterAPI.ApiResponseModel;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MasterAPI.Exceptions
{
    public class ApiErrorsResponseException : ApiException
    {
        private readonly ApiErrorsResponse _apiErrorsResponse = new ApiErrorsResponse();
        public ApiErrorsResponse ApiErrorsResponse => _apiErrorsResponse;

        public ApiErrorsResponseException(ApiErrorsResponse apiErrorsResponse, HttpStatusCode httpStatusCode, string errorTitle, string message) :
            base(httpStatusCode, errorTitle, message)
        {
            _apiErrorsResponse = apiErrorsResponse;
        }
    }
}
