using DWT_apiProj.Data;
using DWT_apiProj.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DWT_apiProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly TableDbContext dbContext;
        public UserController(TableDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        [HttpGet]
        public IActionResult getALL()
        {
            var usersLS = dbContext.Users.ToList();
            return Ok(usersLS);
        }
        
        [HttpPost]
        public IActionResult Add(UserEX addUser)
        {
            var emploee = new User()
            {
                Name = addUser.Name,
                Email = addUser.Email,
                Password = addUser.Password,
                Phone = addUser.Phone,
            };

            dbContext.Users.Add(emploee);
            dbContext.SaveChanges();
            return Ok(emploee);
        }

        [HttpGet("login")]
        public async Task<IActionResult> CheckEmail([FromQuery] string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest(new { message = "Email is required" });
            }

            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user != null)
            {
                return Ok(new { exists = true, message = "Email already exists",pass=user.Password});
            }
            else
            {
                return Ok(new { exists = false, message = "Email is available" });
            }
        }


    }
}
