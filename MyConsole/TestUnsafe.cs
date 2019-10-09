using System;

namespace MyConsole
{
	partial class Program
	{ 
		static string test = "MS Educational ";	// Переменная класса Program
		unsafe static void Display(char* text)	// Опасный  метод
		{
			for (int i = 0; text[i] != 0; ++i)
				Console.Write(text[i] + " ");
		}
		unsafe static void TestUnsafe()	// Вызывающий метод тоже следует сделать опасным, так как внутри идет работа с указателем
		{
			Console.Clear();
			Console.WriteLine("\n\tTest Unsafe Code\n");

			char[] text = new char[] { 'C', 'e', 'n', 't', 'e', 'r', ' ' };
			fixed (char* p = test)
				Display(p);
			fixed (char* p = &text[0])
				Display(p);
			fixed (char* p = "Avalon.ru")
				Display(p);

			Console.WriteLine("\n\tPress any key to go to main menu\n");
			Console.ReadKey(true);
		}
	}
}
