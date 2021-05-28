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
    public class CovidTestingsController : ControllerBase
    {
        private readonly ApplicationDataContext _context;

        public CovidTestingsController(ApplicationDataContext context)
        {
            _context = context;
        }

        // GET: api/CovidTestings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CovidTesting>>> GetCovidTestings()
        {
            return await _context.CovidTestings.ToListAsync();
        }

        // GET: api/CovidTestings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CovidTesting>> GetCovidTesting(int id)
        {
            var covidTesting = await _context.CovidTestings.FindAsync(id);

            if (covidTesting == null)
            {
                return NotFound();
            }

            return covidTesting;
        }

        // PUT: api/CovidTestings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCovidTesting(int id, CovidTesting covidTesting)
        {
            if (id != covidTesting.Id)
            {
                return BadRequest();
            }

            _context.Entry(covidTesting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CovidTestingExists(id))
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

        // POST: api/CovidTestings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CovidTesting>> PostCovidTesting(CovidTesting covidTesting)
        {
            _context.CovidTestings.Add(covidTesting);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCovidTesting", new { id = covidTesting.Id }, covidTesting);
        }

        // DELETE: api/CovidTestings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCovidTesting(int id)
        {
            var covidTesting = await _context.CovidTestings.FindAsync(id);
            if (covidTesting == null)
            {
                return NotFound();
            }

            _context.CovidTestings.Remove(covidTesting);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CovidTestingExists(int id)
        {
            return _context.CovidTestings.Any(e => e.Id == id);
        }
    }
}
