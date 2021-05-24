using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eStateV1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace eStateV1.Controllers
{ 
    public class StanController : Controller
    {
        private readonly eStateDBContext _context;
        private readonly UserManager<Korisnik> _userManager;
        public StanController(eStateDBContext context,UserManager<Korisnik> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Stan
        public async Task<IActionResult> Index()
        {
            var eStateDBContext = _context.Stan.Include(s => s.Korisnik);
            return View(await eStateDBContext.ToListAsync());
        }
        public async Task<IActionResult> MojiStanovi()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var stanovi = await _context.Stan.Where(x => x.KorisnikId ==int.Parse(userId)).ToListAsync();
            return View("Index", stanovi);
        }


        // GET: Stan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stan = await _context.Stan
                .Include(s => s.Korisnik)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stan == null)
            {
                return NotFound();
            }

            return View(stan);
        }

        // GET: Stan/Create
        [Authorize(Roles = "Admin,Korisnik")]
        public IActionResult Create()
        {
            ViewData["KorisnikId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }
        // POST: Stan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BrojSprata,BrojSoba,Parking,Namjesten,Lift,Novogradnja,ImaBalkon,Id,Naziv,Cijena,Adresa,DetaljniOpis")] Stan stan)
        {
            if (ModelState.IsValid)
            {
                stan.KorisnikId = int.Parse(_userManager.GetUserId(HttpContext.User));
                _context.Add(stan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KorisnikId"] = new SelectList(_context.Users, "Id", "Id", stan.KorisnikId);
            return View(stan);
        }
        [Authorize(Roles = "Admin,Korisnik")]
        // GET: Stan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stan = await _context.Stan.FindAsync(id);
            if (stan == null)
            {
                return NotFound();
            }
            ViewData["KorisnikId"] = new SelectList(_context.Users, "Id", "Id", stan.KorisnikId);
            return View(stan);
        }
        [Authorize(Roles = "Admin,Korisnik")]
        // POST: Stan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BrojSprata,BrojSoba,Parking,Namjesten,Lift,Novogradnja,ImaBalkon,Id,Naziv,Cijena,Adresa,DetaljniOpis,KorisnikId")] Stan stan)
        {
            if (id != stan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StanExists(stan.Id))
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
            ViewData["KorisnikId"] = new SelectList(_context.Users, "Id", "Id", stan.KorisnikId);
            return View(stan);
        }
        [Authorize(Roles = "Admin,Korisnik")]
        // GET: Stan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stan = await _context.Stan
                .Include(s => s.Korisnik)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stan == null)
            {
                return NotFound();
            }

            return View(stan);
        }
        [Authorize(Roles = "Admin,Korisnik")]
        // POST: Stan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stan = await _context.Stan.FindAsync(id);
            _context.Stan.Remove(stan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StanExists(int id)
        {
            return _context.Stan.Any(e => e.Id == id);
        }
    }
}
