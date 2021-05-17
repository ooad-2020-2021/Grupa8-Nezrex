using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eState.Models
{
    public class Stan : Nekretnina
    {
        #region Properties
        [Required]
        public int BrojSprata { get; set; }
        [Required]
        public int BrojSoba { get; set; }
        [Required]
        public Boolean Parking { get; set; }
        [Required]
        public Boolean Namjesten { get; set; }
        [Required]
        public Boolean Adaptiran { get; set; }
        [Required]
        public Boolean Lift { get; set; }
        [Required]
        public Boolean Novogradnja { get; set; }
        [Required]
        public Boolean Balkon { get; set; }
        #endregion
    }
}
