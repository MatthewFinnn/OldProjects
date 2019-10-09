using System;

namespace MyConsole
{
	partial class Program
	{
		public class Poly { }		// Базовый класс
		public class Tria : Poly { }	// Производный класс

		static void TestAsIs()
		{
			Console.Clear();

			Tria tria = new Tria();
			Poly poly1 = new Poly(),
				poly2 = tria;		// poly2 ссылается на объект производного класса

			Console.WriteLine("\t\tTest 'as' operator");

			Poly p = poly1 as Poly;
			Tria t = poly1 as Tria; // poly1 ссылается на объект базового класса
			Console.Write(
				"\npoly1 " + (p != null ? "is" : "is not") + " a Poly" +
				"\npoly1 " + (t != null ? "is" : "is not") + " a Tria");

			p = poly2 as Poly;
			t = poly2 as Tria;
			Console.Write(
				"\npoly2 " + (p != null ? "is" : "is not") + " a Poly" +
				"\npoly2 " + (t != null ? "is" : "is not") + " a Tria");

			Console.WriteLine("\n\n\t\tTest 'is' operator");
			Console.Write(
				"\npoly1 " + (poly1 is Poly ? "is" : "is not") + " a Poly" +
				"\npoly1 " + (poly1 is Tria ? "is" : "is not") + " a Tria" +
				"\npoly2 " + (poly2 is Poly ? "is" : "is not") + " a Poly" +
				"\npoly2 " + (poly2 is Tria ? "is" : "is not") + " a Tria");

			Console.WriteLine("\n\t\tPress any key to go to main menu\n");
			Console.ReadKey(true);
		}
	}
}

