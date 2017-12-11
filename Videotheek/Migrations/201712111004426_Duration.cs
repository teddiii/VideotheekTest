namespace Videotheek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Duration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Duration (minutes)", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "genre", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "genre", c => c.String());
            DropColumn("dbo.Products", "Duration (minutes)");
        }
    }
}
