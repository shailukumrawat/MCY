using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCarYard.Models
{
    public class CityMasterModel
    {
        public int city_id { get; set; }
        public int country_id { get; set; }
        public string country { get; set; }
        public int stateid { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public int status { get; set; }

        public List<CityMasterModel> citylist { get; set; }
    }
}