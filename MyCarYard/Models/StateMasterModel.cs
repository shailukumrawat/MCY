using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCarYard.Models
{
    public class StateMasterModel
    {
        public int state_id { get; set; }
        public int count_id { get; set; }
        public string country_name { get; set; }
        public string state { get; set; }
        public int status { get; set; }

        public List<StateMasterModel> statelist { get; set; }
    }

}