using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;


namespace eStateV1.Models
{
    public class Kuca:Nekretnina
    {
       
        [Display(Name = "Broj spratova")]
        public int BrojSpratova { get; set; }
        [Display(Name = "Broj soba")]
        public int BrojSoba { get; set; }
        public bool Parking { get; set; }
        [Display(Name = "Namještena")]
        public bool Namjestena { get; set; }


    }
}
