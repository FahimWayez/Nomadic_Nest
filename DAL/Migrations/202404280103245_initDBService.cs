namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDBService : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        service_id = c.Int(nullable: false, identity: true),
                        service_description = c.String(nullable: false),
                        service_title = c.String(nullable: false),
                        service_location_to = c.String(),
                        service_location_from = c.String(nullable: false),
                        service_value = c.Single(nullable: false),
                        service_status = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.service_id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Services", "UserId", "dbo.Users");
            DropIndex("dbo.Services", new[] { "UserId" });
            DropTable("dbo.Services");
        }
    }
}
