using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOMMERCE_SITE.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Add(int id)
        {
            return View();
        }
        public IActionResult Summary()
        {
            return View();
        }
    }
}
