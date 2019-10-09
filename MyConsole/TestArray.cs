using System;

namespace MyConsole
{

	partial class Program
	{
		static void TestArray()
		{
			Console.Clear();

			uint[,] ua = 	// Объявляем многомерный массив целых
			{
				{1,2,3},
				{4,5,6}
			};
			Console.WriteLine("2-dimensional array:\n");
			for (int i = 0; i <= ua.GetUpperBound(0); i++, Console.WriteLine())// Пробег по нулевому измерению
			{
				for (int j = 0; j < ua.GetLength(1); j++)// Пробег по первому измерению
					Console.Write("a[{0},{1}] = {2},  ", i, j, ua[i, j]);
			}
			Console.WriteLine("\n\nRank = " + ua.Rank); 	// Хотим увидеть значения фундаментальных свойств
			Console.WriteLine("Rows = " + ua.GetLength(0));
			Console.WriteLine("Columns = " + ua.GetLength(1));
			Console.WriteLine("Length = " + ua.Length);

			Console.WriteLine("\n\nUnformatted output\n");
			foreach (uint i in ua)	// Пробег по всем элементам массива
				Console.Write(i + ", ");

			int[] an = { 1, 2, 3, 4, 5 };  // Два массива
			int[] b = { 0, 0, 0, 0, 0, 6, 7, 8, 9, 10 };

			int lenA = Buffer.ByteLength(an), lenB = Buffer.ByteLength(b); // Размеры массивов в байтах

			Console.WriteLine("\n\nThe length of Array an: {0} bytes", lenA);
			foreach (int i in an)  // Все элементы массива
				Console.Write("{0},  ", i);
			Console.WriteLine("\n\nThe length of Array b: {0} bytes", lenB);
			foreach (int i in b)
				Console.Write("{0},  ", i);

			Buffer.BlockCopy(an, 0, b, 0, lenA);  // Интересная операция

			Console.WriteLine("\n\nAfter Block copy operation array a :");
			foreach (int i in an)
				Console.Write("{0},  ", i);
			Console.WriteLine("\n\nArray b: ");
			foreach (int i in b)
				Console.Write("{0},  ", i);
			Console.WriteLine("\n\n");

			int[][] at = 	// Объявляем массив массивов целых
			{
				new int[]{1},
				new int[]{2,3,4},
				new int[]{5,6,7,8,9}
			};
			Console.WriteLine("Jagged array:\n");
			for (int i = 0; i < at.GetLength(0); i++)  // 0-е измерение работает как и ранее
			{
				Console.WriteLine();
				for (int j = 0; j < at[i].GetLength(0); j++) // Число столбцов переменно, поэтому измерение 1 не работает
					Console.Write("a[{0}][{1}] = {2},  ", i, j, at[i][j]);
			}
			Console.WriteLine("\n\nRank = " + at.Rank);
			Console.WriteLine("Length = " + at.Length + '\n');
			for (int i = 0; i < at.GetLength(0); i++)
			{
				foreach (int j in at[i])		// foreach выглядит по-другому
					Console.Write(j + ", ");
			}

			Console.WriteLine('\n');
			Array a = Array.CreateInstance(typeof(int), new int[] { 2, 3, 4 }, new int[] { -2, 0, 2 });

			for (int i = a.GetLowerBound(0); i <= a.GetUpperBound(0); i++)
				for (int j = a.GetLowerBound(1); j <= a.GetUpperBound(1); j++)
					for (int k = a.GetLowerBound(2); k <= a.GetUpperBound(2); k++)
						a.SetValue(i + j + k, new int[] { i, j, k });

			for (int i = a.GetLowerBound(0); i <= a.GetUpperBound(0); i++, Console.WriteLine())
				for (int j = a.GetLowerBound(1); j <= a.GetUpperBound(1); j++, Console.WriteLine())
					for (int k = a.GetLowerBound(2); k <= a.GetUpperBound(2); k++)
						Console.Write("a[{0}][{1}][{2}] = {3}", i, j, k, a.GetValue(new int[] { i, j, k }) + ",  ");




			Console.WriteLine("\n\n\t\tPress any key to go to main menu\n");
			Console.ReadKey(true);
		}
	}
}

