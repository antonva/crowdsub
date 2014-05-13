namespace CrowdSubMain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.requests", "request_user_id", c => c.String());
            AlterColumn("dbo.upvotes", "upvote_request_id", c => c.Int(nullable: false));
            AlterColumn("dbo.upvotes", "upvote_user_id", c => c.String());
            AlterColumn("dbo.videos", "video_created_by_user_id", c => c.String());
            AlterColumn("dbo.subtitles", "subtitle_user_id", c => c.String());
            AlterColumn("dbo.subtitle_comment", "sc_user_id", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.subtitle_comment", "sc_user_id", c => c.Int(nullable: false));
            AlterColumn("dbo.subtitles", "subtitle_user_id", c => c.Int(nullable: false));
            AlterColumn("dbo.videos", "video_created_by_user_id", c => c.Int(nullable: false));
            AlterColumn("dbo.upvotes", "upvote_user_id", c => c.Int());
            AlterColumn("dbo.upvotes", "upvote_request_id", c => c.Int());
            AlterColumn("dbo.requests", "request_user_id", c => c.Int(nullable: false));
        }
    }
}
