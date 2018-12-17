namespace SkyCableApiAndroid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstdata : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblAdminRegistrationModels",
                c => new
                    {
                        Aid = c.Int(nullable: false, identity: true),
                        RegId = c.Int(),
                        Name = c.String(),
                        Address = c.String(),
                        MobileNo = c.String(),
                        City = c.String(),
                        Email = c.String(),
                        UserId = c.String(),
                        Password = c.String(),
                        Pin = c.String(),
                        RegDate = c.DateTime(),
                        NoOfAgent = c.Int(),
                        SkyStatus = c.String(),
                    })
                .PrimaryKey(t => t.Aid);
            
            CreateTable(
                "dbo.tblAgentModels",
                c => new
                    {
                        Aid = c.Int(nullable: false, identity: true),
                        AgentId = c.Int(),
                        AgentName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Aid);
            
            CreateTable(
                "dbo.tblBillModels",
                c => new
                    {
                        Bid = c.Int(nullable: false, identity: true),
                        CustId = c.Int(),
                        CustName = c.String(),
                        Address = c.String(),
                        MobileNo = c.String(),
                        Area = c.String(),
                        NoOfBox = c.Int(),
                        SetupBox_Details = c.String(),
                        Package = c.String(),
                        RegistrationDate = c.DateTime(),
                        AgentName = c.String(),
                        PaymentDate1 = c.String(),
                        PaymentAmount1 = c.Int(),
                        PaymentDate2 = c.String(),
                        PaymentAmount2 = c.Int(),
                        OldBal = c.Decimal(precision: 18, scale: 2),
                        Monthcharge = c.Decimal(precision: 18, scale: 2),
                        Balance = c.Decimal(precision: 18, scale: 2),
                        Bmonth = c.String(),
                        Byear = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Bid);
            
            CreateTable(
                "dbo.tblCustomerRegistrationModels",
                c => new
                    {
                        CustId = c.Int(nullable: false, identity: true),
                        CustName = c.String(),
                        Address = c.String(),
                        MobileNo = c.String(),
                        Area = c.String(),
                        NoOfBox = c.Int(),
                        SetupBox_Details = c.String(),
                        Package = c.String(),
                        PackageRate = c.Int(),
                        RegistrationDate = c.DateTime(),
                        AgentName = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.CustId);
            
            CreateTable(
                "dbo.tblPackageModels",
                c => new
                    {
                        Pid = c.Int(nullable: false, identity: true),
                        PackageName = c.String(),
                        Rate = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Pid);
            
            CreateTable(
                "dbo.tblSkyVisionLoginModels",
                c => new
                    {
                        Sid = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        Password = c.String(),
                        RememberMe = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Sid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblSkyVisionLoginModels");
            DropTable("dbo.tblPackageModels");
            DropTable("dbo.tblCustomerRegistrationModels");
            DropTable("dbo.tblBillModels");
            DropTable("dbo.tblAgentModels");
            DropTable("dbo.tblAdminRegistrationModels");
        }
    }
}
