using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Reflection;

namespace ManList
{
    // расширяем класс Object. добавляем метод IsIn. Проверяет вхождение "object o" в  "IEnumerable en"
    public static class Extender
    {
        public static bool IsIn(this object o, IEnumerable en)
        {
            foreach (var c in en)
                if (c.Equals(o))
                    return true;
            return false;
        }
        public static T Median<T>(this IEnumerable<T> col)
        {
            return col.ToArray()[col.Count() / 2];
        }

        // The first argument of an extension method must use the this modifier
        public static void Dump(this object o)
        {
            PropertyInfo[] properties = o.GetType().GetProperties();
            foreach (PropertyInfo p in properties)
            {
                try
                {
                    Console.WriteLine(string.Format("{0}  -->  {1}",
                      p.Name, p.GetValue(o, null)));
                }
                catch
                {
                    Console.WriteLine(string.Format("{0}  -->  {1}", p.Name, "unknown"));
                }
            }
        }

        public static void Dump(this IList list)
        {
            foreach (object o in list)
                o.Dump();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
             (new List()).Work();

        }



        static void Main34()
        {
            int[] a = { 1, 2, 3, 4, 5, 6 };

            IEnumerable<int> q = from c in a
                                 where c % 2 == 1
                                 select c;
            
            foreach (var d in q)
                Console.WriteLine(d + ", ");

            Console.WriteLine("15.IsIn(a) = {0}", 15.IsIn(a));
            DateTime dt = DateTime.Now;
            Console.WriteLine("Dump data");
            dt.Dump();

            Console.WriteLine("\n\n");
            Console.WriteLine("Dump int");
            a.Dump();
            Console.WriteLine("\n\n");
            //Person[] pp = { 
            //  new Person("A",Gender.M, DateTime.Now.AddYears(-30), "555-5555"),
            //  new Person("B",Gender.F, DateTime.Now.AddYears(-18), "444-5555"),
            //};


            //pp.Dump();

            int m = a.Median();


            foreach (var c in q)
                Console.Write(c + ", ");
            int n = 0;
            Console.ReadKey();
        }
    }
}




//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Collections;
//using System.Reflection;

//namespace TLINQ
//{

//  class Program
//  {
//}
