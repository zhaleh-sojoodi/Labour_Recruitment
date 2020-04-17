using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using roleDemo.Areas.Identity.Pages.Account;
using roleDemo.Models;
using roleDemo.Models.LabourerRecruitment;
using roleDemo.ViewModels;

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

    }

}