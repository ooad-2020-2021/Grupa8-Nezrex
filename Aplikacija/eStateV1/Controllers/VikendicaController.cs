using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eStateV1.Models;
using Microsoft.AspNetCore.Identity;

namespace eStateV1.Controllers
{
    public class VikendicaController : Controller
    {
        private readonly eStateDBContext _context;
        private readonly UserManager<Korisnik> _userManager;
        public VikendicaController(eStateDBContext context,UserManager<Korisnik> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Vikendica
        public async Task<IActionResult> Index()
        {
            var eStateDBContext = _context.Vikendica.Include(v => v.Korisnik);
            return View(await eStateDBContext.ToListAsync());
        }

        // GET: Vikendica/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vikendica = await _context.Vikendica
                .Include(v => v.Korisnik)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vikendica == null)
            {
                return NotFound();
            }

            return View(vikendica);
        }

        // GET: Vikendica/Create
        public IActionResult Create()
        {
            ViewData["KorisnikId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Vikendica/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BrojSoba,BrojSpratova,Parking,Namjeseten,Id,Naziv,Cijena,Adresa,DetaljniOpis")] Vikendica vikendica)
        {
            if (ModelState.IsValid)
            {
                vikendica.KorisnikId = int.Parse(_userManager.GetUserId(HttpContext.User));
                _context.Add(vikendica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KorisnikId"] = new SelectList(_context.Users, "Id", "Id", vikendica.KorisnikId);
            return View(vikendica);
        }

        // GET: Vikendica/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vikendica = await _context.Vikendica.FindAsync(id);
            if (vikendica == null)
            {
                return NotFound();
            }
            ViewData["KorisnikId"] = new SelectList(_context.Users, "Id", "Id", vikendica.KorisnikId);
            return View(vikendica);
        }

        // POST: Vikendica/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BrojSoba,BrojSpratova,Parking,Namjeseten,Id,Naziv,Cijena,Adresa,DetaljniOpis,KorisnikId")] Vikendica vikendica)
        {
            if (id != vikendica.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vikendica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VikendicaExists(vikendica.Id))
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
            ViewData["KorisnikId"] = new SelectList(_context.Users, "Id", "Id", vikendica.KorisnikId);
            return View(vikendica);
        }

        // GET: Vikendica/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vikendica = await _context.Vikendica
                .Include(v => v.Korisnik)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vikendica == null)
            {
                return NotFound();
            }

            return View(vikendica);
        }

        // POST: Vikendica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vikendica = await _context.Vikendica.FindAsync(id);
            _context.Vikendica.Remove(vikendica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VikendicaExists(int id)
        {
            return _context.Vikendica.Any(e => e.Id == id);
        }
    }
}
