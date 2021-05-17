using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eState.Models
{
    public enum PretragaPoVrsti
    {
        [Display(Name = "Sve")]
        SVE,
        [Display(Name = "Prodaja")]
        PRODAJA,
        [Display(Name = "Iznajmljivanje")]
        IZNAJMLJIVANJE,
        [Display(Name = "Potraznja")]
        POTRAZNJA
        
    }
}
