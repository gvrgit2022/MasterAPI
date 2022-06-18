using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterAPI.ApiResponseModel.Attributes
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class JsonApiIdAttribute : Attribute
	{

	}
}
