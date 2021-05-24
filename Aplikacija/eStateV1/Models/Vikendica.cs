using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eStateV1.Models
{
    public class Vikendica:Nekretnina
    {
        [Display(Name = "Broj soba")]
        public int BrojSoba { get; set; }
        [Display(Name = "Broj spratova")]
        public int BrojSpratova { get; set; }
        public bool Parking { get; set; }
        [Display(Name = "Namješten")]
        public bool Namjeseten { get; set; }

    }
}
