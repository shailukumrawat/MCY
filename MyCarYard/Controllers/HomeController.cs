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
using System.Web.Helpers;
using System.Globalization;
using MyCarYard.ActionHelper;
using System.Web.Script.Services;
using System.Net.Mail;
using System.Text;
using System.Web.Hosting;
using System.Collections;

namespace MyCarYard.Controllers
{
    [ValidateInput(false)]
    [OutputCache(Duration = 60)]
    public class HomeController : Controller
    {
        string constr = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        public ActionResult Index()
        {


            RegisterViewModel listmodel = new RegisterViewModel();
            List<MakeTypeModel> list = new List<MakeTypeModel>();
            con = new SqlConnection(constr);
            con.Open();
            cmd = new SqlCommand("GetMakeTypeWithCount", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@countryid", '0');
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                list.Add(new MakeTypeModel
                {
                    make_id = Convert.ToInt32(dr["make_id"].ToString()),
                    make = dr["make_type"].ToString(),
                    status = Convert.ToInt32(dr["status"].ToString()),
                    count = dr["makecount"].ToString()

                });
            }
            dr.Close();
            DateTime todaydate = DateTime.Now.Date;
            DateTime createddate;
            cmd = new SqlCommand("select * from tbl_carmaster order by cid", con);
            //dr = cmd.ExecuteReader();
            SqlDataAdapter _dataadapter = new SqlDataAdapter(cmd);
            DataTable _table = new DataTable();
            _dataadapter.Fill(_table);
            // _table.Load(dr);
            // dr.Close();
            foreach (DataRow row in _table.Rows)
            {

                createddate = Convert.ToDateTime(row["created_date"].ToString());
                TimeSpan diff = todaydate - createddate;
                var daysnum = diff.TotalDays;
                if (daysnum > 28)
                {

                    cmd = new SqlCommand("Update tbl_carmaster set gstatus=1 where cid='" + row["cid"].ToString() + "'", con);
                    cmd.ExecuteNonQuery();
                }

            }
            con.Close();

            listmodel.makelist = list;
            return View(listmodel);

        }

        [AuthonticateUserHelper]
        public ActionResult AddUser()
        {

            return View();
        }
        [AuthonticateUserHelper]
        public ActionResult Plan()
        {
            con = new SqlConnection(constr);
            PlanModel model = new PlanModel();
            List<PlanModel> planlist = new List<PlanModel>();
            JObject json = new JObject();
            SqlCommand cmd = new SqlCommand("GetPlan", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                planlist.Add(
                    new PlanModel
                    {
                        plan_id = Convert.ToInt32(dr["plan_id"].ToString()),
                        plan_name = dr["plan_name"].ToString(),
                        duration = Convert.ToInt32(dr["duration"].ToString()),
                        amnt = Convert.ToInt32(dr["amnt"].ToString()),
                        status = Convert.ToInt32(dr["status"].ToString())
                    });
            }
            model.planlist = planlist;
            return View(model);
        }

        [AuthonticateUserHelper]
        public ActionResult Notification()
        {

            string id = Session["id"].ToString();
            con = new SqlConnection(constr);
            con.Open();
            NotificationModel model = new Models.NotificationModel();
            List<NotificationModel> notificationlist = new List<NotificationModel>();
            cmd = new SqlCommand("select a.*,b.name,b.buslogo,b.status as userstatus from [UserNotification] a,tbl_login b where b.id=a.touid and a.status = 1 and a.touid='" + id + "' order by a.NID desc", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                notificationlist.Add(new NotificationModel
                {
                    fromusername = dr["name"].ToString(),
                    msg = dr["msg"].ToString(),
                    edate = dr["edate"].ToString(),
                    logo = dr["buslogo"].ToString()


                });
                Session["status"] = dr["userstatus"].ToString();
            }
            model.notificationlist = notificationlist;
            // Session["status"] = dr["userstatus"].ToString();
            dr.Close();
            return View(model);
        }

