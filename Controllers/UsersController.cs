using Microsoft.AspNetCore.Mvc;
using UserPersonAuditAPI.Data;
using UserPersonAuditAPI.Models.Identity;

namespace UserPersonAuditAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(ApplicationDbContext context) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(context.Set<ApplicationUser>().ToList());
        }

        [HttpPost]
        public IActionResult CreateUser(ApplicationUser user)
        {
            context.Set<ApplicationUser>().Add(user);
            context.SaveChanges();
            return Ok(user);
        }
    }
}
