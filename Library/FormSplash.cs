using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Library
{
    [ComVisible(false)]
    public partial class FormSplash : Form
    {
        static FormSplash form = null;
        static Thread thread = null;
        static string message;
        System.Windows.Forms.Timer timer;
        double deltaOpacity;

        FormSplash()
        {
            InitializeComponent();
            Opacity = 0.0;
            deltaOpacity = 0.02;
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 3;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }
        public static void ShowForm(string msg)
        {
            if (form != null)
                return;
            message = msg;
            thread = new Thread(FormSplash.StartApp);
            thread.IsBackground = true;
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
        static void StartApp()
        {
            form = new FormSplash();
            form.lblMsg.Text = message;
            Application.Run(form);
        }

        public static void CloseForm()
        {
            if (form != null)
                form.deltaOpacity = -form.deltaOpacity; // Форма начинает угасать
            form = null;			// Форма может быть уничтожена сборщиком мусора
            thread = null;			// Поток закончил свое существование
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (deltaOpacity > 0 && Opacity < 1 || deltaOpacity < 0 && Opacity > 0)
                Opacity += deltaOpacity; // Форма изменяет степень своей непрозрачности (opacity)

            if (deltaOpacity == 0.0)
                timer.Stop();
        }

        public static void AddItem(string msg)
        {
            ListBox box = form.listItem;
            if (box.InvokeRequired)
                box.Invoke(new Action<string>(AddItem), new object[] { msg });
            else
            {
                box.Items.Add(" " + msg);
                box.SelectedIndex = box.Items.Count - 1;
            }
        }

        public static void AddMsg(string msg)
        {
            ListBox box = form.listMsg;
            if (box.InvokeRequired)
                box.Invoke(new Action<string>(AddMsg), new object[] { msg });
            else
            {
                box.Items.Add(" " + msg);
                box.SelectedIndex = box.Items.Count - 1;
                int val = form.progress.Value + 15;
                if (val > 100)
                    val = 100;
                form.progress.Value = val;
            }
        }
    }
}
