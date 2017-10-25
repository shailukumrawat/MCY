using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCarYard.Models
{
    public class CylinderModel
    {

        public int cylinder_id { get; set; }
        public string cylinder_name { get; set; }
        public string status { get; set; }

        public List<CylinderModel> enginelist { get; set; }

    }
}