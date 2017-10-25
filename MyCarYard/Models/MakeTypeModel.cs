using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCarYard.Models
{
    public class MakeTypeModel
    {
        public int make_id { get; set; }
        public string make { get; set; }
        public int status { get; set; }
        public string count { get; set; }

        public List<MakeTypeModel> makelist { get; set; }
    }
}