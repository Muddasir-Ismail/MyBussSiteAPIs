using MyBussSiteAPIs.Models;

namespace MyBussSiteAPIs.Interfaces
{
    public interface ICartService
    {
        public Cart AddToCart (Cart cart);
        public List<Cart> GetAllCartItems();
        public bool DeleteProductFromCartByCustId(int productId);
        public List<Cart> GetCartProductsByCustomerId(int customerId);
    }
}
