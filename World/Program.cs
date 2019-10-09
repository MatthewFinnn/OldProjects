using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace World
{
    class Program
    {
        static void Main()
        {
            string url = "http://teron.ru/uploads/av-2171.jpg"; // URL изображения
            // создаем запрос
            WebRequest request = FileWebRequest.Create(url);
            // создаем прокси и настраиваем
            WebProxy proxy = new WebProxy("localhost", 8080);
            string userName = "";
            string password = "";
            string domain = "";
            proxy.Credentials = new NetworkCredential(userName, password, domain);
            request.Proxy = proxy;

            // здесь делайте с image, что вашей душе угодно
        }
    }
}
