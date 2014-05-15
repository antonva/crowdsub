using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrowdSubMain.Models;
using CrowdSubMain.DAL;
using System.Data.Entity;

namespace CrowdSubMain.Repositories
{
    public class subtitle_comment_repository : i_subtitle_comment_repository
    {
        private crowd_sub_context db = new crowd_sub_context();

        public IQueryable<subtitle_comment> get_subtitle_comments()
        {
            return db.subtitle_comments;
        }

        public void add(subtitle_comment subtitle_comment)
        {
            db.subtitle_comments.Add(subtitle_comment);
            db.SaveChanges();
        }

        public void edit(subtitle_comment subtitle_comment)
        {
            db.Entry(subtitle_comment).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void delete(subtitle_comment subtitle_comment)
        {
            db.subtitle_comments.Remove(subtitle_comment);
            db.SaveChanges();
        }
    }
}