using Refit;
using System.Text.Json.Serialization;

namespace StorageXamarinApp.Models
{
    public class Account
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

    }
}
