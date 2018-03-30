namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Order", "OrderBooksId", "dbo.OrderBooks");
            DropIndex("dbo.Order", new[] { "OrderBooksId" });
            CreateTable(
                "dbo.OrderBooksOrder",
                c => new
                    {
                        OrderBooks_OrderBooksId = c.Int(nullable: false),
                        Order_OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderBooks_OrderBooksId, t.Order_OrderId })
                .ForeignKey("dbo.OrderBooks", t => t.OrderBooks_OrderBooksId, cascadeDelete: true)
                .ForeignKey("dbo.Order", t => t.Order_OrderId, cascadeDelete: true)
                .Index(t => t.OrderBooks_OrderBooksId)
                .Index(t => t.Order_OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderBooksOrder", "Order_OrderId", "dbo.Order");
            DropForeignKey("dbo.OrderBooksOrder", "OrderBooks_OrderBooksId", "dbo.OrderBooks");
            DropIndex("dbo.OrderBooksOrder", new[] { "Order_OrderId" });
            DropIndex("dbo.OrderBooksOrder", new[] { "OrderBooks_OrderBooksId" });
            DropTable("dbo.OrderBooksOrder");
            CreateIndex("dbo.Order", "OrderBooksId");
            AddForeignKey("dbo.Order", "OrderBooksId", "dbo.OrderBooks", "OrderBooksId", cascadeDelete: true);
        }
    }
}
