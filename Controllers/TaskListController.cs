using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskListMVC.Models;


namespace TaskListMVC.Controllers
{
    public class TaskListController : Controller
    {

        private readonly TaskListContext _context;
        public TaskListController(TaskListContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<ToDoItems> ToDoList = _context.ToDoItems.ToList();
            return View(ToDoList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ToDoItems item)
        {
            if (ModelState.IsValid)
            {
                _context.ToDoItems.Add(item);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(item);

        }
        public IActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            ToDoItems item = _context.ToDoItems.Find(Id);
            if(item == null)
            {
                return NotFound();
            }
            return View(item);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? Id)
        {
            ToDoItems item = _context.ToDoItems.Find(Id);
            if(item == null)
            {
                return NotFound();
            }

                _context.ToDoItems.Remove(item);
                _context.SaveChanges();
                return RedirectToAction("Index");
            

        }
        public IActionResult Update(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            ToDoItems item = _context.ToDoItems.Find(Id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ToDoItems item)
        {
            if (ModelState.IsValid)
            {
                _context.ToDoItems.Update(item);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(item);

        }
        public IActionResult Complete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            ToDoItems item = _context.ToDoItems.Find(Id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Complete(ToDoItems item)
        {
            if (ModelState.IsValid)
            {
                _context.ToDoItems.Update(item);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(item);

        }


    }

}
