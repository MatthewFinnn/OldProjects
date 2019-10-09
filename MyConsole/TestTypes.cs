using System;

namespace MyConsole
{
	partial class Program
	{
		static void TestTypes()
		{
			Console.Clear();

			string line = new string('\u2500', 40);
			bool b = false;
			Type t = b.GetType();
			Console.WriteLine(
	@"Assembly FullName: {0},
	Testing bool type
	{1}
	Resides in:		{2}
	Primitive type:		{3}
	Pointer type:		{4}
	Value type:		{5}
	Subclass of object:	{6}", t.Assembly.FullName, line, t, t.IsPrimitive,
			t.IsPointer, t.IsValueType, t.IsSubclassOf(typeof(object)));

			t = typeof(Program);
			Console.WriteLine(
	@"Testing type Program
	{0}
	Primitive type:		{1}
	Pointer type:		{2}
	Value type:		{3}
	Reference type:		{4}
	Subclass of object:	{5}", line, t.IsPrimitive, t.IsPointer,
			t.IsValueType, t.IsClass, t.IsSubclassOf(typeof(object)));

			Console.WriteLine("\nNew Types:\n\n" +
				"uint: \t(" + uint.MinValue + ", " + uint.MaxValue + ")\n" +
				"ulong: \t({0}, {1}) max: {2:e1} \ndecimal: ({3}, {4}) max: {5:e1}\n",
				ulong.MinValue, ulong.MaxValue, (double)ulong.MaxValue,
				decimal.MinValue, decimal.MaxValue, decimal.ToDouble(decimal.MaxValue));

			decimal d = 100.25m;
			Console.WriteLine("\nSuffix 'm' stands for money: " + d + '\n');
			float[] a = { 1, -1.25f, 1.03f, -1, 1e8f, -1e-2f, 5e6f }; // Массив переменных типа float
			Console.WriteLine("\n\nTest Formatting options\n");
			for (int i = 0; i < a.Length; i++)
				Console.Write("\n{0,12:f2}  ", a[i]);		// Здесь используется 12 позиций

			int n = 0;
			n = ++n + n + n++;
			Console.WriteLine("\nn = " + n); 		// Поясните различие
			n = 0;
			n = ++n + n++ + n;
			Console.WriteLine("\nn = " + n);		// Поясните различие

			Console.WriteLine("\n\t\tPress any key to go to main menu\n");
			Console.ReadKey(true);
		}
	}
}

