using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eState.Models
{
    interface IPregledKorisnika
    {
        #region Metode
        public void PregledajKorisnika(RegistrovaniKorisnik korisnik) { }
        public void ObrisiKorisnika(RegistrovaniKorisnik korisnik) { }
        #endregion
    }
}
