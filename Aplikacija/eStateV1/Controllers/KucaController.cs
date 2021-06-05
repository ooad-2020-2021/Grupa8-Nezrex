using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eStateV1.Models;
using Microsoft.AspNetCore.Identity;
using System.Web;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace eStateV1.Controllers
{
    public class KucaController : Controller
    {
        private readonly eStateDBContext _context;
        private readonly UserManager<Korisnik> _userManager;

        public KucaController(eStateDBContext context, UserManager<Korisnik> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Kuca
        public async Task<IActionResult> Index()
        {
            var eStateDBContext = _context.Kuca.Include(k => k.Korisnik);
            return View(await eStateDBContext.ToListAsync());
        }
        public async Task<IActionResult> MojeKuce()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var kuce = await _context.Kuca.Where(x => x.KorisnikId == int.Parse(userId)).ToListAsync();
            return View("Index", kuce);
        }

        // GET: Kuca/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kuca = await _context.Kuca
                .Include(k => k.Korisnik)
                .FirstOrDefaultAsync(m => m.Id == id);
            var slike = await _context.Slike.Where(x => x.NekretninaId == id).ToListAsync();
            kuca.slike = slike;
            if (kuca == null)
            {
                return NotFound();
            }

            return View(kuca);
        }

        // GET: Kuca/Create
        public IActionResult Create()
        {
            ViewData["KorisnikId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Kuca/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BrojSpratova,BrojSoba,Parking,Namjestena,Id,Naziv,Cijena,Adresa,DetaljniOpis")] Kuca kuca, ICollection<IFormFile> files)
        {


            //var res =  System.IO.File.ReadAllBytes(formFiles[0]);
            // String file = Convert.ToBase64String(res);
            if (ModelState.IsValid)
            {
                kuca.KorisnikId = int.Parse(_userManager.GetUserId(HttpContext.User));
                var now = DateTime.Now;
                var date = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
                kuca.VrijemeObjave =date;
                _context.Add(kuca);
                await _context.SaveChangesAsync();
                foreach (var file in files)
                {
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        var bajtovi = ms.ToArray();
                        string s = Convert.ToBase64String(bajtovi);
                        var slika = new Slike { ImageBase64 = s, NekretninaId = kuca.Id };
                        _context.Slike.Add(slika);
                        await _context.SaveChangesAsync();
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["KorisnikId"] = new SelectList(_context.Users, "Id", "Id", kuca.KorisnikId);
            return View(kuca);
        }

        // GET: Kuca/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kuca = await _context.Kuca.FindAsync(id);
            if (kuca == null)
            {
                return NotFound();
            }
            ViewData["KorisnikId"] = new SelectList(_context.Users, "Id", "Id", kuca.KorisnikId);
            return View(kuca);
        }

        // POST: Kuca/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BrojSpratova,BrojSoba,Parking,Namjestena,Id,Naziv,Cijena,Adresa,DetaljniOpis")] Kuca kuca)
        {
            if (id != kuca.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    kuca.KorisnikId = int.Parse(_userManager.GetUserId(HttpContext.User));
                    _context.Update(kuca);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KucaExists(kuca.Id))
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
            ViewData["KorisnikId"] = new SelectList(_context.Users, "Id", "Id", kuca.KorisnikId);
            return View(kuca);
        }

        // GET: Kuca/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kuca = await _context.Kuca
                .Include(k => k.Korisnik)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kuca == null)
            {
                return NotFound();
            }

            return View(kuca);
        }

        // POST: Kuca/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kuca = await _context.Kuca.FindAsync(id);
            _context.Kuca.Remove(kuca);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KucaExists(int id)
        {
            return _context.Kuca.Any(e => e.Id == id);
        }
    }
}
