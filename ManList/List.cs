using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;

namespace ManList
{
	public class List
	{
		List<Man> men;		// Список ссылок на объекты
		bool bModified,	// Флаг состояния: список изменен
				bNew;			// Флаг состояния: новый список
		string version,	// Строка аутентификации файла
					fileName;	// Имя файла со списком

		// Создайте readonly-свойство для доступа к списку men
		// Для свойства задайте атрибуты, необходимые для Xml-сериализации списка (см ниже XmlSerializer)
		[XmlElement(typeof(Stud)), XmlElement(typeof(Prof))]
		public List<Man> Men { get { return men; } }	// Список ссылок на объекты из иерархии Man

		public List()
		{
			// men = // Создайте сам список
			men = new List<Man>();
			bModified = false;
			bNew = true;
			version = "List of Man, v.1.0";
			fileName = FindFolder("Data") + "List.txt"; // Определяем местоположение файлов с данными
		}

        public void ListShow()
        {
            this.Dump();
        }

		string FindFolder(string name)
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

		public void Show()
		{
			Console.Write((men.Count == 0 ? "\n\tList is Empty\n" : "\n\tList of Man\n"));
			// Выведите весь список, нумеруя все строки
			int k=0;
			foreach (Man m in men)
			{
				k++;
				Console.Write(k + " " + m.ToString() + "\n");
			}
		}

		public void Add()
		{
			while (true) // Пусть пользователь вводит, пока ему не надоест	
			{
				Man m = null;				// Пока пустая ссылка	
				switch (ManMenu())	// Это меню должно предлагать выбор: Stud или Prof
				{
					case 'q': return;
					case 's': m = new Stud(); break;
					case 'p': m = new Prof(); break;
					default: continue;
				}
				// Вызовите виртуальный метод ввода данных. Здесь работает полиморфизм позднего связывания
				m.In();
				//==== Добавьте ссылку в коллекцию
				men.Add(m);
				bModified = true;	// Список изменился
			}
		}

		public void Delete()
		{
			if (men.Count == 0)
			{
				Console.WriteLine("List is empty");
				return;
			}
			while (men.Count > 0)
			{
				Console.Write("\n\tDelete\t0...{0} (0 - to Quit): ", men.Count);
				int n = Helper.AskInt("Enter number of del object", 0, men.Count); 
					// Попросите Helper ввести номер удаляемого элемента списка
				if (n <= 0)
					break;
				// Удалите этот элемент
				men.RemoveAt(n-1);
				bModified = true;
				Show();
			}
		}
		//======= Универсальный метод: открывает файл либо для чтения, либо для записи
		public object FileOpen(string mode)
		{
			object file = null;
			switch (mode)
			{
				case "read":
					try
					{
						// Создайте читателя, то есть StreamReader
						file = new StreamReader(fileName,false);
					}
					catch (FileNotFoundException)
					{
						Console.WriteLine("\nFile: " + fileName + " not found");
						return null;
					}
					StreamReader sr = file as StreamReader; // Приведение типа: расплата за универсальность
					string line = sr.ReadLine();
					if (!line.Equals(version))
					{
						Console.WriteLine("\nWrong file format: " + fileName);
						sr.Close();
						return null;
					}
					return file;
				case "write":
					try
					{
						// Создайте писателя, то есть StreamWriter
						file = new StreamWriter(fileName, false);
					}
					catch (IOException)
					{
						Console.WriteLine("\nCan not write to: " + fileName);
						return null;
					}
					StreamWriter sw = file as StreamWriter;
					sw.WriteLine(version + "\n");
					return file;
				default: return null;
			}
		}

		public void Write()
		{
			if (men.Count == 0)
			{
				Console.WriteLine("List is empty");
				return;
			}
			WriteText();
			WriteBinary();
			WriteSoap();
			WriteXml();
			Console.WriteLine("List has been stored in all formats");
			bNew = bModified = false;
		}

		void WriteText()
		{
            
			fileName = Path.ChangeExtension(fileName, ".txt");
			// Обратитесь к методу FileOpen("write") и приведите тип (as StreamWriter)
			StreamWriter sw = FileOpen("write") as StreamWriter;

			if (sw != null)
			{
				foreach (Man m in men)
					sw.WriteLine (m);
				sw.Close();
			}
			
		}

