using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using roleDemo.Areas.Identity.Pages.Account;
using roleDemo.Data;
using roleDemo.Models;

namespace roleDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterLabourerController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;

        public RegisterLabourerController(
    UserManager<IdentityUser> userManager,
    ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> OnPostAsync([FromBody]RegisterModel.InputModel input)
        {
            var user = new IdentityUser { UserName = input.Email.ToLower(), Email = input.Email };
            var result = await _userManager.CreateAsync(user, input.Password);
            var errorList = new List<string>();

            if (result.Succeeded)
            {
                _context.SysUsers.Add(new SysUser()
                {
                    Email = input.Email,
                    Password = input.Password,
                    Role = input.Role
                });
                _context.Labourers.Add(new Labourer()
                {
                    FullName = input.FullName,
                    Email = input.Email,
                    PassWord = input.Password,
                    Description = "",
                    Rating = 5.0f,
                    IsAvailable = true,
                    Availability = input.Availability
                });
                _context.SaveChanges();
                return Ok(new { status = 200, title = "Registered successfully." });
            }

            foreach (IdentityError error in result.Errors)
            {
                errorList.Add(error.Description);
            }

            return BadRequest(new { status = 400, errors = errorList });
        }
    }
}