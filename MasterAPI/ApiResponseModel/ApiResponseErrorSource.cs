using MasterAPI.ApiResponseModel.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterAPI.ApiResponseModel
{
	[JsonApiData]
	public class ApiResponseErrorSource
	{
		[JsonProperty("pointer")]
		public string Pointer { get; set; }
	}
}
