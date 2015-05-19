namespace CMSProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        IdRole = c.Int(nullable: false),
                        role_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Role", t => t.role_ID)
                .Index(t => t.role_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "role_ID", "dbo.Role");
            DropIndex("dbo.User", new[] { "role_ID" });
            DropTable("dbo.User");
            DropTable("dbo.Role");
        }
    }
}
