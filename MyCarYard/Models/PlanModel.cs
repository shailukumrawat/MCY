using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCarYard.Models
{
    public class PlanModel
    {
        public int plan_id { get; set; }
        public string plan_name { get; set; }
        public int duration { get; set; }
        public int amnt { get; set; }
        public int status { get; set; }

        public List<PlanModel> planlist { get; set; }
    }
}