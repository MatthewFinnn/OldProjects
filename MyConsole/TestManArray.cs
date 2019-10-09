using System;

namespace MyConsole
{
	partial class Program
	{ 
		static void TestManArray()	// Вызывающий метод тоже следует сделать опасным, так как внутри идет работа с указателем
		{
            
            //Console.Clear();
            //Man		// Три ссылки на отдельные объекты
            //    ken = new Man("Ken Wood", 40),
            //    len = new Man("Lennie Tristano", 50),
            //    ben = new Man("Ben Webster", 60);
            //Man[] men = { ken, len, ben, ken, len, ben };	// Массив ссылок на объекты

            ////===== Вставьте код поиска первого вхождения Lennie Tristano
            //int id = Array.IndexOf(men , len);
            //Console.WriteLine("The first Lennie's id = {0}", id);
            ////===== Вставьте код поиска последнего вхождения
            //id = Array.LastIndexOf(men, len);
            //Console.WriteLine("The last Lennie's id = {0}", id);
            ////===== Вставьте код реверса последовательности
			
            //Console.WriteLine("\nAfter Reverse:\n");
            //foreach (Man m in men)
            //    m.Out();

            //Array.Reverse(men);
            //Console.WriteLine("\nAfter Reverse:\n");
            //foreach (Man m in men)
            //    m.Out();
            ////===== Копирование подпоследовательности (Вставьте коды вызова метода Copy и вывода всей копии)
            //Man[] menCopi = { new Man(), new Man(), new Man(), ken, len, ben };
            //Console.WriteLine("\nArray manCopi:\n");
            //foreach (Man m in menCopi)
            //    m.Out();
            //Array.Copy(men, menCopi, men.Length); 
            //Console.WriteLine("\nAfter Copy:\n");
            //foreach (Man m in menCopi)
            //    m.Out();
			
            //Console.WriteLine("ken.Equals(men[0]) = {0}", ken.Equals(men[0]));
            //Console.WriteLine("men[0].Equals(men[3]) = {0}", men[0].Equals(men[3]));


            //Console.WriteLine("\n=====Test Equility and Hash keys=====\n");
            //Console.WriteLine("ken.Equals(men[0]) = {0}", ken.Equals(men[0]));
            //Console.WriteLine("men[0].Equals(men[3]) = {0}", men[0].Equals(men[3]));

            //Console.Write("\nHash keys: ");
            //foreach (Man m in men) // Пользуемся родительской версией функции GetHashCode
            //    Console.Write("{0}, ", m.GetHashCode());

            //men[0] = new Man("Ken Wood", 40);

            //Console.Write("\nHash keys: ");
            //foreach (Man m in men)
            //    Console.Write("{0}, ", m.GetHashCode());

            //Console.WriteLine("\n\nken.Equals(men[0]) = {0}", ken.Equals(men[0]));
            //Console.WriteLine("men[0].Equals(men[3]) = {0}", men[0].Equals(men[3]));

            //Console.WriteLine("\n\n=======CompareTo=======");
            ////==== Создайте массив
            //Man[] test = { new Man("cccc", 54), new Man("bbb", 64), new Man("aaaa", 34) };
            //Console.WriteLine("Men before Sort:\n");
            ////==== Выведите массив
            //foreach (Man m in test)
            //    m.Out();
            //Array.Sort(test); // Для сортировки пользуемся статическим методом класса Array
            //Console.WriteLine("\nSort by Name");
            //Man.SortBy = SortMode.byName;
            //Console.WriteLine("\nMen after Sort:\n");
            ////==== Выведите массив
            //foreach (Man m in test)
            //    m.Out();

            //Console.WriteLine("\nSort by Age");
            //Man.SortBy = SortMode.byAge;
            //Array.Sort(test); // Для сортировки пользуемся статическим методом класса Array
            //Console.WriteLine("\nMen after Sort:\n");
            ////==== Выведите массив
            //foreach (Man m in test)
            //    m.Out();


            //Console.WriteLine("\nSort by (SortMode)20");
            //Man.SortBy = (SortMode)20;
            //Array.Sort(test); // Для сортировки пользуемся статическим методом класса Array
            //Console.WriteLine("\nMen after Sort:\n");
            ////==== Выведите массив
            //foreach (Man m in test)
            //    m.Out();

            //Console.WriteLine("\n\tPress any key to go to main menu\n");
            //Console.ReadKey(true);
		}
	}
}
