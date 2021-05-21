using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eStateV1.Models
{
    public class Stan:Nekretnina
    {
        public int BrojSprata { get; set; }
        public int BrojSoba { get; set; }
        public bool Parking { get; set; }
        public bool Namjesten { get; set; }
        public bool Lift { get; set; }
        public bool Novogradnja { get; set; }
        public bool ImaBalkon { get; set; }

    }
}
