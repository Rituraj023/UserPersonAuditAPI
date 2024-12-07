using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserPersonAuditAPI.Data;
using UserPersonAuditAPI.Models.Person;

namespace UserPersonAuditAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController(ApplicationDbContext context) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetPersons()
        {
            return Ok(context.Set<Person>().Include(p => p.CreatedBy).Include(p => p.UpdatedBy).ToList());
        }

        [HttpPost]
        public IActionResult CreatePerson(Person person)
        {
            person.CreatedOn = DateTime.UtcNow;
            context.Set<Person>().Add(person);
            context.SaveChanges();
            return Ok(person);
        }
    }
}
