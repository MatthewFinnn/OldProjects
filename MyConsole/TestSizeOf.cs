using System;
using System.Runtime.InteropServices;

namespace MyConsole
{
	struct IntByte
	{
		int i;
		byte b;
	}

	struct IntByteString
	{
		int i;
		byte b;
		string s;
	}

	struct DoubleByte
	{
		double d;
		byte b;
	}

	partial class Program
	{
		static void TestSizeOf()
		{
			Console.Clear();
			Console.WriteLine("sizeof({0}) = {1}", typeof(int), sizeof(int));
			Console.WriteLine("sizeof({0}) = {1}", typeof(byte), sizeof(byte));
			Console.WriteLine("sizeof({0}) = {1}", typeof(double), sizeof(double));
			Console.WriteLine("sizeof({0}) = {1}", typeof(ulong), sizeof(ulong));
			Console.WriteLine("sizeof({0}) = {1}", typeof(decimal), sizeof(decimal));

			IntByte s = new IntByte();
			Console.WriteLine("Marshal.SizeOf({0}) = {1}", s.GetType(), Marshal.SizeOf(s));
			IntByteString ibs = new IntByteString();
			Console.WriteLine("Marshal.SizeOf({0}) = {1}", ibs.GetType(), Marshal.SizeOf(ibs));
			DoubleByte db = new DoubleByte();
			Console.WriteLine("Marshal.SizeOf({0}) = {1}", db.GetType(), Marshal.SizeOf(db));
			// Слующая строка вызовет исключение
			// Console.WriteLine("Marshal.SizeOf({0}) = {1}", db.GetType(), Marshal.SizeOf(DateTime.Now));
			Console.WriteLine("\n\t\tPress any key to go to main menu\n");
			Console.ReadKey();
		}

	}
}

