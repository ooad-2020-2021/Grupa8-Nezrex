using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eStateV1.Models
{
    public abstract class Nekretnina
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public double Cijena { get; set; }
        public string Adresa { get; set; }
        public string DetaljniOpis { get; set; }
        public int KorisnikId { get; set; }
        public virtual Korisnik Korisnik { get; set; }
    }
}
