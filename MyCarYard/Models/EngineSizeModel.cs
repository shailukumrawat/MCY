using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCarYard.Models
{
    public class EngineSizeModel
    {
        public int ensize_id { get; set; }   
        public int make_id { get; set; }
        public string make_type { get; set; }
        public int model_id { get; set; }
        public string model_name { get; set; }
        public int bad_id { get; set; }
        public string bad_name { get; set; }
        public int ser_id { get; set; }
        public string series_type { get; set; }
        public string ensizename { get; set; }
        public int status { get; set; }

        public List<EngineSizeModel> enginesizelist  {get;set;}
    }
}