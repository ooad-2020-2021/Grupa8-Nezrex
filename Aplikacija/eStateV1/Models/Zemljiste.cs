using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eStateV1.Models
{
    public class Zemljiste:Nekretnina
    {
        public bool UrbanistickaDozvola { get; set; }
        public bool GradjevinskaDozvola { get; set; }
        public bool KomunalniPrikljucak { get; set; }

    }
}
