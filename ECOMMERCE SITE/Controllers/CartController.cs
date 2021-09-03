using ECOMMERCE_SITE.Models;
using ECOMMERCE_SITE.Models.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOMMERCE_SITE.Controllers
{
    public class CartController : Controller
    { 

        private readonly ProductContext _context;
        private readonly IHttpContextAccessor _httpContext;
        public CartController(ProductContext context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }
        public async Task<IActionResult> Add(int id)
        {
            Product p = await (from products in _context.Products
                               where products.ProductId == id
                               select products).SingleAsync();

            string existingItems = _httpContext.HttpContext.Request.Cookies["CartCookie"];

            List<Product> cartProducts = new List<Product>();
            if(existingItems != null)
            {
              cartProducts = JsonConvert.DeserializeObject<List<Product>>(existingItems); 
            }

            cartProducts.Add(p);
            string data = JsonConvert.SerializeObject(p);
            CookieOptions options = new CookieOptions()
            {
                Expires = DateTime.Now.AddYears(1),
                Secure = true,
                IsEssential = true
            };

            _httpContext.HttpContext.Response.Cookies.Append("CartCookie", data, options); 

            return RedirectToAction("Index", "Product");
        }

        private void SingleorDefaultAsync()
        {
            throw new NotImplementedException();
        }

        public IActionResult Summary()
        {
            return View();
        }
    }
}
