using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicariOtomasyon.Controllers
{
    public class ErrorPageController : Controller
    {
        [Route("ErrorPage/{code:int}")]
        public IActionResult ErrorPage(int code)
        {
            return View();
        }

        [Route("ErrorPage/404")]
        public IActionResult Error404()
        {
            return View();
        }

        [Route("ErrorPage/401")]
        public IActionResult Error401()
        {
            return View();
        }

        [Route("ErrorPage/500")]
        public IActionResult Error500()
        {
            return View();
        }
    }
}
