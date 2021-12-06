using EStoreProject.DataAccess.Interfaces;
using EStoreProject.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EStoreProject.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginContextDb _contextDb;

       // public string ReturnUrl { get; private set; }

        public LoginController(ILoginContextDb context)
        {
            _contextDb = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("denied")]
        public IActionResult Denied()
        {
            return View();

        }

        [AllowAnonymous]
        [HttpGet("login")]
        public IActionResult GetByAdEmail_id(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        
        [HttpPost("login")]
        public async Task<IActionResult> GetByAdEmail_id([Bind] Admin objAdmin, string AdEmail_id, string AdPassword, string returnUrl)
        {
            int result = _contextDb.GetByAdEmail_id(AdEmail_id, AdPassword);
            if (result == 1)
            {
                //return RedirectToAction("Index");
                var claims = new List<Claim>();
                claims.Add(new Claim("AdEmail_id", objAdmin.AdEmail_id));
                claims.Add(new Claim(ClaimTypes.Email, objAdmin.AdEmail_id));

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);
                return Redirect(returnUrl);
            }

            /* else
             {
                 TempData["Message"] = "Invalid Email Id or Password!";
             }*/
            TempData["Error"] = "Email-Id or Password is invalid";
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

    }
}

