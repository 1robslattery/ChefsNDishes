using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ChefNDishes.Models;

namespace ChefNDishes.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            List<Chef> c = dbContext.Chefs.Include(d=>d.nameofdish).ToList();
            ViewBag.All = c;
            return View();
        }

        // New Chef - Create a .cshtml with a form/fields
        [HttpGet("AddChef")]
        public IActionResult NewChef()
        {
            return View("AddChef");
        }

        // Create Chef - This model and constructor actually creates the chef and sends to MySql db
        [HttpPost("createChef")]
        public IActionResult createChef(Chef c)
        {
            if(ModelState.IsValid)
            {
                int Current = DateTime.Now.Year;
                int ChefBirthday = c.BirthDate.Year;
                int ChefAge = Current-ChefBirthday;
                c.Age = ChefAge;
                dbContext.Add(c);
                Console.WriteLine("************** Model is Valid **************");
                dbContext.SaveChanges();

                return Redirect("/");
            }
            else
            {
                // Oh no!  We need to return a ViewResponse to preserve the ModelState, and the errors it now contains!
                Console.WriteLine("************** Model is Invalid **************");
                return View("AddChef");
            }
        }

        // New Dish - Create a .cshtml with a form/fields
        [HttpGet("AddDish")]
        public IActionResult AddDish()
        {
            List<Chef> chef = dbContext.Chefs.ToList();
            ViewBag.All = chef;
            return View("AddDish");
        }

        // Create Dish - This model and constructor actually creates the Dish and sends to MySql db
        [HttpPost("createDish")]
        public IActionResult createDish(Dish d)
        {
            if(ModelState.IsValid)
            {

                dbContext.Add(d);
                Console.WriteLine("************** Model is Valid **************");
                dbContext.SaveChanges();
                return Redirect("/Dish");
            }
            else
            {
                List<Chef> chef = dbContext.Chefs.ToList();
                ViewBag.All = chef;
                Console.WriteLine("************** Model is Invalid **************");
                return View("AddDish");
            }
        }

            // New Dish - Create a .cshtml with a form/fields
            [HttpGet("Dish")]
            public IActionResult Dish()
            {
                List<Dish> dish = dbContext.Dishes.ToList();
                ViewBag.All = dish;
                foreach(var x in dish){
                    Chef cook = dbContext.Chefs.SingleOrDefault(c => c.ChefID == x.ChefID);
                }
                return View("Dish");
            }

        [HttpGet("/Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        // This section allows us to use mySQL query links.
        // The first line is the model the rest is the constructor.
        private MyContext dbContext;
        public HomeController(MyContext context)
        {
            dbContext = context;
        }

    }
}