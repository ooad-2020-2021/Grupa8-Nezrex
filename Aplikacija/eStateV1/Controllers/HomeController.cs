using eStateV1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace eStateV1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly eStateDBContext _context;
        public HomeController(ILogger<HomeController> logger,eStateDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles="Admin")]
        public IActionResult AdminPanel()
        {
            var korisnici = _context.Users.ToList();
            return View(korisnici);
        }
        public IActionResult DodajNekretninu()
        {
            return View();
        }
        public IActionResult Onama()
        {
            return View();
        }
        public IActionResult Nekretnine()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Rutiraj(int vrsta)
        {

            if (vrsta == 0)
            {
                return RedirectToAction("Create", "Stan");
            }
            if (vrsta == 1)
            {
                return RedirectToAction("Create", "Vikendica");
            }
            if (vrsta == 2)
            {
                return RedirectToAction("Create", "Zemljiste");
            }
            if (vrsta == 3)
            {
                return RedirectToAction("Create", "Kuca");
            }


            return View("Index");
        }

        public IActionResult IzborNekretnineZaPregled(int vrsta)
        {

            if (vrsta == 0)
            {
                return RedirectToAction("Index", "Stan");
            }
            if (vrsta == 1)
            {
                return RedirectToAction("Index", "Vikendica");
            }
            if (vrsta == 2)
            {
                return RedirectToAction("Index", "Zemljiste");
            }
            if (vrsta == 3)
            {
                return RedirectToAction("Index", "Kuca");
            }

            return View("Index");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
