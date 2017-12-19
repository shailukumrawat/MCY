using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using MyCarYard.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Web.Security;
using System.Net.Mail;
using System.Text;

namespace MyCarYard.Controllers
{
    [Authorize]
    [ValidateInput(false)]
    public class AccountController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;


        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }


        [AllowAnonymous]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["id"] = null;
            Session.Abandon(); // it will clear the session at the end of request
            //return RedirectToAction("Login", "Account");
            return RedirectToAction("Index", "Home");
            //return true;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }





        //
        // GET: /Account/Login
        [AllowAnonymous]

        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return RedirectToAction("Index", "Home");
            // return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel Model, string returnUrl)
        {
            // if (!ModelState.IsValid)
            // {
            //   return View(model);
            /// }
            /// 
            if (ModelState.IsValid)
            {

                string connString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString; // Read the connection string from the web.config file
                SqlDataReader dr;

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Select * from tbl_login where email='" + Model.Email + "' and pass='" + Model.Password + "'", conn);
                    Model.flag = Convert.ToBoolean(cmd.ExecuteScalar());
                    if (Model.flag == true)
                    {
                        dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            //                      var authTicket = new FormsAuthenticationTicket(
                            //  1,
                            //  dr[0].ToString(),  //user id
                            //  DateTime.Now,
                            //  DateTime.Now.AddMinutes(1),  // expiry
                            //  Model.RememberMe,  //true to remember
                            //  "", //roles 
                            //  "/"
                            //);
                            //                      HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(authTicket));
                            //                      Response.Cookies.Add(cookie);

                            FormsAuthentication.SetAuthCookie(Model.Email, Model.RememberMe);
                            if (Model.RememberMe)
                            {
                                HttpCookie cookie = new HttpCookie("Login");
                                cookie.Values.Add("EmailID", Model.Email);
                                cookie.Values.Add("Password", Model.Password);
                                cookie.Expires = DateTime.Now.AddDays(30);
                                Response.Cookies.Add(cookie);
                             }
                           
                            string coval = dr[8].ToString();
                            Session["id"] = dr[0].ToString();
                            Session["name"] = dr[1].ToString();
                            Session["email"] = dr[2].ToString();
                            Session["pass"] = dr[3].ToString();
                            Session["type"] = dr[4].ToString();
                            Session["country"] = coval;
                            Session["status"] = dr["status"].ToString();
                            Session["parentstore"] = dr["parentstore"].ToString();
                            if (Session["type"].ToString() != "Super")
                            {
                                return RedirectToAction("UserIndex", "Home");

                            }
                            else
                            {
                                return RedirectToAction("Dashboard", "Home");
                            }

                        }
                        //return View("Dashboard");


                    }
                    else
                    {


                        return RedirectToAction("Index", "Home");



                    }
                }



            }
            return View(Model);

        }

        //
        // GET: /Account/VerifyCode
        [AllowAnonymous]
        public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            // Require that the user has already logged in via username/password or external login
            if (!await SignInManager.HasBeenVerifiedAsync())
            {
                return View("Error");
            }
            return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // The following code protects for brute force attacks against the two factor codes. 
            // If a user enters incorrect codes for a specified amount of time then the user account 
            // will be locked out for a specified amount of time. 
            // You can configure the account lockout settings in IdentityConfig
            var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent: model.RememberMe, rememberBrowser: model.RememberBrowser);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(model.ReturnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid code.");
                    return View(model);
            }
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Register(RegisterViewModel model)
        {
            string errorcode = "";
            string id = "";
            // var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            // var result = await UserManager.CreateAsync(user, model.Password);
            // if (result.Succeeded)
            //{
            // await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

            string connString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString; // Read the connection string from the web.config file
                                                                                                       //  SqlDataReader dr;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                SqlParameter[] sqlparam = new SqlParameter[16];
                SqlCommand cmd = new SqlCommand("InsertCustomer", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                sqlparam[0] = new SqlParameter("@name", SqlDbType.NVarChar, 200);
                sqlparam[0].Value = model.Name;
                sqlparam[1] = new SqlParameter("@email", SqlDbType.NVarChar, 50);
                sqlparam[1].Value = model.RegEmail.Trim();
                sqlparam[2] = new SqlParameter("@pass", SqlDbType.NVarChar, 50);
                sqlparam[2].Value = model.RegPassword;
                sqlparam[3] = new SqlParameter("@type", SqlDbType.NVarChar, 50);
                sqlparam[3].Value = model.Type;
                sqlparam[4] = new SqlParameter("@id", SqlDbType.Int);
                sqlparam[4].Direction = ParameterDirection.Output;
                sqlparam[5] = new SqlParameter("@errorCode", SqlDbType.Int);
                sqlparam[5].Direction = ParameterDirection.Output;
                sqlparam[6] = new SqlParameter("@errorMessage", SqlDbType.NVarChar, 200);
                sqlparam[6].Direction = ParameterDirection.Output;
                sqlparam[7] = new SqlParameter("@businessname", SqlDbType.NVarChar, 200);
                sqlparam[7].Value = model.BusinessName;
                sqlparam[8] = new SqlParameter("@contactnumber", SqlDbType.NVarChar, 200);
                sqlparam[8].Value = model.ContactNumber;
                sqlparam[9] = new SqlParameter("@country", SqlDbType.NVarChar, 200);
                sqlparam[9].Value = model.regcountry;
                sqlparam[10] = new SqlParameter("@state", SqlDbType.NVarChar, 200);
                sqlparam[10].Value = model.regstate;
                sqlparam[11] = new SqlParameter("@zipcode", SqlDbType.NVarChar, 200);
                sqlparam[11].Value = model.regzipcode;
                sqlparam[12] = new SqlParameter("@city", SqlDbType.NVarChar, 200);
                sqlparam[12].Value = model.regcity;
                sqlparam[13] = new SqlParameter("@region", SqlDbType.NVarChar, 200);
                sqlparam[13].Value = model.regregion;

              
                if (model.Type == "Paid")
                {
                    sqlparam[14] = new SqlParameter("@parentstore", SqlDbType.NVarChar, 200);
                    sqlparam[14].Value = "0";
                }
                else
                {
                    sqlparam[14] = new SqlParameter("@parentstore", SqlDbType.NVarChar, 200);
                    sqlparam[14].Value = "";
                }
                //sqlparam[14] = new SqlParameter("@suburb", SqlDbType.NVarChar, 200);
                //sqlparam[14].Value = model.regsuburb;  

                sqlparam[15] = new SqlParameter("@facebookId", SqlDbType.NVarChar, 200);
                sqlparam[15].Value = model.HDfacebookId;

                cmd.Parameters.AddRange(sqlparam);
                cmd.ExecuteNonQuery();
                errorcode = sqlparam[5].Value.ToString();
                id = sqlparam[4].Value.ToString();
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
                msg.To.Add(model.RegEmail);


                // MailMessage mail = new MailMessage("info@stums.in", model.RegEmail, "MyCarYard New Registration", htmlmessage);
                msg.IsBodyHtml = true;
                SmtpClient client = new SmtpClient("relay-hosting.secureserver.net");
                try
                {
                    client.Send(msg);
                }
                catch { }
                //Email Code Here

                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                //return RedirectToAction("Index", "Home");


                //}
                // If we got this far, something failed, redisplay form

            }
            //AddErrors(result);

            if (model.Type == "Free" && errorcode == "0")
            {

                Session["id"] = id;
                Session["name"] = model.Name;
                Session["email"] = model.RegEmail;
                Session["pass"] = model.RegPassword;
                Session["type"] = "Free";
                Session["status"] = "0";
                return RedirectToAction("UserIndex", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.Email);
                if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View("ForgotPasswordConfirmation");
                }

                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                // string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                // var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);		
                // await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
                // return RedirectToAction("ForgotPasswordConfirmation", "Account");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            AddErrors(result);
            return View();
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/SendCode
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            var userId = await SignInManager.GetVerifiedUserIdAsync();
            if (userId == null)
            {
                return View("Error");
            }
            var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Generate the token and send it
            if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
            {
                return View("Error");
            }
            return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }

        //
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
                case SignInStatus.Failure:
                default:
                    // If the user does not have an account, then prompt the user to create an account
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                    return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Manage");
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }











        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}