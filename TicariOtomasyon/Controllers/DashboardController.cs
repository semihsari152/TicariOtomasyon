using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicariOtomasyon.Controllers
{
   
    public class DashboardController : Controller
    {
        Context c = new Context();

        public IActionResult Index()
        {

            //mevcut tüm ürünler için 
            var harcama = c.Products.Sum(x => x.PurchasePrice);
            ViewBag.harcama = harcama;

            var kazanc = c.Products.Sum(x => x.SalePrice);
            ViewBag.kazanc = kazanc;
         
            var kar = (int)((kazanc - harcama) * 100 / harcama);
            ViewBag.kar = kar;


            //satılan ürünler için

            var alınan = c.SalesMovements.Sum(x => x.Product.PurchasePrice);
            ViewBag.alınan = alınan;

            var satılan = c.SalesMovements.Sum(x => x.Product.SalePrice);
            ViewBag.satılan = satılan;

            var mevcutkar = (int)((satılan - alınan) * 100 / alınan);
            ViewBag.mevcutkar = mevcutkar;


            var beklenen = (mevcutkar - kar)*(-1);
            ViewBag.beklenen = beklenen;


            //üst tablo için
            DateTime today = DateTime.Today;
            var satis = c.SalesMovements.Count(x => x.SalesMovementsDate == today).ToString();
            ViewBag.satis = satis;

            //bugün satılan ürünlerden gelen para
            var toplamtutar = c.SalesMovements.Where(x=>x.SalesMovementsDate==today).Sum(x => x.Product.SalePrice);
            ViewBag.toplamtutar = toplamtutar;

            var satilanurun = c.SalesMovements.Where(x => x.SalesMovementsDate == today).Select(x => x.SalesMovementsUnit).FirstOrDefault();
            ViewBag.satilanurun = satilanurun;

            return View();
        }
    }
}
