using MasterAPI.ApiResponseModel.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MasterAPI.ApiResponseModel
{
	[JsonApiError]
	public class ApiErrorResponse
	{
		/// <summary>
		/// unique id for this occurrence of the error
		/// </summary>
		/// <value>unique id for this occurrence of the error</value>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		/// http status code, e.g. '500'
		/// </summary>
		/// <value>http status code, e.g. '500'</value>

		[JsonProperty("status")]
		public string Status { get; set; }

		/// <summary>
		/// short non unique message about this type of error
		/// </summary>
		/// <value>short non unique message about this type of error</value>

		[JsonProperty("title")]
		public string Title { get; set; }

		/// <summary>
		/// user friendly message about this unique error
		/// </summary>
		/// <value>user friendly message about this unique error</value>

		[JsonProperty("detail")]
		public string Detail { get; set; }

		/// <summary>
		/// reference to the source of the error, optionally including any of the following members; 'pointer'  JSON Pointer to the associated entity in the request document, 'parameter' a string indicating which URI query parameter caused the errorr
		/// </summary>
		/// <value>reference to the source of the error, optionally including any of the following members; 'pointer'  JSON Pointer to the associated entity in the request document, 'parameter' a string indicating which URI query parameter caused the errorr</value>

		[JsonProperty("source")]
		public ApiResponseErrorSource Source { get; set; }

		/// <summary>
		/// business code of the error
		/// </summary>
		/// <value>business code of the error</value>

		[JsonProperty("code")]
		public string Code { get; set; }
		public ApiErrorResponse(HttpStatusCode httpStatus, string id, string title, string detail, string code = "", ApiResponseErrorSource source = null)
		{

			Status = ((int)httpStatus).ToString();
			Id = id;
			Title = title;
			Detail = detail;
			Code = code;
			Source = source;
		}
	}
}
