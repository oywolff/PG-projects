namespace Kampanjer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nyversjon : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ItemKeywords", "VendorItemNo", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.ItemKeywords", "ItemNo", c => c.String());
            AlterColumn("dbo.Keywords", "KeywordName", c => c.String(nullable: false, maxLength: 30));
            DropColumn("dbo.ItemKeywords", "ItemKeywordName");
            DropColumn("dbo.ItemKeywords", "Description");
            DropColumn("dbo.Keywords", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Keywords", "Description", c => c.String());
            AddColumn("dbo.ItemKeywords", "Description", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.ItemKeywords", "ItemKeywordName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Keywords", "KeywordName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.ItemKeywords", "ItemNo", c => c.Int(nullable: false));
            DropColumn("dbo.ItemKeywords", "VendorItemNo");
        }
    }
}
