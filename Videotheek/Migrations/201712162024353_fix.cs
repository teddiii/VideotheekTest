namespace Videotheek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Users", new[] { "email" });
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "user_id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Users", "user_id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "user_id", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.Users", "user_id");
            CreateIndex("dbo.Users", "email", unique: true);
        }
    }
}
