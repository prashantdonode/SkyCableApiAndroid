using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SkyCableApiAndroid.Entity;
using SkyCableApiAndroid.Models;
using System.Net;
using System.Data.Entity;
using System.Web.Security;

namespace SkyCableApiAndroid.Controllers
{
    public class AdminController : Controller
    {



        CableApiAndroidEntity _db = new CableApiAndroidEntity();
        ApprovalController _objApproval = new ApprovalController();
        ReportController _objReport = new ReportController();
        RegistrationController _objReg = new RegistrationController();



        public ActionResult Dashboard()
        {
            return View();
        }


        public ActionResult RequestApproval()
        {
              var result = _db.tblAdminRegistrations.ToList();

               return View(result);

         }


        #region Sky Vision Company Login

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(tblSkyVisionLogin model)
        {
            if (ModelState.IsValid)
            {
                using (CableApiAndroidEntity _db = new CableApiAndroidEntity())
                {

                   // string abc = "";
                    var result = _db.tblSkyVisionLogins.Where(psd => psd.UserId == model.UserId && psd.Password == model.Password).FirstOrDefault();

                    if (result != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.UserId, model.RememberMe);
                        Session["UserId"] = result.UserId;
                        Session["Password"] = result.Password;

                        return RedirectToAction("Dashboard", "Admin");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Login data is incorrect!");
                    }

                }

            }

            return View();
        }



        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        #endregion



        #region Approval The Request

        public ActionResult Approval(int id)
        {
            int Status = 0;
         

            if (ModelState.IsValid)
            {
                var result = _objApproval.ApprovalRequest(id);
               
                if(result.Result.Status==1)
                {
                    Status = 1;
                    ViewBag.Message = Status;
                    return RedirectToAction("RequestApproval", "Admin");
                }

               
            }

            return View();
        }


        #endregion


        #region Reject The Request


        public ActionResult Reject(int id)
        {
            int Status = 0;

            if (ModelState.IsValid)
            {
                var result = _objApproval.RejectRequest(id);
                
                if(result.Result.Status==1)
                {
                    Status = 1;
                    ViewBag.Message = Status;
                    return RedirectToAction("RequestApproval", "Admin");

                }
               
               
            }

            return View();
        }


        #endregion

        #region Reject List

        public ActionResult RejectRequestList()
        {
            var result = _db.tblAdminRegistrations.Where(psd => psd.SkyStatus == 2).ToList();

            return View(result);
        }

        #endregion

        #region Daily Collection Reports Show

        public ActionResult DilyCollectionReport()
        {
            // tblDailyCollectionModel model = new tblDailyCollectionModel();

            tblBill model = new tblBill();

            model.PaymentDate1 = Convert.ToString(System.DateTime.Now.Date);
            model.PaymentDate1 = model.PaymentDate1.Remove(10);

            model.PaymentDate2 = Convert.ToString(System.DateTime.Now.Date);
            model.PaymentDate2 = model.PaymentDate2.Remove(10);

            model.Bmonth = Convert.ToString(DateTime.Now.ToString("MMM"));
            model.Byear = Convert.ToString(DateTime.Now.Year);



            var result = _db.tblBills.Where(psd => psd.PaymentDate1.Contains(model.PaymentDate1) || psd.PaymentDate2.Contains(model.PaymentDate2) && psd.Bmonth==model.Bmonth && psd.Byear==model.Byear).ToList();

            return View(result);
        }

        #endregion

        #region Month Wise Reports show

        public ActionResult MonthWiseReport()
        {
            // tblDailyCollectionModel model = new tblDailyCollectionModel();

            tblBill model = new tblBill();

            model.PaymentDate1 = Convert.ToString(System.DateTime.Now.Date);
            model.PaymentDate1 = model.PaymentDate1.Remove(10);

            model.PaymentDate2 = Convert.ToString(System.DateTime.Now.Date);
            model.PaymentDate2 = model.PaymentDate2.Remove(10);

            model.Bmonth = Convert.ToString(DateTime.Now.ToString("MMM"));
            model.Byear = Convert.ToString(DateTime.Now.Year);

            var result = _db.tblBills.Where(psd=>psd.Bmonth==model.Bmonth && psd.Byear==model.Byear).ToList();

            return View(result);
        }


