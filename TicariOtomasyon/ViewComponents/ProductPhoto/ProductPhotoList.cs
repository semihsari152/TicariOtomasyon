using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicariOtomasyon.ViewComponents.ProductPhoto
{
    public class ProductPhotoList: ViewComponent
    {
        ProductManager pm = new ProductManager(new EfProductRepository());
        public IViewComponentResult Invoke()
        {
            var values = pm.GetList();
            return View(values);
        }
    }
}
