namespace CrowdSubMain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.requests",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        request_user_id = c.Int(nullable: false),
                        request_lang = c.Int(nullable: false),
                        request_video_id = c.Int(nullable: false),
                        request_date_created = c.DateTime(nullable: false),
                        user_Id = c.String(maxLength: 128),
                        video_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.AspNetUsers", t => t.user_Id)
                .ForeignKey("dbo.videos", t => t.video_id)
                .Index(t => t.user_Id)
                .Index(t => t.video_id);
            
            CreateTable(
                "dbo.upvotes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        upvote_request_id = c.Int(),
                        upvote_user_id = c.Int(),
                        upvote_date_create = c.DateTime(nullable: false),
                        request_id = c.Int(),
                        user_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.requests", t => t.request_id)
                .ForeignKey("dbo.AspNetUsers", t => t.user_Id)
                .Index(t => t.request_id)
                .Index(t => t.user_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.videos",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        video_created_by_user_id = c.Int(nullable: false),
                        video_title = c.String(),
                        video_type = c.Int(nullable: false),
                        video_year_published = c.Int(nullable: false),
                        video_date_created = c.DateTime(nullable: false),
                        video_date_updated = c.DateTime(nullable: false),
                        video_description = c.String(),
                        user_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.AspNetUsers", t => t.user_Id)
                .Index(t => t.user_Id);
            
            CreateTable(
                "dbo.subtitles",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        subtitle_user_id = c.Int(nullable: false),
                        subtitle_video_id = c.Int(nullable: false),
                        subtitle_file_path = c.String(),
                        subtitle_date_created = c.DateTime(nullable: false),
                        subtitle_download_count = c.Int(nullable: false),
                        subtitle_language = c.Int(nullable: false),
                        user_Id = c.String(maxLength: 128),
                        video_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.AspNetUsers", t => t.user_Id)
                .ForeignKey("dbo.videos", t => t.video_id)
                .Index(t => t.user_Id)
                .Index(t => t.video_id);
            
            CreateTable(
                "dbo.subtitle_comment",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        sc_user_id = c.Int(nullable: false),
                        sc_sub_id = c.Int(nullable: false),
                        sc_comment = c.String(),
                        sc_date_created = c.DateTime(nullable: false),
                        subtitle_id = c.Int(),
                        user_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.subtitles", t => t.subtitle_id)
                .ForeignKey("dbo.AspNetUsers", t => t.user_Id)
                .Index(t => t.subtitle_id)
                .Index(t => t.user_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.videos", "user_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.subtitles", "video_id", "dbo.videos");
            DropForeignKey("dbo.subtitles", "user_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.subtitle_comment", "user_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.subtitle_comment", "subtitle_id", "dbo.subtitles");
            DropForeignKey("dbo.requests", "video_id", "dbo.videos");
            DropForeignKey("dbo.requests", "user_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.upvotes", "user_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.upvotes", "request_id", "dbo.requests");
            DropIndex("dbo.videos", new[] { "user_Id" });
            DropIndex("dbo.subtitles", new[] { "video_id" });
            DropIndex("dbo.subtitles", new[] { "user_Id" });
            DropIndex("dbo.subtitle_comment", new[] { "user_Id" });
            DropIndex("dbo.subtitle_comment", new[] { "subtitle_id" });
            DropIndex("dbo.requests", new[] { "video_id" });
            DropIndex("dbo.requests", new[] { "user_Id" });
            DropIndex("dbo.upvotes", new[] { "user_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "User_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.upvotes", new[] { "request_id" });
            DropTable("dbo.subtitle_comment");
            DropTable("dbo.subtitles");
            DropTable("dbo.videos");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.upvotes");
            DropTable("dbo.requests");
        }
    }
}
