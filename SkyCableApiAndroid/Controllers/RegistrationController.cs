using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using SkyCableApiAndroid.Models;
using SkyCableApiAndroid.Entity;

namespace SkyCableApiAndroid.Controllers
{
    public class RegistrationController : ApiController
    {
        CableApiAndroidEntity _db = new CableApiAndroidEntity();

        #region Admin Registration

        [HttpPost]
        public async Task<ProjectResult> AdminRegistration(tblAdminRegistration model)
        {
            try
            {
                var result1 = _db.tblAdminRegistrations.Where(a=>a.UserId == model.UserId && a.Password == model.Password && a.IMEINo == model.IMEINo).ToList();
                if (result1.Count != 0)
                {
                    return new ProjectResult { Message = "User Already Exist", Status = 2, Response = result1 };
                }
                else
                {
                    model.SkyStatus = 0;
                    var result = _db.tblAdminRegistrations.Max(psd => psd.RegId);
                    if (result == null)
                    {
                        result = 0;
                    }
                    model.RegId = (result.Value) + 1;

                    tblAdminRegistration _objAdmin = new tblAdminRegistration();

                    if (ModelState.IsValid)
                    {
                        _objAdmin.RegId = model.RegId;
                        _objAdmin.Name = model.Name;
                        _objAdmin.Address = model.Address;
                        _objAdmin.City = model.City;
                        _objAdmin.Email = model.Email;
                        _objAdmin.MobileNo = model.MobileNo;
                        _objAdmin.UserId = model.UserId;
                        _objAdmin.Password = model.Password;
                        _objAdmin.Pin = model.Pin;
                        _objAdmin.NoOfAgent = model.NoOfAgent;
                        //_objAdmin.RegDate = model.RegDate;
                        _objAdmin.RegDate = System.DateTime.Now.Date;
                        _objAdmin.SkyStatus = model.SkyStatus;
                        _objAdmin.IMEINo = model.IMEINo;
                        _objAdmin.OperatorCode = model.OperatorCode;

                        _db.tblAdminRegistrations.Add(_objAdmin);
                        _db.SaveChanges();


                        return new ProjectResult { Message = "Success", Status = 1, Response = _objAdmin };
                    }
                    else
                    {
                        return new ProjectResult { Message = "No data found", Status = 0, Response = null };
                    }
                }
               
            }
            catch (Exception ex)
            {
                return new ProjectResult { Message = ex.ToString(), Status = 0, Response = null };
            }
        }


        #endregion

        #region customer Registration

        [HttpPost]
        public async Task<ProjectResult> CustomerRegistration(tblCustomerRegistration model)
        {

            try
            {
                var result1 = _db.tblCustomerRegistrations.Where(a => a.CustName == model.CustName && a.IMEINo == model.IMEINo).ToList();
                if (result1.Count != 0)
                {
                    return new ProjectResult { Message = "User Already Exist", Status = 0, Response = result1 };
                }
                else
                {
                    tblCustomerRegistration _objCustomer = new tblCustomerRegistration();

                    _objCustomer.CustName = model.CustName;
                    _objCustomer.Address = model.Address;
                    _objCustomer.MobileNo = model.MobileNo;
                    _objCustomer.Area = model.Area;
                    _objCustomer.NoOfBox = model.NoOfBox;
                    _objCustomer.SetupBox_Details = model.SetupBox_Details;
                    _objCustomer.Package = model.Package;
                    _objCustomer.PackageRate = (model.PackageRate * model.NoOfBox);

                    if (_objCustomer.OldBal == null)
                    {
                        _objCustomer.OldBal = 0;
                    }
                    else
                    {
                        _objCustomer.OldBal = model.OldBal;
                    }

                    _objCustomer.RegistrationDate = model.RegistrationDate;
                    _objCustomer.AgentName = model.AgentName;
                    _objCustomer.Status = model.Status;
                    _objCustomer.IMEINo = model.IMEINo;
                    _objCustomer.OperatorCode = model.OperatorCode;

                    _db.tblCustomerRegistrations.Add(_objCustomer);
                    _db.SaveChanges();

                    if (_objCustomer != null)
                    {
                        return new ProjectResult { Message = "Sucsessfully", Status = 1, Response = _objCustomer };
                    }
                    else
                    {
                        return new ProjectResult { Message = "Insert Failed", Status = 0, Response = null };

                    }

                }
                   
            }
            catch (Exception exp)
            {
                return new ProjectResult { Message = exp.ToString(), Status = 0, Response = null };
            }

        }

        #endregion

        #region Agent Registration

