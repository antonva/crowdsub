using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CrowdSubMain.Models;

namespace CrowdSubMain.DAL
{
	public class crowd_sub_initializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<crowd_sub_context>
	{
		protected override void Seed(crowd_sub_context context)
		{
			var requests = new List<request>
			{
				new request
				{
					request_user_id = 1.ToString(),
					request_lang = (language)0,
					request_video_id = 1,
					request_date_created = DateTime.Now
				},
				new request
				{
					request_user_id = 1.ToString(),
					request_lang = (language)0,
					request_video_id = 2,
					request_date_created = DateTime.Now
				},
				new request
				{
					request_user_id = 2.ToString(),
					request_lang = (language)1,
					request_video_id = 2,
					request_date_created = DateTime.Now
				}
			};
			requests.ForEach(r => context.requests.Add(r));
			context.SaveChanges();
			var subtitles = new List<subtitle>
			{
				new subtitle
				{
					subtitle_user_id = 1.ToString(),
					subtitle_video_id = 1,
					subtitle_file_path = "c:/filepath1",
					subtitle_date_created = DateTime.Now,
					subtitle_download_count = 0,
					subtitle_language = (language)0
				},
				new subtitle
				{
					subtitle_user_id = 2.ToString(),
					subtitle_video_id = 2,
					subtitle_file_path = "c:/filepath",
					subtitle_date_created = DateTime.Now,
					subtitle_download_count = 0,
					subtitle_language = (language)0
				},
				new subtitle
				{
					subtitle_user_id = 3.ToString(),
					subtitle_video_id = 3,
					subtitle_file_path = "c:/filepath",
					subtitle_date_created = DateTime.Now,
					subtitle_download_count = 0,
					subtitle_language = (language)0
				}
			};
			subtitles.ForEach(s => context.subtitles.Add(s));
			context.SaveChanges();

			var subtitle_comments = new List<subtitle_comment>
			{
				new subtitle_comment
				{
					sc_user_id = 1.ToString(),
					sc_sub_id = 1,
					sc_comment = "Wow this is a great subtitle",
					sc_date_created = DateTime.Now
				},
				new subtitle_comment
				{
					sc_user_id = 2.ToString(),
					sc_sub_id = 2,
					sc_comment = "Horrible subtitle",
					sc_date_created = DateTime.Now
				},
				new subtitle_comment
				{
					sc_user_id = 3.ToString(),
					sc_sub_id = 3,
					sc_comment = "Good subtitle, i like",
					sc_date_created = DateTime.Now
				}
			};
			subtitle_comments.ForEach(s => context.subtitle_comments.Add(s));
			context.SaveChanges();

			var videos = new List<video> 
			{
				new video
				{
					video_created_by_user_id = 1.ToString(),
					video_title = "Bartman",
					video_type = (vidtype)0,
					video_year_published = 2001,
					video_date_created = DateTime.Now,
					video_date_updated = DateTime.Now,
					video_description = "Geðveikt fínn gaur"
				},

				new video
				{
					video_created_by_user_id = 2.ToString(),
					video_title = "Gorillaz",
					video_type = (vidtype)1,
					video_year_published = 2011,
					video_date_created = DateTime.Now,
					video_date_updated = DateTime.Now,
					video_description = "Massa Leiðinlegur gaur"
				},

				new video
				{
					video_created_by_user_id = 3.ToString(),
					video_title = "Aint it great to shart",
					video_type = (vidtype)0,
					video_year_published = 1995,
					video_date_created = DateTime.Now,
					video_date_updated = DateTime.Now,
					video_description = "Fokk Nei, maður"
				}
			};

			videos.ForEach(s => context.videos.Add(s));
			context.SaveChanges();

			var upvotes = new List<upvote>
			{
				new upvote
				{
					upvote_request_id = 1,
					upvote_user_id = 1.ToString(),
					upvote_date_create = DateTime.Now
				},

				new upvote
				{
					upvote_request_id = 2,
					upvote_user_id = 2.ToString(),
					upvote_date_create = DateTime.Now
				},

				new upvote
				{
					upvote_request_id = 3,
					upvote_user_id = 3.ToString(),
					upvote_date_create = DateTime.Now
				}
			}; 

			upvotes.ForEach(s => context.upvotes.Add(s));
			context.SaveChanges();
		}
	}
}