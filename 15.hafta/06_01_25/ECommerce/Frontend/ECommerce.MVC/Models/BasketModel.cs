using System.Text.Json.Serialization;

namespace ECommerce.MVC.Models
{
    public class BasketModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("applicationUserId")]
        public string ApplicationUserId { get; set; }

        [JsonPropertyName("basketItems")]
        public List<BasketItemModel> BasketItems { get; set; }
    }
}
