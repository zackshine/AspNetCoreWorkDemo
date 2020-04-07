using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core3MVC.Data;
using Core3MVC.Models;

namespace Core3MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestUsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TestUsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TestUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestUser>>> GetTestUsers()
        {
            return await _context.TestUsers.ToListAsync();
        }

        // GET: api/TestUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TestUser>> GetTestUser(int id)
        {
            var testUser = await _context.TestUsers.FindAsync(id);

            if (testUser == null)
            {
                return NotFound();
            }

            return testUser;
        }

        // PUT: api/TestUsers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestUser(int id, TestUser testUser)
        {
            if (id != testUser.UserId)
            {
                return BadRequest();
            }

            _context.Entry(testUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestUserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TestUsers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TestUser>> PostTestUser(TestUser testUser)
        {
            using (ApplicationDbContext myContext = _context as ApplicationDbContext)
            {
                myContext?.TestUsers?.Add(testUser);
                int changes = myContext.SaveChanges();

                if (changes > 0)
                {
                    return Created("User saved", testUser);
                }
            }
            return Accepted();
            //_context.TestUsers.Add(testUser);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTestUser", new { id = testUser.UserId }, testUser);
        }

        // DELETE: api/TestUsers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TestUser>> DeleteTestUser(int id)
        {
            var testUser = await _context.TestUsers.FindAsync(id);
            if (testUser == null)
            {
                return NotFound();
            }

            _context.TestUsers.Remove(testUser);
            await _context.SaveChangesAsync();

            return testUser;
        }

        private bool TestUserExists(int id)
        {
            return _context.TestUsers.Any(e => e.UserId == id);
        }
    }
}
