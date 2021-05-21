using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eStateV1.Models;

namespace eStateV1.Controllers
{
    public class ZemljisteController : Controller
    {
        private readonly eStateDBContext _context;

        public ZemljisteController(eStateDBContext context)
        {
            _context = context;
        }

        // GET: Zemljiste
        public async Task<IActionResult> Index()
        {
            var eStateDBContext = _context.Zemljiste.Include(z => z.Korisnik);
            return View(await eStateDBContext.ToListAsync());
        }

        // GET: Zemljiste/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zemljiste = await _context.Zemljiste
                .Include(z => z.Korisnik)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zemljiste == null)
            {
                return NotFound();
            }

            return View(zemljiste);
        }

        // GET: Zemljiste/Create
        public IActionResult Create()
        {
            ViewData["KorisnikId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Zemljiste/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UrbanistickaDozvola,GradjevinskaDozvola,KomunalniPrikljucak,Id,Naziv,Cijena,Adresa,DetaljniOpis,KorisnikId")] Zemljiste zemljiste)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zemljiste);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KorisnikId"] = new SelectList(_context.Users, "Id", "Id", zemljiste.KorisnikId);
            return View(zemljiste);
        }

        // GET: Zemljiste/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zemljiste = await _context.Zemljiste.FindAsync(id);
            if (zemljiste == null)
            {
                return NotFound();
            }
            ViewData["KorisnikId"] = new SelectList(_context.Users, "Id", "Id", zemljiste.KorisnikId);
            return View(zemljiste);
        }

        // POST: Zemljiste/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UrbanistickaDozvola,GradjevinskaDozvola,KomunalniPrikljucak,Id,Naziv,Cijena,Adresa,DetaljniOpis,KorisnikId")] Zemljiste zemljiste)
        {
            if (id != zemljiste.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zemljiste);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZemljisteExists(zemljiste.Id))
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
            ViewData["KorisnikId"] = new SelectList(_context.Users, "Id", "Id", zemljiste.KorisnikId);
            return View(zemljiste);
        }

        // GET: Zemljiste/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zemljiste = await _context.Zemljiste
                .Include(z => z.Korisnik)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zemljiste == null)
            {
                return NotFound();
            }

            return View(zemljiste);
        }

        // POST: Zemljiste/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zemljiste = await _context.Zemljiste.FindAsync(id);
            _context.Zemljiste.Remove(zemljiste);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZemljisteExists(int id)
        {
            return _context.Zemljiste.Any(e => e.Id == id);
        }
    }
}
