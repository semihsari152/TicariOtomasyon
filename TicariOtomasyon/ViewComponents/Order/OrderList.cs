using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicariOtomasyon.ViewComponents.Order
{
    public class OrderList : ViewComponent
    {
        SalesMovementManager sm = new SalesMovementManager(new EfSalesMovementRepository());
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            var values = c.SalesMovements.Include(x => x.Product).Include(x => x.Current).Include(x => x.Staff).OrderBy(x => x.SalesMovementsDate).Skip(Math.Max(0, c.SalesMovements.Count() - 5)).ToList();
            return View(values);
        }
    }
}
