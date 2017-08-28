namespace EntityFramworkCodeFirstFluentApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class libraries : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.library",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        address = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.books", "Library_Id", c => c.Int());
            CreateIndex("dbo.books", "Library_Id");
            AddForeignKey("dbo.books", "Library_Id", "dbo.library", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.books", "Library_Id", "dbo.library");
            DropIndex("dbo.books", new[] { "Library_Id" });
            DropColumn("dbo.books", "Library_Id");
            DropTable("dbo.library");
        }
    }
}
