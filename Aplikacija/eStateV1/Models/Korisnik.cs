using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eStateV1.Models
{
    public class Korisnik:IdentityUser<int>
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int PostanskiBroj { get; set; }
        public string Kanton { get; set; }
        public int BrojTelefona { get; set; }
        public string Adresa { get; set; }
    }
}
