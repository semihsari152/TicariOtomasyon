using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicariOtomasyon.Models;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer.Concrete;

namespace TicariOtomasyon.Controllers
{

    public class GraphicController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ProList()
        {
            List<CategoryClass> snf = new List<CategoryClass>();

            using (var c = new Context())
            {
                snf = c.Categories.Select(x => new CategoryClass
                {
                    name = x.CategoryName,
                    count = x.Products.Count()
                }).ToList();
            }

            return Json(new { jsonlist = snf });
        }

        public IActionResult ProList2()
        {
            List<CategoryClass> snf = new List<CategoryClass>();

            using (var c = new Context())
            {
                snf = c.Departments.Select(x => new CategoryClass
                {
                    name = x.DepartmentName,
                    count = x.Staffs.Count()
                }).ToList();
            }

            return Json(new { jsonlist = snf });
        }

        public IActionResult ProList3()
        {
            List<CategoryClass> snf = new List<CategoryClass>();

            using (var c = new Context())
            {
                snf = c.Products.Select(x => new CategoryClass
                {
                    name = x.ProductName,
                    count = x.SalesMovements.Count()
                }).ToList();
            }

            return Json(new { jsonlist = snf });
        }
        public IActionResult ProList4()
        {
            List<CategoryClass> snf = new List<CategoryClass>();

            using (var c = new Context())
            {
                snf = c.Currents.Select(x => new CategoryClass
                {
                    name = x.CurrentName +" "+ x.CurrentSurname,
                    count = x.SalesMovements.Count()
                }).ToList();
            }

            return Json(new { jsonlist = snf });
        }
    }
}