		void WriteBinary()
		{
			//fileName = Path.ChangeExtension(fileName, ".bin");
			// Создайте код, как рассказано ниже. Не забудьте закрыть файл
			fileName = Path.ChangeExtension(fileName, ".bin");
			IFormatter fmt = new BinaryFormatter();
			Stream stream = new FileStream(fileName, FileMode.Create);
			fmt.Serialize(stream, men);
			stream.Close();

		}

		void WriteSoap()
		{
			//fileName = Path.ChangeExtension(fileName, ".soap");
			// Создайте код, как рассказано ниже. Не забудьте закрыть файл
			fileName = Path.ChangeExtension(fileName, ".soap");
			Stream stream = new FileStream(fileName, FileMode.Create);
			IFormatter fmt = new SoapFormatter();
			fmt.Serialize(stream, men.ToArray());
			stream.Close();

		}

		void WriteXml()
		{
			fileName = Path.ChangeExtension(fileName, ".xml");
			// Создайте код, как рассказано ниже. Не забудьте закрыть файл
			XmlSerializer serializer = new XmlSerializer(typeof(List));
			TextWriter sw = new StreamWriter(fileName);
			serializer.Serialize(sw, this);
			sw.Close();

		}

		public void Read()
		{
			if (men.Count != 0)
			{
				Console.WriteLine("Deleting current list");
				men.Clear();
			}

			switch (ReadWriteMenu())
			{
				default: return;
				case 't': ReadText(); break;
				case 'b': ReadBinary(); break;
				case 's': ReadSoap(); break;
				case 'x': ReadXml(); break;
			}
			bModified = false;
			Show();
		}


		void ReadText()
		{
			fileName = Path.ChangeExtension(fileName, ".txt");
			// Обратитесь к методу FileOpen("read") и приведите тип (as StreamReader)
			StreamReader sr = FileOpen("read") as StreamReader; // Обратитесь к методу FileOpen("read") и приведите тип (as StreamReader)
			if (sr == null)
			{
				Console.WriteLine("Could not open: " + fileName);
				return;
			}
			Console.WriteLine("Reading from: " + Path.GetFileName(fileName));
			string line;
			while ((line = sr.ReadLine()) != null)
			{
				if (line == "")
					continue;
				Man m;
				switch (line[0])
				{
					case 'S': m = new Stud(); break;
					case 'P': m = new Prof(); break;
					default: return;
				}
				char[] separator = { ':', ';' };
				string[] tokens = line.Split(separator);// Разбейте строку на подстроки с помощью метода Split
				m.Read (tokens); // Здесь работает полиморфизм поздего связывания
				men.Add(m);
			}
			sr.Close();
		}

		void ReadBinary()
		{
		  fileName = Path.ChangeExtension(fileName, ".bin");
			// Создайте код, как рассказано ниже. Не забудьте закрыть файл
		  men.Clear();	// Для убедительности
		  IFormatter fmt = new BinaryFormatter();
		  Stream stream = new FileStream(fileName, FileMode.Open);
		  men = (List<Man>)fmt.Deserialize(stream);
		  stream.Close();

			
		}

		void ReadSoap()
		{
			fileName = Path.ChangeExtension(fileName, ".soap");
			// Создайте код, как рассказано ниже. Не забудьте закрыть файл
			IFormatter fmt = new SoapFormatter();
			Stream stream = new FileStream(fileName, FileMode.Open);
			Man[] ma = (Man[])fmt.Deserialize(stream);
			men.Clear();
			foreach (Man m in ma)
				men.Add(m);
			stream.Close();

		}

		void ReadXml()
		{
			fileName = Path.ChangeExtension(fileName, ".xml");
			// Создайте код, как рассказано ниже. Не забудьте закрыть файл
			XmlSerializer serializer = new XmlSerializer(typeof(List));
			TextReader sr = new StreamReader(fileName);
			men = (serializer.Deserialize(sr) as List).men;
			sr.Close();
		}

		public void Quit()
		{
			if (bModified)
			{
				Console.Write("\n\t\tList has been changed. Save (y/n)?  ");

				string s = Console.ReadLine();
				if (s.Equals("Y") || s.Equals("y"))
					Write();
			}
		}

		public void Sort()
		{
			if (men.Count == 0)
			{
				Console.WriteLine("\n\tList is empty");
				return;
			}
			switch (SortMenu())		// Установите режим сортировки
			{
				default: return;
				case 'n': Man.SortBy = SortMode.byName; break;
				case 'a': Man.SortBy = SortMode.byAge; break;
				case 's': Man.SortBy = SortMode.byStatus; break;
			}
			men.Sort();
			Show();
		}

