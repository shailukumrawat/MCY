using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCarYard.Models
{
    public class UserListModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public int status { get; set; }
        public string pass { get; set; }
        public int city { get; set; }
        public int state { get; set; }
        public int country { get; set; }
        public string street { get; set; }
        public string streetname { get; set; }
        public string other { get; set; }
        public string other1 { get; set; }
        public string other2 { get; set; }
        public string cno { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string gender { get; set; }
        public string zip { get; set; }
        public int regions { get; set; }
        public string suburb { get; set; }
        public string type { get; set; }
        public string late { get; set; }
        public string lonz { get; set; }
        public string regdate { get; set; }
        public string validdate { get; set; }
        public int plan_id { get; set; }
        public string orgname { get; set; }
        public string customerid { get; set; }
        public string showphone { get; set; }
        public string logo { get; set; }
        public string countryname { get; set; }
        public string statename { get; set; }
        public string resonname { get; set; }
        public string carcount { get; set; }
        public string eventcount { get; set; }

        public List<UserListModel> userlist { get; set; }
       

    }
}