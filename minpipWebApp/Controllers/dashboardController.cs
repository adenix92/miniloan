using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using minpipWebApp.Models;
using System.Text.RegularExpressions;

namespace minpipWebApp.Controllers
{
    
    public class dashboardController : Controller
    {
        db_a7d46_realtech01Entities db = new db_a7d46_realtech01Entities();
        
        //
        elo_function_class orderid = new elo_function_class();
        // GET: dashboard `3ESDNJ
        public ActionResult Index()
        {
            string welcome = "";
            Session["Checked_OfficeVerification_Id"] = 0;
            Session["checked_backdetail_Id"] = 0;
            Session["checked_loan_Id"] = 0;
            Session["CheckedProfile_ID"] = 0;

             if (Session["user_email"]!=null && ((int)Session["user_id"])>0)
            {


                try
                {
                    List<SignUpClass1> signUp_Result = new List<SignUpClass1>();
                    //checking if the user update profile
                    using (db)
                    {
                        int Id = Convert.ToInt16(Session["user_id"]);
                        var Personal_Id_result = (from a in db.PersonalDatas where a.SignUp_Id == Id select a.Id).ToList();
                        ViewBag.check_user_id = Personal_Id_result.Count;
                        var cppid = string.IsNullOrEmpty(Convert.ToString(Personal_Id_result.Count)) ? 0 : Personal_Id_result.Count;

                        Session["CheckedProfile_ID"] = cppid;



                       signUp_Result = db.SignUps.Where(x => x.Id == Id && x.Active==1).Select(x => new SignUpClass1 {SurName=x.SurName,FirstName=x.FirstName,OtherName=x.OtherName,Email = x.Email,Phone=x.Phone }).ToList();
                        ViewBag.signUp_Result = signUp_Result;

                        //checking each page of the form
                        PersonalData Personal_Id = db.PersonalDatas.SingleOrDefault(x=>x.SignUp_Id==Id);
                        int PId = string.IsNullOrEmpty(Convert.ToString(Personal_Id.Id)) ? 0 : Personal_Id.Id;
                        //ViewBag.PId = PId;
                        var officeverification = (from o in db.OfficeAndIdentifications where o.PersonalDataId == PId select o.Id).ToList();
                        var cov_Id = officeverification.Count==0 ? 0 : officeverification.Count;
                        Session["Checked_OfficeVerification_Id"] = cov_Id;
                        //ViewBag 
                        var addbank = (from b in db.BankDetails where b.PersonalDataId == PId select b.Id).ToList();
                        var adb = string.IsNullOrEmpty(Convert.ToString(addbank.Count)) ? 0 : addbank.Count;
                        Session["checked_backdetail_Id"] = adb;
                        // 
                        var bankloan = (from loan in db.LoanDetails where loan.PersonalDataId==PId select loan.Id).ToList();
                        var bl = string.IsNullOrEmpty(Convert.ToString(bankloan.Count)) ? 0 : bankloan.Count;
                        Session["checked_loan_Id"] = bl;



                    }


                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

                ViewBag.welcome = welcome;
                return View();
            }
            else
            {
                return Redirect("~/Account/Index");   
            }
           
            
        }

        private int IdUser()
        {
            return Convert.ToInt16(Session["user_id"]);
        }
        public ActionResult Updateprofile() {

            if (Session["user_email"] != null && ((int)Session["user_id"]) > 0)
            {


                try
                {

                    int Id = IdUser();
                    //check the page if the record already proceed.
                    var Personal_Id_result = (from a in db.PersonalDatas where a.SignUp_Id == Id select a.Id).ToList();
                    if (Personal_Id_result.Count == 1)
                    {
                      return  Redirect("~/dashboard/Index");
                    }
                    else
                    {




                        //

                        var signUp_result = db.SignUps.SingleOrDefault(x => x.Id == Id);
                        ViewBag.surname = signUp_result.SurName;
                        ViewBag.firstname = signUp_result.FirstName;
                        ViewBag.email = signUp_result.Email;
                        //


                        //select data from states table
                        List<State> states = db.States.ToList();
                        ViewBag.states = new SelectList(states, "Id", "Name");

                        //query for occupation
                        List<Occupation> Occ = db.Occupations.ToList();
                        ViewBag.Occ = new SelectList(Occ, "Id", "Name");


                        //
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message.ToString());
                }
                return View();
            }
            else
            {
                return Redirect("~/Account/Index");
            }

           
        }

        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Updateprofile(_PersonalData Profile)
        {

            try
            {
                List<State> states = db.States.ToList();
                ViewBag.states = new SelectList(states, "Id", "Name");

                //
                List<Occupation> Occ = db.Occupations.ToList();
                ViewBag.Occ = new SelectList(Occ, "Id", "Name");

                int Id = IdUser();
                var signUp_result = db.SignUps.SingleOrDefault(x => x.Id ==Id);
                ViewBag.surname = signUp_result.SurName;
                ViewBag.firstname = signUp_result.FirstName;
                ViewBag.email = signUp_result.Email;

                //select data from states table


                //query for occupation
                

                if (ModelState.IsValid && Request.Form["LocalId"]!="")
                {
                    //
                   //
                   PersonalData p = new PersonalData();
                    string Year = DateTime.Parse(DateTime.Now.ToString()).Year.ToString();
                    string Day = DateTime.Parse(DateTime.Now.ToString()).Month.ToString();
                    p.ApplicationNumber = "MIP" + Day + Year + IdUser().ToString();
                    p.SignUp_Id = Convert.ToInt16(Id);
                    p.ResidentialAddress = Profile.ResidentialAddress;
                    p.LocalId = Profile.LocalId;//Convert.ToInt16(Request.Form["LocalId"]);
                    p.MobileNumber = Profile.MobileNumber;
                    p.ZipCode = Profile.ZipCode;
                    p.DOB = Profile.DOB;
                    p.OccupId = Profile.OccupId;
                    p.Active = 1;
                    p.DateRegister = DateTime.Now.ToString();
                    db.PersonalDatas.Add(p);
                    db.SaveChanges();
                    int i = p.Id;
                    if (i > 0)
                    {
                        Session["pid"] = p.Id;
                        return Redirect("~/dashboard/OfficeandVerification");
                    }
                    else
                    {
                        ViewBag.msg = "<h3 class=\"text-danger\"> Personal Profile Fail</h3>";
                    }
                }
                else
                {
                    Console.WriteLine("Field is not yet submitted");
                }


            }
            catch (Exception ex)
            {

                ViewBag.msg = ex.Data.Values;
            }

            return View();
        }


        private int signUpId()
        {
            int sId = Convert.ToInt16(Session["user_id"]);
            var Id = (from id in db.PersonalDatas where id.SignUp_Id==(sId) select id.Id).FirstOrDefault();
            return Id;
        }






        public ActionResult OfficeandVerification()
        {
            
            if (Session["user_email"] != null && ((int)Session["user_id"]) > 0)
            {

                //check the page if user details is already exists
                try
                {
                    var Id = signUpId();
                    var OvChecked = (from ov in db.OfficeAndIdentifications where ov.PersonalDataId == Id select ov.Id).ToList();
                    if (OvChecked.Count==1)
                    {
                        return Redirect("~/dashboard/Index");
                    }
                    else
                    {
                        List<SelectListItem> meanofidentification = new List<SelectListItem>()
            {
                new SelectListItem {Value="National ID", Text="National ID", Selected=true },
                new SelectListItem {Value="Driver License",Text="Driver License" },
                new SelectListItem {Value="Int. Passport",Text="Int. Passport" }
            };

                        ViewData["meanofidentification"] = meanofidentification;

                        List<SelectListItem> nationality = new List<SelectListItem>() {
                new SelectListItem {Value="Nigeria",Text="Nigeria", Selected=true }
            };
                        ViewData["nationality"] = nationality;
                        //

                    }

                }
                catch (Exception ex)
                {
                    ViewBag.msg = ex.Message.ToString();

                }

                
                //
                
                return View();

            }
            else
            {
                return Redirect("~/Account/Index");

            }

        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OfficeandVerification(_OfficeAndIdentification o)
        {

            List<SelectListItem> meanofidentification = new List<SelectListItem>()
            {
                new SelectListItem {Value="National ID", Text="National ID", Selected=true },
                new SelectListItem {Value="Driver License",Text="Driver License" },
                new SelectListItem {Value="Int. Passport",Text="Int. Passport" }
            };

            ViewData["meanofidentification"] = meanofidentification;

            List<SelectListItem> nationality = new List<SelectListItem>() {
                new SelectListItem {Value="Nigeria",Text="Nigeria", Selected=true }
            };
            ViewData["nationality"] = nationality;


            try
            {
                //
             

                //

                if (ModelState.IsValid)
                {
                    //ViewBag.msg = "The Model State is Valid";
                    
                    OfficeAndIdentification office_data = new OfficeAndIdentification();
                    office_data.PersonalDataId = signUpId();
                    office_data.Employer = o.Employer;
                    office_data.OfficeAddress = o.OfficeAddress;
                    office_data.OfficePhone = o.OfficePhone;
                    office_data.Department = o.Department;
                    office_data.BasicSalary = o.BasicSalary;
                    office_data.NetIncome = o.NetIncome;
                    office_data.IdentificationName = o.IdentificationName;
                    office_data.IdentificationNumber = o.IdentificationNumber;

                    office_data.IssueDate = o.IssueDate;
                    office_data.ExpireDated = o.ExpireDated;
                    office_data.Nationality = o.Nationality;
                    office_data.Spouse = o.Spouse;
                    office_data.Email = minpipWebApp.Controllers.AccountController.bytesString_Convertion(Session["user_email"].ToString());
                    office_data.DateRegister = DateTime.Now.ToString();
                    office_data.Active = 1;
                    db.OfficeAndIdentifications.Add(office_data);
                    db.SaveChanges();
                    var i = office_data.Id;
                    if (i > 0)
                    {
                        
                        return Redirect("~/dashboard/BankDetails");
                    }
                    else
                    {
                        ViewBag.msg = "<h3 class=\"text-danger\">Application Update Process Failed</h3>";
                    }




                }
                else
                {
                    Console.WriteLine("Invalid State while some Field required proper data entry");

                }

                
                //
            }
            catch (Exception ex)
            {

                ViewBag.msg = ex.Message.ToString();
            }


            return View(o);

        }

        private void load_bankdetails()
        {
            ViewBag.color = "text text-danger";

            //
            List<SelectListItem> overdraft = new List<SelectListItem>()
            {
                new SelectListItem {Value="No",Text="No" }
                ,
                new SelectListItem {Value="Yes",Text="Yes" }
            };
            ViewData["overdraft"] = overdraft;
            // checking bank type
            List<SelectListItem> _bankType = new List<SelectListItem>()
            {
                new SelectListItem { Value = "Saving", Text = "Saving", Selected=true },
                new SelectListItem { Value="Current Account", Text="Current Account", Selected=true}
            };

            ViewData["_bankType"] = _bankType;

            string[] bankArray = {"" };




            List<SelectListItem> bankList = new List<SelectListItem>() {
                new SelectListItem { }
            };
        }


        public ActionResult BankDetails()
        {

            if (Session["user_email"] != null && ((int)Session["user_id"]) > 0)
            {
                try
                {
                    

                    var Id = signUpId();
                    var bankChecked= (from ov in db.BankDetails where ov.PersonalDataId == Id select ov.Id).ToList();
                    if (bankChecked.Count == 1)
                    {
                        return Redirect("~/dashboard/Index");
                    }
                    else
                    {
                        load_bankdetails();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }

                return View();
            }
            else
            {
                return Redirect("~/Account/Index");
            }
                //
               

           
        }

        //

      

        //calling Post for bankDetails 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BankDetails(_BankDetails _bank)
        {
            load_bankdetails();

            try
            {
                //

                //define 
                ViewBag.color = "text text-danger";
                
                // 
                if (ModelState.IsValid)
                {
                    BankDetail _bd = new BankDetail();
                    _bd.AccountName = _bank.AccountName;
                    _bd.AccountNumber = _bank.AccountNumber;
                    _bd.BankName = _bank.BankName;
                    _bd.BVN = _bank.BVN;
                    _bd.AccountType = _bank.AccountType;
                    _bd.EFT_ACC_Number = _bank.EFT_ACC_Number;
                    _bd.EFT_Bank_Name = _bank.EFT_Bank_Name;
                    _bd.BankDraft = _bank.BankDraft;
                    _bd.Active = 1;
                    _bd.PersonalDataId = signUpId();

                    _bd.OrderId = orderid.OrderID();
                    _bd.RegisterDate = DateTime.Now.ToString();

                    //
                    db.BankDetails.Add(_bd);
                    db.SaveChanges();
                    var  i = _bd.Id;
                    if ((int)i > 0)
                    {
                        return Redirect("~/dashboard/LoanDetail");
                    }
                    else
                    {
                        //
                        ViewBag.msg = "<h3 class=\"text-danger\">Application Update Process Failed</h3>";
                        //
                    }                    
                    
                    
                     
                }
                else
                {
                    Console.WriteLine("Server Response: Application Models State is Invalid");
                }

            }
            catch (Exception ex)
            {

                ViewBag.error = ex.Message.ToString();
            }
            return View(_bank);
        }


        


        public ActionResult LoanDetail()
        {
            List<SelectListItem> loantype = new List<SelectListItem>()
            {
                new SelectListItem {Value="Cash",Text="Cash" }
                ,
                new SelectListItem {Value="Asset",Text="Asset" },
                new SelectListItem {Value="Other",Text="Other" }
            };
            ViewData["loantype"] = loantype;

            List<SelectListItem> frequently = new List<SelectListItem>();
            for(int i = 0; i < 4; i++)
            {
                frequently.Add(new SelectListItem { Value = i.ToString(), Text = i.ToString() +"x" });
            }
            ViewData["freq"] = frequently;
            List<SelectListItem> monthly = new List<SelectListItem>();
            for(int j = 1; j < 7; j++)
            {
                monthly.Add(new SelectListItem { Value = j.ToString(), Text = j.ToString() + "Month" });
            }
            ViewData["monthly"] = monthly;


            return View();

        }
        public ActionResult localGoverntment(int Id)
        {
            // DB_A637A2_studentPortalEntities db = new DB_A637A2_studentPortalEntities();
            //List<LGA> LGov = db.LGAs.Where(x => x.StateID == Id).Select(x => new LGA { LGAID=x.LGAID,LGAName=x.LGAName}).ToList();
            List<LocalGovt> LocalList = db.LocalGovts.ToList();
            List<Localgovts> localModel = LocalList.Where(x => x.StateId == Id).Select(x => new Localgovts { Id = x.Id, Name = x.Name}).ToList();

            return Json(localModel, JsonRequestBehavior.AllowGet);
        }


        public ActionResult AddGuarantor()
        {
            return View();
        }

        public ActionResult UploadDocument()
        {
            var file_upload = db.UploadingDescriptions.Where(x => x.OccupationId == 1).ToList();
            var callfile = new SelectList(file_upload, "Id", "DescriptionName");
            ViewBag.callfile = callfile;

            return View();
        }
        //

        public string  UniTesting()
        {
            var ex = @"^[0-9]{10}";
            var acc = "B123456789";
            var c = Regex.IsMatch(acc, ex);
            return c.ToString();

        }


        

        //

    }

   
}