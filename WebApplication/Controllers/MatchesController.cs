using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    public class MatchesController : Controller
    {
        readonly string _apiUrl;

        public MatchesController(IConfiguration configuration)
        {
            _apiUrl = configuration.GetSection("ApiUrl").Value;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async  Task<IActionResult> Create()
        {
            HttpResponseMessage response = null;

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json;odata=verbose");
                response = await httpClient.GetAsync(new Uri(_apiUrl + "api/teams"));
            }

            if (response.IsSuccessStatusCode)
            {
                ViewBag.Teams = new SelectList(await response.Content.ReadAsAsync<List<Team>>(), "Id", "Name");
                return View();
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]Match match)
        {
            HttpResponseMessage response = null;

            using (var httpClient = new HttpClient())
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(match), Encoding.UTF8, "application/json");
                response = await httpClient.PostAsync(new Uri(_apiUrl + "api/matches"), stringContent);
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
