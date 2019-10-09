
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace StudentsOleDb
{
    public class FormMsg : Form
    {
        Label lbl;
        Timer timer;

        public FormMsg(string msg, int interval)
        {
            StringBuilder text = new StringBuilder();
            for (int i = 0; i < msg.Length; i++)
            {
                text.Append(msg[i]);
                if ((i + 1) % 80 == 0)
                    text.Append('\n');
            }
            timer = new Timer();
            timer.Interval = interval;
            timer.Tick += (s, e) => { Dispose(); };

            lbl = new Label();
            lbl.Font = new Font("Tahoma", 10.0F);
            lbl.ForeColor = Color.Yellow;
            lbl.Padding = new Padding(12, 5, 12, 12);
            lbl.Text = text.ToString();
            lbl.AutoSize = true;
            lbl.Paint += (s, e) => { e.Graphics.DrawRectangle(Pens.Yellow, 5, 5, lbl.Width - 7, lbl.Height - 10); };
            Controls.Add(lbl);

            BackColor = Color.Black;
            FormBorderStyle = FormBorderStyle.None;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            TopMost = true;
            Load += (s, e) =>
            {
                Form form = Application.OpenForms[0];
                Left = form.Left + 75;
                Top = form.Top + 75;
                timer.Start();
            };
            Show();
            Update();
        }
    }
}
