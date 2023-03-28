using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicariOtomasyon.Models;

namespace TicariOtomasyon.Controllers
{
    public class SalesMovementController : Controller
    {
        SalesMovementManager svm = new SalesMovementManager(new EfSalesMovementRepository());
        ProductManager pm = new ProductManager(new EfProductRepository());
        CurrentManager cm = new CurrentManager(new EfCurrentRepository());
        StaffManager sm = new StaffManager(new EfStaffRepository());
        NotificationClass nc = new NotificationClass();

        Context c = new Context();
        public IActionResult Index()
        {
            var values = c.SalesMovements.Include(x => x.Product).Include(x => x.Current).Include(x => x.Staff).ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult SalesMovementAdd()
        {
            List<SelectListItem> productvalues = (from x in pm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.ProductName,
                                                      Value = x.ProductID.ToString()
                                                  }).ToList();

            List<SelectListItem> currentvalues = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CurrentName + " " + x.CurrentSurname,
                                                      Value = x.CurrentID.ToString()
                                                  }).ToList();

            List<SelectListItem> staffvalues = (from x in sm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.StaffName + " " + x.StaffSurname,
                                                    Value = x.StaffID.ToString()
                                                }).ToList();




            ViewBag.productv = productvalues;
            ViewBag.currentv = currentvalues;
            ViewBag.staffv = staffvalues;


            return View();
        }

        [HttpPost]
        public IActionResult SalesMovementAdd(SalesMovement salesMovement)
        {
            if (salesMovement.SalesMovementsPrice > 0 && salesMovement.SalesMovementsTotal > 0 && salesMovement.SalesMovementsUnit > 0)
            {
                salesMovement.SalesMovementsDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                svm.TAdd(salesMovement);

                nc.NotificationAdd(salesMovement.SalesMovementsID.ToString(), "Satış");

                TempData["eklendi"] = "";
            }
            else
            {
                TempData["basarisiz"] = "";
            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult SalesMovementUpdate(int id)
        {

            List<SelectListItem> productvalues = (from x in pm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.ProductName,
                                                      Value = x.ProductID.ToString()
                                                  }).ToList();

            List<SelectListItem> currentvalues = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CurrentName + "" + x.CurrentSurname,
                                                      Value = x.CurrentID.ToString()
                                                  }).ToList();

            List<SelectListItem> staffvalues = (from x in sm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.StaffName + "" + x.StaffSurname,
                                                    Value = x.StaffID.ToString()
                                                }).ToList();

            ViewBag.productv = productvalues;
            ViewBag.currentv = currentvalues;
            ViewBag.staffv = staffvalues;

            var salesMovementvalues = svm.GetById(id);
            return View(salesMovementvalues);
        }

        [HttpPost]
        public IActionResult SalesMovementUpdate(SalesMovement salesMovement)
        {
            if (salesMovement.SalesMovementsPrice > 0 && salesMovement.SalesMovementsTotal > 0 && salesMovement.SalesMovementsUnit > 0)
            {
                svm.TUpdate(salesMovement);

                nc.NotificationUpdate(salesMovement.SalesMovementsID.ToString(), "Satış");

                TempData["güncellendi"] = "";
            }
            else
            {
                TempData["basarisiz"] = "";
            }
            return RedirectToAction("Index");
        }

        //public IActionResult SalesMovementDetails(int id)
        //{
        //    var values = c.SalesMovements.Include(x => x.Product).Include(x => x.Current).Include(x => x.Staff).Where(x => x.SalesMovementsID == id).ToList();
        //    return View(values);
        //}

        public IActionResult GetReceipt(int id)
        {

            var values = c.Receipts.Where(x => x.ReceiptLineNumber.Substring(2, 6) == id.ToString()).ToList();

            return View(values);
        }

    }
}
