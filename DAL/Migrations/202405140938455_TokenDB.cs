namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TokenDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        TokenId = c.Int(nullable: false, identity: true),
                        TokenKey = c.String(nullable: false, maxLength: 100),
                        TokenCreate = c.DateTime(nullable: false),
                        TokenDestroy = c.DateTime(),
                        UserId = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TokenId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tokens");
        }
    }
}
