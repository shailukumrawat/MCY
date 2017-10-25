using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCarYard.Models
{
    public class ListedByModel
    {
        public int listedas_id { get; set; }
        public string listed_name { get; set; }
        public string status { get; set; }

        public List<ListedByModel> listedbylist { get; set; }
    }
}