namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        user_id = c.Int(nullable: false, identity: true),
                        user_name = c.String(nullable: false),
                        user_email = c.String(nullable: false),
                        user_password = c.String(nullable: false),
                        user_phone_number = c.String(),
                        user_gender = c.String(nullable: false),
                        user_city = c.String(nullable: false),
                        user_state_name = c.String(nullable: false),
                        user_country = c.String(nullable: false),
                        role = c.String(),
                    })
                .PrimaryKey(t => t.user_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
