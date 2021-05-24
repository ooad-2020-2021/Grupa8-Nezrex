using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eStateV1.Models
{
    public class Zemljiste:Nekretnina
    {
        [Display(Name = "Urbanistička Dozvola")]
        public bool UrbanistickaDozvola { get; set; }
        [Display(Name = "Građevinska Dozvola")]
        public bool GradjevinskaDozvola { get; set; }
        [Display(Name = "Komunalni Priključak")]
        public bool KomunalniPrikljucak { get; set; }

    }
}
