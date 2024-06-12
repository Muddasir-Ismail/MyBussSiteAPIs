using MyBussSiteAPIs.Context;
using MyBussSiteAPIs.Interfaces;
using MyBussSiteAPIs.Models;

namespace MyBussSiteAPIs.Services
{
    public class CartServices : ICartService
    {
        private readonly dbContext _dbContext;
        public CartServices(dbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Cart AddToCart(Cart cart)
        {
            var addCart = _dbContext.Add(cart);
            _dbContext.SaveChanges();
            return addCart.Entity;
        }

        public bool DeleteProductFromCartByCustId(int productId)
        {
            var deleteCart = _dbContext.carts.SingleOrDefault(s => s.ProductId == productId);
            if(deleteCart != null)
            {
                _dbContext.carts.Remove(deleteCart);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Cart> GetAllCartItems()
        {
            var list = _dbContext.carts.ToList();
            return list;
        }

        public List<Cart> GetCartProductsByCustomerId(int customerId)
        {
            var getCart = _dbContext.carts.Where(s => s.CustomerId ==  customerId).ToList();
            return getCart;
        }
    }
}
