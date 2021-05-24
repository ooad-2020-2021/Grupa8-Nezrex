using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eStateV1.Models
{
    public class Korisnik:IdentityUser<int>
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        [Display(Name = "Poštanski broj")]
        public int PostanskiBroj { get; set; }
        public string Kanton { get; set; }
        [Display(Name = "Broj telefona")]
        public int BrojTelefona { get; set; }
        public string Adresa { get; set; }
    }
}
