using System;

namespace MyConsole
{
	partial class Program
	{ 
		static void TestRational()	// Вызывающий метод тоже следует сделать опасным, так как внутри идет работа с указателем
		{
			Console.Clear();
			Console.WriteLine("\n\tTest Rational class\n");

			Rational p = new Rational(2, 4),
						q = new Rational(27, 81),
						s = new Rational(20, 15);
			p.Print("p"); q.Print("q"); s.Print("s");
			(p + q).Print("p+q");
			(p - q).Print("p-q");
			(q - p).Print("q-p");
			(p * q).Print("p*q");
			(p / q).Print("p/q");
			Console.WriteLine("p!=q: {0}", p != q);
			Console.WriteLine("p>q: {0}", p > q);
			Console.WriteLine("p<q: {0}", p < q);
			Console.WriteLine("p<1: {0}", p < 1);
			Console.WriteLine("p>0.3: {0}", p > 0.3);

			Console.ReadKey();
		}
	}
}
