using eStateV1.WeatherModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eStateV1.Models
{
    public class WeatherModel
    {
        public List<Podaci> data { get; set; }
        public int count { get; set; }
    }
}
