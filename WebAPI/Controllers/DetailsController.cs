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
    public class DetailsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public DetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = _context.Details.ToList();

            return Ok(new { message = "Sukses mengambil data detail!", StatusCode = 200, data = data });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = _context.Details.Find(id);

            return Ok(new { message = "Sukses mengambil data detail!", StatusCode = 200, data = data });
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Details detail)
        {
            var data = _context.Details.Find(id);
            data.MasterId = detail.MasterId;
            data.ProductId = detail.ProductId;
            data.Quantity = detail.Quantity;
            _context.Details.Update(data);
            var result = _context.SaveChanges();
            if (result > 0)
            {
                return Ok(new { message = "Sukses mengubah data detail!", StatusCode = 200 });
            }

            return BadRequest(new { message = "Gagal mengubah data detail!", StatusCode = 400 });
        }

        [HttpPost]
        public IActionResult Post(Details detail)
        {
            _context.Details.Add(detail);
            var result = _context.SaveChanges();
            if (result > 0)
            {
                return Ok(new { message = "Sukses menambahkan data detail!", StatusCode = 200 });
            }

            return BadRequest(new { message = "Gagal menambahkan data detail!", StatusCode = 400 });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = _context.Details.Find(id);
            _context.Details.Remove(data);
            var result = _context.SaveChanges();
            if (result > 0)
            {
                return Ok(new { message = "Sukses menghapus data detail!", StatusCode = 200 });
            }

            return BadRequest(new { message = "Gagal menghapus data detail!", StatusCode = 400 });
        }
    }
}
