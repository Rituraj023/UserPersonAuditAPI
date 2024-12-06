using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserPersonAuditAPI.Data;
using UserPersonAuditAPI.Models;

namespace UserPersonAuditAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PersonsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetPersons()
        {
            return Ok(_context.Persons.Include(p => p.CreatedBy).Include(p => p.UpdatedBy).ToList());
        }

        [HttpPost]
        public IActionResult CreatePerson(Person person)
        {
            person.CreatedOn = DateTime.UtcNow;
            _context.Persons.Add(person);
            _context.SaveChanges();
            return Ok(person);
        }
    }
}
