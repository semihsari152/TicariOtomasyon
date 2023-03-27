using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicariOtomasyon.Controllers
{
    public class NotificationController : Controller
    {

        NotificationManager nm = new NotificationManager(new EfNotificationRepository());

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllNotifications()
        {
            var values = nm.GetList();
            return View(values);
        }
    }
}
