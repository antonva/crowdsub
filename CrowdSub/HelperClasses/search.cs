using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrowdSub.HelperClasses
{
	public class search
	{
		private static search the_instance = null;

		public static search instance //SINGLETON PATTERN
		{
			get
			{
				if(the_instance == null)
				{
					the_instance = new search();
				}
				return the_instance;
			}
		}

		//TODO: write function to search for video and another one to search for user
	}
}