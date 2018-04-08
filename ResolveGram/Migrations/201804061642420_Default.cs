namespace ResolveGram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Default : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountID = c.Long(nullable: false, identity: true),
                        Email = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        LastSeen = c.DateTime(),
                        Rating = c.Short(),
                        Code = c.Guid(),
                        YouTubeCode = c.String(),
                    })
                .PrimaryKey(t => t.AccountID);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        TaskID = c.Long(nullable: false, identity: true),
                        TaskTitle = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        HasReminder = c.Boolean(nullable: false),
                        ShowHomePage = c.Boolean(nullable: false),
                        Notes = c.String(),
                        CategoryID = c.Byte(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        TimeStamp = c.Binary(),
                        AccountID = c.Long(nullable: false),
                        IsComplete = c.Boolean(nullable: false),
                        PriorityID = c.Byte(),
                        AssignTo = c.String(),
                        Code = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.TaskID)
                .ForeignKey("dbo.Accounts", t => t.AccountID, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Priorities", t => t.PriorityID)
                .Index(t => t.CategoryID)
                .Index(t => t.AccountID)
                .Index(t => t.PriorityID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Priorities",
                c => new
                    {
                        PriorityID = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.PriorityID);
            
            CreateTable(
                "dbo.SubTasks",
                c => new
                    {
                        SubTaskID = c.Long(nullable: false, identity: true),
                        TaskID = c.Int(nullable: false),
                        Title = c.String(),
                        Notes = c.String(),
                        DueDate = c.DateTime(nullable: false),
                        IsComplete = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        AssignedTo = c.String(),
                        Code = c.Guid(nullable: false),
                        Task_TaskID = c.Long(),
                    })
                .PrimaryKey(t => t.SubTaskID)
                .ForeignKey("dbo.Tasks", t => t.Task_TaskID)
                .Index(t => t.Task_TaskID);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        NotificationID = c.Long(nullable: false, identity: true),
                        Message = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                        AccountID = c.Long(nullable: false),
                        Icon = c.String(),
                        CssClass = c.String(),
                    })
                .PrimaryKey(t => t.NotificationID)
                .ForeignKey("dbo.Accounts", t => t.AccountID, cascadeDelete: true)
                .Index(t => t.AccountID);
            
            CreateTable(
                "dbo.Organisations",
                c => new
                    {
                        OrganisationID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        DateCreated = c.DateTime(),
                        IsActive = c.Boolean(),
                        StaffNo = c.Int(),
                    })
                .PrimaryKey(t => t.OrganisationID);
            
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
                        Account_AccountID = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.Account_AccountID)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.Account_AccountID);
            
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
            DropForeignKey("dbo.AspNetUsers", "Account_AccountID", "dbo.Accounts");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Notifications", "AccountID", "dbo.Accounts");
            DropForeignKey("dbo.SubTasks", "Task_TaskID", "dbo.Tasks");
            DropForeignKey("dbo.Tasks", "PriorityID", "dbo.Priorities");
            DropForeignKey("dbo.Tasks", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Tasks", "AccountID", "dbo.Accounts");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "Account_AccountID" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Notifications", new[] { "AccountID" });
            DropIndex("dbo.SubTasks", new[] { "Task_TaskID" });
            DropIndex("dbo.Tasks", new[] { "PriorityID" });
            DropIndex("dbo.Tasks", new[] { "AccountID" });
            DropIndex("dbo.Tasks", new[] { "CategoryID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Organisations");
            DropTable("dbo.Notifications");
            DropTable("dbo.SubTasks");
            DropTable("dbo.Priorities");
            DropTable("dbo.Categories");
            DropTable("dbo.Tasks");
            DropTable("dbo.Accounts");
        }
    }
}
