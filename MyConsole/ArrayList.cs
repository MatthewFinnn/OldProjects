using System;
using System.Collections;

namespace MyConsole
{
	partial class Program
	{

		static void TestArrayList()	// Вызывающий метод тоже следует сделать опасным, так как внутри идет работа с указателем
		{
            //Console.Clear();

            //ArrayList men = new ArrayList();	// Создаем коллекцию ссылок на объекты
            //Console.WriteLine("List properties:\n" +
            //    "\nCapacity:       {0}\nIsFixedSize:    {1}" +
            //    "\nIsReadOnly:     {2}\nIsSynchronized: {3}", men.Capacity, men.IsFixedSize, men.IsReadOnly, men.IsSynchronized);
            //Man		// Три ссылки на отдельные объекты
            //    ken = new Man("Ken Wood", 40),
            //    len = new Man("Lennie Tristano", 50),
            //    ben = new Man("Ben Webster", 60);

            //men.Add(ken); men.Add(ben); men.Add(len); // Вставляем ссылки в конец списка
            //men.Sort();	// Сравните этот вызов с тем, который был ранее
            //Console.WriteLine("Men after Sort by name:\n");
            //foreach (Man m in men)
            //    m.Out();
            //men.Add(ken); 	// Добавляем ссылку в конец списка
            //men.Insert(0, ken); 	// Вставляем ссылку в начало списка
            //ArrayList other = (ArrayList)men.Clone();	// Создаем клон списка
            //Console.WriteLine("\nMen Clone:\n");
            //foreach (Man m in other)
            //    m.Out();


            ///*Контейнер типа ArrayList может быть создан на основе стандартного массива, а затем 
            //дополнен не только отдельными ссылками, но и целыми коллекциями ссылок, которые вставляются 
            // в указанные нами позиции. Роль вставляемой коллекции может выполнять объект любого класса,
            // который реализует интерфейс ICollection. Стандартный массив удовлетворяет этому условию, 
            // поэтому он может быть вставлен внутрь коллекции типа ArrayList.*/

            //Console.WriteLine("\n=====Вставляемые коллекции в =Array List====\n");
            //Man[] ma = { ken, len, ben };

            //men = new ArrayList(ma);  // Создаем коллекцию на основе массива
            //ma = new Man[] { ken, ken, ken, ken }; // Массив меняет все свои элементы

            //int id = men.LastIndexOf(ben); // Узнаем где (в коллекции) сидит Ben Webster
            //men.InsertRange(id, ma); 	// Вставляем перед ней стандартный массив
            //men.InsertRange(id, ma); 	// Повторяем вставку (для убедительности)

            //Console.WriteLine("\nMen after ken's attack:\n");
            //foreach (Man m in men)
            //    m.Out();


            ///*Задание. Продолжите тему (в коллекции слишком много Ken'ов) и реализуйте такой алгоритм.
            //    •	Удалите первую ссылку на Ken Wood. Используйте метод Remove.
            //    •	Найдите позицию следующего Ken’а (IndexOf) и удалите объект с помощью метода RemoveAt.
            //    •	Вычислите, сколько всего объектов расположено в коллекции после найденной позиции Ken'а. Присвойте это значение переменной nLeft и выведите на экран.
            //    •	Возродите стандартный массив ma так, чтобы его размер стал nLeft.
            //    •	Скопируйте последние nLeft элементов коллекции в массив ma. Используйте метод CopyTo.
            //    •	Проверьте, что получилось.
            //    •	Удалите из коллекции всех оставшихся Ken’ов (цикл, использующий Contains и Remove).
            //    •	Скопируйте часть коллекции в стандартный массив с помощью метода ToArray класса ArrayList.
            //    •	Объясните различие между методами CopyTo и ToArray.*/

            //int nLeft = 0;
            //men.Remove(ken);
            //men.RemoveAt((men.IndexOf(ken)));
            //nLeft = men.Count - men.IndexOf(ken) - 1;


            //Console.WriteLine("\n\tPress any key to go to main menu\n");
            //Console.ReadKey(true);
		}
	}
}
