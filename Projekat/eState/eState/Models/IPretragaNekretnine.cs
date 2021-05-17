using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eState.Models
{
    interface IPretragaNekretnine
    {
        public List<Nekretnina> pretragaPoKategoriji();
        public List<Nekretnina> PretragaPoCijeni(int cijena);
        public List<Nekretnina> pretragaPoLokaciji(string adresa);
        public List<Nekretnina> pretragaPoVelicini(int kvadratura);
        public List<Nekretnina> pretragaPoVrsti(PretragaPoVrsti vrsta);
    }
}
