namespace SilverScreenRelics.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ArtItem", "ArtItem_ArtItemId", "dbo.ArtItem");
            DropIndex("dbo.ArtItem", new[] { "ArtItem_ArtItemId" });
            DropColumn("dbo.ArtItem", "ArtItem_ArtItemId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ArtItem", "ArtItem_ArtItemId", c => c.Int());
            CreateIndex("dbo.ArtItem", "ArtItem_ArtItemId");
            AddForeignKey("dbo.ArtItem", "ArtItem_ArtItemId", "dbo.ArtItem", "ArtItemId");
        }
    }
}
