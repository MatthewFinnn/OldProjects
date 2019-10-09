using System;

namespace MyConsole
{
	partial class Program
	{
		static decimal TestSwap( ref decimal fst, ref decimal scn)
		{
			decimal temp;
			temp = fst;
			fst = scn;
			scn = temp;
			return 0;
		}
	}
}

