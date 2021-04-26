using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using COVID19IMS.Data;

namespace COVID19IMS.Controllers
{
    public class CovidTestingController : Controller
    {
        private readonly ApplicationDataContext _context;

        public CovidTestingController(ApplicationDataContext context)
        {
            _context = context;
        }

        // GET: CovidTestings
        public async Task<IActionResult> Index()
        {
            return View(await _context.CovidTestings.ToListAsync());
        }

        // GET: CovidTestings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var covidTesting = await _context.CovidTestings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (covidTesting == null)
            {
                return NotFound();
            }

            return View(covidTesting);
        }

        // GET: CovidTestings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CovidTestings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,FullName,Email,MobileNo,Birthday,NationalIdNo,HomeAddress,Status,AppointmentDateTime,AppointmentLocation,AppointmentBoothNo,TestingDate,TesterName,TestingResult,TestingDetails")] CovidTesting covidTesting)
        {
            if (ModelState.IsValid)
            {
                _context.Add(covidTesting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(covidTesting);
        }

        // GET: CovidTestings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var covidTesting = await _context.CovidTestings.FindAsync(id);
            if (covidTesting == null)
            {
                return NotFound();
            }
            return View(covidTesting);
        }

        // POST: CovidTestings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,Email,MobileNo,Birthday,NationalIdNo,HomeAddress,Status,AppointmentDateTime,AppointmentLocation,AppointmentBoothNo,TestingDate,TesterName,TestingResult,TestingDetails")] CovidTesting covidTesting)
        {
            if (id != covidTesting.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(covidTesting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CovidTestingExists(covidTesting.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(covidTesting);
        }

        // GET: CovidTestings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var covidTesting = await _context.CovidTestings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (covidTesting == null)
            {
                return NotFound();
            }

            return View(covidTesting);
        }

        // POST: CovidTestings/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var covidTesting = await _context.CovidTestings.FindAsync(id);
            _context.CovidTestings.Remove(covidTesting);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CovidTestingExists(int id)
        {
            return _context.CovidTestings.Any(e => e.Id == id);
        }
    }
}
