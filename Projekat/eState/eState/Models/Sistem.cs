using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eState.Models
{
    public class Sistem
    {
        #region Properties
        [NotMapped]
        public List<Korisnik> Korisnici { get; set; }
        [NotMapped]
        public List<Nekretnina> Nekretnine { get; set; }
        #endregion
        #region Constructors
        public Sistem(List<Korisnik> korisnici, List<Nekretnina> nekretnine)
        {
            Korisnici = korisnici;
            Nekretnine = nekretnine;
        }
        #endregion
        #region Modeli
        public void dodajKorisnika() { }
        public void obrisiKorisnika() { }
        #endregion
    }
}
