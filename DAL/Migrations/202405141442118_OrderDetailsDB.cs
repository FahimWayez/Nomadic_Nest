namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderDetailsDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "service_id", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderDetails", "service_id");
            AddForeignKey("dbo.OrderDetails", "service_id", "dbo.Services", "service_id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "service_id", "dbo.Services");
            DropIndex("dbo.OrderDetails", new[] { "service_id" });
            DropColumn("dbo.OrderDetails", "service_id");
        }
    }
}
