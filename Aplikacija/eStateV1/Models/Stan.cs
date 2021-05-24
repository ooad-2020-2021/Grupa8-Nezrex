using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eStateV1.Models
{
    public class Stan:Nekretnina
    {
        [Display(Name = "Broj spratova")]
        public int BrojSprata { get; set; }
        [Display(Name = "Broj soba")]
        public int BrojSoba { get; set; }
        [Display(Name = "Parking")]
        public bool Parking { get; set; }
        [Display(Name = "Namješten")]
        public bool Namjesten { get; set; }
        [Display(Name = "Lift")]
        public bool Lift { get; set; }
        [Display(Name = "Novogradnja")]
        public bool Novogradnja { get; set; }
        [Display(Name = "Balkon")]
        public bool ImaBalkon { get; set; }

    }
}
