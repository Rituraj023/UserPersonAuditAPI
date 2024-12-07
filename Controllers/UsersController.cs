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
            return Ok(context.Set<User>().ToList());
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            context.Set<User>().Add(user);
            context.SaveChanges();
            return Ok(user);
        }
    }
}
