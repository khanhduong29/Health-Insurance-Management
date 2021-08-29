namespace Health_Insurance_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_Table_PolicyOnEmployee : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PolicyOnEmployees", "Status", c => c.Byte(nullable: false));
            AlterColumn("dbo.PolicyOnEmployees", "UpdatedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PolicyOnEmployees", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PolicyOnEmployees", "Status", c => c.Int(nullable: false));
        }
    }
}
