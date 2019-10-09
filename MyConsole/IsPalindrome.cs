using System;

namespace MyConsole
{
	partial class Program
	{
		static bool  Palindrome(string s)
		{
			s = s.Replace(" ", "");
			s = s.Replace(",", "");
			s = s.ToLower();

			for (int i = 0; i < s.Length ; i++)
			{
				if (s[i] != s[s.Length-1 -i])
					return false;
			}
			return true;
		}
	}
}

