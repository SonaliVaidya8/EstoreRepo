using EStoreProject.DataAccess.Interfaces;
using EStoreProject.Model;
using EStoreProject.Models;
using EStoreProject.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EStoreProject.Controllers
{
    public class HomeController : Controller

    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductContextDb _context;

        public HomeController(ILogger<HomeController> logger, IProductContextDb context)
        {
            _context = context;

            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Saree()
        {
            return View();
        }

        public IActionResult TShirts()
        {
            return View();
        }

        public IActionResult CasualShirts()
        {
            return View();
        }

        public IActionResult WomensEthnicSets()
        {
            return View();
        }

        public IActionResult Jeans()
        {
            return View();
        }

        public IActionResult WomenDresses()
        {
            return View();
        }

        public IActionResult ProductDetails(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            Products product = _context.GetProductById(id);
            if(product == null)
            {
                return NotFound();
            }
            return View(product);
        }
       
        //cart
        [HttpPost, ActionName("ProductDetails")]
        public IActionResult ProductDetail(int id)
        {
            List<Products> products = new List<Products>();
            if (id == null)
            {
                return NotFound();
            }
            var product = _context.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            products = HttpContext.Session.Get<List<Products>>("products");
            if (products == null)
            {
                products = new List<Products>();
            }
            products.Add(product);
            HttpContext.Session.Set("products", products);
            return RedirectToAction("Cart");

        }

        public IActionResult Cart()
        {
            List<Products> products = HttpContext.Session.Get<List<Products>>("products");
            if(products==null)
            {
                products = new List<Products>();
            }
            return View(products);
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
