namespace Kampanjer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ContactId);
            
            CreateTable(
                "dbo.ItemKeywords",
                c => new
                    {
                        ItemKeywordID = c.Int(nullable: false, identity: true),
                        VendorItemNo = c.String(nullable: false, maxLength: 20),
                        ItemNo = c.String(),
                        KeywordID = c.Int(),
                    })
                .PrimaryKey(t => t.ItemKeywordID)
                .ForeignKey("dbo.Keywords", t => t.KeywordID)
                .Index(t => t.KeywordID);
            
            CreateTable(
                "dbo.Keywords",
                c => new
                    {
                        KeywordID = c.Int(nullable: false, identity: true),
                        KeywordName = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.KeywordID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemKeywords", "KeywordID", "dbo.Keywords");
            DropIndex("dbo.ItemKeywords", new[] { "KeywordID" });
            DropTable("dbo.Keywords");
            DropTable("dbo.ItemKeywords");
            DropTable("dbo.Contacts");
        }
    }
}
