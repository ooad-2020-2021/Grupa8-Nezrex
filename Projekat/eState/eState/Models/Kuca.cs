using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eState.Models
{
    public class Kuca : Nekretnina
    {
        #region Properties
        [Required]
        public int BrojSpratova { get; set; }
        [Required]
        public int BrojSoba { get; set; }
        [Required]
        public Boolean Parking {get; set;}
        [Required]
        public Boolean Namjestena { get; set; }
        #endregion
    }
}
