using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ExameSoftware.Dtos
{
	public class PeopleRequest
	{
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("age")]
        public int Age { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; } = string.Empty;
    }
}

