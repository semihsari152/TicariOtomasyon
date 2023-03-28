using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TicariOtomasyon.Models;

namespace TicariOtomasyon.Controllers
{
    public class CurrentController : Controller
    {
        CurrentManager cm = new CurrentManager(new EfCurrentRepository());
        Context c = new Context();
        NotificationClass nc = new NotificationClass();

        public IActionResult Index()
        {
            var values = c.Currents.Where(x => x.CurrentStatus == true).ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CurrentAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CurrentAdd(Current current,CurrentModel p)
        {

            if (p.CurrentImage != null && p.CurrentCity != null && p.CurrentMail != null && p.CurrentName != null && p.CurrentSurname != null)
            {
                var extension = Path.GetExtension(p.CurrentImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/panel/template/assets/images/current-images/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.CurrentImage.CopyTo(stream);
                current.CurrentImage = "/panel/template/assets/images/current-images/" + newimagename;



                current.CurrentStatus = true;
                current.CurrentPassword = current.CurrentName.ToLower() + "123";
                cm.TAdd(current);

                nc.NotificationAdd(current.CurrentName + " " + current.CurrentSurname, "Cari");

                TempData["eklendi"] = "";
            }
            else
            {
                TempData["basarisiz"] = "";
            }
            return RedirectToAction("Index");
        }

        public IActionResult CurrentDelete(int id)
        {
            var value = cm.GetById(id);
            value.CurrentStatus = false;

            nc.NotificationDelete(value.CurrentName + " " + value.CurrentSurname, "Cari");

            cm.TDelete(value);

            TempData["silindi"] = "";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CurrentUpdate(int id)
        {

            var departmentvalue = cm.GetById(id);

            ViewBag.sehir = departmentvalue.CurrentCity;
            return View(departmentvalue);
        }

        [HttpPost]
        public IActionResult CurrentUpdate(Current current)
        {
            if (current.CurrentCity != null && current.CurrentMail != null && current.CurrentName != null && current.CurrentSurname != null)
            {    
                current.CurrentStatus = true;
                cm.TUpdate(current);

                nc.NotificationUpdate(current.CurrentName + " " + current.CurrentSurname, "Cari");

                TempData["güncellendi"] = "";
            }
            else
            {
                TempData["basarisiz"] = "";
            }
            return RedirectToAction("Index");
        }

        public IActionResult CurrentSaleMovements(int id)
        {
            var values = c.SalesMovements.Include(x => x.Product).Include(x => x.Staff).Include(x => x.Current).Where(x => x.CurrentID == id).ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult CurrentImageUpdate(int id)
        {
            var value = cm.GetById(id);

            return View(value);
        }

        [HttpPost]
            public IActionResult CurrentImageUpdate(Current current, CurrentModel p)
        {
            if (p.CurrentImage !=null)
            {
                var extension = Path.GetExtension(p.CurrentImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/panel/template/assets/images/current-images/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.CurrentImage.CopyTo(stream);
                current.CurrentImage = "/panel/template/assets/images/current-images/" + newimagename;

                cm.TUpdate(current);

                nc.NotificationUpdate(current.CurrentName + " " + current.CurrentSurname, "Cari");

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
