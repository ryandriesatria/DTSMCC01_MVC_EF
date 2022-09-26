using Microsoft.AspNetCore.Mvc;
using MvcCore.Context;
using MvcCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCore.Controllers
{
    public class MastersController : Controller
    {
        private readonly ApplicationDbContext _context;
        public MastersController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var masters = _context.Masters.ToList();
            return View(masters);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Masters master)
        {
            if (ModelState.IsValid)
            {
                _context.Masters.Add(master);
                var result = _context.SaveChanges();
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }
            }

            return View();
        }

        //GET
        public IActionResult Edit(int id)
        {
            var master = _context.Masters.Find(id);
            return View(master);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Masters master)
        {
            if (ModelState.IsValid)
            {
                _context.Masters.Update(master);
                var result = _context.SaveChanges();
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        //GET
        public IActionResult Delete(int id)
        {
            var master = _context.Masters.Find(id);
            return View(master);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Masters master)
        {
            if (ModelState.IsValid)
            {
                _context.Masters.Remove(master);
                var result = _context.SaveChanges();
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        //GET
        public IActionResult Details(int id)
        {
            var master = _context.Masters.Find(id);
            return View(master);
        }
    }
}
