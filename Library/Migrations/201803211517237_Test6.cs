namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "OrderBooksId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Order", "OrderBooksId");
        }
    }
}