        #endregion

        #region Balance Reports Show

        public ActionResult BalanceReport()
        {
            // tblDailyCollectionModel model = new tblDailyCollectionModel();

            tblBill model = new tblBill();

            model.PaymentDate1 = Convert.ToString(System.DateTime.Now.Date);
            model.PaymentDate1 = model.PaymentDate1.Remove(10);

            model.PaymentDate2 = Convert.ToString(System.DateTime.Now.Date);
            model.PaymentDate2 = model.PaymentDate2.Remove(10);

            model.Bmonth = Convert.ToString(DateTime.Now.ToString("MMM"));
            model.Byear = Convert.ToString(DateTime.Now.Year);

            var result = _db.tblBills.Where(psd=>psd.Bmonth==model.Bmonth && psd.Byear==model.Byear && psd.Balance!=0).ToList();

            return View(result);
        }

        #endregion

        #region Active Customer Reports Show

        public ActionResult ActiveCustomerReport()
        {
            // tblDailyCollectionModel model = new tblDailyCollectionModel();
            tblBill model = new tblBill();

            model.PaymentDate1 = Convert.ToString(System.DateTime.Now.Date);
            model.PaymentDate1 = model.PaymentDate1.Remove(10);

            model.PaymentDate2 = Convert.ToString(System.DateTime.Now.Date);
            model.PaymentDate2 = model.PaymentDate2.Remove(10);

            model.Bmonth = Convert.ToString(DateTime.Now.ToString("MMM"));
            model.Byear = Convert.ToString(DateTime.Now.Year);

            var result = _db.tblBills.Where(psd => psd.Bmonth == model.Bmonth && psd.Byear == model.Byear && psd.Status == "Active").ToList();

            return View(result);
        }

        #endregion

        #region Deactive Customer Reports Show

        public ActionResult DeactiveCustomerReport()
        {
            // tblDailyCollectionModel model = new tblDailyCollectionModel();

            tblBill model = new tblBill();

            model.PaymentDate1 = Convert.ToString(System.DateTime.Now.Date);
            model.PaymentDate1 = model.PaymentDate1.Remove(10);

            model.PaymentDate2 = Convert.ToString(System.DateTime.Now.Date);
            model.PaymentDate2 = model.PaymentDate2.Remove(10);

            model.Bmonth = Convert.ToString(DateTime.Now.ToString("MMM"));
            model.Byear = Convert.ToString(DateTime.Now.Year);

            var result = _db.tblBills.Where(psd=>psd.Bmonth==model.Bmonth && psd.Byear==model.Byear && psd.Status=="Deactive").ToList();
            return View(result);
        }

        #endregion

        #region Paid Bill Method Show

        public ActionResult PaidBill(tblPaidBillModel model)
        {
            model.Bmonth = Convert.ToString(DateTime.Now.ToString("MMM"));
            model.Byear = Convert.ToString(DateTime.Now.Year);

            var result = _objReg.AllBillDetails(model);

            return View(result.Result.Response);
        }


        public ActionResult PaidBillEdit(int id)
        {
            tblBill _objBill = _db.tblBills.Find(id);

            if (_objBill == null)
            {
                return HttpNotFound();
            }

            return View(_objBill);
        }


        [HttpPost]
        public ActionResult PaidBillEdit(tblBill bill)
        {
            if (ModelState.IsValid)
            {
                tblPaidBillModel model = new tblPaidBillModel();

                model.Bid = bill.Bid;
                model.PaymentAmount1 = bill.PaymentAmount1;
                model.PaymentAmount2 = bill.PaymentAmount2;
                model.PaymentDate1 = bill.PaymentDate1;
                model.PaymentDate2 = bill.PaymentDate2;
                model.Monthcharge = bill.Monthcharge;
                model.Balance = bill.Balance;


                _db.Entry(bill).State = EntityState.Modified;
                _db.SaveChanges();

                var result = _objReg.PaidBill(model);

                return RedirectToAction("Dashboard", "Admin");
            }

            return View(bill);
        }

        #endregion



    }


}