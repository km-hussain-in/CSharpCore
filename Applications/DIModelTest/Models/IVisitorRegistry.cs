using System.Collections.Generic;

namespace EFModelTest.Models
{
	public interface IVisitorRegistry
	{
		IEnumerable<Visitor> GetVisitors();

		void RegisterVisit(string name);
	}
}

