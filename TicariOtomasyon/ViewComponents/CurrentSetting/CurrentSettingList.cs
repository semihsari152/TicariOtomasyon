using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicariOtomasyon.ViewComponents.CurrentSetting
{
    public class CurrentSettingList : ViewComponent
    {
        CurrentManager cm = new CurrentManager(new EfCurrentRepository());
        Context c = new Context();

        public IViewComponentResult Invoke()
        {
            var usermail = User.Identity.Name;
            var id = c.Currents.Where(x => x.CurrentMail == usermail).Select(y => y.CurrentID).FirstOrDefault();
            var cariBul = cm.GetById(id);
            ViewBag.sehir = cariBul.CurrentCity;
            return View(cariBul);
        }
    }
}
