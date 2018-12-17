using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkyCableApiAndroid.Models
{
    public class SkvCableApiAndroidModel
    {
    }

    public class ProjectResult
    {
        public string Message { get; set; }
        public int Status { get; set; }
        public object Response { get; set; }
    }

    public class result
    {
        public int success { get; set; }
        public string msg { get; set; }
    }



    public partial class tblAdminRegistration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Aid { get; set; }
        public Nullable<int> RegId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Pin { get; set; }
        public Nullable<System.DateTime> RegDate { get; set; }
        public Nullable<int> NoOfAgent { get; set; }
        public int SkyStatus { get; set; }
        public string OperatorCode { get; set; }
        public string IMEINo { get; set; }
    }

    public partial class tblAgent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Aid { get; set; }
        public Nullable<int> AgentId { get; set; }
        public string AgentName { get; set; }
        public string Password { get; set; }
        public string OperatorCode { get; set; }
        public string IMEINo { get; set; }

    }


    public partial class tblCustomerRegistration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustId { get; set; }
        public string CustName { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public string Area { get; set; }
        public Nullable<int> NoOfBox { get; set; }
        public string SetupBox_Details { get; set; }
        public string Package { get; set; }
        public Nullable<int> PackageRate { get; set; }
        public Nullable<int> OldBal { get; set; }
        public Nullable<System.DateTime> RegistrationDate { get; set; }
        public string AgentName { get; set; }
        public string Status { get; set; }
        public string OperatorCode { get; set; }
        public string IMEINo { get; set; }        
    }


    public partial class tblPackage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Pid { get; set; }
        public string PackageName { get; set; }
        public string Rate { get; set; }
        public string OperatorCode { get; set; }
        public string IMEINo { get; set; }
    }


    public partial class tblSkyVisionLogin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Sid { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }


    public partial class tblBill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Bid { get; set; }
        public Nullable<int> CustId { get; set; }
        public string CustName { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public string Area { get; set; }
        public Nullable<int> NoOfBox { get; set; }
        public string SetupBox_Details { get; set; }
        public string Package { get; set; }
        public Nullable<System.DateTime> RegistrationDate { get; set; }
        public string AgentName { get; set; }
        public string PaymentDate1 { get; set; }
        public Nullable<int> PaymentAmount1 { get; set; }
        public string PaymentDate2 { get; set; }
        public Nullable<int> PaymentAmount2 { get; set; }
        public Nullable<int> OldBal { get; set; }
        public Nullable<int> Monthcharge { get; set; }
        public Nullable<int> Balance { get; set; }
        public string Bmonth { get; set; }
        public string Byear { get; set; }
        public string Status { get; set; }
        public string OperatorCode { get; set; }
        public string IMEINo { get; set; }
    }







    public class tblValidatePinModel
    {
        public string Pin { get; set; }
    }






    public class tblBillGenerationModel
    {
        public string Bmonth { get;set;}
        public string Byear { get; set; }
        public string OperatorCode { get; set; }
        public string IMEINo { get; set; }
    }


    public class tblDailyCollectionModel
    {
        public string Date { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
    }


    public class tblPaidBillModel
    {
        public int Bid { get; set; }
        public Nullable<int> CustId { get; set; }
        public string CustName { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public string Area { get; set; }
        public Nullable<int> NoOfBox { get; set; }
        public string SetupBox_Details { get; set; }
        public string Package { get; set; }
        public Nullable<System.DateTime> RegistrationDate { get; set; }
        public string AgentName { get; set; }
        public string PaymentDate1 { get; set; }
        public Nullable<int> PaymentAmount1 { get; set; }
        public string PaymentDate2 { get; set; }
        public Nullable<int> PaymentAmount2 { get; set; }
        public Nullable<int> OldBal { get; set; }
        public Nullable<int> Monthcharge { get; set; }
        public Nullable<int> Balance { get; set; }
        public string Bmonth { get; set; }
        public string Byear { get; set; }
        public string Status { get; set; }
        public string OperatorCode { get; set; }
        public string IMEINo { get; set; }
    }

}