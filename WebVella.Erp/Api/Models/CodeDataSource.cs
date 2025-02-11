using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WebVella.Erp.Api.Models
{
	public abstract class CodeDataSource : DataSourceBase
	{
		[JsonProperty(PropertyName = "type")]
		public override DataSourceType Type { get { return DataSourceType.CODE; } }

		[JsonProperty(PropertyName = "result_model")]
		public override string ResultModel { get; set; } = "object";

		public abstract object Execute(Dictionary<string, object> arguments);

		protected static T? EnumValueFromParameter<T>(object o)
		{
			if (o is T state)
				return state;

			var type = Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);

			if (o is int i)
				return (T)Enum.ToObject(type, i);

			if (o is string s)
			{
				if (type.IsEnum && Enum.TryParse(type, s, true, out var obj))
					return (T)obj;
				if (int.TryParse(s, out i))
					return (T)Enum.ToObject(type, i);
			}
			return default;
		}
	}
}
