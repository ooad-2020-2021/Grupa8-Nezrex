using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eState.Models
{
    public abstract class Nekretnina
    {
        
        #region Properties
        [Key]
        [Required]
        public int ID { get; set; }
        [Required]
        public string Naziv { get; set; }
        [Required]
        public double Cijena { get; set; }
        [Required]
        public string Adresa { get; set; }
        [Required]
        public int Kvadratura { get; set; }
        [Required]
        public string DetaljniOpis { get; set; }
        [Required]
        public string Slika { get; set; }
        [Required]
        public Prodavac Prodavac { get; set; }
        #endregion
        
        #region Constructors
        public Nekretnina(string naziv, double cijena, string adresa, int kvadratura, string detaljniOpis, string slika, Prodavac prodavac)
        {
            Naziv = naziv;
            Cijena = cijena;
            Adresa = adresa;
            Kvadratura = kvadratura;
            DetaljniOpis = detaljniOpis;
            Slika = slika;
            Prodavac = prodavac;
        }
        public Nekretnina() { }
        #endregion
        #region Metode
        public void AzurirajPodatke() { }
        #endregion
    }
}
