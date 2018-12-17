namespace SkyCableApiAndroid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tenthdat : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblAdminRegistrations", "OperatorCode", c => c.String());
            AddColumn("dbo.tblAdminRegistrations", "IMEINo", c => c.String());
            AlterColumn("dbo.tblPackages", "Rate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tblPackages", "Rate", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.tblAdminRegistrations", "IMEINo");
            DropColumn("dbo.tblAdminRegistrations", "OperatorCode");
        }
    }
}
