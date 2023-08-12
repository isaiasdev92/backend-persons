using System;
using Newtonsoft.Json;

namespace ExameSoftware.Dtos
{
	public class ApiResponse<T>
	{
		public ApiResponse()
		{	
		}

		public ApiResponse(T data)
		{
			Data = data;
		}

		[JsonProperty("data")]
		public T? Data { get; set; }

        [JsonProperty("errors")]
        public List<string>? Errors { get; set; }
	}
}

