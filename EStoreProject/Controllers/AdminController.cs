using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EStoreProject.DataAccess;
using EStoreProject.Model;

namespace EStoreProject.Controllers
{
    public class AdminController : Controller
    {
        AdminContextDb _contextDb = new AdminContextDb();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateAdmin()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAdmin([Bind] Admin ad)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contextDb.AddAdmin(ad);
                    return RedirectToAction("Index");

                }
                return View(ad);
            }
            catch
            {
                return View();
            }
        }

        public IActionResult GetByAdEmail_id(string email_id)
        {
            /*
            int result = _contextDb.GetByEmail_id(email_id);
            if (result == 1)
            {
                TempData["msg"] = "you are welcome you have loged In";
            }
            else
            {
                TempData["msg"] = "Email id or Password is wrong";
            }
            return View();
            */
            if (email_id==null)
            {
                return NotFound();
            }
            Admin admin = _contextDb.GetByEmail_id(email_id);
            if (admin == null)
            {

                return NotFound();
            }
            return View(admin);
        }
    } 
}
