namespace SkyCableApiAndroid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sixthdata : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblCustomerRegistrations", "OldBal", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblCustomerRegistrations", "OldBal");
        }
    }
}
