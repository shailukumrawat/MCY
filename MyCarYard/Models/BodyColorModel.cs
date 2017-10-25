using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCarYard.Models
{
    public class BodyColorModel
    {
        public int body_color_id { get; set; }
        public string body_color_name { get; set; }
        public string status { get; set; }

        public List<BodyColorModel> bodycolorlist { get; set; }
    }
}