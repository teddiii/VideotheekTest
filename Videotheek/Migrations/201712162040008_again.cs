namespace Videotheek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class again : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Users", new[] { "email" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Users", "email", unique: true);
        }
    }
}
