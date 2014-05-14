using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrowdSubMain.Models;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CrowdSubMain.DAL
{
	public class crowd_sub_context : IdentityDbContext<ApplicationUser>
	{
		public crowd_sub_context() : base("crowdbass"){ }
		public DbSet<request> requests { get; set; }
		public DbSet<subtitle> subtitles { get; set; }
		public DbSet<subtitle_comment> subtitle_comments { get; set; }
		public DbSet<upvote> upvotes { get; set; }
		public DbSet<video> videos { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			//configure relation mapping and foreign keys of request model
			modelBuilder.Entity<request>().HasRequired(r => r.user).WithMany(u => u.requests).HasForeignKey(r => r.request_user_id).WillCascadeOnDelete(false);
			modelBuilder.Entity<request>().HasRequired(r => r.video).WithMany(v => v.requests).HasForeignKey(r => r.request_video_id);

			//configure relation mapping and foreign keys of subtitle model
			modelBuilder.Entity<subtitle>().HasRequired(s => s.user).WithMany(u => u.subtitles).HasForeignKey(s => s.subtitle_user_id).WillCascadeOnDelete(false);
			modelBuilder.Entity<subtitle>().HasRequired(s => s.video).WithMany(v => v.subtitles).HasForeignKey(s => s.subtitle_video_id);

			//configure relation mapping and foreign keys of subtitle comment model
			modelBuilder.Entity<subtitle_comment>().HasRequired(sc => sc.user).WithMany(u => u.subtitle_comments).HasForeignKey(sc => sc.sc_user_id).WillCascadeOnDelete(false);
			modelBuilder.Entity<subtitle_comment>().HasRequired(sc => sc.subtitle).WithMany(s => s.subtitle_comments).HasForeignKey(sc => sc.sc_sub_id);

			//configure relation mapping and foreign keys of upvote model
			modelBuilder.Entity<upvote>().HasRequired(up => up.user).WithMany(u => u.upvotes).HasForeignKey(up => up.upvote_user_id).WillCascadeOnDelete(false);
			modelBuilder.Entity<upvote>().HasRequired(up => up.request).WithMany(r => r.upvotes).HasForeignKey(up => up.upvote_request_id);

			//configure relation mapping and foreign keys of video model
			modelBuilder.Entity<video>().HasRequired(v => v.user).WithMany(u => u.videos).HasForeignKey(v => v.video_created_by_user_id).WillCascadeOnDelete(false);
		}
	}
}