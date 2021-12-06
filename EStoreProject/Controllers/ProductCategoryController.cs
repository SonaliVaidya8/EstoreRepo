using EStoreProject.DataAccess.Interfaces;
using EStoreProject.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStoreProject.Controllers
{
    [Authorize]

    public class ProductCategoryController : Controller
    {
        private readonly IProductCategoryContextDb _context;
        public ProductCategoryController(IProductCategoryContextDb context)
        {
            _context = context;
        }
        //[Authorize]


        // GET: ProductCategoryController
        public IActionResult Index()
        {
            List<ProductCategory> productCategoryList = _context.GetAllProductCategory().ToList();
            return View(productCategoryList);
        }

        [HttpGet]
        public async Task<IActionResult> Index(string Productsearch)
        {
            ViewData["GetAllProductCategory"] = Productsearch;
            var productquery = from x in _context.GetAllProductCategory() select x;
            if (!String.IsNullOrEmpty(Productsearch))
            {
                productquery = productquery.Where(x => x.ProductCategoryName.Contains(Productsearch));
            }
            return View(productquery);
        }

        // GET: ProductCategoryController/Details/5
        public ActionResult GetProductCategoryById(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            ProductCategory productCategory = _context.GetProductCategoryById(id);
            if (productCategory == null)
            {
                return NotFound();
            }
            return View(productCategory);
        }
    

        // GET: ProductCategoryController/Create
        public IActionResult CreateProductCategory()
        {
            return View();
        }

        // POST: ProductCategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateProductCategory([Bind] ProductCategory productCategory)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.CreateProductCategory(productCategory);
                    return RedirectToAction("Index");
                }
                return View(productCategory);
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductCategoryController/Edit/5
        public ActionResult UpdateProductCategory(int id)
        {

            if (id <= 0)
            {
                return NotFound();
            }
            ProductCategory productCategory = _context.GetProductCategoryById(id);
            if (productCategory == null)
            {
                return NotFound();
            }
            return View(productCategory);
        }
    

        // POST: ProductCategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateProductCategory(int id, [Bind] ProductCategory productCategory)
        {
            try
            {
                if (id <= 0)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    _context.UpdateProductCategory(productCategory);
                    return RedirectToAction("Index");

                }
                return View(_context);
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductCategoryController/Delete/5
        public ActionResult DeleteProductCategory(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            ProductCategory productCategory = _context.GetProductCategoryById(id);
            if (productCategory == null)
            {
                return NotFound();
            }
            return View(productCategory);
        }

        // POST: ProductCategoryController/Delete/5
        [HttpPost, ActionName("DeleteProductCategory")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _context.DeleteProductCategory(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
