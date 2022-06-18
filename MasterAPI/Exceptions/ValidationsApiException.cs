using System.Collections.Generic;
using System.Net;

namespace MasterAPI.Exceptions
{
	public class ValidationsApiException : AggregateApiException
	{
		public ValidationsApiException(HttpStatusCode httpStatusCode, string errorTitle, string errorCode = "") : base(httpStatusCode, errorTitle, errorCode)
		{
		}
		public ValidationsApiException(string errorTitle, string errorCode = "") : base(HttpStatusCode.BadRequest, errorTitle, errorCode)
		{

		}

		public void AddValidationException(HttpStatusCode statusCode, string errorTitle, string message, string errorCode = "", string errorPointer = "")
		{
			AddApiException(new ApiException(statusCode, errorTitle, message, errorCode, errorPointer));
		}

		public void AddValidationException(string errorTitle, string message, string errorCode = "", string errorPointer = "")
		{
			AddValidationException(HttpStatusCode.BadRequest, errorTitle, message, errorCode, errorPointer);
		}
		public void AddValidationException(string message, string errorCode = "", string errorPointer = "")
		{
			AddValidationException(HttpStatusCode.BadRequest, ErrorTitle, message, errorCode, errorPointer);
		}

		public void AddValidationException(ValidationApiException validationApiException)
		{
			AddApiException(validationApiException);
		}

	    public void AddValidationExceptions(IEnumerable<ValidationApiException> validationApiExceptions)
	    {
	        AddApiExceptions(validationApiExceptions);
	    }
    }
}
