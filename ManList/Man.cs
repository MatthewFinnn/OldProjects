using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManList
{
	public enum SortMode : byte { byName, byAge, byStatus };	// Новый тип данных
	[Serializable]
	public abstract class Man : IComparable, ICloneable
	{
		object ICloneable.Clone()	// Явная реализация метода интерфейса
		{
			Man m = this as Man;
			return m;// Создаем и возвращаем новый объект в виде копии существующего (Ваш код . . .)
		}

		public abstract string Class();	// Этот метод обязаны реализовать не абстрактные потомки


		protected string name; 		// Данные, содержащиеся в любом объекте класса Man
		protected int age;

        

		static int maxName = 25;
		static int maxAge = 150;

		public string Name
		{
			get { return name; }
			set
			{
				if (value.Length > maxName)
					name = Helper.GetName(value.Substring(0, maxName - 1));
				else
					name = Helper.GetName(value);
			}
		}

		public int Age
		{
			get { return age; }
			set { Helper.MakeInt(value.ToString(), 0, maxAge, out age); }
		}

		public static int MaxAge
		{
			get { return maxAge; }
			set { maxAge = value; }
		}

		public static int MaxName
		{
			get { return maxName; }
			set { maxName = value; }
		}

		public void Edit()
		{
			Console.WriteLine(this);
			In();
		}

		public static string Surname(Man m)	// Ищем последний пробел, считая, что фамилия расположена после него
		{
			return m.name.Substring(m.name.LastIndexOf(' ') + 1);
		}


		public static string Firstname(Man m)
		{/* Найдите первый пробел, считая, что Firstname расположено до него*/
			return m.name.Substring(0, m.name.LastIndexOf(' '));
		}

		private static SortMode sortBy = SortMode.byName; // Статическая переменная
		private static SortMode LsortBy = SortMode.byAge;
		public int CompareTo(object other)
		{
			Man m = other as Man;
			switch (sortBy) 	// Выбираем ветвь в зависимости от режима сортировки
			{
				case SortMode.byName: return name.CompareTo(m.name);
				case SortMode.byAge: return age.CompareTo(m.age);
				case SortMode.byStatus:
					if (!Class().Equals(m.Class()))
						return Class().CompareTo(m.Class());
					if (LsortBy == SortMode.byName)
						return name.CompareTo(m.name);
					return age.CompareTo(m.age);
				default: return 0;
			}
		}


		public Man() { name = "N/A"; age = 0; }		// Default constructor
		public Man(string n, int a) { name = n; age = a; }	//  Useful constructor
		~Man()		// Деструктор (Попытка освободить память)
		{
			name = name.Remove(0, name.Length); // Можно проще: name = null;
		}
		public Man(Man man)
		{
			this.name = man.name;
			this.age = man.age;
		}

		public virtual void In()		// Метод ввода данных объектов класса
		{
			Console.Write("Name: ");
            name = Helper.GetName(Console.ReadLine());
			age = Helper.AskInt("Age: ", 0, maxAge);
		}

		public static SortMode SortBy		// Свойство SortBy типа SortMode
		{
			get { return sortBy; }
			set
			{
				if (value < SortMode.byName || SortMode.byStatus < value)
					throw new ArgumentOutOfRangeException(
						string.Format("\n\nНеверно задан режим сортировки: {0}\n\n", value));
				if (sortBy != SortMode.byStatus)
					LsortBy = sortBy;
			    sortBy = value;
			}
		}

		public virtual void Read(string[] tokens) // Выбор данных из уже разобранной строки (массива лексем)
		{
			// Здесь работает свойство, которое пользуется методом GetName для защиты от плохого ввода
			Name = tokens[1].Trim();	// Нас интересует (см. формат данных файла) только 1-я  и 3-я лексемы (считая от нуля)
			Helper.MakeInt(tokens[3], 0, maxAge, out age);
		}


		public override string ToString()	// Разделители понадобятся при чтении данных из файла
		{
			return name.PadRight(maxName) + " ; Age: " + age;
		}


		public override bool Equals(object other)
		{
			Man m = other as Man;
			return m == null ? false : m.name == name && m.age == age;
		}


		internal static int IndexOf(Man[] men, Man len)
		{
			throw new NotImplementedException();
		}
	}
}
