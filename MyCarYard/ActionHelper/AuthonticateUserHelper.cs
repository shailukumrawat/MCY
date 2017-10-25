using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Security;

namespace MyCarYard.ActionHelper
{
    public class AuthonticateUserHelper : FilterAttribute, IAuthenticationFilter
    {
        //string superAdminRole = "SuperAdmin"; // can be taken from resource file or config file
        //string adminRole = HttpContext.Current.Session["RoleId"].ToString(); // can be taken from resource file or config file


        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (filterContext.HttpContext.Session["id"] == null)
            {
                FormsAuthentication.SignOut();
                //What goes here?
                filterContext.Controller.TempData["FlashMessage"] = "Session timeout, Please login.";
                filterContext.Result = new HttpUnauthorizedResult(); // mark unauthorized
            }
            else
            {
                if (!string.Equals(Convert.ToString(HttpContext.Current.Session["id"]), string.Empty))
                {

                    int userID = 0;
                    bool hasID = int.TryParse(filterContext.HttpContext.Session["id"].ToString(), out userID);

                    if (!hasID)
                    {

                        FormsAuthentication.SignOut();
                        //What goes here?
                        filterContext.Controller.TempData["FlashMessage"] = "You are not authorized user, Please login via a valid User to access this.";
                        //Change the Result to point back to login
                        filterContext.Result = new HttpUnauthorizedResult(); // mark unauthorized

                        /*int roleID = 0;
                        bool hasRoleID = int.TryParse(filterContext.HttpContext.Session["id"].ToString(), out roleID);
                        if (roleID == 1)
                        {

                        }
                        else
                        {
                            FormsAuthentication.SignOut();
                            //What goes here?
                            filterContext.Controller.TempData["FlashMessage"] = "You are not authorized user, Please login via a valid User to access this.";
                            //Change the Result to point back to login
                            filterContext.Result = new HttpUnauthorizedResult(); // mark unauthorized
                        }*/
                    }
                    // else
                    //{
                    /*int roleID = 0;
                    bool hasRoleID = int.TryParse(filterContext.HttpContext.Session["id"].ToString(), out roleID);
                    if (roleID == 1)
                    {

                    }
                    else
                    {*/
                    //}
                    //}

                }
                else
                {
                    FormsAuthentication.SignOut();
                    //What goes here?
                    filterContext.Controller.TempData["FlashMessage"] = "Session timeout, Please login.";
                    filterContext.Result = new HttpUnauthorizedResult(); // mark unauthorized
                }
                //if (filterContext.HttpContext.User.Identity.IsAuthenticated &&
                //   (filterContext.HttpContext.User.IsInRole(superAdminRole)
                //    || filterContext.HttpContext.User.IsInRole(adminRole)))
                //{
                //    //do nothing
                //}
                //else
                //{
                //    filterContext.Result = new HttpUnauthorizedResult(); // mark unauthorized

                //}
            }

        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectToRouteResult("Default",
                    new System.Web.Routing.RouteValueDictionary{
                        {"controller", "Home"},
                        {"action", "Index"},
                        {"returnUrl", filterContext.HttpContext.Request.RawUrl}
                    });
            }

        }
    }

}
