using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eStateV1.Models
{
    public class Kuca:Nekretnina
    {
        public int BrojSpratova { get; set; }
        public int BrojSoba { get; set; }
        public bool Parking { get; set; }
        public bool Namjestena { get; set; }
    }
}
