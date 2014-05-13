using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrowdSubCodeFirst.Models;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;

namespace CrowdSubCodeFirst.DAL
{
	public class crowd_sub_context : DbContext
	{
		public crowd_sub_context : base("crowd_sub_context"){ }

		public DbSet<request> requests { get; set; }
		public DbSet<subtitle> subtitles { get; set; }
		public DbSet<subtitle_comment> subtitle_comments { get; set; }
		public DbSet<upvote> upvotes { get; set; }
		public DbSet<video> videos { get; set; }
	}
}