using ECOMMERCE_SITE.Models;
using ECOMMERCE_SITE.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> Register(RegisterViewModel reg)
        {
            if (ModelState.IsValid)
            {
                User User = new User()
                {
                    DateOfBirth = reg.DateOfBirth,
                    Email = reg.Email,
                    Password = reg.Password,
                    UserName = reg.Username
                };
                _context.Users.Add(User);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Home"); 
            }

            return View(reg);
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Login(LoginViewModel model)
        {
            User user = await
                (from u in _context.Users
                 where u.UserName == model.Username
                 && u.Password == model.Password
                 select u).SingleOrDefaultAsync();
            if(User == null)
            {
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
