using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicariOtomasyon.Controllers
{
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageRepository());
        Context c = new Context();

        public IActionResult Index()
        {
            return View();
            
        }

        public IActionResult AllMessages()
        {
            var username = User.Identity.Name;
            var mail = c.Admins.Where(x => x.AdminUsername == username).Select(y => y.AdminMail).FirstOrDefault();
            var values = c.Messages.Where(y => y.MessageReceiver == mail).OrderBy(x => x.MessageDate).ToList();
            return View(values);
        }

    }
}
