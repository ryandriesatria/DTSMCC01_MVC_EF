using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcCore.Context;
using MvcCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCore.Controllers
{
    public class DetailsController : Controller
    {

        private readonly ApplicationDbContext _context;
        public DetailsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var details = _context.Details.Include(detail => detail.Products).
                Include(detail => detail.Masters).ToList(); ;
            return View(details) ;
        }

        //GET
        public IActionResult Create()
        {
            var productId = _context.Products.Select(p => p.Id).ToList();
            ViewBag.productId = productId;
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Details detail)
        {
            
            if (ModelState.IsValid)
            {
                _context.Details.Add(detail);
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
            var detail = _context.Details.Find(id);
            return View(detail);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Details detail)
        {
            if (ModelState.IsValid)
            {
                _context.Details.Update(detail);
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
            var detail = _context.Details.Find(id);
            return View(detail);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Details detail)
        {
            if (ModelState.IsValid)
            {
                _context.Details.Remove(detail);
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
            var detail = _context.Details.Find(id);
            return View(detail);
        }
    }
}
