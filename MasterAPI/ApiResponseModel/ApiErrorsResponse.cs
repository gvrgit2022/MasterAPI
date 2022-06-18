using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterAPI.ApiResponseModel
{
    public class ApiErrorsResponse
    {
        [JsonProperty("errors")]
        public List<ApiErrorResponse> Errors { get; set; }
    }
}
