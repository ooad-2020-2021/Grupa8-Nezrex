using eStateV1.Models;
using eStateV1.WeatherModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace eStateV1.Helpers
{

    public class HelperMethods 
    {

        public async Task<Podaci> GetInfoAboutWeatherInSarajevo()
        {
            using(var client = new HttpClient())
            {
                var result = await client.GetAsync("https://api.weatherbit.io/v2.0/current?city=Sarajevo&country=BA&key=98a3684db055424284f834b8e08f766a");

                var res = JsonConvert.DeserializeObject<WeatherModel>(await result.Content.ReadAsStringAsync());

                return res.data[0];
            }
        }
    }
}
