using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCarYard.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.Services;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Globalization;

using System.Net.Mail;
using System.Web.Helpers;
using MyCarYard.ActionHelper;
using System.Text;
using System.Web.Hosting;

namespace MyCarYard.Controllers
{

    [ValidateInput(false)]
    public class AdminController : Controller
    {
        string constr = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        [AuthonticateUserHelper]
        public ActionResult CityMaster()
        {
            DataTable dt = new DataTable();
            List<CityMasterModel> citylist = new List<CityMasterModel>();
            CityMasterModel model = new CityMasterModel();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("GetCity", con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            citylist.Add(new CityMasterModel
                            {
                                city_id = Convert.ToInt32(dt.Rows[i]["city_id"].ToString()),
                                country_id = Convert.ToInt32(dt.Rows[i]["count_id"].ToString()),
                                country = dt.Rows[i]["country_name"].ToString(),
                                stateid = Convert.ToInt32(dt.Rows[i]["state_id"].ToString()),
                                state = dt.Rows[i]["state_name"].ToString(),
                                city = dt.Rows[i]["city"].ToString(),
                                status = Convert.ToInt32(dt.Rows[i]["status"].ToString())


                            });
                        }
                    }
                    //return objDept;
                }
            }
            model.citylist = citylist;


            return View("CityMaster", model);



            //return View();
        }
        [AuthonticateUserHelper]
        public ActionResult SeriesMaster()
        {
            DataTable dt = new DataTable();
            List<BadgeTypeModel> badgelist = new List<BadgeTypeModel>();
            BadgeTypeModel model = new BadgeTypeModel();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("GetBadge", con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            badgelist.Add(new BadgeTypeModel
                            {
                                bad_id = Convert.ToInt32(dt.Rows[i]["bad_id"].ToString()),
                                makeid = Convert.ToInt32(dt.Rows[i]["make_id"].ToString()),
                                make = dt.Rows[i]["make_type"].ToString(),
                                modid = Convert.ToInt32(dt.Rows[i]["model_id"].ToString()),
                                mod = dt.Rows[i]["model"].ToString(),
                                badge = dt.Rows[i]["badge_type"].ToString(),

                                status = Convert.ToInt32(dt.Rows[i]["status"].ToString())


                            });
                        }
                    }
                    //return objDept;
                }
            }
            model.badgelist = badgelist;

            return View(model);
        }
        [AuthonticateUserHelper]
        public ActionResult ConditionMaster()
        {

            DataTable dt = new DataTable();
            List<ConditionModel> conditionlist = new List<ConditionModel>();
            ConditionModel model = new ConditionModel();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("GetCondition", con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            conditionlist.Add(new ConditionModel
                            {
                                cond_id = Convert.ToInt32(dt.Rows[i]["cond_id"].ToString()),
                                condition = dt.Rows[i]["condition"].ToString(),
                                status = Convert.ToInt32(dt.Rows[i]["status"].ToString())
                            });
                        }
                    }

                }
            }
            model.conditionlist = conditionlist;
            return View("ConditionMaster", model);
            //return View();
        }
        [AuthonticateUserHelper]
        public ActionResult EngineMaster()
        {
            DataTable dt = new DataTable();
            List<CylinderModel> enginelist = new List<CylinderModel>();
            CylinderModel model = new CylinderModel();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("getallcylinders", con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            enginelist.Add(new CylinderModel
                            {
                                cylinder_id = Convert.ToInt32(dt.Rows[i]["cylinder_id"].ToString()),
                                cylinder_name = dt.Rows[i]["cylinder_name"].ToString(),
                                status = dt.Rows[i]["status"].ToString()
                            });
                        }
                    }

                }
            }
            model.enginelist = enginelist;
            return View("EngineMaster", model);

            //return View();

        }
        [AuthonticateUserHelper]
        public ActionResult MakeTypeMaster()
        {
            DataTable dt = new DataTable();
            List<MakeTypeModel> makelist = new List<MakeTypeModel>();
            MakeTypeModel model = new MakeTypeModel();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("GetMakeType", con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            makelist.Add(new MakeTypeModel
                            {
                                make_id = Convert.ToInt32(dt.Rows[i]["make_id"].ToString()),
                                make = dt.Rows[i]["make_type"].ToString(),
                                status = Convert.ToInt32(dt.Rows[i]["status"].ToString())
                            });
                        }
                    }

                }
            }
            model.makelist = makelist;
            return View("MakeTypeMaster", model);

            //return View();
        }
        [AuthonticateUserHelper]
        public ActionResult ModelMaster()
        {
            DataTable dt = new DataTable();
            List<ModelTypeModel> modellist = new List<ModelTypeModel>();
            ModelTypeModel model = new ModelTypeModel();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("GetModel", con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            modellist.Add(new ModelTypeModel
                            {
                                model_id = Convert.ToInt32(dt.Rows[i]["model_id"].ToString()),
                                modeltype = dt.Rows[i]["model"].ToString(),
                                makeid = Convert.ToInt32(dt.Rows[i]["make_id"].ToString()),
                                make = dt.Rows[i]["make_type"].ToString(),
                                status = Convert.ToInt32(dt.Rows[i]["status"].ToString())
                            });
                        }
                    }

                }
            }
            model.modellist = modellist;
            return View("ModelMaster", model);


            // return View();
        }
        [AuthonticateUserHelper]
        public ActionResult OdemeterMaster()
        {
            DataTable dt = new DataTable();
            List<OdoMeterModel> meterlist = new List<OdoMeterModel>();
            OdoMeterModel model = new OdoMeterModel();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("GetOdoMeter", con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            meterlist.Add(new OdoMeterModel
                            {
                                odo_id = Convert.ToInt32(dt.Rows[i]["odo_id"].ToString()),
                                meter = dt.Rows[i]["odometer"].ToString(),
                                status = Convert.ToInt32(dt.Rows[i]["status"].ToString())
                            });
                        }
                    }

                }
            }
            model.meterlist = meterlist;
            return View("OdemeterMaster", model);


            //   return View();
        }
        [AuthonticateUserHelper]
        public ActionResult SuburbMaster()
        {

            DataTable dt = new DataTable();
            List<ReasonModel> reasonlist = new List<ReasonModel>();
            ReasonModel model = new ReasonModel();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("GetReason", con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            reasonlist.Add(new ReasonModel
                            {
                                reas_id = Convert.ToInt32(dt.Rows[i]["reas_id"].ToString()),
                                count_id = Convert.ToInt32(dt.Rows[i]["count_id"].ToString()),
                                country = dt.Rows[i]["country_name"].ToString(),
                                state_id = Convert.ToInt32(dt.Rows[i]["state_id"].ToString()),
                                state = dt.Rows[i]["state_name"].ToString(),
                                cityid = Convert.ToInt32(dt.Rows[i]["city_id"].ToString()),
                                city = dt.Rows[i]["city"].ToString(),
                                reason = dt.Rows[i]["reason"].ToString(),
                                status = Convert.ToInt32(dt.Rows[i]["status"].ToString())


                            });
                        }
                    }
                    //return objDept;
                }
            }
            model.reasonlist = reasonlist;


            return View("SuburbMaster", model);



            // return View();
        }

        [AuthonticateUserHelper]
        public ActionResult NewRegionMaster()
        {

            DataTable dt = new DataTable();
            List<NewRegionModel> reasonlist = new List<NewRegionModel>();
            NewRegionModel model = new NewRegionModel();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("GetNewRegion", con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            reasonlist.Add(new NewRegionModel
                            {
                                reas_id = Convert.ToInt32(dt.Rows[i]["reas_id"].ToString()),
                                count_id = Convert.ToInt32(dt.Rows[i]["coun_id"].ToString()),
                                country = dt.Rows[i]["country_name"].ToString(),
                                state_id = Convert.ToInt32(dt.Rows[i]["state_id"].ToString()),
                                state = dt.Rows[i]["state_name"].ToString(),
                                cityid = Convert.ToInt32(dt.Rows[i]["city_id"].ToString()),
                                city = dt.Rows[i]["city"].ToString(),
                                regionid = Convert.ToInt32(dt.Rows[i]["regionid"].ToString()),
                                regionname = dt.Rows[i]["regionname"].ToString(),
                                reason = dt.Rows[i]["reason"].ToString(),
                                status = dt.Rows[i]["status"].ToString()


                            });
                        }
                    }
                    //return objDept;
                }
            }
            model.newregionlist = reasonlist;


            return View(model);



            // return View();
        }

        [AuthonticateUserHelper]
        public ActionResult BadgeType()
        {
            DataTable dt = new DataTable();
            List<SeriesModel> serieslist = new List<SeriesModel>();
            SeriesModel model = new SeriesModel();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("GetSeries", con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            serieslist.Add(new SeriesModel
                            {
                                ser_id = Convert.ToInt32(dt.Rows[i]["ser_id"].ToString()),
                                makeid = Convert.ToInt32(dt.Rows[i]["make_id"].ToString()),
                                make = dt.Rows[i]["make_type"].ToString(),
                                modid = Convert.ToInt32(dt.Rows[i]["model_id"].ToString()),
                                mod = dt.Rows[i]["model"].ToString(),
                                badid = Convert.ToInt32(dt.Rows[i]["bad_id"].ToString()),
                                badge = dt.Rows[i]["badge_type"].ToString(),
                                series = dt.Rows[i]["series_type"].ToString(),
                                status = Convert.ToInt32(dt.Rows[i]["status"].ToString())
                            });
                        }
                    }
                    //return objDept;
                }
            }
            model.serieslist = serieslist;
            return View(model);
            // return View();
        }

        [AuthonticateUserHelper]
        public ActionResult EngineSizeMaster()
        {
            DataTable dt = new DataTable();
            List<EngineSizeModel> serieslist = new List<EngineSizeModel>();
            EngineSizeModel model = new EngineSizeModel();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("GetEngineSize", con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            serieslist.Add(new EngineSizeModel
                            {
                                ensize_id = Convert.ToInt32(dt.Rows[i]["ensize_id"].ToString()),
                                ser_id = Convert.ToInt32(dt.Rows[i]["ser_id"].ToString()),
                                make_id = Convert.ToInt32(dt.Rows[i]["make_id"].ToString()),
                                make_type = dt.Rows[i]["make_type"].ToString(),
                                model_id = Convert.ToInt32(dt.Rows[i]["model_id"].ToString()),
                                model_name = dt.Rows[i]["model"].ToString(),
                                bad_id = Convert.ToInt32(dt.Rows[i]["bad_id"].ToString()),
                                bad_name = dt.Rows[i]["badge_type"].ToString(),
                                series_type = dt.Rows[i]["series_type"].ToString(),
                                ensizename = dt.Rows[i]["ensize_name"].ToString(),
                                status = Convert.ToInt32(dt.Rows[i]["status"].ToString())
                            });
                        }
                    }
                    //return objDept;
                }
            }
            model.enginesizelist = serieslist;
            return View(model);
            // return View();
        }

        [AuthonticateUserHelper]
        public ActionResult TransmisionMaster()
        {
            DataTable dt = new DataTable();
            List<TransmisionModel> translist = new List<TransmisionModel>();
            TransmisionModel model = new TransmisionModel();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("GetTransmision", con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            translist.Add(new TransmisionModel
                            {
                                trans_id = Convert.ToInt32(dt.Rows[i]["trans_id"].ToString()),
                                transmision = dt.Rows[i]["transmision"].ToString(),
                                status = Convert.ToInt32(dt.Rows[i]["status"].ToString())
                            });
                        }
                    }

                }
            }
            model.translist = translist;
            return View("TransmisionMaster", model);

            //return View();
        }

        [AuthonticateUserHelper]
        public ActionResult SpeedTypeMaster()
        {
            DataTable dt = new DataTable();
            List<SpeedTypeModel> translist = new List<SpeedTypeModel>();
            SpeedTypeModel model = new SpeedTypeModel();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("GetSpeedType", con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            translist.Add(new SpeedTypeModel
                            {
                                speedtypeid = Convert.ToInt32(dt.Rows[i]["speedtypeid"].ToString()),
                                speedtypename = dt.Rows[i]["speedtypename"].ToString(),
                                status = dt.Rows[i]["status"].ToString()
                            });
                        }
                    }

                }
            }
            model.speedtypelist = translist;
            return View(model);

            //return View();
        }

        [AuthonticateUserHelper]
        public ActionResult DriveTrainMaster()
        {
            DataTable dt = new DataTable();
            List<DriveTrainModel> drivelist = new List<DriveTrainModel>();
            DriveTrainModel model = new DriveTrainModel();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("GetDrive", con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            drivelist.Add(new DriveTrainModel
                            {
                                drive_id = Convert.ToInt32(dt.Rows[i]["driv_id"].ToString()),
                                drive = dt.Rows[i]["drive"].ToString(),
                                status = Convert.ToInt32(dt.Rows[i]["status"].ToString())
                            });
                        }
                    }

                }
            }
            model.drivelist = drivelist;
            return View("DriveTrainMaster", model);

            // return View();
        }

        [AuthonticateUserHelper]
        public ActionResult BodyTypeMaster()
        {

            BodyTypeModel model = new BodyTypeModel();

            DataTable dt = new DataTable();
            List<BodyTypeModel> bodytypelist = new List<BodyTypeModel>();

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("GetBodyType", con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            bodytypelist.Add(new BodyTypeModel
                            {
                                bodytype_id = Convert.ToInt32(dt.Rows[i]["body_type_id"].ToString()),
                                bodytype_name = dt.Rows[i]["body_type"].ToString(),
                                status = dt.Rows[i]["status"].ToString()
                            });
                        }
                    }

                }
            }
            model.bodytypelist = bodytypelist;

            return View(model);
        }
        [AuthonticateUserHelper]
        public ActionResult ListedMaster()
        {

            List<ListedByModel> listedbylist = new List<ListedByModel>();
            ListedByModel model = new ListedByModel();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("GetListedAs", con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            listedbylist.Add(new ListedByModel
                            {
                                listedas_id = Convert.ToInt32(dt.Rows[i]["listed_id"].ToString()),
                                listed_name = dt.Rows[i]["listed_name"].ToString(),
                                status = dt.Rows[i]["status"].ToString()
                            });
                        }
                    }

                }
            }
            model.listedbylist = listedbylist;

            return View(model);
        }

        [AuthonticateUserHelper]
        public ActionResult BodyColorMaster()
        {

            BodyColorModel model = new BodyColorModel();
            List<BodyColorModel> bodycolorlist = new List<Models.BodyColorModel>();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("GetBodyColor", con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            bodycolorlist.Add(new BodyColorModel
                            {
                                body_color_id = Convert.ToInt32(dt.Rows[i]["body_color_id"].ToString()),
                                body_color_name = dt.Rows[i]["body_color_name"].ToString(),
                                status = dt.Rows[i]["status"].ToString()
                            });
                        }
                    }

                }
            }
            model.bodycolorlist = bodycolorlist;

            return View(model);
        }

        [AuthonticateUserHelper]
        public ActionResult InteriorColorMaster()
        {

            InteriorColorModel model = new InteriorColorModel();
            List<InteriorColorModel> intecolorlist = new List<InteriorColorModel>();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("GetInteriorColor", con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            intecolorlist.Add(new InteriorColorModel
                            {
                                Inte_color_id = Convert.ToInt32(dt.Rows[i]["inter_color_id"].ToString()),
                                Inte_color_name = dt.Rows[i]["inter_color_name"].ToString(),
                                status = dt.Rows[i]["status"].ToString()
                            });
                        }
                    }

                }
            }
            model.interiorcolorlist = intecolorlist;
            return View(model);
        }

        [AuthonticateUserHelper]
        public ActionResult InteriorMaterialMaster()
        {

            InteriorMaterialModel model = new InteriorMaterialModel();
            List<InteriorMaterialModel> intematlist = new List<InteriorMaterialModel>();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("GetInteriorMaterial", con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            intematlist.Add(new InteriorMaterialModel
                            {
                                Inte_Mat_id = Convert.ToInt32(dt.Rows[i]["inter_mat_id"].ToString()),
                                Inte_Mat_name = dt.Rows[i]["inter_Mat_name"].ToString(),
                                status = dt.Rows[i]["status"].ToString()
                            });
                        }
                    }

                }
            }
            model.intematlist = intematlist;
            return View(model);
        }

        [AuthonticateUserHelper]
        public ActionResult FuelMaster()
        {

            FuelModel model = new FuelModel();
            List<FuelModel> fuellist = new List<FuelModel>();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("GetFuel", con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            fuellist.Add(new FuelModel
                            {
                                fuel_id = Convert.ToInt32(dt.Rows[i]["fuel_id"].ToString()),
                                fuel_name = dt.Rows[i]["fuel_name"].ToString(),
                                status = dt.Rows[i]["status"].ToString()
                            });
                        }
                    }

                }
            }
            model.fuellist = fuellist;
            return View(model);
        }

        [HttpGet]
        [AuthonticateUserHelper]
        public ActionResult EditCustomer(string custid)
        {

            custid = ConvertHelper.Decode(custid);
            UserListModel model = new UserListModel();
            con = new SqlConnection(constr);
            SqlCommand com = new SqlCommand("UserDetails", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            com.Parameters.AddWithValue("@id", custid);
            da.Fill(dt);
            con.Close();

            if (dt.Rows.Count > 0)
            {

                model = new UserListModel
                {
                    plan_id = Convert.ToInt32(dt.Rows[0]["plan_id"].ToString()),
                    id = dt.Rows[0]["id"].ToString(),
                    fname = dt.Rows[0]["fname"].ToString(),
                    lname = dt.Rows[0]["lname"].ToString(),
                    city = Convert.ToInt32(dt.Rows[0]["city"].ToString()),
                    state = Convert.ToInt32(dt.Rows[0]["state"].ToString()),
                    country = Convert.ToInt32(dt.Rows[0]["country"].ToString()),
                    regions = Convert.ToInt32(dt.Rows[0]["regions"].ToString()),
                    //suburb = dt.Rows[0]["suburb"].ToString(),
                    zip = dt.Rows[0]["zip"].ToString(),
                    other = dt.Rows[0]["other"].ToString(),
                    other1 = dt.Rows[0]["other1"].ToString(),
                    other2 = dt.Rows[0]["other2"].ToString(),
                    gender = dt.Rows[0]["gender"].ToString(),
                    cno = dt.Rows[0]["cno"].ToString(),
                    street = dt.Rows[0]["street"].ToString(),
                    streetname = dt.Rows[0]["streetname"].ToString(),
                    late = dt.Rows[0]["late"].ToString(),
                    lonz = dt.Rows[0]["long"].ToString(),
                    email = dt.Rows[0]["email"].ToString(),
                    name = dt.Rows[0]["name"].ToString(),
                    type = dt.Rows[0]["type"].ToString(),
                    pass = dt.Rows[0]["pass"].ToString(),
                    status = Convert.ToInt32(dt.Rows[0]["status"].ToString()),
                    regdate = Convert.ToDateTime(dt.Rows[0]["reg_date"].ToString()).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    validdate = Convert.ToDateTime(dt.Rows[0]["valid_date"].ToString()).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    orgname = dt.Rows[0]["orgname"].ToString(),
                    customerid = dt.Rows[0]["cust_id"].ToString(),
                    logo = dt.Rows[0]["buslogo"].ToString()
                };

            }

            return View(model);
        }

        [HttpGet]
        [AuthonticateUserHelper]
        public ActionResult AdminProfile(int custid)
        {

            UserListModel model = new UserListModel();
            con = new SqlConnection(constr);
            SqlCommand com = new SqlCommand("UserDetails", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            com.Parameters.AddWithValue("@id", custid);
            da.Fill(dt);
            con.Close();

            if (dt.Rows.Count > 0)
            {

                model = new UserListModel
                {
                    plan_id = Convert.ToInt32(dt.Rows[0]["plan_id"].ToString()),
                    id = dt.Rows[0]["id"].ToString(),
                    fname = dt.Rows[0]["fname"].ToString(),
                    lname = dt.Rows[0]["lname"].ToString(),
                    city = Convert.ToInt32(dt.Rows[0]["city"].ToString()),
                    state = Convert.ToInt32(dt.Rows[0]["state"].ToString()),
                    country = Convert.ToInt32(dt.Rows[0]["country"].ToString()),
                    regions = Convert.ToInt32(dt.Rows[0]["regions"].ToString()),
                    suburb = dt.Rows[0]["suburb"].ToString(),
                    zip = dt.Rows[0]["zip"].ToString(),
                    other = dt.Rows[0]["other"].ToString(),
                    other1 = dt.Rows[0]["other1"].ToString(),
                    other2 = dt.Rows[0]["other2"].ToString(),
                    gender = dt.Rows[0]["gender"].ToString(),
                    cno = dt.Rows[0]["cno"].ToString(),
                    street = dt.Rows[0]["street"].ToString(),
                    streetname = dt.Rows[0]["streetname"].ToString(),
                    late = dt.Rows[0]["late"].ToString(),
                    lonz = dt.Rows[0]["long"].ToString(),
                    email = dt.Rows[0]["email"].ToString(),
                    name = dt.Rows[0]["name"].ToString(),
                    type = dt.Rows[0]["type"].ToString(),
                    pass = dt.Rows[0]["pass"].ToString(),
                    status = Convert.ToInt32(dt.Rows[0]["status"].ToString()),
                    regdate = Convert.ToDateTime(dt.Rows[0]["reg_date"].ToString()).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    validdate = Convert.ToDateTime(dt.Rows[0]["valid_date"].ToString()).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    orgname = dt.Rows[0]["orgname"].ToString(),
                    customerid = dt.Rows[0]["cust_id"].ToString()
                };

            }

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject AddCondition(string condition, int status)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("AddCondition", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@condition", condition);
            com.Parameters.AddWithValue("@status", status);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;
        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject UpdateCondition(int conditionid, string condition, int status)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("UpdateCondition", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@conditionid", conditionid);
            com.Parameters.AddWithValue("@condition", condition);
            com.Parameters.AddWithValue("@status", status);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;
        }


        [HttpPost]
        [AllowAnonymous]
        public JObject checkloginFb(string facebookId)
        {

            con = new SqlConnection(constr);
            JObject json = new JObject();
            con.Open();
            cmd = new SqlCommand("Select email,pass from tbl_login where facebookId='" + facebookId + "'", con);
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);

            if (dt.Rows.Count > 0)
            {
                AccountController _objAC = new AccountController();
                LoginViewModel _objVM = new LoginViewModel();
                json["status"] = "Success";
                json["email"] = dt.Rows[0]["email"].ToString(); _objVM.Email = dt.Rows[0]["email"].ToString();
                json["password"] = dt.Rows[0]["pass"].ToString(); _objVM.Password = dt.Rows[0]["pass"].ToString();
                _objVM.RememberMe = false;
                _objAC.Login(_objVM, "");
                json["status"] = "Success";
            }
            else
            {
                json["status"] = "Invalid";
            }

            return json;
        }
        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        public JObject checklogin(string unm, string pass)
        {

            con = new SqlConnection(constr);
            JObject json = new JObject();
            con.Open();
            cmd = new SqlCommand("Select * from tbl_login where email='" + unm + "' and pass='" + pass + "'", con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                json["status"] = "Success";
            }
            else
            {
                json["status"] = "Invalid";
            }

            return json;
        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject DeleteCondition(int conditionid)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("DeleteCondition", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@conditionid", conditionid);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;
        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject AddCity(int country, int state, string city, int status)
        {
            JObject json = new JObject();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("AddCity", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@count_id", country);
                    cmd.Parameters.AddWithValue("@state_id", state);
                    cmd.Parameters.AddWithValue("@city", city);
                    cmd.Parameters.AddWithValue("@status", status);
                    con.Open();
                    json["status"] = cmd.ExecuteScalar().ToString();
                    con.Close();
                }
            }
            return json;
        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject UpdateCity(int cityid, int country, int state, string city, int status)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("UpdateCity", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@cityid", cityid);
            com.Parameters.AddWithValue("@count_id", country);
            com.Parameters.AddWithValue("@state_id", state);
            com.Parameters.AddWithValue("@city", city);
            com.Parameters.AddWithValue("@status", status);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;
        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject DeleteCity(int cityid)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("DeleteCity", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@cityid", cityid);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;
        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]

        // Added by ravikant sonare 16/05/2017

        public JObject AddRegions(int country, int state, int city, string reason, int status)
        {
            JObject json = new JObject();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("AddRegions", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@count_id", country);
                    cmd.Parameters.AddWithValue("@state_id", state);
                    cmd.Parameters.AddWithValue("@city_id", city);
                    cmd.Parameters.AddWithValue("@region", reason);
                    cmd.Parameters.AddWithValue("@status", status);
                    con.Open();
                    json["status"] = Convert.ToString(cmd.ExecuteScalar());
                    con.Close();
                }
            }
            return json;
        }
        public JObject AddReason(int country, int state, int city, string reason, int status)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("AddReason", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@count_id", country);
            com.Parameters.AddWithValue("@state_id", state);
            com.Parameters.AddWithValue("@city_id", city);
            com.Parameters.AddWithValue("@reason", reason);
            com.Parameters.AddWithValue("@status", status);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;
        }
        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject AddRegion(int country, int state, int city, string suburb, string reason, int status)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("AddRegion", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@count_id", country);
            com.Parameters.AddWithValue("@state_id", state);
            com.Parameters.AddWithValue("@city_id", city);
            com.Parameters.AddWithValue("@suburb", suburb);
            com.Parameters.AddWithValue("@region", reason);
            com.Parameters.AddWithValue("@status", status);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;
        }


        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject UpdateReason(int regionid, int country, int state, int city, string reason, int status)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("UpdateReason", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@regionid", regionid);
            com.Parameters.AddWithValue("@count_id", country);
            com.Parameters.AddWithValue("@state_id", state);
            com.Parameters.AddWithValue("@city_id", city);
            com.Parameters.AddWithValue("@reason", reason);
            com.Parameters.AddWithValue("@status", status);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;
        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject DeleteReason(int reas_id)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("DeleteReason", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@regionid", reas_id);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;
        }





        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject UpdateRegion(int regionid, int country, int state, int city, int suburb, string region, int status)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("UpdateRegion", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@regionid", regionid);
            com.Parameters.AddWithValue("@count_id", country);
            com.Parameters.AddWithValue("@state_id", state);
            com.Parameters.AddWithValue("@city_id", city);
            com.Parameters.AddWithValue("@suburb", suburb);
            com.Parameters.AddWithValue("@region", region);
            com.Parameters.AddWithValue("@status", status);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;
        }


        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject DeleteRegion(int regionid)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("DeleteRegion", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@regionid", regionid);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;
        }


        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject AddEngine(string engine, int status)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("AddCylinder", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@cylinder", engine);
            com.Parameters.AddWithValue("@status", status);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;
        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject UpdateEngine(int cylinderid, string engine, int status)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("UpdateCylinder", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@cylinderid", cylinderid);
            com.Parameters.AddWithValue("@cylinder", engine);
            com.Parameters.AddWithValue("@status", status);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;
        }


        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject DeleteEngine(int cylinderid)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("DeleteCylinder", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@cylinderid", cylinderid);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;
        }


        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject AddTransmision(string trans, int status)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("AddTransmision", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@transmision", trans);

            com.Parameters.AddWithValue("@status", status);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;
        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject UpdateTransmision(int transid, string trans, int status)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("UpdateTransmision", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@transid", transid);
            com.Parameters.AddWithValue("@transmision", trans);

            com.Parameters.AddWithValue("@status", status);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;
        }



        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject AddSpeedType(string speedtypename, int status)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("AddSpeedType", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@speedtype", speedtypename);
            com.Parameters.AddWithValue("@status", status);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;
        }
        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject UpdateSpeedtype(int speedtypeid, string speedtypename, int status)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("UpdateSpeedType", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@speedtypeid", speedtypeid);
            com.Parameters.AddWithValue("@speedtypename", speedtypename);
            com.Parameters.AddWithValue("@status", status);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;
        }


        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject DeleteTransmision(int transid)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("DeleteTransmision", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@transid", transid);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;
        }



        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject DeleteSpeedType(int speedtypeid)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("DeleteSpeedtype", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@speedtypeid", speedtypeid);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;
        }
        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject AddFuel(string fuelname, string status)
        {

            JObject json = new JObject();
            con = new SqlConnection(constr);
            con.Open();
            cmd = new SqlCommand("InsertFuelMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fuelname", fuelname);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.ExecuteNonQuery();
            json["status"] = "Success";
            con.Close();
            return json;
        }


        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject UpdateFuel(int fuelid, string fuelname, string status)
        {

            JObject json = new JObject();
            con = new SqlConnection(constr);
            con.Open();
            cmd = new SqlCommand("UpdateFuelMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fuelid", fuelid);
            cmd.Parameters.AddWithValue("@fuelname", fuelname);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.ExecuteNonQuery();
            json["status"] = "Success";
            con.Close();
            return json;
        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject DeleteFuel(int fuelid)
        {

            JObject json = new JObject();
            con = new SqlConnection(constr);
            con.Open();
            cmd = new SqlCommand("DeleteFuelMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fuelid", fuelid);
            cmd.ExecuteNonQuery();
            json["status"] = "Success";
            con.Close();
            return json;
        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject AddMeter(string meter, int status)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("AddOdometer", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@meter", meter);
            com.Parameters.AddWithValue("@status", status);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;
        }


        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject UpdateMeter(int meterid, string meter, int status)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("UpdateOdometer", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@meterid", meterid);
            com.Parameters.AddWithValue("@meter", meter);
            com.Parameters.AddWithValue("@status", status);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;
        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject DeleteMeter(int meterid)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("DeleteOdometer", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@meterid", meterid);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;
        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject AddCurrency(string currency, int count_id, int status)
        {
            con = new SqlConnection(constr);
            con.Open();
            JObject json = new JObject();
            SqlParameter[] sqlparam = new SqlParameter[4];
            SqlCommand com = new SqlCommand("InsertCurrency", con);
            com.CommandType = CommandType.StoredProcedure;
            sqlparam[0] = new SqlParameter("@currency", SqlDbType.NVarChar, 200);
            sqlparam[0].Value = currency;
            sqlparam[1] = new SqlParameter("@count_id", SqlDbType.Int);
            sqlparam[1].Value = count_id;
            sqlparam[2] = new SqlParameter("@status", SqlDbType.Int);
            sqlparam[2].Value = status;
            sqlparam[3] = new SqlParameter("@errormessage", SqlDbType.NVarChar, 200);
            sqlparam[3].Direction = ParameterDirection.Output;
            com.Parameters.AddRange(sqlparam);

            com.ExecuteNonQuery();

            string errormessage = sqlparam[3].Value.ToString();

            if (errormessage == "0")
            {
                json["status"] = "Success";
            }
            else
            {
                json["status"] = errormessage;
            }

            con.Close();

            return json;
        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject UpdateCurrency(int curid, string currency, int count_id, string status)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("[UpdateCurrency]", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@cur_id", curid);
            com.Parameters.AddWithValue("@currency", currency);
            com.Parameters.AddWithValue("@status", status);
            com.Parameters.AddWithValue("@count_id", count_id);

            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;
        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject DeleteCurrency(int curid)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("[DeleteCurrency]", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@cur_id", curid);

            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;
        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject AddCategory(string category, int status)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("InsertEventCategory", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@category", category);
            com.Parameters.AddWithValue("@status", status);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;
        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject UpdateCategory(int catid, string category, int status)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("UpdateEventCategoryNew", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@catid", catid);
            com.Parameters.AddWithValue("@category", category);
            com.Parameters.AddWithValue("@status", status);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;
        }


        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject DeleteCategory(int catid)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("DeleteEventCategoryNew", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@catid", catid);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;
        }




        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject AddDriveTrain(string drive, int status)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("AddDriveTrain", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@drive", drive);
            com.Parameters.AddWithValue("@status", status);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;
        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject UpdateDriveTrain(int drivetid, string drive, string status)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("UpdateDriveTrain", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@drivetid", drivetid);
            com.Parameters.AddWithValue("@drive", drive);
            com.Parameters.AddWithValue("@status", status);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;
        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject DeleteDriveTrain(int drivetid)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("DeleteDriveTrain", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@drivetid", drivetid);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;
        }


        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject AddMake(string make, int status)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("AddMakeType", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@make", make);
            com.Parameters.AddWithValue("@status", status);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;
        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject UpdateMake(int makeid, string make, int status)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("UpdateMakeType", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@makeid", makeid);
            com.Parameters.AddWithValue("@make", make);
            com.Parameters.AddWithValue("@status", status);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;
        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject DeleteMake(int makeid)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("DeleteMakeType", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@makeid", makeid);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;
        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject AddModel(int make, string model, int status)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("AddModel", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@make_id", make);
            com.Parameters.AddWithValue("@model", model);
            com.Parameters.AddWithValue("@status", status);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;
        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject UpdateModel(int modelid, int make, string model, int status)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("UpdateModel", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@modelid", modelid);
            com.Parameters.AddWithValue("@make_id", make);
            com.Parameters.AddWithValue("@model", model);
            com.Parameters.AddWithValue("@status", status);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;
        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject DeleteModel(int modelid)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("DeleteModel", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@modelid", modelid);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;
        }


        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject AddBadge(int make, int model, string badge, int status)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("AddBadgeType", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@make_id", make);
            com.Parameters.AddWithValue("@model_id", model);
            com.Parameters.AddWithValue("@badge", badge);
            com.Parameters.AddWithValue("@status", status);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;
        }


        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject UpdateBadge(int badid, int make, int model, string badge, int status)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("UpdateBadgeType", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@badid", badid);
            com.Parameters.AddWithValue("@make_id", make);
            com.Parameters.AddWithValue("@model_id", model);
            com.Parameters.AddWithValue("@badge", badge);
            com.Parameters.AddWithValue("@status", status);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;
        }


        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject DeleteBadge(int badid)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("DeleteBadgeType", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@badid", badid);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;
        }


        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject AddSeries(int make, int model, int badge, string series, int status)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("AddSeriesType", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@make_id", make);
            com.Parameters.AddWithValue("@model_id", model);
            com.Parameters.AddWithValue("@bad_id", badge);
            com.Parameters.AddWithValue("@series", series);
            com.Parameters.AddWithValue("@status", status);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;
        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject AddEngineSize(int make, int model, int badge, int series, string engsize, int status)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("AddEngineSize", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@make_id", make);
            com.Parameters.AddWithValue("@model_id", model);
            com.Parameters.AddWithValue("@bad_id", badge);
            com.Parameters.AddWithValue("@series", series);
            com.Parameters.AddWithValue("@engsize", engsize);
            com.Parameters.AddWithValue("@status", status);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;
        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject UpdateSeries(int serid, int make, int model, int badge, string series, int status)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("UpdateSeriesType", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@serid", serid);
            com.Parameters.AddWithValue("@make_id", make);
            com.Parameters.AddWithValue("@model_id", model);
            com.Parameters.AddWithValue("@bad_id", badge);
            com.Parameters.AddWithValue("@series", series);
            com.Parameters.AddWithValue("@status", status);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;
        }


        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject DeleteSeries(int serid)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("DeleteSeriesType", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@serid", serid);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;
        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject UpdateEngineSizeMaster(int engsizeid, int make, int model, int badge, int series, string engsize, int status)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("UpdateEngineSizeMaster", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@engsizeid", engsizeid);
            com.Parameters.AddWithValue("@serid", series);
            com.Parameters.AddWithValue("@make_id", make);
            com.Parameters.AddWithValue("@model_id", model);
            com.Parameters.AddWithValue("@bad_id", badge);
            com.Parameters.AddWithValue("@engsize", engsize);
            com.Parameters.AddWithValue("@status", status);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;
        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject DeleteEngineSizeMaster(int engsizeid)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("DeleteEngineSizeMaster", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@engsizeid", engsizeid);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;
        }


        [HttpPost]
        [WebMethod]

        public JObject LoadMake()
        {
            con = new SqlConnection(constr);
            List<MakeTypeModel> makelist = new List<MakeTypeModel>();
            JObject json = new JObject();
            SqlCommand cmd = new SqlCommand("GetMakeType", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                makelist.Add(
                    new MakeTypeModel
                    {
                        make_id = Convert.ToInt32(dr["make_id"].ToString()),
                        make = dr["make_type"].ToString(),
                        status = Convert.ToInt32(dr["status"].ToString())
                    });
            }
            json["makelist"] = JToken.FromObject(makelist);
            return json;
        }


        [HttpPost]
        [WebMethod]
        public JObject LoadMakeWithCount()
        {
            con = new SqlConnection(constr);
            List<MakeTypeModel> makelist = new List<MakeTypeModel>();
            JObject json = new JObject();
            SqlCommand cmd = new SqlCommand("GetMakeTypeWithCount", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                makelist.Add(
                    new MakeTypeModel
                    {
                        make_id = Convert.ToInt32(dr["make_id"].ToString()),
                        make = dr["make_type"].ToString(),
                        status = Convert.ToInt32(dr["status"].ToString()),
                        count = dr["makecount"].ToString()
                    });
            }
            json["makelist"] = JToken.FromObject(makelist);
            return json;
        }

        [HttpPost]
        [WebMethod]
        public JObject LoadModel(int make)
        {
            con = new SqlConnection(constr);
            List<ModelTypeModel> modellist = new List<ModelTypeModel>();
            JObject json = new JObject();
            SqlCommand cmd = new SqlCommand("GetModelDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            cmd.Parameters.AddWithValue("@make_id", make);
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                modellist.Add(
                    new ModelTypeModel
                    {
                        model_id = Convert.ToInt32(dr["model_id"].ToString()),

                        modeltype = dr["model"].ToString(),
                        status = Convert.ToInt32(dr["status"].ToString())
                    });
            }
            json["modellist"] = JToken.FromObject(modellist);
            return json;
        }


        [HttpPost]
        [WebMethod]
        public JObject LoadModelWithCount(string[] make)
        {
            con = new SqlConnection(constr);
            List<ModelTypeModel> modellist = new List<ModelTypeModel>();
            JObject json = new JObject();
            SqlCommand cmd = new SqlCommand("GetModelDetailsWithCount", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            //cmd.Parameters.AddWithValue("@make_id", make);
            cmd.Parameters.Add("@List", SqlDbType.VarChar).Value = make[0];
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                modellist.Add(
                    new ModelTypeModel
                    {
                        model_id = Convert.ToInt32(dr["model_id"].ToString()),
                        modeltype = dr["model"].ToString(),
                        status = Convert.ToInt32(dr["status"].ToString()),
                        count = dr["modelcount"].ToString(),
                        make = dr["make_type"].ToString()
                    });
            }
            json["modellist"] = JToken.FromObject(modellist);
            return json;
        }

        [HttpPost]

        [WebMethod]
        public JObject LoadBadge(int make, int model)
        {
            con = new SqlConnection(constr);
            List<BadgeTypeModel> badgelist = new List<BadgeTypeModel>();
            JObject json = new JObject();
            SqlCommand cmd = new SqlCommand("GetBadgeDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            cmd.Parameters.AddWithValue("@make_id", make);
            cmd.Parameters.AddWithValue("@model_id", model);
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                badgelist.Add(
                    new BadgeTypeModel
                    {
                        bad_id = Convert.ToInt32(dr["bad_id"].ToString()),

                        badge = dr["badge_type"].ToString(),
                        status = Convert.ToInt32(dr["status"].ToString())
                    });
            }
            json["badgelist"] = JToken.FromObject(badgelist);
            return json;
        }

        [HttpPost]

        [WebMethod]
        public JObject LoadBadgeWithCount(string[] model)
        {
            con = new SqlConnection(constr);
            List<BadgeTypeModel> badgelist = new List<BadgeTypeModel>();
            JObject json = new JObject();
            SqlCommand cmd = new SqlCommand("GetBadgeDetailsWithCount", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            //cmd.Parameters.AddWithValue("@make_id", make);
            cmd.Parameters.AddWithValue("@List", model[0]);
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                badgelist.Add(
                    new BadgeTypeModel
                    {
                        bad_id = Convert.ToInt32(dr["bad_id"].ToString()),

                        badge = dr["badge_type"].ToString(),
                        status = Convert.ToInt32(dr["status"].ToString()),
                        count = dr["badgecount"].ToString(),
                        make = dr["make_type"].ToString(),
                        mod = dr["model"].ToString()
                    });
            }
            json["badgelist"] = JToken.FromObject(badgelist);
            return json;
        }


        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        public JObject LoadCity(int country, int state)
        {
            con = new SqlConnection(constr);
            List<CityMasterModel> citylist = new List<CityMasterModel>();
            JObject json = new JObject();
            SqlCommand cmd = new SqlCommand("GetCityDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            cmd.Parameters.AddWithValue("@count_id", country);
            cmd.Parameters.AddWithValue("@state_id", state);
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                citylist.Add(
                    new CityMasterModel
                    {
                        city_id = Convert.ToInt32(dr["city_id"].ToString()),

                        city = dr["city"].ToString(),
                        status = Convert.ToInt32(dr["status"].ToString())
                    });
            }
            json["citylist"] = JToken.FromObject(citylist);
            return json;
        }


        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        public JObject Loadsuburb(int country, int state, int city)
        {
            con = new SqlConnection(constr);
            List<ReasonModel> citylist = new List<ReasonModel>();
            JObject json = new JObject();
            SqlCommand cmd = new SqlCommand("GetSuburbDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            cmd.Parameters.AddWithValue("@count_id", country);
            cmd.Parameters.AddWithValue("@state_id", state);
            cmd.Parameters.AddWithValue("@city_id", city);
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                citylist.Add(
                    new ReasonModel
                    {
                        cityid = Convert.ToInt32(dr["city_id"].ToString()),
                        reas_id = Convert.ToInt32(dr["reas_id"].ToString()),
                        reason = dr["reason"].ToString(),
                        //city = dr["city"].ToString(),
                        status = Convert.ToInt32(dr["status"].ToString())
                    });
            }
            json["suburblist"] = JToken.FromObject(citylist);
            return json;
        }


        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        public JObject LoadRegion(int country, int state, int city)
        {
            con = new SqlConnection(constr);
            List<ReasonModel> citylist = new List<ReasonModel>();
            JObject json = new JObject();
            SqlCommand cmd = new SqlCommand("GetReasonDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            cmd.Parameters.AddWithValue("@count_id", country);
            cmd.Parameters.AddWithValue("@state_id", state);
            cmd.Parameters.AddWithValue("@city_id", city);
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                citylist.Add(
                    new ReasonModel
                    {
                        reas_id = Convert.ToInt32(dr["reas_id"].ToString()),
                        reason = dr["reason"].ToString(),
                        status = Convert.ToInt32(dr["status"].ToString())

                    });
            }
            json["regionlist"] = JToken.FromObject(citylist);
            return json;
        }


        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        public JObject LoadNewRegion(int country, int state, int city, int region)
        {
            con = new SqlConnection(constr);
            List<NewRegionModel> citylist = new List<NewRegionModel>();
            JObject json = new JObject();
            SqlCommand cmd = new SqlCommand("GetNewRegionDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            cmd.Parameters.AddWithValue("@count_id", country);
            cmd.Parameters.AddWithValue("@state_id", state);
            cmd.Parameters.AddWithValue("@city_id", city);
            cmd.Parameters.AddWithValue("@region", region);
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                citylist.Add(
                    new NewRegionModel
                    {
                        regionid = Convert.ToInt32(dr["regionid"].ToString()),
                        regionname = dr["regionname"].ToString(),
                        status = dr["status"].ToString()

                    });
            }
            json["newregionlist"] = JToken.FromObject(citylist);
            return json;
        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        public JObject LoadReason(int country, int state, int city)
        {
            con = new SqlConnection(constr);
            List<ReasonModel> reasonlist = new List<ReasonModel>();
            JObject json = new JObject();
            SqlCommand cmd = new SqlCommand("GetReasonDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            cmd.Parameters.AddWithValue("@count_id", country);
            cmd.Parameters.AddWithValue("@state_id", state);
            cmd.Parameters.AddWithValue("@city_id", city);
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                reasonlist.Add(
                    new ReasonModel
                    {
                        reas_id = Convert.ToInt32(dr["reas_id"].ToString()),

                        reason = dr["reason"].ToString(),
                        status = Convert.ToInt32(dr["status"].ToString())
                    });
            }
            json["reasonlist"] = JToken.FromObject(reasonlist);
            return json;
        }




        [HttpPost]
        [WebMethod]
        public JObject LoadSeries(int make, int model, int badge)
        {
            con = new SqlConnection(constr);
            List<SeriesModel> serieslist = new List<SeriesModel>();
            JObject json = new JObject();
            SqlCommand cmd = new SqlCommand("GetSeriesDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            cmd.Parameters.AddWithValue("@make_id", make);
            cmd.Parameters.AddWithValue("@model_id", model);
            cmd.Parameters.AddWithValue("@bad_id", badge);
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                serieslist.Add(
                    new SeriesModel
                    {
                        ser_id = Convert.ToInt32(dr["ser_id"].ToString()),

                        series = dr["series_type"].ToString(),
                        status = Convert.ToInt32(dr["status"].ToString())
                    });
            }
            json["serieslist"] = JToken.FromObject(serieslist);
            return json;
        }

        [HttpPost]
        [WebMethod]
        public JObject LoadSeriesWithCount(string[] badge)
        {
            con = new SqlConnection(constr);
            List<SeriesModel> serieslist = new List<SeriesModel>();
            JObject json = new JObject();
            SqlCommand cmd = new SqlCommand("GetSeriesDetailsWithCount", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            //cmd.Parameters.AddWithValue("@make_id", make);
            //cmd.Parameters.AddWithValue("@model_id", model);
            cmd.Parameters.AddWithValue("@List", badge[0]);
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                serieslist.Add(
                    new SeriesModel
                    {
                        ser_id = Convert.ToInt32(dr["ser_id"].ToString()),

                        series = dr["series_type"].ToString(),
                        status = Convert.ToInt32(dr["status"].ToString()),
                        count = dr["seriescount"].ToString(),
                        badge = dr["badge_type"].ToString(),
                        mod = dr["model"].ToString(),
                        make = dr["make_type"].ToString(),
                    });
            }
            json["serieslist"] = JToken.FromObject(serieslist);
            return json;
        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        public JObject LoadEngineSize(int make, int model, int badge, int series)
        {
            con = new SqlConnection(constr);
            List<EngineSizeModel> serieslist = new List<EngineSizeModel>();
            JObject json = new JObject();
            SqlCommand cmd = new SqlCommand("GetEngineSizeDetail", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            cmd.Parameters.AddWithValue("@make_id", make);
            cmd.Parameters.AddWithValue("@model_id", model);
            cmd.Parameters.AddWithValue("@bad_id", badge);
            cmd.Parameters.AddWithValue("@series", series);
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                serieslist.Add(
                    new EngineSizeModel
                    {
                        ensize_id = Convert.ToInt32(dr["ensize_id"].ToString()),
                        ensizename = dr["ensize_name"].ToString(),
                        status = Convert.ToInt32(dr["status"].ToString())
                    });
            }
            json["enginesizelist"] = JToken.FromObject(serieslist);
            return json;
        }


        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        public JObject LoadCurrency()
        {
            con = new SqlConnection(constr);
            List<CurrencyModel> currencylist = new List<CurrencyModel>();
            JObject json = new JObject();
            SqlCommand cmd = new SqlCommand("GetCurrency", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                currencylist.Add(
                    new CurrencyModel
                    {
                        cur_id = Convert.ToInt32(dr["cur_id"].ToString()),
                        currency = dr["currency"].ToString(),
                        status = Convert.ToInt32(dr["status"].ToString()),
                        count_id = Convert.ToInt32(dr["count_id"].ToString()),

                    });
            }
            json["currencylist"] = JToken.FromObject(currencylist);
            return json;
        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        public JObject LoadCondition()
        {
            con = new SqlConnection(constr);
            List<ConditionModel> conditionlist = new List<ConditionModel>();
            JObject json = new JObject();
            SqlCommand cmd = new SqlCommand("GetCondition", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                conditionlist.Add(
                    new ConditionModel
                    {
                        cond_id = Convert.ToInt32(dr["cond_id"].ToString()),
                        condition = dr["condition"].ToString(),
                        status = Convert.ToInt32(dr["status"].ToString()),
                        count = dr["CarCount"].ToString(),
                    });
            }
            json["conditionlist"] = JToken.FromObject(conditionlist);
            return json;
        }


        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        public JObject LoadTransmission()
        {
            con = new SqlConnection(constr);
            List<TransmisionModel> translist = new List<TransmisionModel>();
            JObject json = new JObject();
            SqlCommand cmd = new SqlCommand("GetTransmision", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                translist.Add(
                    new TransmisionModel
                    {
                        trans_id = Convert.ToInt32(dr["trans_id"].ToString()),
                        transmision = dr["transmision"].ToString(),
                        status = Convert.ToInt32(dr["status"].ToString()),
                        count = dr["CarCount"].ToString(),
                    });
            }
            json["translist"] = JToken.FromObject(translist);
            return json;
        }


        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        public JObject LoadSpeedType()
        {
            con = new SqlConnection(constr);
            List<SpeedTypeModel> translist = new List<SpeedTypeModel>();
            JObject json = new JObject();
            SqlCommand cmd = new SqlCommand("GetSpeedType", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                translist.Add(
                    new SpeedTypeModel
                    {
                        speedtypeid = Convert.ToInt32(dr["speedtypeid"].ToString()),
                        speedtypename = dr["speedtypename"].ToString(),
                        status = dr["status"].ToString()
                    });
            }
            json["speedtypelist"] = JToken.FromObject(translist);
            return json;
        }


        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        public JObject LoadMeter()
        {
            con = new SqlConnection(constr);
            List<OdoMeterModel> meterlist = new List<OdoMeterModel>();
            JObject json = new JObject();
            SqlCommand cmd = new SqlCommand("GetOdoMeter", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                meterlist.Add(
                    new OdoMeterModel
                    {
                        odo_id = Convert.ToInt32(dr["odo_id"].ToString()),
                        meter = dr["odometer"].ToString(),
                        status = Convert.ToInt32(dr["status"].ToString())
                    });
            }
            json["meterlist"] = JToken.FromObject(meterlist);
            return json;
        }
        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        public JObject LoadDriveTrain()
        {
            con = new SqlConnection(constr);
            List<DriveTrainModel> drivelist = new List<DriveTrainModel>();
            JObject json = new JObject();
            SqlCommand cmd = new SqlCommand("GetDrive", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                drivelist.Add(
                    new DriveTrainModel
                    {
                        drive_id = Convert.ToInt32(dr["driv_id"].ToString()),
                        drive = dr["drive"].ToString(),
                        status = Convert.ToInt32(dr["status"].ToString())
                    });
            }
            json["drivelist"] = JToken.FromObject(drivelist);
            return json;
        }


        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        public JObject LoadEventCat()
        {
            con = new SqlConnection(constr);
            List<EventCategoryModel> catlist = new List<EventCategoryModel>();
            JObject json = new JObject();
            SqlCommand cmd = new SqlCommand("GetCategory", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                catlist.Add(
                    new EventCategoryModel
                    {
                        ecat_id = Convert.ToInt32(dr["ecat_id"].ToString()),
                        category = dr["category"].ToString(),
                        status = Convert.ToInt32(dr["status"].ToString()),
                        Count = dr["catcount"].ToString()
                    });
            }
            json["catlist"] = JToken.FromObject(catlist);
            return json;
        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject AddBodyType(string bodytype, string status)
        {

            JObject json = new JObject();
            con = new SqlConnection(constr);
            con.Open();
            cmd = new SqlCommand("InsertBodyType", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@bodytype", bodytype);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.ExecuteNonQuery();
            json["status"] = "Success";
            con.Close();
            return json;

        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject UpdataBodyType(int bodytypeid, string bodytype, string status)
        {

            JObject json = new JObject();
            con = new SqlConnection(constr);
            con.Open();
            cmd = new SqlCommand("UpdateBodyType", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@bodytypeid", bodytypeid);
            cmd.Parameters.AddWithValue("@bodytype", bodytype);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.ExecuteNonQuery();
            json["status"] = "Success";
            con.Close();
            return json;

        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject DeleteBodyType(int bodytypeid)
        {

            JObject json = new JObject();
            con = new SqlConnection(constr);
            con.Open();
            cmd = new SqlCommand("DeleteBodyType", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@bodytypeid", bodytypeid);

            cmd.ExecuteNonQuery();
            json["status"] = "Success";
            con.Close();
            return json;

        }

        [AllowAnonymous]
        [HttpPost]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject AddListedAs(string listedas, string status)
        {

            JObject json = new JObject();
            con = new SqlConnection(constr);
            con.Open();
            cmd = new SqlCommand("[InsertListedAs]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@listed", listedas);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.ExecuteNonQuery();
            json["status"] = "Success";
            con.Close();
            return json;
        }

        [AllowAnonymous]
        [HttpPost]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject UpdateListedAs(int listedasid, string listedas, string status)
        {

            JObject json = new JObject();
            con = new SqlConnection(constr);
            con.Open();
            cmd = new SqlCommand("[UpdateListedAs]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@listid", listedasid);
            cmd.Parameters.AddWithValue("@listed", listedas);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.ExecuteNonQuery();
            json["status"] = "Success";
            con.Close();
            return json;
        }

        [AllowAnonymous]
        [HttpPost]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject DeleteListedAs(int listedasid)
        {

            JObject json = new JObject();
            con = new SqlConnection(constr);
            con.Open();
            cmd = new SqlCommand("DeleteListedAs", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@listid", listedasid);
            cmd.ExecuteNonQuery();
            json["status"] = "Success";
            con.Close();
            return json;
        }

        [AllowAnonymous]
        [HttpPost]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject AddbodyColor(string bodycolor, string status)
        {

            JObject json = new JObject();
            con = new SqlConnection(constr);
            con.Open();
            cmd = new SqlCommand("InsertBodyColor", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@colorname", bodycolor);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.ExecuteNonQuery();
            json["status"] = "Success";
            con.Close();
            return json;
        }

        [AllowAnonymous]
        [HttpPost]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject UpdatebodyColor(int bodycolorid, string bodycolor, string status)
        {

            JObject json = new JObject();
            con = new SqlConnection(constr);
            con.Open();
            cmd = new SqlCommand("UpdateBodyColor", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@bodycolorid", bodycolorid);
            cmd.Parameters.AddWithValue("@colorname", bodycolor);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.ExecuteNonQuery();
            json["status"] = "Success";
            con.Close();
            return json;
        }

        [AllowAnonymous]
        [HttpPost]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject DeletebodyColor(int bodycolorid)
        {

            JObject json = new JObject();
            con = new SqlConnection(constr);
            con.Open();
            cmd = new SqlCommand("DeleteBodyColor", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@bodycolorid", bodycolorid);
            cmd.ExecuteNonQuery();
            json["status"] = "Success";
            con.Close();
            return json;
        }

        [AllowAnonymous]
        [HttpPost]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject AddInteriorColor(string intecolor, string status)
        {
            JObject json = new JObject();
            con = new SqlConnection(constr);
            con.Open();
            cmd = new SqlCommand("InsertInteriorColor", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@colorname", intecolor);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;
        }


        [AllowAnonymous]
        [HttpPost]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject UpdateInteriorColor(int intcolorid, string intecolor, string status)
        {
            JObject json = new JObject();
            con = new SqlConnection(constr);
            con.Open();
            cmd = new SqlCommand("UpdateInteriorColor", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@intcolorid", intcolorid);
            cmd.Parameters.AddWithValue("@colorname", intecolor);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;
        }


        [AllowAnonymous]
        [HttpPost]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject DeleteInteriorColor(int intcolorid)
        {
            JObject json = new JObject();
            con = new SqlConnection(constr);
            con.Open();
            cmd = new SqlCommand("DeleteInteriorColor", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@intcolorid", intcolorid);
            cmd.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;
        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject AddInteriorMaterial(string intermat, string status)
        {

            JObject json = new JObject();
            con = new SqlConnection(constr);
            con.Open();
            cmd = new SqlCommand("InsertInteriorMaterial", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@matname", intermat);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;
        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject UpdateInteriorMaterial(int intid, string intermat, string status)
        {

            JObject json = new JObject();
            con = new SqlConnection(constr);
            con.Open();
            cmd = new SqlCommand("UpdateInteriorMaterial", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@intmatid", intid);
            cmd.Parameters.AddWithValue("@matname", intermat);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;
        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject DeleteInteriorMaterial(int intid)
        {

            JObject json = new JObject();
            con = new SqlConnection(constr);
            con.Open();
            cmd = new SqlCommand("DeleteInteriorMaterial", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@intmatid", intid);
            cmd.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;
        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject EditCustomer(int cust_id, int plan_id, string regdate, string validdate, string name, string cno, string email, string gender, int country, int state, int city, int region, string zipcode, string streetname, string street, string pass, string lat, string longi, string apprstatus, string customerid, string bname, string usertype)
        {

            JObject json = new JObject();
            con = new SqlConnection(constr);
            con.Open();
            SqlParameter[] sqlparam = new SqlParameter[24];
            cmd = new SqlCommand("editcustomer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            sqlparam[0] = new SqlParameter("@cust_id", SqlDbType.Int);
            sqlparam[0].Value = cust_id;
            sqlparam[1] = new SqlParameter("@plan_id", SqlDbType.Int);
            sqlparam[1].Value = plan_id;
            sqlparam[2] = new SqlParameter("@regdate", SqlDbType.NVarChar, 50);
            sqlparam[2].Value = regdate;
            sqlparam[3] = new SqlParameter("@validdate", SqlDbType.NVarChar, 50);
            sqlparam[3].Value = validdate;
            sqlparam[4] = new SqlParameter("@name", SqlDbType.NVarChar, 50);
            sqlparam[4].Value = name;
            sqlparam[5] = new SqlParameter("@cno", SqlDbType.NVarChar, 50);
            sqlparam[5].Value = cno;
            sqlparam[6] = new SqlParameter("@email", SqlDbType.NVarChar, 50);
            sqlparam[6].Value = email;
            sqlparam[7] = new SqlParameter("@gender", SqlDbType.NVarChar, 20);
            sqlparam[7].Value = gender;
            sqlparam[8] = new SqlParameter("@country", SqlDbType.Int);
            sqlparam[8].Value = country;
            sqlparam[9] = new SqlParameter("@state", SqlDbType.Int);
            sqlparam[9].Value = state;
            sqlparam[10] = new SqlParameter("@city", SqlDbType.Int);
            sqlparam[10].Value = city;
            sqlparam[11] = new SqlParameter("@region", SqlDbType.Int);
            sqlparam[11].Value = region;
            sqlparam[12] = new SqlParameter("@zipcode", SqlDbType.NVarChar, 50);
            sqlparam[12].Value = zipcode;
            //sqlparam[13] = new SqlParameter("@suburb", SqlDbType.NVarChar, 200);
            //sqlparam[13].Value = suburb;
            sqlparam[13] = new SqlParameter("@streetname", SqlDbType.NVarChar, 200);
            sqlparam[13].Value = streetname;
            sqlparam[14] = new SqlParameter("@street", SqlDbType.NVarChar, 200);
            sqlparam[14].Value = street;
            sqlparam[15] = new SqlParameter("@pass", SqlDbType.NVarChar, 50);
            sqlparam[15].Value = pass;
            sqlparam[16] = new SqlParameter("@lat", SqlDbType.NVarChar, 200);
            sqlparam[16].Value = lat;
            sqlparam[17] = new SqlParameter("@longi", SqlDbType.NVarChar, 200);
            sqlparam[17].Value = longi;
            sqlparam[18] = new SqlParameter("@apprstatus", SqlDbType.NVarChar, 50);
            sqlparam[18].Value = apprstatus;
            sqlparam[19] = new SqlParameter("@errorCode", SqlDbType.Int);
            sqlparam[19].Direction = ParameterDirection.Output;
            sqlparam[20] = new SqlParameter("@errorMessage", SqlDbType.NVarChar, 200);
            sqlparam[20].Direction = ParameterDirection.Output;
            sqlparam[21] = new SqlParameter("@customerid", SqlDbType.NVarChar, 200);
            sqlparam[21].Value = customerid;
            sqlparam[22] = new SqlParameter("@bname", SqlDbType.NVarChar, 200);
            sqlparam[22].Value = bname;
            sqlparam[23] = new SqlParameter("@usertype", SqlDbType.NVarChar, 200);
            sqlparam[23].Value = usertype;
            cmd.Parameters.AddRange(sqlparam);
            cmd.ExecuteNonQuery();
            int errorcode = (int)sqlparam[19].Value;
            string errorMessage = sqlparam[20].Value.ToString();
            if (errorcode == 0)
            {
                json["status"] = "1";
            }
            else
            {
                json["status"] = errorMessage;
            }
            con.Close();
            return json;
        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject AddCustomer(string cust_id, int plan_id, string regdate, string validdate, string name, string cno, string email, string gender, int country, int state, int city, int region, string zipcode, string streetname, string street, string pass, string lat, string longi, string apprstatus, string customerid, string bname, string ctype)
        {

            JObject json = new JObject();
            con = new SqlConnection(constr);
            con.Open();
            SqlParameter[] sqlparam = new SqlParameter[25];
            cmd = new SqlCommand("Addcustomer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            sqlparam[0] = new SqlParameter("@cust_id", SqlDbType.NVarChar, 200);
            sqlparam[0].Value = cust_id;
            sqlparam[1] = new SqlParameter("@plan_id", SqlDbType.Int);
            sqlparam[1].Value = plan_id;
            sqlparam[2] = new SqlParameter("@regdate", SqlDbType.NVarChar, 50);
            sqlparam[2].Value = regdate;
            sqlparam[3] = new SqlParameter("@validdate", SqlDbType.NVarChar, 50);
            sqlparam[3].Value = validdate;
            sqlparam[4] = new SqlParameter("@name", SqlDbType.NVarChar, 50);
            sqlparam[4].Value = name;
            sqlparam[5] = new SqlParameter("@cno", SqlDbType.NVarChar, 50);
            sqlparam[5].Value = cno;
            sqlparam[6] = new SqlParameter("@email", SqlDbType.NVarChar, 50);
            sqlparam[6].Value = email;
            sqlparam[7] = new SqlParameter("@gender", SqlDbType.NVarChar, 20);
            sqlparam[7].Value = gender;
            sqlparam[8] = new SqlParameter("@country", SqlDbType.Int);
            sqlparam[8].Value = country;
            sqlparam[9] = new SqlParameter("@state", SqlDbType.Int);
            sqlparam[9].Value = state;
            sqlparam[10] = new SqlParameter("@city", SqlDbType.Int);
            sqlparam[10].Value = city;
            sqlparam[11] = new SqlParameter("@region", SqlDbType.Int);
            sqlparam[11].Value = region;
            sqlparam[12] = new SqlParameter("@zipcode", SqlDbType.NVarChar, 50);
            sqlparam[12].Value = zipcode;
            //sqlparam[13] = new SqlParameter("@suburb", SqlDbType.NVarChar, 200);
            //sqlparam[13].Value = suburb;
            sqlparam[13] = new SqlParameter("@streetname", SqlDbType.NVarChar, 200);
            sqlparam[13].Value = streetname;
            sqlparam[14] = new SqlParameter("@street", SqlDbType.NVarChar, 200);
            sqlparam[14].Value = street;
            sqlparam[15] = new SqlParameter("@pass", SqlDbType.NVarChar, 50);
            sqlparam[15].Value = pass;
            sqlparam[16] = new SqlParameter("@lat", SqlDbType.NVarChar, 200);
            sqlparam[16].Value = lat;
            sqlparam[17] = new SqlParameter("@longi", SqlDbType.NVarChar, 200);
            sqlparam[17].Value = longi;
            sqlparam[18] = new SqlParameter("@apprstatus", SqlDbType.NVarChar, 50);
            sqlparam[18].Value = apprstatus;
            sqlparam[19] = new SqlParameter("@errorCode", SqlDbType.Int);
            sqlparam[19].Direction = ParameterDirection.Output;
            sqlparam[20] = new SqlParameter("@errorMessage", SqlDbType.NVarChar, 200);
            sqlparam[20].Direction = ParameterDirection.Output;
            sqlparam[21] = new SqlParameter("@customerid", SqlDbType.NVarChar, 200);
            sqlparam[21].Value = customerid;
            sqlparam[22] = new SqlParameter("@bname", SqlDbType.NVarChar, 200);
            sqlparam[22].Value = bname;
            sqlparam[23] = new SqlParameter("@ctype", SqlDbType.NVarChar, 200);
            sqlparam[23].Value = ctype;
            sqlparam[24] = new SqlParameter("@custid", SqlDbType.NVarChar, 200);
            sqlparam[24].Direction = ParameterDirection.Output;

            cmd.Parameters.AddRange(sqlparam);
            cmd.ExecuteNonQuery();
            int errorcode = (int)sqlparam[19].Value;
            string errorMessage = sqlparam[20].Value.ToString();
            string custid = sqlparam[24].Value.ToString();

            String htmlmessage = "<table border='0' cellpadding='5' cellspacing='0' style='font - family:arial; background - color: #fff; height:auto; width:800px; margin:30px auto; max-width:100%;'>";
            htmlmessage = htmlmessage + "<tr><td align='left' style='border-bottom:10px solid #0098fa;padding:20px50px;'>";
            htmlmessage = htmlmessage + "<img src='http://mycaryard.mobi96.org/content/images/logo.png' alt='logo'></td></tr><tr>";
            htmlmessage = htmlmessage + "<td align='left' style='padding:30px 50px 20px; font-size: 24px;  color:#000;'> Welcome!</td></tr><tr>";
            htmlmessage = htmlmessage + "<td align='left' style = 'padding:0px 50px 20px; color:#000;'>";
            htmlmessage = htmlmessage + "A mycaryard account has been created for you. your account is in under review, mycaryard team will contact your shortly.";
            htmlmessage = htmlmessage + "</tr><tr><td align='left' style='padding:0px 50px 20px; color:#000;'>";
            htmlmessage = htmlmessage + "Login page: <a href='http://mycaryard.mobi96.org/Home/UserIndex' style='color: #0066CC;'> mycaryard.mobi96.org</a><br>";
            htmlmessage = htmlmessage + "Email:<a href='mycaryard@gmail.com' style='color: #0066CC;'> mycaryard@gmail.com </a></td></tr><tr>";
            htmlmessage = htmlmessage + "<td align='left' style='padding:0px 50px 20px; color:#000;'>";
            htmlmessage = htmlmessage + "We are here to help. if you have any question about marcaryard, just visit<span style='color: #0066CC;text-decoration:underline'> <a href='http://mycaryard.mobi96.org/Home/UserIndex' style='color: #0066CC;'>support site</a> </span></td></tr><tr>";
            htmlmessage = htmlmessage + "<td align='left' style='padding: 0px 50px 10px;line-height:24px; color:#0098FA;'><a href='http://mycaryard.mobi96.org/Home/UserIndex' style='color: #0066CC;'>Login to your account if you already have</a></td></tr><tr><td></td></tr></table>";

            var msg = new MailMessage();
            var htmlBody = AlternateView.CreateAlternateViewFromString(htmlmessage, Encoding.UTF8, "text/html");
            MailAddress sender = new MailAddress("info@stums.in", "MyCarYard");
            msg.AlternateViews.Add(htmlBody);
            msg.From = sender;
            msg.Subject = "MYCARYARD New Registration";
            msg.To.Add(email);


            if (errorcode == 0)
            {
                json["status"] = "1";
                json["custid"] = custid;
            }
            else
            {
                json["status"] = errorMessage;
            }
            con.Close();
            return json;
        }



        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        public JObject loadListedAs()
        {

            JObject json = new JObject();
            List<ListedByModel> listedbylist = new List<ListedByModel>();
            ListedByModel model = new ListedByModel();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("GetListedAs", con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            listedbylist.Add(new ListedByModel
                            {
                                listedas_id = Convert.ToInt32(dt.Rows[i]["listed_id"].ToString()),
                                listed_name = dt.Rows[i]["listed_name"].ToString(),
                                status = dt.Rows[i]["status"].ToString()
                            });
                        }
                    }

                }
            }
            json["listedas"] = JToken.FromObject(listedbylist);
            return json;
        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        public JObject loadbodytype()
        {

            BodyTypeModel model = new BodyTypeModel();
            JObject json = new JObject();
            DataTable dt = new DataTable();
            List<BodyTypeModel> bodytypelist = new List<BodyTypeModel>();

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("GetBodyType", con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            bodytypelist.Add(new BodyTypeModel
                            {
                                bodytype_id = Convert.ToInt32(dt.Rows[i]["body_type_id"].ToString()),
                                bodytype_name = dt.Rows[i]["body_type"].ToString(),
                                status = dt.Rows[i]["status"].ToString()
                            });
                        }
                    }

                }
            }
            json["bodytypelist"] = JToken.FromObject(bodytypelist);
            return json;
        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        public JObject loadbodycolor()
        {

            JObject json = new JObject();
            BodyColorModel model = new BodyColorModel();
            List<BodyColorModel> bodycolorlist = new List<Models.BodyColorModel>();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("GetBodyColor", con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            bodycolorlist.Add(new BodyColorModel
                            {
                                body_color_id = Convert.ToInt32(dt.Rows[i]["body_color_id"].ToString()),
                                body_color_name = dt.Rows[i]["body_color_name"].ToString(),
                                status = dt.Rows[i]["status"].ToString()
                            });
                        }
                    }

                }
            }
            json["bodycolorlist"] = JToken.FromObject(bodycolorlist);
            return json;
        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        public JObject loadinteriorcolor()
        {

            JObject json = new JObject();
            InteriorColorModel model = new InteriorColorModel();
            List<InteriorColorModel> intecolorlist = new List<InteriorColorModel>();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("GetInteriorColor", con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            intecolorlist.Add(new InteriorColorModel
                            {
                                Inte_color_id = Convert.ToInt32(dt.Rows[i]["inter_color_id"].ToString()),
                                Inte_color_name = dt.Rows[i]["inter_color_name"].ToString(),
                                status = dt.Rows[i]["status"].ToString()
                            });
                        }
                    }

                }
            }
            json["interiorcolorlist"] = JToken.FromObject(intecolorlist);
            return json;
        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        public JObject loadinteriormaterial()
        {

            JObject json = new JObject();
            InteriorMaterialModel model = new InteriorMaterialModel();
            List<InteriorMaterialModel> intematlist = new List<InteriorMaterialModel>();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("GetInteriorMaterial", con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            intematlist.Add(new InteriorMaterialModel
                            {
                                Inte_Mat_id = Convert.ToInt32(dt.Rows[i]["inter_mat_id"].ToString()),
                                Inte_Mat_name = dt.Rows[i]["inter_Mat_name"].ToString(),
                                status = dt.Rows[i]["status"].ToString()
                            });
                        }
                    }

                }
            }
            json["materiallist"] = JToken.FromObject(intematlist);
            return json;
        }


        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        public JObject GetTranmissionDetail(int transid)
        {

            JObject json = new JObject();
            TransmisionModel model = new TransmisionModel();
            List<TransmisionModel> intematlist = new List<TransmisionModel>();
            DataTable dt = new DataTable();
            con = new SqlConnection(constr);
            cmd = new SqlCommand("getTransDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@transid", SqlDbType.Int).Value = transid;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    intematlist.Add(new TransmisionModel
                    {
                        trans_id = Convert.ToInt32(dt.Rows[i]["trans_id"].ToString()),
                        transmision = dt.Rows[i]["transmision"].ToString(),
                        speedtype = dt.Rows[i]["speedtype"].ToString(),
                        status = Convert.ToInt32(dt.Rows[i]["status"].ToString())
                    });
                }
            }


            json["transdetaillist"] = JToken.FromObject(intematlist);
            return json;
        }



        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        public JObject GetAllCylinders()
        {

            JObject json = new JObject();
            CylinderModel model = new CylinderModel();
            List<CylinderModel> intematlist = new List<CylinderModel>();
            DataTable dt = new DataTable();
            con = new SqlConnection(constr);
            cmd = new SqlCommand("GetAllCylinders", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    intematlist.Add(new CylinderModel
                    {
                        cylinder_id = Convert.ToInt32(dt.Rows[i]["cylinder_id"].ToString()),
                        cylinder_name = dt.Rows[i]["cylinder_name"].ToString(),
                        status = dt.Rows[i]["status"].ToString()
                    });
                }
            }


            json["cylinderlist"] = JToken.FromObject(intematlist);
            return json;
        }

        [HttpPost]
        [WebMethod]
        [AllowAnonymous]
        public JObject GetAllFuel()
        {


            JObject json = new JObject();
            FuelModel model = new FuelModel();
            List<FuelModel> intematlist = new List<FuelModel>();
            DataTable dt = new DataTable();
            con = new SqlConnection(constr);
            cmd = new SqlCommand("[GetFuel]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    intematlist.Add(new FuelModel
                    {
                        fuel_id = Convert.ToInt32(dt.Rows[i]["fuel_id"].ToString()),
                        fuel_name = dt.Rows[i]["fuel_name"].ToString(),
                        status = dt.Rows[i]["status"].ToString()
                    });
                }
            }


            json["fuellist"] = JToken.FromObject(intematlist);
            return json;
        }

        [HttpPost]
        public JObject checkregemail(string unm)
        {

            JObject json = new JObject();
            con = new SqlConnection(constr);
            con.Open();
            cmd = new SqlCommand("select * from tbl_login where email = '" + unm + "'", con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                json["status"] = "Email Address Already Exists";

            }
            else
            {

                json["status"] = "Success";
            }

            con.Close();

            return json;
        }

        [HttpPost]
        public JObject ForgetPass(string unm)
        {

            JObject json = new JObject();
            con = new SqlConnection(constr);
            con.Open();
            cmd = new SqlCommand("select * from tbl_login where email = '" + unm + "'", con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                json["status"] = "Success";
                //Email Code

                MailMessage mail = new MailMessage("info@mobi96.org", unm, "MYCARYARD Password Reset", "You requested to reset your password for MyCarYard Account.<br> Your MYCARYARD Account ID (" + unm + "). Your Acccount Password is - " + dr["pass"].ToString());
                mail.IsBodyHtml = true;
                SmtpClient client = new SmtpClient("relay-hosting.secureserver.net");
                client.Send(mail);
            }
            else
            {

                json["status"] = "Invalid";
            }

            con.Close();

            return json;
        }

        [HttpPost]
        public JObject ContactUs(string name, string email, string subject, string msg)
        {
            JObject json = new JObject();

            var SmtpClient = new SmtpClient();
            SmtpClient.Send("info@stums.in", "nileshlad1988@gmail.com", "MYCARYARD Enquiry", "Name - " + name + ", Email - " + email + ", Subject - " + subject + ", Message - " + msg + "");
            json["status"] = "Success";

            return json;
        }
        [HttpPost]
        public JObject SendEnquiry(string enqname, string email, string cno, string postcode, string msg, string custemail)
        {

            JObject json = new JObject();

            ////var SmtpClient = new SmtpClient();
            ////SmtpClient.Send("info@stums.in", custemail , "MyCarYard Enquiry", "Email - " + email + ", Contact Number - " + cno + ", PostCode - " + postcode + ", Message - " + msg + "");
            String htmlmessage = "<table border='0' cellpadding='5' cellspacing='0' style='font - family:arial; background - color: #fff; height:auto; width:800px; margin:30px auto; max-width:100%;'>";
            htmlmessage = htmlmessage + "<tr><td align='left' style='border-bottom:10px solid #0098fa;padding:20px50px;'>";
            htmlmessage = htmlmessage + "<img src='http://mycaryard.mobi96.org/content/images/logo.png' alt='logo'></td></tr><tr>";
            htmlmessage = htmlmessage + "<td align='left' style='padding:30px 50px 20px; font-size: 24px;  color:#000;'> New Enquiry</td></tr><tr>";
            htmlmessage = htmlmessage + "<td align='left' style = 'padding:0px 50px 20px; color:#000;'>";
            htmlmessage = htmlmessage + "Name: " + enqname + "<br> Email: " + email + " <br> Contact Number: " + cno + " <br> PostCode: " + postcode + " <br> Message: " + msg + "";
            htmlmessage = htmlmessage + "</tr><tr><td align='left' style='padding:0px 50px 20px; color:#000;'>";
            htmlmessage = htmlmessage + "Login page: <a href='http://mycaryard.mobi96.org/Home/UserIndex' style='color: #0066CC;'> mycaryard.mobi96.org</a><br>";
            htmlmessage = htmlmessage + "Email:<a href='info@mycaryard.com' style='color: #0066CC;'> info@mycaryard.com </a></td></tr><tr>";
            htmlmessage = htmlmessage + "<td align='left' style='padding:0px 50px 20px; color:#000;'>";
            htmlmessage = htmlmessage + "We are here to help. if you have any question about marcaryard, just visit<span style='color: #0066CC;text-decoration:underline'> <a href='http://mycaryard.mobi96.org/Home/UserIndex' style='color: #0066CC;'>support site</a> </span></td></tr><tr>";
            htmlmessage = htmlmessage + "<td align='left' style='padding: 0px 50px 10px;line-height:24px; color:#0098FA;'><a href='http://mycaryard.mobi96.org/Home/UserIndex' style='color: #0066CC;'>Login to your account if you already have</a></td></tr><tr><td></td></tr></table>";

            var msg1 = new MailMessage();
            var htmlBody = AlternateView.CreateAlternateViewFromString(htmlmessage, Encoding.UTF8, "text/html");
            // MailAddress sender = new MailAddress("info@mycaryard.net", "info@admin2018");
            MailAddress sender = new MailAddress("info@mycaryard.net");
            msg1.AlternateViews.Add(htmlBody);
            msg1.From = sender;
            msg1.Subject = "MYCARYARD New Enquiry";
            msg1.To.Add("madelslim@hotmail.com");

            // MailMessage mail = new MailMessage("info@stums.in", model.RegEmail, "MyCarYard New Registration", htmlmessage);
            msg1.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("relay-hosting.secureserver.net");
            client.Send(msg1);


            //MailMessage mail = new MailMessage();
            //mail.To.Add(email);
            //mail.To.Add("xxx@gmail.com");
            //mail.From = new MailAddress("yyy@gmail.com");
            //mail.Subject = "sub";

            //mail.Body = body;

            //mail.IsBodyHtml = true;
            //SmtpClient smtp = new SmtpClient();
            //smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
            //smtp.Credentials = new System.Net.NetworkCredential
            //     ("yyy@gmail.com", "pw"); // ***use valid credentials***
            //smtp.Port = 587;

            ////Or your Smtp Email ID and Password
            //smtp.EnableSsl = true;
            //smtp.Send(mail);

            json["status"] = "Success";

            return json;
        }
        [AuthonticateUserHelper]
        public ActionResult UpdateBusinessLogo(HttpPostedFileBase buslogo, FormCollection frmlogoupdate)
        {
            if (buslogo != null)
            {
                string pic = System.IO.Path.GetFileName(buslogo.FileName);
                string path = System.IO.Path.Combine(
                Server.MapPath("~/images/logos"), frmlogoupdate["photoupdateid"] + pic);
                buslogo.SaveAs(path);
                WebImage supermanImage = new WebImage(Server.MapPath("~/images/logos/" + frmlogoupdate["photoupdateid"] + pic));

                supermanImage.AddTextWatermark("MY CARYARD", "White", 40, "Regular", "Consolas", "Right", "Top", 20, 10);

                supermanImage.Save(Server.MapPath("~/images/logos/" + frmlogoupdate["photoupdateid"] + pic));

                using (MemoryStream ms = new MemoryStream())
                {
                    buslogo.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }
                //Update Image Name1
                con = new SqlConnection(constr);
                con.Open();
                cmd = new SqlCommand("update tbl_login SET buslogo='" + frmlogoupdate["photoupdateid"] + pic + "' where id= '" + frmlogoupdate["photoupdateid"] + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }



            return RedirectToAction("UserList", "Home");
        }
        public string ForgotPasswordEmailAndCodeVarification(string UserData, int DataType)
        {
            con = new SqlConnection(constr);
            cmd = new SqlCommand("ForgotUserPassword", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserData", SqlDbType.NVarChar, 100).Value = UserData;
            cmd.Parameters.Add("@DataType", SqlDbType.Int).Value = DataType;
            con.Open();
            string Result = cmd.ExecuteScalar().ToString();
            con.Close();
            return Result;
        }

        [HttpPost]
        public ActionResult ForgotPasswordEmailVarification(string UserEmail)
        {
            string Result = ForgotPasswordEmailAndCodeVarification(UserEmail, 0);
            if (Result != "incorrect")
            {
                string body = String.Empty;
                body = System.IO.File.ReadAllText(HostingEnvironment.MapPath("~/App_Data/Template/ForgotPasswordEmailTemplate.txt"));
                body = body.Replace("forgotpasswordlink_dyn", "http://mycaryard.mobi96.org/Admin/ForgotPassword?unique_id=" + Result);
                var json = SendEmail(body, UserEmail, "MYCARYARD | Password Reset Url");
                return Json(new { status = "Success" });
            }


            return Json(new { status = "incorrect" });
        }
        [AllowAnonymous]
        public ActionResult ForgotPassword(string unique_id)
        {
            string Result = ForgotPasswordEmailAndCodeVarification(unique_id, 1);

            if (Result != "incorrect")
            {
                int UserId;
                bool isUserId = int.TryParse(Result, out UserId);
                if (isUserId)
                {
                    return RedirectToAction("NewPasswordSetting", "Home", new { id = UserId });
                }

            }
            return RedirectToAction("Index", "Home");
        }
        public JObject SendEmail(string body, string Email_Id, string Sub)
        {

            JObject json = new JObject();
            try
            {

                MailMessage mail = new MailMessage("info@mobi96.org", Email_Id, Sub, body);
                mail.IsBodyHtml = true;
                SmtpClient client = new SmtpClient("relay-hosting.secureserver.net");
                client.Send(mail);

                json["status"] = 1;
                json["Message"] = "Mail Sent";
            }
            catch (Exception ex)
            {
                json["status"] = 0;
                json["Message"] = ex.Message;
            }
            return json;
        }
    }
}