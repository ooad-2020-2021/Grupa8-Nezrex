using eStateV1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eStateV1.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly eStateDBContext _context;
        public ApiController(eStateDBContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("api/SveKuce")]
        public async Task<List<Kuca>> SveKuce()
        {
            var kuce = await _context.Kuca.ToListAsync();
            return kuce;
        }

        [HttpGet]
        [Route("api/SviStanovi")]
        public async Task<List<Stan>> SviStanovi()
        {
            var stanovi = await _context.Stan.ToListAsync();
            return stanovi;
        }

        [HttpGet]
        [Route("api/SvaZemljista")]
        public async Task<ActionResult<List<Zemljiste>>> SvaZemljista()
        {
            var zemljiste = await _context.Zemljiste.ToListAsync();
            return Ok(zemljiste);
        }

        [HttpGet]
        [Route("api/SveVikendice")]
        public async Task<List<Vikendica>> SveVikendice()
        {
            var vikendice = await _context.Vikendica.ToListAsync();
            return vikendice;
            //return Ok();
        }

        [HttpPost]
        [Route("api/DodajKucu")]
        public async Task<ActionResult<Kuca>> DodajKucu([FromBody] Kuca k)
        {
            try
            {
                Kuca kuca = new Kuca
                {
                    Adresa = k.Adresa,
                    KorisnikId = 2,
                    BrojSoba = k.BrojSoba,
                    BrojSpratova = k.BrojSpratova,
                    Cijena = k.Cijena,
                    DetaljniOpis = k.DetaljniOpis,
                    Namjestena = k.Namjestena,
                    Naziv = k.Naziv,
                    Parking = k.Parking,
                    slike = null
                };
                _context.Kuca.Add(kuca);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }

}
