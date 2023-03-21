using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TicariOtomasyon.Models;

namespace TicariOtomasyon.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Current p)
        {

            var datavalue = c.Currents.FirstOrDefault(x => x.CurrentMail == p.CurrentMail && x.CurrentPassword == p.CurrentPassword);
            if (datavalue != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,p.CurrentMail)
                };

                var useridentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authproperties = new AuthenticationProperties();

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(useridentity), authproperties);

                return RedirectToAction("Index", "CurrentPanel");

            }
            else
            {
                return View();
            }

        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }


        [HttpGet]
        public IActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AdminLogin(Admin p)
        {
            var datavalue = c.Admins.FirstOrDefault(x => x.AdminUsername == p.AdminUsername && x.AdminPassword == p.AdminPassword);
            if (datavalue != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,p.AdminUsername)
                };

                var useridentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authproperties = new AuthenticationProperties();

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(useridentity), authproperties);

                return RedirectToAction("Index", "Dashboard");

            }
            else
            {
                return View();
            }

        }
    }
}