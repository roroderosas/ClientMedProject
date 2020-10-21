using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClientMed.Data;
using ClientMed.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;


namespace ClientMed.Controllers
{
    public class MedCalendarsController : Controller
    {
        private readonly MedCalContext _context;

        public MedCalendarsController(MedCalContext context)
        {
            _context = context;
        }

        // GET: MedCalendars
        public async Task<IActionResult> Index()
        {
            var medCalContext = _context.MedCalendars.Include(m => m.Client).Include(m => m.DayOfWk).Include(m => m.DaySched);
            return View(await medCalContext.ToListAsync());
        }

        // GET: MedCalendars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medCalendar = await _context.MedCalendars
                .Include(m => m.Client)
                .Include(m => m.DayOfWk)
                .Include(m => m.DaySched)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (medCalendar == null)
            {
                return NotFound();
            }

            return View(medCalendar);
        }

        // GET: MedCalendars/Create
        public IActionResult Create()
        {
            //ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "ClientID");
            //ViewData["DayOfWkID"] = new SelectList(_context.Set<DayOfWk>(), "DayOfWkID", "DayOfWkID");
            //ViewData["DaySchedID"] = new SelectList(_context.Set<DaySched>(), "DaySchedID", "DaySchedID");
            PopulateClientNameDropDownList();
            PopulateDayOfWkDropDownList();
            PopulateDaySchedDropDownList();
            return View();
        }

        // POST: MedCalendars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ClientID,DaySchedID,DayOfWkID,SugarLvl,Done")] MedCalendar medCalendar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medCalendar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "ClientID", medCalendar.ClientID);
            ViewData["DayOfWkID"] = new SelectList(_context.Set<DayOfWk>(), "DayOfWkID", "DayOfWkID", medCalendar.DayOfWkID);
            ViewData["DaySchedID"] = new SelectList(_context.Set<DaySched>(), "DaySchedID", "DaySchedID", medCalendar.DaySchedID);
           // ViewData["ClientName"] = new SelectList(_context.Set<Client>(), "LastName", "LastName", medCalendar.Client.LastName);
            return View(medCalendar);
        }

        // GET: MedCalendars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var medCalendar = await _context.MedCalendars.FindAsync(id);

            var medCalendar = await _context.MedCalendars
                .Include(m => m.Client)
                .Include(m => m.DayOfWk)
                .Include(m => m.DaySched)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (medCalendar == null)
            {
                return NotFound();
            }
            //ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "ClientID", medCalendar.ClientID);
            //ViewData["DayOfWkID"] = new SelectList(_context.Set<DayOfWk>(), "DayOfWkID", "DayOfWkID", medCalendar.DayOfWkID);
            //ViewData["DaySchedID"] = new SelectList(_context.Set<DaySched>(), "DaySchedID", "DaySchedID", medCalendar.DaySchedID);
            //ViewData["LastName"] = new SelectList(_context.Set<Client>(), "LastName", "LastName", medCalendar.Client.LastName);
            return View(medCalendar);
        }

        // POST: MedCalendars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SugarLvl,Done")] MedCalendar medCalendar)
        {
            if (id != medCalendar.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medCalendar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedCalendarExists(medCalendar.ID))
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
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "ClientID", medCalendar.ClientID);
            ViewData["DayOfWkID"] = new SelectList(_context.Set<DayOfWk>(), "DayOfWkID", "DayOfWkID", medCalendar.DayOfWkID);
            ViewData["DaySchedID"] = new SelectList(_context.Set<DaySched>(), "DaySchedID", "DaySchedID", medCalendar.DaySchedID);

            return View(medCalendar);
        }

        // GET: MedCalendars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medCalendar = await _context.MedCalendars
                .Include(m => m.Client)
                .Include(m => m.DayOfWk)
                .Include(m => m.DaySched)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (medCalendar == null)
            {
                return NotFound();
            }

            return View(medCalendar);
        }

        // POST: MedCalendars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medCalendar = await _context.MedCalendars.FindAsync(id);
            _context.MedCalendars.Remove(medCalendar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedCalendarExists(int id)
        {
            return _context.MedCalendars.Any(e => e.ID == id);
        }

        private void PopulateClientNameDropDownList(object selectedClientName = null)
        {
            var clientnameQuery = from c in _context.Clients
                                  orderby c.LastName
                                  select c;
            ViewBag.ClientID = new SelectList(clientnameQuery, "ClientID", "LastName", selectedClientName);
        }

        private void PopulateDayOfWkDropDownList(object selectedDayOfWk = null)
        {
            var dayofwkQuery = from d in _context.DayOfWks
                               orderby d.DayOfWkID
                               select d;
            ViewBag.DayOfWkID = new SelectList(dayofwkQuery, "DayOfWkID", "DayOfWkName", selectedDayOfWk);
        }

        private void PopulateDaySchedDropDownList(object selectedDaySched = null)
        {
            var dayschedkQuery = from d in _context.DayScheds
                               orderby d.DaySchedID
                               select d;
            ViewBag.DaySchedID = new SelectList(dayschedkQuery, "DaySchedID", "DaySchedName", selectedDaySched);
        }
    }
}
