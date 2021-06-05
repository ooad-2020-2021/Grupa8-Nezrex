using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eStateV1.WeatherModels
{
   public class Podaci
    {
        public double rh { get; set; }
        public string pod { get; set; }
        public double lon { get; set; }
        public double pres { get; set; }
        public string timezone { get; set; }
        public string ob_time { get; set; }
        public string country_code { get; set; }
        public double clouds { get; set; }
        public double ts { get; set; }
        public double solar_rad { get; set; }
        public string state_code { get; set; }
        public string city_name { get; set; }
        public double wind_spd { get; set; }
        public string wind_cdir_full { get; set; }
        public string wind_cdir { get; set; }
        public double slp { get; set; }
        public double vis { get; set; }
        public double h_angle { get; set; }
        public string sunset { get; set; }
        public double dni { get; set; }
        public double dewpt { get; set; }
        public double snow { get; set; }
        public double uv { get; set; }
        public double precip { get; set; }
        public double wind_dir { get; set; }
        public string sunrise { get; set; }
        public double ghi { get; set; }
        public double dhi { get; set; }
        public double aqi { get; set; }
        public double lat { get; set; }
        public Weather weather { get; set; }
        public string datetime { get; set; }
        public double temp { get; set; }
        public string station { get; set; }
        public double elev_angle { get; set; }
        public double app_temp { get; set; }
    }
}
