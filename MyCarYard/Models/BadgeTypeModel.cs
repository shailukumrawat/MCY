using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCarYard.Models
{
    public class BadgeTypeModel
    {

        public int bad_id { get; set; }
        public int makeid { get; set; }
        public string make { get; set; }
        public int modid { get; set; }
        public string mod { get; set; }

        public string badge { get; set; }
        public string count { get; set; }
        public int status { get; set; }

        public List<BadgeTypeModel> badgelist { get; set; }
    }

}