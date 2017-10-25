using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCarYard.Models
{
    public class EventCategoryModel
    {
        public int ecat_id { get; set; }
        public string category { get; set; }
        public int status { get; set; }
        public string Count { get; set; }

        public List<EventCategoryModel> categorylist { get; set; }
    }
}