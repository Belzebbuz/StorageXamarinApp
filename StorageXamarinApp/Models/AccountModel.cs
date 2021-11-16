using Refit;
using System.Text.Json.Serialization;

namespace StorageXamarinApp.Models
{
    public class AccountModel
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

    }
}
