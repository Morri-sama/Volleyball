using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    public class SetsController : Controller
    {
        private readonly string _apiUrl;

        public SetsController(IConfiguration configuration)
        {
            _apiUrl = configuration.GetSection("ApiUrl").Value;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            HttpResponseMessage response = null;

            int matchId = 1;

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json;odata=verbose");
                response = await httpClient.GetAsync(new Uri(_apiUrl + $"api/sets/{matchId}"));
            }

            if (response.IsSuccessStatusCode)
            {
                return View(await response.Content.ReadAsAsync<ICollection<Set>>());
            }
            else
            {
                return NotFound();
            }
        }

    }
}
