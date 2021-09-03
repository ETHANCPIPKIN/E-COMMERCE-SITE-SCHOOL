using ECOMMERCE_SITE.Models;
using ECOMMERCE_SITE.Models.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOMMERCE_SITE.Controllers
{
    public class UserController : Controller
    {
        private readonly ProductContext _context;
        
        public UserController(ProductContext context)
        {
            _context = context; 
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel reg)
        {
            if (ModelState.IsValid)
            {
                User User = new User()
                {
                    DateOfBirth = reg.DateOfBirth,
                    Email = reg.Email,
                    Password = reg.Password,
                };
            }

            return View(reg);
        }
    }
}
