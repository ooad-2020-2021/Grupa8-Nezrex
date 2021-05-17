using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eState.Models
{
    public class RegistrovaniKorisnik : Korisnik
    {
        
        #region Properties
        [Key]
        [Required]
        public int ID { get; set; }
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        [Required]
        [Range(4, int.MaxValue, ErrorMessage = "Lozinka mora imati najmanje 4 znaka")]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int PostanskiBroj { get; set; }
        [Required]
        public string Kanton { get; set; }
        [Required]
        public int BrojMobitela { get; set; }
        [Required]
        public string Adresa { get; set; }
        #endregion

        #region Constructors
        public RegistrovaniKorisnik() { }
        public RegistrovaniKorisnik(string ime, string prezime, string email, int postanskiBroj, string kanton, int brojMobitela, string adresa) {
            Ime = ime;
            Prezime = prezime;
            Email = email;
            PostanskiBroj = postanskiBroj;
            Kanton = kanton;
            BrojMobitela = brojMobitela;
            Adresa = adresa;
        }

    
        #endregion
        #region Metode
        public void AzurirajPodatkeProfila() { }
        #endregion
    }
}
