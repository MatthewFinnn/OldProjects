using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyConsole
{
	public enum SortMode : byte { byName, byAge, byStatus };

     public abstract class  Man : IComparable
	{
		protected string name; 		// Данные, содержащиеся в любом объекте класса Man
		protected int age;
        protected int maxName = 25;
        protected int maxAge = 150;

		public Man() { name = "N/A"; age = 0; }		// Default constructor

		public Man(string n, int a) { name = Helper.GetName(n); age = a; }	//  Useful constructor
        public Man(Man m) { name = m.name; age = m.age; }

        ~Man() { name = name.Remove(0, name.Length);} // Можно проще: name = null;

        public string Name
        {
            get { return name; }
            set { name = Helper.GetName(value); }
        }

        public string MaxName
        {
            get { return name; }
            set {Helper.MakeInt(value, 0 , 8, out maxName); }
        }

        public string MaxAge
        {
            get { return name; }
            set { Helper.MakeInt(value, 0, 150, out maxAge); }
        }

        public static string Surname(Man m) { return m.name.Substring(m.name.LastIndexOf(' ') + 1); }
        // Ищем последний пробел, считая, что фамилия расположена после него

        public static string Firstname(Man m) { return m.name.Substring(0, m.name.IndexOf(' ')); }
        /* Найдите первый пробел, считая, что Firstname расположено до него*/ 

        private static SortMode sortBy = SortMode.byName;

        public static SortMode SortBy		// Свойство SortBy типа SortMode
        {
            get { return sortBy; }
            set
            {
                if (value < SortMode.byName || SortMode.byStatus < value)
                    sortBy = SortMode.byName;
                else sortBy = value;
            }
        }

        public virtual void In()		// Метод ввода данных объектов класса
		{
			Console.Write("Name: ");
			name = Helper.GetName(Console.ReadLine());	// Имя – это строка символов

			Console.Write("Age: ");			// Возраст – это целое
			age = int.Parse(Console.ReadLine());	// Преобразуем введенную строку в целое без знака
		}

		public void Out() { Console.WriteLine(this); }

		public override bool Equals(object other)
		{
			try { Man m = (Man)other; return m.name == name && m.age == age; }
			catch { return false; }
		}
    
		public override int GetHashCode() { return base.GetHashCode();}

        public override string ToString() { return name.PadRight(maxName) + " ; Age: " + age; }

		public int CompareTo(object other)
		{
			Man m = (Man)other;
			switch (sortBy) 	// Выбираем ветвь в зависимости от режима сортировки
			{
				case SortMode.byName: return String.Compare(name, m.name);
				case SortMode.byAge:
					if (age > m.age) return 1;
					if (age < m.age) return -1;
					else return 0;
				case SortMode.byStatus: return 0;
			}
			return -1;
		}

        public virtual void Read(string[] tokens) // Выбор данных из уже разобранной строки (массива лексем)
        {
            // Здесь работает свойство, которое пользуется методом GetName для защиты от плохого ввода
            Name = tokens[1].Trim();	// Нас интересует (см. формат данных файла) только 1-я  и 3-я лексемы (считая от нуля)
            Helper.MakeInt(tokens[3], 0, maxAge, out age);
        }

        public abstract string Class();

        public void Edit() {Console.WriteLine(this); In();}


       


	}
}
