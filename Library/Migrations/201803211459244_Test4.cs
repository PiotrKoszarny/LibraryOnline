namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderBooksOrder", "OrderBooks_OrderBooksId", "dbo.OrderBooks");
            DropForeignKey("dbo.OrderBooksOrder", "Order_OrderId", "dbo.Order");
            DropIndex("dbo.OrderBooksOrder", new[] { "OrderBooks_OrderBooksId" });
            DropIndex("dbo.OrderBooksOrder", new[] { "Order_OrderId" });
            CreateIndex("dbo.OrderBooks", "OrderId");
            AddForeignKey("dbo.OrderBooks", "OrderId", "dbo.Order", "OrderId", cascadeDelete: true);
            DropTable("dbo.OrderBooksOrder");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OrderBooksOrder",
                c => new
                    {
                        OrderBooks_OrderBooksId = c.Int(nullable: false),
                        Order_OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderBooks_OrderBooksId, t.Order_OrderId });
            
            DropForeignKey("dbo.OrderBooks", "OrderId", "dbo.Order");
            DropIndex("dbo.OrderBooks", new[] { "OrderId" });
            CreateIndex("dbo.OrderBooksOrder", "Order_OrderId");
            CreateIndex("dbo.OrderBooksOrder", "OrderBooks_OrderBooksId");
            AddForeignKey("dbo.OrderBooksOrder", "Order_OrderId", "dbo.Order", "OrderId", cascadeDelete: true);
            AddForeignKey("dbo.OrderBooksOrder", "OrderBooks_OrderBooksId", "dbo.OrderBooks", "OrderBooksId", cascadeDelete: true);
        }
    }
}
