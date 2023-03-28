using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TicariOtomasyon.Models;

namespace TicariOtomasyon.Controllers
{
    public class ProductController : Controller
    {
        ReceiptDetailManager rdm = new ReceiptDetailManager(new EfReceiptDetailRepository());
        ReceiptManager rm = new ReceiptManager(new EfReceiptRepository());
        ProductManager pm = new ProductManager(new EfProductRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        StaffManager sm = new StaffManager(new EfStaffRepository());
        Context c = new Context();
        SalesMovementManager svm = new SalesMovementManager(new EfSalesMovementRepository());
        CurrentManager currentManager = new CurrentManager(new EfCurrentRepository());
        NotificationClass nc = new NotificationClass();

        public IActionResult Index()
        {
            var values = pm.GetProductListWithCategory();
            return View(values);
        }

        [HttpGet]
        public IActionResult ProductAdd()
        {

            List<SelectListItem> productvalues = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.pv = productvalues;
            return View();
        }

        [HttpPost]
        public IActionResult ProductAdd(Product product, ProductModel p)
        {

            if (p.ProductImage != null && product.ProductMark != null && product.ProductName != null && product.ProductStock > 0 && product.PurchasePrice > 0 && product.SalePrice > 0)
            {
                var extension = Path.GetExtension(p.ProductImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/panel/template/assets/images/product-images/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.ProductImage.CopyTo(stream);
                product.ProductImage = "/panel/template/assets/images/product-images/" + newimagename;

                product.ProductStatus = true;
                pm.TAdd(product);

                nc.NotificationAdd(product.ProductName, "Ürün");

                TempData["eklendi"] = "";
            }
            else
            {
                TempData["basarisiz"] = "";
            }
            return RedirectToAction("Index");
        }

        public IActionResult ProductDelete(int id)
        {
            var value = pm.GetById(id);

            nc.NotificationDelete(value.ProductName, "Ürün");

            pm.TDelete(value);
            TempData["silindi"] = "";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ProductUpdate(int id)
        {
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.pv = categoryvalues;

            var productvalues = pm.GetById(id);
            return View(productvalues);
        }

        [HttpPost]
        public IActionResult ProductUpdate(Product product)
        {
            if (product.ProductMark != null && product.ProductName != null && product.ProductStock > 0 && product.PurchasePrice > 0 && product.SalePrice > 0)
            {

                product.ProductStatus = true;
                pm.TUpdate(product);

                nc.NotificationUpdate(product.ProductName, "Ürün");

                TempData["güncellendi"] = "";
            }
            else
            {
                TempData["basarisiz"] = "";
            }
            return RedirectToAction("Index");
        }

        public IActionResult ProductList()
        {
            var values = pm.GetProductListWithCategory();
            return View(values);
        }

        [HttpGet]
        public IActionResult ProductSell(int id)
        {

            List<SelectListItem> staffvalues = (from x in sm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.StaffName + " " + x.StaffSurname,
                                                    Value = x.StaffID.ToString()
                                                }).ToList();
            ViewBag.sv = staffvalues;

            List<SelectListItem> currentvalues = (from x in currentManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CurrentName + " " + x.CurrentSurname,
                                                      Value = x.CurrentID.ToString()
                                                  }).ToList();

            ViewBag.cv = currentvalues;

            var deger1 = c.Products.Find(id);
            ViewBag.dgr1 = deger1.ProductID;
            ViewBag.dgr2 = deger1.SalePrice;

            return View();
        }

        [HttpPost]
        public IActionResult ProductSell(SalesMovement salesMovement, Receipt receipt, ReceiptDetail receiptDetail)
        {


            salesMovement.SalesMovementsDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            svm.TAdd(salesMovement);


            int id = salesMovement.SalesMovementsID;
            var values = c.SalesMovements.Where(x => x.SalesMovementsID == id).Include(x => x.Staff).Include(x => x.Current).Include(x => x.Product).Select(s => new
            {
                staffName = s.Staff.StaffName,
                staffSurname = s.Staff.StaffSurname,
                currentName = s.Current.CurrentName,
                currentSurname = s.Current.CurrentSurname,
                productName = s.Product.ProductName
            }).FirstOrDefault();



            receipt.ReceiptSerialNumber = "P";
            receipt.ReceiptLineNumber = "10" + salesMovement.SalesMovementsID.ToString();
            receipt.ReceiptTaxAuthority = "Bursa";
            receipt.ReceiptSupplier = values.staffName + " " + values.staffSurname;
            receipt.ReceiptReceiver = values.currentName + " " + values.currentSurname;
            receipt.ReceiptTotal = salesMovement.SalesMovementsTotal;
            receipt.ReceiptDate = salesMovement.SalesMovementsDate;
            receipt.ReceiptTime = DateTime.Now.ToString("HH:mm");
            rm.TAdd(receipt);

            receiptDetail.ReceiptDetailsUnitPrice = salesMovement.SalesMovementsPrice;
            receiptDetail.ReceiptDetailsTotal = salesMovement.SalesMovementsTotal;
            receiptDetail.ReceiptDetailsDescription = values.productName;
            receiptDetail.ReceiptDetailsAmount = salesMovement.SalesMovementsUnit;
            receiptDetail.ReceiptID = receipt.ReceiptID;
            rdm.TAdd(receiptDetail);

            nc.NotificationSell(values.productName, "Ürün");

            return RedirectToAction("Index", "SalesMovement");
        }

        public IActionResult ProductChangeStatus(int id)
        {

            var value = pm.GetById(id);


            if (value.ProductStatus == true)
            {
                value.ProductStatus = false;
                nc.NotificationDelete(value.ProductName, "Ürün");
            }
            else
            {
                value.ProductStatus = true;
            }

            pm.TUpdate(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult ProductImageUpdate(int id)
        {
            var value = pm.GetById(id);

            return View(value);
        }

        [HttpPost]
        public IActionResult ProductImageUpdate(Product product, ProductModel p)
        {
            if (p.ProductImage != null)
            {
                var extension = Path.GetExtension(p.ProductImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/panel/template/assets/images/product-images/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.ProductImage.CopyTo(stream);
                product.ProductImage = "/panel/template/assets/images/product-images/" + newimagename;

                pm.TUpdate(product);

                nc.NotificationUpdate(product.ProductName, "Ürün");

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
