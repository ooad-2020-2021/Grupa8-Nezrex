using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eState.Models
{
    public class Prodavac
    {
        #region Properties
        [NotMapped]
        public List<Nekretnina> Nekretnina { get; set; }
        #endregion
        
        #region Constructors
        public Prodavac() {}
        public Prodavac(List<Nekretnina> nekretnina) {
            Nekretnina = nekretnina;
        }

        #endregion

        #region Metode
        public void postaviNekretninu() { }
        public void azurirajPodatkeNekretnine() { }
        public void odgovoriKupcu() { }
        #endregion
    }
}
