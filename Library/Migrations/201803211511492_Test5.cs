namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Order", "OrderDate", c => c.String());
            DropColumn("dbo.Order", "OrderBooksId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Order", "OrderBooksId", c => c.Int(nullable: false));
            AlterColumn("dbo.Order", "OrderDate", c => c.DateTime(nullable: false));
        }
    }
}
