using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Context;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = _context.Products.ToList();

            return Ok(new { message = "Sukses mengambil data produk!", StatusCode = 200, data = data });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = _context.Products.Find(id);

            return Ok(new { message = "Sukses mengambil data produk!", StatusCode = 200, data = data });
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Products product)
        {
            var data = _context.Products.Find(id);
            data.Name = product.Name;
            data.Price = product.Price;
            data.Stock = product.Stock;
            _context.Products.Update(data);
            var result = _context.SaveChanges();
            if(result > 0)
            {
                return Ok(new { message = "Sukses mengubah data produk!", StatusCode = 200});
            }

            return BadRequest(new { message = "Gagal mengubah data produk!", StatusCode = 400});
        }

        [HttpPost]
        public IActionResult Post(Products product)
        {
            _context.Products.Add(product);
            var result = _context.SaveChanges();
            if (result > 0)
            {
                return Ok(new { message = "Sukses menambahkan data produk!", StatusCode = 200 });
            }

            return BadRequest(new { message = "Gagal menambahkan data produk!", StatusCode = 400 });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = _context.Products.Find(id);
            _context.Products.Remove(data);
            var result = _context.SaveChanges();
            if (result > 0)
            {
                return Ok(new { message = "Sukses menghapus data produk!", StatusCode = 200 });
            }

            return BadRequest(new { message = "Gagal menghapus data produk!", StatusCode = 400 });
        }
    }
}
