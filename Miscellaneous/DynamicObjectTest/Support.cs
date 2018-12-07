using System;
using System.Dynamic;

namespace DynamicObjectTest
{

	class Greeter : DynamicObject
	{
		public string Greet(string name)
		{
			return $"Welcome {name}.";
		}

		public override bool TryInvokeMember(InvokeMemberBinder method, object[] arguments, out object result)
		{
			if(arguments.Length == 1 && arguments[0].GetType() == typeof(string))
			{
				result = $"Cannot {method.Name} {arguments[0]}!";
				return true;
			}

			result = null;
			return false;
		}

	}

	class Support
	{
		public void Run(string[] args)
		{
			dynamic g = new Greeter();
			Console.WriteLine(g.Greet("Jack"));
			Console.WriteLine(g.Kill("Jack"));
		}
	}

}