using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCarYard.Models
{
    public class NewRegionModel
    {
        public int regionid { get; set; }
        public int count_id { get; set; }
        public string country { get; set; }
        public int state_id { get; set; }
        public string state { get; set; }
        public int cityid { get; set; }
        public string city { get; set; }
        public int reas_id {get;set;}
        public string reason { get; set; }
        public string regionname { get; set; }
        public string status { get; set; }

        public List<NewRegionModel> newregionlist { get; set; }
    }
}