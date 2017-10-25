using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCarYard.Models
{
    public class BodyTypeModel
    {
        public int bodytype_id { get; set; }
        public string bodytype_name { get; set; }
        public string status { get; set; }
        public List<BodyTypeModel> bodytypelist { get; set; }
    }
}