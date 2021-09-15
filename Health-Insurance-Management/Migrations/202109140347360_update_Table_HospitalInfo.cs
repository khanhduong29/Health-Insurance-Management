namespace Health_Insurance_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_Table_HospitalInfo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HospitalInfoes", "Status", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HospitalInfoes", "Status", c => c.Int(nullable: false));
        }
    }
}
