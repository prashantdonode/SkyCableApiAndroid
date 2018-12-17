namespace SkyCableApiAndroid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fifthdata : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tblAdminRegistrations", "SkyStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tblAdminRegistrations", "SkyStatus", c => c.String());
        }
    }
}
