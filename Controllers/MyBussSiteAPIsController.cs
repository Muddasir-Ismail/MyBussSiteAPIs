using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBussSiteAPIs.Interfaces;
using MyBussSiteAPIs.Models;

namespace MyBussSiteAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("*")]
    [Produces("application/json")]
    public class MyBussSiteAPIsController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ICartService _cartService;
        private readonly ICateoryService _cateoryService;
        private readonly IProductService _productService;
        public MyBussSiteAPIsController(IAuthService authService, ICartService cartService, ICateoryService cateoryService, IProductService productService)
        {
            _authService = authService;
            _cartService = cartService;
            _cateoryService = cateoryService;
            _productService = productService;
        }

        [HttpPost("Login")]
        public string Login([FromBody] LoginRequest loginReq)
        {
            var login = _authService.Login(loginReq);
            return login;
        }

        [HttpPost("Register")]
        public Register AddUser([FromBody] Register reg)
        {
            var register = new Register
            {
                Name = reg.Name,
                Email = reg.Email,
                Password = reg.Password,
            };

            var addUser = _authService.AddUser(reg);
            return addUser;
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("updateUserProfile")]
        public Register Put(int id, [FromForm] Register register)
        {
            var updateProfile = _authService.UpdateUser(register);
            return updateProfile;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getCustomerById")]
        public Register Get(int id)
        {
            var getById = _authService.GetAllUserById(id);
            return getById;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getAllCustomer")]
        public List<Register> Get()
        {
            var getUser = _authService.GetAllUsers();
            return getUser;
        }


        // GET: api/<CartController>
        [HttpGet("getAllCartItems")]
        public List<Cart> GetAllCartItems()
        {
            var list = _cartService.GetAllCartItems();
            return list;
        }

        // GET api/<CartController>/5
        [HttpGet("getCartProductsByCustomerId")]
        public List<Cart> GetCartProductsByCustomerId(int customerId)
        {
            var res = _cartService.GetCartProductsByCustomerId(customerId);
            return res;
        }

        // POST api/<CartController>
        [HttpPost("addToCart")]
        public Cart Post([FromBody] Cart cart)
        {
            var add = _cartService.AddToCart(cart);
            return add;
        }


        // DELETE api/<CartController>/5
        [HttpDelete("deleteProductFromCartById")]
        public bool Delete(int productId)
        {
            var delete = _cartService.DeleteProductFromCartByCustId(productId);
            return delete;
        }


        // GET: api/<CategoryController>
        [HttpGet("getAllCategory")]
        public List<Category> GetAllCategories()
        {
            var list = _cateoryService.GetAllCategories();
            return list;
        }

        //// GET api/<CategoryController>/5
        [HttpGet("getCategoryById")]
        public Category GetCategoryId(int id)
        {
            var cat = _cateoryService.GetCategoryById(id);
            return cat;
        }

        // POST api/<CategoryController>
        [HttpPost("addCategory")]
        public Category Post([FromBody] Category category)
        {
            var addCat = _cateoryService.AddCategory(category);
            return addCat;
        }

        //// PUT api/<CategoryController>/5
        [HttpPut("updateCategoryById")]
        public Category Put(int id, [FromBody] Category category)
        {
            var updateCat = _cateoryService.UpdateCategory(category);
            return updateCat;
        }

        //// DELETE api/<CategoryController>/5
        [HttpDelete("deleteCategoryById")]
        public bool DeleteCategory(int id)
        {
            var deleteCat = _cateoryService.DeleteCategory(id);
            return deleteCat;
        }



        // GET: api/<ProductController>
        [HttpGet("getAllProducts")]
        public List<Product> GetAllProducts()
        {
            var pro = _productService.GetAllProducts();
            return pro;
        }

        [HttpGet("getAllProductsByCategoryId")]
        public List<Product> GetProCustById(int categoryId)
        {
            var list1 = _productService.GetAllProductsByCategoryId(categoryId);
            return list1;
        }
        // GET api/<ProductController>/5
        [HttpGet("getProductById")]
        public Product GetProductById(int id)
        {
            var pro = _productService.GetProductById(id);
            return pro;
        }

        // POST api/<ProductController>
        [HttpPost("addProduct")]
        public Product Post([FromBody] Product product)
        {
            var addPro = _productService.AddProduct(product);
            return addPro;
        }

        // PUT api/<ProductController>/5
        [HttpPut("updateProductById")]
        public Product Put(int id, [FromBody] Product product)
        {
            var updatePro = _productService.UpdateProduct(product);
            return updatePro;
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("deleteProductById")]
        public bool DeleteProduct(int id)
        {
            var deletePro = _productService.DeleteProduct(id);
            return deletePro;
        }
    }
}
