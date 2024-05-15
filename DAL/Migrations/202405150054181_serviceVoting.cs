namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class serviceVoting : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Services", "Votes", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Services", "Votes");
        }
    }
}
