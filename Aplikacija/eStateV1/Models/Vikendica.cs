using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eStateV1.Models
{
    public class Vikendica:Nekretnina
    {
        public int BrojSoba { get; set; }
        public int BrojSpratova { get; set; }
        public bool Parking { get; set; }
        public bool Namjeseten { get; set; }

    }
}
