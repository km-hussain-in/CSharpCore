using System;
using System.Linq;

namespace EFDBFirstTest1
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
					db.Entry(s).Collection(e => e.Visitors).Load();
					foreach(var v in s.Visitors)
						Console.WriteLine($"{v.Id} visited on {v.Recent}");
				}
			}
		}
	}
}
