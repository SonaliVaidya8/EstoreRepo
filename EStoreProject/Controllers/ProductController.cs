using EStoreProject.DataAccess.Interfaces;
using EStoreProject.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStoreProject.Controllers
{
    [Authorize]

    public class ProductController : Controller
    {
        
        private readonly IProductContextDb _context;
        public ProductController(IProductContextDb context)
        {
      _context = context;
        }
        //cart
        //List<Products> li = new List<Products>();

        //...
        // GET: ProductController
        public IActionResult Index()
        {
            List<Products> productList = _context.GetAllProduct().ToList();
            return View(productList);
        }
          
        [HttpGet]
        public async Task<IActionResult> Index(string Productsearch)
        {
            ViewData["GetAllProduct"] = Productsearch;
            var productquery = from x in _context.GetAllProduct() select x;
            if(!String.IsNullOrEmpty(Productsearch))
            {
                productquery = productquery.Where(x => x.ProductName.Contains(Productsearch) || x.ProductCategoryName.Contains(Productsearch));
            }
            return View(productquery);
        }


        // GET: ProductController/Details/5
        public ActionResult GetProductById(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            Products product = _context.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // GET: ProductController/Create
        public IActionResult CreateNewProduct()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateNewProduct([Bind] Products product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.CreateNewProduct(product);
                    return RedirectToAction("Index");
                }
                return View(product);
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult UpdateProduct(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            Products product = _context.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateProduct(int id, [Bind] Products product)
        {
            try
            {
                if (id <= 0)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    _context.UpdateProduct(product);
                    return RedirectToAction("Index");

                }
                return View(_context);
            }
            catch
            {
                return View();
            }
        }


        // GET: ProductController/Delete/5
        public ActionResult DeleteProduct(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            Products product = _context.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost, ActionName("DeleteProduct")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _context.DeleteProduct(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        //Add to cart
        /*
        public ActionResult Cart(int id)
        {
            ViewData["GetAllProduct"] = id;
            var query = from x in _context.GetAllProduct() select x;
            query = (IEnumerable<Products>)query.Where(x => x.ProductId == id).SingleOrDefault();
            return View(query);

        }

        [HttpPost]
        public ActionResult AddtoCart(int id, int qty)
        {
            ViewData["GetAllProduct"] = id;
            Products product = (Products)(from x in _context.GetAllProduct() select x);
            product = (IEnumerable<Products>)product.Where(x => x.ProductId == id).SingleOrDefault();
            Products cart = new Products();
            cart.ProductId = id;
            cart.ProductName = product.ProductName;
            cart.ProductPrice = Convert.ToInt32(product.ToString());
            cart.ProductDescription = product.ProductDescription;
            if (TempData["cart"]==null)
            {
                li.Add(product);
                TempData["cart"] = li;
            }
            //TempData.Keep();
            return RedirectToAction("Index");
        }
            
        */
    }
}


