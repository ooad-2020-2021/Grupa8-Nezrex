using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eStateV1.Models
{
    public class Slike
    {
        public int Id { get; set; }
        public string ImageBase64 { get; set; }
        public int NekretninaId { get; set; }
        [ForeignKey("NekretninaId")]
        public virtual Nekretnina slikeNekretnina { get; set; }
    }
}
