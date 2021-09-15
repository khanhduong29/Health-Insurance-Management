namespace Health_Insurance_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newsb_v2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "EmloyeeId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "EmloyeeId");
        }
    }
}
