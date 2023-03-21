using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicariOtomasyon.ViewComponents.Message
{

    public class MessageList : ViewComponent
    {
        MessageManager mm = new MessageManager(new EfMessageRepository());
        Context c = new Context();

        public IViewComponentResult Invoke()
        {
            var username = User.Identity.Name;
            var mail = c.Admins.Where(x => x.AdminUsername == username).Select(y => y.AdminMail).FirstOrDefault();
            var values = c.Messages.Where(y=>y.MessageReceiver==mail).OrderBy(x=>x.MessageDate).Skip(Math.Max(0, c.Admins.Count() - 6)).ToList();
            return View(values);
        }
    }
}
