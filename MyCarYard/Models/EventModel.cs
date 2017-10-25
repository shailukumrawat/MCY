using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCarYard.Models
{
    public class EventModel
    {
        
        public string eid { get; set; }
        public int uid { get; set; }
        public string title { get; set; }
        public string subject { get; set; }
        public string date {get;set;}
        public string time {get;set;}
        public string address { get; set; }
        public string cno { get; set; }
        public int country {get;set;}
        public int state {get;set;}
        public int city {get;set;}
        public string suburb { get; set; }
        public string postcode { get; set; }
        public string unit { get; set; }
        public string street { get; set; }
        public string streetname { get; set; }
        public string descr {get;set;}
        public int status {get;set;}
        public string late { get; set; }
        public string lonz { get; set; }
        public string img { get; set; }
        public string img1 { get; set; }
        public string img2 { get; set; }
        public int price { get; set; }
        public DateTime create_date { get; set; }
        public int ispaid { get; set; }
        public string category { get; set; }
        public string going { get; set; }
        public List<EventModel> eventlist { get; set; }
        public string country_name { get; set; }
        public string state_name { get; set; }
        public string city_name { get; set; }
    }
}

