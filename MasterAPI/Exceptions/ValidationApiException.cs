using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MasterAPI.Exceptions
{
	public class ValidationApiException : ApiException
	{
		public ValidationApiException(HttpStatusCode httpStatusCode, string errorId, string errorTitle, string message, string errorCode = "", string errorPointer = "") : base(httpStatusCode, errorId, errorTitle, message, errorCode, errorPointer)
		{
		}
	
		public ValidationApiException(string message, string errorCode = "", string errorPointer = "") : base(HttpStatusCode.BadRequest, "", "Invalid request.", message, errorCode, errorPointer)
		{
		}
		public ValidationApiException(string errorTitle, string message, string errorCode = "", string errorPointer = "") : base(HttpStatusCode.BadRequest, "", errorTitle, message, errorCode, errorPointer)
		{
		}
	}
}
