namespace OnlineBookManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Author_id = c.Int(nullable: false, identity: true),
                        Author_name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        bookType_id = c.Int(nullable: false),
                        Phone = c.String(nullable: false),
                        Author_password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Author_id)
                .ForeignKey("dbo.BookTypes", t => t.bookType_id, cascadeDelete: true)
                .Index(t => t.bookType_id);
            
            CreateTable(
                "dbo.BookTypes",
                c => new
                    {
                        bookType_id = c.Int(nullable: false, identity: true),
                        bookType_name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.bookType_id);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Book_id = c.Int(nullable: false, identity: true),
                        Book_name = c.String(nullable: false),
                        bookType_id = c.Int(nullable: false),
                        Author_id = c.Int(nullable: false),
                        Publisher_id = c.Int(nullable: false),
                        Publish_date = c.DateTime(nullable: false),
                        ISBN_no = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Book_id)
                .ForeignKey("dbo.Authors", t => t.Author_id)
                .ForeignKey("dbo.BookTypes", t => t.bookType_id)
                .ForeignKey("dbo.Publishers", t => t.Publisher_id)
                .Index(t => t.bookType_id)
                .Index(t => t.Author_id)
                .Index(t => t.Publisher_id);
            
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        Publisher_id = c.Int(nullable: false, identity: true),
                        Publisher_name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Publisher_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "Publisher_id", "dbo.Publishers");
            DropForeignKey("dbo.Books", "bookType_id", "dbo.BookTypes");
            DropForeignKey("dbo.Books", "Author_id", "dbo.Authors");
            DropForeignKey("dbo.Authors", "bookType_id", "dbo.BookTypes");
            DropIndex("dbo.Books", new[] { "Publisher_id" });
            DropIndex("dbo.Books", new[] { "Author_id" });
            DropIndex("dbo.Books", new[] { "bookType_id" });
            DropIndex("dbo.Authors", new[] { "bookType_id" });
            DropTable("dbo.Publishers");
            DropTable("dbo.Books");
            DropTable("dbo.BookTypes");
            DropTable("dbo.Authors");
        }
    }
}
