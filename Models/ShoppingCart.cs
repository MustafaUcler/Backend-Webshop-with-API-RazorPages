namespace BackendApp1.Models
{
    public class ShoppingCart
    {
        public int ShoppingCartId { get; set; }
        public string UserId { get; set; }
        public int ProductId { get; set; }
        public List<Product> Products { get; set; }
    }
}
