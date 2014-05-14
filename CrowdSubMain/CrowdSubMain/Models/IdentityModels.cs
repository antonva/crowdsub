using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace CrowdSubMain.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
		public virtual ICollection<video> videos { get; set; }
		public virtual ICollection<upvote> upvotes { get; set; }
		public virtual ICollection<subtitle_comment> subtitle_comments { get; set; }
		public virtual ICollection<subtitle> subtitles { get; set; }
		public virtual ICollection<request> requests { get; set; }
    }

    /* public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("crowdbase")
        {
        }

        public System.Data.Entity.DbSet<CrowdSubMain.Models.request> requests { get; set; }

		public System.Data.Entity.DbSet<CrowdSubMain.Models.subtitle> subtitles { get; set; }

		public System.Data.Entity.DbSet<CrowdSubMain.Models.video> videos { get; set; }
    } */
}