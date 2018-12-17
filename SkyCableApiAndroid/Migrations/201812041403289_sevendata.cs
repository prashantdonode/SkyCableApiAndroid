namespace SkyCableApiAndroid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sevendata : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblAdminRegistrations", "OperatorCode", c => c.String());
            AddColumn("dbo.tblAdminRegistrations", "IMEINo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblAdminRegistrations", "IMEINo");
            DropColumn("dbo.tblAdminRegistrations", "OperatorCode");
        }
    }
}
