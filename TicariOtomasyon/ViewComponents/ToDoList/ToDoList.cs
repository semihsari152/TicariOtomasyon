using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicariOtomasyon.ViewComponents.ToDoList
{
    public class ToDoList : ViewComponent
    {
        ToDoListManager tm = new ToDoListManager(new EfToDoListRepository());

        public IViewComponentResult Invoke()
        {
            var values = tm.GetList();
            return View(values);
        }
    }
}