		public void Work()
		{
			Console.WriteLine("\n\t\t Linear List");
			while (true)
			{
				switch (Menu())
				{
					case 'q': Quit(); return;
                    case 's': Show(); break;
                    case 'l': Console.WriteLine("\n Stud:_ \n Prof:_\n"); ShowLINQ(Console.ReadLine()); break;
					case 'a': Add(); break;
					case 'd': Delete(); break;
					case 'e': Edit(); break;
					case 't': Sort(); break;
					case 'r': Read(); break;
					case 'w': Write(); break;
					case 'h': Handle(); break;
                    case 'g': ListShow(); break;
				}
			}
		}

		public void Edit()
		{
			if (men.Count == 0)
			{
				Console.WriteLine("List is empty");
				return;
			}
			while (men.Count > 0)
			{
				Console.Write("\n\tEdit\t0...{0}  (0 - to Quit): ", men.Count);
				int n = Helper.AskInt("", 0, men.Count);
				if (n == 0)
					break;
				Console.Write("\nEdit ");
				this[n - 1].Edit();			// Здесь работает индексатор
				bModified = true;
				Show();
			}
		}
		public char Menu()
		{
			Console.Write("\n" +
				"\n\t\tq - Quit\tt - Sort" +
				"\n\t\ts - Show\tr - Read" +
				"\n\t\ta - Add \tw - Write" +
				"\n\t\td - Delete\te - Edit" +
				"\n\t\th - Handle\n\n"+
                "\n\t\tl - ShowLINQ\n"+
                "\n\t\tg - Show List properties\n");
			return Console.ReadLine().ToLower()[0];
		}

		public char SortMenu()
		{
			Console.Write("\n\t\tSorting\n" +
				"\n\t\tn - By Name" +
				"\n\t\ta - By Age" +
				"\n\t\ts - By Status" +
				"\n\t\tq - Quit\n\n");
			return Console.ReadLine().ToLower()[0];
		}

		public char ManMenu()
		{
			Console.Write(
				"\n\t\ts - Student" +
				"\n\t\tp - Professor" +
				"\n\t\tq - Quit\n\n");
			return (Console.ReadLine().ToLower())[0];
		}

		public char ShowMenu()
		{
			Console.Write(
				"\n\t\tf - First Names" +
				"\n\t\ts - Surnames" +
				"\n\t\tn - Normal" +
				"\n\t\tq - Don't show\n\n");
                
			return Console.ReadLine().ToLower()[0];
		}
		public char ReadWriteMenu()
		{
			Console.Write("\n" +
				"\n\t\tq - Quit" +
				"\n\t\tt - Text" +
				"\n\t\tb - Binary" +
				"\n\t\ts - Soap" +
				"\n\t\tx - XML\n\n");
			return Console.ReadLine().ToLower()[0];
		}

		void Handle()
		{
			if (men.Count == 0)
			{
				Console.WriteLine("List is empty");
				return;
			}
			switch (ShowMenu())
			{
				case 'q': return;
				case 'f':
					HandleMen("\n\tList of Man Names:", new Func<Man, string>(Man.Firstname));
					break;
				case 's':
					HandleMen("\n\tList of Man Surnames:", new Func<Man, string>(Man.Surname));
					break;
				case 'n': Show(); break;
			}
		}

		void HandleMen(string title, Func<Man, string> func)
		{
			Console.WriteLine(men.Count == 0 ? "\n\tList is empty\n" : title);
			for (int i = 0; i < men.Count; i++) 
				Console.WriteLine("  {0}. {1}", i + 1, func(men[i]));
		}

        void ShowLINQ( String temp)
        {
            IEnumerable<Man> q = from c in men
                                 where c.Class() == temp
                                 select c;

            Console.WriteLine("\n End Dump \n");

            foreach (var m in q)
            {
                m.Dump();
                Console.WriteLine("==========");
            }
        }

		// Индексатор (используется в методе Edit). Cоздайте его в качестве упражнения.
		public Man this[int id]
		{
			get
			{
				if (id < 0 || men.Count <= id)
					throw new ArgumentOutOfRangeException("Man.Indexer: Wrong id " + id);
				return men[id];
			}
			set
			{
				// Ваш код. Не забудьте про защиту от неправильных значений id
				if (id < 0 || men.Count <= id)
					throw new ArgumentOutOfRangeException("Man.Indexer: Wrong id " + id);
				men[id] = value;
			}
		}
	}

}
