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
    public class ReceiptController : Controller
    {
        ReceiptManager rm = new ReceiptManager(new EfReceiptRepository());
        Context c = new Context();
        public IActionResult Index()
        {
            var values = rm.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult ReceiptAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ReceiptAdd(Receipt receipt)
        {
            if (receipt.ReceiptLineNumber != null && receipt.ReceiptReceiver != null && receipt.ReceiptSerialNumber != null && receipt.ReceiptSupplier != null && receipt.ReceiptTaxAuthority != null && receipt.ReceiptTime != null && receipt.ReceiptTotal >0 )
            {
                rm.TAdd(receipt);

                TempData["eklendi"] = "";
            }
            else
            {
                TempData["basarisiz"] = "";
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ReceiptUpdate(int id)
        {

            var receiptvalue = rm.GetById(id);
            return View(receiptvalue);
        }

        [HttpPost]
        public IActionResult ReceiptUpdate(Receipt receipt)
        {
            if (receipt.ReceiptLineNumber != null && receipt.ReceiptReceiver != null && receipt.ReceiptSerialNumber != null && receipt.ReceiptSupplier != null && receipt.ReceiptTaxAuthority != null && receipt.ReceiptTime != null && receipt.ReceiptTotal > 0)
            {
                rm.TUpdate(receipt);

                TempData["güncellendi"] = "";
            }
            else
            {
                TempData["basarisiz"] = "";
            }
            return RedirectToAction("Index");
        }

        public IActionResult ReceiptDetails(int id)
        {
            var values = c.ReceiptDetails.Include(x => x.Receipt).Where(x => x.ReceiptID == id).ToList();
            return View(values);
        }

        public IActionResult TransformReceipt(int id)
        {
            DynamicReceiptModal drm = new DynamicReceiptModal();

            drm.value1 = c.Receipts.Where(x => x.ReceiptID == id).ToList();

            drm.value2 = c.ReceiptDetails.Where(x => x.ReceiptID == id).ToList();

            return View(drm);
        }

        //public IActionResult Dynamic()
        //{

        //    DynamicReceiptModal drm = new DynamicReceiptModal();

        //    drm.value1 = c.Receipts.ToList();
        //    drm.value2 = c.ReceiptDetails.ToList();

        //    return View(drm);
        //}


        //public IActionResult ReceiptSave(string RecepitSerialNumber, string ReceiptLineNumber, DateTime ReceiptDate,
        //    string ReceiptTaxAuthority, string ReceiptTime, string ReceiptSupplier, string ReceiptReceiver, string ReceiptTotal,
        //    ReceiptDetail[] ReceiptDetails)
        //{

        //    if (RecepitSerialNumber != null && ReceiptLineNumber != null && RecepitSerialNumber != null && ReceiptTaxAuthority != null && ReceiptTime != null && ReceiptSupplier != null && ReceiptReceiver != null && ReceiptTotal != null && ReceiptDetails != null)
        //    {
        //        Receipt r = new Receipt();
        //        r.ReceiptSerialNumber = RecepitSerialNumber;
        //        r.ReceiptLineNumber = ReceiptLineNumber;
        //        r.ReceiptDate = ReceiptDate;
        //        r.ReceiptTaxAuthority = ReceiptTaxAuthority;
        //        r.ReceiptTime = ReceiptTime;
        //        r.ReceiptSupplier = ReceiptSupplier;
        //        r.ReceiptReceiver = ReceiptReceiver;
        //        r.ReceiptTotal = decimal.Parse(ReceiptTotal);
        //        rm.TAdd(r);

        //        foreach (var item in ReceiptDetails)
        //        {
        //            ReceiptDetail rd = new ReceiptDetail();
        //            rd.ReceiptDetailsDescription = item.ReceiptDetailsDescription;
        //            rd.ReceiptDetailsAmount = item.ReceiptDetailsAmount;
        //            rd.ReceiptDetailsUnitPrice = item.ReceiptDetailsUnitPrice;
        //            rd.ReceiptDetailsTotal = item.ReceiptDetailsTotal;
        //            rd.ReceiptID = item.ReceiptID;
        //            c.ReceiptDetails.Add(rd);
        //        }
        //    }



        //    return Json("İşlem Başarılı", new Newtonsoft.Json.JsonSerializerSettings());
        //}





        //public IActionResult ReceiptSave(DynamicRequestModel dynamic)
        //{

        //    Receipt r = new Receipt();
        //    r.ReceiptSerialNumber = dynamic.ReceiptSerialNumber;
        //    r.ReceiptLineNumber = dynamic.ReceiptLineNumber;
        //    r.ReceiptDate = dynamic.ReceiptDate;
        //    r.ReceiptTaxAuthority = dynamic.ReceiptTaxAuthority;
        //    r.ReceiptTime = dynamic.ReceiptTime;
        //    r.ReceiptSupplier = dynamic.ReceiptSupplier;
        //    r.ReceiptReceiver = dynamic.ReceiptReceiver;
        //    r.ReceiptTotal = (decimal)dynamic.ReceiptTotal;
        //    rm.TAdd(r);

        //    return Json("İşlem Başarılı", new Newtonsoft.Json.JsonSerializerSettings());
        //}
    }
}
