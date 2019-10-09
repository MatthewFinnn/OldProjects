using System;

namespace MyConsole
{
	partial class Program
	{
		unsafe static void FloatInterior(float[] a)
		{
			Console.WriteLine();
			fixed (float* pFix = a)	// Прикалываем к столу массив одной булавкой (чтобы не убежал)
			{
				float* p = pFix; 				// Этой булавкой будем его ковырять (булавка подвижна)
				for (int i = 0; i < a.Length; i++, p++)	// Хотим увидеть байты числа в формате float
				{
					Console.Write("\n{0,12:f2}  at  {1} :  ", a[i], (int)p);	// Элемент массива и его адрес
					byte* pb = (byte*)p + 4;		// Этой (тонкой) булавкой ковыряемся во внутренней структуре переменной типа float
					for (int j = 0; j < 4; j++)
						Console.Write("{0:x2} ", *--pb); // Да здравствует адресная арифметика всех C-подобных языков!!!
				}
			}
			Console.ReadKey();
			Console.WriteLine("\n");	// Теперь сборщик мусора (если захочет) может заняться массивом , т.к. мы вышли из блока fixed
		}

	}
}
