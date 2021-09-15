namespace Health_Insurance_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class role_v6 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.RoleViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RoleViewModels",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