        [HttpPost]
        public async Task<ProjectResult> AgentRegistration(tblAgent model)
        {
            tblAgent _objAgent = new tblAgent();


            try
            {
                if (ModelState.IsValid)
                {
                    _objAgent.AgentId = model.AgentId;
                    _objAgent.AgentName = model.AgentName;
                    _objAgent.Password = model.Password;
                    _objAgent.IMEINo = model.IMEINo;
                    _objAgent.OperatorCode = model.OperatorCode;


                    _db.tblAgents.Add(_objAgent);
                    _db.SaveChanges();

                    return new ProjectResult { Message = "Success", Status = 1, Response = "Success" };

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

        [HttpPost]
        public async Task<ProjectResult> PackageInsert(tblPackage model)
        {
            tblPackage _objPackage = new tblPackage();


            try
            {
                if (ModelState.IsValid)
                {
                    _objPackage.Pid = model.Pid;
                    _objPackage.PackageName = model.PackageName;
                    _objPackage.Rate = model.Rate;
                    _objPackage.IMEINo = model.IMEINo;
                    _objPackage.OperatorCode = model.OperatorCode;

                    _db.tblPackages.Add(_objPackage);
                    _db.SaveChanges();

                    return new ProjectResult { Message = "Success", Status = 1, Response = "Success" };

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

        [HttpPost]
        public async Task<ProjectResult> PackageData(tblPackage model)
        { 
            try
            {
                var result = _db.tblPackages.Where(a=>a.IMEINo == model.IMEINo && a.OperatorCode == model.OperatorCode).ToList();

                if (result != null)
                {
                    return new ProjectResult { Message = "Success", Status = 1, Response = result };
                }
                else
                {
                    return new ProjectResult { Message = "Not Success", Status = 0, Response = null };
                }

                    
                
            }
            catch (Exception exp)
            {
                return new ProjectResult { Message = exp.ToString(), Status = 0, Response = null };
            }

        }

        [HttpPost]
        public async Task<ProjectResult> AgentData(tblAgent model)
        {
            try
            {
                var result = _db.tblAgents.Where(a => a.IMEINo == model.IMEINo && a.OperatorCode == model.OperatorCode).ToList();

                if (result != null)
                {
                    return new ProjectResult { Message = "Success", Status = 1, Response = result };
                }
                else
                {
                    return new ProjectResult { Message = "Not Success", Status = 0, Response = null };
                }

            }
            catch (Exception exp)
            {
                return new ProjectResult { Message = exp.ToString(), Status = 0, Response = null };
            }

        }

        #endregion

        #region Agent Login
        [HttpPost]
        public async Task<ProjectResult> AgentLogin(tblAgent model)
        {
            try
            {
                var result = _db.tblAgents.Where(a=>a.AgentName==model.AgentName && a.Password == model.Password && a.OperatorCode == model.OperatorCode).ToList();

                if (result != null)
                {
                    return new ProjectResult { Message = "Success", Status = 1, Response = result };
                }
                else
                {
                    return new ProjectResult { Message = "Not Success", Status = 0, Response = null };
                }

            }
            catch (Exception exp)
            {
                return new ProjectResult { Message = exp.ToString(), Status = 0, Response = null };
            }

        }
        #endregion

        #region Operator No
        [HttpPost]
        public async Task<ProjectResult> getOperatorno(tblAdminRegistration model)
        {
            try
            {
                var result = _db.tblAdminRegistrations.Where(a => a.IMEINo == model.IMEINo).ToList();

                if (result != null)
                {
                    return new ProjectResult { Message = "Success", Status = 1, Response = result };
                }
                else
                {
                    return new ProjectResult { Message = "Not Success", Status = 0, Response = null };
                }

            }
            catch (Exception exp)
            {
                return new ProjectResult { Message = exp.ToString(), Status = 0, Response = null };
            }

        }
        #endregion

        #region Admin Login

        [HttpPost]
        public async Task<ProjectResult> AdminLogin(tblAdminRegistration model)
        {
            try
            {
                if (model.Password != null)
                {
                    if (model.UserId != null)
                    {
                        var result = _db.tblAdminRegistrations.Where(a => a.UserId == model.UserId && a.Password == model.Password && a.IMEINo==model.IMEINo).ToList();

                        if (result == null)
                        {
                            return new ProjectResult { Message = "Sorry User ID or Password is Wrong", Status = 0, Response = null };

                        }
                        if (result.Count != 0)
                        {
                            foreach (var item in result)
                            {
                                if (item.SkyStatus == 1)
                                {
                                    return new ProjectResult { Message = "Success", Status = 1, Response = result };

                                }
                                else
                                {
                                    return new ProjectResult { Message = "Sorry Request Not Approval", Status = 0, Response = null };

                                }
                            }

                            return new ProjectResult { Message = "Sorry Something is Wrong", Status = 0, Response = null };


                        }
                        else
                        {
                            return new ProjectResult { Message = "Sorry User ID or Password is Wrong", Status = 0, Response = null };

                        }
                    }
                    else
                    {
                        return new ProjectResult { Message = "Sorry User ID is Blank", Status = 0, Response = null };

                    }


                }
                else
                {
                    if (model.Pin != null)
                    {

                        var result = _db.tblAdminRegistrations.Where(a => a.Pin == model.Pin && a.IMEINo==model.IMEINo).ToList();

                        if (result == null)
                        {
                            return new ProjectResult { Message = "Sorry Pin is Wrong", Status = 0, Response = null };

                        }
                        if (result.Count != 0)
                        {
                            foreach (var item in result)
                            {
                                if (item.SkyStatus == 1)
                                {
                                    return new ProjectResult { Message = "Success", Status = 1, Response = result };

                                }
                                else
                                {
                                    return new ProjectResult { Message = "Sorry Request Not Approval", Status = 0, Response = null };

                                }
                            }

                            return new ProjectResult { Message = "Sorry Something is Wrong", Status = 0, Response = null };

                        }
                        else
                        {
                            return new ProjectResult { Message = "Sorry UserId Or Password is Wrong", Status = 0, Response = null };

                        }

                    }
                    else
                    {
                        return new ProjectResult { Message = "Sorry Pin is Wrong", Status = 0, Response = null };
                    }

                }


            }
            catch (Exception exp)
            {
                return new ProjectResult { Message = exp.ToString(), Status = 0, Response = null };
            }
        }

        #endregion


        #region  All Bill Details List

        public async Task<ProjectResult> BillDetailsList(tblBill model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _db.tblBills.Where(psd => psd.AgentName == model.AgentName && psd.Bmonth == model.Bmonth && psd.Byear == model.Byear && psd.OperatorCode == model.OperatorCode).ToList();

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

        #region  All Paid Details List

        public async Task<ProjectResult> PaidDetailsList(tblBill model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _db.tblBills.Where(psd => psd.AgentName == model.AgentName && psd.CustId == model.CustId).ToList();

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


        #region Add Package Information

        [HttpPost]
        public async Task<ProjectResult> AddPackageInfo(tblPackage model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    tblPackage _objPkg = new tblPackage();

                    _objPkg.PackageName = model.PackageName;
                    _objPkg.Rate = model.Rate;

                    _db.tblPackages.Add(_objPkg);
                    _db.SaveChanges();

                    return new ProjectResult { Message = "Sucsess", Status = 1, Response = "Success" };


                }
                else
                {
                    return new ProjectResult { Message = "Something is Wrong", Status = 0, Response = null };

                }



            }
            catch (Exception exp)
            {
                return new ProjectResult { Message = exp.ToString(), Status = 0, Response = null };
            }

        }

        #endregion

        #region New Bill Generation 

        public async Task<ProjectResult> BillGeneration(tblBillGenerationModel model)
        {
            try
            {

                var result1 = _db.tblBills.Where(a => a.Bmonth == model.Bmonth && a.Byear == model.Byear && a.IMEINo == model.IMEINo && a.OperatorCode == model.OperatorCode).ToList();
                if(result1.Count == 0)
                {
                    tblBill _objBill = new tblBill();

                    var result = _db.tblCustomerRegistrations.ToList();

                    if (result.Count != 0)
                    {
                        foreach (var record in result)
                        {
                            _objBill.CustId = record.CustId;
                            _objBill.CustName = record.CustName;
                            _objBill.Address = record.Address;
                            _objBill.MobileNo = record.MobileNo;
                            _objBill.Area = record.Area;
                            _objBill.NoOfBox = record.NoOfBox;
                            _objBill.SetupBox_Details = record.SetupBox_Details;
                            _objBill.Package = record.Package;
                            if (record.OldBal == null)
                            {
                                record.OldBal = 0;
                            }
                            _objBill.Monthcharge = (Convert.ToInt32(record.PackageRate + record.OldBal));
                            _objBill.RegistrationDate = record.RegistrationDate;
                            _objBill.AgentName = record.AgentName;
                            _objBill.PaymentDate1 = "";
                            _objBill.PaymentAmount1 = 0;
                            _objBill.PaymentDate2 = "";
                            _objBill.PaymentAmount2 = 0;
                            _objBill.OldBal = record.OldBal;
                            _objBill.Balance = (Convert.ToInt32(record.PackageRate + record.OldBal));
                            _objBill.Bmonth = model.Bmonth;
                            _objBill.Byear = model.Byear;
                            _objBill.Status = record.Status;
                            _objBill.IMEINo = record.IMEINo;
                            _objBill.OperatorCode = record.OperatorCode;

                            _db.tblBills.Add(_objBill);
                            _db.SaveChanges();


                        }

                        return new ProjectResult { Message = "Success", Status = 1, Response = "Success" };

                    }
                    else
                    {
                        return new ProjectResult { Message = "Failed", Status = 0, Response = null };
                    }
                }
                else
                {
                    return new ProjectResult { Message = "Bill Already Generated", Status = 2, Response = null };
                }
               




            }
            catch (Exception exp)
            {
                return new ProjectResult { Message = exp.ToString(), Status = 0, Response = null };
            }

        }

        #endregion


        #region  All Bill Details

        public async Task<ProjectResult> AllBillDetails(tblPaidBillModel model)
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


        #region  All BillNo Details

        public async Task<ProjectResult> BillNoDetails(tblBill model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _db.tblBills.Where(psd => psd.Bid == model.Bid && psd.OperatorCode == model.OperatorCode).ToList();

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


        #region  All Agent Ip Link Details

        public async Task<ProjectResult> AgentIpLinkDetails(tblAdminRegistration model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _db.tblAdminRegistrations.Where(psd => psd.OperatorCode == model.OperatorCode && psd.SkyStatus == 1).ToList();

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


        #region Bill Paid 

        [HttpPost]
        public async Task<ProjectResult> PaidBill(tblPaidBillModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // var result = _db.tblBills.Where(psd=>psd.CustId==model.CustId).FirstOrDefault();

                    using (CableApiAndroidEntity _db = new CableApiAndroidEntity())
                    {

                        tblBill _objBill = (from psd in _db.tblBills.Where(psd => psd.Bid == model.Bid) select psd).FirstOrDefault();
                        tblCustomerRegistration _objCust = (from psd in _db.tblCustomerRegistrations.Where(psd => psd.CustId == _objBill.CustId) select psd).FirstOrDefault();

                        if (model.PaymentAmount2 != 0 && model.PaymentDate2 != "")
                        {
                            //_objBill.PaymentAmount1 = model.PaymentAmount1;
                            //_objBill.PaymentDate1 = model.PaymentDate1;
                            _objBill.PaymentAmount2 = model.PaymentAmount2;
                            _objBill.PaymentDate2 = model.PaymentDate2;
                            _objBill.Balance = model.Balance;
                            _objBill.Bid = model.Bid;

                        }
                        else
                        {
                            _objBill.PaymentAmount1 = model.PaymentAmount1;
                            _objBill.PaymentDate1 = model.PaymentDate1;
                            _objBill.PaymentAmount2 = 0;
                            _objBill.PaymentDate2 = "";
                            _objBill.Balance = model.Balance;
                            _objBill.Bid = model.Bid;
                        }



                        if (model.PaymentAmount1 != 0 && model.PaymentAmount2 == 0)
                        {
                            //_objBill.Balance = (model.Monthcharge-model.PaymentAmount1);
                            _objCust.OldBal = model.Balance;
                        }
                        else
                        {
                            //_objBill.Balance = (model.Monthcharge - (model.PaymentAmount2 + model.PaymentAmount1));
                            _objCust.OldBal = model.Balance;
                        }

                        _db.Entry(_objBill).State = System.Data.Entity.EntityState.Modified;
                        _db.SaveChanges();

                        _db.Entry(_objCust).State = System.Data.Entity.EntityState.Modified;
                        _db.SaveChanges();

                        return new ProjectResult { Message = "Success", Status = 1, Response = _objBill };

                    }



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


        #region  All Agent Imeino Update

        public async Task<ProjectResult> Imeinoupdate(tblAgent model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tblAgent _objcr = new tblAgent();
                    _objcr = _db.tblAgents.Where(a => a.AgentName == model.AgentName && a.OperatorCode == model.OperatorCode).FirstOrDefault();
                    _objcr.IMEINo = model.IMEINo;

                    _db.Entry(_objcr).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                    return new ProjectResult { Message = "Success", Status = 1, Response = _objcr };
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


        #region  All Mobile Update

        public async Task<ProjectResult> Mobileupdate(tblCustomerRegistration model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tblCustomerRegistration _objcr = new tblCustomerRegistration();
                    _objcr = _db.tblCustomerRegistrations.Where(a => a.CustId == model.CustId && a.OperatorCode == model.OperatorCode).FirstOrDefault();
                    _objcr.MobileNo = model.MobileNo;

                    _db.Entry(_objcr).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                    return new ProjectResult { Message = "Success", Status = 1, Response = _objcr };
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


        #region Daily Collections Report Agent

        [HttpPost]
        public async Task<ProjectResult> DailyCollectionReportAgent(tblBill model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _db.tblBills.Where(psd => (psd.PaymentDate1.Contains(model.PaymentDate1)) || (psd.PaymentDate2.Contains(model.PaymentDate2)) && psd.Bmonth == model.Bmonth && psd.Byear == model.Byear && psd.AgentName == model.AgentName && psd.OperatorCode == model.OperatorCode).ToList();

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
    }
}
