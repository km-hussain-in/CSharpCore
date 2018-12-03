using System;
using System.Linq;

namespace EFDBFirstTest2
{
	class Program
	{
		static void Main(string[] args)
		{
			int sid = int.Parse(args[0]);

			using(var db = new AppDbContext())
			{
				Site s = db.Sites.Find(sid);
				if(s != null)
				{
					Console.WriteLine(s.Name);
					foreach(var v in s.Visitors)
						Console.WriteLine($"{v.Id} visited on {v.Recent}");
				}
			}
		}
	}
}
