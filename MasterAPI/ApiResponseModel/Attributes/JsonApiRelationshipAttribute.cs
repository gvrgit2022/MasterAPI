using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterAPI.ApiResponseModel.Attributes
{
	public class JsonApiRelationshipAttribute : Attribute
	{
		private string TypeName { get; set; }
		public JsonApiRelationshipAttribute(string typeName)
		{
			TypeName = typeName;
		}
		public JsonApiRelationshipAttribute()
		{

		}
	}
}
