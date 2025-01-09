using System.Text.Json.Serialization;

namespace ECommerce.MVC.Models
{
    public class OrderModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("applicationUserId")]
        public string ApplicationUserId { get; set; }

        [JsonPropertyName("orderItems")]
        public List<OrderItemModel> OrderItems { get; set; }

        [JsonPropertyName("orderStatus")]
        public int OrderStatus { get; set; }

        [JsonPropertyName("createdDate")]
        public DateTime CreatedDate { get; set; }

        [JsonPropertyName("totalAmount")]
        public decimal TotalAmount { get; set; }
    }
}
