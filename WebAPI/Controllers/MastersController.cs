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
    public class MastersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public MastersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = _context.Masters.ToList();

            return Ok(new { message = "Sukses mengambil data master!", StatusCode = 200, data = data });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = _context.Masters.Find(id);

            return Ok(new { message = "Sukses mengambil data master!", StatusCode = 200, data = data });
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Masters master)
        {
            var data = _context.Masters.Find(id);
            data.TransactionDate = master.TransactionDate;
            _context.Masters.Update(data);
            var result = _context.SaveChanges();
            if (result > 0)
            {
                return Ok(new { message = "Sukses mengubah data master!", StatusCode = 200 });
            }

            return BadRequest(new { message = "Gagal mengubah data master!", StatusCode = 400 });
        }

        [HttpPost]
        public IActionResult Post(Masters master)
        {
            _context.Masters.Add(master);
            var result = _context.SaveChanges();
            if (result > 0)
            {
                return Ok(new { message = "Sukses menambahkan data master!", StatusCode = 200 });
            }

            return BadRequest(new { message = "Gagal menambahkan data master!", StatusCode = 400 });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = _context.Masters.Find(id);
            _context.Masters.Remove(data);
            var result = _context.SaveChanges();
            if (result > 0)
            {
                return Ok(new { message = "Sukses menghapus data master!", StatusCode = 200 });
            }

            return BadRequest(new { message = "Gagal menghapus data master!", StatusCode = 400 });
        }
    }
}
