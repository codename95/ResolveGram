namespace ResolveGram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Default2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tasks", "TimeStamp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tasks", "TimeStamp", c => c.Binary());
        }
    }
}
