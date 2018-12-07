using System;
using System.Reflection;

namespace DynamicProxyTest
{	
	interface IGreeter
	{
		string Meet(string person, bool formal);
		string Leave(string person);
	}

	class EnglishGreeter : IGreeter
	{
		public string Meet(string person, bool formal) => formal ? $"Hello {person}" : $"Hi {person}";

		public string Leave(string person) => $"Bye {person}"; 
	}

	/*
	class GreeterEchoProxy : IGreeter
	{
		private IGreeter original;

		public string Meet(string person, bool formal)
		{
			Console.WriteLine(">> Invoking Meet method of {0}", original.GetType().Name);
			return original.Meet(person, formal);
		}

		public string Leave(string person)
		{
			Console.WriteLine(">> Invoking Leave method of {0}", original.GetType().Name);
			return original.Leave(person);
		}

		public static IGreeter CreateFor(IGreeter target)
		{
			var proxy = new GreeterEchoProxy();
			proxy.original = target;
			return proxy;
		}
	}
	*/
	
	class EchoProxy<I> : DispatchProxy where I : class
	{
		private I original = null;

		protected override object Invoke(MethodInfo method, object[] arguments)
		{
			Console.WriteLine(">> Invoking {0} method of {1}", method.Name, original.GetType().Name);
			return method.Invoke(original, arguments);
		}

		public static I CreateFor<T>(T target) where T : I
		{
			object proxy = DispatchProxy.Create<I, EchoProxy<I>>();
			((EchoProxy<I>)proxy).original = target;
			return (I)proxy;
		}
	}

	class Support
	{
		
		internal void Run(string[] args)
		{
			//IGreeter gp = GreeterEchoProxy.CreateFor(new EnglishGreeter());
			IGreeter gp = EchoProxy<IGreeter>.CreateFor(new EnglishGreeter());
			Console.WriteLine(gp.Meet("Jack", false));
			Console.WriteLine(gp.Leave("Jack"));
		}
	}
}
