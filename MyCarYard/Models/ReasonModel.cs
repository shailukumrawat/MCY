using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCarYard.Models
{
    public class ReasonModel
    {
        public int reas_id { get; set; }
        public int count_id { get; set; }
        public string country { get; set; }
        public int state_id { get; set; }
        public string state { get; set; }
        public int cityid { get; set; }
        public string city { get; set; }
        public string reason { get; set; }
        public int status { get; set; }

        public List<ReasonModel> reasonlist { get; set; }
    }
}