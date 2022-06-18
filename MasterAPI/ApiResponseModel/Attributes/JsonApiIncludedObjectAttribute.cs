using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterAPI.ApiResponseModel.Attributes
{
	[AttributeUsage(AttributeTargets.Class)]
	public class JsonApiIncludedObjectAttribute : Attribute
	{
		private string TypeName { get; set; }
		public JsonApiIncludedObjectAttribute(string typeName)
		{
			TypeName = typeName;
		}
		public JsonApiIncludedObjectAttribute()
		{

		}
	}
}
