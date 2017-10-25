using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCarYard.Models
{
    public class InteriorMaterialModel
    {
        public int Inte_Mat_id { get; set; }
        public string Inte_Mat_name { get; set; }
        public string status { get; set; }

        public List<InteriorMaterialModel> intematlist { get; set; }
    }
}