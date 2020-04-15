using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using roleDemo.Data;
using roleDemo.Repositories;
using roleDemo.ViewModels;

namespace roleDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private IConfiguration _config;
        private IServiceProvider _serviceProvider;
        private ApplicationDbContext _context;

        public LoginController(SignInManager<IdentityUser> signInManager,
                                IConfiguration config,
                                IServiceProvider serviceProvider,
                                ApplicationDbContext context)
        {
            _signInManager = signInManager;
            _config = config;
            _serviceProvider = serviceProvider;
            _context = context;
        }

        [HttpGet]
        [Route("List")]
        // Since we have cookie authentication and Jwt authentication we must
        // specify that we want Jwt authentication here.
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
         Roles = "Admin,Manager")]
        public JsonResult List()
        {
            var claim = HttpContext.User.Claims.ElementAt(0);
            string userName = claim.Value;
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            JArray todoList = new JArray();
            todoList.Add("Wash car");
            todoList.Add("Do laundry");
            return Json(todoList);
        }

        // GET: api/Todo
        [HttpGet]
        [Route("Todo")]
        // Since we have cookie authentication and Jwt authentication we must
        // specify that we want Jwt authentication here.
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
         Roles = "Admin,Manager,Customer")]
        
        public async Task<ActionResult<IEnumerable<Todo>>> GetTodos()
        {
            var claim = HttpContext.User.Claims.ElementAt(0);
            string userName = claim.Value;
            TodoRepo tdRepo = new TodoRepo(_context);
            List<Todo> td = tdRepo.GetAllTodos(userName);
            return  td;
        }
        // GET api/todot?id=5
        [HttpGet]
        [Route("Todot")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
 Roles = "Admin,Manager,Customer")]
        public async Task<ActionResult<Todo>> GetTodo(int id)
        {
          //  var todo = await _context.Todos.FindAsync(id);
            var claim = HttpContext.User.Claims.ElementAt(0);
            string userName = claim.Value;
            TodoRepo tdRepo = new TodoRepo(_context);
            Todo td = tdRepo.GetTodo(id, userName);
            if (td == null)
            {
                return NotFound();
            }

            return td;
        }

        [HttpPost]
        [Route("Todo")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
 Roles = "Admin,Manager,Customer")]
        public async Task<ActionResult<Todo>> PostTodo(Todo todo)
        {
            var claim = HttpContext.User.Claims.ElementAt(0);
            string userName = claim.Value;
            TodoRepo tdRepo = new TodoRepo(_context);
            tdRepo.CreateTodo(userName, todo.Description, todo.IsComplete);

            return CreatedAtAction("GetTodo(todo.ID)", new { id = todo.ID }, todo);
           }

        // PUT: api/Todo
        [HttpPut]
        [Route("Todo")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
 Roles = "Admin,Manager,Customer")]
        public async Task<IActionResult> PutTodo(Todo todo)
        {
            var claim = HttpContext.User.Claims.ElementAt(0);
            string userName = claim.Value;
            TodoRepo tdRepo = new TodoRepo(_context);
            tdRepo.Update(todo.ID, userName, todo.Description, todo.IsComplete);
            return NoContent();
        }

        // DELETE: api/Todo?id=5
        [HttpDelete]
        [Route("Todo")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
 Roles = "Admin,Manager,Customer")]
        public async Task<ActionResult<Todo>> DeleteTodo(int id)
        {
            var claim = HttpContext.User.Claims.ElementAt(0);
            string userName = claim.Value;

            var todo = await _context.Todos.FindAsync(id);
            if (todo == null || todo.UserName!=userName)
            {
                return NotFound();
            }

            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();
            return new ObjectResult(todo);
           // return todo;
        }
        [HttpGet]
        [Route("User")]
        // Since we have cookie authentication and Jwt authentication we must
        // specify that we want Jwt authentication here.
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
 Roles = "Admin,Manager")]
        public async Task<ActionResult<IEnumerable<UserVM>>> GetUsers()
        {
            var claim = HttpContext.User.Claims.ElementAt(0);
            string userName = claim.Value;
            UserRepo userRepo = new UserRepo(_context);
            IEnumerable<UserVM> users = userRepo.All();
            List<UserVM> asList = users.ToList();
            return asList;
        }

        [HttpGet]
        [Route("UserRole")]
        // Since we have cookie authentication and Jwt authentication we must
        // specify that we want Jwt authentication here.
        // Get /userrole?userName=mingming@gmail.com
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
 Roles = "Admin,Manager")]
        public async Task<ActionResult<IEnumerable<RoleVM>>> Detail(string userName)
        {
            UserRoleRepo userRoleRepo = new UserRoleRepo(_serviceProvider);
            var roles = await userRoleRepo.GetUserRoles(userName);
            // ViewBag.UserName = userName;
            List<RoleVM> roless = roles.ToList();
            return roless;
        }

        [HttpPost]
        public async Task<JsonResult> OnPostAsync([FromBody]LoginVM loginVM)
        {
            dynamic jsonResponse = new JObject();
            if (ModelState.IsValid)
            {
                var result = await
                            _signInManager.PasswordSignInAsync(loginVM.Email.ToUpper(),
                            loginVM.Password, loginVM.RememberMe, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    var UserManager = _serviceProvider
                        .GetRequiredService<UserManager<IdentityUser>>();
                    var user = await UserManager.FindByEmailAsync(loginVM.Email);

                    if (user != null)
                    {
                        var tokenString = GenerateJSONWebToken(user);
                        jsonResponse.token = tokenString;
                        jsonResponse.status = "OK";
                        return Json(jsonResponse);
                    }
                }
                else if (result.IsLockedOut)
                {
                    jsonResponse.token = "";
                    jsonResponse.status = "Locked Out";
                    return Json(jsonResponse);
                }
            }
            jsonResponse.token = "";
            jsonResponse.status = "Invalid Login";
            return Json(jsonResponse);
        }

        List<Claim> AddUserRoleClaims(List<Claim> claims, string userId)
        {
            // Get current user's roles. 
            var userRoleList = _context.UserRoles.Where(ur => ur.UserId == userId);
            var roleList = from ur in userRoleList
                           from r in _context.Roles
                           where r.Id == ur.RoleId
                           select new { r.Name };

            // Add each of the user's roles to the claims list.
            foreach (var roleItem in roleList)
            {
                claims.Add(new Claim(ClaimTypes.Role, roleItem.Name));
            }
            return claims;
        }

        string GenerateJSONWebToken(IdentityUser user)
        {
            var securityKey
                = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials
                = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti,
                            Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            claims = AddUserRoleClaims(claims, user.Id);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private bool TodoExists(int id)
        {
            return _context.Todos.Any(e => e.ID == id);
        }
    }
}
