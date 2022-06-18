using System.Net;

namespace MasterAPI.Exceptions
{
	public class InvalidRequestParamApiException : ApiException
	{

		public InvalidRequestParamApiException(string message, string errorCode = "", string errorPointer = "") : base(HttpStatusCode.BadRequest, "", "Invalid Request Parameter.", message, errorCode, errorPointer)
		{
		}

	}
}
