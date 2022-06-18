using System.Net;

namespace MasterAPI.Exceptions
{
	public class NotFoundApiException : ApiException
	{

		public NotFoundApiException(string errorId, string message, string errorCode = "", string errorPointer = "") : base(HttpStatusCode.NotFound, errorId, "Not Found.", message, errorCode, errorPointer)
		{
		}
		public NotFoundApiException(string message, string errorCode = "", string errorPointer = "") : base(HttpStatusCode.NotFound, "", "Not Found.", message, errorCode, errorPointer)
		{
		}
	}
}
