using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Context;
using WebAPI.Models;
using WebAPI.ViewModels;
using WebAPI.Repository.Data;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailsController : ControllerBase
    {
        private readonly DetailsRepository _repository;
        public DetailsController(DetailsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = _repository.Get();

            return Ok(new { message = "Sukses mengambil data detail!", StatusCode = 200, data = data });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = _repository.Get(id);

            return Ok(new { message = "Sukses mengambil data detail!", StatusCode = 200, data = data });
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, DetailsViewModel detail)
        {
            var result = _repository.Put(id, detail);

            if (result > 0)
            {
                return Ok(new { message = "Sukses mengubah data detail!", StatusCode = 200 });
            }

            return BadRequest(new { message = "Gagal mengubah data detail!", StatusCode = 400 });
        }

        [HttpPost]
        public IActionResult Post(DetailsViewModel detail)
        {
            var result = _repository.Post(detail);
                        
            if (result > 0)
            {
                return Ok(new { message = "Sukses menambahkan data detail!", StatusCode = 200 });
            }

            return BadRequest(new { message = "Gagal menambahkan data detail!", StatusCode = 400 });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _repository.Delete(id);
            if (result > 0)
            {
                return Ok(new { message = "Sukses menghapus data detail!", StatusCode = 200 });
            }

            return BadRequest(new { message = "Gagal menghapus data detail!", StatusCode = 400 });
        }
    }
}
