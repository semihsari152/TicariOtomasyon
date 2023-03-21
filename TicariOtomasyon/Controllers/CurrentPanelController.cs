using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    
    public class CurrentPanelController : Controller
    {
        Context c = new Context();
        CurrentManager cm = new CurrentManager(new EfCurrentRepository());
        MessageManager mm = new MessageManager(new EfMessageRepository());

        public IActionResult Index()
        {
            var usermail = User.Identity.Name;
            ViewBag.usermail = usermail;

            var value = c.Messages.Where(x => x.MessageReceiver == usermail).ToList();

            var mailId = c.Currents.Where(x => x.CurrentMail == usermail).Select(y => y.CurrentID).FirstOrDefault();
            var toplamSatis = c.SalesMovements.Where(x => x.CurrentID == mailId).Count();
            ViewBag.toplamSatis = toplamSatis;
            ViewBag.mailId = mailId;

            var toplamTutar = c.SalesMovements.Where(x => x.CurrentID == mailId).Sum(y => y.SalesMovementsTotal);
            ViewBag.toplamTutar = toplamTutar;

            var telefon = c.Currents.Where(x => x.CurrentID == mailId).Select(y => y.CurrentPhone).FirstOrDefault();

            ViewBag.telefon = "("+telefon.Substring(0, 3)+")"+" "+telefon.Substring(3,3)+" "+telefon.Substring(6,4);


            var toplamUrun = c.SalesMovements.Where(x => x.CurrentID == mailId).Sum(y => y.SalesMovementsUnit);
            ViewBag.toplamUrun = toplamUrun;

            var adSoyad = c.Currents.Where(x => x.CurrentID == mailId).Select(y => y.CurrentName + " " + y.CurrentSurname).FirstOrDefault();
            ViewBag.adSoyad = adSoyad;

            var image = c.Currents.Where(x => x.CurrentID == mailId).Select(y => y.CurrentImage).FirstOrDefault();
            ViewBag.image = image;

            var city = c.Currents.Where(x => x.CurrentID == mailId).Select(y => y.CurrentCity).FirstOrDefault();
            ViewBag.city = city;

            return View(value);

        } 

        public IActionResult Orders()
        {

            var usermail = User.Identity.Name;

            var id = c.Currents.Where(x => x.CurrentMail == usermail).Select(y => y.CurrentID).FirstOrDefault();

            var values = c.SalesMovements.Include(x=>x.Staff).Include(x => x.Product).Where(x => x.CurrentID == id).ToList();

            return View(values);
        }

        public IActionResult Inbox()
        {

            var usermail = User.Identity.Name;

            var messages = c.Messages.Where(x => x.MessageReceiver == usermail).OrderByDescending(x => x.MessageID).ToList();

            var inboxcount = c.Messages.Count(x => x.MessageReceiver == usermail).ToString();
            ViewBag.inboxcount = inboxcount;

            var outboxcount = c.Messages.Count(x => x.MessageSender == usermail).ToString();
            ViewBag.outboxcount = outboxcount;

            return View(messages);
        }

        public IActionResult Outbox()
        {

            var usermail = User.Identity.Name;

            var messages = c.Messages.Where(x => x.MessageSender == usermail).OrderByDescending(x => x.MessageID).ToList();

            var inboxcount = c.Messages.Count(x => x.MessageReceiver == usermail).ToString();
            ViewBag.inboxcount = inboxcount;

            var outboxcount = c.Messages.Count(x => x.MessageSender == usermail).ToString();
            ViewBag.outboxcount = outboxcount;

            return View(messages);
        }

        [HttpGet]
        public IActionResult NewMessage()
        {
            var usermail = User.Identity.Name;
   
            var inboxcount = c.Messages.Count(x => x.MessageReceiver == usermail).ToString();
            ViewBag.inboxcount = inboxcount;

            var outboxcount = c.Messages.Count(x => x.MessageSender == usermail).ToString();
            ViewBag.outboxcount = outboxcount;
            return View();
        }

        [HttpPost]
        public IActionResult NewMessage(Message message)
        {
            var usermail = User.Identity.Name;
            message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            message.MessageSender = usermail;

            mm.TAdd(message);

            return RedirectToAction("Outbox");
        }

        public IActionResult MessageDetails(int id)
        {
            var usermail = User.Identity.Name;

            var messages = c.Messages.Where(x => x.MessageID == id).ToList();

            
          

            var inboxcount = c.Messages.Count(x => x.MessageReceiver == usermail).ToString();
            ViewBag.inboxcount = inboxcount;

            var outboxcount = c.Messages.Count(x => x.MessageSender == usermail).ToString();
            ViewBag.outboxcount = outboxcount;


            return View(messages);
        }


        public IActionResult CariBilgiGüncelle(Current current)
        {
            var usermail = User.Identity.Name;

            var updatecurrent = c.Currents.Where(x=>x.CurrentMail == usermail).FirstOrDefault();
            updatecurrent.CurrentName = current.CurrentName;
            updatecurrent.CurrentSurname = current.CurrentSurname;
            updatecurrent.CurrentCity = current.CurrentCity;
            updatecurrent.CurrentPassword = current.CurrentPassword;

            cm.TUpdate(updatecurrent);

            return RedirectToAction("Index");
        }

    }
}
