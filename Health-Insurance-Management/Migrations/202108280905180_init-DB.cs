namespace Health_Insurance_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompanyDetails",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false),
                        CompanyAddress = c.String(nullable: false),
                        CompanyPhone = c.String(nullable: false),
                        CompanyURL = c.String(),
                        Status = c.Byte(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        PolicyId = c.Int(nullable: false),
                        EmployeeName = c.String(nullable: false),
                        Designation = c.String(),
                        JoinDate = c.DateTime(nullable: false),
                        Salary = c.Double(nullable: false),
                        EmployeeAddress = c.String(),
                        EmployeePhone = c.String(),
                        Status = c.Byte(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Policies", t => t.PolicyId, cascadeDelete: true)
                .Index(t => t.PolicyId);
            
            CreateTable(
                "dbo.Policies",
                c => new
                    {
                        PolicyId = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(nullable: false),
                        PolicyName = c.String(nullable: false),
                        PolicyDescription = c.String(),
                        Amount = c.Double(nullable: false),
                        Emi = c.Double(nullable: false),
                        MedicalId = c.String(nullable: false),
                        Status = c.Byte(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.PolicyId)
                .ForeignKey("dbo.CompanyDetails", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.HospitalInfoes",
                c => new
                    {
                        HospitalId = c.Int(nullable: false, identity: true),
                        HospitalName = c.String(nullable: false),
                        HospitalPhone = c.String(nullable: false),
                        HospitalAddress = c.String(nullable: false),
                        HospitalURL = c.String(),
                        Status = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.HospitalId);
            
            CreateTable(
                "dbo.PolicyApprovalDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PolicyId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Reason = c.String(nullable: false),
                        Status = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Policies", t => t.PolicyId, cascadeDelete: true)
                .Index(t => t.PolicyId);
            
            CreateTable(
                "dbo.PolicyOnEmployees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        PolicyId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: false)
                .ForeignKey("dbo.Policies", t => t.PolicyId, cascadeDelete: false)
                .Index(t => t.EmployeeId)
                .Index(t => t.PolicyId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PolicyOnEmployees", "PolicyId", "dbo.Policies");
            DropForeignKey("dbo.PolicyOnEmployees", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.PolicyApprovalDetails", "PolicyId", "dbo.Policies");
            DropForeignKey("dbo.Employees", "PolicyId", "dbo.Policies");
            DropForeignKey("dbo.Policies", "CompanyId", "dbo.CompanyDetails");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PolicyOnEmployees", new[] { "PolicyId" });
            DropIndex("dbo.PolicyOnEmployees", new[] { "EmployeeId" });
            DropIndex("dbo.PolicyApprovalDetails", new[] { "PolicyId" });
            DropIndex("dbo.Policies", new[] { "CompanyId" });
            DropIndex("dbo.Employees", new[] { "PolicyId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PolicyOnEmployees");
            DropTable("dbo.PolicyApprovalDetails");
            DropTable("dbo.HospitalInfoes");
            DropTable("dbo.Policies");
            DropTable("dbo.Employees");
            DropTable("dbo.CompanyDetails");
        }
    }
}
