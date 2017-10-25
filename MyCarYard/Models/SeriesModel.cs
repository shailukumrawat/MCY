using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCarYard.Models
{
    public class SeriesModel
    {
        public int ser_id { get; set; }
        public int makeid { get; set; }
        public string make { get; set; }
        public int modid { get; set; }
        public string mod { get; set; }
        public int badid { get; set; }
        public string badge { get; set; }
        public string series { get; set; }
        public int status { get; set; }
        public string count { get; set; }
        public List<SeriesModel> serieslist { get; set; }
    }
}