using System;
using System.Text;
using System.Threading;
using System.Globalization;

namespace MyConsole
{
	partial class Program
	{

		public static void Main()
		{
			Console.BackgroundColor = ConsoleColor.DarkBlue;
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WindowWidth = 110;
			Console.WindowHeight = 45;
			Console.Title = "MyConsole Application";
			Console.InputEncoding = Encoding.GetEncoding("windows-1251");
			Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

			Rational ratOne =  Rational.One;
			Rational ratZero = Rational.Zero;
			Rational summ = ratOne + ratZero;

			while (true)
			{
				Console.Clear();
				switch (Menu())
				{
					case '\x1b':
						Console.Beep(800, 100); Console.Beep(600, 100); Console.Beep(400, 500);
						Console.Write("\a\a"); return;
					case 'q': return;
					case 't': TestTypes(); break;
					case 'w': TestSwitch(); break;
					case 'u': TestUnsafe(); break;
					case 'f': float[] f= new float[] {1,3 , 2, 3,5 , 4};  FloatInterior(f); break;
					case 'r': TestRational(); break;
					case 'e': SetEncoding(); break;
					case 'm': TestMan(); break;
					case 'c': TestStack(); break;
					case 'z': TestSizeOf(); break;
					case 'a': TestArray(); break;
					case 'y': TestManArray(); break;
					case 'i': TestAsIs(); break;
					case 'd': DynamicArrays(); break;
					case 'l': TestArrayList(); break;
					case 'b':
						{
							Console.Clear(); 
							C c = new C();
							Console.WriteLine(c.Say());
							Console.WriteLine(c.Cry());
							Console.WriteLine("\n\tPress any key...");
							Console.ReadKey();
						}; break;
					case 'p':
						{
							Console.Clear();
							Console.WriteLine("Введите строку");
							Console.WriteLine(Palindrome(Console.ReadLine()));
							Console.WriteLine("\n\tPress any key...");
							Console.ReadKey();
							break;
						}

					case 's':
						{
							decimal fst = 5;
							decimal scn = 6;
							Console.Clear();
							Console.WriteLine(
@"		Until:
		Fst= {0} 
		Scn= {1}
									
						", fst, scn);

							TestSwap(ref fst, ref scn);
							Console.WriteLine(
@"		After:
		Fst= {0} 
		Scn= {1}
							
						", fst, scn);
							Console.WriteLine("\n\t\tPress any key to go to main menu\n");
							Console.ReadKey();
							break;
						}
				}
			}
		}
		public static char Menu() // Меню выбора действия
		{
			Console.Write(
@"		Select a sample

			q - Quit
			t - Types
			s - Swap
			w - Switc
			p - Palindrome 
			u - Unsafe
			f - Float Interior
			r - Rational class
			e - Encoding
			m - Man
			c - Stack
			z - SizeOf
			a - Array
			y - Man Array
			b - Abstract class 
			i - As/Is
			d - Dynamic arrays
			l - Array List
			");
			return char.ToLower(Console.ReadKey(true).KeyChar); // Читаем символ
		}
	}
}


