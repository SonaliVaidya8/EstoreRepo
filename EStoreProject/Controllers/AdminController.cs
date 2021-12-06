using EStoreProject.DataAccess.Interfaces;
using EStoreProject.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStoreProject.Controllers
{
    public class AdminController : Controller
    { 
    private readonly IAdminContextDb _contextDb;
    public AdminController(IAdminContextDb context)
    {
        _contextDb = context;
    }
    public IActionResult Index()
    {
            List<Admin> adminList = _contextDb.GetAllAdmin().ToList();
            return View(adminList);
        }
    public IActionResult CreateAdmin()
    {
        return View();

    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult CreateAdmin([Bind] Admin objAdmin)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _contextDb.AddAdmin(objAdmin);
                return RedirectToAction("Index");

            }
            return View(objAdmin);
        }
        catch
        {
            return View();
        }
    }


        /*
        public ActionResult DeleteAdmin(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            Admin admin = _contextDb.GetAdminByEmailId(id);
            if (admin == null)
            {
                return NotFound();
            }
            return View(admin);
        }

        // POST: ProductController/Delete/5
        [HttpPost, ActionName("DeleteAdmin")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _contextDb.DeleteAdmin(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }*/



        /*
        public IActionResult GetByAdEmail_id()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetByAdEmail_id([Bind] Admin objAdmin, string AdEmail_id, string AdPassword)
        {
            int result = _contextDb.GetByAdEmail_id(AdEmail_id, AdPassword);
            if (result == 1)
            {
                return RedirectToAction("Index");
                //TempData["Message"] = "Welcome to Login Page";
            }
            else
            {
                TempData["Message"] = "Invalid Email Id or Password!";
            }
            return View();
        }*/

    }
    }


