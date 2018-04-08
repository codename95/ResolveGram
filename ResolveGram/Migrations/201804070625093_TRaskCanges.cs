namespace ResolveGram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TRaskCanges : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Tasks", newName: "TaskLists");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.TaskLists", newName: "Tasks");
        }
    }
}
