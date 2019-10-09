using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading;

namespace Images
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Click += new EventHandler(button1_Click);

        }



        void button1_Click(object sender, EventArgs e)
        {
            int count = 0;
            for (int i = 1; i < 2000; i++)
            {
                try
                {
                    string url = "http://xkcd.ru/i/" + i + "_v5.png"; // URL изображения
                    // создаем запрос
                    WebRequest request = FileWebRequest.Create(url);
                    // создаем прокси и настраиваем
                    //WebProxy proxy = new WebProxy("localhost", 8080);
                    //string userName = "";
                    //string password = "";
                    //string domain = "";
                    //proxy.Credentials = new NetworkCredential(userName, password, domain);
                    //request.Proxy = proxy;
                    // создаем поток на основе запроса через прокси
                    Stream stream = request.GetResponse().GetResponseStream();
                    // создаем изображение на основе потока
                    Image image = Image.FromStream(stream);
                    // здесь делайте с image, что вашей душе угодно
                    image.Save("D:\\Images\\" + i + "_v5.jpg");
                    count += 1;
                    label1.Text = count.ToString();
                }
                catch { }

            }

            
        }
    }
}
