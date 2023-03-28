using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicariOtomasyon.Models;

namespace TicariOtomasyon.Controllers
{
    public class DepartmentController : Controller
    {

        DepartmentManager dm = new DepartmentManager(new EfDepartmentRepository());
        Context c = new Context();
        NotificationClass nc = new NotificationClass();

        public IActionResult Index()
        {
            //var values = c.Departments.Where(x => x.DepartmentStatus == true).ToList();
            var values = dm.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult DepartmentAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DepartmentAdd(Department department)
        {
            if (department.DepartmentName != null )
            {
                department.DepartmentStatus = true;
                dm.TAdd(department);

                nc.NotificationAdd(department.DepartmentName, "Departman");

                TempData["eklendi"] = "";
            }
            else
            {
                TempData["basarisiz"] = "";
            }
           
            return RedirectToAction("Index");
        }

        public IActionResult DepartmentDelete(int id)
        {
            var value = dm.GetById(id);
            value.DepartmentStatus = false;

            nc.NotificationDelete(value.DepartmentName, "Departman");

            dm.TDelete(value);

            TempData["silindi"] = "";
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult DepartmentUpdate(int id)
        {

            var departmentvalue = dm.GetById(id);
            return View(departmentvalue);
        }

        [HttpPost]
        public IActionResult DepartmentUpdate(Department department)
        {
            if (department.DepartmentName != null)
            {
                dm.TUpdate(department);

                nc.NotificationUpdate(department.DepartmentName, "Departman");

                TempData["güncellendi"] = "";
            }
            else
            {
                TempData["basarisiz"] = "";
            }
            return RedirectToAction("Index");
        }

        public IActionResult DepartmentDetails(int id)
        {
            var values = c.Staffs.Where(x => x.DepartmentID == id).ToList();
            var dpt = c.Departments.Where(x => x.DepartmentID == id).Select(y => y.DepartmentName).FirstOrDefault();
            ViewBag.d = dpt;
            return View(values);
        }

        public IActionResult DepartmentStaffMovements(int id)
        {
            var values = c.SalesMovements.Include(x => x.Product).Include(x=>x.Current).Where(x => x.StaffID == id).ToList();
            return View(values);
        }

    }
}
