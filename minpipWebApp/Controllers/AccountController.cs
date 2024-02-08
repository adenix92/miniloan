using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using minpipWebApp.Models;
using System.Net.Mail;
using System.Text;

namespace minpipWebApp.Controllers
{
    public class AccountController : Controller
    {
        minpipWebApp.Models.db_a7d46_realtech01Entities db = new Models.db_a7d46_realtech01Entities();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(_SignIn data) {

            if (ModelState.IsValid)
            {
                int active = 1;

                var Password = Stringbyte__Convertion(data.Password);
                

                var Login = db.SignUps.SingleOrDefault(s => s.Email == data.UserName && s.Passwords == Password && s.Active == active);
                
                if (Login !=null)
                {
                    
                    Session["user_email"] = Stringbyte__Convertion(Login.Email);
                    Session["user_id"] = Login.Id;
                    return Redirect("~/dashboard/Index");
                }
                else
                {
                    ViewBag.msg = "Incorrect Username OR Password";
                }
                    }
            return View();
                }
       

        
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(_SignUp Fields) {

            var msg = "";
            ViewBag.fc = "form-control";
            
            try
            {

                if (ModelState.IsValid)
                {
                    var result = (from a in db.SignUps where a.Email == Fields.Email select a).ToList();


                    if (result.Count != 0)
                    {
                        //let the email user first before the application proceed


                        msg = "The Email Already Exist";

                        // ViewBag.msg = "Valid";

                    }

                    else
                    {

                        

                        SignUp sign_In = new SignUp();
                        sign_In.Title = "Nil";
                        sign_In.FirstName = Fields.FirstName;
                        sign_In.SurName = Fields.SurName;
                        sign_In.OtherName = Fields.OtherName;
                        sign_In.Email = Fields.Email;
                        sign_In.Phone = Fields.Phone;
                        sign_In.Passwords = Stringbyte__Convertion(Fields.SurName);
                        sign_In.Active = 0;
                        sign_In.DateRegister = DateTime.Now;
                        
                        db.SignUps.Add(sign_In);
                        db.SaveChanges();
                        int v = sign_In.Id;
                        if (v > 0)
                        {
                            //send email smtp here
                            //sending email
                            var from = "noreply@minpip.com";
                            MailMessage mail = new MailMessage();
                            mail.To.Add(Fields.Email);
                            mail.From = new MailAddress(from);
                            mail.Subject = "Account Confirmation";
                            var emailconv = Stringbyte__Convertion(Fields.Email);
                            string Body = "<div width:960px; margin:0 auto; background-color:#CCC;><h3>Hi " + Fields.FirstName + "</h3>"
                                    +"<p>Username: "+Fields.Email+"</p>"
                                    +"<p>Password: "+Fields.SurName+"</p>"
                                    + "<p align=\"justify\">Thank you for creating account with <i>minpip loan</i></p>"

                                   + "<p align=\"justify\">Kindly activate your account with the link below to enjoy the full service. </p>"

        + "<p><a href=\"http://loan.minpip.com/Account/verifyme/" + emailconv + "\" style=\"display:inline-block; font-weight:400; line-height:1.5; color:#212529;text-align:center;text-decoration:none;vertical-align:middle;cursor:pointer;-webkit-user-select:none;-moz-user-select:none;user-select:none;background-color:transparent;border:1px solid transparent;padding:.375rem .75rem;font-size:1rem;border-radius:.25rem;transition:color .15s ease-in-out,background-color .15s ease-in-out,border-color .15s ease-in-out,box-shadow .15s ease-in-out;color:#fff;background-color:#0d6efd;border-color:#0d6efd;\">Click here to verify your new account</a></p><p>If you experience any issues logging into your account, reach out to us at info@minpip.com.</p><p>Regards,</p><p>THE MINPIP TEAM.</p></div>";
                            mail.Body = Body;
                            mail.IsBodyHtml = true;
                            SmtpClient smtp = new SmtpClient();
                            smtp.Host = "mail.minpip.com";
                            smtp.Port = 8889;
                            smtp.UseDefaultCredentials = false;
                            smtp.Credentials = new System.Net.NetworkCredential("noreply@minpip.com", "Realtech01"); // Enter seders User name and password  
                            smtp.EnableSsl = false;
                            smtp.Send(mail);
                            msg = "Verification Link has been sent to your email";

                           // ViewBag.color = "text-success";



                            //
                        }
                        else
                        {
                            msg = "The Application Fail";
                        }

                        //


                    }
                }
                else
                {
                    msg = "Some Field Require Valid Information";
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message.ToString();
                Console.WriteLine(ex.Message.ToString());
            }

            ViewBag.msg = msg;
            return View();
            }
        public static string Stringbyte__Convertion(string Parameter)
        {
            byte[] b = Encoding.ASCII.GetBytes(Parameter);
            return Convert.ToBase64String(b);
        }

        public static string bytesString_Convertion(string Parameter)
        {
            byte[] s = Convert.FromBase64String(Parameter);
            return Encoding.ASCII.GetString(s);
        }


        [Route("Account/verifyme/{ba?}")]
        public ActionResult email_verification(string ba)
        {

            //YmF5ZXN0ZGF2aWRAZ21haWwuY29t
            //bayestdavid@gmail.com
            //return ayubaweb.Controllers.dashboardController.Stringbyte__Convertion("bayestdavid@gmail.com");
            //var Id = ayubaweb.Controllers.dashboardController.bytesString_Convertion(ba);
            var Email = bytesString_Convertion(ba);
            //YWRlbmlyYW5AZ21haWwuY29t
            var confirmation = db.SignUps.SingleOrDefault(x => x.Email == Email && x.Active == 0);
            //var ema = confirmation.Email;
            try
            {
                var d = string.IsNullOrEmpty(Convert.ToString(confirmation.Id)) ? 0 : confirmation.Id;
                if (d > 0)
                {

                    confirmation.Active = 1;
                    db.SaveChanges();


                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Error");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message.ToString());
            }
            return RedirectToAction("Error");



        }

        public string Error()
        {
            return "<h4>Error 505 Page</h4>";
        }

    }
}