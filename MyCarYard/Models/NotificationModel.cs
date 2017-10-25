using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCarYard.Models
{
    public class NotificationModel
    {
        public int fromuid { get; set; }
        public int touid { get; set; }
        public string fromusername { get; set; }
        public string tousername { get; set; }
        public string edate { get; set; }
        public string msg { get; set; }
        public string status { get; set; }
        public string logo { get; set; }

        public List<NotificationModel> notificationlist { get; set; }
    }
}