using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SkyCableApiAndroid.Models;
using SkyCableApiAndroid.Entity;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SkyCableApiAndroid.Controllers
{
    
    public class ApprovalController : ApiController
    {


        CableApiAndroidEntity _db = new CableApiAndroidEntity();


        #region Admin Table Registrated User List For Approval Request

        [HttpGet]
        public async Task<ProjectResult> GetAdminApprovalRequest()
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var result = _db.tblAdminRegistrations.Where(a => a.SkyStatus == 0).ToList();

                    return new ProjectResult { Message = "Success", Status = 1, Response = result };
                }
                else
                {
                    return new ProjectResult { Message = "Failed", Status = 0, Response = null };
                }
            }
            catch (Exception exp)
            {
                return new ProjectResult { Message = "Failed", Status = 0, Response = null };
            }


        }

        #endregion

        #region Validate Pin For Avoiding Duplications

        [HttpPost]
        public async Task<ProjectResult> ValidatePin(tblValidatePinModel model)
        {

            try
            {

                var result = _db.tblAdminRegistrations.Where(psd => psd.Pin == model.Pin).FirstOrDefault();

                if (result == null)
                {
                    return new ProjectResult { Message = "Success", Status = 1, Response = "Success" };
                }
                else
                {
                    return new ProjectResult { Message = "Pin Already Exist", Status = 0, Response = null };
                }


            }
            catch (Exception exp)
            {

                return new ProjectResult { Message = exp.ToString(), Status = 0, Response = null };
            }

        }

        #endregion

        #region Approval The  Admin Request

        [HttpPost]
        public async Task<ProjectResult> ApprovalRequest(int id)
        {
            string OperatorCode = GenerateRandomChar()+ Convert.ToString(GenerateRandomNo());

            tblAdminRegistration _objAdmin = _db.tblAdminRegistrations.Find(id);

            try
            {
                var result = _db.tblAdminRegistrations.Where(psd=>psd.OperatorCode==OperatorCode).ToList();

                if(result.Count==0)
                {

                    _objAdmin.SkyStatus = 1;
                    _objAdmin.OperatorCode = OperatorCode;
                    _db.Entry(_objAdmin).State = EntityState.Modified;
                    _db.SaveChanges();
                }
                else
                {
                    OperatorCode = GenerateRandomChar() + Convert.ToString(GenerateRandomNo());
                    _objAdmin.SkyStatus = 1;
                    _objAdmin.OperatorCode = OperatorCode;
                    _db.Entry(_objAdmin).State = EntityState.Modified;
                    _db.SaveChanges();
                }
               

                return new ProjectResult { Message="Success",Status=1,Response="Success"};

            }
            catch(Exception exp)
            {
                return new ProjectResult { Message=exp.ToString(),Status=0,Response=null};
            }
        }

        #endregion

        #region Reject The Admin Request

        [HttpPost]
        public async Task<ProjectResult> RejectRequest(int id)
        {
            try
            {
                tblAdminRegistration _objAdmin = _db.tblAdminRegistrations.Find(id);
                _objAdmin.SkyStatus = 2;

                _db.Entry(_objAdmin).State = EntityState.Modified;
                _db.SaveChanges();

                return new ProjectResult { Message="Success",Status=1,Response="Success"};

            }
            catch(Exception exp)
            {
                return new ProjectResult { Message="Failed",Status=0,Response=null};
            }
        }

        #endregion

        #region Random Functions For Generate Alpha-Numeric 8 Digit Number

        //Generate RandomNo
        public int GenerateRandomNo()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }


        public static string GenerateRandomChar()
        {
            string result = string.Empty;
            Random random = new Random((int)DateTime.Now.Ticks);
            List<string> characters = new List<string>() { };
             for (int i = 65; i < 91; i++)
            {
                characters.Add(((char)i).ToString());
            }
            for (int i = 0; i < 4; i++)
            {
                result += characters[random.Next(0, characters.Count)];
               
            }
            return result;
        }

        #endregion


    }
}
