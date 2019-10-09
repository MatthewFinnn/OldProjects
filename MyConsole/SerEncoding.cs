using System;
using System.Text;

namespace MyConsole
{
	partial class Program
	{
		static string Koi8rToWin1251 (string source)
		{
			Encoding win = Encoding.GetEncoding("windows-1251");
			return win.GetString(Encoding.Convert(
				Encoding.GetEncoding("koi8-r"), win, win.GetBytes(source)));
		}
		static string Win1251ToKoi8r (string source)
		{
			Encoding koi = Encoding.GetEncoding("koi8-r");
			return koi.GetString(Encoding.Convert(
				Encoding.GetEncoding("windows-1251"), koi, koi.GetBytes(source)));
		}

		static void SetEncoding()
		{
			Console.Clear();
			string s = @"
	Вам хочется узнать местонахождение посетителей вашего сайта?
	Вам интересно узнать людей, читающих ваше резюме?
	Это важно для бизнеса, так как вы cможете влиять на целевую аудиторию.\n";

			Console.WriteLine("KOI8-R:\n\n" + (s=Win1251ToKoi8r(s)));
			Console.WriteLine("Windows-1251:\n\n{0}\n", Koi8rToWin1251(s));
			Console.ReadKey();
		}

	}
}

