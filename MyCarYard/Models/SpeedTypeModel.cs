using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCarYard.Models
{
    public class SpeedTypeModel
    {
        public int speedtypeid { get; set; }
        public string speedtypename { get; set; }
        public string status { get; set; }

        public List<SpeedTypeModel> speedtypelist { get; set; }

    }
}