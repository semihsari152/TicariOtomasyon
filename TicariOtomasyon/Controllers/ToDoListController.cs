using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicariOtomasyon.Controllers
{
    public class ToDoListController : Controller
    {
        ToDoListManager tm = new ToDoListManager(new EfToDoListRepository());

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListAdd(string subject)
        {
            ToDoList list = new ToDoList();

            list.ToDoListName = subject;
            list.ToDoListStatus = true;
            tm.TAdd(list);
        
            return RedirectToAction("Index","Dashboard");
        }

        public IActionResult ListDelete(int id)
        {
            var value = tm.GetById(id);
            tm.TDelete(value);

            return RedirectToAction("Index", "Dashboard");
        }
    }
}
