using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models;
using Newtonsoft.Json;

namespace WebApplication.Controllers
{
    public class TeamsController : Controller
    {
        readonly string _apiUrl;

        public TeamsController(IConfiguration configuration)
        {
            _apiUrl = configuration.GetSection("ApiUrl").Value;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]Team team)
        {
            HttpResponseMessage response = null;

            using (var httpClient = new HttpClient())
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(team), Encoding.UTF8, "application/json");
                response = await httpClient.PostAsync(new Uri(_apiUrl + "api/teams"), stringContent);
            }

            if (response.IsSuccessStatusCode)
            {
                return View();
            }
            else
            {
                return NotFound();
            }
        }
    }
}