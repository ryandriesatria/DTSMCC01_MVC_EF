using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Context;
using WebAPI.Models;
using WebAPI.Repository.Data;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MastersController : ControllerBase
    {
        private readonly MastersRepository _repository;
        public MastersController(MastersRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = _repository.Get();

            return Ok(new { message = "Sukses mengambil data master!", StatusCode = 200, data = data });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = _repository.Get(id);

            return Ok(new { message = "Sukses mengambil data master!", StatusCode = 200, data = data });
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Masters master)
        {
            var result = _repository.Put(id, master);
            if (result > 0)
            {
                return Ok(new { message = "Sukses mengubah data master!", StatusCode = 200 });
            }

            return BadRequest(new { message = "Gagal mengubah data master!", StatusCode = 400 });
        }

        [HttpPost]
        public IActionResult Post(Masters master)
        {
            var result = _repository.Post(master);
            if (result > 0)
            {
                return Ok(new { message = "Sukses menambahkan data master!", StatusCode = 200 });
            }

            return BadRequest(new { message = "Gagal menambahkan data master!", StatusCode = 400 });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _repository.Delete(id);
            if (result > 0)
            {
                return Ok(new { message = "Sukses menghapus data master!", StatusCode = 200 });
            }

            return BadRequest(new { message = "Gagal menghapus data master!", StatusCode = 400 });
        }
    }
}
