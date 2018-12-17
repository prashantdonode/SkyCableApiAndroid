namespace SkyCableApiAndroid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eleventhdata : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tblBills", "OldBal", c => c.Int());
            AlterColumn("dbo.tblBills", "Monthcharge", c => c.Int());
            AlterColumn("dbo.tblBills", "Balance", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tblBills", "Balance", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.tblBills", "Monthcharge", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.tblBills", "OldBal", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}
