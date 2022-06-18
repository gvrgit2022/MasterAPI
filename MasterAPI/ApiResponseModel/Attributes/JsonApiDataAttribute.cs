using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterAPI.ApiResponseModel.Attributes
{
	[AttributeUsage(AttributeTargets.Class)]
	public class JsonApiDataAttribute : System.Attribute
	{
		private string TypeName { get; set; }
		private string DataAttributeOverride { get; set; }

		public JsonApiDataAttribute()
		{

		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="typeName">type for the this object to be returned when serialized</param>
		/// <param name="dataAttribueOverride">Override data attribute.</param>
		public JsonApiDataAttribute(string typeName = null, string dataAttributeOverride = null)
		{
			TypeName = typeName;
			DataAttributeOverride = dataAttributeOverride;
		}
	}
}
