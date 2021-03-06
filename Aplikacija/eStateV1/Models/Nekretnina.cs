using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "Detaljni opis")]
        public string DetaljniOpis { get; set; }
        [Display(Name = "Vrijeme objave")]
        [Column(TypeName = "datetime2")]
        public DateTime VrijemeObjave { get; set; }
        public int KorisnikId { get; set; }
        public virtual Korisnik Korisnik { get; set; }
        public List<Slike> slike { get; set; }
        public Nekretnina()
        {
            slike = new List<Slike>();
        }
    }
}
