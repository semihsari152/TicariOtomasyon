using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TicariOtomasyon.Models;

namespace TicariOtomasyon.Controllers
{
    public class StaffController : Controller
    {
        StaffManager sm = new StaffManager(new EfStaffRepository());
        DepartmentManager dm = new DepartmentManager(new EfDepartmentRepository());
        NotificationClass nc = new NotificationClass();

        public IActionResult Index()
        {
            var values = sm.GetProductListWithDepartment();
            //var values = c.Departments.Where(x => x.DepartmentStatus == true).ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult StaffAdd()
        {
            List<SelectListItem> productvalues = (from x in dm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.DepartmentName,
                                                      Value = x.DepartmentID.ToString()
                                                  }).ToList();
            ViewBag.pv = productvalues;
            return View();
        }

        [HttpPost]
        public IActionResult StaffAdd(Staff s,AddProfileImage p)
        {
            if (p.StaffImage != null && s.StaffMail != null && s.StaffName != null && s.StaffSurname != null)
            {
                var extension = Path.GetExtension(p.StaffImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/panel/template/assets/images/faces/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.StaffImage.CopyTo(stream);
                s.StaffImage = "/panel/template/assets/images/faces/"+newimagename;
            

            s.StaffStatus = true;
            sm.TAdd(s);

                nc.NotificationAdd(s.StaffName + " " + s.StaffSurname, "Personel");



                TempData["eklendi"] = "";

            }
            else
            {
                TempData["basarisiz"] = "";
            }
            return RedirectToAction("Index");

        }

        public IActionResult StaffDelete(int id)
        {
            var value = sm.GetById(id);

            nc.NotificationDelete(value.StaffName + " " + value.StaffSurname, "Personel");

            value.StaffStatus = false;

            sm.TDelete(value);

            TempData["silindi"] = "";
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult StaffUpdate(int id)
        {
            List<SelectListItem> productvalues = (from x in dm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.DepartmentName,
                                                      Value = x.DepartmentID.ToString()
                                                  }).ToList();
            ViewBag.pv = productvalues;

            var staffvalue = sm.GetById(id);
            return View(staffvalue);
        }

        [HttpPost]
        public IActionResult StaffUpdate(Staff s,AddProfileImage p)
        {
            if (s.StaffMail != null && s.StaffName != null && s.StaffSurname != null)
            {
                s.StaffStatus = true;
                sm.TUpdate(s);

                nc.NotificationUpdate(s.StaffName + " " + s.StaffSurname, "Personel");

                TempData["güncellendi"] = "";
            }
            else
            {
                TempData["basarisiz"] = "";
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult StaffImageUpdate(int id)
        {
            var value = sm.GetById(id);

            return View(value);
        }

        [HttpPost]
        public IActionResult StaffImageUpdate(Staff staff, AddProfileImage p)
        {
            if (p.StaffImage !=null)
            {
                var extension = Path.GetExtension(p.StaffImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/panel/template/assets/images/faces/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.StaffImage.CopyTo(stream);
                staff.StaffImage = "/panel/template/assets/images/faces/" + newimagename;

                sm.TUpdate(staff);
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
