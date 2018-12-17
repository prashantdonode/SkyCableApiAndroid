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
                    var result = _objApproval.GetAdminApprovalRequest();

                    return View(result.Result.Response);

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


        #region Daily Collection Reports Show

        //public ActionResult DilyCollectionReport()
        //{
        //    tblDailyCollectionModel model = new tblDailyCollectionModel();

        //    model.Date = Convert.ToString(System.DateTime.Now.Date);

        //    model.Date = model.Date.Remove(10);
        //    model.Month = Convert.ToString(DateTime.Now.ToString("MMM"));
        //    model.Year = Convert.ToString(DateTime.Now.Year);



        //    var result = _objReport.DailyCollectionReport(model);

        //    return View(result.Result.Response);
        //}

        #endregion

        #region Month Wise Reports show

        //public ActionResult MonthWiseReport()
        //{
        //    tblDailyCollectionModel model = new tblDailyCollectionModel();

        //    string Date = Convert.ToString(DateTime.Now.Date);
        //    model.Date = Date.Remove(10);
        //    model.Month = Convert.ToString(DateTime.Now.ToString("MMM"));
        //    model.Year = Convert.ToString(DateTime.Now.Year);


        //    var result = _objReport.MonthWiseReport(model);

        //    return View(result.Result.Response);
        //}


        #endregion

        #region Balance Reports Show

        //public ActionResult BalanceReport()
        //{
        //    tblDailyCollectionModel model = new tblDailyCollectionModel();

        //    string Date = Convert.ToString(DateTime.Now.Date);
        //    model.Date = Date.Remove(10);
        //    model.Month = Convert.ToString(DateTime.Now.ToString("MMM"));
        //    model.Year = Convert.ToString(DateTime.Now.Year);

        //    var result = _objReport.BalanceReport(model);

        //    return View(result.Result.Response);
        //}

        #endregion

        #region Active Customer Reports Show

        //public ActionResult ActiveCustomerReport()
        //{
        //    tblDailyCollectionModel model = new tblDailyCollectionModel();

        //    string Date = Convert.ToString(DateTime.Now.Date);

        //    model.Date = Date.Remove(10);
        //    model.Month = Convert.ToString(DateTime.Now.ToString("MMM"));
        //    model.Year = Convert.ToString(DateTime.Now.Year);

        //    var result = _objReport.ActiveCustomerReport(model);

        //    return View(result.Result.Response);
        //}

        #endregion

        #region Deactive Customer Reports Show

        //public ActionResult DeactiveCustomerReport()
        //{
        //    tblDailyCollectionModel model = new tblDailyCollectionModel();

        //    string Date = Convert.ToString(DateTime.Now.Date);
        //    model.Date = Date.Remove(10);

        //    model.Month = Convert.ToString(DateTime.Now.ToString("MMM"));
        //    model.Year = Convert.ToString(DateTime.Now.Year);

        //    var result = _objReport.DeactiveCustomerReport(model);

        //    return View(result.Result.Response);
        //}

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