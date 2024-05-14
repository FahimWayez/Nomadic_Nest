namespace DAL.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class c : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderDetails",
                c => new
                {
                    OrderDetailsId = c.Int(nullable: false, identity: true),
                    order_Id = c.Int(nullable: false),
                    service_id = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.OrderDetailsId)
                .ForeignKey("dbo.Services", t => t.service_id, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.order_Id, cascadeDelete: false)
                .Index(t => t.order_Id)
                .Index(t => t.service_id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "order_Id", "dbo.Orders");
            DropForeignKey("dbo.OrderDetails", "service_id", "dbo.Services");
            DropIndex("dbo.OrderDetails", new[] { "service_id" });
            DropIndex("dbo.OrderDetails", new[] { "order_Id" });
            DropTable("dbo.OrderDetails");
        }
    }
}
