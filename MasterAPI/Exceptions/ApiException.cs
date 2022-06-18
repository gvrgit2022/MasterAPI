using System;
using System.Net;

namespace MasterAPI.Exceptions
{
	public class ApiException : Exception
	{
		public string ErrorId { get; set; }
		public HttpStatusCode ApiHttpStatusCode { get; set; } = HttpStatusCode.InternalServerError;
		public string ErrorTitle { get; set; } = "An exception has occured.";
		public string ErrorCode { get; set; }
		public string ErrorPointer { get; set; }
		public ApiException(HttpStatusCode httpStatusCode, string errorId, string errorTitle, string message, string errorCode = "", string errorPointer = "") : base(message)
		{
			ValidateStatusCode(httpStatusCode);
			ApiHttpStatusCode = httpStatusCode;
			ErrorTitle = errorTitle;
			ErrorId = errorId;
			ErrorCode = errorCode;
			ErrorPointer = errorPointer;
		}

		public ApiException(string errorId, string errorTitle, string message, Exception innerException, string errorCode = "", string errorPointer = "") : base(message, innerException)
		{
			ErrorTitle = errorTitle;
			ErrorId = errorId;
			ErrorCode = errorCode;
			ErrorPointer = errorPointer;
		}

		public ApiException(string errorId, string message, string errorCode = "", string errorPointer = "") : base(message)
		{
			ErrorId = errorId;
			ErrorCode = errorCode;
			ErrorPointer = errorPointer;
		}

		public ApiException(string errorId, Exception exception, string errorCode = "", string errorPointer = "") : base(exception.Message, exception.InnerException)
		{
			ErrorId = errorId;
			ErrorCode = errorCode;
			ErrorPointer = errorPointer;
		}

		public ApiException(HttpStatusCode httpStatusCode, string errorTitle, string message, string errorCode = "", string errorPointer = "") : base(message)
		{
			ValidateStatusCode(httpStatusCode);
			ApiHttpStatusCode = httpStatusCode;
			ErrorTitle = errorTitle;
			ErrorCode = errorCode;
			ErrorPointer = errorPointer;
		}

		public ApiException(string errorTitle, string message, Exception innerException, string errorCode = "", string errorPointer = "") : base(message, innerException)
		{
			ErrorTitle = errorTitle;
			ErrorCode = errorCode;
			ErrorPointer = errorPointer;
		}

		public ApiException(string message, string errorCode = "", string errorPointer = "") : base(message)
		{
			ErrorCode = errorCode;
			ErrorPointer = errorPointer;
		}

		public ApiException( Exception exception, string errorCode = "", string errorPointer = "") : base(exception.Message, exception.InnerException)
		{
			ErrorCode = errorCode;
			ErrorPointer = errorPointer;
		}

		private void ValidateStatusCode(HttpStatusCode httpStatusCode)
		{
			if ((int)httpStatusCode < 400)
			{
				throw new ArgumentException($"Invalid {nameof(httpStatusCode)} value. Status code should only be error status codes.");
			}
		}
	}
}
