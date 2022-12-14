using Microsoft.AspNetCore.Mvc;
using MvcCore.Context;
using MvcCore.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCore.Controllers
{


    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Products product)
        {
            if(ModelState.IsValid)
            {
                _context.Products.Add(product);
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
            var product = _context.Products.Single(p => p.Id == id);
            return View(product);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Products product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Update(product);
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
            var product = _context.Products.Single(p => p.Id == id);
            return View(product);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Products product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Remove(product);
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
            var product = _context.Products.Single(p => p.Id == id);
            return View(product);
        }

    }
}

