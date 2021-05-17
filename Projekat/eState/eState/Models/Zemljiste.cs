using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eState.Models
{
    public class Zemljiste : Nekretnina
    {
        #region Properties
        public Boolean UrbanistickaDozvola { get; set; }
        public Boolean GradjevinskaDozvola { get; set; }
        public Boolean KomunalniPrikljucak { get; set; }
        #endregion
    }
}
