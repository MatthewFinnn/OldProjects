using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Library
{
        public static class MyProperties
        {
            static string[] letters = {
			"A", "B", "C", "D", "E", "F", "G", "H", "I", "K", "L", "M", "N", "O", "P", 
			"Q", "R", "S", "T", "U", "V", "W", "X", "__" };

            static string[] prefixes = {
			"Ac", "Al", "Am", "AspNet", "As", "broker", "bu", "Ca", "Ce", "Ch", "CIM", 
			"Cl", "Co", "Cr", "Csc", "Ctl", "cursor", 
			"database", "De", "Disk", "Driver", "En", "Er", "Ex",
			"Fa", "Fd", "Fi", "Fr", "He", "Ho", "Http", "HWConfig", "Im", "Io", "Is", "Kerb", 
			"latch", "Lo", "Lp","Ma", "MMC", "Me", "Mo", "MSNdis", "Mp", "MSi", "MSS", "MSW", 
			"MSF", "MSN", "MS1", "MSP", "MST", "MSK", "MS_", "MS", "Mu", "Ne", "Nl", "No", "Nt",
			"Open", "Op", "Page", "Pl", "Po", "Process", "Prop", "Rd", "RS", "Registry", "Re",
			"Sam", "Sc", "Set", "Se", "Si", "So", "Sq", "Sp", "St", "Sy", 
			"Tc", "Te", "Th", "TP", "Ts", "Ud", "Um",
			"Web", "Wc", "Wd", "Wl", "Wm", "Win32_Perf", "Win32_A", "Win32_B", "Win32_C", "Win32_D", 
			"Win32_F", "Win32_I", "Win32_L", "Win32_M", "Win32_N", "Win32_O", "Win32_P", 
			"Win32_R", "Win32_Ser", "Win32_Soft", "Win32_System", "Win32_S", "Win32_T", 
			"Win32_U", "Win32_V", "Win32_W", "Win32", "Workflow", "WS", "Wi", "Wo", "Xe", "XEvent", 
			"__Namespace", "__Class", "__Instance", "__" };

            public static void Classify(string name, ref TreeNode node)
            {
                Globals.Classify(letters, name, ref node);
                Globals.Classify(prefixes, name, ref node);
            }
        }

        public static class MyEvents
        {
            static string[] prefixes = { 
			"HD", "Kernel", "MSFT", "MSNdis", "MS", "Port", "Process", "Reg", 
			"Win32", "Workflow", "__Namespace", "__Class", "__Instance", "__" };
            public static void Classify(string name, ref TreeNode node)
            {
                Globals.Classify(prefixes, name, ref node);
            }
        }

        public static class MyOther
        {
            static string[] letters = { 
			"A", "B", "C", "D", "E", "F", "H", "I", "K", "L",
			"M", "O", "P", "R", "S", "T", "U", "W" };
            static string[] prefixes = { 
			"Ac", "Al", "Cs", "Di", "Dr", "Fi", "Get", "Hd", "He", "HNet", 
			"Id", "Im", "ISCSI", "Is", "Mm", "MSNdis", "Mp", "MSi", "MSS", "MSW", 
			"MSF", "MSN", "MS1", "MSP", "MST", "MSK", "MSM", "MS_", "MS", "Mu", "Pa", "Pe", "Po", 
			"Process", "Re", "Rs", "Se", "Sy", "Tc", "Th", "Tp", "Ts", "Ud", "Um",
			"Vs", "Win32", "Wh", "Wm", "__" };
            public static void Classify(string name, ref TreeNode node)
            {
                Globals.Classify(letters, name, ref node);
                Globals.Classify(prefixes, name, ref node);
            }
        }

	public class Globals
	{
		public static void Classify(string[] prefixes, string name, ref TreeNode node)
		{
			bool found = false;
			foreach (string s in prefixes)
			{
				found = name.StartsWith(s, StringComparison.InvariantCultureIgnoreCase);
				if (found)
				{
					FindOrAddNode(s, ref node);
					break;
				}
			}
		}
		public static void FindOrAddNode(string s, ref TreeNode node)
		{
			int pos = node.Nodes.IndexOfKey(s);
			node = pos == -1 ?
				node.Nodes.Add(s, s, 3, 2) :
				node.Nodes[pos];
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
