using System;

namespace MyConsole
{
	partial class Program
	{
		static void TestSwitch()
		{
			Console.Clear();
			string ans;
			while (true)
			{
				Console.WriteLine(
@"  
	I :	 ans = My
	YOU:	 ans = Your
	HE:	 ans = His
	SHE:	 ans = Her
	Q:	 ans = Leaving
	default: ans = We need a pronoun!
								");

				string s = Console.ReadLine();

				switch (s.ToUpper())	// Приводим к верхнему регистру и разветвляемся в зависимости от значения строки символов
				{
					case "I": ans = "My"; break;
					case "YOU": ans = "Your"; break;
					case "HE": ans = "His"; break;
					case "SHE": ans = "Her"; break;
					case "Q": ans = "Leaving"; break;
					default: ans = "We need a pronoun!"; break;
				}
				Console.WriteLine(ans);

				if (ans == "Leaving")
				{
					Console.WriteLine("\n\t\tPress any key to go to main menu\n");
					Console.ReadKey();
					break;
				}

				Console.WriteLine("Press any key...");
				Console.ReadKey();
				Console.Clear();

			}
		}

	}
}

