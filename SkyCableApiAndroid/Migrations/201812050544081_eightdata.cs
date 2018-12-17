namespace SkyCableApiAndroid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eightdata : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblAgents", "OperatorCode", c => c.String());
            AddColumn("dbo.tblAgents", "IMEINo", c => c.String());
            AddColumn("dbo.tblBills", "OperatorCode", c => c.String());
            AddColumn("dbo.tblBills", "IMEINo", c => c.String());
            AddColumn("dbo.tblCustomerRegistrations", "OperatorCode", c => c.String());
            AddColumn("dbo.tblCustomerRegistrations", "IMEINo", c => c.String());
            AddColumn("dbo.tblPackages", "OperatorCode", c => c.String());
            AddColumn("dbo.tblPackages", "IMEINo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblPackages", "IMEINo");
            DropColumn("dbo.tblPackages", "OperatorCode");
            DropColumn("dbo.tblCustomerRegistrations", "IMEINo");
            DropColumn("dbo.tblCustomerRegistrations", "OperatorCode");
            DropColumn("dbo.tblBills", "IMEINo");
            DropColumn("dbo.tblBills", "OperatorCode");
            DropColumn("dbo.tblAgents", "IMEINo");
            DropColumn("dbo.tblAgents", "OperatorCode");
        }
    }
}
