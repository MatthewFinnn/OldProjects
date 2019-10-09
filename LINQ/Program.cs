using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace LINQ
{
    class Program
    {
        static void Main()
        {

            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
            foreach (var v in cultures)
                Console.WriteLine("{0,52}  {1}", v.EnglishName, v.IetfLanguageTag);
            Console.ReadKey();
        }
    }
}
