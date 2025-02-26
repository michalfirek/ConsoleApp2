using ConsoleApp2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
	internal class Test : ITest
	{
		public string Name { get; set; }

		public void Print()
		{
			Console.WriteLine(Name);
		}
	}
}
