namespace ECommerce.MVC.Models
{
    public class HomeIndexModel
    {
        public IEnumerable<CategoryModel> Categories { get; set; }
        public IEnumerable<ProductModel> Products { get; set; }
    }
}
