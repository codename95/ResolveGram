namespace ResolveGram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Email_Text : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TaskLists", "SendEmail", c => c.Boolean(nullable: false));
            AddColumn("dbo.TaskLists", "SendTextMessage", c => c.Boolean(nullable: false));
            DropColumn("dbo.TaskLists", "HasReminder");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TaskLists", "HasReminder", c => c.Boolean(nullable: false));
            DropColumn("dbo.TaskLists", "SendTextMessage");
            DropColumn("dbo.TaskLists", "SendEmail");
        }
    }
}
