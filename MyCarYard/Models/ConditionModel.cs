using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCarYard.Models
{
    public class ConditionModel
    {
        public int cond_id { get; set; }
        public string condition { get; set; }
        public int status { get; set; }
        public string count { get; set; }
        public List<ConditionModel> conditionlist { get; set; }
    }
}