using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCarYard.Models
{
    public class FuelModel
    {
        public int fuel_id { get; set; }
        public string fuel_name { get; set; }
        public string status { get; set; }

        public List<FuelModel> fuellist { get; set; }
    }
}