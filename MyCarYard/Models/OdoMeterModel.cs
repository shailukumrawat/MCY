using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCarYard.Models
{
    public class OdoMeterModel
    {
        public int odo_id { get; set; }
        public string meter { get; set; }
        public int status { get; set; }

        public List<OdoMeterModel> meterlist { get; set; }

    }
}