using System;

namespace MyConsole
{
	partial class Program
	{

		static void DynamicArrays()
		{
            //Console.Clear();

            //Console.Write("\nEnter Man array ");
            //int size = Helper.AskInt("Array size: ", 1, 3);	// Запрашиваем желаемый размер массива
            //Man[] men = new Man[size]; 	// Отводим память динамически (на этапе выполнения)

            //for (int i = 0; i < size; i++)	// Создаем сами объекты, на которые ссылаются элементы массива
            //{
            //    men[i] = new Man();
            //    //==== Здесь можно вставить вызов метода ввода данных —  men[i].In();
            //    men[i].Out();
            //}

            ////второй способ

            //int n = Helper.AskInt("Rows: ", 1, 4),	 // Запрашиваем желаемые размеры матрицы
            //    m = Helper.AskInt("Columns: ", 1, 4);

            //Array a = Array.CreateInstance(typeof(double), n, m); // Массив в n строк и m столбцов

            //Console.WriteLine("Rank = {0}", a.Rank);
            //for (int i = a.GetLowerBound(0); i <= a.GetUpperBound(0); i++)
            //{
            //    for (int j = a.GetLowerBound(1); j < a.GetLength(1); j++)
            //    {
            //        a.SetValue(Math.Sin(Math.PI * (i + j) / 4), i, j);
            //        Console.WriteLine("a[{0},{1}] = {2}", i, j, a.GetValue(i, j));
            //    }
            //}

            ////массиы man'ов

            //Array aMan = Array.CreateInstance(typeof(Man), n, m);

            //Console.WriteLine("Rank = {0}", aMan.Rank);
            //for (int i = aMan.GetLowerBound(0); i <= aMan.GetUpperBound(0); i++)
            //{
            //    for (int j = aMan.GetLowerBound(1); j < aMan.GetLength(1); j++)
            //    {
            //        aMan.SetValue(new Man(), i, j);
            //        Console.WriteLine("a[{0},{1}] = {2}", i, j, aMan.GetValue(i, j));
            //    }
            //}

            //Console.WriteLine("\n\t\tPress any key to go to main menu\n");
            //Console.ReadKey(true);
		}
	}
}

