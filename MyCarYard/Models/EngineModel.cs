using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCarYard.Models
{
    public class EngineModel
    {
        public int eng_id { get; set; }
        public string engine { get; set; }
        public int status { get; set; }

        public List<EngineModel> enginelist { get; set; }
    }
}