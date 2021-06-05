using eStateV1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using eStateV1.Helpers;

namespace eStateV1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly eStateDBContext _context;
        private readonly UserManager<Korisnik> _userManager;
        private readonly HelperMethods _helperMethods;
        public HomeController(ILogger<HomeController> logger,eStateDBContext context,UserManager<Korisnik> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _helperMethods = new HelperMethods();
        }

        public async Task<IActionResult> Index()
        {
            var weather = await _helperMethods.GetInfoAboutWeatherInSarajevo();
            var temperatura = weather.temp;
            var Grad = weather.city_name;
            ViewBag.Temperatura = temperatura;
            ViewBag.Grad = Grad;
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
        public async Task<IActionResult> Nekretnine()
        {
            dynamic returnModel = new ExpandoObject();
            returnModel.kuce = await _context.Kuca.ToListAsync();
            returnModel.stanovi = await _context.Stan.ToListAsync();
            returnModel.vikendice = await _context.Vikendica.ToListAsync();
            returnModel.zemljista =await _context.Zemljiste.ToListAsync();
            return View(returnModel);
        }

        public async Task<IActionResult> MojeNekretnine()
        {
            dynamic returnModel = new ExpandoObject();
            var userId = _userManager.GetUserId(HttpContext.User);
            returnModel.kuce = await _context.Kuca.Where(x => x.KorisnikId == int.Parse(userId)).ToListAsync();
            returnModel.stanovi = await _context.Stan.Where(x => x.KorisnikId == int.Parse(userId)).ToListAsync();
            returnModel.vikendice = await _context.Vikendica.Where(x => x.KorisnikId == int.Parse(userId)).ToListAsync();
            returnModel.zemljista = await _context.Zemljiste.Where(x => x.KorisnikId == int.Parse(userId)).ToListAsync();
            return View(returnModel);
        }

       /* public Task<IActionResult> IzborNekretnine()
        {
            
            //return View(returnModel);
        }*/

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

        public IActionResult MojeIzborNekretnine(int vrsta)
        {

            if (vrsta == 0)
            {
                return RedirectToAction("MojiStanovi", "Stan");
            }
            if (vrsta == 1)
            {
                return RedirectToAction("MojeVikendice", "Vikendica");
            }
            if (vrsta == 2)
            {
                return RedirectToAction("MojaZemljista", "Zemljiste");
            }
            if (vrsta == 3)
            {
                return RedirectToAction("MojeKuce", "Kuca");
            }

            return View("Index");
        }


        public IActionResult SveNekretnine(string value)
        {
            if(value=="Kuce")
            {
                var kuce = _context.Kuca.ToList();
                TempData["Kuce"] = JsonConvert.SerializeObject(kuce);
            }
            else
            {
                TempData["Kuce"] = _context.Kuca.ToList();
            }
            return RedirectToAction("MojeNekretnine");
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
