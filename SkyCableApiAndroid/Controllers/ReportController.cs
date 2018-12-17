using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SkyCableApiAndroid.Models;
using SkyCableApiAndroid.Entity;
using System.Threading.Tasks;

namespace SkyCableApiAndroid.Controllers
{
    public class ReportController : ApiController
    {



        CableApiAndroidEntity _db = new CableApiAndroidEntity();


        #region Daily Collection Sum Reports
        [HttpPost]
        public async Task<ProjectResult> DailyCollectionSumReport(tblBill model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _db.tblBills.Where(psd => (psd.PaymentDate1.Contains(model.PaymentDate1)) || (psd.PaymentDate2.Contains(model.PaymentDate2)) && psd.Bmonth == model.Bmonth && psd.Byear == model.Byear && psd.IMEINo == model.IMEINo && psd.OperatorCode == model.OperatorCode).Sum(psd => (psd.PaymentAmount1) + (psd.PaymentAmount2)).Value;

                    return new ProjectResult { Message = "Successs", Status = 1, Response = result };

                }
                else
                {
                    return new ProjectResult { Message = "Failed", Status = 0, Response = null };

                }


            }
            catch (Exception exp)
            {
                return new ProjectResult { Message = exp.ToString(), Status = 0, Response = null };
            }
        }



        #endregion

        #region Daily Collection Reports

        [HttpPost]
        public async Task<ProjectResult> DailyCollectionReport(tblBill model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _db.tblBills.Where(psd => (psd.PaymentDate1.Contains(model.PaymentDate1)) || (psd.PaymentDate2.Contains(model.PaymentDate2)) && psd.Bmonth == model.Bmonth && psd.Byear == model.Byear && psd.IMEINo == model.IMEINo && psd.OperatorCode == model.OperatorCode).ToList();

                    return new ProjectResult { Message = "Successs", Status = 1, Response = result };

                }
                else
                {
                    return new ProjectResult { Message = "Failed", Status = 0, Response = null };

                }

            }
            catch (Exception exp)
            {
                return new ProjectResult { Message = exp.ToString(), Status = 0, Response = null };

            }

        }


        #endregion

        #region Month Wise Sum Reports

        [HttpPost]
        public async Task<ProjectResult> MonthWiseSumReport(tblBill model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _db.tblBills.Where(psd => psd.Bmonth == model.Bmonth && psd.Byear == model.Byear && psd.IMEINo == model.IMEINo && psd.OperatorCode == model.OperatorCode).Sum(psd => (psd.PaymentAmount1) + (psd.PaymentAmount2)).Value;

                    return new ProjectResult { Message = "Success", Status = 1, Response = result };

                }
                else
                {
                    return new ProjectResult { Message = "Failed", Status = 0, Response = null };
                }


            }
            catch (Exception exp)
            {

                return new ProjectResult { Message = exp.ToString(), Status = 0, Response = null };
            }
        }

        #endregion

        #region Month Wise Reports

        [HttpPost]
        public async Task<ProjectResult> MonthWiseReport(tblBill model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _db.tblBills.Where(psd => psd.Bmonth == model.Bmonth && psd.Byear == model.Byear && psd.IMEINo == model.IMEINo && psd.OperatorCode == model.OperatorCode).ToList();

                    return new ProjectResult { Message = "Success", Status = 1, Response = result };
                }
                else
                {
                    return new ProjectResult { Message = "Failed", Status = 0, Response = null };
                }


            }
            catch (Exception exp)
            {
                return new ProjectResult { Message = exp.ToString(), Status = 0, Response = null };
            }

        }

        #endregion

        #region Balance Sum Reports

        [HttpPost]
        public async Task<ProjectResult> BalanceSumReport(tblBill model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _db.tblBills.Where(psd => psd.Bmonth == model.Bmonth && psd.Byear == model.Byear && psd.IMEINo == model.IMEINo && psd.OperatorCode == model.OperatorCode).Sum(psd => psd.Balance).Value;

                    return new ProjectResult { Message = "Success", Status = 1, Response = result };

                }
                else
                {
                    return new ProjectResult { Message = "Failed", Status = 0, Response = null };
                }


            }
            catch (Exception exp)
            {
                return new ProjectResult { Message = exp.ToString(), Status = 0, Response = null };
            }

        }


        #endregion

        #region Balance Reports

        [HttpPost]
        public async Task<ProjectResult> BalanceReport(tblBill model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _db.tblBills.Where(psd => psd.Bmonth == model.Bmonth && psd.Byear == model.Byear && psd.Balance != 0 && psd.IMEINo == model.IMEINo && psd.OperatorCode == model.OperatorCode).ToList();


                    return new ProjectResult { Message = "Success", Status = 1, Response = result };
                }
                else
                {
                    return new ProjectResult { Message = "Failed", Status = 0, Response = null };
                }

            }
            catch (Exception exp)
            {
                return new ProjectResult { Message = exp.ToString(), Status = 0, Response = null };
            }
        }

        #endregion

        #region Active Customer Sum Reports

        [HttpPost]
        public async Task<ProjectResult> ActiveCustomerSumReport(tblBill model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var result = _db.tblBills.Where(psd => psd.Bmonth == model.Bmonth && psd.Byear == model.Byear && psd.IMEINo == model.IMEINo && psd.OperatorCode == model.OperatorCode && psd.Status == "Active").ToList();

                    return new ProjectResult { Message = "Success", Status = 1, Response = result.Count };

                }
                else
                {
                    return new ProjectResult { Message = "Failed", Status = 0, Response = null };
                }


            }
            catch (Exception exp)
            {

                return new ProjectResult { Message = exp.ToString(), Status = 0, Response = null };

            }

        }

        #endregion

        #region Active Deactive Customer Reports 

        [HttpPost]
        public async Task<ProjectResult> ActiveCustomerReport(tblBill model)
        {

            try
            {
                if (ModelState.IsValid)
                {

                    var result = _db.tblBills.Where(psd => psd.Bmonth == model.Bmonth && psd.Byear == model.Byear && psd.IMEINo == model.IMEINo && psd.OperatorCode == model.OperatorCode).ToList();

                    return new ProjectResult { Message = "Success", Status = 1, Response = result };

                }
                else
                {
                    return new ProjectResult { Message = "Failed", Status = 0, Response = null };
                }


            }
            catch (Exception exp)
            {
                return new ProjectResult { Message = exp.ToString(), Status = 0, Response = null };
            }

        }


        #endregion

        #region Deactive Customer Sum Reports

        [HttpPost]
        public async Task<ProjectResult> DeactiveCustomerSumReport(tblBill model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _db.tblBills.Where(psd => psd.Bmonth == model.Bmonth && psd.Byear == model.Byear && psd.IMEINo == model.IMEINo && psd.OperatorCode == model.OperatorCode && psd.Status == "Deactive").ToList();
                    
                    return new ProjectResult { Message = "Success", Status = 1, Response = result.Count };
                }
                else
                {
                    return new ProjectResult { Message = "Failed", Status = 0, Response = null };
                }

            }
            catch (Exception exp)
            {
                return new ProjectResult { Message = exp.ToString(), Status = 0, Response = null };
            }
        }

        #endregion

        #region Deactive Customer Reports

        [HttpPost]
        public async Task<ProjectResult> DeactiveCustomerReport(tblBill model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _db.tblBills.Where(psd => psd.Bmonth == model.Bmonth && psd.Byear == model.Byear && psd.IMEINo == model.IMEINo && psd.OperatorCode == model.OperatorCode && psd.Status == "Deactive").ToList();

                    return new ProjectResult { Message = "Success", Status = 1, Response = result };

                }
                else
                {
                    return new ProjectResult { Message = "Failed", Status = 0, Response = null };
                }


            }
            catch (Exception exp)
            {
                return new ProjectResult { Message = exp.ToString(), Status = 0, Response = null };
            }
        }

        #endregion



    }
}
