using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CrowdSubCodeFirst.Models;

namespace CrowdSubCodeFirst.DAL
{
	public class crowd_sub_initializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<crowd_sub_context>
	{
		protected override void Seed(crowd_sub_context context)
		{
			var requests = new List<request>
			{
				new request
				{
					id = 1,
					request_user_id = 1,
					request_lang = 0,

				}
			}
		}
	}
}