using HrDashboard.ModelInitialize;
using HrDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HrDashboard.Controllers
{
    public class UserController : Controller
    {
        HRContext context;
        public UserController()
        {
            context = new HRContext();
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        //Registration Action
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        //Registration POST Action
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration([Bind(Exclude = "IsEmailVerified, ActivationCode")] Users users)
        {
            bool status = false;
            string message = "";

            //Model Validation
            if (ModelState.IsValid)
            {
                #region Check for Email Validation
                var isExist = DoesEmailExist(users.Email);
                if (isExist == true)
                {
                    // Throw error in the textbox on View()
                    ModelState.AddModelError("EmailExist", "This E-mail already exists in the System.");
                    return View(users);
                }
                #endregion

                #region Generate Activation Code
                users.ActivationCode = Guid.NewGuid();
                #endregion

                #region Password Hashing
                users.Password = Crypto.Hash(users.Password);
                users.ConfirmPassword = Crypto.Hash(users.ConfirmPassword);
                #endregion

                users.IsEmailVerified = false;

                #region Save Data to Database
                context.UsersDbSet.Add(users);
                context.SaveChanges();
                //Send Email to User
                SendVerificationLinkEmail(users.Email, users.ActivationCode.ToString());
                message = "Just a few more steps, registration was a success. An account activation link" +
                    " has been sent to your E-mail account: " + users.Email + ", please open your e-mail for the activation.";
                status = true;
                #endregion
            }
            else
            {
                message = "Invalid Request";
            }

            ViewBag.Message = message;
            ViewBag.Status = status;
            return View(users);
        }

        //Verify Account
        [HttpGet]
        public ActionResult VerifyAccount(string id)
        {
            bool status = false;
            
            //to avoid confirm password does not match issue on save changes
            context.Configuration.ValidateOnSaveEnabled = false;
            var query = context.UsersDbSet.Where(c => c.ActivationCode == new Guid(id)).FirstOrDefault();
            if (query != null)
            {
                query.IsEmailVerified = true;
                context.SaveChanges();
                status = true;
            }
            else
            {
                ViewBag.Message = "Invalid Request";
            }
            ViewBag.Status = status;
            return View();
        }

        //Login
        [HttpGet]
        public ActionResult LoginForm()
        {
            return View();
        }

        //Login POST Action
        public string usernameNow = "";
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginForm(UserLogin login, string returnUrl)
        {
            string message = "";
            string password = login.Password;
            usernameNow = login.Username;
            using (HRContext context = new HRContext())
            {
                var getUser = context.UsersDbSet.Where(c => c.Username == login.Username || c.Email == login.Username).SingleOrDefault();
                if (getUser != null)
                {
                    if (Crypto.Hash(password) == getUser.Password)
                    {
                        int timeout = login.RememberMe ? 17280 : 480;
                        var ticket = new FormsAuthenticationTicket(login.Username, login.RememberMe, timeout);
                        string encryptedTicket = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                        cookie.Expires = DateTime.Now.AddMinutes(timeout);
                        cookie.HttpOnly = true;
                        Response.Cookies.Add(cookie);

                        if (Url.IsLocalUrl(returnUrl))
                        { return Redirect(returnUrl); }
                        else
                        { return RedirectToAction("Index", "Home"); }
                    }
                    else
                    { message = "It seems that you have entered a wrong password, please check your inputs and try again."; }
                }
                else
                { message = "There is no such username saved in the system, please make sure the you entered the correct spelling."; }
            }
            ViewBag.Message = message;
            return View(login);
        }

        //Logout
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LoginForm", "User");
        }


        #region Non Action Methods
        [NonAction]
        public bool DoesEmailExist(string emailId)
        {
            var email = context.UsersDbSet.Where(a => a.Email == emailId).FirstOrDefault();
            if (email == null)
            { return false; }
            else { return true; }
        }

        [NonAction]
        public void SendVerificationLinkEmail(string email, string activationCode)
        {
            var verifyUrl = "/User/VerifyAccount/" + activationCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);

            var fromEmail = new MailAddress("joshsmonta@gmail.com", "Sonic IT");
            var toEmail = new MailAddress(email);
            var fromEmailPassword = "GitaraMan19";
            string subject = "Your Sonic HR-System account is successfully created.";
            string body = "<br/><br/>Your account is now created. Just a few more steps for Sonic's security measures." +
                "Please click on the link below to verify your account." +
                "<br/><br/> <a href = '" + link + "'>" + link + "</a>";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            }) { smtp.Send(message); }

        }
        #endregion

    }
}