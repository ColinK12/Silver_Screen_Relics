namespace SilverScreenRelics.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitCommit : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AspNetRoles", newName: "IdentityRole");
            RenameTable(name: "dbo.AspNetUserRoles", newName: "IdentityUserRole");
            RenameTable(name: "dbo.AspNetUsers", newName: "ApplicationUser");
            RenameTable(name: "dbo.AspNetUserClaims", newName: "IdentityUserClaim");
            RenameTable(name: "dbo.AspNetUserLogins", newName: "IdentityUserLogin");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.IdentityRole", "RoleNameIndex");
            DropIndex("dbo.IdentityUserRole", new[] { "UserId" });
            DropIndex("dbo.IdentityUserRole", new[] { "RoleId" });
            DropIndex("dbo.ApplicationUser", "UserNameIndex");
            DropIndex("dbo.IdentityUserClaim", new[] { "UserId" });
            DropIndex("dbo.IdentityUserLogin", new[] { "UserId" });
            DropPrimaryKey("dbo.AspNetUserRoles");
            DropPrimaryKey("dbo.AspNetUserLogins");
            CreateTable(
                "dbo.ArtItem",
                c => new
                    {
                        ArtItemId = c.Int(nullable: false, identity: true),
                        ArtItemTitle = c.String(nullable: false),
                        ArtItemDescription = c.String(nullable: false),
                        ArtItemPrice = c.Double(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                        ArtItem_ArtItemId = c.Int(),
                    })
                .PrimaryKey(t => t.ArtItemId)
                .ForeignKey("dbo.ArtItem", t => t.ArtItem_ArtItemId)
                .Index(t => t.ArtItem_ArtItemId);
            
            CreateTable(
                "dbo.Movie",
                c => new
                    {
                        MovieId = c.Int(nullable: false, identity: true),
                        MovieTitle = c.String(),
                        MovieReleaseYear = c.Int(nullable: false),
                        UserRating = c.Int(nullable: false),
                        ArtItemId = c.Int(nullable: false),
                        Movie_MovieId = c.Int(),
                    })
                .PrimaryKey(t => t.MovieId)
                .ForeignKey("dbo.ArtItem", t => t.ArtItemId, cascadeDelete: true)
                .ForeignKey("dbo.Movie", t => t.Movie_MovieId)
                .Index(t => t.ArtItemId)
                .Index(t => t.Movie_MovieId);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionId = c.Int(nullable: false, identity: true),
                        ArtItemId = c.Int(nullable: false),
                        ArtItemPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionId)
                .ForeignKey("dbo.ArtItem", t => t.ArtItemId, cascadeDelete: true)
                .Index(t => t.ArtItemId);
            
            AddColumn("dbo.IdentityUserRole", "IdentityRole_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.IdentityUserRole", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.IdentityUserClaim", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.IdentityUserLogin", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.IdentityRole", "Name", c => c.String());
            AlterColumn("dbo.IdentityUserRole", "RoleId", c => c.String());
            AlterColumn("dbo.ApplicationUser", "Email", c => c.String());
            AlterColumn("dbo.ApplicationUser", "UserName", c => c.String());
            AlterColumn("dbo.IdentityUserClaim", "UserId", c => c.String());
            AlterColumn("dbo.IdentityUserLogin", "LoginProvider", c => c.String());
            AlterColumn("dbo.IdentityUserLogin", "ProviderKey", c => c.String());
            AddPrimaryKey("dbo.IdentityUserRole", "UserId");
            AddPrimaryKey("dbo.IdentityUserLogin", "UserId");
            CreateIndex("dbo.IdentityUserRole", "IdentityRole_Id");
            CreateIndex("dbo.IdentityUserRole", "ApplicationUser_Id");
            CreateIndex("dbo.IdentityUserClaim", "ApplicationUser_Id");
            CreateIndex("dbo.IdentityUserLogin", "ApplicationUser_Id");
            AddForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole", "Id");
            AddForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser", "Id");
            AddForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser", "Id");
            AddForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Transactions", "ArtItemId", "dbo.ArtItem");
            DropForeignKey("dbo.Movie", "Movie_MovieId", "dbo.Movie");
            DropForeignKey("dbo.Movie", "ArtItemId", "dbo.ArtItem");
            DropForeignKey("dbo.ArtItem", "ArtItem_ArtItemId", "dbo.ArtItem");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Transactions", new[] { "ArtItemId" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Movie", new[] { "Movie_MovieId" });
            DropIndex("dbo.Movie", new[] { "ArtItemId" });
            DropIndex("dbo.ArtItem", new[] { "ArtItem_ArtItemId" });
            DropPrimaryKey("dbo.IdentityUserLogin");
            DropPrimaryKey("dbo.IdentityUserRole");
            AlterColumn("dbo.IdentityUserLogin", "ProviderKey", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.IdentityUserLogin", "LoginProvider", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.IdentityUserClaim", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.ApplicationUser", "UserName", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.ApplicationUser", "Email", c => c.String(maxLength: 256));
            AlterColumn("dbo.IdentityUserRole", "RoleId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.IdentityRole", "Name", c => c.String(nullable: false, maxLength: 256));
            DropColumn("dbo.IdentityUserLogin", "ApplicationUser_Id");
            DropColumn("dbo.IdentityUserClaim", "ApplicationUser_Id");
            DropColumn("dbo.IdentityUserRole", "ApplicationUser_Id");
            DropColumn("dbo.IdentityUserRole", "IdentityRole_Id");
            DropTable("dbo.Transactions");
            DropTable("dbo.Movie");
            DropTable("dbo.ArtItem");
            AddPrimaryKey("dbo.AspNetUserLogins", new[] { "LoginProvider", "ProviderKey", "UserId" });
            AddPrimaryKey("dbo.AspNetUserRoles", new[] { "UserId", "RoleId" });
            CreateIndex("dbo.IdentityUserLogin", "UserId");
            CreateIndex("dbo.IdentityUserClaim", "UserId");
            CreateIndex("dbo.ApplicationUser", "UserName", unique: true, name: "UserNameIndex");
            CreateIndex("dbo.IdentityUserRole", "RoleId");
            CreateIndex("dbo.IdentityUserRole", "UserId");
            CreateIndex("dbo.IdentityRole", "Name", unique: true, name: "RoleNameIndex");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.IdentityUserLogin", newName: "AspNetUserLogins");
            RenameTable(name: "dbo.IdentityUserClaim", newName: "AspNetUserClaims");
            RenameTable(name: "dbo.ApplicationUser", newName: "AspNetUsers");
            RenameTable(name: "dbo.IdentityUserRole", newName: "AspNetUserRoles");
            RenameTable(name: "dbo.IdentityRole", newName: "AspNetRoles");
        }
    }
}
