using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCarYard.Models
{
    public class TransmisionModel
    {
        public int trans_id { get; set; }
        public string transmision { get; set; }
        public string speedtype { get; set; }
        public int status { get; set; }
        public string count { get; set; }
        public List<TransmisionModel> translist { get; set; }
    }
}