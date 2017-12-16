namespace Videotheek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Users : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        user_id = c.Guid(nullable: false),
                        firstname = c.String(name: "first name", nullable: false, maxLength: 255),
                        lastname = c.String(name: "last name", nullable: false, maxLength: 255),
                        user_name = c.String(nullable: false, maxLength: 50),
                        encrypted_pwd = c.String(nullable: false, maxLength: 255),
                        pwd_salt = c.String(maxLength: 255),
                        email = c.String(nullable: false, maxLength: 255),
                        created_at = c.DateTime(nullable: false),
                        modified_at = c.DateTime(nullable: false),
                        deleted_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.user_id)
                .Index(t => t.user_name, unique: true)
                .Index(t => t.email, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "email" });
            DropIndex("dbo.Users", new[] { "user_name" });
            DropTable("dbo.Users");
        }
    }
}
