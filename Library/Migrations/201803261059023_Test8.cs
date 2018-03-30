namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reader", "Admin", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reader", "Admin");
        }
    }
}
