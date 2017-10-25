using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCarYard.Models
{
    public class InteriorColorModel
    {
        public int Inte_color_id { get; set; }
        public string Inte_color_name { get; set; }
        public string status { get; set; }

        public List<InteriorColorModel> interiorcolorlist { get; set; }

    }
}