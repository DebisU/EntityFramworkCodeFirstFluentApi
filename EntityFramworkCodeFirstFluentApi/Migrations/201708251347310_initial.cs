namespace EntityFramworkCodeFirstFluentApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.books",
                c => new
                    {
                        BookID = c.Int(nullable: false, identity: true),
                        BookName = c.String(unicode: false),
                        ISBN = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.BookID);
            
            CreateTable(
                "dbo.review",
                c => new
                    {
                        ReviewID = c.Int(nullable: false, identity: true),
                        BookID = c.Int(nullable: false),
                        ReviewText = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ReviewID)
                .ForeignKey("dbo.books", t => t.BookID, cascadeDelete: true)
                .Index(t => t.BookID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.review", "BookID", "dbo.books");
            DropIndex("dbo.review", new[] { "BookID" });
            DropTable("dbo.review");
            DropTable("dbo.books");
        }
    }
}
