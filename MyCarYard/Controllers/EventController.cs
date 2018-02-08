using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCarYard.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MyCarYard.ActionHelper;

namespace MyCarYard.Controllers.EventControllers
{

    public class EventController : Controller
    {
        string constr = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        // GET: Event
        public ActionResult Index(string option = "0")
        {
            if (option == "0")
            {

                option = "CID";
            }
            //return View();            
            DataTable dt = new DataTable();
            List<EventViewModel> eventlist1 = new List<EventViewModel>();
            List<CarModel> carlist = new List<CarModel>();
            RegisterViewModel eventmodel = new RegisterViewModel();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("GetEvent", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sortby", option);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            eventlist1.Add(new EventViewModel
                            {


                                eid = ConvertHelper.Encode(dt.Rows[i]["eid"].ToString()),
                                uid = Convert.ToInt32(dt.Rows[i]["uid"].ToString()),
                                title = dt.Rows[i]["title"].ToString(),
                                subject = dt.Rows[i]["subject"].ToString(),
                                date = dt.Rows[i]["edate"].ToString(),
                                time = dt.Rows[i]["etime"].ToString(),
                                address = dt.Rows[i]["address"].ToString(),
                                cno = dt.Rows[i]["cno"].ToString(),
                                country = dt.Rows[i]["country_name"].ToString(),
                                state = dt.Rows[i]["state_name"].ToString(),
                                city = dt.Rows[i]["cityname"].ToString(),
                                descr = dt.Rows[i]["descr"].ToString(),
                                late = dt.Rows[i]["late"].ToString(),
                                lonz = dt.Rows[i]["long"].ToString(),
                                status = Convert.ToInt32(dt.Rows[i]["status"].ToString()),
                                img = dt.Rows[i]["img"].ToString(),
                                img1 = dt.Rows[i]["img1"].ToString(),
                                img2 = dt.Rows[i]["img2"].ToString(),
                                reason = dt.Rows[i]["reason"].ToString(),
                                suburb = dt.Rows[i]["regionname"].ToString(),
                                code = dt.Rows[i]["code"].ToString(),
                                unit = dt.Rows[i]["unit"].ToString(),
                                street = dt.Rows[i]["street"].ToString(),
                                sname = dt.Rows[i]["sname"].ToString(),
                                cat = Convert.ToInt32(dt.Rows[i]["cat"].ToString()),
                                create_date = Convert.ToDateTime(dt.Rows[i]["created_date"].ToString()),
                                ispaid = Convert.ToInt32(dt.Rows[i]["ispaid"].ToString()),
                                price = Convert.ToInt32(dt.Rows[i]["price"].ToString()),
                                showphone = Convert.ToInt32(dt.Rows[i]["shownumber"].ToString()),
                                going = dt.Rows[i]["going"].ToString(),
                                sponsorship = dt.Rows[i]["sponsorship"].ToString(),
                                sponsorname = dt.Rows[i]["sponsorname"].ToString()
                            });
                        }
                    }

                }
            }

            dt = new DataTable();



            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("GetCarDetails", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sortby", option);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            carlist.Add(new CarModel
                            {
                                cid = ConvertHelper.Encode(dt.Rows[i]["cid"].ToString()),
                                price = dt.Rows[i]["price"].ToString(),
                                descr = dt.Rows[i]["descr"].ToString(),
                                engine = dt.Rows[i]["ensize_name"].ToString(),
                                year = Convert.ToInt32(dt.Rows[i]["year"].ToString()),
                                cylinder = Convert.ToInt32(dt.Rows[i]["cylinder"].ToString()),
                                cylinder_name = dt.Rows[i]["cylinder_name"].ToString(),
                                img = dt.Rows[i]["img"].ToString(),
                                img1 = dt.Rows[i]["img1"].ToString(),
                                img2 = dt.Rows[i]["img2"].ToString(),
                                uid = Convert.ToInt32(dt.Rows[i]["uid"].ToString()),
                                bcolor = dt.Rows[i]["bcolor"].ToString(),
                                icolor = dt.Rows[i]["icolor"].ToString(),
                                list = dt.Rows[i]["list"].ToString(),
                                material = dt.Rows[i]["material"].ToString(),
                                body_type = dt.Rows[i]["bodytypename"].ToString(),
                                status = Convert.ToInt32(dt.Rows[i]["status"].ToString()),
                                make = dt.Rows[i]["make_type"].ToString(),
                                badge = dt.Rows[i]["badge_type"].ToString(),
                                series = dt.Rows[i]["series"].ToString(),
                                currency = dt.Rows[i]["currencyname"].ToString(),
                                model = dt.Rows[i]["model"].ToString(),
                                tranmition = dt.Rows[i]["transmision"].ToString(),
                                country = dt.Rows[i]["country_name"].ToString(),
                                state = dt.Rows[i]["state_name"].ToString(),
                                city = dt.Rows[i]["cityname"].ToString(),
                                zipcode = dt.Rows[i]["zip"].ToString(),
                                meter = dt.Rows[i]["meter"].ToString(),
                                matrics = dt.Rows[i]["odometer"].ToString(),
                                condition = dt.Rows[i]["condition"].ToString(),
                                uname = dt.Rows[i]["name"].ToString(),
                                drive = dt.Rows[i]["drive"].ToString(),
                                fuel = dt.Rows[i]["fuel"].ToString(),
                                gstatus = dt.Rows[i]["gstatus"].ToString(),
                                speedtype = dt.Rows[i]["speedtypename"].ToString(),
                                star = Convert.ToInt32(dt.Rows[i]["star"].ToString()),
                                img3 = dt.Rows[i]["img3"].ToString(),
                                img4 = dt.Rows[i]["img4"].ToString(),
                                img5 = dt.Rows[i]["img5"].ToString(),
                                created_date = dt.Rows[i]["created_date"].ToString(),
                                showphone = Convert.ToInt32(dt.Rows[i]["showphone"].ToString()),
                                cno = dt.Rows[i]["cno"].ToString(),
                                orgname = dt.Rows[i]["orgname"].ToString(),
                                suburb = dt.Rows[i]["regionname"].ToString(),
                                email = dt.Rows[i]["email"].ToString()




                            });
                        }
                    }
                }
            }

            // RegisterViewModel listmodel = new RegisterViewModel();
            List<MakeTypeModel> list = new List<MakeTypeModel>();
            con = new SqlConnection(constr);
            con.Open();
            cmd = new SqlCommand("GetMakeType", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                list.Add(new MakeTypeModel
                {
                    make_id = Convert.ToInt32(dr["make_id"].ToString()),
                    make = dr["make_type"].ToString(),
                    status = Convert.ToInt32(dr["status"].ToString())

                });
            }
            con.Close();

            eventmodel.makelist = list;
            eventmodel.carlist = carlist;
            eventmodel.eventlist = eventlist1;
            return View(eventmodel);


        }
    }
}