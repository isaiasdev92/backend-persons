using Newtonsoft.Json;

namespace ExameSoftware.Dtos
{
	public class PeopleItem
	{
        [JsonProperty("id")]
        public int Id { get; set; }


        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("age")]
        public int Age { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; } = string.Empty;
    }
}

