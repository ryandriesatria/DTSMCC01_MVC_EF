using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Repository.Data;
using WebAPI.ViewModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountRepository _repository;
        public AccountController(AccountRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("login")]
        public IActionResult Login(Login login)
        {
            var data = _repository.Login(login);

            if(data == null)
            {
                return BadRequest(new { message = "Gagal login! Email atau password salah", StatusCode = 400 });
            }
            return Ok(new { message = "Berhasil login!", StatusCode = 200, data = data});
        }

        [HttpPost("register")]
        public IActionResult Register(Register register)
        {
            var data = _repository.Register(register);

            if (data == null)
            {
                return BadRequest(new { message = "Register gagal", StatusCode = 400 });
            }
            return Ok(new { message = "Register berhasil", StatusCode = 200, data = data });
        }

        [HttpPost("changePassword")]
        public IActionResult ChangePassword(ChangePassword changePassword)
        {
            var result = _repository.ChangePassword(changePassword);

            if (result == 0)
            {
                return BadRequest(new { message = "Ganti password gagal", StatusCode = 400 });
            }
            return Ok(new { message = "Ganti password berhasil", StatusCode = 200});
        }

        [HttpPost("forgotPassword")]
        public IActionResult ForgotPassword(ForgotPassword forgotPassword)
        {
            var result = _repository.ForgotPassword(forgotPassword);

            if (result == 0)
            {
                return BadRequest(new { message = "recovery password gagal", StatusCode = 400 });
            }
            return Ok(new { message = "recovery password berhasil", StatusCode = 200 });
        }
    }
}
