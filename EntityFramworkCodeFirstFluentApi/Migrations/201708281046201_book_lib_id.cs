namespace EntityFramworkCodeFirstFluentApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class book_lib_id : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.books", "Library_Id", "dbo.library");
            DropIndex("dbo.books", new[] { "Library_Id" });
            AlterColumn("dbo.books", "Library_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.books", "Library_Id");
            AddForeignKey("dbo.books", "Library_Id", "dbo.library", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.books", "Library_Id", "dbo.library");
            DropIndex("dbo.books", new[] { "Library_Id" });
            AlterColumn("dbo.books", "Library_Id", c => c.Int());
            CreateIndex("dbo.books", "Library_Id");
            AddForeignKey("dbo.books", "Library_Id", "dbo.library", "Id");
        }
    }
}
