namespace Health_Insurance_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newsb_v1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "EmployeeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "EmployeeId", c => c.Int(nullable: false));
        }
    }
}
