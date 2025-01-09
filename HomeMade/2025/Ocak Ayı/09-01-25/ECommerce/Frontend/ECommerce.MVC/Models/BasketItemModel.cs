using System.Text.Json.Serialization;

namespace ECommerce.MVC.Models
{
    public class BasketItemModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("basketId")]
        public int BasketId { get; set; }
        [JsonPropertyName("productId")]
        public int ProductId { get; set; }
        [JsonPropertyName("product")]
        public ProductModel Product { get; set; }
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }
    }
}

// buraların hepsini kısa kesicem şimdi nav propları buralarda almıyoruz  hepsini üstüne jsonpropname ile ilgili json başlığına eşitliyoruz ki gelen ve giden verileri ben hem kodumd akullanıyim hemde kodumdaki karşıya gidicek veriler istediğim şekilde ve kuralla ilgili jsona gitmesi gerek hepsini modellerle yapıyorum tıpkı api de yaptığım DTO lar gibi