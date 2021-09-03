using ECOMMERCE_SITE.Models;
using ECOMMERCE_SITE.Models.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOMMERCE_SITE.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductContext _context; 
        public ProductController(ProductContext context)
        {
            _context = context; 
        }
        ///Displays a view that lists all products
        public IActionResult Index()
        {
            // get all products
            List<Product> products = _context.Products.ToList();
            

            // send list of products to view to be displayed
            return View(products);
        }

        public IActionResult AddView()
        {
            return View();
        }
        public async Task<IActionResult> Add([Bind("ProductId,Title,Price,Category")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }


        public IActionResult Delete(int id)
        {
            Product p = _context
                .Products
                .Where(s => s.ProductId == id)
                .Single();

            return View(p);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            Product p = _context
               .Products
               .Where(s => s.ProductId == id)
               .Single();

            _context.Remove(p);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            Product p = _context
                .Products
                .Where(s => s.ProductId == id)
                .Single();

            return View(p);
        }

        [HttpPost, ActionName("Edit")]
        public async Task<IActionResult> Edited(Product p)
        {
            if (ModelState.IsValid)
            {
                _context.Update(p);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(p);
        }
    }
}
