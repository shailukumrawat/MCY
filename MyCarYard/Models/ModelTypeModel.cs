using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCarYard.Models
{
    public class ModelTypeModel
    {
        public int model_id { get; set; }
        public int makeid { get; set; }
        public string make { get; set; }
        public string modeltype { get; set; }
        public int status { get; set; }
        public string count { get; set; }
        public List<ModelTypeModel> modellist { get; set; }

    }
}