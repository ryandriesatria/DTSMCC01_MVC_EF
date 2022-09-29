using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcCore.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebAPI.ViewModels;

namespace MvcCore.Controllers
{
    public class AccountController : Controller
    {
        HttpClient HttpClient;
        //string address;

        public AccountController()
        {
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            string address = "https://localhost:44334/api/Account/login";
            HttpClient = new HttpClient
            {
                BaseAddress = new Uri(address)
            };

            StringContent content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");
            var result = HttpClient.PostAsync(address, content).Result;
            if (result.IsSuccessStatusCode)
            {
                var data = JsonConvert.DeserializeObject<ResponseClient>(await result.Content.ReadAsStringAsync());
                HttpContext.Session.SetString("Role", data.Data.Role);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Register register)
        {
            string address = "https://localhost:44334/api/Account/register";
            HttpClient = new HttpClient
            {
                BaseAddress = new Uri(address)
            };
            StringContent content = new StringContent(JsonConvert.SerializeObject(register), Encoding.UTF8, "application/json");
            var result = HttpClient.PostAsync(address, content).Result;
            if (result.IsSuccessStatusCode)
            {
                var data = JsonConvert.DeserializeObject<ResponseClient>(await result.Content.ReadAsStringAsync());
                HttpContext.Session.SetString("Role", data.Data.Role);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
