using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCarYard.Models
{
    public class CurrencyModel
    {
        public int cur_id { get; set; }
        public int count_id { get; set; }
        public string count_name { get; set; }
        public string currency { get; set; }
        public int status { get; set; }

        public List<CurrencyModel> currencylist { get; set; }
    }
}