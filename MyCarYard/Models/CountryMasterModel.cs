using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCarYard.Models
{
    public class CountryMasterModel
    {
        public int count_id { get; set; }
        public string countryname { get; set; }
        public int status { get; set; }
        public List<CountryMasterModel> countrylist { get; set; }
        public int carcount { get; set; }
        public int eventcount { get; set; }
     }
}