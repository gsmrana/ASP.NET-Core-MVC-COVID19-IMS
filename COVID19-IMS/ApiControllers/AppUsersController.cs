using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using COVID19IMS.Data;
using COVID19IMS.Models;

namespace COVID19IMS.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : ControllerBase
    {
        private readonly ApplicationDataContext _context;

        public AppUsersController(ApplicationDataContext context)
        {
            _context = context;
        }

        // GET: api/AppUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetAppUsers()
        {
            return await _context.AppUsers.ToListAsync();
        }

        // POST: api/AppUsers/Login
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<AppUser>> Login(AppUser appUser)
        {
            var loginUser = await _context.AppUsers
                .FirstOrDefaultAsync(u => u.Email == appUser.Email && u.PasswordHash == appUser.PasswordHash);
            if (loginUser == null)  return NotFound();
            return loginUser;
        }

        // POST: api/AppUsers/Register
        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<AppUser>> Register(AppUser appUser)
        {
            if (_context.AppUsers.Any(u => u.Email == appUser.Email)) 
                return BadRequest("The Email is already registered.");

            appUser.RuleName = "User";
            _context.AppUsers.Add(appUser);
            await _context.SaveChangesAsync();
            return CreatedAtAction("/", new { id = appUser.Id }, appUser);
        }

        // GET: api/AppUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetAppUser(int id)
        {
            var appUser = await _context.AppUsers.FindAsync(id);

            if (appUser == null)
            {
                return NotFound();
            }

            return appUser;
        }

        // PUT: api/AppUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppUser(int id, AppUser appUser)
        {
            if (id != appUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(appUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppUserExists(id))
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

        // POST: api/AppUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AppUser>> PostAppUser(AppUser appUser)
        {
            _context.AppUsers.Add(appUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppUser", new { id = appUser.Id }, appUser);
        }

        // DELETE: api/AppUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppUser(int id)
        {
            var appUser = await _context.AppUsers.FindAsync(id);
            if (appUser == null)
            {
                return NotFound();
            }

            _context.AppUsers.Remove(appUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppUserExists(int id)
        {
            return _context.AppUsers.Any(e => e.Id == id);
        }
    }
}
