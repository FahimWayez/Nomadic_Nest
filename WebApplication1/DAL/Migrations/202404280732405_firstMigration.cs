namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        comment_Id = c.Int(nullable: false, identity: true),
                        comment = c.String(nullable: false),
                        comment_created = c.DateTime(nullable: false),
                        PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.comment_Id)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        post_id = c.Int(nullable: false, identity: true),
                        post_description = c.String(nullable: false),
                        post_title = c.String(),
                        post_location = c.String(nullable: false),
                        post_created = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.post_id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
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
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        order_Id = c.Int(nullable: false, identity: true),
                        order_created = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.order_Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
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
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Posts", "UserId", "dbo.Users");
            DropIndex("dbo.Services", new[] { "UserId" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.Posts", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "PostId" });
            DropTable("dbo.Services");
            DropTable("dbo.Orders");
            DropTable("dbo.Users");
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
        }
    }
}
