using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Validate()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);

                if (result.Succeeded)
                {
                    var user = _userManager.Users.SingleOrDefault(r => r.NormalizedUserName == model.UserName.Normalize());
                    return Ok(Jwt.GenerateTokenAsync(user, _configuration["JwtKey"], Convert.ToInt32(_configuration["JwtExpireDays"]), _configuration["JwtIssuer"], _configuration["JwtIssuer"]));
                }
            }
            else
            {
                return NotFound();
            }

            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    UserName = model.UserName,
                    FirstName = model.FirstName,
                    MiddleName = model.MiddleName,
                    LastName = model.LastName
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return Ok(Jwt.GenerateTokenAsync(user, _configuration["JwtKey"], Convert.ToInt32(_configuration["JwtExpireDays"]), _configuration["JwtIssuer"], _configuration["JwtIssuer"]));
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {

                return NotFound();
            }
        }
    }
}
