using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsGalaxy
{
	public class Helper
	{
		public static readonly string None = "N/A";

		public static int AskInt(string prompt, int min, int max)
		{
			int res = 0;
			for (bool ok = false; !ok;)
			{
				Console.Write(prompt);
				ok = MakeInt(Console.ReadLine(), min, max, out res);
			}
			return res;
		}
		public static bool MakeInt(string s, int min, int max, out int res)
		{
			res = 0;
			try
			{
				res = int.Parse(s);
				if (res < min || max < res)
				{
					Console.WriteLine("Value must be in ({0}, {1})", min, max);
					return false;
				}
			}
			catch
			{
				Console.WriteLine("It is not valid integer");
				return false;
			}
			return true;
		}
		public static DateTime AskDateTime(string prompt, DateTime min, DateTime max)
		{
			DateTime res = DateTime.Now;
			for (bool ok = false; !ok;)
			{
				Console.Write(prompt);
				ok = MakeDateTime(Console.ReadLine(), min, max, out res);
			}
			return res;
		}
		public static bool MakeDateTime(string s, DateTime min, DateTime max, out DateTime res)
		{
			res = DateTime.MinValue;
			try
			{
				res = DateTime.Parse(s);
				if (res < min || max < res)
				{
					Console.WriteLine("Value must be in ({0}, {1})", min, max);
					return false;
				}
			}
			catch
			{
				Console.WriteLine("It is not valid integer");
				return false;
			}
			return true;
		}
		public static string GetWord(string text)
		{
			Regex reg = new Regex("[А-Я|а-я|A-Z|a-z]+[ ]*");
			MatchCollection mc = reg.Matches(text);

			foreach (Match m in mc)		// Проход по всей коллекции совпадений
			{
				foreach (Group g in m.Groups)	// Проход по всей коллекции групп
				{
					foreach (Capture c in g.Captures)		// Проход по всей коллекции захватов
					{
						StringBuilder res = new StringBuilder(c.Value.Trim().ToLower());
						res[0] = char.ToUpper(res[0]);
						return res.ToString();
					}
				}
			}
			return null;
		}

		public static string GetName(string text)
		{
			Regex reg = new Regex("[А-Я|а-я|A-Z|a-z]+[ ]*");
			string[] captures = { "", "", "" };
			MatchCollection mc = reg.Matches(text);

			int count = 0;
			foreach (Match m in mc)		// Проход по всей коллекции совпадений
			{
				foreach (Group g in m.Groups)	// Проход по всей коллекции групп
				{
					foreach (Capture c in g.Captures)		// Проход по всей коллекции захватов
					{
						if (count < 3)
							captures[count++] = c.Value.Trim().ToLower();
					}
				}
			}

			string result = "";
			foreach (string s in captures)
			{
				if (s.Length > 0)
				{
					StringBuilder word = new StringBuilder(s);
					word[0] = char.ToUpper(word[0]);
					result += word + " ";
				}
			}
			return string.IsNullOrEmpty(result) ? "N/A" : result.Trim();
		}
		public static string FindFolder(string name)
		{
			string dir = Application.StartupPath;
			for (char slash = '\\'; dir != null; dir = Path.GetDirectoryName(dir))
			{
				string res = dir.TrimEnd(slash) + slash + name;
				if (Directory.Exists(res))
					return res + slash;
			}
			return null;
		}
	}
}
