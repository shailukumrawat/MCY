using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCarYard.Models
{
    public class DriveTrainModel
    {
        public int drive_id { get; set; }
        public string drive { get; set; }
        public int status { get; set; }

        public List<DriveTrainModel> drivelist { get; set; }
    }
}