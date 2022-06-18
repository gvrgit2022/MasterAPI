using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace MasterAPI.Exceptions
{
	public class AggregateApiException : ApiException
	{
		private readonly List<ApiException>  _apiExceptions = new List<ApiException>();

		public IEnumerable<ApiException> ApiExceptions => _apiExceptions;

		public AggregateApiException(HttpStatusCode httpStatusCode, string errorId, string errorTitle, string message, string errorCode = "", params ApiException[] apiExceptions) : base(httpStatusCode, errorId, errorTitle, message, errorCode)
		{
			AddApiExceptions(apiExceptions);
		}

		public AggregateApiException(HttpStatusCode httpStatusCode, string errorId, string errorTitle, string message, IEnumerable<ApiException> apiExceptions, string errorCode = "") : base(httpStatusCode, errorId, errorTitle, message, errorCode)
		{
			AddApiExceptions(apiExceptions);
		}
		public AggregateApiException(string errorId, string errorTitle, string message, string errorCode = "", params ApiException[] apiExceptions) : base(errorId, errorTitle, message, null, errorCode)
		{
			AddApiExceptions(apiExceptions);
		}
		public AggregateApiException(string errorId, string errorTitle, string message, IEnumerable<ApiException> apiExceptions, string errorCode = "") : base(errorId, errorTitle, message, null, errorCode)
		{
			AddApiExceptions(apiExceptions);
		}

		public AggregateApiException(string errorId, string message, string errorCode = "", params ApiException[] apiExceptions) : base(errorId, message, errorCode)
		{
			AddApiExceptions(apiExceptions);
		}
		public AggregateApiException(string errorId, string message, IEnumerable<ApiException> apiExceptions, string errorCode = "") : base(errorId, message, errorCode)
		{
			AddApiExceptions(apiExceptions);
		}
		public AggregateApiException(string errorId, Exception exception, IEnumerable<ApiException> apiExceptions, string errorCode = "") : base(errorId, exception, errorCode)
		{
			AddApiExceptions(apiExceptions);
		}

		public AggregateApiException(string errorId, Exception exception, string errorCode = "", params ApiException[] apiExceptions) : base(errorId, exception, errorCode)
		{
			AddApiExceptions(apiExceptions);
		}
		public AggregateApiException(HttpStatusCode httpStatusCode, string errorTitle, string errorCode = "", params ApiException[] apiExceptions) : base(httpStatusCode, errorTitle, "Aggregate exception occured.", errorCode, string.Empty)
		{
			AddApiExceptions(apiExceptions);
		}
		public AggregateApiException(HttpStatusCode httpStatusCode, string errorTitle, string errorCode = "") : base(httpStatusCode, errorTitle, "Aggregate exception occured.", errorCode, string.Empty)
		{
	
		}

		public void AddApiException(ApiException apiException)
		{
			_apiExceptions.Add(apiException);
		}
		public void AddApiExceptions(IEnumerable<ApiException> apiExceptions)
		{
			_apiExceptions.AddRange(apiExceptions);
		}

		
	}
}
