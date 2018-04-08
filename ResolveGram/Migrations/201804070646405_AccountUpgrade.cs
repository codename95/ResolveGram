namespace ResolveGram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccountUpgrade : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "FirstName", c => c.String());
            AddColumn("dbo.Accounts", "LastName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "LastName");
            DropColumn("dbo.Accounts", "FirstName");
        }
    }
}