        [AuthonticateUserHelper]
        public ActionResult Setting()
        {

            return View();
        }
        [AllowAnonymous]
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult NewPasswordSetting(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                Session["Userid"] = id;
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        [WebMethod]
        [HttpPost]
        public JObject changepassword(string id, string oldpass, string newpass)
        {

            JObject json = new JObject();
            con = new SqlConnection(constr);
            con.Open();
            SqlParameter[] sqlparam = new SqlParameter[4];
            cmd = new SqlCommand("changepassword", con);
            cmd.CommandType = CommandType.StoredProcedure;
            sqlparam[0] = new SqlParameter("@id", SqlDbType.NVarChar, 200);
            sqlparam[0].Value = id;
            sqlparam[1] = new SqlParameter("@oldpass", SqlDbType.NVarChar, 200);
            sqlparam[1].Value = oldpass;
            sqlparam[2] = new SqlParameter("@newpass", SqlDbType.NVarChar, 200);
            sqlparam[2].Value = newpass;
            sqlparam[3] = new SqlParameter("@status", SqlDbType.NVarChar, 2000);
            sqlparam[3].Direction = ParameterDirection.Output;
            cmd.Parameters.AddRange(sqlparam);
            cmd.ExecuteNonQuery();
            string status = sqlparam[3].Value.ToString();
            json["status"] = status;
            con.Close();
            return json;
        }

        [WebMethod]
        [AllowAnonymous]
        [HttpPost]
        [AuthonticateUserHelper]
        public JObject EditPlan(int planid, string planname, string duration, float amnt, string status)
        {

            JObject json = new JObject();
            con = new SqlConnection(constr);
            con.Open();
            cmd = new SqlCommand("EditPlan", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@planid", planid);
            cmd.Parameters.AddWithValue("@planname", planname);
            cmd.Parameters.AddWithValue("@duration", duration);
            cmd.Parameters.AddWithValue("@amnt", amnt);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.ExecuteNonQuery();
            con.Close();
            json["status"] = "1";
            return json;
        }

        //public ActionResult UploadCarPic(HttpPostedFileBase img, HttpPostedFileBase img1, HttpPostedFileBase img2, HttpPostedFileBase img3, HttpPostedFileBase img4, HttpPostedFileBase img5, FormCollection frm1)
        //{
        //    if (img != null)
        //    {
        //        string pic = System.IO.Path.GetFileName(img.FileName);
        //        string path = System.IO.Path.Combine(
        //        Server.MapPath("~/images/cars"), frm1["addcarid"] + pic);
        //        img.SaveAs(path);

        //        WebImage supermanImage = new WebImage(Server.MapPath("~/images/cars/" + frm1["addcarid"] + pic));
        //        supermanImage.AddImageWatermark(Server.MapPath("~/Content/images/logo.png"), 227, 25, "Right", "Bottom", 85, 10);
        //        //supermanImage.AddTextWatermark("MY CARYARD", "White",40, "Regular", "Consolas", "Right", "Top", 20, 10);

        //        supermanImage.Save(Server.MapPath("~/images/cars/" + frm1["addcarid"] + pic));

        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            img.InputStream.CopyTo(ms);
        //            byte[] array = ms.GetBuffer();
        //        }
        //        //Update Image Name1
        //        con = new SqlConnection(constr);
        //        con.Open();
        //        cmd = new SqlCommand("update tbl_carmaster SET img='" + frm1["addcarid"] + pic + "' where cid= '" + frm1["addcarid"] + "'", con);
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //    }

        //    if (img1 != null)
        //    {
        //        string pic = System.IO.Path.GetFileName(img1.FileName);
        //        string path = System.IO.Path.Combine(
        //        Server.MapPath("~/images/cars"), frm1["addcarid"] + pic);
        //        img1.SaveAs(path);
        //        WebImage supermanImage = new WebImage(Server.MapPath("~/images/cars/" + frm1["addcarid"] + pic));
        //        supermanImage.AddImageWatermark(Server.MapPath("~/Content/images/logo.png"), 227, 25, "Right", "Bottom", 85, 10);
        //        //supermanImage.AddTextWatermark("MY CARYARD", "White",40, "Regular", "Consolas", "Right", "Top", 20, 10);

        //        supermanImage.Save(Server.MapPath("~/images/cars/" + frm1["addcarid"] + pic));

        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            img1.InputStream.CopyTo(ms);
        //            byte[] array = ms.GetBuffer();
        //        }
        //        //Update Image Name2
        //        con = new SqlConnection(constr);
        //        con.Open();
        //        cmd = new SqlCommand("update tbl_carmaster SET img1='" + frm1["addcarid"] + pic + "' where cid= '" + frm1["addcarid"] + "'", con);
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //    }

        //    if (img2 != null)
        //    {
        //        string pic = System.IO.Path.GetFileName(img2.FileName);
        //        string path = System.IO.Path.Combine(
        //        Server.MapPath("~/images/cars"), frm1["addcarid"] + pic);
        //        img2.SaveAs(path);

        //        WebImage supermanImage = new WebImage(Server.MapPath("~/images/cars/" + frm1["addcarid"] + pic));
        //        supermanImage.AddImageWatermark(Server.MapPath("~/Content/images/logo.png"), 227, 25, "Right", "Bottom", 85, 10);
        //        //supermanImage.AddTextWatermark("MY CARYARD", "White", 40, "Regular", "Consolas", "Right", "Top", 20, 10);

        //        supermanImage.Save(Server.MapPath("~/images/cars/" + frm1["addcarid"] + pic));


        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            img2.InputStream.CopyTo(ms);
        //            byte[] array = ms.GetBuffer();
        //        }
        //        con = new SqlConnection(constr);
        //        con.Open();
        //        cmd = new SqlCommand("update tbl_carmaster SET img2='" + frm1["addcarid"] + pic + "' where cid= '" + frm1["addcarid"] + "'", con);
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //    }

        //    if (img3 != null)
        //    {
        //        string pic = System.IO.Path.GetFileName(img3.FileName);
        //        string path = System.IO.Path.Combine(
        //        Server.MapPath("~/images/cars"), frm1["addcarid"] + pic);
        //        img3.SaveAs(path);

        //        WebImage supermanImage = new WebImage(Server.MapPath("~/images/cars/" + frm1["addcarid"] + pic));
        //        supermanImage.AddImageWatermark(Server.MapPath("~/Content/images/logo.png"), 227, 25, "Right", "Bottom", 85, 10);
        //        // supermanImage.AddTextWatermark("MY CARYARD", "White", 40, "Regular", "Consolas", "Right", "Top", 20, 10);

        //        supermanImage.Save(Server.MapPath("~/images/cars/" + frm1["addcarid"] + pic));

        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            img3.InputStream.CopyTo(ms);
        //            byte[] array = ms.GetBuffer();
        //        }
        //        con = new SqlConnection(constr);
        //        con.Open();
        //        cmd = new SqlCommand("update tbl_carmaster SET img3='" + frm1["addcarid"] + pic + "' where cid= '" + frm1["addcarid"] + "'", con);
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //    }

        //    if (img4 != null)
        //    {
        //        string pic = System.IO.Path.GetFileName(img4.FileName);
        //        string path = System.IO.Path.Combine(
        //        Server.MapPath("~/images/cars"), frm1["addcarid"] + pic);
        //        img4.SaveAs(path);
        //        WebImage supermanImage = new WebImage(Server.MapPath("~/images/cars/" + frm1["addcarid"] + pic));
        //        supermanImage.AddImageWatermark(Server.MapPath("~/Content/images/logo.png"), 227, 25, "Right", "Bottom", 85, 10);
        //        //supermanImage.AddTextWatermark("MY CARYARD", "White", 40, "Regular", "Consolas", "Right", "Top", 20, 10);

        //        supermanImage.Save(Server.MapPath("~/images/cars/" + frm1["addcarid"] + pic));

        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            img4.InputStream.CopyTo(ms);
        //            byte[] array = ms.GetBuffer();
        //        }
        //        con = new SqlConnection(constr);
        //        con.Open();
        //        cmd = new SqlCommand("update tbl_carmaster SET img4='" + frm1["addcarid"] + pic + "' where cid= '" + frm1["addcarid"] + "'", con);
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //    }

        //    if (img5 != null)
        //    {
        //        string pic = System.IO.Path.GetFileName(img5.FileName);
        //        string path = System.IO.Path.Combine(
        //        Server.MapPath("~/images/cars"), frm1["addcarid"] + pic);
        //        img5.SaveAs(path);
        //        WebImage supermanImage = new WebImage(Server.MapPath("~/images/cars/" + frm1["addcarid"] + pic));
        //        supermanImage.AddImageWatermark(Server.MapPath("~/Content/images/logo.png"), 227, 25, "Right", "Bottom", 85, 10);
        //        // supermanImage.AddTextWatermark("MY CARYARD", "White", 40, "Regular", "Consolas", "Right", "Top", 20, 10);

        //        supermanImage.Save(Server.MapPath("~/images/cars/" + frm1["addcarid"] + pic));

        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            img5.InputStream.CopyTo(ms);
        //            byte[] array = ms.GetBuffer();
        //        }
        //        con = new SqlConnection(constr);
        //        con.Open();
        //        cmd = new SqlCommand("update tbl_carmaster SET img5='" + frm1["addcarid"] + pic + "' where cid= '" + frm1["addcarid"] + "'", con);
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //    }

        //    return RedirectToAction("AddCar", "Home");
        //}

        //Change Action code 2/5/2017 
        public ActionResult UploadCarPic(FormCollection frm1)
        {
            string filePath = string.Empty;
            var dataStr = String.Format("{0:d/M/yyyy HH:mm:ss}", DateTime.Now);
            dataStr = dataStr.Replace(@"/", "").Trim(); dataStr = dataStr.Replace(@":", "").Trim(); dataStr = dataStr.Replace(" ", String.Empty);

            Hashtable ht = new Hashtable();
            for (int i = 0; i < 6; i++)
            {
                if (!string.IsNullOrEmpty(frm1["addcarid"]))
                {
                    if (!string.IsNullOrEmpty(frm1["hdoutput" + i]))
                    {
                        filePath = HostingEnvironment.MapPath("~/images/cars/");
                        var image = frm1["addcarid"] + "_" + i + "_car" + dataStr + ".png";
                        var valuefind = frm1["hdoutput" + i];
                        byte[] bytes = System.Convert.FromBase64String(valuefind);
                        using (FileStream fs = new FileStream(filePath + image, FileMode.CreateNew, FileAccess.Write, FileShare.None))
                        {
                            fs.Write(bytes, 0, bytes.Length);
                            fs.Close();
                        }
                        WebImage supermanImage = new WebImage(Server.MapPath("~/images/cars/" + image));
                        supermanImage.AddImageWatermark(Server.MapPath("~/Content/images/logo.png"), 227, 25, "Right", "Bottom", 85, 10);
                        supermanImage.Save(Server.MapPath("~/images/cars/" + image));
                        ht.Add(i, image);
                    }
                }

            }

            con = new SqlConnection(constr);
            con.Open();
            cmd = new SqlCommand("update tbl_carmaster SET img='" + ht[0] + "',img1='" + ht[1] + "',img2='" + ht[2] + "',img3='" + ht[3] + "',img4='" + ht[4] + "',img5='" + ht[5] + "' where cid= '" + frm1["addcarid"] + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();

            // return image;
            return RedirectToAction("ManageYard", "Home");
        }

        //public ActionResult EditCarPic(HttpPostedFileBase img, HttpPostedFileBase img1, HttpPostedFileBase img2, HttpPostedFileBase img3, HttpPostedFileBase img4, HttpPostedFileBase img5, FormCollection frm1)
        //{
        //    if (img != null)
        //    {
        //        string pic = System.IO.Path.GetFileName(img.FileName);
        //        string path = System.IO.Path.Combine(
        //        Server.MapPath("~/images/cars"), frm1["addcarid"] + pic);
        //        img.SaveAs(path);
        //        WebImage supermanImage = new WebImage(Server.MapPath("~/images/cars/" + frm1["addcarid"] + pic));

        //        supermanImage.AddImageWatermark(Server.MapPath("~/Content/images/logo.png"), 227, 25, "Right", "Bottom", 85, 10);
        //        //supermanImage.AddTextWatermark("MY CARYARD", "White", 40, "Regular", "Consolas", "Right", "Top", 20, 10);

        //        supermanImage.Save(Server.MapPath("~/images/cars/" + frm1["addcarid"] + pic));

        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            img.InputStream.CopyTo(ms);
        //            byte[] array = ms.GetBuffer();
        //        }
        //        //Update Image Name1
        //        con = new SqlConnection(constr);
        //        con.Open();
        //        cmd = new SqlCommand("update tbl_carmaster SET img='" + frm1["addcarid"] + pic + "' where cid= '" + frm1["addcarid"] + "'", con);
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //    }

        //    if (img1 != null)
        //    {
        //        string pic = System.IO.Path.GetFileName(img1.FileName);
        //        string path = System.IO.Path.Combine(
        //        Server.MapPath("~/images/cars"), frm1["addcarid"] + pic);
        //        img1.SaveAs(path);
        //        WebImage supermanImage = new WebImage(Server.MapPath("~/images/cars/" + frm1["addcarid"] + pic));
        //        supermanImage.AddImageWatermark(Server.MapPath("~/Content/images/logo.png"), 227, 25, "Right", "Bottom", 85, 10);
        //        //supermanImage.AddTextWatermark("MY CARYARD", "White", 40, "Regular", "Consolas", "Right", "Top", 20, 10);

        //        supermanImage.Save(Server.MapPath("~/images/cars/" + frm1["addcarid"] + pic));

        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            img1.InputStream.CopyTo(ms);
        //            byte[] array = ms.GetBuffer();
        //        }
        //        //Update Image Name2
        //        con = new SqlConnection(constr);
        //        con.Open();
        //        cmd = new SqlCommand("update tbl_carmaster SET img1='" + frm1["addcarid"] + pic + "' where cid= '" + frm1["addcarid"] + "'", con);
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //    }

        //    if (img2 != null)
        //    {
        //        string pic = System.IO.Path.GetFileName(img2.FileName);
        //        string path = System.IO.Path.Combine(
        //        Server.MapPath("~/images/cars"), frm1["addcarid"] + pic);
        //        img2.SaveAs(path);
        //        WebImage supermanImage = new WebImage(Server.MapPath("~/images/cars/" + frm1["addcarid"] + pic));
        //        supermanImage.AddImageWatermark(Server.MapPath("~/Content/images/logo.png"), 227, 25, "Right", "Bottom", 85, 10);
        //        //supermanImage.AddTextWatermark("MY CARYARD", "White", 40, "Regular", "Consolas", "Right", "Top", 20, 10);

        //        supermanImage.Save(Server.MapPath("~/images/cars/" + frm1["addcarid"] + pic));

        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            img2.InputStream.CopyTo(ms);
        //            byte[] array = ms.GetBuffer();
        //        }
        //        con = new SqlConnection(constr);
        //        con.Open();
        //        cmd = new SqlCommand("update tbl_carmaster SET img2='" + frm1["addcarid"] + pic + "' where cid= '" + frm1["addcarid"] + "'", con);
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //    }

        //    if (img3 != null)
        //    {
        //        string pic = System.IO.Path.GetFileName(img3.FileName);
        //        string path = System.IO.Path.Combine(
        //        Server.MapPath("~/images/cars"), frm1["addcarid"] + pic);
        //        img3.SaveAs(path);
        //        WebImage supermanImage = new WebImage(Server.MapPath("~/images/cars/" + frm1["addcarid"] + pic));
        //        supermanImage.AddImageWatermark(Server.MapPath("~/Content/images/logo.png"), 227, 25, "Right", "Bottom", 85, 10);
        //        //supermanImage.AddTextWatermark("MY CARYARD", "White", 40, "Regular", "Consolas", "Right", "Top", 20, 10);

        //        supermanImage.Save(Server.MapPath("~/images/cars/" + frm1["addcarid"] + pic));

        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            img3.InputStream.CopyTo(ms);
        //            byte[] array = ms.GetBuffer();
        //        }
        //        con = new SqlConnection(constr);
        //        con.Open();
        //        cmd = new SqlCommand("update tbl_carmaster SET img3='" + frm1["addcarid"] + pic + "' where cid= '" + frm1["addcarid"] + "'", con);
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //    }

        //    if (img4 != null)
        //    {
        //        string pic = System.IO.Path.GetFileName(img4.FileName);
        //        string path = System.IO.Path.Combine(
        //        Server.MapPath("~/images/cars"), frm1["addcarid"] + pic);
        //        img4.SaveAs(path);
        //        WebImage supermanImage = new WebImage(Server.MapPath("~/images/cars/" + frm1["addcarid"] + pic));
        //        supermanImage.AddImageWatermark(Server.MapPath("~/Content/images/logo.png"), 227, 25, "Right", "Bottom", 85, 10);
        //        //supermanImage.AddTextWatermark("MY CARYARD", "White", 40, "Regular", "Consolas", "Right", "Top", 20, 10);

        //        supermanImage.Save(Server.MapPath("~/images/cars/" + frm1["addcarid"] + pic));

        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            img4.InputStream.CopyTo(ms);
        //            byte[] array = ms.GetBuffer();
        //        }
        //        con = new SqlConnection(constr);
        //        con.Open();
        //        cmd = new SqlCommand("update tbl_carmaster SET img4='" + frm1["addcarid"] + pic + "' where cid= '" + frm1["addcarid"] + "'", con);
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //    }

        //    if (img5 != null)
        //    {
        //        string pic = System.IO.Path.GetFileName(img5.FileName);
        //        string path = System.IO.Path.Combine(
        //        Server.MapPath("~/images/cars"), frm1["addcarid"] + pic);
        //        img5.SaveAs(path);
        //        WebImage supermanImage = new WebImage(Server.MapPath("~/images/cars/" + frm1["addcarid"] + pic));
        //        supermanImage.AddImageWatermark(Server.MapPath("~/Content/images/logo.png"), 227, 25, "Right", "Bottom", 85, 10);
        //        //supermanImage.AddTextWatermark("MY CARYARD", "White", 40, "Regular", "Consolas", "Right", "Top", 20, 10);

        //        supermanImage.Save(Server.MapPath("~/images/cars/" + frm1["addcarid"] + pic));

        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            img5.InputStream.CopyTo(ms);
        //            byte[] array = ms.GetBuffer();
        //        }
        //        con = new SqlConnection(constr);
        //        con.Open();
        //        cmd = new SqlCommand("update tbl_carmaster SET img5='" + frm1["addcarid"] + pic + "' where cid= '" + frm1["addcarid"] + "'", con);
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //    }

        //    return RedirectToAction("ManageYard", "Home");

        //    // change code on 3/5/2017

        //    string filePath = string.Empty;
        //    var dataStr = String.Format("{0:d/M/yyyy HH:mm:ss}", DateTime.Now);
        //    dataStr = dataStr.Replace(@"/", "").Trim(); dataStr = dataStr.Replace(@":", "").Trim(); dataStr = dataStr.Replace(" ", String.Empty);

        //    Hashtable ht = new Hashtable();
        //    for (int i = 0; i < 6; i++)
        //    {
        //        if (!string.IsNullOrEmpty(frm1["addcarid"]))
        //        {
        //            if (!string.IsNullOrEmpty(frm1["hdoutput" + i]))
        //            {
        //                filePath = HostingEnvironment.MapPath("~/images/cars/");
        //                var image = frm1["addcarid"] + i + "_car" + dataStr + ".png";
        //                var valuefind = frm1["hdoutput" + i];
        //                byte[] bytes = System.Convert.FromBase64String(valuefind);
        //                FileStream fs = new FileStream(filePath + image, FileMode.CreateNew, FileAccess.Write, FileShare.None);
        //                fs.Write(bytes, 0, bytes.Length);
        //                fs.Close();
        //                ht.Add(i, image);
        //            }
        //        }

        //    }

        //    con = new SqlConnection(constr);
        //    con.Open();
        //    cmd = new SqlCommand("update tbl_carmaster SET img='" + ht[0] + "',img1='" + ht[1] + "',img2='" + ht[2] + "',img3='" + ht[3] + "',img4='" + ht[4] + "',img5='" + ht[5] + "' where cid= '" + frm1["addcarid"] + "'", con);
        //    cmd.ExecuteNonQuery();
        //    con.Close();

        //    // return image;
        //    return RedirectToAction("ManageYard", "Home");
        //}

        //// change code on 3/5/2017

        public ActionResult EditCarPic(FormCollection frm1)
        {
            string filePath = string.Empty;
            var dataStr = String.Format("{0:d/M/yyyy HH:mm:ss}", DateTime.Now);
            dataStr = dataStr.Replace(@"/", "").Trim(); dataStr = dataStr.Replace(@":", "").Trim(); dataStr = dataStr.Replace(" ", String.Empty);

            Hashtable ht = new Hashtable();
            for (int i = 0; i < 6; i++)
            {
                if (!string.IsNullOrEmpty(frm1["addcarid"]))
                {
                    if (!string.IsNullOrEmpty(frm1["hdoutput" + i]))
                    {
                        filePath = HostingEnvironment.MapPath("~/images/cars/");
                        var image = frm1["addcarid"] + "_" + i + "_car" + dataStr + ".png";
                        var valuefind = frm1["hdoutput" + i];
                        byte[] bytes = System.Convert.FromBase64String(valuefind);
                        FileStream fs = new FileStream(filePath + image, FileMode.CreateNew, FileAccess.Write, FileShare.None);
                        fs.Write(bytes, 0, bytes.Length);
                        fs.Close();
                        WebImage supermanImage = new WebImage(Server.MapPath("~/images/cars/" + image));
                        supermanImage.AddImageWatermark(Server.MapPath("~/Content/images/logo.png"), 227, 25, "Right", "Bottom", 85, 10);
                        supermanImage.Save(Server.MapPath("~/images/cars/" + image));
                        ht.Add(i, image);
                    }
                }

            }

            con = new SqlConnection(constr);
            con.Open();
            cmd = new SqlCommand("update tbl_carmaster SET " + (ht[0] == null ? "img=img," : "img='" + ht[0] + "',") + (ht[1] == null ? "img1=img1," : "img1='" + ht[1] + "',") + (ht[2] == null ? "img2=img2," : "img2='" + ht[2] + "',") + (ht[3] == null ? "img3=img3," : "img3='" + ht[3] + "',") + (ht[4] == null ? "img4=img4," : "img4='" + ht[4] + "',") + (ht[5] == null ? "img5=img5" : "img5='" + ht[5] + "'") + " where cid= '" + frm1["addcarid"] + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();

            // return image;
            return RedirectToAction("ManageYard", "Home");
        }

        public ActionResult EditCarPicForAdmin(HttpPostedFileBase img, HttpPostedFileBase img1, HttpPostedFileBase img2, HttpPostedFileBase img3, HttpPostedFileBase img4, HttpPostedFileBase img5, FormCollection frm1)
        {
            if (img != null)
            {
                string pic = System.IO.Path.GetFileName(img.FileName);
                string path = System.IO.Path.Combine(
                Server.MapPath("~/images/cars"), frm1["addcarid"] + pic);
                img.SaveAs(path);
                WebImage supermanImage = new WebImage(Server.MapPath("~/images/cars/" + frm1["addcarid"] + pic));
                supermanImage.AddImageWatermark(Server.MapPath("~/Content/images/logo.png"), 227, 25, "Right", "Bottom", 85, 10);
                //supermanImage.AddTextWatermark("MY CARYARD", "White", 40, "Regular", "Consolas", "Right", "Top", 20, 10);

                supermanImage.Save(Server.MapPath("~/images/cars/" + frm1["addcarid"] + pic));

                using (MemoryStream ms = new MemoryStream())
                {
                    img.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }
                //Update Image Name1
                con = new SqlConnection(constr);
                con.Open();
                cmd = new SqlCommand("update tbl_carmaster SET img='" + frm1["addcarid"] + pic + "' where cid= '" + frm1["addcarid"] + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            if (img1 != null)
            {
                string pic = System.IO.Path.GetFileName(img1.FileName);
                string path = System.IO.Path.Combine(
                Server.MapPath("~/images/cars"), frm1["addcarid"] + pic);
                img1.SaveAs(path);
                WebImage supermanImage = new WebImage(Server.MapPath("~/images/cars/" + frm1["addcarid"] + pic));
                supermanImage.AddImageWatermark(Server.MapPath("~/Content/images/logo.png"), 227, 25, "Right", "Bottom", 85, 10);
                //supermanImage.AddTextWatermark("MY CARYARD", "White", 40, "Regular", "Consolas", "Right", "Top", 20, 10);

                supermanImage.Save(Server.MapPath("~/images/cars/" + frm1["addcarid"] + pic));

                using (MemoryStream ms = new MemoryStream())
                {
                    img1.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }
                //Update Image Name2
                con = new SqlConnection(constr);
                con.Open();
                cmd = new SqlCommand("update tbl_carmaster SET img1='" + frm1["addcarid"] + pic + "' where cid= '" + frm1["addcarid"] + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            if (img2 != null)
            {
                string pic = System.IO.Path.GetFileName(img2.FileName);
                string path = System.IO.Path.Combine(
                Server.MapPath("~/images/cars"), frm1["addcarid"] + pic);
                img2.SaveAs(path);
                WebImage supermanImage = new WebImage(Server.MapPath("~/images/cars/" + frm1["addcarid"] + pic));
                supermanImage.AddImageWatermark(Server.MapPath("~/Content/images/logo.png"), 227, 25, "Right", "Bottom", 85, 10);
                //supermanImage.AddTextWatermark("MY CARYARD", "White", 40, "Regular", "Consolas", "Right", "Top", 20, 10);

                supermanImage.Save(Server.MapPath("~/images/cars/" + frm1["addcarid"] + pic));

                using (MemoryStream ms = new MemoryStream())
                {
                    img2.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }
                con = new SqlConnection(constr);
                con.Open();
                cmd = new SqlCommand("update tbl_carmaster SET img2='" + frm1["addcarid"] + pic + "' where cid= '" + frm1["addcarid"] + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            if (img3 != null)
            {
                string pic = System.IO.Path.GetFileName(img3.FileName);
                string path = System.IO.Path.Combine(
                Server.MapPath("~/images/cars"), frm1["addcarid"] + pic);
                img3.SaveAs(path);
                WebImage supermanImage = new WebImage(Server.MapPath("~/images/cars/" + frm1["addcarid"] + pic));
                supermanImage.AddImageWatermark(Server.MapPath("~/Content/images/logo.png"), 227, 25, "Right", "Bottom", 85, 10);
                //supermanImage.AddTextWatermark("MY CARYARD", "White", 40, "Regular", "Consolas", "Right", "Top", 20, 10);

                supermanImage.Save(Server.MapPath("~/images/cars/" + frm1["addcarid"] + pic));

                using (MemoryStream ms = new MemoryStream())
                {
                    img3.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }
                con = new SqlConnection(constr);
                con.Open();
                cmd = new SqlCommand("update tbl_carmaster SET img3='" + frm1["addcarid"] + pic + "' where cid= '" + frm1["addcarid"] + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            if (img4 != null)
            {
                string pic = System.IO.Path.GetFileName(img4.FileName);
                string path = System.IO.Path.Combine(
                Server.MapPath("~/images/cars"), frm1["addcarid"] + pic);
                img4.SaveAs(path);
                WebImage supermanImage = new WebImage(Server.MapPath("~/images/cars/" + frm1["addcarid"] + pic));
                supermanImage.AddImageWatermark(Server.MapPath("~/Content/images/logo.png"), 227, 25, "Right", "Bottom", 85, 10);
                //supermanImage.AddTextWatermark("MY CARYARD", "White", 40, "Regular", "Consolas", "Right", "Top", 20, 10);

                supermanImage.Save(Server.MapPath("~/images/cars/" + frm1["addcarid"] + pic));

                using (MemoryStream ms = new MemoryStream())
                {
                    img4.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }
                con = new SqlConnection(constr);
                con.Open();
                cmd = new SqlCommand("update tbl_carmaster SET img4='" + frm1["addcarid"] + pic + "' where cid= '" + frm1["addcarid"] + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            if (img5 != null)
            {
                string pic = System.IO.Path.GetFileName(img5.FileName);
                string path = System.IO.Path.Combine(
                Server.MapPath("~/images/cars"), frm1["addcarid"] + pic);
                img5.SaveAs(path);
                WebImage supermanImage = new WebImage(Server.MapPath("~/images/cars/" + frm1["addcarid"] + pic));
                supermanImage.AddImageWatermark(Server.MapPath("~/Content/images/logo.png"), 227, 25, "Right", "Bottom", 85, 10);
                //supermanImage.AddTextWatermark("MY CARYARD", "White", 40, "Regular", "Consolas", "Right", "Top", 20, 10);

                supermanImage.Save(Server.MapPath("~/images/cars/" + frm1["addcarid"] + pic));

                using (MemoryStream ms = new MemoryStream())
                {
                    img5.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }
                con = new SqlConnection(constr);
                con.Open();
                cmd = new SqlCommand("update tbl_carmaster SET img5='" + frm1["addcarid"] + pic + "' where cid= '" + frm1["addcarid"] + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            string cid = frm1["cid"].ToString();
            string type = frm1["type"].ToString();
            cid = ConvertHelper.Encode(cid);
            return RedirectToAction("ApproveUserListing", "Home", new { cid = cid, type = type });
        }

        //public ActionResult UploadEventPic(HttpPostedFileBase img, HttpPostedFileBase img1, HttpPostedFileBase img2, FormCollection frm1)
        //{
        //    if (img != null)
        //    {
        //        string pic = System.IO.Path.GetFileName(img.FileName);
        //        string path = System.IO.Path.Combine(
        //        Server.MapPath("~/images/events"), frm1["eventid"] + pic);
        //        img.SaveAs(path);
        //        WebImage supermanImage = new WebImage(Server.MapPath("~/images/events/" + frm1["eventid"] + pic));
        //        supermanImage.AddImageWatermark(Server.MapPath("~/Content/images/logo.png"), 227, 25, "Right", "Bottom", 85, 10);
        //        //supermanImage.AddTextWatermark("MY CARYARD", "White", 40, "Regular", "Consolas", "Right", "Top", 20, 10);

        //        supermanImage.Save(Server.MapPath("~/images/events/" + frm1["eventid"] + pic));

        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            img.InputStream.CopyTo(ms);
        //            byte[] array = ms.GetBuffer();
        //        }
        //        //Update Image Name1
        //        con = new SqlConnection(constr);
        //        con.Open();
        //        cmd = new SqlCommand("update tbl_eventmaster SET img='" + frm1["eventid"] + pic + "' where eid= '" + frm1["eventid"] + "'", con);
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //    }

        //    if (img1 != null)
        //    {
        //        string pic = System.IO.Path.GetFileName(img1.FileName);
        //        string path = System.IO.Path.Combine(
        //        Server.MapPath("~/images/events"), frm1["eventid"] + pic);
        //        img1.SaveAs(path);
        //        WebImage supermanImage = new WebImage(Server.MapPath("~/images/events/" + frm1["eventid"] + pic));
        //        supermanImage.AddImageWatermark(Server.MapPath("~/Content/images/logo.png"), 227, 25, "Right", "Bottom", 85, 10);
        //        //supermanImage.AddTextWatermark("MY CARYARD", "White", 40, "Regular", "Consolas", "Right", "Top", 20, 10);

        //        supermanImage.Save(Server.MapPath("~/images/events/" + frm1["eventid"] + pic));

        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            img1.InputStream.CopyTo(ms);
        //            byte[] array = ms.GetBuffer();
        //        }
        //        //Update Image Name2
        //        con = new SqlConnection(constr);
        //        con.Open();
        //        cmd = new SqlCommand("update tbl_eventmaster SET img1='" + frm1["eventid"] + pic + "' where eid= '" + frm1["eventid"] + "'", con);
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //    }

        //    if (img2 != null)
        //    {
        //        string pic = System.IO.Path.GetFileName(img2.FileName);
        //        string path = System.IO.Path.Combine(
        //        Server.MapPath("~/images/events"), frm1["eventid"] + pic);
        //        img2.SaveAs(path);
        //        WebImage supermanImage = new WebImage(Server.MapPath("~/images/events/" + frm1["eventid"] + pic));
        //        supermanImage.AddImageWatermark(Server.MapPath("~/Content/images/logo.png"), 227, 25, "Right", "Bottom", 85, 10);
        //        //supermanImage.AddTextWatermark("MY CARYARD", "White", 40, "Regular", "Consolas", "Right", "Top", 20, 10);

        //        supermanImage.Save(Server.MapPath("~/images/events/" + frm1["eventid"] + pic));

        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            img2.InputStream.CopyTo(ms);
        //            byte[] array = ms.GetBuffer();
        //        }
        //        con = new SqlConnection(constr);
        //        con.Open();
        //        cmd = new SqlCommand("update tbl_eventmaster SET img2='" + frm1["eventid"] + pic + "' where eid= '" + frm1["eventid"] + "'", con);
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //    }

        //    return RedirectToAction("ManageEvent", "Home");
        //}

        //// Change on 3/5/2017
        [WebMethod]
        public JObject UploadEventPic(FormCollection frm1)
        {
            string filePath = string.Empty;
            var dataStr = String.Format("{0:d/M/yyyy HH:mm:ss}", DateTime.Now);
            dataStr = dataStr.Replace(@"/", "").Trim(); dataStr = dataStr.Replace(@":", "").Trim(); dataStr = dataStr.Replace(" ", String.Empty);

            Hashtable ht = new Hashtable();
            for (int i = 0; i < 3; i++)
            {
                if (!string.IsNullOrEmpty(frm1["eventid"]))
                {
                    if (!string.IsNullOrEmpty(frm1["hdoutput" + i]))
                    {
                        filePath = HostingEnvironment.MapPath("~/images/events/");
                        var image = frm1["eventid"] + "_" + i + "_event" + dataStr + ".png";
                        var valuefind = frm1["hdoutput" + i];
                        byte[] bytes = System.Convert.FromBase64String(valuefind);
                        FileStream fs = new FileStream(filePath + image, FileMode.CreateNew, FileAccess.Write, FileShare.None);
                        fs.Write(bytes, 0, bytes.Length);
                        fs.Close();
                        WebImage supermanImage = new WebImage(Server.MapPath("~/images/events/" + image));
                        supermanImage.AddImageWatermark(Server.MapPath("~/Content/images/logo.png"), 227, 25, "Right", "Bottom", 85, 10);
                        supermanImage.Save(Server.MapPath("~/images/events/" + image));
                        ht.Add(i, image);
                    }
                }

            }
            con = new SqlConnection(constr);
            con.Open();
            cmd = new SqlCommand("update tbl_eventmaster SET img='" + ht[0] + "',img1='" + ht[1] + "',img2='" + ht[2] + "' where eid= '" + frm1["eventid"] + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            JObject json = new JObject();
            json["status"] = "Success";
            json["eid"] = 1;// Convert.ToInt32(sqlparam[20].Value.ToString());
            return json;
            // return Json(new { isok = true, message = "Your Message" });
            //return RedirectToAction("ManageEvent", "Home");
        }

        //public ActionResult EditEventPic(HttpPostedFileBase img, HttpPostedFileBase img1, HttpPostedFileBase img2, FormCollection frm1)
        //{
        //    if (img != null)
        //    {
        //        string pic = System.IO.Path.GetFileName(img.FileName);
        //        string path = System.IO.Path.Combine(
        //        Server.MapPath("~/images/events"), frm1["eventid"] + pic);
        //        img.SaveAs(path);
        //        WebImage supermanImage = new WebImage(Server.MapPath("~/images/events/" + frm1["eventid"] + pic));
        //        supermanImage.AddImageWatermark(Server.MapPath("~/Content/images/logo.png"), 227, 25, "Right", "Bottom", 85, 10);
        //        //supermanImage.AddTextWatermark("MY CARYARD", "White", 40, "Regular", "Consolas", "Right", "Top", 20, 10);

        //        supermanImage.Save(Server.MapPath("~/images/events/" + frm1["eventid"] + pic));

        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            img.InputStream.CopyTo(ms);
        //            byte[] array = ms.GetBuffer();
        //        }
        //        //Update Image Name1
        //        con = new SqlConnection(constr);
        //        con.Open();
        //        cmd = new SqlCommand("update tbl_eventmaster SET img='" + frm1["eventid"] + pic + "' where eid= '" + frm1["eventid"] + "'", con);
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //    }

        //    if (img1 != null)
        //    {
        //        string pic = System.IO.Path.GetFileName(img1.FileName);
        //        string path = System.IO.Path.Combine(
        //        Server.MapPath("~/images/events"), frm1["eventid"] + pic);
        //        img1.SaveAs(path);
        //        WebImage supermanImage = new WebImage(Server.MapPath("~/images/events/" + frm1["eventid"] + pic));
        //        supermanImage.AddImageWatermark(Server.MapPath("~/Content/images/logo.png"), 227, 25, "Right", "Bottom", 85, 10);
        //        // supermanImage.AddTextWatermark("MY CARYARD", "White", 40, "Regular", "Consolas", "Right", "Top", 20, 10);

        //        supermanImage.Save(Server.MapPath("~/images/events/" + frm1["eventid"] + pic));

        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            img1.InputStream.CopyTo(ms);
        //            byte[] array = ms.GetBuffer();
        //        }
        //        //Update Image Name2
        //        con = new SqlConnection(constr);
        //        con.Open();
        //        cmd = new SqlCommand("update tbl_eventmaster SET img1='" + frm1["eventid"] + pic + "' where eid= '" + frm1["eventid"] + "'", con);
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //    }

        //    if (img2 != null)
        //    {
        //        string pic = System.IO.Path.GetFileName(img2.FileName);
        //        string path = System.IO.Path.Combine(
        //        Server.MapPath("~/images/events"), frm1["eventid"] + pic);
        //        img2.SaveAs(path);
        //        WebImage supermanImage = new WebImage(Server.MapPath("~/images/events/" + frm1["eventid"] + pic));
        //        supermanImage.AddImageWatermark(Server.MapPath("~/Content/images/logo.png"), 227, 25, "Right", "Bottom", 85, 10);
        //        //supermanImage.AddTextWatermark("MY CARYARD", "White", 40, "Regular", "Consolas", "Right", "Top", 20, 10);

        //        supermanImage.Save(Server.MapPath("~/images/events/" + frm1["eventid"] + pic));

        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            img2.InputStream.CopyTo(ms);
        //            byte[] array = ms.GetBuffer();
        //        }
        //        con = new SqlConnection(constr);
        //        con.Open();
        //        cmd = new SqlCommand("update tbl_eventmaster SET img2='" + frm1["eventid"] + pic + "' where eid= '" + frm1["eventid"] + "'", con);
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //    }

        //    return RedirectToAction("ManageEvent", "Home");
        //}

        //// change on 3/5/2017

        public ActionResult EditEventPic(FormCollection frm1)
        {
            string filePath = string.Empty;
            var dataStr = String.Format("{0:d/M/yyyy HH:mm:ss}", DateTime.Now);
            dataStr = dataStr.Replace(@"/", "").Trim(); dataStr = dataStr.Replace(@":", "").Trim(); dataStr = dataStr.Replace(" ", String.Empty);

            Hashtable ht = new Hashtable();
            for (int i = 0; i < 3; i++)
            {
                if (!string.IsNullOrEmpty(frm1["eventid"]))
                {
                    if (!string.IsNullOrEmpty(frm1["hdoutput" + i]))
                    {
                        filePath = HostingEnvironment.MapPath("~/images/events/");
                        var image = frm1["eventid"] + "_" + i + "_event" + dataStr + ".png";
                        var valuefind = frm1["hdoutput" + i];
                        byte[] bytes = System.Convert.FromBase64String(valuefind);
                        FileStream fs = new FileStream(filePath + image, FileMode.CreateNew, FileAccess.Write, FileShare.None);
                        fs.Write(bytes, 0, bytes.Length);
                        fs.Close();
                        WebImage supermanImage = new WebImage(Server.MapPath("~/images/events/" + image));
                        supermanImage.AddImageWatermark(Server.MapPath("~/Content/images/logo.png"), 227, 25, "Right", "Bottom", 85, 10);
                        supermanImage.Save(Server.MapPath("~/images/events/" + image));
                        ht.Add(i, image);
                    }
                }

            }
            con = new SqlConnection(constr);
            con.Open();
            cmd = new SqlCommand("update tbl_eventmaster SET " + (ht[0] == null ? "img=img," : "img='" + ht[0] + "',") + (ht[1] == null ? "img1=img1," : "img1='" + ht[1] + "',") + (ht[2] == null ? "img2=img2" : "img2='" + ht[2] + "'") + " where eid= '" + frm1["eventid"] + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();

            return RedirectToAction("ManageEvent", "Home");
        }

        public ActionResult EditEventPicForAdmin(HttpPostedFileBase img, HttpPostedFileBase img1, HttpPostedFileBase img2, FormCollection frm1)
        {
            if (img != null)
            {
                string pic = System.IO.Path.GetFileName(img.FileName);
                string path = System.IO.Path.Combine(
                Server.MapPath("~/images/events"), frm1["eventid"] + pic);
                img.SaveAs(path);
                WebImage supermanImage = new WebImage(Server.MapPath("~/images/events/" + frm1["eventid"] + pic));
                supermanImage.AddImageWatermark(Server.MapPath("~/Content/images/logo.png"), 227, 25, "Right", "Bottom", 85, 10);
                //supermanImage.AddTextWatermark("MY CARYARD", "White", 40, "Regular", "Consolas", "Right", "Top", 20, 10);

                supermanImage.Save(Server.MapPath("~/images/events/" + frm1["eventid"] + pic));

                using (MemoryStream ms = new MemoryStream())
                {
                    img.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }
                //Update Image Name1
                con = new SqlConnection(constr);
                con.Open();
                cmd = new SqlCommand("update tbl_eventmaster SET img='" + frm1["eventid"] + pic + "' where eid= '" + frm1["eventid"] + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            if (img1 != null)
            {
                string pic = System.IO.Path.GetFileName(img1.FileName);
                string path = System.IO.Path.Combine(
                Server.MapPath("~/images/events"), frm1["eventid"] + pic);
                img1.SaveAs(path);
                WebImage supermanImage = new WebImage(Server.MapPath("~/images/events/" + frm1["eventid"] + pic));
                supermanImage.AddImageWatermark(Server.MapPath("~/Content/images/logo.png"), 227, 25, "Right", "Bottom", 85, 10);
                //supermanImage.AddTextWatermark("MY CARYARD", "White", 40, "Regular", "Consolas", "Right", "Top", 20, 10);

                supermanImage.Save(Server.MapPath("~/images/events/" + frm1["eventid"] + pic));

                using (MemoryStream ms = new MemoryStream())
                {
                    img1.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }
                //Update Image Name2
                con = new SqlConnection(constr);
                con.Open();
                cmd = new SqlCommand("update tbl_eventmaster SET img1='" + frm1["eventid"] + pic + "' where eid= '" + frm1["eventid"] + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            if (img2 != null)
            {
                string pic = System.IO.Path.GetFileName(img2.FileName);
                string path = System.IO.Path.Combine(
                Server.MapPath("~/images/events"), frm1["eventid"] + pic);
                img2.SaveAs(path);
                WebImage supermanImage = new WebImage(Server.MapPath("~/images/events/" + frm1["eventid"] + pic));
                supermanImage.AddImageWatermark(Server.MapPath("~/Content/images/logo.png"), 227, 25, "Right", "Bottom", 85, 10);
                //supermanImage.AddTextWatermark("MY CARYARD", "White", 40, "Regular", "Consolas", "Right", "Top", 20, 10);

                supermanImage.Save(Server.MapPath("~/images/events/" + frm1["eventid"] + pic));

                using (MemoryStream ms = new MemoryStream())
                {
                    img2.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }
                con = new SqlConnection(constr);
                con.Open();
                cmd = new SqlCommand("update tbl_eventmaster SET img2='" + frm1["eventid"] + pic + "' where eid= '" + frm1["eventid"] + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            string cid = frm1["cid"].ToString();
            string type = frm1["type"].ToString();
            cid = ConvertHelper.Encode(cid);
            return RedirectToAction("ApproveUserListing", "Home", new { cid = cid, type = type });
        }

        //public ActionResult UploadBusinessLogo(HttpPostedFileBase buslogo, FormCollection frm1)
        //{
        //    if (buslogo != null)
        //    {
        //        string pic = System.IO.Path.GetFileName(buslogo.FileName);
        //        string path = System.IO.Path.Combine(
        //        Server.MapPath("~/images/logos"), frm1["custlid"] + pic);
        //        buslogo.SaveAs(path);
        //        WebImage supermanImage = new WebImage(Server.MapPath("~/images/logos/" + frm1["custlid"] + pic));

        //        supermanImage.AddTextWatermark("MY CARYARD", "White", 40, "Regular", "Consolas", "Right", "Top", 20, 10);

        //        supermanImage.Save(Server.MapPath("~/images/logos/" + frm1["custlid"] + pic));

        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            buslogo.InputStream.CopyTo(ms);
        //            byte[] array = ms.GetBuffer();
        //        }
        //        //Update Image Name1
        //        con = new SqlConnection(constr);
        //        con.Open();
        //        cmd = new SqlCommand("update tbl_login SET buslogo='" + frm1["custlid"] + pic + "' where id= '" + frm1["custlid"] + "'", con);
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //    }



        //    return RedirectToAction("UserProfile", "Home");
        //}
        public ActionResult UploadBusinessLogo(FormCollection frm1)
        {
            string filePath = string.Empty;
            var dataStr = String.Format("{0:d/M/yyyy HH:mm:ss}", DateTime.Now);
            dataStr = dataStr.Replace(@"/", "").Trim(); dataStr = dataStr.Replace(@":", "").Trim(); dataStr = dataStr.Replace(" ", String.Empty);

            if (!string.IsNullOrEmpty(frm1["hdoutput"]))
            {
                filePath = HostingEnvironment.MapPath("~/images/logos/");
                var image = frm1["custlid"] + "_" + dataStr + ".png";
                var valuefind = frm1["hdoutput"];
                byte[] bytes = System.Convert.FromBase64String(valuefind);
                using (FileStream fs = new FileStream(filePath + image, FileMode.CreateNew, FileAccess.Write, FileShare.None))
                {
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Close();
                }
                WebImage supermanImage = new WebImage(Server.MapPath("~/images/logos/" + image));
                supermanImage.AddTextWatermark("MY CARYARD", "White", 40, "Regular", "Consolas", "Right", "Top", 20, 10);
                supermanImage.Save(Server.MapPath("~/images/logos/" + image));
                //Update Image Name1
                con = new SqlConnection(constr);
                con.Open();
                cmd = new SqlCommand("update tbl_login SET buslogo='" + image + "' where id= '" + frm1["custlid"] + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            return RedirectToAction("UserProfile", "Home");
        }

        public ActionResult UpdateBusinessLogo(HttpPostedFileBase buslogo, FormCollection frm1)
        {
            if (buslogo != null)
            {
                string pic = System.IO.Path.GetFileName(buslogo.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/images/logos"), frm1["custlid"] + pic);
                buslogo.SaveAs(path);
                WebImage supermanImage = new WebImage(Server.MapPath("~/images/logos/" + frm1["custlid"] + pic));

                supermanImage.AddTextWatermark("MY CARYARD", "White", 40, "Regular", "Consolas", "Right", "Top", 20, 10);

                supermanImage.Save(Server.MapPath("~/images/logos/" + frm1["custlid"] + pic));

                using (MemoryStream ms = new MemoryStream())
                {
                    buslogo.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }
                //Update Image Name1
                con = new SqlConnection(constr);
                con.Open();
                cmd = new SqlCommand("update tbl_login SET buslogo='" + frm1["custlid"] + pic + "' where id= '" + frm1["custlid"] + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }



            return RedirectToAction("UserProfile", "Home");
        }

        public ActionResult AddBusinessLogo(HttpPostedFileBase buslogo, FormCollection frmlogoupdate)
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
        [AuthonticateUserHelper]
        public ActionResult AddCar()
        {
            return View();
        }
        [AuthonticateUserHelper]
        public ActionResult AddEvent()
        {
            return View();
        }
        [AuthonticateUserHelper]
        public ActionResult Currency()
        {

            DataTable dt = new DataTable();
            List<CurrencyModel> currencylist = new List<CurrencyModel>();
            CurrencyModel model = new CurrencyModel();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("GetCurrency", con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            currencylist.Add(new CurrencyModel
                            {
                                cur_id = Convert.ToInt32(dt.Rows[i]["cur_id"].ToString()),
                                currency = dt.Rows[i]["currency"].ToString(),
                                count_id = Convert.ToInt32(dt.Rows[i]["count_id"].ToString()),
                                count_name = dt.Rows[i]["country_name"].ToString(),
                                status = Convert.ToInt32(dt.Rows[i]["status"].ToString())
                            });
                        }
                    }

                }
            }
            model.currencylist = currencylist;
            return View("Currency", model);

            //return View();
        }

        [AuthonticateUserHelper]
        public ActionResult ApproveListing(string type)
        {

            ApproveListModel model = new ApproveListModel();
            model.listtype = type;
            con = new SqlConnection(constr);
            List<ApproveListModel> UserList = new List<ApproveListModel>();
            JObject json = new JObject();
            SqlCommand com;
            if (type == "appr")
            {
                com = new SqlCommand("select a.*,(select count(*) from tbl_carmaster  where status = '1' and uid=a.id) as 'pendingcount',(select count(*) from tbl_eventmaster  where status = '1' and uid=a.id) as 'eventpendingcount' from tbl_login a where a.id IN (select uid from tbl_carmaster where status=1) or a.id IN (select uid from tbl_eventmaster where status=1)  and a.type != 'Super' order by a.id desc", con);//GetAllCustomerListing
            }
            else if (type == "nappr")
            {
                com = new SqlCommand("select a.*,(select count(*) from tbl_carmaster b where b.status = '2' and b.uid=a.id) as 'pendingcount',(select count(*) from tbl_eventmaster b where b.status = '2' and b.uid=a.id) as 'eventpendingcount' from tbl_login a where a.id IN (select uid from tbl_carmaster where status=2) or a.id IN (select uid from tbl_eventmaster where status=2)  and a.type != 'Super' order by a.id desc", con);//select a.*,(select count(*) from tbl_carmaster b where b.status = '0' and b.uid=a.id) as 'pendingcount' from tbl_login a where a.type != 'Super' order by a.id desc
            }
            else
            {
                // com = new SqlCommand("select a.*,(select count(*) from tbl_carmaster b where b.status = '0' and b.uid=a.id) as 'pendingcount',(select count(*) from tbl_eventmaster b where b.status = '0' and b.uid=a.id) as 'eventpendingcount' from tbl_login a where a.status= 0 AND (a.id IN (select uid from tbl_carmaster where status=0) or a.id IN (select uid from tbl_eventmaster where status=0) ) and a.type != 'Super' order by a.id desc", con);//select a.*,(select count(*) from tbl_carmaster b where b.status = '0' and b.uid=a.id) as 'pendingcount' from tbl_login a where a.type != 'Super' order by a.id desc
                com = new SqlCommand("select a.*,(select count(*) from tbl_carmaster b where b.status = '0' and b.uid=a.id) as 'pendingcount',(select count(*) from tbl_eventmaster b where b.status = '0' and b.uid=a.id) as 'eventpendingcount' from tbl_login a where a.id IN (select uid from tbl_carmaster where status=0) or a.id IN (select uid from tbl_eventmaster where status=0)  and a.type != 'Super' order by a.id desc", con);//select a.*,(select count(*) from tbl_carmaster b where b.status = '0' and b.uid=a.id) as 'pendingcount' from tbl_login a where a.type != 'Super' order by a.id desc

                ///Change Query in 26/4/2017 
                ///select a.*,(select count(*) from tbl_carmaster b where b.status = '0' and b.uid=a.id) as 'pendingcount',(select count(*) from tbl_eventmaster b where b.status = '0' and b.uid=a.id) as 'eventpendingcount' from tbl_login a where a.id IN (select uid from tbl_carmaster where status=0) or a.id IN (select uid from tbl_eventmaster where status=0)  and a.type != 'Super' order by a.id desc
            }
            //com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind EmpModel generic list using dataRow 
            foreach (DataRow dr in dt.Rows)
            {
                UserList.Add(
                    new ApproveListModel
                    {
                        id = ConvertHelper.Encode(dr["id"].ToString()),
                        name = Convert.ToString(dr["name"].ToString()),
                        email = Convert.ToString(dr["email"].ToString()),
                        type = dr["type"].ToString(),
                        status = Convert.ToInt32(dr["status"].ToString()),
                        pendingcount = Convert.ToInt32(dr["pendingcount"].ToString()),
                        eventcount = dr["eventpendingcount"].ToString(),
                        orgname = dr["orgname"].ToString(),
                        listid = dr["cust_id"].ToString()


                    }
                    );
            }

            model.userlist = UserList;

            return View(model);


        }

        [AuthonticateUserHelper]
        public ActionResult ApproveUserListing(string cid, string type)
        {
            cid = ConvertHelper.Decode(cid);
            SqlCommand com;
            ApproveUserListModel model = new ApproveUserListModel();
            model.uid = Convert.ToInt32(cid);
            model.listype = type;
            con = new SqlConnection(constr);
            List<ApproveUserListModel> UserList = new List<ApproveUserListModel>();

            if (type == "appr")
            {
                com = new SqlCommand("select a.*,b.make_type,c.model as 'modelname',d.badge_type from tbl_carmaster a,MakeTypeMaster b,ModelMaster c,BadgeTypeMaster d where d.bad_id=a.badge and c.model_id=a.model and b.make_id=a.make and a.uid ='" + cid + "' and a.status = '1' order by a.cid desc", con);
            }
            else if (type == "nappr")
            {
                com = new SqlCommand("select a.*,b.make_type,c.model as 'modelname',d.badge_type from tbl_carmaster a,MakeTypeMaster b,ModelMaster c,BadgeTypeMaster d where d.bad_id=a.badge and c.model_id=a.model and b.make_id=a.make and a.uid ='" + cid + "' and a.status = '2' order by a.cid desc", con);

            }
            else
            {
                com = new SqlCommand("select a.*,b.make_type,c.model as 'modelname',d.badge_type from tbl_carmaster a,MakeTypeMaster b,ModelMaster c,BadgeTypeMaster d where d.bad_id=a.badge and c.model_id=a.model and b.make_id=a.make and a.uid ='" + cid + "' and a.status = '0' order by a.cid desc", con);
            }


            //com.CommandType = CommandType.StoredProcedure;
            //com.Parameters.AddWithValue("@cid", cid);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind EmpModel generic list using dataRow 
            foreach (DataRow dr in dt.Rows)
            {
                UserList.Add(
                    new ApproveUserListModel
                    {
                        cid = ConvertHelper.Encode(dr["cid"].ToString()),
                        make = dr["make_type"].ToString(),
                        model = dr["modelname"].ToString(),
                        badge = dr["badge_type"].ToString(),
                        status = Convert.ToInt32(dr["status"].ToString()),
                        listingid = dr["listid"].ToString(),
                        addeddate = Convert.ToDateTime(dr["created_date"].ToString()).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)

                    }
                    );
            }

            List<EventViewModel> eventlist = new List<EventViewModel>();


            if (type == "appr")
            {
                com = new SqlCommand("SELECT  b.country_name,c.state_name,a.*,d.name from tbl_eventmaster a,tbl_country_master b,tbl_state_master c,tbl_login d where b.count_id=a.country and c.state_id=a.state and  d.id=a.uid and a.uid='" + cid + "' and a.status = '1'  ORDER BY a.eid DESC", con);
            }
            else if (type == "nappr")
            {
                com = new SqlCommand("SELECT  b.country_name,c.state_name,a.*,d.name from tbl_eventmaster a,tbl_country_master b,tbl_state_master c,tbl_login d where b.count_id=a.country and c.state_id=a.state and  d.id=a.uid and a.uid='" + cid + "' and a.status = '2'  ORDER BY a.eid DESC", con);

            }
            else
            {
                com = new SqlCommand("SELECT  b.country_name,c.state_name,a.*,d.name from tbl_eventmaster a,tbl_country_master b,tbl_state_master c,tbl_login d where b.count_id=a.country and c.state_id=a.state and  d.id=a.uid and a.uid='" + cid + "' and a.status = '0'  ORDER BY a.eid DESC", con);
            }



            //com = new SqlCommand("GetAllEventList", con);

            //com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@cid", cid);
            da = new SqlDataAdapter(com);
            dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind EmpModel generic list using dataRow 
            foreach (DataRow dr in dt.Rows)
            {
                eventlist.Add(
                    new EventViewModel
                    {
                        eid = ConvertHelper.Encode(dr["eid"].ToString()),
                        title = dr["title"].ToString(),
                        subject = dr["subject"].ToString(),
                        date = Convert.ToDateTime(dr["edate"].ToString()).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                        status = Convert.ToInt32(dr["status"].ToString()),
                        listingid = dr["listid"].ToString()


                    }
                    );
            }

            model.approveeventlist = eventlist;
            model.approveuserlist = UserList;

            return View(model);


        }

        [AuthonticateUserHelper]
        public ActionResult ApproveCarDetail(string cid, string type)
        {
            cid = ConvertHelper.Decode(cid);
            ApproveUserListModel model = new ApproveUserListModel();

            con = new SqlConnection(constr);
            List<ApproveUserListModel> UserList = new List<ApproveUserListModel>();
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("GetCarDetailById", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@cid", cid);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind EmpModel generic list using dataRow 
            foreach (DataRow dr in dt.Rows)
            {
                model = new ApproveUserListModel()
                {
                    uid = Convert.ToInt32(dr["uid"].ToString()),
                    cid = dr["cid"].ToString(),
                    addeddate = Convert.ToDateTime(dr["created_date"].ToString()).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    make = dr["make"].ToString(),
                    model = dr["model"].ToString(),
                    badge = dr["badge"].ToString(),
                    series = dr["series"].ToString(),
                    currency = dr["cur_id"].ToString(),
                    price = dr["price"].ToString(),
                    year = Convert.ToInt32(dr["year"].ToString()),
                    list = dr["list"].ToString(),
                    condition = dr["condition"].ToString(),
                    body_type = dr["body_type"].ToString(),
                    bcolor = dr["bcolor"].ToString(),
                    icolor = dr["icolor"].ToString(),
                    material = dr["material"].ToString(),
                    tranmition = dr["transmition"].ToString(),
                    speedtype = dr["speedtype"].ToString(),
                    drive = dr["drive"].ToString(),
                    cylinder = Convert.ToInt32(dr["cylinder"].ToString()),
                    meter = dr["meter"].ToString(),
                    matrics = dr["matrics"].ToString(),
                    engine = dr["engine"].ToString(),
                    fuel = dr["fuel"].ToString(),
                    descr = dr["descr"].ToString(),
                    gstatus = dr["gstatus"].ToString(),
                    status = Convert.ToInt32(dr["status"].ToString()),
                    listype = type,
                    listingid = dr["listid"].ToString(),
                    img = dr["img"].ToString(),
                    img1 = dr["img1"].ToString(),
                    img2 = dr["img2"].ToString(),
                    img3 = dr["img3"].ToString(),
                    img4 = dr["img4"].ToString(),
                    img5 = dr["img5"].ToString()



                };
            }



            return View(model);


        }

        [AuthonticateUserHelper]
        public ActionResult ApproveEventDetail(string eid, string type)
        {

            eid = ConvertHelper.Decode(eid);
            DataTable dt = new DataTable();
            List<EventViewModel> eventlist1 = new List<EventViewModel>();

            ApproveUserListModel eventmodel = new ApproveUserListModel();
            eventmodel.listype = type;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("GetEventDetails", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@eid", eid);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            eventlist1.Add(new EventViewModel
                            {

                                eid = dt.Rows[i]["eid"].ToString(),
                                uid = Convert.ToInt32(dt.Rows[i]["uid"].ToString()),
                                title = dt.Rows[i]["title"].ToString(),
                                subject = dt.Rows[i]["subject"].ToString(),
                                date = Convert.ToDateTime(dt.Rows[i]["edate"].ToString()).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                                time = dt.Rows[i]["etime"].ToString(),
                                address = dt.Rows[i]["address"].ToString(),
                                cno = dt.Rows[i]["cno"].ToString(),
                                country = dt.Rows[i]["country"].ToString(),
                                state = dt.Rows[i]["state"].ToString(),
                                city = dt.Rows[i]["city"].ToString(),
                                descr = dt.Rows[i]["descr"].ToString(),
                                late = dt.Rows[i]["late"].ToString(),
                                lonz = dt.Rows[i]["long"].ToString(),
                                status = Convert.ToInt32(dt.Rows[i]["status"].ToString()),
                                img = dt.Rows[i]["img"].ToString(),
                                img1 = dt.Rows[i]["img1"].ToString(),
                                img2 = dt.Rows[i]["img2"].ToString(),
                                reason = dt.Rows[i]["reason"].ToString(),
                                //suburb = dt.Rows[i]["suburb"].ToString(),
                                code = dt.Rows[i]["code"].ToString(),
                                unit = dt.Rows[i]["unit"].ToString(),
                                street = dt.Rows[i]["street"].ToString(),
                                sname = dt.Rows[i]["sname"].ToString(),
                                cat = Convert.ToInt32(dt.Rows[i]["cat"].ToString()),
                                price = Convert.ToInt32(dt.Rows[i]["price"].ToString()),
                                ispaid = Convert.ToInt32(dt.Rows[i]["ispaid"].ToString()),
                                showphone = Convert.ToInt32(dt.Rows[i]["shownumber"].ToString()),
                                listingid = dt.Rows[i]["listid"].ToString(),
                                sponsorship = dt.Rows[i]["sponsorship"].ToString()


                            });
                        }
                    }

                }
            }

            eventmodel.approveeventlist = eventlist1;
            return View(eventmodel);


        }

        [AuthonticateUserHelper]
        public ActionResult EditUserCar(string cid)
        {
            cid = ConvertHelper.Decode(cid);

            ApproveUserListModel model = new ApproveUserListModel();
            con = new SqlConnection(constr);
            List<ApproveUserListModel> UserList = new List<ApproveUserListModel>();
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("GetCarDetailById", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@cid", cid);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind EmpModel generic list using dataRow 
            foreach (DataRow dr in dt.Rows)
            {
                model = new ApproveUserListModel()
                {
                    uid = Convert.ToInt32(dr["uid"].ToString()),
                    cid = dr["cid"].ToString(),
                    addeddate = Convert.ToDateTime(dr["created_date"].ToString()).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    make = dr["make"].ToString(),
                    model = dr["model"].ToString(),
                    badge = dr["badge"].ToString(),
                    series = dr["series"].ToString(),
                    currency = dr["cur_id"].ToString(),
                    price = dr["price"].ToString(),
                    year = Convert.ToInt32(dr["year"].ToString()),
                    list = dr["list"].ToString(),
                    condition = dr["condition"].ToString(),
                    body_type = dr["body_type"].ToString(),
                    bcolor = dr["bcolor"].ToString(),
                    icolor = dr["icolor"].ToString(),
                    material = dr["material"].ToString(),
                    tranmition = dr["transmition"].ToString(),
                    speedtype = dr["speedtype"].ToString(),
                    drive = dr["drive"].ToString(),
                    cylinder = Convert.ToInt32(dr["cylinder"].ToString()),
                    meter = dr["meter"].ToString(),
                    matrics = dr["matrics"].ToString(),
                    engine = dr["engine"].ToString(),
                    fuel = dr["fuel"].ToString(),
                    descr = dr["descr"].ToString(),
                    gstatus = dr["gstatus"].ToString(),
                    status = Convert.ToInt32(dr["status"].ToString()),
                    img = dr["img"].ToString(),
                    img1 = dr["img1"].ToString(),
                    img2 = dr["img2"].ToString(),
                    img3 = dr["img3"].ToString(),
                    img4 = dr["img4"].ToString(),
                    img5 = dr["img5"].ToString(),
                    listingid = dr["listid"].ToString(),



                };
            }



            return View(model);


        }

        [AuthonticateUserHelper]
        public ActionResult EditEvent(string eid)

        {

            eid = ConvertHelper.Decode(eid);


            //return View();            
            DataTable dt = new DataTable();
            List<EventViewModel> eventlist1 = new List<EventViewModel>();

            ApproveUserListModel eventmodel = new ApproveUserListModel();
            SqlConnection con = new SqlConnection(constr);

            SqlCommand cmd = new SqlCommand("GetEventDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@eid", eid);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    eventlist1.Add(new EventViewModel
                    {

                        eid = dt.Rows[i]["eid"].ToString(),
                        uid = Convert.ToInt32(dt.Rows[i]["uid"].ToString()),
                        title = dt.Rows[i]["title"].ToString(),
                        subject = dt.Rows[i]["subject"].ToString(),
                        date = Convert.ToDateTime(dt.Rows[i]["edate"].ToString()).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                        time = dt.Rows[i]["etime"].ToString(),
                        address = dt.Rows[i]["address"].ToString(),
                        cno = dt.Rows[i]["cno"].ToString(),
                        country = dt.Rows[i]["country"].ToString(),
                        state = dt.Rows[i]["state"].ToString(),
                        city = dt.Rows[i]["city"].ToString(),
                        descr = dt.Rows[i]["descr"].ToString(),
                        late = dt.Rows[i]["late"].ToString(),
                        lonz = dt.Rows[i]["long"].ToString(),
                        status = Convert.ToInt32(dt.Rows[i]["status"].ToString()),
                        img = dt.Rows[i]["img"].ToString(),
                        img1 = dt.Rows[i]["img1"].ToString(),
                        img2 = dt.Rows[i]["img2"].ToString(),
                        reason = dt.Rows[i]["reason"].ToString(),
                        suburb = dt.Rows[i]["suburb"].ToString(),
                        code = dt.Rows[i]["code"].ToString(),
                        unit = dt.Rows[i]["unit"].ToString(),
                        street = dt.Rows[i]["street"].ToString(),
                        sname = dt.Rows[i]["sname"].ToString(),
                        cat = Convert.ToInt32(dt.Rows[i]["cat"].ToString()),
                        price = Convert.ToInt32(dt.Rows[i]["price"].ToString()),
                        ispaid = Convert.ToInt32(dt.Rows[i]["ispaid"].ToString()),
                        showphone = Convert.ToInt32(dt.Rows[i]["shownumber"].ToString()),
                        listingid = dt.Rows[i]["listid"].ToString(),
                        sponsorship = dt.Rows[i]["sponsorship"].ToString(),
                        sponsorname = dt.Rows[i]["sponsorname"].ToString()
                    });
                }
            }


            eventmodel.approveeventlist = eventlist1;
            return View(eventmodel);
        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        public JObject GetPlanById(int plan_id)
        {

            JObject json = new JObject();
            List<PlanModel> planlist = new List<Models.PlanModel>();
            con = new SqlConnection(constr);
            con.Open();
            cmd = new SqlCommand("GetPlanById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@plan_id", SqlDbType.Int).Value = plan_id;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                planlist.Add(new PlanModel
                {

                    plan_id = Convert.ToInt32(dr["plan_id"].ToString()),
                    plan_name = dr["plan_name"].ToString(),
                    duration = Convert.ToInt32(dr["duration"].ToString()),
                    amnt = Convert.ToInt32(dr["amnt"].ToString()),
                    status = Convert.ToInt32(dr["status"].ToString())


                });
            }
            json["planlist"] = JToken.FromObject(planlist);
            dr.Close();
            con.Close();
            return json;
        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        public JObject CarCount()
        {
            con = new SqlConnection(constr);
            List<UserListModel> UserList = new List<UserListModel>();
            JObject json = new JObject();
            con.Open();
            SqlCommand com = new SqlCommand("CarCount", con);
            com.CommandType = CommandType.StoredProcedure;
            dr = com.ExecuteReader();
            int totalcars = 0;
            if (dr.Read())
            {
                totalcars = Convert.ToInt32(dr[0].ToString());

            }
            dr.Close();
            con.Close();
            json["totalcars"] = totalcars.ToString();
            return json;
        }

        [HttpGet]
        [AllowAnonymous]
        [WebMethod]
        public JObject GetAllUser()
        {
            con = new SqlConnection(constr);
            List<UserListModel> UserList = new List<UserListModel>();
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("getAllCustomers", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind EmpModel generic list using dataRow 
            foreach (DataRow dr in dt.Rows)
            {
                UserList.Add(
                    new UserListModel
                    {
                        id = dr["id"].ToString(),
                        name = Convert.ToString(dr["name"].ToString()),
                        email = Convert.ToString(dr["email"].ToString()),
                        type = dr["type"].ToString(),
                        late = dr["late"].ToString(),
                        lonz = dr["long"].ToString(),
                        status = Convert.ToInt32(dr["status"].ToString())
                    }
                    );
            }
            json["userlist"] = JToken.FromObject(UserList);
            return json;
        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        public JObject GetLeteLong()
        {
            con = new SqlConnection(constr);
            List<UserListModel> UserList = new List<UserListModel>();
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("getlatelong", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind EmpModel generic list using dataRow 
            foreach (DataRow dr in dt.Rows)
            {
                UserList.Add(
                    new UserListModel
                    {
                        id = ConvertHelper.Encode(dr["id"].ToString()),
                        street = dr["street"].ToString(),
                        countryname = dr["countryname"].ToString(),
                        statename = dr["statename"].ToString(),
                        zip = dr["zip"].ToString(),
                        resonname = dr["resonname"].ToString(),
                        streetname = dr["streetname"].ToString(),
                        name = Convert.ToString(dr["name"].ToString()),
                        email = Convert.ToString(dr["email"].ToString()),
                        type = dr["type"].ToString(),
                        late = dr["late"].ToString(),
                        lonz = dr["long"].ToString(),
                        status = Convert.ToInt32(dr["status"].ToString()),
                        logo = dr["buslogo"].ToString(),
                        carcount = dr["carcount"].ToString(),
                        eventcount = dr["eventcount"].ToString()

                    }
                    );
            }
            json["userlist"] = JToken.FromObject(UserList);
            return json;
        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        public JObject GetLeteLongEvent()
        {
            con = new SqlConnection(constr);
            List<EventModel> UserList = new List<EventModel>();
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("getlatelongevent", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind EmpModel generic list using dataRow 
            foreach (DataRow dr in dt.Rows)
            {
                UserList.Add(
                    new EventModel
                    {
                        eid = ConvertHelper.Encode(dr["eid"].ToString()),
                        category = dr["category"].ToString(),
                        img = dr["img"].ToString(),
                        title = Convert.ToString(dr["title"].ToString()),
                        subject = Convert.ToString(dr["subject"].ToString()),
                        date = Convert.ToDateTime(dr["edate"].ToString()).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                        // type = dr["type"].ToString(),
                        late = dr["late"].ToString(),
                        lonz = dr["long"].ToString(),
                        status = Convert.ToInt32(dr["status"].ToString()),
                        going = dr["going"].ToString(),
                        country_name = dr["country_name"].ToString(),
                        state_name = dr["state_name"].ToString(),
                        city_name = dr["city_name"].ToString(),
                        postcode = dr["code"].ToString(),
                    }
                    );
            }
            json["userlist"] = JToken.FromObject(UserList);
            return json;
        }

        public JObject GetCountry()
        {
            con = new SqlConnection(constr);
            List<CountryMasterModel> countrylist = new List<CountryMasterModel>();
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("GetCountry", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                countrylist.Add(
                    new CountryMasterModel
                    {
                        count_id = Convert.ToInt32(dr["count_id"].ToString()),
                        countryname = dr["country_name"].ToString(),
                        status = Convert.ToInt32(dr["status"].ToString()),
                        carcount = Convert.ToInt32(dr["carcount"].ToString()),
                        eventcount = Convert.ToInt32(dr["eventcount"].ToString()),
                    });
            }
            json["countrylist"] = JToken.FromObject(countrylist);
            return json;
        }

        public JObject FetchCountry(int count_id)
        {
            con = new SqlConnection(constr);
            List<CountryMasterModel> countrylist = new List<CountryMasterModel>();
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("FetchCountry", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            com.Parameters.AddWithValue("@count_id", count_id);
            da.Fill(dt);
            con.Close();
            if (dt.Rows.Count > 0)
            {
                countrylist.Add(
                    new CountryMasterModel
                    {
                        count_id = Convert.ToInt32(dt.Rows[0]["count_id"].ToString()),
                        countryname = dt.Rows[0]["country_name"].ToString(),
                        status = Convert.ToInt32(dt.Rows[0]["status"].ToString())
                    });
            }
            json["countrylist"] = JToken.FromObject(countrylist);
            return json;
        }
        public JObject FetchState(int state_id)
        {
            con = new SqlConnection(constr);
            List<StateMasterModel> statelist = new List<StateMasterModel>();
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("FetchState", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            com.Parameters.AddWithValue("@state_id", state_id);
            da.Fill(dt);
            con.Close();
            if (dt.Rows.Count > 0)
            {
                statelist.Add(
                    new StateMasterModel
                    {
                        state_id = Convert.ToInt32(dt.Rows[0]["state_id"].ToString()),
                        count_id = Convert.ToInt32(dt.Rows[0]["count_id"].ToString()),
                        state = dt.Rows[0]["state_name"].ToString(),
                        status = Convert.ToInt32(dt.Rows[0]["status"].ToString())
                    });
            }
            json["statelist"] = JToken.FromObject(statelist);
            return json;
        }

        [HttpPost]
        public JObject GoindToEvent(int uid, string eid, string email)
        {

            eid = ConvertHelper.Decode(eid);
            JObject json = new JObject();
            con = new SqlConnection(constr);
            con.Open();
            SqlParameter[] sqlparam = new SqlParameter[5];
            cmd = new SqlCommand("insertgoingevent", con);
            cmd.CommandType = CommandType.StoredProcedure;
            sqlparam[0] = new SqlParameter("@uid", SqlDbType.Int);
            sqlparam[0].Value = uid;
            sqlparam[1] = new SqlParameter("@eid", SqlDbType.Int);
            sqlparam[1].Value = eid;
            sqlparam[2] = new SqlParameter("@email", SqlDbType.NVarChar, 200);
            sqlparam[2].Value = email;
            sqlparam[3] = new SqlParameter("@errorCode", SqlDbType.Int);
            sqlparam[3].Direction = ParameterDirection.Output;
            sqlparam[4] = new SqlParameter("@errorMessage", SqlDbType.NVarChar, 200);
            sqlparam[4].Direction = ParameterDirection.Output;
            cmd.Parameters.AddRange(sqlparam);
            cmd.ExecuteNonQuery();
            string errormessage = sqlparam[4].Value.ToString();
            int errorCode = Convert.ToInt32(sqlparam[3].Value.ToString());
            json["status"] = errormessage;
            con.Close();
            return json;

        }

        [HttpPost]
        public JObject DeleteGoindToEvent(int uid, string eid, string email)
        {
            eid = ConvertHelper.Decode(eid);
            JObject json = new JObject();
            con = new SqlConnection(constr);
            con.Open();
            SqlParameter[] sqlparam = new SqlParameter[5];
            cmd = new SqlCommand("DeleteGoindToEvent", con);
            cmd.CommandType = CommandType.StoredProcedure;
            sqlparam[0] = new SqlParameter("@uid", SqlDbType.Int);
            sqlparam[0].Value = uid;
            sqlparam[1] = new SqlParameter("@eid", SqlDbType.Int);
            sqlparam[1].Value = eid;
            sqlparam[2] = new SqlParameter("@email", SqlDbType.NVarChar, 200);
            sqlparam[2].Value = email;
            sqlparam[3] = new SqlParameter("@errorCode", SqlDbType.Int);
            sqlparam[3].Direction = ParameterDirection.Output;
            sqlparam[4] = new SqlParameter("@errorMessage", SqlDbType.NVarChar, 200);
            sqlparam[4].Direction = ParameterDirection.Output;
            cmd.Parameters.AddRange(sqlparam);
            cmd.ExecuteNonQuery();
            string errormessage = sqlparam[4].Value.ToString();
            int errorCode = Convert.ToInt32(sqlparam[3].Value.ToString());
            json["status"] = errormessage;
            con.Close();
            return json;

        }

        public JObject GetState(int count_id)
        {
            con = new SqlConnection(constr);
            List<StateMasterModel> statelist = new List<StateMasterModel>();
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("GetState", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            com.Parameters.AddWithValue("@count_id", count_id);
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                statelist.Add(
                    new StateMasterModel
                    {
                        state_id = Convert.ToInt32(dr["state_id"].ToString()),
                        count_id = Convert.ToInt32(dr["count_id"].ToString()),
                        state = dr["state_name"].ToString(),
                        status = Convert.ToInt32(dr["status"].ToString())
                    });
            }
            json["statelist"] = JToken.FromObject(statelist);
            return json;
        }

        [HttpGet]
        [AllowAnonymous]
        [WebMethod]
        public JObject GetPlan()
        {
            con = new SqlConnection(constr);
            List<PlanModel> planlist = new List<PlanModel>();
            JObject json = new JObject();
            SqlCommand cmd = new SqlCommand("GetPlan", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                planlist.Add(
                    new PlanModel
                    {
                        plan_id = Convert.ToInt32(dr["plan_id"].ToString()),
                        plan_name = dr["plan_name"].ToString(),
                        duration = Convert.ToInt32(dr["duration"].ToString()),
                        amnt = Convert.ToInt32(dr["amnt"].ToString()),
                        status = Convert.ToInt32(dr["status"].ToString())
                    });
            }
            json["planlist"] = JToken.FromObject(planlist);
            return json;

        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        public JObject UserDetails(int id)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            List<UserListModel> UserDetails = new List<UserListModel>();
            SqlCommand com = new SqlCommand("UserDetails", con);
            com.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            com.Parameters.AddWithValue("@id", id);
            da.Fill(dt);
            con.Close();

            if (dt.Rows.Count > 0)
            {

                UserDetails.Add(new UserListModel
                {
                    name = dt.Rows[0]["name"].ToString(),
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
                    orgname = dt.Rows[0]["orgname"].ToString(),
                    customerid = dt.Rows[0]["cust_id"].ToString(),
                    showphone = dt.Rows[0]["showphone"].ToString(),
                    logo = dt.Rows[0]["buslogo"].ToString()

                });

            }

            json["UserDetails"] = JToken.FromObject(UserDetails);
            return json;
        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        public JObject InsertCountry(string countryname, int status)
        {
            JObject json = new JObject();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("InsertCountry", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@countryname", countryname);
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
        public JObject InsertState(int count_id, string state, int status)
        {

            JObject json = new JObject();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("InsertState", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@count_id", count_id);
                    cmd.Parameters.AddWithValue("@state_name", state);
                    cmd.Parameters.AddWithValue("@status", status);
                    con.Open();
                    json["status"] = cmd.ExecuteScalar().ToString();
                    con.Close();
                }
            }
            return json;
        }

        [HttpPost]
        [WebMethod]
        [ScriptMethod]
        [ValidateInput(false)]
        public JObject AddNewEvent(string title, string subject, string eventdate, string eventtime, string address, string cno, int country, int state, int city, int reason, string code, string unit, string street, string sname, string descr, string late, string lonz, int cat, int price, int ispaid, string showphone, string sponsorship, string sponsorname)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            string uid = Session["id"].ToString();
            SqlParameter[] sqlparam = new SqlParameter[25];
            SqlCommand com = new SqlCommand("AddEvent", con);
            com.CommandType = CommandType.StoredProcedure;
            sqlparam[0] = new SqlParameter("@uid", SqlDbType.Int);
            sqlparam[0].Value = uid;
            sqlparam[1] = new SqlParameter("@title", SqlDbType.NVarChar, 200);
            sqlparam[1].Value = title;
            sqlparam[2] = new SqlParameter("@subject", SqlDbType.NVarChar, -1);
            sqlparam[2].Value = subject;
            sqlparam[3] = new SqlParameter("@edate", SqlDbType.NVarChar, 200);
            sqlparam[3].Value = eventdate;
            sqlparam[4] = new SqlParameter("@etime", SqlDbType.NVarChar, 200);
            sqlparam[4].Value = eventtime;
            sqlparam[5] = new SqlParameter("@cno", SqlDbType.NVarChar, 200);
            sqlparam[5].Value = cno;
            sqlparam[6] = new SqlParameter("@country", SqlDbType.Int);
            sqlparam[6].Value = country;
            sqlparam[7] = new SqlParameter("@state", SqlDbType.Int);
            sqlparam[7].Value = state;
            sqlparam[8] = new SqlParameter("@city", SqlDbType.Int);
            sqlparam[8].Value = city;
            sqlparam[9] = new SqlParameter("@reason", SqlDbType.Int);
            sqlparam[9].Value = reason;
            //sqlparam[10] = new SqlParameter("@suburb", SqlDbType.Int);
            //sqlparam[10].Value = suburb;
            sqlparam[10] = new SqlParameter("@code", SqlDbType.NVarChar, 200);
            sqlparam[10].Value = code;
            sqlparam[11] = new SqlParameter("@unit", SqlDbType.NVarChar, 200);
            sqlparam[11].Value = unit;
            sqlparam[12] = new SqlParameter("@street", SqlDbType.NVarChar, 200);
            sqlparam[12].Value = street;

            sqlparam[13] = new SqlParameter("@sname", SqlDbType.NVarChar, 200);
            sqlparam[13].Value = sname;
            sqlparam[14] = new SqlParameter("@descr", SqlDbType.NVarChar, -1);
            sqlparam[14].Value = descr.Replace("&clubs;", "'");


            sqlparam[15] = new SqlParameter("@late", SqlDbType.NVarChar, 200);
            sqlparam[15].Value = late;
            sqlparam[16] = new SqlParameter("@long", SqlDbType.NVarChar, 200);
            sqlparam[16].Value = lonz;
            sqlparam[17] = new SqlParameter("@cat", SqlDbType.Int);
            sqlparam[17].Value = cat;
            sqlparam[18] = new SqlParameter("@ispaid", SqlDbType.Int);
            sqlparam[18].Value = ispaid;
            sqlparam[19] = new SqlParameter("@price", SqlDbType.Int);
            sqlparam[19].Value = price;
            sqlparam[20] = new SqlParameter("@eid", SqlDbType.Int);
            sqlparam[20].Direction = ParameterDirection.Output;
            sqlparam[21] = new SqlParameter("@showphone", SqlDbType.NVarChar, 200);
            sqlparam[21].Value = showphone;
            sqlparam[22] = new SqlParameter("@address", SqlDbType.NVarChar, 200);
            sqlparam[22].Value = address;
            sqlparam[23] = new SqlParameter("@sponsorship", SqlDbType.NVarChar, 200);
            sqlparam[23].Value = sponsorship;
            sqlparam[24] = new SqlParameter("@sponsorname", SqlDbType.NVarChar, 200);
            sqlparam[24].Value = sponsorname;
            com.Parameters.AddRange(sqlparam);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            json["eid"] = Convert.ToInt32(sqlparam[20].Value.ToString());
            return json;


        }

        [HttpPost]
        [AllowAnonymous]
        // [WebMethod]
        //public JObject EditEvent(int eid, string title, string subject, string date, string time, string address, string cno, int country, int state, int city, int reason, string code, string unit, string street, string sname, string descr, string late, string lonz, int cat, int price, int ispaid, int status, int showphone, string listid, string sponsorship, string sponsorname)
        public JObject EditEvent(string eid, string title, string subject, string date, string time, string address, string cno, string country, string state, string city, string reason, string code, string unit, string street, string sname, string descr, string late, string lonz, string cat, int price, string ispaid, string status, string showphone, string listid, string sponsorship, string sponsorname)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();


            SqlParameter[] sqlparam = new SqlParameter[26];
            SqlCommand com = new SqlCommand("EditEvent", con);
            com.CommandType = CommandType.StoredProcedure;
            sqlparam[0] = new SqlParameter("@eid", SqlDbType.Int);
            sqlparam[0].Value = eid;
            sqlparam[1] = new SqlParameter("@title", SqlDbType.NVarChar, 200);
            sqlparam[1].Value = title;
            sqlparam[2] = new SqlParameter("@subject", SqlDbType.NVarChar, -1);
            sqlparam[2].Value = subject;
            sqlparam[3] = new SqlParameter("@edate", SqlDbType.NVarChar, 200);
            sqlparam[3].Value = date;
            sqlparam[4] = new SqlParameter("@etime", SqlDbType.NVarChar, 200);
            sqlparam[4].Value = time;
            sqlparam[5] = new SqlParameter("@cno", SqlDbType.NVarChar, 200);
            sqlparam[5].Value = cno;
            sqlparam[6] = new SqlParameter("@country", SqlDbType.Int);
            sqlparam[6].Value = country;
            sqlparam[7] = new SqlParameter("@state", SqlDbType.Int);
            sqlparam[7].Value = state;
            sqlparam[8] = new SqlParameter("@city", SqlDbType.Int);
            sqlparam[8].Value = city;
            sqlparam[9] = new SqlParameter("@reason", SqlDbType.Int);
            sqlparam[9].Value = reason;
            //sqlparam[10] = new SqlParameter("@suburb", SqlDbType.Int);
            //sqlparam[10].Value = suburb;
            sqlparam[10] = new SqlParameter("@code", SqlDbType.NVarChar, 200);
            sqlparam[10].Value = code;
            sqlparam[11] = new SqlParameter("@unit", SqlDbType.NVarChar, 200);
            sqlparam[11].Value = unit;
            sqlparam[12] = new SqlParameter("@street", SqlDbType.NVarChar, 200);
            sqlparam[12].Value = street;

            sqlparam[13] = new SqlParameter("@sname", SqlDbType.NVarChar, 200);
            sqlparam[13].Value = sname;
            sqlparam[14] = new SqlParameter("@descr", SqlDbType.NVarChar, -1);
            sqlparam[14].Value = descr;


            sqlparam[15] = new SqlParameter("@late", SqlDbType.NVarChar, 200);
            sqlparam[15].Value = late;
            sqlparam[16] = new SqlParameter("@long", SqlDbType.NVarChar, 200);
            sqlparam[16].Value = lonz;
            sqlparam[17] = new SqlParameter("@cat", SqlDbType.Int);
            sqlparam[17].Value = cat;
            sqlparam[18] = new SqlParameter("@ispaid", SqlDbType.Int);
            sqlparam[18].Value = ispaid;
            sqlparam[19] = new SqlParameter("@price", SqlDbType.Int);
            sqlparam[19].Value = price;
            sqlparam[20] = new SqlParameter("@status", SqlDbType.Int);
            sqlparam[20].Value = status;
            sqlparam[21] = new SqlParameter("@showphone", SqlDbType.Int);
            sqlparam[21].Value = showphone;
            sqlparam[22] = new SqlParameter("@listid", SqlDbType.NVarChar, 200);
            sqlparam[22].Value = listid;
            sqlparam[23] = new SqlParameter("@sponsorship", SqlDbType.NVarChar, 200);
            sqlparam[23].Value = sponsorship;

            sqlparam[24] = new SqlParameter("@address", SqlDbType.NVarChar, 200);
            sqlparam[24].Value = address;
            sqlparam[25] = new SqlParameter("@sponsorname", SqlDbType.NVarChar, 200);
            sqlparam[25].Value = sponsorname;

            com.Parameters.AddRange(sqlparam);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            // json["eid"] = Convert.ToInt32(sqlparam[21].Value.ToString());
            return json;


        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject AddCar(int make, int model, int badge, int series, string price, int currency, string list, int condition, string descr, string body_type, string bcolor, string icolor, int year, string material, int transmition, int drive, int cylinder, string meter, string engine, int metrics, string speedtype, string fuel)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            string uid = Session["id"].ToString();
            SqlParameter[] sqlparam = new SqlParameter[24];
            SqlCommand com = new SqlCommand("AddCar", con);
            com.CommandType = CommandType.StoredProcedure;
            sqlparam[0] = new SqlParameter("@uid", SqlDbType.Int);
            sqlparam[0].Value = uid;
            sqlparam[1] = new SqlParameter("@make", SqlDbType.Int);
            sqlparam[1].Value = make;
            sqlparam[2] = new SqlParameter("@model", SqlDbType.Int);
            sqlparam[2].Value = model;
            sqlparam[3] = new SqlParameter("@badge", SqlDbType.Int);
            sqlparam[3].Value = badge;
            sqlparam[4] = new SqlParameter("@series", SqlDbType.Int);
            sqlparam[4].Value = series;
            sqlparam[5] = new SqlParameter("@price", SqlDbType.NVarChar, 200);
            sqlparam[5].Value = price;
            sqlparam[6] = new SqlParameter("@currency", SqlDbType.Int);
            sqlparam[6].Value = currency;
            sqlparam[7] = new SqlParameter("@list", SqlDbType.Int);
            sqlparam[7].Value = list;
            sqlparam[8] = new SqlParameter("@condition", SqlDbType.Int);
            sqlparam[8].Value = condition;
            sqlparam[9] = new SqlParameter("@descr", SqlDbType.NVarChar, -1);
            sqlparam[9].Value = descr;
            sqlparam[10] = new SqlParameter("@body_type", SqlDbType.Int);
            sqlparam[10].Value = body_type;
            sqlparam[11] = new SqlParameter("@bcolor", SqlDbType.Int);
            sqlparam[11].Value = bcolor;
            sqlparam[12] = new SqlParameter("@icolor", SqlDbType.Int);
            sqlparam[12].Value = icolor;
            sqlparam[13] = new SqlParameter("@year", SqlDbType.Int);
            sqlparam[13].Value = year;
            sqlparam[14] = new SqlParameter("@material", SqlDbType.Int);
            sqlparam[14].Value = material;
            sqlparam[15] = new SqlParameter("@transmition", SqlDbType.Int);
            sqlparam[15].Value = transmition;
            sqlparam[16] = new SqlParameter("@drive", SqlDbType.Int);
            sqlparam[16].Value = drive;
            sqlparam[17] = new SqlParameter("@cylinder", SqlDbType.Int);
            sqlparam[17].Value = cylinder;

            sqlparam[18] = new SqlParameter("@meter", SqlDbType.NVarChar, 200);
            sqlparam[18].Value = meter;
            sqlparam[19] = new SqlParameter("@engine", SqlDbType.NVarChar, 200);
            sqlparam[19].Value = engine;
            sqlparam[20] = new SqlParameter("@matrics", SqlDbType.Int);
            sqlparam[20].Value = metrics;
            //com.Parameters.AddWithValue("@img", img);
            //com.Parameters.AddWithValue("@img1", img1);
            //com.Parameters.AddWithValue("@img2", img2);
            sqlparam[21] = new SqlParameter("@speedtype", SqlDbType.NVarChar, 200);
            sqlparam[21].Value = speedtype;
            sqlparam[22] = new SqlParameter("@fuel", SqlDbType.NVarChar, 200);
            sqlparam[22].Value = fuel;
            sqlparam[23] = new SqlParameter("@carid", SqlDbType.Int);
            sqlparam[23].Direction = ParameterDirection.Output;
            com.Parameters.AddRange(sqlparam);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            json["carid"] = Convert.ToInt32(sqlparam[23].Value.ToString());

            //json["error"] = ex.Message;

            return json;


        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject EditCar(int cid, int make, int model, int badge, int series, string price, int currency, int condition, string descr, string body_type, string bcolor, string icolor, int year, string material, int transmition, int drive, int cylinder, string meter, string engine, int metrics, string speedtype, string fuel, string addeddate, string status, string gstatus, string listid)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            //string uid = Session["id"].ToString();
            try
            {

                SqlCommand com = new SqlCommand("EditCar", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@cid", cid);
                //  com.Parameters.AddWithValue("@uid", uid);
                com.Parameters.AddWithValue("@make", make);
                com.Parameters.AddWithValue("@model", model);
                com.Parameters.AddWithValue("@badge", badge);
                com.Parameters.AddWithValue("@series", series);
                com.Parameters.AddWithValue("@price", price);
                com.Parameters.AddWithValue("@currency", currency);
                com.Parameters.AddWithValue("@list", 0);
                com.Parameters.AddWithValue("@condition", condition);
                com.Parameters.AddWithValue("@descr", descr);
                com.Parameters.AddWithValue("@body_type", body_type);
                com.Parameters.AddWithValue("@bcolor", bcolor);
                com.Parameters.AddWithValue("@icolor", icolor);
                com.Parameters.AddWithValue("@year", year);
                com.Parameters.AddWithValue("@material", material);
                com.Parameters.AddWithValue("@transmition", transmition);
                com.Parameters.AddWithValue("@drive", drive);
                com.Parameters.AddWithValue("@cylinder", cylinder);
                com.Parameters.AddWithValue("@meter", meter);
                com.Parameters.AddWithValue("@engine", engine);
                com.Parameters.AddWithValue("@matrics", metrics);
                com.Parameters.AddWithValue("@speedtype", speedtype);
                com.Parameters.AddWithValue("@fuel", fuel);
                com.Parameters.AddWithValue("@addeddate", addeddate);
                com.Parameters.AddWithValue("@status", status);
                com.Parameters.AddWithValue("@gstatus", gstatus);
                com.Parameters.AddWithValue("@listid", listid);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                json["status"] = "Success";
            }
            catch (Exception ex)
            {

                json["error"] = ex.Message;
            }
            return json;


        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject UpdateWatchlistStatus(string cid)
        {
            cid = ConvertHelper.Decode(cid);
            con = new SqlConnection(constr);
            JObject json = new JObject();
            //string uid = Session["id"].ToString();
            try
            {
                string uid = Session["id"].ToString();
                SqlCommand com = new SqlCommand("UpdateWatchliststatus", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@cid", cid);
                com.Parameters.AddWithValue("@uid", uid);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                json["status"] = "Success";
            }
            catch (Exception ex)
            {

                json["error"] = ex.Message;
            }
            return json;


        }

        [WebMethod]
        [HttpPost]
        public JObject UpdateEventWatchlist(string eid)
        {


            eid = ConvertHelper.Decode(eid);
            con = new SqlConnection(constr);
            JObject json = new JObject();
            //string uid = Session["id"].ToString();
            try
            {
                string uid = Session["id"].ToString();
                SqlCommand com = new SqlCommand("UpdateEventWatchliststatus", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@eid", eid);
                com.Parameters.AddWithValue("@uid", uid);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                json["status"] = "Success";
            }
            catch (Exception ex)
            {

                json["error"] = ex.Message;
            }

            return json;
        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        [AuthonticateUserHelper]
        public JObject DeleteCar(string cid)
        {
            cid = ConvertHelper.Decode(cid);
            con = new SqlConnection(constr);
            JObject json = new JObject();
            //string uid = Session["id"].ToString();
            try
            {

                SqlCommand com = new SqlCommand("DeleteCar", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@cid", cid);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                json["status"] = "Success";
            }
            catch (Exception ex)
            {

                json["error"] = ex.Message;
            }
            return json;


        }


        [AllowAnonymous, WebMethod, AuthonticateUserHelper]
        public JObject DeleteEvent(string eid)
        {
            eid = ConvertHelper.Decode(eid);
            con = new SqlConnection(constr);
            JObject json = new JObject();
            //string uid = Session["id"].ToString();
            try
            {

                SqlCommand com = new SqlCommand("Deleteevent", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@eid", eid);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                json["status"] = "Success";
            }
            catch (Exception ex)
            {

                json["error"] = ex.Message;
            }
            return json;


        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        public JObject InsertPlan(string plan_name, int duration, int amnt, int status)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("InsertPlan", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@plan_name", plan_name);
            com.Parameters.AddWithValue("@duration", duration);
            com.Parameters.AddWithValue("@amnt", amnt);
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
        public JObject DeletePlan(int planid)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("DeletePlan", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@planid", planid);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;
        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        public JObject UpdateStatus(string id, string status)
        {

            id = ConvertHelper.Decode(id);
            con = new SqlConnection(constr);
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("UpdateStatus", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id", id);
            com.Parameters.AddWithValue("@status", status);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();


            string email = "";
            cmd = new SqlCommand("select * from tbl_login where id='" + id + "'", con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                email = dr["email"].ToString();

            }

            dr.Close();

            String htmlmessage = "<table border='0' cellpadding='5' cellspacing='0' style='font - family:arial; background - color: #fff; height:auto; width:800px; margin:30px auto; max-width:100%;'>";
            htmlmessage = htmlmessage + "<tr><td align='left' style='border-bottom:10px solid #0098fa;padding:20px50px;'>";
            htmlmessage = htmlmessage + "<img src='http://mycaryard.stums.in/content/images/logo.png' alt='logo'></td></tr><tr>";
            htmlmessage = htmlmessage + "<td align='left' style='padding:30px 50px 20px; font-size: 24px;  color:#000;'> Welcome!</td></tr><tr>";
            htmlmessage = htmlmessage + "<td align='left' style = 'padding:0px 50px 20px; color:#000;'>";
            htmlmessage = htmlmessage + "A mycaryard account has been created for you. your account is in under review, mycaryard team will contact your shortly.";
            htmlmessage = htmlmessage + "</tr><tr><td align='left' style='padding:0px 50px 20px; color:#000;'>";
            htmlmessage = htmlmessage + "Login page: <a href='http://mycaryard.stums.in/Home/UserIndex' style='color: #0066CC;'> mycaryard.stums.in</a><br>";
            htmlmessage = htmlmessage + "Email:<a href='mycaryard@gmail.com' style='color: #0066CC;'> mycaryard@gmail.com </a></td></tr><tr>";
            htmlmessage = htmlmessage + "<td align='left' style='padding:0px 50px 20px; color:#000;'>";
            htmlmessage = htmlmessage + "We are here to help. if you have any question about marcaryard, just visit<span style='color: #0066CC;text-decoration:underline'> <a href='http://mycaryard.stums.in/Home/UserIndex' style='color: #0066CC;'>support site</a> </span></td></tr><tr>";
            htmlmessage = htmlmessage + "<td align='left' style='padding: 0px 50px 10px;line-height:24px; color:#0098FA;'><a href='http://mycaryard.stums.in/Home/UserIndex' style='color: #0066CC;'>Login to your account if you already have</a></td></tr><tr><td></td></tr></table>";

            var msg = new MailMessage();
            var htmlBody = AlternateView.CreateAlternateViewFromString(htmlmessage, Encoding.UTF8, "text/html");
            MailAddress sender = new MailAddress("info@stums.in", "MyCarYard");
            msg.AlternateViews.Add(htmlBody);
            msg.From = sender;
            msg.Subject = "MYCARYARD New Registration";
            msg.To.Add(email);


            // MailMessage mail = new MailMessage("info@stums.in", model.RegEmail, "MyCarYard New Registration", htmlmessage);
            msg.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("relay-hosting.secureserver.net");
            client.Send(msg);


            json["status"] = "Success";

            return json;


        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        public JObject DeleteUser(string id)
        {
            id = ConvertHelper.Decode(id);
            con = new SqlConnection(constr);
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("DeleteUser", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id", id);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;

        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        public JObject UpdateUserProfile(int id, string dname, string fname, string lname, string cno, string city, string state, string country, string street, string streetname, string other, string other1, string other2, string zip, string regions, string gender, string late, string lonz, string showphone, string bname)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("UpdateUser", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id", id);
            com.Parameters.AddWithValue("@dname", dname);
            com.Parameters.AddWithValue("@fname", fname);
            com.Parameters.AddWithValue("@lname", lname);
            com.Parameters.AddWithValue("@cno", cno);
            com.Parameters.AddWithValue("@city", city);
            com.Parameters.AddWithValue("@state", state);
            com.Parameters.AddWithValue("@country", country);
            com.Parameters.AddWithValue("@street", street);
            com.Parameters.AddWithValue("@streetname", streetname);
            com.Parameters.AddWithValue("@other", other);
            com.Parameters.AddWithValue("@other1", other1);
            com.Parameters.AddWithValue("@other2", other2);
            com.Parameters.AddWithValue("@zip", zip);
            com.Parameters.AddWithValue("@regions", regions);
            //com.Parameters.AddWithValue("@suburb", suburb);
            com.Parameters.AddWithValue("@gender", gender);
            com.Parameters.AddWithValue("@late", late);
            com.Parameters.AddWithValue("@long", lonz);
            com.Parameters.AddWithValue("@showphone", showphone);
            com.Parameters.AddWithValue("@bname", bname);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            return json;
        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        public JObject UpdateCountry(int count_id, string country, int status)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("UpdateCountry", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@count_id", count_id);
            com.Parameters.AddWithValue("@country_name", country);
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
        public JObject DeleteCountry(int count_id)
        {
            JObject json = new JObject();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteCountry", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@count_id", count_id);
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
        public JObject UpdateState(int state_id, int count_id, string state, int status)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("UpdateState", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@state_id", state_id);
            com.Parameters.AddWithValue("@count_id", count_id);
            com.Parameters.AddWithValue("@state_name", state);
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
        public JObject DeleteState(int state_id)
        {
            JObject json = new JObject();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteState", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@state_id", state_id);
                    con.Open();
                    json["status"] = cmd.ExecuteScalar().ToString();
                    con.Close();
                }
            }
            return json;
        }

        [AuthonticateUserHelper]
        public ActionResult UserList()
        {
            UserListModel model = new UserListModel();
            con = new SqlConnection(constr);
            List<UserListModel> UserList = new List<UserListModel>();
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("getAllCustomers", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind EmpModel generic list using dataRow 
            foreach (DataRow dr in dt.Rows)
            {
                UserList.Add(
                    new UserListModel
                    {
                        id = ConvertHelper.Encode(dr["id"].ToString()),
                        name = Convert.ToString(dr["name"].ToString()),
                        email = Convert.ToString(dr["email"].ToString()),
                        type = dr["type"].ToString(),
                        status = Convert.ToInt32(dr["status"].ToString()),
                        regdate = Convert.ToDateTime(dr["reg_date"].ToString()).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                        orgname = dr["orgname"].ToString(),
                        customerid = dr["cust_id"].ToString()
                    }
                    );
            }

            model.userlist = UserList;

            return View(model);
        }

        [AuthonticateUserHelper]
        public ActionResult ApproveUsers()
        {
            UserListModel model = new UserListModel();
            con = new SqlConnection(constr);
            List<UserListModel> UserList = new List<UserListModel>();
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("getAllCustomers", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind EmpModel generic list using dataRow 
            foreach (DataRow dr in dt.Rows)
            {
                UserList.Add(
                    new UserListModel
                    {
                        orgname = dr["orgname"].ToString(),
                        customerid = dr["cust_id"].ToString(),
                        id = ConvertHelper.Encode(dr["id"].ToString()),
                        name = Convert.ToString(dr["name"].ToString()),
                        email = Convert.ToString(dr["email"].ToString()),
                        type = dr["type"].ToString(),
                        status = Convert.ToInt32(dr["status"].ToString()),
                        regdate = Convert.ToDateTime(dr["reg_date"].ToString()).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)
                    }
                    );
            }

            model.userlist = UserList;

            return View(model);
        }

        [AuthonticateUserHelper]
        public ActionResult Dashboard()
        {

            return View();
        }

        [AuthonticateUserHelper]
        public ActionResult UserIndex()
        {
            return View();
        }

        [AuthonticateUserHelper]
        public ActionResult UserProfile()
        {
            return View();
        }

        [AuthonticateUserHelper]
        public ActionResult EventMaster()
        {
            return View();




        }

        public ActionResult CarMaster(string option = "0")
        {
            //return View();
            if (option == "0")
            {

                option = "CID";
            }

            DataTable dt = new DataTable();
            List<CarModel> carlist = new List<CarModel>();
            RegisterViewModel model = new RegisterViewModel();
            List<EventViewModel> eventlist1 = new List<EventViewModel>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("GetCarDetails", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sortby", option);
                    con.Open();
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
                                //series = dt.Rows[i]["series"].ToString(),
                                series = dt.Rows[i]["series_type"].ToString(),
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
            dt = new DataTable();

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


                            });
                        }
                    }

                }
            }


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
            dr.Close();
            con.Close();
            model.makelist = list;
            model.carlist = carlist;
            model.eventlist = eventlist1;
            return View("CarMaster", model);

        }

        [HttpPost]
        [WebMethod]
        [ValidateInput(false)]
        public JObject AdvanceSearchCar(string make, string model, string series, string badge, string condition, string transmission, int fyear, int tyear, int country, int state, Int32 minprice, Int32 maxprice, string keyword, string filterval)
        {
            DataTable dt = new DataTable();
            List<CarModel> carlist = new List<CarModel>();
            RegisterViewModel regmodel = new RegisterViewModel();
            List<EventViewModel> eventlist1 = new List<EventViewModel>();
            con = new SqlConnection(constr);

            cmd = new SqlCommand("AdvanceSearchCar", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@make", make);
            cmd.Parameters.AddWithValue("@model", model);
            cmd.Parameters.AddWithValue("@series", series);
            cmd.Parameters.AddWithValue("@badge", badge);
            cmd.Parameters.AddWithValue("@condition", condition);
            cmd.Parameters.AddWithValue("@transmission", transmission);
            cmd.Parameters.AddWithValue("@fyear", fyear);
            cmd.Parameters.AddWithValue("@tyear", tyear);
            cmd.Parameters.AddWithValue("@country", country);
            cmd.Parameters.AddWithValue("@state", state);
            cmd.Parameters.AddWithValue("@minprice", minprice);
            cmd.Parameters.AddWithValue("@maxprice", maxprice);
            cmd.Parameters.AddWithValue("@keyword", keyword);
            cmd.Parameters.AddWithValue("@filterval", filterval);

            con.Open();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    string starget = "0";

                    if (Session["id"] != null)
                    {
                        int carid = Convert.ToInt32(dt.Rows[i]["cid"].ToString());

                        string uid;

                        uid = Session["id"].ToString();

                        SqlCommand cmd1 = new SqlCommand("select * from CarWatchList where cid='" + carid + "' and uid ='" + uid + "'", con);
                        SqlDataReader dr1 = cmd1.ExecuteReader();
                        if (dr1.Read())
                        {
                            starget = dr1["status"].ToString();
                        }
                        dr1.Close();
                    }
                    carlist.Add(new CarModel
                    {
                        cid = ConvertHelper.Encode(dt.Rows[i]["cid"].ToString()),
                        price = Convert.ToInt32(dt.Rows[i]["price"].ToString()).ToString("#,##0"),
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
                        //series = dt.Rows[i]["series"].ToString(),
                        series = dt.Rows[i]["series_type"].ToString(),
                        currency = dt.Rows[i]["currencyname"].ToString(),
                        model = dt.Rows[i]["model"].ToString(),
                        tranmition = dt.Rows[i]["transmision"].ToString(),
                        country = dt.Rows[i]["country_name"].ToString(),
                        state = dt.Rows[i]["state_name"].ToString(),
                        city = dt.Rows[i]["cityname"].ToString(),
                        zipcode = dt.Rows[i]["zip"].ToString(),
                        meter = Convert.ToInt32(dt.Rows[i]["meter"].ToString()).ToString("#,##0"),
                        matrics = dt.Rows[i]["odometer"].ToString(),
                        condition = dt.Rows[i]["condition"].ToString(),
                        uname = dt.Rows[i]["name"].ToString(),
                        drive = dt.Rows[i]["drive"].ToString(),
                        fuel = dt.Rows[i]["fuel"].ToString(),
                        gstatus = dt.Rows[i]["gstatus"].ToString(),
                        speedtype = dt.Rows[i]["speedtypename"].ToString(),
                        star = Convert.ToInt32(starget),
                        img3 = dt.Rows[i]["img3"].ToString(),
                        img4 = dt.Rows[i]["img4"].ToString(),
                        img5 = dt.Rows[i]["img5"].ToString(),
                        created_date = dt.Rows[i]["created_date"].ToString(),
                        totaldays = getTotaldays(dt.Rows[i]["created_date"].ToString()),

                        showphone = Convert.ToInt32(dt.Rows[i]["showphone"].ToString()),
                        cno = dt.Rows[i]["cno"].ToString(),
                        orgname = dt.Rows[i]["orgname"].ToString(),
                        suburb = dt.Rows[i]["regionname"].ToString()

                    });
                }
            }



            con.Close();

            JObject json = new JObject();
            json["status"] = "success";
            json["carlist"] = JToken.FromObject(carlist);
            regmodel.carlist = carlist;

            return json;

        }

        [HttpPost]
        [WebMethod]
        [ValidateInput(false)]
        public JObject AdvanceSearchCarMap(string make, string model, string series, string badge, string condition, string transmission, int fyear, int tyear, int country, int state, Int32 minprice, Int32 maxprice, string keyword)
        {
            DataTable dt = new DataTable();

            List<UserListModel> UserList = new List<UserListModel>();
            JObject json = new JObject();
            SqlConnection con = new SqlConnection(constr);
            cmd = new SqlCommand("AdvanceSearchCarMap", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@make", make);
            cmd.Parameters.AddWithValue("@model", model);
            cmd.Parameters.AddWithValue("@series", series);
            cmd.Parameters.AddWithValue("@badge", badge);
            cmd.Parameters.AddWithValue("@condition", condition);
            cmd.Parameters.AddWithValue("@transmission", transmission);
            cmd.Parameters.AddWithValue("@fyear", fyear);
            cmd.Parameters.AddWithValue("@tyear", tyear);
            cmd.Parameters.AddWithValue("@country", country);
            cmd.Parameters.AddWithValue("@state", state);
            cmd.Parameters.AddWithValue("@minprice", minprice);
            cmd.Parameters.AddWithValue("@maxprice", maxprice);
            cmd.Parameters.AddWithValue("@keyword", keyword);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);


            foreach (DataRow dr in dt.Rows)
            {
                UserList.Add(
                    new UserListModel
                    {
                        id = ConvertHelper.Encode(dr["id"].ToString()),
                        street = dr["street"].ToString(),
                        streetname = dr["streetname"].ToString(),
                        name = Convert.ToString(dr["name"].ToString()),
                        email = Convert.ToString(dr["email"].ToString()),
                        type = dr["type"].ToString(),
                        late = dr["late"].ToString(),
                        lonz = dr["long"].ToString(),
                        status = Convert.ToInt32(dr["status"].ToString()),
                        logo = dr["buslogo"].ToString(),
                        countryname = dr["country_name"].ToString(),
                        statename = dr["state_name"].ToString(),
                        resonname = dr["regionname"].ToString(),
                        zip = dr["zip"].ToString()


                    }
                    );
            }
            json["userlist"] = JToken.FromObject(UserList);
            return json;

        }

        public Int32 getTotaldays(string date)
        {

            Int32 totdays;
            TimeSpan diff = DateTime.UtcNow.Date - Convert.ToDateTime(date);
            totdays = Convert.ToInt32(Math.Abs(diff.TotalDays));
            return totdays;

        }

        public ActionResult UserAdvanceSearchCar(int make, int model, int fyear, int tyear, int country, int state, Int32 minprice, Int32 maxprice, string keyword, int series, int badge)
        {
            DataTable dt = new DataTable();
            List<CarModel> carlist = new List<CarModel>();
            RegisterViewModel regmodel = new RegisterViewModel();
            List<EventViewModel> eventlist1 = new List<EventViewModel>();
            con = new SqlConnection(constr);


            cmd = new SqlCommand("SELECT ISNULL(((select status from carwatchlist  where cid=a.cid and uid=k.id)),0) as 'carstar',p.city as 'cityname',b.country_name,c.state_name,d.make_type,e.model,f.badge_type,g.series_type,h.transmision,i.currency as 'currencyname',j.odometer,k.id,a.*,k.name,l.cylinder_name,m.speedtypename,n.ensize_name,o.Body_Type as 'bodytypename',k.zip,k.cno,k.orgname,k.showphone from tbl_carmaster a,tbl_country_master b,tbl_state_master c,MakeTypeMaster d,ModelMaster e,BadgeTypeMaster f,SeriesTypeMaster g,TransmisionMaster h,tbl_currency_master i,OdoMeterMaster j,tbl_login k,Cylinder_Master l,SpeedTypeMaster m,EngineSizeMaster n,Body_TypeMaster o,CityMaster p where p.city_id=k.city and o.Body_type_id=a.body_type and n.ensize_id=a.engine and m.speedtypeid=a.speedtype and l.cylinder_id=a.cylinder and d.make_id=a.make and e.model_id=a.model and f.bad_id=a.badge and g.ser_id=a.series and h.trans_id=a.transmition and i.cur_id=a.currency and j.odo_id=a.matrics and k.id=a.uid and k.country=b.count_id and k.state=c.state_id  and a.status = 1", con);

            if (make != 0 && model == 0 && fyear == 0 && tyear == 0 && country == 0 && state == 0 && minprice == 0 && maxprice == 0 && keyword == "")
            {
                cmd = new SqlCommand("SELECT ISNULL(((select status from carwatchlist  where cid=a.cid and uid=k.id)),0) as 'carstar',p.city as 'cityname',b.country_name,c.state_name,d.make_type,e.model,f.badge_type,g.series_type,h.transmision,i.currency as 'currencyname',j.odometer,k.id,a.*,k.name,l.cylinder_name,m.speedtypename,n.ensize_name,o.Body_Type as 'bodytypename',k.zip,k.cno,k.orgname,k.showphone from tbl_carmaster a,tbl_country_master b,tbl_state_master c,MakeTypeMaster d,ModelMaster e,BadgeTypeMaster f,SeriesTypeMaster g,TransmisionMaster h,tbl_currency_master i,OdoMeterMaster j,tbl_login k,Cylinder_Master l,SpeedTypeMaster m,EngineSizeMaster n,Body_TypeMaster o,CityMaster p where p.city_id=k.city and o.Body_type_id=a.body_type and n.ensize_id=a.engine and m.speedtypeid=a.speedtype and l.cylinder_id=a.cylinder and d.make_id=a.make and e.model_id=a.model and f.bad_id=a.badge and g.ser_id=a.series and h.trans_id=a.transmition and i.cur_id=a.currency and j.odo_id=a.matrics and k.id=a.uid and k.country=b.count_id and k.state=c.state_id  and a.status = 1 and a.make='" + make + "'", con);

            }

            if (make != 0 && model != 0 && fyear == 0 && tyear == 0 && country == 0 && state == 0 && minprice == 0 && maxprice == 0 && keyword == "")
            {
                cmd = new SqlCommand("SELECT ISNULL(((select status from carwatchlist  where cid=a.cid and uid=k.id)),0) as 'carstar',p.city as 'cityname',b.country_name,c.state_name,d.make_type,e.model,f.badge_type,g.series_type,h.transmision,i.currency as 'currencyname',j.odometer,k.id,a.*,k.name,l.cylinder_name,m.speedtypename,n.ensize_name,o.Body_Type as 'bodytypename',k.zip,k.cno,k.orgname,k.showphone from tbl_carmaster a,tbl_country_master b,tbl_state_master c,MakeTypeMaster d,ModelMaster e,BadgeTypeMaster f,SeriesTypeMaster g,TransmisionMaster h,tbl_currency_master i,OdoMeterMaster j,tbl_login k,Cylinder_Master l,SpeedTypeMaster m,EngineSizeMaster n,Body_TypeMaster o,CityMaster p where p.city_id=k.city and o.Body_type_id=a.body_type and n.ensize_id=a.engine and m.speedtypeid=a.speedtype and l.cylinder_id=a.cylinder and d.make_id=a.make and e.model_id=a.model and f.bad_id=a.badge and g.ser_id=a.series and h.trans_id=a.transmition and i.cur_id=a.currency and j.odo_id=a.matrics and k.id=a.uid and k.country=b.count_id and k.state=c.state_id  and a.status = 1 and a.make='" + make + "' and a.model='" + model + "'", con);

            }

            if (make != 0 && model != 0 && series != 0 && fyear == 0 && tyear == 0 && country == 0 && state == 0 && minprice == 0 && maxprice == 0 && keyword == "")
            {
                cmd = new SqlCommand("SELECT ISNULL(((select status from carwatchlist  where cid=a.cid and uid=k.id)),0) as 'carstar',p.city as 'cityname',b.country_name,c.state_name,d.make_type,e.model,f.badge_type,g.series_type,h.transmision,i.currency as 'currencyname',j.odometer,k.id,a.*,k.name,l.cylinder_name,m.speedtypename,n.ensize_name,o.Body_Type as 'bodytypename',k.zip,k.cno,k.orgname,k.showphone from tbl_carmaster a,tbl_country_master b,tbl_state_master c,MakeTypeMaster d,ModelMaster e,BadgeTypeMaster f,SeriesTypeMaster g,TransmisionMaster h,tbl_currency_master i,OdoMeterMaster j,tbl_login k,Cylinder_Master l,SpeedTypeMaster m,EngineSizeMaster n,Body_TypeMaster o,CityMaster p where p.city_id=k.city and o.Body_type_id=a.body_type and n.ensize_id=a.engine and m.speedtypeid=a.speedtype and l.cylinder_id=a.cylinder and d.make_id=a.make and e.model_id=a.model and f.bad_id=a.badge and g.ser_id=a.series and h.trans_id=a.transmition and i.cur_id=a.currency and j.odo_id=a.matrics and k.id=a.uid and k.country=b.count_id and k.state=c.state_id  and a.status = 1 and a.make='" + make + "' and a.model='" + model + "' and a.badge= '" + series + "'", con);

            }

            if (make != 0 && model != 0 && series != 0 && badge != 0 && fyear == 0 && tyear == 0 && country == 0 && state == 0 && minprice == 0 && maxprice == 0 && keyword == "")
            {
                cmd = new SqlCommand("SELECT ISNULL(((select status from carwatchlist  where cid=a.cid and uid=k.id)),0) as 'carstar',p.city as 'cityname',b.country_name,c.state_name,d.make_type,e.model,f.badge_type,g.series_type,h.transmision,i.currency as 'currencyname',j.odometer,k.id,a.*,k.name,l.cylinder_name,m.speedtypename,n.ensize_name,o.Body_Type as 'bodytypename',k.zip,k.cno,k.orgname,k.showphone from tbl_carmaster a,tbl_country_master b,tbl_state_master c,MakeTypeMaster d,ModelMaster e,BadgeTypeMaster f,SeriesTypeMaster g,TransmisionMaster h,tbl_currency_master i,OdoMeterMaster j,tbl_login k,Cylinder_Master l,SpeedTypeMaster m,EngineSizeMaster n,Body_TypeMaster o,CityMaster p where p.city_id=k.city and o.Body_type_id=a.body_type and n.ensize_id=a.engine and m.speedtypeid=a.speedtype and l.cylinder_id=a.cylinder and d.make_id=a.make and e.model_id=a.model and f.bad_id=a.badge and g.ser_id=a.series and h.trans_id=a.transmition and i.cur_id=a.currency and j.odo_id=a.matrics and k.id=a.uid and k.country=b.count_id and k.state=c.state_id  and a.status = 1 and a.make='" + make + "' and a.model='" + model + "' and a.badge= '" + series + "' and a.series='" + badge + "'", con);

            }
            if (make != 0 && model != 0 && series != 0 && badge != 0 && fyear != 0 && tyear != 0 && country == 0 && state == 0 && minprice == 0 && maxprice == 0 && keyword == "")
            {
                cmd = new SqlCommand("SELECT ISNULL(((select status from carwatchlist  where cid=a.cid and uid=k.id)),0) as 'carstar',p.city as 'cityname',b.country_name,c.state_name,d.make_type,e.model,f.badge_type,g.series_type,h.transmision,i.currency as 'currencyname',j.odometer,k.id,a.*,k.name,l.cylinder_name,m.speedtypename,n.ensize_name,o.Body_Type as 'bodytypename',k.zip,k.cno,k.orgname,k.showphone from tbl_carmaster a,tbl_country_master b,tbl_state_master c,MakeTypeMaster d,ModelMaster e,BadgeTypeMaster f,SeriesTypeMaster g,TransmisionMaster h,tbl_currency_master i,OdoMeterMaster j,tbl_login k,Cylinder_Master l,SpeedTypeMaster m,EngineSizeMaster n,Body_TypeMaster o,CityMaster p where p.city_id=k.city and o.Body_type_id=a.body_type and n.ensize_id=a.engine and m.speedtypeid=a.speedtype and l.cylinder_id=a.cylinder and d.make_id=a.make and e.model_id=a.model and f.bad_id=a.badge and g.ser_id=a.series and h.trans_id=a.transmition and i.cur_id=a.currency and j.odo_id=a.matrics and k.id=a.uid and k.country=b.count_id and k.state=c.state_id  and a.status = 1 and a.make='" + make + "' and a.model='" + model + "' and a.badge= '" + series + "' and a.series='" + badge + "' and a.year between '" + fyear + "' and '" + tyear + "'", con);

            }
            if (make != 0 && model == 0 && fyear != 0 && tyear != 0 && country == 0 && state == 0 && minprice == 0 && maxprice == 0 && keyword == "")
            {
                cmd = new SqlCommand("SELECT ISNULL(((select status from carwatchlist  where cid=a.cid and uid=k.id)),0) as 'carstar',p.city as 'cityname',b.country_name,c.state_name,d.make_type,e.model,f.badge_type,g.series_type,h.transmision,i.currency as 'currencyname',j.odometer,k.id,a.*,k.name,l.cylinder_name,m.speedtypename,n.ensize_name,o.Body_Type as 'bodytypename',k.zip,k.cno,k.orgname,k.showphone from tbl_carmaster a,tbl_country_master b,tbl_state_master c,MakeTypeMaster d,ModelMaster e,BadgeTypeMaster f,SeriesTypeMaster g,TransmisionMaster h,tbl_currency_master i,OdoMeterMaster j,tbl_login k,Cylinder_Master l,SpeedTypeMaster m,EngineSizeMaster n,Body_TypeMaster o,CityMaster p where p.city_id=k.city and o.Body_type_id=a.body_type and n.ensize_id=a.engine and m.speedtypeid=a.speedtype and l.cylinder_id=a.cylinder and d.make_id=a.make and e.model_id=a.model and f.bad_id=a.badge and g.ser_id=a.series and h.trans_id=a.transmition and i.cur_id=a.currency and j.odo_id=a.matrics and k.id=a.uid and k.country=b.count_id and k.state=c.state_id  and a.status = 1 and a.make='" + make + "' and a.year between '" + fyear + "' and '" + tyear + "'", con);

            }

            if (make == 0 && model == 0 && fyear != 0 && tyear != 0 && country == 0 && state == 0 && minprice == 0 && maxprice == 0 && keyword == "")
            {
                cmd = new SqlCommand("SELECT ISNULL(((select status from carwatchlist  where cid=a.cid and uid=k.id)),0) as 'carstar',p.city as 'cityname',b.country_name,c.state_name,d.make_type,e.model,f.badge_type,g.series_type,h.transmision,i.currency as 'currencyname',j.odometer,k.id,a.*,k.name,l.cylinder_name,m.speedtypename,n.ensize_name,o.Body_Type as 'bodytypename',k.zip,k.cno,k.orgname,k.showphone from tbl_carmaster a,tbl_country_master b,tbl_state_master c,MakeTypeMaster d,ModelMaster e,BadgeTypeMaster f,SeriesTypeMaster g,TransmisionMaster h,tbl_currency_master i,OdoMeterMaster j,tbl_login k,Cylinder_Master l,SpeedTypeMaster m,EngineSizeMaster n,Body_TypeMaster o,CityMaster p where p.city_id=k.city and o.Body_type_id=a.body_type and n.ensize_id=a.engine and m.speedtypeid=a.speedtype and l.cylinder_id=a.cylinder and d.make_id=a.make and e.model_id=a.model and f.bad_id=a.badge and g.ser_id=a.series and h.trans_id=a.transmition and i.cur_id=a.currency and j.odo_id=a.matrics and k.id=a.uid and k.country=b.count_id and k.state=c.state_id  and a.status = 1  and a.year between '" + fyear + "' and '" + tyear + "'", con);

            }

            if (make != 0 && model != 0 && fyear != 0 && tyear != 0 && country != 0 && state == 0 && minprice == 0 && maxprice == 0 && keyword == "")
            {
                cmd = new SqlCommand("SELECT ISNULL(((select status from carwatchlist  where cid=a.cid and uid=k.id)),0) as 'carstar',p.city as 'cityname',b.country_name,c.state_name,d.make_type,e.model,f.badge_type,g.series_type,h.transmision,i.currency as 'currencyname',j.odometer,k.id,a.*,k.name,l.cylinder_name,m.speedtypename,n.ensize_name,o.Body_Type as 'bodytypename',k.zip,k.cno,k.orgname,k.showphone from tbl_carmaster a,tbl_country_master b,tbl_state_master c,MakeTypeMaster d,ModelMaster e,BadgeTypeMaster f,SeriesTypeMaster g,TransmisionMaster h,tbl_currency_master i,OdoMeterMaster j,tbl_login k,Cylinder_Master l,SpeedTypeMaster m,EngineSizeMaster n,Body_TypeMaster o,CityMaster p where p.city_id=k.city and o.Body_type_id=a.body_type and n.ensize_id=a.engine and m.speedtypeid=a.speedtype and l.cylinder_id=a.cylinder and d.make_id=a.make and e.model_id=a.model and f.bad_id=a.badge and g.ser_id=a.series and h.trans_id=a.transmition and i.cur_id=a.currency and j.odo_id=a.matrics and k.id=a.uid and k.country=b.count_id and k.state=c.state_id  and a.status = 1 and a.make='" + make + "' and a.model='" + model + "' and a.year between '" + fyear + "' and '" + tyear + "' and k.country='" + country + "'", con);

            }
            if (make != 0 && model == 0 && fyear == 0 && tyear == 0 && country != 0 && state == 0 && minprice == 0 && maxprice == 0 && keyword == "")
            {
                cmd = new SqlCommand("SELECT ISNULL(((select status from carwatchlist  where cid=a.cid and uid=k.id)),0) as 'carstar',p.city as 'cityname',b.country_name,c.state_name,d.make_type,e.model,f.badge_type,g.series_type,h.transmision,i.currency as 'currencyname',j.odometer,k.id,a.*,k.name,l.cylinder_name,m.speedtypename,n.ensize_name,o.Body_Type as 'bodytypename',k.zip,k.cno,k.orgname,k.showphone from tbl_carmaster a,tbl_country_master b,tbl_state_master c,MakeTypeMaster d,ModelMaster e,BadgeTypeMaster f,SeriesTypeMaster g,TransmisionMaster h,tbl_currency_master i,OdoMeterMaster j,tbl_login k,Cylinder_Master l,SpeedTypeMaster m,EngineSizeMaster n,Body_TypeMaster o,CityMaster p where p.city_id=k.city and o.Body_type_id=a.body_type and n.ensize_id=a.engine and m.speedtypeid=a.speedtype and l.cylinder_id=a.cylinder and d.make_id=a.make and e.model_id=a.model and f.bad_id=a.badge and g.ser_id=a.series and h.trans_id=a.transmition and i.cur_id=a.currency and j.odo_id=a.matrics and k.id=a.uid and k.country=b.count_id and k.state=c.state_id  and a.status = 1 and a.make='" + make + "'  and k.country='" + country + "'", con);

            }

            if (make != 0 && model != 0 && fyear == 0 && tyear == 0 && country != 0 && state == 0 && minprice == 0 && maxprice == 0 && keyword == "")
            {
                cmd = new SqlCommand("SELECT ISNULL(((select status from carwatchlist  where cid=a.cid and uid=k.id)),0) as 'carstar',p.city as 'cityname',b.country_name,c.state_name,d.make_type,e.model,f.badge_type,g.series_type,h.transmision,i.currency as 'currencyname',j.odometer,k.id,a.*,k.name,l.cylinder_name,m.speedtypename,n.ensize_name,o.Body_Type as 'bodytypename',k.zip,k.cno,k.orgname,k.showphone from tbl_carmaster a,tbl_country_master b,tbl_state_master c,MakeTypeMaster d,ModelMaster e,BadgeTypeMaster f,SeriesTypeMaster g,TransmisionMaster h,tbl_currency_master i,OdoMeterMaster j,tbl_login k,Cylinder_Master l,SpeedTypeMaster m,EngineSizeMaster n,Body_TypeMaster o,CityMaster p where p.city_id=k.city and o.Body_type_id=a.body_type and n.ensize_id=a.engine and m.speedtypeid=a.speedtype and l.cylinder_id=a.cylinder and d.make_id=a.make and e.model_id=a.model and f.bad_id=a.badge and g.ser_id=a.series and h.trans_id=a.transmition and i.cur_id=a.currency and j.odo_id=a.matrics and k.id=a.uid and k.country=b.count_id and k.state=c.state_id  and a.status = 1 and a.make='" + make + "' and a.model='" + model + "' and k.country='" + country + "'", con);

            }
            if (make == 0 && model == 0 && fyear == 0 && tyear == 0 && country != 0 && state == 0 && minprice == 0 && maxprice == 0 && keyword == "")
            {
                cmd = new SqlCommand("SELECT ISNULL(((select status from carwatchlist  where cid=a.cid and uid=k.id)),0) as 'carstar',p.city as 'cityname',b.country_name,c.state_name,d.make_type,e.model,f.badge_type,g.series_type,h.transmision,i.currency as 'currencyname',j.odometer,k.id,a.*,k.name,l.cylinder_name,m.speedtypename,n.ensize_name,o.Body_Type as 'bodytypename',k.zip,k.cno,k.orgname,k.showphone from tbl_carmaster a,tbl_country_master b,tbl_state_master c,MakeTypeMaster d,ModelMaster e,BadgeTypeMaster f,SeriesTypeMaster g,TransmisionMaster h,tbl_currency_master i,OdoMeterMaster j,tbl_login k,Cylinder_Master l,SpeedTypeMaster m,EngineSizeMaster n,Body_TypeMaster o,CityMaster p where p.city_id=k.city and o.Body_type_id=a.body_type and n.ensize_id=a.engine and m.speedtypeid=a.speedtype and l.cylinder_id=a.cylinder and d.make_id=a.make and e.model_id=a.model and f.bad_id=a.badge and g.ser_id=a.series and h.trans_id=a.transmition and i.cur_id=a.currency and j.odo_id=a.matrics and k.id=a.uid and k.country=b.count_id and k.state=c.state_id  and a.status = 1 and k.country='" + country + "'", con);

            }

            if (make != 0 && model != 0 && fyear != 0 && tyear != 0 && country != 0 && state != 0 && minprice == 0 && maxprice == 0 && keyword == "")
            {
                cmd = new SqlCommand("SELECT ISNULL(((select status from carwatchlist  where cid=a.cid and uid=k.id)),0) as 'carstar',p.city as 'cityname',b.country_name,c.state_name,d.make_type,e.model,f.badge_type,g.series_type,h.transmision,i.currency as 'currencyname',j.odometer,k.id,a.*,k.name,l.cylinder_name,m.speedtypename,n.ensize_name,o.Body_Type as 'bodytypename',k.zip,k.cno,k.orgname,k.showphone from tbl_carmaster a,tbl_country_master b,tbl_state_master c,MakeTypeMaster d,ModelMaster e,BadgeTypeMaster f,SeriesTypeMaster g,TransmisionMaster h,tbl_currency_master i,OdoMeterMaster j,tbl_login k,Cylinder_Master l,SpeedTypeMaster m,EngineSizeMaster n,Body_TypeMaster o,CityMaster p where p.city_id=k.city and o.Body_type_id=a.body_type and n.ensize_id=a.engine and m.speedtypeid=a.speedtype and l.cylinder_id=a.cylinder and d.make_id=a.make and e.model_id=a.model and f.bad_id=a.badge and g.ser_id=a.series and h.trans_id=a.transmition and i.cur_id=a.currency and j.odo_id=a.matrics and k.id=a.uid and k.country=b.count_id and k.state=c.state_id  and a.status = 1 and a.make='" + make + "' and a.model='" + model + "' and a.year between '" + fyear + "' and '" + tyear + "' and k.country='" + country + "' and k.state='" + state + "'", con);

            }

            if (make != 0 && model != 0 && fyear == 0 && tyear == 0 && country != 0 && state != 0 && minprice == 0 && maxprice == 0 && keyword == "")
            {
                cmd = new SqlCommand("SELECT ISNULL(((select status from carwatchlist  where cid=a.cid and uid=k.id)),0) as 'carstar',p.city as 'cityname',b.country_name,c.state_name,d.make_type,e.model,f.badge_type,g.series_type,h.transmision,i.currency as 'currencyname',j.odometer,k.id,a.*,k.name,l.cylinder_name,m.speedtypename,n.ensize_name,o.Body_Type as 'bodytypename',k.zip,k.cno,k.orgname,k.showphone from tbl_carmaster a,tbl_country_master b,tbl_state_master c,MakeTypeMaster d,ModelMaster e,BadgeTypeMaster f,SeriesTypeMaster g,TransmisionMaster h,tbl_currency_master i,OdoMeterMaster j,tbl_login k,Cylinder_Master l,SpeedTypeMaster m,EngineSizeMaster n,Body_TypeMaster o,CityMaster p where p.city_id=k.city and o.Body_type_id=a.body_type and n.ensize_id=a.engine and m.speedtypeid=a.speedtype and l.cylinder_id=a.cylinder and d.make_id=a.make and e.model_id=a.model and f.bad_id=a.badge and g.ser_id=a.series and h.trans_id=a.transmition and i.cur_id=a.currency and j.odo_id=a.matrics and k.id=a.uid and k.country=b.count_id and k.state=c.state_id  and a.status = 1 and a.make='" + make + "' and a.model='" + model + "' and k.country='" + country + "' and k.state='" + state + "'", con);

            }

            if (make != 0 && model != 0 && fyear == 0 && tyear == 0 && country != 0 && state == 0 && minprice == 0 && maxprice == 0 && keyword == "")
            {
                cmd = new SqlCommand("SELECT ISNULL(((select status from carwatchlist  where cid=a.cid and uid=k.id)),0) as 'carstar',p.city as 'cityname',b.country_name,c.state_name,d.make_type,e.model,f.badge_type,g.series_type,h.transmision,i.currency as 'currencyname',j.odometer,k.id,a.*,k.name,l.cylinder_name,m.speedtypename,n.ensize_name,o.Body_Type as 'bodytypename',k.zip,k.cno,k.orgname,k.showphone from tbl_carmaster a,tbl_country_master b,tbl_state_master c,MakeTypeMaster d,ModelMaster e,BadgeTypeMaster f,SeriesTypeMaster g,TransmisionMaster h,tbl_currency_master i,OdoMeterMaster j,tbl_login k,Cylinder_Master l,SpeedTypeMaster m,EngineSizeMaster n,Body_TypeMaster o,CityMaster p where p.city_id=k.city and o.Body_type_id=a.body_type and n.ensize_id=a.engine and m.speedtypeid=a.speedtype and l.cylinder_id=a.cylinder and d.make_id=a.make and e.model_id=a.model and f.bad_id=a.badge and g.ser_id=a.series and h.trans_id=a.transmition and i.cur_id=a.currency and j.odo_id=a.matrics and k.id=a.uid and k.country=b.count_id and k.state=c.state_id  and a.status = 1 and a.make='" + make + "' and a.model='" + model + "'  and k.country='" + country + "'", con);

            }

            if (make == 0 && model == 0 && fyear == 0 && tyear == 0 && country != 0 && state != 0 && minprice == 0 && maxprice == 0 && keyword == "")
            {
                cmd = new SqlCommand("SELECT ISNULL(((select status from carwatchlist  where cid=a.cid and uid=k.id)),0) as 'carstar',p.city as 'cityname',b.country_name,c.state_name,d.make_type,e.model,f.badge_type,g.series_type,h.transmision,i.currency as 'currencyname',j.odometer,k.id,a.*,k.name,l.cylinder_name,m.speedtypename,n.ensize_name,o.Body_Type as 'bodytypename',k.zip,k.cno,k.orgname,k.showphone from tbl_carmaster a,tbl_country_master b,tbl_state_master c,MakeTypeMaster d,ModelMaster e,BadgeTypeMaster f,SeriesTypeMaster g,TransmisionMaster h,tbl_currency_master i,OdoMeterMaster j,tbl_login k,Cylinder_Master l,SpeedTypeMaster m,EngineSizeMaster n,Body_TypeMaster o,CityMaster p where p.city_id=k.city and o.Body_type_id=a.body_type and n.ensize_id=a.engine and m.speedtypeid=a.speedtype and l.cylinder_id=a.cylinder and d.make_id=a.make and e.model_id=a.model and f.bad_id=a.badge and g.ser_id=a.series and h.trans_id=a.transmition and i.cur_id=a.currency and j.odo_id=a.matrics and k.id=a.uid and k.country=b.count_id and k.state=c.state_id  and a.status = 1  and k.country='" + country + "' and k.state='" + state + "'", con);

            }

            if (make != 0 && model != 0 && fyear != 0 && tyear != 0 && country != 0 && state != 0 && minprice != 0 && maxprice != 0 && keyword == "")
            {
                cmd = new SqlCommand("SELECT ISNULL(((select status from carwatchlist  where cid=a.cid and uid=k.id)),0) as 'carstar',p.city as 'cityname',b.country_name,c.state_name,d.make_type,e.model,f.badge_type,g.series_type,h.transmision,i.currency as 'currencyname',j.odometer,k.id,a.*,k.name,l.cylinder_name,m.speedtypename,n.ensize_name,o.Body_Type as 'bodytypename',k.zip,k.cno,k.orgname,k.showphone from tbl_carmaster a,tbl_country_master b,tbl_state_master c,MakeTypeMaster d,ModelMaster e,BadgeTypeMaster f,SeriesTypeMaster g,TransmisionMaster h,tbl_currency_master i,OdoMeterMaster j,tbl_login k,Cylinder_Master l,SpeedTypeMaster m,EngineSizeMaster n,Body_TypeMaster o,CityMaster p where p.city_id=k.city and o.Body_type_id=a.body_type and n.ensize_id=a.engine and m.speedtypeid=a.speedtype and l.cylinder_id=a.cylinder and d.make_id=a.make and e.model_id=a.model and f.bad_id=a.badge and g.ser_id=a.series and h.trans_id=a.transmition and i.cur_id=a.currency and j.odo_id=a.matrics and k.id=a.uid and k.country=b.count_id and k.state=c.state_id  and a.status = 1 and a.make='" + make + "' and a.model='" + model + "' and a.year between '" + fyear + "' and '" + tyear + "' and k.country='" + country + "' and k.state='" + state + "' and a.price between '" + minprice + "' and '" + maxprice + "'", con);

            }

            if (make == 0 && model == 0 && fyear == 0 && tyear == 0 && country == 0 && state == 0 && minprice != 0 && maxprice != 0 && keyword == "")
            {
                cmd = new SqlCommand("SELECT ISNULL(((select status from carwatchlist  where cid=a.cid and uid=k.id)),0) as 'carstar',p.city as 'cityname',b.country_name,c.state_name,d.make_type,e.model,f.badge_type,g.series_type,h.transmision,i.currency as 'currencyname',j.odometer,k.id,a.*,k.name,l.cylinder_name,m.speedtypename,n.ensize_name,o.Body_Type as 'bodytypename',k.zip,k.cno,k.orgname,k.showphone from tbl_carmaster a,tbl_country_master b,tbl_state_master c,MakeTypeMaster d,ModelMaster e,BadgeTypeMaster f,SeriesTypeMaster g,TransmisionMaster h,tbl_currency_master i,OdoMeterMaster j,tbl_login k,Cylinder_Master l,SpeedTypeMaster m,EngineSizeMaster n,Body_TypeMaster o,CityMaster p where p.city_id=k.city and o.Body_type_id=a.body_type and n.ensize_id=a.engine and m.speedtypeid=a.speedtype and l.cylinder_id=a.cylinder and d.make_id=a.make and e.model_id=a.model and f.bad_id=a.badge and g.ser_id=a.series and h.trans_id=a.transmition and i.cur_id=a.currency and j.odo_id=a.matrics and k.id=a.uid and k.country=b.count_id and k.state=c.state_id  and a.status = 1 and a.price between '" + minprice + "' and '" + maxprice + "'", con);

            }

            if (make != 0 && model != 0 && fyear != 0 && tyear != 0 && country != 0 && state != 0 && minprice != 0 && maxprice != 0 && keyword == "")
            {
                cmd = new SqlCommand("SELECT ISNULL(((select status from carwatchlist  where cid=a.cid and uid=k.id)),0) as 'carstar',p.city as 'cityname',b.country_name,c.state_name,d.make_type,e.model,f.badge_type,g.series_type,h.transmision,i.currency as 'currencyname',j.odometer,k.id,a.*,k.name,l.cylinder_name,m.speedtypename,n.ensize_name,o.Body_Type as 'bodytypename',k.zip,k.cno,k.orgname,k.showphone from tbl_carmaster a,tbl_country_master b,tbl_state_master c,MakeTypeMaster d,ModelMaster e,BadgeTypeMaster f,SeriesTypeMaster g,TransmisionMaster h,tbl_currency_master i,OdoMeterMaster j,tbl_login k,Cylinder_Master l,SpeedTypeMaster m,EngineSizeMaster n,Body_TypeMaster o,CityMaster p where p.city_id=k.city and o.Body_type_id=a.body_type and n.ensize_id=a.engine and m.speedtypeid=a.speedtype and l.cylinder_id=a.cylinder and d.make_id=a.make and e.model_id=a.model and f.bad_id=a.badge and g.ser_id=a.series and h.trans_id=a.transmition and i.cur_id=a.currency and j.odo_id=a.matrics and k.id=a.uid and k.country=b.count_id and k.state=c.state_id  and a.status = 1 and a.make='" + make + "' and a.model='" + model + "' and a.year between '" + fyear + "' and '" + tyear + "' and k.country='" + country + "' and k.state='" + state + "' and a.price between '" + minprice + "' and '" + maxprice + "'", con);

            }

            //All
            if (make != 0 && model != 0 && fyear != 0 && tyear != 0 && country != 0 && state != 0 && minprice != 0 && maxprice != 0 && keyword != "")
            {
                cmd = new SqlCommand("SELECT ISNULL(((select status from carwatchlist  where cid=a.cid and uid=k.id)),0) as 'carstar',p.city as 'cityname',b.country_name,c.state_name,d.make_type,e.model,f.badge_type,g.series_type,h.transmision,i.currency as 'currencyname',j.odometer,k.id,a.*,k.name,l.cylinder_name,m.speedtypename,n.ensize_name,o.Body_Type as 'bodytypename',k.zip,k.cno,k.orgname,k.showphone from tbl_carmaster a,tbl_country_master b,tbl_state_master c,MakeTypeMaster d,ModelMaster e,BadgeTypeMaster f,SeriesTypeMaster g,TransmisionMaster h,tbl_currency_master i,OdoMeterMaster j,tbl_login k,Cylinder_Master l,SpeedTypeMaster m,EngineSizeMaster n,Body_TypeMaster o,CityMaster p where p.city_id=k.city and o.Body_type_id=a.body_type and n.ensize_id=a.engine and m.speedtypeid=a.speedtype and l.cylinder_id=a.cylinder and d.make_id=a.make and e.model_id=a.model and f.bad_id=a.badge and g.ser_id=a.series and h.trans_id=a.transmition and i.cur_id=a.currency and j.odo_id=a.matrics and k.id=a.uid and k.country=b.count_id and k.state=c.state_id  and a.status = 1 and a.make='" + make + "' and a.model='" + model + "' and a.year between '" + fyear + "' and '" + tyear + "' and k.country='" + country + "' and k.state='" + state + "' and a.price between '" + minprice + "' and '" + maxprice + "'", con);

            }

            //For Only Keyword
            if (make == 0 && model == 0 && fyear == 0 && tyear == 0 && country == 0 && state == 0 && minprice == 0 && maxprice == 0 && keyword != "")
            {
                cmd = new SqlCommand("SELECT ISNULL(((select status from carwatchlist  where cid=a.cid and uid=k.id)),0) as 'carstar',p.city as 'cityname',b.country_name,c.state_name,d.make_type,e.model,f.badge_type,g.series_type,h.transmision,i.currency as 'currencyname',j.odometer,k.id,a.*,k.name,l.cylinder_name,m.speedtypename,n.ensize_name,o.Body_Type as 'bodytypename',k.zip,k.cno,k.orgname,k.showphone from tbl_carmaster a,tbl_country_master b,tbl_state_master c,MakeTypeMaster d,ModelMaster e,BadgeTypeMaster f,SeriesTypeMaster g,TransmisionMaster h,tbl_currency_master i,OdoMeterMaster j,tbl_login k,Cylinder_Master l,SpeedTypeMaster m,EngineSizeMaster n,Body_TypeMaster o,CityMaster p where p.city_id=k.city and o.Body_type_id=a.body_type and n.ensize_id=a.engine and m.speedtypeid=a.speedtype and l.cylinder_id=a.cylinder and d.make_id=a.make and e.model_id=a.model and f.bad_id=a.badge and g.ser_id=a.series and h.trans_id=a.transmition and i.cur_id=a.currency and j.odo_id=a.matrics and k.id=a.uid and k.country=b.count_id and k.state=c.state_id  and a.status = 1 ", con);

            }

            if (make == 0 && model == 0 && fyear != 0 && tyear != 0 && country != 0 && state != 0 && minprice != 0 && maxprice != 0 && keyword != "")
            {
                cmd = new SqlCommand("SELECT ISNULL(((select status from carwatchlist  where cid=a.cid and uid=k.id)),0) as 'carstar',p.city as 'cityname',b.country_name,c.state_name,d.make_type,e.model,f.badge_type,g.series_type,h.transmision,i.currency as 'currencyname',j.odometer,k.id,a.*,k.name,l.cylinder_name,m.speedtypename,n.ensize_name,o.Body_Type as 'bodytypename',k.zip,k.cno,k.orgname,k.showphone from tbl_carmaster a,tbl_country_master b,tbl_state_master c,MakeTypeMaster d,ModelMaster e,BadgeTypeMaster f,SeriesTypeMaster g,TransmisionMaster h,tbl_currency_master i,OdoMeterMaster j,tbl_login k,Cylinder_Master l,SpeedTypeMaster m,EngineSizeMaster n,Body_TypeMaster o,CityMaster p where p.city_id=k.city and o.Body_type_id=a.body_type and n.ensize_id=a.engine and m.speedtypeid=a.speedtype and l.cylinder_id=a.cylinder and d.make_id=a.make and e.model_id=a.model and f.bad_id=a.badge and g.ser_id=a.series and h.trans_id=a.transmition and i.cur_id=a.currency and j.odo_id=a.matrics and k.id=a.uid and k.country=b.count_id and k.state=c.state_id  and a.status = 1   and a.year between '" + fyear + "' and '" + tyear + "' and k.country='" + country + "' and k.state='" + state + "' and a.price between '" + minprice + "' and '" + maxprice + "'", con);

            }

            if (make == 0 && model == 0 && fyear == 0 && tyear == 0 && country != 0 && state != 0 && minprice != 0 && maxprice != 0 && keyword != "")
            {
                cmd = new SqlCommand("SELECT ISNULL(((select status from carwatchlist  where cid=a.cid and uid=k.id)),0) as 'carstar',p.city as 'cityname',b.country_name,c.state_name,d.make_type,e.model,f.badge_type,g.series_type,h.transmision,i.currency as 'currencyname',j.odometer,k.id,a.*,k.name,l.cylinder_name,m.speedtypename,n.ensize_name,o.Body_Type as 'bodytypename',k.zip,k.cno,k.orgname,k.showphone from tbl_carmaster a,tbl_country_master b,tbl_state_master c,MakeTypeMaster d,ModelMaster e,BadgeTypeMaster f,SeriesTypeMaster g,TransmisionMaster h,tbl_currency_master i,OdoMeterMaster j,tbl_login k,Cylinder_Master l,SpeedTypeMaster m,EngineSizeMaster n,Body_TypeMaster o,CityMaster p where p.city_id=k.city and o.Body_type_id=a.body_type and n.ensize_id=a.engine and m.speedtypeid=a.speedtype and l.cylinder_id=a.cylinder and d.make_id=a.make and e.model_id=a.model and f.bad_id=a.badge and g.ser_id=a.series and h.trans_id=a.transmition and i.cur_id=a.currency and j.odo_id=a.matrics and k.id=a.uid and k.country=b.count_id and k.state=c.state_id  and a.status = 1   and k.country='" + country + "' and k.state='" + state + "' and a.price between '" + minprice + "' and '" + maxprice + "'", con);

            }


            if (make == 0 && model == 0 && fyear == 0 && tyear == 0 && country == 0 && state == 0 && minprice != 0 && maxprice != 0 && keyword != "")
            {
                cmd = new SqlCommand("SELECT ISNULL(((select status from carwatchlist  where cid=a.cid and uid=k.id)),0) as 'carstar',p.city as 'cityname',b.country_name,c.state_name,d.make_type,e.model,f.badge_type,g.series_type,h.transmision,i.currency as 'currencyname',j.odometer,k.id,a.*,k.name,l.cylinder_name,m.speedtypename,n.ensize_name,o.Body_Type as 'bodytypename',k.zip,k.cno,k.orgname,k.showphone from tbl_carmaster a,tbl_country_master b,tbl_state_master c,MakeTypeMaster d,ModelMaster e,BadgeTypeMaster f,SeriesTypeMaster g,TransmisionMaster h,tbl_currency_master i,OdoMeterMaster j,tbl_login k,Cylinder_Master l,SpeedTypeMaster m,EngineSizeMaster n,Body_TypeMaster o,CityMaster p where p.city_id=k.city and o.Body_type_id=a.body_type and n.ensize_id=a.engine and m.speedtypeid=a.speedtype and l.cylinder_id=a.cylinder and d.make_id=a.make and e.model_id=a.model and f.bad_id=a.badge and g.ser_id=a.series and h.trans_id=a.transmition and i.cur_id=a.currency and j.odo_id=a.matrics and k.id=a.uid and k.country=b.count_id and k.state=c.state_id  and a.status = 1   and a.price between '" + minprice + "' and '" + maxprice + "'", con);

            }
            con.Open();
            da = new SqlDataAdapter(cmd);
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
                        series = dt.Rows[i]["series_type"].ToString(),
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
                        star = Convert.ToInt32(dt.Rows[i]["carstar"].ToString()),
                        img3 = dt.Rows[i]["img3"].ToString(),
                        img4 = dt.Rows[i]["img4"].ToString(),
                        img5 = dt.Rows[i]["img5"].ToString(),
                        created_date = dt.Rows[i]["created_date"].ToString(),
                        showphone = Convert.ToInt32(dt.Rows[i]["showphone"].ToString()),
                        cno = dt.Rows[i]["cno"].ToString(),
                        orgname = dt.Rows[i]["orgname"].ToString()

                    });
                }
            }



            regmodel.carlist = carlist;

            return View(regmodel);

        }

        [WebMethod]
        [HttpPost]
        public JObject AdvanceSearchEvent(string cat, string eventdue, string country, string state, string eventkeyword, string spons, string loginid, string filterval)
        {


            DataTable dt = new DataTable();
            List<EventViewModel> eventlist1 = new List<EventViewModel>();

            RegisterViewModel eventmodel = new RegisterViewModel();
            con = new SqlConnection(constr);

            cmd = new SqlCommand("AdvanceSearchEvent", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cat", cat);
            cmd.Parameters.AddWithValue("@eventdue", eventdue);
            cmd.Parameters.AddWithValue("@country", country);
            cmd.Parameters.AddWithValue("@state", state);
            cmd.Parameters.AddWithValue("@keyword", eventkeyword);
            cmd.Parameters.AddWithValue("@spons", spons);
            cmd.Parameters.AddWithValue("@loginid", loginid);
            cmd.Parameters.AddWithValue("@filterval", filterval);


            con.Open();
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
                        date = Convert.ToDateTime(dt.Rows[i]["edate"].ToString()).ToString("dd/MM/yyyy"),
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
                        ispaid = Convert.ToInt32(dt.Rows[i]["ispaid"].ToString()),
                        create_date = Convert.ToDateTime(dt.Rows[i]["created_date"].ToString()),
                        price = Convert.ToInt32(dt.Rows[i]["price"].ToString()),
                        showphone = Convert.ToInt32(dt.Rows[i]["shownumber"].ToString()),
                        going = dt.Rows[i]["going"].ToString(),
                        goORgoing = dt.Rows[i]["goORgoing"].ToString()



                    });
                }



            }


            JObject json = new JObject();
            json["eventlist"] = JToken.FromObject(eventlist1);
            return json;
        }

        [WebMethod]
        [HttpPost]
        public JObject AdvanceSearchEventMap(string cat, string eventdue, string country, string state, string eventkeyword, string spons)
        {



            List<EventModel> UserList = new List<EventModel>();
            JObject json = new JObject();
            con = new SqlConnection(constr);
            cmd = new SqlCommand("AdvanceSearchEventMap", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cat", cat);
            cmd.Parameters.AddWithValue("@eventdue", eventdue);
            cmd.Parameters.AddWithValue("@country", country);
            cmd.Parameters.AddWithValue("@state", state);
            cmd.Parameters.AddWithValue("@keyword", eventkeyword);
            cmd.Parameters.AddWithValue("@spons", spons);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind EmpModel generic list using dataRow 
            foreach (DataRow dr in dt.Rows)
            {
                UserList.Add(
                    new EventModel
                    {
                        eid = ConvertHelper.Encode(dr["eid"].ToString()),
                        category = dr["category"].ToString(),
                        img = dr["img"].ToString(),
                        title = Convert.ToString(dr["title"].ToString()),
                        subject = Convert.ToString(dr["subject"].ToString()),
                        date = Convert.ToDateTime(dr["edate"].ToString()).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                        // type = dr["type"].ToString(),
                        late = dr["late"].ToString(),
                        lonz = dr["long"].ToString(),
                        status = Convert.ToInt32(dr["status"].ToString()),
                        city_name = dr["cityname"].ToString(),
                        country_name = dr["country_name"].ToString(),
                        state_name = dr["state_name"].ToString(),
                        going = dr["going"].ToString(),
                        postcode = dr["code"].ToString(),
                    }
                    );
            }
            json["userlist"] = JToken.FromObject(UserList);
            return json;

        }

        public ActionResult UserAdvanceSearchEvent(int cat, string eventdue, int country, int state, string eventkeyword)
        {


            DataTable dt = new DataTable();
            List<EventViewModel> eventlist1 = new List<EventViewModel>();

            RegisterViewModel eventmodel = new RegisterViewModel();
            con = new SqlConnection(constr);
            cmd = new SqlCommand("SELECT  b.country_name,c.state_name,a.*,d.name,(select count(*) from eventgoingmaster where eid=a.eid) as 'going' from tbl_eventmaster a,tbl_country_master b,tbl_state_master c,tbl_login d where b.count_id=a.country and c.state_id=a.state and  d.id=a.uid and a.status = 1", con);

            if (cat != 0 && eventdue == "0" && country == 0 && state == 0 && eventkeyword == "")
            {

                cmd = new SqlCommand("SELECT  b.country_name,c.state_name,a.*,d.name,(select count(*) from eventgoingmaster where eid=a.eid) as 'going' from tbl_eventmaster a,tbl_country_master b,tbl_state_master c,tbl_login d where b.count_id=a.country and c.state_id=a.state and  d.id=a.uid and a.status = 1 and a.cat='" + cat + "'", con);

            }


            if (cat != 0 && eventdue == "going" && country == 0 && state == 0 && eventkeyword == "")
            {

                cmd = new SqlCommand("SELECT  b.country_name,c.state_name,a.*,d.name,(select count(*) from eventgoingmaster where eid=a.eid) as 'going' from tbl_eventmaster a,tbl_country_master b,tbl_state_master c,tbl_login d where b.count_id=a.country and c.state_id=a.state and  d.id=a.uid and a.status = 1 and a.cat='" + cat + "' and a.edate = '" + DateTime.Now.ToString() + "'", con);

            }

            if (cat != 0 && eventdue == "upcomming" && country == 0 && state == 0 && eventkeyword == "")
            {

                cmd = new SqlCommand("SELECT  b.country_name,c.state_name,a.*,d.name,(select count(*) from eventgoingmaster where eid=a.eid) as 'going' from tbl_eventmaster a,tbl_country_master b,tbl_state_master c,tbl_login d where b.count_id=a.country and c.state_id=a.state and  d.id=a.uid and a.status = 1 and a.cat='" + cat + "' and a.edate > '" + DateTime.Now.ToString() + "'", con);

            }

            if (cat != 0 && eventdue == "due" && country == 0 && state == 0 && eventkeyword == "")
            {

                cmd = new SqlCommand("SELECT  b.country_name,c.state_name,a.*,d.name,(select count(*) from eventgoingmaster where eid=a.eid) as 'going' from tbl_eventmaster a,tbl_country_master b,tbl_state_master c,tbl_login d where b.count_id=a.country and c.state_id=a.state and  d.id=a.uid and a.status = 1 and a.cat='" + cat + "' and a.edate < '" + DateTime.Now.ToString() + "'", con);

            }

            if (cat != 0 && eventdue == "0" && country != 0 && state == 0 && eventkeyword == "")
            {

                cmd = new SqlCommand("SELECT  b.country_name,c.state_name,a.*,d.name,(select count(*) from eventgoingmaster where eid=a.eid) as 'going' from tbl_eventmaster a,tbl_country_master b,tbl_state_master c,tbl_login d where b.count_id=a.country and c.state_id=a.state and  d.id=a.uid and a.status = 1 and a.cat='" + cat + "' and a.country='" + country + "'", con);

            }

            if (cat != 0 && eventdue == "0" && country != 0 && state != 0 && eventkeyword == "")
            {

                cmd = new SqlCommand("SELECT  b.country_name,c.state_name,a.*,d.name,(select count(*) from eventgoingmaster where eid=a.eid) as 'going' from tbl_eventmaster a,tbl_country_master b,tbl_state_master c,tbl_login d where b.count_id=a.country and c.state_id=a.state and  d.id=a.uid and a.status = 1 and a.cat='" + cat + "' and a.country='" + country + "' and a.state='" + state + "'", con);

            }

            if (cat != 0 && eventdue == "0" && country != 0 && state != 0 && eventkeyword != "")
            {

                cmd = new SqlCommand("SELECT  b.country_name,c.state_name,a.*,d.name,(select count(*) from eventgoingmaster where eid=a.eid) as 'going' from tbl_eventmaster a,tbl_country_master b,tbl_state_master c,tbl_login d where b.count_id=a.country and c.state_id=a.state and  d.id=a.uid and a.status = 1 and a.cat='" + cat + "' and a.country='" + country + "' and a.state='" + state + "' and a.titel like '%" + eventkeyword + "%'", con);

            }

            if (cat == 0 && eventdue == "0" && country != 0 && state != 0 && eventkeyword == "")
            {

                cmd = new SqlCommand("SELECT  b.country_name,c.state_name,a.*,d.name,(select count(*) from eventgoingmaster where eid=a.eid) as 'going' from tbl_eventmaster a,tbl_country_master b,tbl_state_master c,tbl_login d where b.count_id=a.country and c.state_id=a.state and  d.id=a.uid and a.status = 1 and a.country='" + country + "' and a.state='" + state + "'", con);

            }
            if (cat == 0 && eventdue == "0" && country != 0 && state == 0 && eventkeyword == "")
            {

                cmd = new SqlCommand("SELECT  b.country_name,c.state_name,a.*,d.name,(select count(*) from eventgoingmaster where eid=a.eid) as 'going' from tbl_eventmaster a,tbl_country_master b,tbl_state_master c,tbl_login d where b.count_id=a.country and c.state_id=a.state and  d.id=a.uid and a.status = 1 and a.country='" + country + "'", con);

            }

            if (cat == 0 && eventdue == "0" && country != 0 && state == 0 && eventkeyword != "")
            {

                cmd = new SqlCommand("SELECT  b.country_name,c.state_name,a.*,d.name,(select count(*) from eventgoingmaster where eid=a.eid) as 'going' from tbl_eventmaster a,tbl_country_master b,tbl_state_master c,tbl_login d where b.count_id=a.country and c.state_id=a.state and  d.id=a.uid and a.status = 1 and a.country='" + country + "'  and a.titel like '%" + eventkeyword + "%'", con);

            }

            if (cat == 0 && eventdue == "0" && country != 0 && state != 0 && eventkeyword != "")
            {

                cmd = new SqlCommand("SELECT  b.country_name,c.state_name,a.*,d.name,(select count(*) from eventgoingmaster where eid=a.eid) as 'going' from tbl_eventmaster a,tbl_country_master b,tbl_state_master c,tbl_login d where b.count_id=a.country and c.state_id=a.state and  d.id=a.uid and a.status = 1 and a.country='" + country + "' and a.state='" + state + "' and a.titel like '%" + eventkeyword + "%'", con);

            }

            if (cat != 0 && eventdue == "0" && country != 0 && state == 0 && eventkeyword == "")
            {

                cmd = new SqlCommand("SELECT  b.country_name,c.state_name,a.*,d.name,(select count(*) from eventgoingmaster where eid=a.eid) as 'going' from tbl_eventmaster a,tbl_country_master b,tbl_state_master c,tbl_login d where b.count_id=a.country and c.state_id=a.state and  d.id=a.uid and a.status = 1 and a.cat='" + cat + "' and a.country='" + country + "'", con);

            }
            if (cat != 0 && eventdue == "0" && country != 0 && state != 0 && eventkeyword == "")
            {

                cmd = new SqlCommand("SELECT  b.country_name,c.state_name,a.*,d.name,(select count(*) from eventgoingmaster where eid=a.eid) as 'going' from tbl_eventmaster a,tbl_country_master b,tbl_state_master c,tbl_login d where b.count_id=a.country and c.state_id=a.state and  d.id=a.uid and a.status = 1 and a.cat='" + cat + "' and a.country='" + country + "' and a.state='" + state + "'", con);

            }
            if (cat != 0 && eventdue == "0" && country != 0 && state == 0 && eventkeyword != "")
            {

                cmd = new SqlCommand("SELECT  b.country_name,c.state_name,a.*,d.name,(select count(*) from eventgoingmaster where eid=a.eid) as 'going' from tbl_eventmaster a,tbl_country_master b,tbl_state_master c,tbl_login d where b.count_id=a.country and c.state_id=a.state and  d.id=a.uid and a.status = 1 and a.cat='" + cat + "' and a.country='" + country + "' and a.title like '%" + eventkeyword + "%'", con);

            }

            if (cat != 0 && eventdue == "0" && country != 0 && state != 0 && eventkeyword != "")
            {

                cmd = new SqlCommand("SELECT  b.country_name,c.state_name,a.*,d.name,(select count(*) from eventgoingmaster where eid=a.eid) as 'going' from tbl_eventmaster a,tbl_country_master b,tbl_state_master c,tbl_login d where b.count_id=a.country and c.state_id=a.state and  d.id=a.uid and a.status = 1 and a.cat='" + cat + "' and a.country='" + country + "' and a.state='" + state + "' and a.title like '%" + eventkeyword + "%'", con);

            }



            con.Open();
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
                        city = dt.Rows[i]["city"].ToString(),
                        descr = dt.Rows[i]["descr"].ToString(),
                        late = dt.Rows[i]["late"].ToString(),
                        lonz = dt.Rows[i]["long"].ToString(),
                        status = Convert.ToInt32(dt.Rows[i]["status"].ToString()),
                        img = dt.Rows[i]["img"].ToString(),
                        img1 = dt.Rows[i]["img1"].ToString(),
                        img2 = dt.Rows[i]["img2"].ToString(),
                        reason = dt.Rows[i]["reason"].ToString(),
                        suburb = dt.Rows[i]["suburb"].ToString(),
                        code = dt.Rows[i]["code"].ToString(),
                        unit = dt.Rows[i]["unit"].ToString(),
                        street = dt.Rows[i]["street"].ToString(),
                        sname = dt.Rows[i]["sname"].ToString(),
                        cat = Convert.ToInt32(dt.Rows[i]["cat"].ToString()),
                        ispaid = Convert.ToInt32(dt.Rows[i]["ispaid"].ToString()),
                        create_date = Convert.ToDateTime(dt.Rows[i]["created_date"].ToString()),
                        price = Convert.ToInt32(dt.Rows[i]["price"].ToString()),
                        showphone = Convert.ToInt32(dt.Rows[i]["shownumber"].ToString()),
                        going = dt.Rows[i]["going"].ToString()


                    });
                }



            }
            eventmodel.eventlist = eventlist1;

            return View(eventmodel);
        }

        [AuthonticateUserHelper]
        public ActionResult UserCarMaster(string option = "0")
        {
            if (option == "0")
            {

                option = "CID";
            }
            //return View();

            DataTable dt = new DataTable();
            List<CarModel> carlist = new List<CarModel>();
            RegisterViewModel model = new RegisterViewModel();
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
                            int carid = Convert.ToInt32(dt.Rows[i]["cid"].ToString());
                            string uid = Session["id"].ToString();

                            SqlCommand cmd1 = new SqlCommand("select * from CarWatchList where cid='" + carid + "' and uid ='" + uid + "'", con);
                            SqlDataReader dr1 = cmd1.ExecuteReader();
                            string starget = "0";
                            if (dr1.Read())
                            {
                                starget = dr1["status"].ToString();
                            }
                            dr1.Close();
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
                                series = dt.Rows[i]["series_type"].ToString(),
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
                                star = Convert.ToInt32(starget),
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


            dt = new DataTable();
            List<EventViewModel> eventlist1 = new List<EventViewModel>();

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
                                going = dt.Rows[i]["going"].ToString()



                            });
                        }
                    }

                }
            }
            model.eventlist = eventlist1;
            model.carlist = carlist;
            return View("UserCarMaster", model);

        }

        [AuthonticateUserHelper]
        public ActionResult UserEventMaster(string option = "0")
        {
            //return View();
            if (option == "0")
            {

                option = "CID";
            }

            DataTable dt = new DataTable();
            List<CarModel> carlist = new List<CarModel>();
            RegisterViewModel model = new RegisterViewModel();
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

                            int carid = Convert.ToInt32(dt.Rows[i]["cid"].ToString());
                            string uid = Session["id"].ToString();

                            SqlCommand cmd1 = new SqlCommand("select * from CarWatchList where cid='" + carid + "' and uid ='" + uid + "'", con);
                            SqlDataReader dr1 = cmd1.ExecuteReader();
                            string starget = "0";
                            if (dr1.Read())
                            {
                                starget = dr1["status"].ToString();
                            }
                            dr1.Close();
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
                                series = dt.Rows[i]["series_type"].ToString(),
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
                                star = Convert.ToInt32(starget),
                                img3 = dt.Rows[i]["img3"].ToString(),
                                img4 = dt.Rows[i]["img4"].ToString(),
                                img5 = dt.Rows[i]["img5"].ToString(),
                                created_date = dt.Rows[i]["created_date"].ToString(),
                                showphone = Convert.ToInt32(dt.Rows[i]["showphone"].ToString()),
                                cno = dt.Rows[i]["cno"].ToString(),
                                orgname = dt.Rows[i]["orgname"].ToString(),
                                suburb = dt.Rows[i]["regionname"].ToString()


                            });
                        }
                    }
                }
            }


            dt = new DataTable();
            List<EventViewModel> eventlist1 = new List<EventViewModel>();

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


                            });
                        }
                    }

                }
            }
            model.eventlist = eventlist1;
            model.carlist = carlist;
            return View(model);

        }

        public ActionResult CarDetails(string cid = "0")
        {
            cid = ConvertHelper.Decode(cid);
            con = new SqlConnection(constr);

            List<CarModel> cardetailslist = new List<CarModel>();

            RegisterViewModel model = new RegisterViewModel();
            SqlCommand com = new SqlCommand("CarDetails", con);
            com.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            com.Parameters.AddWithValue("@cid", cid);
            da.Fill(dt);
            con.Close();

            if (dt.Rows.Count > 0)
            {

                cardetailslist.Add(new CarModel
                {
                    cid = ConvertHelper.Encode(dt.Rows[0]["cid"].ToString()),
                    uid = Convert.ToInt32(dt.Rows[0]["uid"].ToString()),
                    make = dt.Rows[0]["make_type"].ToString(),
                    price = dt.Rows[0]["price"].ToString(),
                    descr = TextToHtml(dt.Rows[0]["descr"].ToString()),
                    bcolor = dt.Rows[0]["body_color_name"].ToString(),
                    model = dt.Rows[0]["model"].ToString(),
                    engine = dt.Rows[0]["ensize_name"].ToString(),
                    year = Convert.ToInt32(dt.Rows[0]["year"].ToString()),
                    body_type = dt.Rows[0]["body_type"].ToString(),
                    tranmition = dt.Rows[0]["transmision"].ToString(),
                    status = Convert.ToInt32(dt.Rows[0]["status"].ToString()),
                    img = dt.Rows[0]["img"].ToString(),
                    img1 = dt.Rows[0]["img1"].ToString(),
                    img2 = dt.Rows[0]["img2"].ToString(),
                    uname = dt.Rows[0]["name"].ToString(),
                    country = dt.Rows[0]["country_name"].ToString(),
                    state = dt.Rows[0]["state_name"].ToString(),
                    badge = dt.Rows[0]["badge_type"].ToString(),
                    series = dt.Rows[0]["series_type"].ToString(),
                    currency = dt.Rows[0]["currencyname"].ToString(),
                    icolor = dt.Rows[0]["inter_color_name"].ToString(),
                    list = dt.Rows[0]["list"].ToString(),
                    material = dt.Rows[0]["inter_mat_name"].ToString(),
                    meter = dt.Rows[0]["meter"].ToString(),
                    matrics = dt.Rows[0]["odometer"].ToString(),
                    condition = dt.Rows[0]["condition"].ToString(),
                    cylinder = Convert.ToInt32(dt.Rows[0]["cylinder"].ToString()),
                    drive = dt.Rows[0]["drive"].ToString(),
                    created_date = dt.Rows[0]["created_date"].ToString(),
                    city = dt.Rows[0]["cityname"].ToString(),
                    fuel = dt.Rows[0]["fuel"].ToString(),
                    gstatus = dt.Rows[0]["gstatus"].ToString(),
                    speedtype = dt.Rows[0]["speedtypename"].ToString(),
                    star = Convert.ToInt32(dt.Rows[0]["star"].ToString()),
                    img3 = dt.Rows[0]["img3"].ToString(),
                    img4 = dt.Rows[0]["img4"].ToString(),
                    img5 = dt.Rows[0]["img5"].ToString(),
                    showphone = Convert.ToInt32(dt.Rows[0]["showphone"].ToString()),
                    cno = dt.Rows[0]["cno"].ToString(),
                    orgname = dt.Rows[0]["orgname"].ToString(),
                    zipcode = dt.Rows[0]["zip"].ToString(),
                    suburb = dt.Rows[0]["regionname"].ToString(),
                    cylinder_name = dt.Rows[0]["cylinder_name"].ToString(),
                    email = dt.Rows[0]["email"].ToString()


                });

            }

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
            dr.Close();
            con.Close();
            model.makelist = list;
            model.cardetailslist = cardetailslist;
            return View("CarDetails", model);

            //  return View();
        }

        [AuthonticateUserHelper]
        public ActionResult UserCarDetails(string cid = "0")
        {
            cid = ConvertHelper.Decode(cid);

            con = new SqlConnection(constr);

            List<CarModel> cardetailslist = new List<CarModel>();

            RegisterViewModel model = new RegisterViewModel();
            SqlCommand com = new SqlCommand("CarDetails", con);
            com.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            com.Parameters.AddWithValue("@cid", cid);
            da.Fill(dt);
            con.Close();

            if (dt.Rows.Count > 0)
            {

                cardetailslist.Add(new CarModel
                {
                    cid = ConvertHelper.Encode(dt.Rows[0]["cid"].ToString()),
                    uid = Convert.ToInt32(dt.Rows[0]["uid"].ToString()),
                    make = dt.Rows[0]["make_type"].ToString(),
                    price = dt.Rows[0]["price"].ToString(),
                    descr = TextToHtml(dt.Rows[0]["descr"].ToString()),
                    bcolor = dt.Rows[0]["body_color_name"].ToString(),
                    model = dt.Rows[0]["model"].ToString(),
                    engine = dt.Rows[0]["ensize_name"].ToString(),
                    year = Convert.ToInt32(dt.Rows[0]["year"].ToString()),
                    body_type = dt.Rows[0]["body_type"].ToString(),
                    tranmition = dt.Rows[0]["transmision"].ToString(),
                    status = Convert.ToInt32(dt.Rows[0]["status"].ToString()),
                    img = dt.Rows[0]["img"].ToString(),
                    img1 = dt.Rows[0]["img1"].ToString(),
                    img2 = dt.Rows[0]["img2"].ToString(),
                    uname = dt.Rows[0]["name"].ToString(),
                    country = dt.Rows[0]["country_name"].ToString(),
                    state = dt.Rows[0]["state_name"].ToString(),
                    badge = dt.Rows[0]["badge_type"].ToString(),
                    series = dt.Rows[0]["series_type"].ToString(),
                    currency = dt.Rows[0]["currencyname"].ToString(),
                    icolor = dt.Rows[0]["inter_color_name"].ToString(),
                    list = dt.Rows[0]["list"].ToString(),
                    material = dt.Rows[0]["inter_mat_name"].ToString(),
                    meter = dt.Rows[0]["meter"].ToString(),
                    matrics = dt.Rows[0]["odometer"].ToString(),
                    condition = dt.Rows[0]["condition"].ToString(),
                    cylinder = Convert.ToInt32(dt.Rows[0]["cylinder"].ToString()),
                    drive = dt.Rows[0]["drive"].ToString(),
                    created_date = dt.Rows[0]["created_date"].ToString(),
                    city = dt.Rows[0]["cityname"].ToString(),
                    fuel = dt.Rows[0]["fuel"].ToString(),
                    gstatus = dt.Rows[0]["gstatus"].ToString(),
                    speedtype = dt.Rows[0]["speedtypename"].ToString(),
                    star = Convert.ToInt32(dt.Rows[0]["carstar"].ToString()),
                    img3 = dt.Rows[0]["img3"].ToString(),
                    img4 = dt.Rows[0]["img4"].ToString(),
                    img5 = dt.Rows[0]["img5"].ToString(),
                    showphone = Convert.ToInt32(dt.Rows[0]["showphone"].ToString()),
                    cno = dt.Rows[0]["cno"].ToString(),
                    orgname = dt.Rows[0]["orgname"].ToString(),
                    zipcode = dt.Rows[0]["zip"].ToString(),
                    suburb = dt.Rows[0]["regionname"].ToString(),
                    cylinder_name = dt.Rows[0]["cylinder_name"].ToString(),
                    email = dt.Rows[0]["email"].ToString()




                });

            }


            model.cardetailslist = cardetailslist;
            return View("UserCarDetails", model);

            //  return View();
        }

        public ActionResult EventDetails(string eid = "0")
        {

            eid = ConvertHelper.Decode(eid);

            con = new SqlConnection(constr);

            List<EventViewModel> eventdetailslist = new List<EventViewModel>();

            RegisterViewModel model = new RegisterViewModel();
            SqlCommand com = new SqlCommand("GetEventDetails", con);
            com.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            com.Parameters.AddWithValue("@eid", eid);
            da.Fill(dt);
            con.Close();
            if (dt.Rows.Count > 0)
            {

                eventdetailslist.Add(new EventViewModel
                {

                    eid = ConvertHelper.Encode(dt.Rows[0]["eid"].ToString()),
                    uid = Convert.ToInt32(dt.Rows[0]["uid"].ToString()),
                    title = dt.Rows[0]["title"].ToString(),
                    subject = TextToHtml(dt.Rows[0]["subject"].ToString()),
                    date = dt.Rows[0]["edate"].ToString(),
                    time = dt.Rows[0]["etime"].ToString(),
                    address = dt.Rows[0]["address"].ToString(),
                    cno = dt.Rows[0]["cno"].ToString(),
                    country = dt.Rows[0]["country_name"].ToString(),
                    state = dt.Rows[0]["state_name"].ToString(),
                    city = dt.Rows[0]["city"].ToString(),
                    descr = dt.Rows[0]["descr"].ToString(),
                    late = dt.Rows[0]["late"].ToString(),
                    lonz = dt.Rows[0]["long"].ToString(),
                    status = Convert.ToInt32(dt.Rows[0]["status"].ToString()),
                    img = dt.Rows[0]["img"].ToString(),
                    img1 = dt.Rows[0]["img1"].ToString(),
                    img2 = dt.Rows[0]["img2"].ToString(),
                    reason = dt.Rows[0]["reason"].ToString(),
                    //suburb = dt.Rows[0]["suburb"].ToString(),
                    code = dt.Rows[0]["code"].ToString(),
                    unit = dt.Rows[0]["unit"].ToString(),
                    street = dt.Rows[0]["street"].ToString(),
                    sname = dt.Rows[0]["sname"].ToString(),
                    cat = Convert.ToInt32(dt.Rows[0]["cat"].ToString()),
                    uname = dt.Rows[0]["name"].ToString(),
                    create_date = Convert.ToDateTime(dt.Rows[0]["created_date"].ToString()),
                    ispaid = Convert.ToInt32(dt.Rows[0]["ispaid"].ToString()),
                    price = Convert.ToInt32(dt.Rows[0]["price"].ToString()),
                    showphone = Convert.ToInt32(dt.Rows[0]["shownumber"].ToString()),
                    going = dt.Rows[0]["going"].ToString(),
                    email = dt.Rows[0]["email"].ToString(),
                    sponsorship = dt.Rows[0]["sponsorship"].ToString(),
                    sponsorname = dt.Rows[0]["sponsorname"].ToString()

                });
            }


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
            dr.Close();
            con.Close();
            model.makelist = list;
            model.eventdetailslist = eventdetailslist;
            return View("EventDetails", model);

            //return View();
        }

        public string TextToHtml(string text)
        {
            text = HttpUtility.HtmlEncode(text);
            text = text.Replace("\r\n", "\r");
            text = text.Replace("\n", "\r");
            text = text.Replace("\r", "<br>\r\n");
            text = text.Replace("  ", " &nbsp;");
            return text;
        }

        [AuthonticateUserHelper]
        public ActionResult UserEventDetails(string eid = "0")
        {
            eid = ConvertHelper.Decode(eid);

            con = new SqlConnection(constr);

            List<EventViewModel> eventdetailslist = new List<EventViewModel>();

            RegisterViewModel model = new RegisterViewModel();
            SqlCommand com = new SqlCommand("GetEventDetails", con);
            com.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            com.Parameters.AddWithValue("@eid", eid);
            da.Fill(dt);
            con.Close();
            if (dt.Rows.Count > 0)
            {

                eventdetailslist.Add(new EventViewModel
                {

                    eid = ConvertHelper.Encode(dt.Rows[0]["eid"].ToString()),
                    uid = Convert.ToInt32(dt.Rows[0]["uid"].ToString()),
                    title = dt.Rows[0]["title"].ToString(),
                    subject = TextToHtml(dt.Rows[0]["subject"].ToString()),
                    date = dt.Rows[0]["edate"].ToString(),
                    time = dt.Rows[0]["etime"].ToString(),
                    address = dt.Rows[0]["address"].ToString(),
                    cno = dt.Rows[0]["cno"].ToString(),
                    country = dt.Rows[0]["country_name"].ToString(),
                    state = dt.Rows[0]["state_name"].ToString(),
                    city = dt.Rows[0]["city"].ToString(),
                    descr = dt.Rows[0]["descr"].ToString(),
                    late = dt.Rows[0]["late"].ToString(),
                    lonz = dt.Rows[0]["long"].ToString(),
                    status = Convert.ToInt32(dt.Rows[0]["status"].ToString()),
                    img = dt.Rows[0]["img"].ToString(),
                    img1 = dt.Rows[0]["img1"].ToString(),
                    img2 = dt.Rows[0]["img2"].ToString(),
                    reason = dt.Rows[0]["reason"].ToString(),
                    suburb = dt.Rows[0]["suburb"].ToString(),
                    code = dt.Rows[0]["code"].ToString(),
                    unit = dt.Rows[0]["unit"].ToString(),
                    street = dt.Rows[0]["street"].ToString(),
                    sname = dt.Rows[0]["sname"].ToString(),
                    cat = Convert.ToInt32(dt.Rows[0]["cat"].ToString()),
                    uname = dt.Rows[0]["name"].ToString(),
                    going = dt.Rows[0]["going"].ToString(),
                    create_date = Convert.ToDateTime(dt.Rows[0]["created_date"].ToString()),
                    ispaid = Convert.ToInt32(dt.Rows[0]["ispaid"].ToString()),
                    price = Convert.ToInt32(dt.Rows[0]["price"].ToString()),
                    showphone = Convert.ToInt32(dt.Rows[0]["shownumber"].ToString()),
                    email = dt.Rows[0]["email"].ToString(),
                    sponsorship = dt.Rows[0]["sponsorship"].ToString(),
                    sponsorname = dt.Rows[0]["sponsorname"].ToString()
                });

            }

            model.eventdetailslist = eventdetailslist;

            return View(model);

        }

        [AuthonticateUserHelper]
        public ActionResult ManageEvent(string option = "0")
        {
            if (option == "0")
            {

                option = "CID";
            }
            string uid = Session["id"].ToString();
            DataTable dt = new DataTable();
            List<EventViewModel> eventlist1 = new List<EventViewModel>();
            RegisterViewModel eventmodel = new RegisterViewModel();
            SqlConnection con = new SqlConnection(constr);

            SqlCommand cmd = new SqlCommand("GetAllEventList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cid", uid);
            cmd.Parameters.AddWithValue("@sortby", option);
            con.Open();
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
                        city = dt.Rows[i]["city"].ToString(),
                        descr = dt.Rows[i]["descr"].ToString(),
                        late = dt.Rows[i]["late"].ToString(),
                        lonz = dt.Rows[i]["long"].ToString(),
                        status = Convert.ToInt32(dt.Rows[i]["status"].ToString()),
                        img = dt.Rows[i]["img"].ToString(),
                        img1 = dt.Rows[i]["img1"].ToString(),
                        img2 = dt.Rows[i]["img2"].ToString(),
                        reason = dt.Rows[i]["reason"].ToString(),
                        suburb = dt.Rows[i]["suburb"].ToString(),
                        code = dt.Rows[i]["code"].ToString(),
                        unit = dt.Rows[i]["unit"].ToString(),
                        street = dt.Rows[i]["street"].ToString(),
                        sname = dt.Rows[i]["sname"].ToString(),
                        cat = Convert.ToInt32(dt.Rows[i]["cat"].ToString()),
                        create_date = Convert.ToDateTime(dt.Rows[i]["created_date"].ToString()),
                        uname = dt.Rows[i]["name"].ToString(),
                        sponsorname = dt.Rows[i]["sponsorname"].ToString(),
                        going = dt.Rows[i]["going"].ToString(),
                    });
                }
            }



            dt = new DataTable();

            string id = Session["id"].ToString();
            List<EventViewModel> eventlist = new List<EventViewModel>();

            using (SqlConnection con1 = new SqlConnection(constr))
            {
                using (SqlCommand cmd1 = new SqlCommand("GetGoingEvents", con1))
                {
                    con1.Open();
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@uid", id);
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                    da1.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            eventlist.Add(new EventViewModel
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
                                city = dt.Rows[i]["city"].ToString(),
                                descr = dt.Rows[i]["descr"].ToString(),
                                late = dt.Rows[i]["late"].ToString(),
                                lonz = dt.Rows[i]["long"].ToString(),
                                status = Convert.ToInt32(dt.Rows[i]["status"].ToString()),
                                img = dt.Rows[i]["img"].ToString(),
                                img1 = dt.Rows[i]["img1"].ToString(),
                                img2 = dt.Rows[i]["img2"].ToString(),
                                reason = dt.Rows[i]["reason"].ToString(),
                                suburb = dt.Rows[i]["suburb"].ToString(),
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
                                uname = dt.Rows[i]["name"].ToString(),
                                sponsorname = dt.Rows[i]["sponsorname"].ToString(),

                            });
                        }
                    }

                }
            }



            eventmodel.eventdetailslist = eventlist;
            eventmodel.eventlist = eventlist1;
            return View(eventmodel);

        }
        [AuthonticateUserHelper]
        public ActionResult ManageYard(string option = "0")
        {
            if (option == "0")
            {

                option = "CID";
            }

            string uid = Session["id"].ToString();
            DataTable dt = new DataTable();
            List<CarModel> carlist = new List<CarModel>();
            RegisterViewModel model = new RegisterViewModel();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("GetCarDetailsbyID", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@uid", uid);
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
                                series = dt.Rows[i]["series_type"].ToString(),
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
                                star = Convert.ToInt32(dt.Rows[i]["carstar"].ToString()),
                                img3 = dt.Rows[i]["img3"].ToString(),
                                img4 = dt.Rows[i]["img4"].ToString(),
                                img5 = dt.Rows[i]["img5"].ToString(),
                                created_date = dt.Rows[i]["created_date"].ToString(),
                                suburb = dt.Rows[i]["regionname"].ToString()







                            });
                        }
                    }
                }
            }
            model.carlist = carlist;

            return View(model);
        }

        public ActionResult CarMapListing(string uid)
        {
            uid = ConvertHelper.Decode(uid);

            DataTable dt = new DataTable();
            List<CarModel> carlist = new List<CarModel>();
            RegisterViewModel model = new RegisterViewModel();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("GetCarMapListing", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@uid", uid);
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
                                series = dt.Rows[i]["series_type"].ToString(),
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
                                star = Convert.ToInt32(dt.Rows[i]["carstar"].ToString()),
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
            dr.Close();
            con.Close();
            con = new SqlConnection(constr);
            con.Open();
            cmd = new SqlCommand("select * from tbl_login where id='" + uid + "'", con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                model.buslog = dr["buslogo"].ToString();
            }
            dr.Close();
            con.Close();




            model.makelist = list;
            model.carlist = carlist;

            return View(model);
        }

        [AuthonticateUserHelper]
        public ActionResult UserCarMapListing(string uid)
        {
            uid = ConvertHelper.Decode(uid);

            DataTable dt = new DataTable();
            List<CarModel> carlist = new List<CarModel>();
            RegisterViewModel model = new RegisterViewModel();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("GetCarMapListing", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@uid", uid);
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
                                series = dt.Rows[i]["series_type"].ToString(),
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
                                star = Convert.ToInt32(dt.Rows[i]["carstar"].ToString()),
                                img3 = dt.Rows[i]["img3"].ToString(),
                                img4 = dt.Rows[i]["img4"].ToString(),
                                img5 = dt.Rows[i]["img5"].ToString(),
                                created_date = dt.Rows[i]["created_date"].ToString(),
                                showphone = Convert.ToInt32(dt.Rows[i]["showphone"].ToString()),
                                cno = dt.Rows[i]["cno"].ToString(),
                                orgname = dt.Rows[i]["orgname"].ToString(),
                                suburb = dt.Rows[i]["regionname"].ToString()



                            });
                        }
                    }
                }
            }

            con = new SqlConnection(constr);
            con.Open();
            cmd = new SqlCommand("select * from tbl_login where id = '" + uid + "'", con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                model.buslog = dr["buslogo"].ToString();
            }

            dr.Close();
            model.carlist = carlist;

            return View(model);
        }

        [AuthonticateUserHelper]

        public ActionResult WatchList()
        {
            string uid = Session["id"].ToString();
            DataTable dt = new DataTable();
            List<CarModel> carlist = new List<CarModel>();
            RegisterViewModel model = new RegisterViewModel();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("GetCarWatchlist", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@uid", uid);
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
                                star = Convert.ToInt32(dt.Rows[i]["carstar"].ToString()),
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

            dt = new DataTable();

            List<EventViewModel> eventlist1 = new List<EventViewModel>();
            con = new SqlConnection(constr);
            cmd = new SqlCommand("GetEventWatchList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@uid", uid);
            con.Open();
            da = new SqlDataAdapter(cmd);
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
                        city = dt.Rows[i]["city"].ToString(),
                        descr = dt.Rows[i]["descr"].ToString(),
                        late = dt.Rows[i]["late"].ToString(),
                        lonz = dt.Rows[i]["long"].ToString(),
                        status = Convert.ToInt32(dt.Rows[i]["status"].ToString()),
                        img = dt.Rows[i]["img"].ToString(),
                        img1 = dt.Rows[i]["img1"].ToString(),
                        img2 = dt.Rows[i]["img2"].ToString(),
                        reason = dt.Rows[i]["reason"].ToString(),
                        suburb = dt.Rows[i]["suburb"].ToString(),
                        code = dt.Rows[i]["code"].ToString(),
                        unit = dt.Rows[i]["unit"].ToString(),
                        street = dt.Rows[i]["street"].ToString(),
                        sname = dt.Rows[i]["sname"].ToString(),
                        cat = Convert.ToInt32(dt.Rows[i]["cat"].ToString()),
                        create_date = Convert.ToDateTime(dt.Rows[i]["created_date"].ToString()),
                        star = Convert.ToInt32(dt.Rows[i]["eventstar"].ToString())

                    });
                }
            }



            model.carlist = carlist;
            model.eventlist = eventlist1;
            return View(model);
        }

        [AuthonticateUserHelper]
        public ActionResult StateMaster()
        {

            con = new SqlConnection(constr);
            List<StateMasterModel> statelist = new List<StateMasterModel>();
            //JObject json = new JObject();
            StateMasterModel model = new Models.StateMasterModel();
            SqlCommand com = new SqlCommand("GetAllState", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                statelist.Add(
                    new StateMasterModel
                    {
                        state_id = Convert.ToInt32(dr["state_id"].ToString()),
                        count_id = Convert.ToInt32(dr["count_id"].ToString()),
                        country_name = dr["country_name"].ToString(),
                        state = dr["state_name"].ToString(),
                        status = Convert.ToInt32(dr["status"].ToString())
                    });
            }
            model.statelist = statelist;
            return View(model);
        }
        [AuthonticateUserHelper]
        public ActionResult CountryMaster()
        {

            con = new SqlConnection(constr);
            List<CountryMasterModel> countrylist = new List<CountryMasterModel>();
            CountryMasterModel model = new CountryMasterModel();
            SqlCommand com = new SqlCommand("GetCountry", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                countrylist.Add(
                    new CountryMasterModel
                    {
                        count_id = Convert.ToInt32(dr["count_id"].ToString()),
                        countryname = dr["country_name"].ToString(),
                        status = Convert.ToInt32(dr["status"].ToString())
                    });
            }
            model.countrylist = countrylist;
            // json["countrylist"] = JToken.FromObject(countrylist);
            return View(model);
        }

        [AuthonticateUserHelper]
        public ActionResult EventCatMaster()
        {

            DataTable dt = new DataTable();
            List<EventCategoryModel> categorylist = new List<EventCategoryModel>();
            EventCategoryModel model = new EventCategoryModel();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("GetCategory", con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            categorylist.Add(new EventCategoryModel
                            {
                                ecat_id = Convert.ToInt32(dt.Rows[i]["ecat_id"].ToString()),
                                category = dt.Rows[i]["category"].ToString(),
                                status = Convert.ToInt32(dt.Rows[i]["status"].ToString())
                            });
                        }
                    }

                }
            }
            model.categorylist = categorylist;
            return View("EventCatMaster", model);

            //return View();
        }

        public ActionResult About()
        {
            RegisterViewModel model = new RegisterViewModel();
            ViewBag.Message = "Your application description page.";
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
            dr.Close();
            con.Close();
            model.makelist = list;
            return View(model);
        }

        public ActionResult Contact()
        {
            RegisterViewModel model = new RegisterViewModel();
            ViewBag.Message = "Your application description page.";
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
            dr.Close();
            con.Close();
            model.makelist = list;

            return View(model);
        }

        [HttpPost]
        public JObject PfreeUserCount()
        {

            JObject json = new JObject();
            con = new SqlConnection(constr);
            con.Open();
            cmd = new SqlCommand("select count(*) from tbl_login where status = '0' and type = 'Free'", con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                json["freetotalusers"] = dr[0].ToString();
            }
            else
            {

                json["freetotalusers"] = 0;
            }
            dr.Close();
            con.Close();
            List<UserListModel> list1 = new List<UserListModel>();
            con = new SqlConnection(constr);
            con.Open();
            cmd = new SqlCommand("select * from tbl_login where status = '0' and type = 'Free'", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                list1.Add(new UserListModel
                {
                    id = ConvertHelper.Encode(dr["id"].ToString()),
                    orgname = dr["orgname"].ToString(),
                    regdate = dr["reg_date"].ToString(),
                    name = dr["fname"].ToString(),
                    lname = dr["lname"].ToString(),
                    email = dr["email"].ToString()

                });


            }

            json["freeuserlist"] = JToken.FromObject(list1);
            dr.Close();
            con.Close();

            return json;
        }
        [HttpPost]
        public JObject PUserCount()
        {

            JObject json = new JObject();
            con = new SqlConnection(constr);
            con.Open();
            cmd = new SqlCommand("select count(*) from tbl_login where status = '2' and type = 'Paid'", con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                json["totalusers"] = dr[0].ToString();
            }
            else
            {

                json["totalusers"] = 0;
            }
            dr.Close();
            con.Close();
            List<UserListModel> list = new List<UserListModel>();
            con = new SqlConnection(constr);
            con.Open();
            cmd = new SqlCommand("select * from tbl_login where status = '2' and type = 'Paid'", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                list.Add(new UserListModel
                {

                    id = ConvertHelper.Encode(dr["id"].ToString()),
                    orgname = dr["orgname"].ToString(),
                    regdate = dr["reg_date"].ToString(),
                    name = dr["fname"].ToString(),
                    lname = dr["lname"].ToString(),
                    email = dr["email"].ToString()

                });


            }

            json["userlist"] = JToken.FromObject(list);
            dr.Close();
            con.Close();



            return json;
        }

        [HttpPost]
        public JObject UserCarCount()
        {

            JObject json = new JObject();
            con = new SqlConnection(constr);
            con.Open();
            cmd = new SqlCommand("select count(*) from tbl_carmaster where status = '0'", con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                json["carcount"] = dr[0].ToString();
            }
            else
            {

                json["carcount"] = 0;
            }
            dr.Close();
            con.Close();
            List<CarModel> list = new List<CarModel>();
            con = new SqlConnection(constr);
            con.Open();
            cmd = new SqlCommand("select a.*,b.make_type,c.model as 'ModelName' from tbl_carmaster a,MakeTypeMaster b,ModelMaster c where c.model_id=a.model and b.make_id=a.make and a.status = '0'", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                list.Add(new CarModel
                {
                    cid = ConvertHelper.Encode(dr["cid"].ToString()),
                    make = dr["make_type"].ToString(),
                    model = dr["modelname"].ToString()

                });


            }

            json["carlist"] = JToken.FromObject(list);
            dr.Close();
            con.Close();



            return json;
        }

        [HttpPost]
        public JObject UserEventCount()
        {

            JObject json = new JObject();
            con = new SqlConnection(constr);
            con.Open();
            cmd = new SqlCommand("select count(*) from tbl_eventmaster where status = '0'", con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                json["eventcount"] = dr[0].ToString();
            }
            else
            {

                json["eventcount"] = 0;
            }
            dr.Close();
            con.Close();
            List<EventViewModel> list = new List<EventViewModel>();
            con = new SqlConnection(constr);
            con.Open();
            cmd = new SqlCommand("select * from tbl_eventmaster where status = '0'", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                list.Add(new EventViewModel
                {
                    eid = ConvertHelper.Encode(dr["eid"].ToString()),
                    //subject = dr["subject"].ToString(),
                    title = dr["title"].ToString()

                });


            }

            json["eventlist"] = JToken.FromObject(list);
            dr.Close();
            con.Close();



            return json;
        }

        [HttpPost]
        public JObject ChangeCarStatus(string cid, string status)
        {

            cid = ConvertHelper.Decode(cid);

            JObject json = new JObject();
            con = new SqlConnection(constr);
            con.Open();
            cmd = new SqlCommand("ChangeCarStatus", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cid", cid);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.ExecuteNonQuery();
            json["status"] = "Success";
            con.Close();
            return json;
        }

        [HttpPost]
        public JObject ChangeCarGStatus(string cid, string status)
        {
            cid = ConvertHelper.Decode(cid);

            JObject json = new JObject();
            con = new SqlConnection(constr);
            con.Open();
            cmd = new SqlCommand("ChangeCarGStatus", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cid", cid);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.ExecuteNonQuery();
            json["status"] = "Success";
            con.Close();
            return json;
        }

        [HttpPost]
        public JObject ChangeEventStatus(string eid, string status)
        {
            eid = ConvertHelper.Decode(eid);

            JObject json = new JObject();
            con = new SqlConnection(constr);
            con.Open();
            cmd = new SqlCommand("ChangeEventStatus", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@eid", eid);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.ExecuteNonQuery();
            json["status"] = "Success";
            con.Close();
            return json;
        }

        [AuthonticateUserHelper]
        public ActionResult UserAboutUS()
        {


            return View();

        }

        [AuthonticateUserHelper]
        public ActionResult UserContact()
        {


            return View();

        }

        [AuthonticateUserHelper]
        public ActionResult ManageStore()
        {
            string uid = Session["id"].ToString();
            UserListModel model = new UserListModel();
            con = new SqlConnection(constr);
            List<UserListModel> UserList = new List<UserListModel>();
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("GetStoreByParentStore", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@parentstore", uid);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind EmpModel generic list using dataRow 
            foreach (DataRow dr in dt.Rows)
            {
                UserList.Add(
                    new UserListModel
                    {
                        id = dr["id"].ToString(),
                        name = Convert.ToString(dr["name"].ToString()),
                        email = Convert.ToString(dr["email"].ToString()),
                        type = dr["type"].ToString(),
                        status = Convert.ToInt32(dr["status"].ToString()),
                        regdate = Convert.ToDateTime(dr["reg_date"].ToString()).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                        orgname = dr["orgname"].ToString(),
                        customerid = dr["cust_id"].ToString()






                        //pass = Convert.ToInt32(dt.Rows[i]["year"].ToString()),
                        //city = Convert.ToInt32(dt.Rows[i]["cylinder"].ToString()),
                        //state = dt.Rows[i]["cylinder_name"].ToString(),
                        //country = dt.Rows[i]["img"].ToString(),
                        //street = dt.Rows[i]["img1"].ToString(),
                        //streetname = dt.Rows[i]["img2"].ToString(),
                        //other = Convert.ToInt32(dt.Rows[i]["uid"].ToString()),
                        //other1 = dt.Rows[i]["bcolor"].ToString(),
                        //other2 = dt.Rows[i]["icolor"].ToString(),
                        //cno = dt.Rows[i]["list"].ToString(),
                        //fname = dt.Rows[i]["material"].ToString(),
                        //lname = dt.Rows[i]["bodytypename"].ToString(),
                        //gender = Convert.ToInt32(dt.Rows[i]["status"].ToString()),
                        //zip = dt.Rows[i]["make_type"].ToString(),
                        //regions = dt.Rows[i]["badge_type"].ToString(),
                        //suburb = dt.Rows[i]["series_type"].ToString(),
                        //type = dt.Rows[i]["currencyname"].ToString(),
                        //late = dt.Rows[i]["model"].ToString(),
                        //lonz = dt.Rows[i]["transmision"].ToString(),
                        //validdate = dt.Rows[i]["state_name"].ToString(),
                        //plan_id = dt.Rows[i]["cityname"].ToString(),
                        //showphone = dt.Rows[i]["odometer"].ToString(),
                        //logo = dt.Rows[i]["condition"].ToString(),
                        //countryname = dt.Rows[i]["name"].ToString(),
                        //statename = dt.Rows[i]["drive"].ToString(),
                        //resonname = dt.Rows[i]["fuel"].ToString(),
                        //carcount = dt.Rows[i]["gstatus"].ToString(),
                        //eventcount = dt.Rows[i]["speedtypename"].ToString()

                    }
                    );
            }

            model.userlist = UserList;

            return View(model);
        }

        [AuthonticateUserHelper]
        public JObject SwitchStore(string id, string name, string type, string status, string email)
        {
            Session["id"] = id;
            Session["name"] = name;
            Session["type"] = type;
            Session["status"] = status;
            Session["parentstore"] = id;
            Session["email"] = email;
            JObject json = new JObject();
            json["status"] = "Success";
            return json;
        }

        [AuthonticateUserHelper]
        public ActionResult AddStore()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        public JObject AddStore(int id, string dname, string fname, string lname, string email, string password, string cno, string city, string state, string country, string street, string streetname, string other, string other1, string other2, string zip, string regions, string gender, string late, string lonz, string showphone, string bname)
        {
            con = new SqlConnection(constr);
            JObject json = new JObject();
            SqlCommand com = new SqlCommand("AddStore", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id", id);
            com.Parameters.AddWithValue("@dname", dname);
            com.Parameters.AddWithValue("@fname", fname);
            com.Parameters.AddWithValue("@lname", lname);
            com.Parameters.AddWithValue("@email", email);
            com.Parameters.AddWithValue("@pass", password);
            com.Parameters.AddWithValue("@cno", cno);
            com.Parameters.AddWithValue("@city", city);
            com.Parameters.AddWithValue("@state", state);
            com.Parameters.AddWithValue("@country", country);
            com.Parameters.AddWithValue("@street", street);
            com.Parameters.AddWithValue("@streetname", streetname);
            com.Parameters.AddWithValue("@other", other);
            com.Parameters.AddWithValue("@other1", other1);
            com.Parameters.AddWithValue("@other2", other2);
            com.Parameters.AddWithValue("@zip", zip);
            com.Parameters.AddWithValue("@regions", regions);
            //com.Parameters.AddWithValue("@suburb", suburb);
            com.Parameters.AddWithValue("@gender", gender);
            com.Parameters.AddWithValue("@late", late);
            com.Parameters.AddWithValue("@long", lonz);
            com.Parameters.AddWithValue("@showphone", showphone);
            com.Parameters.AddWithValue("@bname", bname);
            com.Parameters.AddWithValue("@errorCode", SqlDbType.Int);
            com.Parameters.AddWithValue("@errorMessage", SqlDbType.NVarChar);
            SqlParameter storeid = new SqlParameter("@storeid", SqlDbType.Int) { Direction = ParameterDirection.Output };
            com.Parameters.Add(storeid);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            json["status"] = "Success";
            json["storeid"] = Convert.ToInt32(storeid.Value.ToString());

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
            MailAddress sender = new MailAddress("info@mobi96.org", "MYCARYARD");
            msg.AlternateViews.Add(htmlBody);
            msg.From = sender;
            msg.Subject = "MYCARYARD New Registration";
            msg.To.Add(email);


            // MailMessage mail = new MailMessage("info@stums.in", model.RegEmail, "MyCarYard New Registration", htmlmessage);
            msg.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("relay-hosting.secureserver.net");
            try
            {
                client.Send(msg);
            }
            catch { }

            return json;
        }

        public ActionResult UploadStoreBusinessLogo(FormCollection frm1)
        {
            string filePath = string.Empty;
            var dataStr = String.Format("{0:d/M/yyyy HH:mm:ss}", DateTime.Now);
            dataStr = dataStr.Replace(@"/", "").Trim(); dataStr = dataStr.Replace(@":", "").Trim(); dataStr = dataStr.Replace(" ", String.Empty);

            if (!string.IsNullOrEmpty(frm1["hdoutput"]))
            {
                filePath = HostingEnvironment.MapPath("~/images/logos/");
                var image = frm1["custlid"] + "_" + dataStr + ".png";
                var valuefind = frm1["hdoutput"];
                byte[] bytes = System.Convert.FromBase64String(valuefind);
                using (FileStream fs = new FileStream(filePath + image, FileMode.CreateNew, FileAccess.Write, FileShare.None))
                {
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Close();
                }
                WebImage supermanImage = new WebImage(Server.MapPath("~/images/logos/" + image));
                supermanImage.AddTextWatermark("MY CARYARD", "White", 40, "Regular", "Consolas", "Right", "Top", 20, 10);
                supermanImage.Save(Server.MapPath("~/images/logos/" + image));
                //Update Image Name1
                con = new SqlConnection(constr);
                con.Open();
                cmd = new SqlCommand("update tbl_login SET buslogo='" + image + "' where id= '" + frm1["custlid"] + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return RedirectToAction("ManageStore", "Home");
        }

        public ActionResult CarListing(string uid, string option = "0")
        {
            if (option == "0")
            {

                option = "CID";
            }
            DataTable dt = new DataTable();
            List<CarModel> carlist = new List<CarModel>();
            RegisterViewModel model = new RegisterViewModel();
            List<EventViewModel> eventlist1 = new List<EventViewModel>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("GetCarListing", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sortby", option);
                    cmd.Parameters.AddWithValue("@uid", ConvertHelper.Decode(uid));
                    con.Open();
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
            model.carlist = carlist;
            return View("CarListing", model);

        }

        public ActionResult EventListing(string uid, string option = "0")
        {
            if (option == "0")
            {

                option = "CID";
            }
            DataTable dt = new DataTable();
            RegisterViewModel model = new RegisterViewModel();
            List<EventViewModel> eventlist1 = new List<EventViewModel>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("GetEventListing", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sortby", option);
                    cmd.Parameters.AddWithValue("@uid", ConvertHelper.Decode(uid));
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


                            });
                        }
                    }

                }
            }
            model.eventlist = eventlist1;
            return View("EventListing", model);

        }

        public ActionResult CarListinglog(string uid, string option = "0")
        {
            if (option == "0")
            {

                option = "CID";
            }
            DataTable dt = new DataTable();
            List<CarModel> carlist = new List<CarModel>();
            RegisterViewModel model = new RegisterViewModel();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("GetCarListing", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sortby", option);
                    cmd.Parameters.AddWithValue("@uid", ConvertHelper.Decode(uid));
                    con.Open();
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

            model.carlist = carlist;
            return View("CarListinglog", model);

        }

        public ActionResult EventListinglog(string uid, string option = "0")
        {
            if (option == "0")
            {

                option = "CID";
            }
            DataTable dt = new DataTable();
            RegisterViewModel model = new RegisterViewModel();
            List<EventViewModel> eventlist1 = new List<EventViewModel>();


            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("GetEventListing", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sortby", option);
                    cmd.Parameters.AddWithValue("@uid", ConvertHelper.Decode(uid));
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


                            });
                        }
                    }

                }
            }
            model.eventlist = eventlist1;
            return View("EventListinglog", model);

        }

    }
}