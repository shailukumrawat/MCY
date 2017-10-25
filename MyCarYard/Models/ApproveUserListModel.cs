using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCarYard.Models
{
    public class ApproveUserListModel
    {
        public string cid { get; set; }
        public string listingid { get; set; }
        public int uid { get; set; }
        public string addeddate { get; set; }
        public string make { get; set; }
        public string price { get; set; }
        public string badge { get; set; }
        public string series { get; set; }
        public string currency { get; set; }
        public string descr { get; set; }
        public int year { get; set; }
        public string bcolor { get; set; }
        public string body_type { get; set; }
        public string tranmition { get; set; }
        public string list { get; set; }
        public string condition { get; set; }
        public string model { get; set; }
        public string engine { get; set; }
        public string icolor { get; set; }
        public string fuel { get; set; }
        public string img { get; set; }
        public string img1 { get; set; }
        public string img2 { get; set; }
        public int status { get; set; }
        public string country { get; set; }
        public string state { get; set; }
        public string material { get; set; }
        public string drive { get; set; }
        public int cylinder { get; set; }
        public string meter { get; set; }
        public string matrics { get; set; }
        public string uname { get; set; }
        public string gstatus { get; set; }
        public string speedtype { get; set; }
        public string img3 { get; set; }
        public string img4 { get; set; }
        public string img5 { get; set; }
        public string listype { get; set; }
        public List<EventViewModel> approveeventlist { get;  set; }

        public List<ApproveUserListModel> approveuserlist { get; set; }

    }
}