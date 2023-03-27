using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TicariOtomasyon.Models;

namespace TicariOtomasyon.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        Context c = new Context();
        public IActionResult Index()
        {
            var values = c.Categories.Where(x => x.CategoryStatus == true).ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CategoryAdd(Category c, CategoryModel p)
        {

            if (p.CategoryImage != null && p.CategoryImage != null)
            {
                var extension = Path.GetExtension(p.CategoryImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/panel/template/assets/images/category-images/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.CategoryImage.CopyTo(stream);
                c.CategoryImage = "/panel/template/assets/images/category-images/" + newimagename;


                c.CategoryStatus = true;

                cm.TAdd(c);

                TempData["eklendi"] = "";

            }
            else
            {
                TempData["basarisiz"] = "";
            }

            return RedirectToAction("Index");
        }

        public IActionResult CategoryDelete(int id)
        {
            var value = cm.GetById(id);
            value.CategoryStatus = false;

            cm.TDelete(value);

            TempData["silindi"] = "";
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult CategoryUpdate(int id)
        {

            var categoryvalue = cm.GetById(id);
            return View(categoryvalue);
        }

        [HttpPost]
        public IActionResult CategoryUpdate(Category c)
        {
            if (c.CategoryImage != null)
            {
                c.CategoryStatus = true;

                cm.TUpdate(c);
                TempData["güncellendi"] = "";
            }
            else
            {
                TempData["basarisiz"] = "";
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult CategoryImageUpdate(int id)
        {
            var value = cm.GetById(id);

            return View(value);
        }

        [HttpPost]
        public IActionResult CategoryImageUpdate(Category category, CategoryModel p)
        {
            if (p.CategoryImage != null)
            {
                var extension = Path.GetExtension(p.CategoryImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/panel/template/assets/images/category-images/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.CategoryImage.CopyTo(stream);
                category.CategoryImage = "/panel/template/assets/images/category-images/" + newimagename;

                cm.TUpdate(category);
                TempData["güncellendi"] = "";
            }
            else
            {
                TempData["basarisiz"] = "";
            }

            return RedirectToAction("Index");
        }

    }
}
