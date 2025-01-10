using Newtonsoft.Json;
using System;
using System.Linq;

namespace WebVella.Erp.Api.Models
{
    public class QueryResponse : BaseResponseModel
    {
		public QueryResponse() {
			Object = new QueryResult();
		}

		[JsonProperty(PropertyName = "object")]
        public QueryResult Object { get; set; }

		public static QueryResponse Error(string message)
		{
			QueryResponse response = new QueryResponse
			{
				Success = false,
				Object = null,
				Timestamp = DateTime.UtcNow
			};
			response.Errors.Add(new ErrorModel { Message = message });
			return response;
		}

		public string GetMessage()
		{
			var messages = Errors
				.Select(e => e.Message)
				.Prepend(Message);

			return string.Join(Environment.NewLine, messages);
		}
	}
}
