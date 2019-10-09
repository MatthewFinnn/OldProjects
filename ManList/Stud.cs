using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManList
{
	[Serializable]
	public class Stud : Man
	{
		
		public override string Class() { return "Stud: "; }


		
		protected int course;
		static int maxCourse = 6;

		public int Course
		{
			get { return course; }
			set { Helper.MakeInt(value.ToString(),0,maxCourse,out course); }
		}

		public static int MaxCourse
		{

			get { return maxCourse; }
			set { maxCourse = value; }
		}
		

		public Stud() : base() { course = 0; }		// Default constructor
		public Stud(string n, int a, int c) : base(n, a) { course = c; }	//  Useful constructor
		
		public Stud(Stud stud) : base(stud)
		{
			this.course = stud.course;
		}
		
		
		public override void In()
		{
			Console.Write(Class());
			base.In();		// Вызов родительской версии
			course = Helper.AskInt("Course: ", 0, maxCourse);
		}

		
		

		public override void Read(string[] tokens) // Выбор данных из уже разобранной строки (массива лексем)
		{
			// Здесь работает свойство, которое пользуется методом GetName для защиты от плохого ввода
			base.Read(tokens);
			Helper.MakeInt(tokens[5], 0, maxCourse, out course); 
		}


		public override string ToString()
		{
			return Class() + base.ToString() + ";  Course: " + course;
		}

	}
}
