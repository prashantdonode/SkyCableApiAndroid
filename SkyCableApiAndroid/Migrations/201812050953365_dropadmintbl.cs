namespace SkyCableApiAndroid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropadmintbl : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tblAdminRegistrations", "OperatorCode");
            DropColumn("dbo.tblAdminRegistrations", "IMEINo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tblAdminRegistrations", "IMEINo", c => c.String());
            AddColumn("dbo.tblAdminRegistrations", "OperatorCode", c => c.String());
        }
    }
}
