namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        Author = c.String(),
                        Title = c.String(),
                        YearPublication = c.Int(nullable: false),
                        OrderBooks_OrderBooksId = c.Int(),
                        Order_OrderId = c.Int(),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("dbo.OrderBooks", t => t.OrderBooks_OrderBooksId)
                .ForeignKey("dbo.Order", t => t.Order_OrderId)
                .Index(t => t.OrderBooks_OrderBooksId)
                .Index(t => t.Order_OrderId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Book_BookId = c.Int(),
                    })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("dbo.Book", t => t.Book_BookId)
                .Index(t => t.Book_BookId);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        ReaderId = c.Int(nullable: false),
                        OrderBooksId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.OrderBooks", t => t.OrderBooksId, cascadeDelete: true)
                .ForeignKey("dbo.Reader", t => t.ReaderId, cascadeDelete: true)
                .Index(t => t.ReaderId)
                .Index(t => t.OrderBooksId);
            
            CreateTable(
                "dbo.OrderBooks",
                c => new
                    {
                        OrderBooksId = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderBooksId);
            
            CreateTable(
                "dbo.Reader",
                c => new
                    {
                        ReaderId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ReaderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Book", "Order_OrderId", "dbo.Order");
            DropForeignKey("dbo.Order", "ReaderId", "dbo.Reader");
            DropForeignKey("dbo.Order", "OrderBooksId", "dbo.OrderBooks");
            DropForeignKey("dbo.Book", "OrderBooks_OrderBooksId", "dbo.OrderBooks");
            DropForeignKey("dbo.Category", "Book_BookId", "dbo.Book");
            DropIndex("dbo.Order", new[] { "OrderBooksId" });
            DropIndex("dbo.Order", new[] { "ReaderId" });
            DropIndex("dbo.Category", new[] { "Book_BookId" });
            DropIndex("dbo.Book", new[] { "Order_OrderId" });
            DropIndex("dbo.Book", new[] { "OrderBooks_OrderBooksId" });
            DropTable("dbo.Reader");
            DropTable("dbo.OrderBooks");
            DropTable("dbo.Order");
            DropTable("dbo.Category");
            DropTable("dbo.Book");
        }
    }
}
