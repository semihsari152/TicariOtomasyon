using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicariOtomasyon.Controllers
{
    public class AdminController : Controller
    {
        AdminManager adm = new AdminManager(new EfAdminRepository());
        Context c = new Context();

        public IActionResult Index()
        {
            var username = User.Identity.Name;
            var id = c.Admins.Where(x => x.AdminUsername == username).Select(y => y.AdminID).FirstOrDefault();
            var finduser = adm.GetById(id);
            return View(finduser);
        }

        public IActionResult AdminUpdate(Admin admin)
        {
            var username = User.Identity.Name;

            var updateadmin = c.Admins.Where(x => x.AdminUsername == username).FirstOrDefault();
            updateadmin.AdminUsername = admin.AdminUsername;
            updateadmin.AdminPassword = admin.AdminPassword;
            updateadmin.AdminPermission = admin.AdminPermission;
            updateadmin.AdminName = admin.AdminName;
            updateadmin.AdminSurname = admin.AdminSurname;

            adm.TUpdate(updateadmin);

            return RedirectToAction("Index","Dashboard");
        }
    }
}
