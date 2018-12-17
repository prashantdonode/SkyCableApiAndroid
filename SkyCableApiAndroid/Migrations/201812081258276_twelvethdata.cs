namespace SkyCableApiAndroid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class twelvethdata : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tblCustomerRegistrations", "OldBal", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tblCustomerRegistrations", "OldBal", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}
