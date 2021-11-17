namespace SilverScreenRelics.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArtItem",
                c => new
                    {
                        ArtItemId = c.Int(nullable: false, identity: true),
                        ArtItemTitle = c.String(nullable: false),
                        ArtItemDescription = c.String(nullable: false),
                        ArtItemPrice = c.Double(nullable: false),
                        UserId = c.String(maxLength: 128),
                        IsActive = c.Boolean(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                        ArtItem_ArtItemId = c.Int(),
                    })
                .PrimaryKey(t => t.ArtItemId)
                .ForeignKey("dbo.ArtItem", t => t.ArtItem_ArtItemId)
                .ForeignKey("dbo.ApplicationUser", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.ArtItem_ArtItemId);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.Movie",
                c => new
                    {
                        MovieId = c.Int(nullable: false, identity: true),
                        MovieTitle = c.String(),
                        MovieReleaseYear = c.Int(nullable: false),
                        UserRating = c.Int(nullable: false),
                        ArtItemId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        Movie_MovieId = c.Int(),
                    })
                .PrimaryKey(t => t.MovieId)
                .ForeignKey("dbo.ArtItem", t => t.ArtItemId, cascadeDelete: true)
                .ForeignKey("dbo.Movie", t => t.Movie_MovieId)
                .ForeignKey("dbo.ApplicationUser", t => t.UserId)
                .Index(t => t.ArtItemId)
                .Index(t => t.UserId)
                .Index(t => t.Movie_MovieId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        ArtItemId = c.Int(nullable: false),
                        ArtItemPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionId)
                .ForeignKey("dbo.ArtItem", t => t.ArtItemId, cascadeDelete: true)
                .ForeignKey("dbo.ApplicationUser", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.ArtItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.Transactions", "ArtItemId", "dbo.ArtItem");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Movie", "UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.Movie", "Movie_MovieId", "dbo.Movie");
            DropForeignKey("dbo.Movie", "ArtItemId", "dbo.ArtItem");
            DropForeignKey("dbo.ArtItem", "UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.ArtItem", "ArtItem_ArtItemId", "dbo.ArtItem");
            DropIndex("dbo.Transactions", new[] { "ArtItemId" });
            DropIndex("dbo.Transactions", new[] { "UserId" });
            DropIndex("dbo.Movie", new[] { "Movie_MovieId" });
            DropIndex("dbo.Movie", new[] { "UserId" });
            DropIndex("dbo.Movie", new[] { "ArtItemId" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ArtItem", new[] { "ArtItem_ArtItemId" });
            DropIndex("dbo.ArtItem", new[] { "UserId" });
            DropTable("dbo.Transactions");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Movie");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.ArtItem");
        }
    }
}
