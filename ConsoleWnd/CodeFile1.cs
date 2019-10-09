//using System;
//using System.Drawing;
//using System.Windows.Forms;
//using System.Drawing.Drawing2D;

//namespace ConsoleWnd
//{
//    public class MyForm1 : Form
//    {
//        Point[] pts, vel;
//        int rad, diam, id;
//        Timer timer;
//        Random rand;
//        bool erased, bDrawCurve;

//        public MyForm1()
//        {
//            bDrawCurve = erased = false;
//            id = -1;
//            rad = 8;
//            diam = rad * 2;
//            pts = new Point[] { 
//                new Point(20, 250), new Point(5, 50),
//                new Point(300, 300), new Point(250, 50)
//            };
//            vel = new Point[] { 
//                new Point(2, -2), new Point(10, 10),
//                new Point(-1, 1), new Point(1, -1)
//            };

//            Text = "My First Form";
//            BackColor = Color.FromArgb(255, 255, 200);
//            Width = 800;
//            Height = 500;
//            DoubleBuffered = true;//что бы избежать мерцания эл-та при перерисовке

//            timer = new Timer();
//            timer.Interval = 10;

//            rand = new Random(DateTime.Now.Millisecond);

//            Button btnStart = new Button();
//            btnStart.Text = "Start";
//            btnStart.Location = new Point(400, 50);
//            btnStart.Size = new Size(100, 25);
//            Controls.Add(btnStart);

//            Button btnClear = new Button();
//            btnClear.Text = "Clear";
//            btnClear.Location = new Point(400, 200);
//            btnClear.Size = new Size(100, 25);
//            Controls.Add(btnClear);

//            Button btnDraw = new Button();
//            btnDraw.Text = "Draw curve";
//            btnDraw.Location = new Point(400, 240);
//            btnDraw.Size = new Size(100, 25);
//            Controls.Add(btnDraw);

//            Paint += new PaintEventHandler(MyForm_Paint);//делегат.обраб событие пейнт класса контрол
//            MouseDown += new MouseEventHandler(MyForm_MouseDown);
//            MouseMove += new MouseEventHandler(MyForm_MouseMove);
//            MouseUp += new MouseEventHandler(MyForm_MouseUp);
//            btnStart.Click += new EventHandler(btnStart_Click);
//            btnClear.Click += new EventHandler(btnClear_Click);
//            timer.Tick += new EventHandler(timer_Tick);
//            btnDraw.Click += new EventHandler(btnDraw_Click);
//        }


//        void timer_Tick(object sender, EventArgs e)
//        {
//            for (int i = 0; i < pts.Length; i++)
//            {
//                pts[i].X += vel[i].X;
//                pts[i].Y += vel[i].Y;
//                if (pts[i].X < rad)
//                    vel[i].X = rand.Next(1, 30);
//                else if (pts[i].X > ClientSize.Width - rad)
//                    vel[i].X = -rand.Next(1, 30);
//                if (pts[i].Y < rad)
//                    vel[i].Y = rand.Next(1, 30);
//                else if (pts[i].Y > ClientSize.Height - rad)
//                    vel[i].Y = -rand.Next(1, 30);
//            }
//            Invalidate();
//        }

//        void btnClear_Click(object sender, EventArgs e)
//        {
//            erased = !erased;
//            (sender as Button).Text = erased ? "Draw all" : "Clear all";
//            Invalidate();
//        }

//        void btnStart_Click(object sender, EventArgs e)
//        {
//            Button btn = sender as Button;
//            if (timer.Enabled)
//            {
//                timer.Stop();
//                btn.Text = "Start";
//            }
//            else
//            {
//                timer.Start();
//                btn.Text = "Stop";
//            }
//        }

//        void MyForm_MouseUp(object sender, MouseEventArgs e)
//        {
//            id = -1;
//        }

//        void MyForm_MouseMove(object sender, MouseEventArgs e)
//        {
//            if (id != -1)
//            {
//                pts[id].X = e.X;
//                pts[id].Y = e.Y;
//                Invalidate();
//            }
//        }

//        void MyForm_MouseDown(object sender, MouseEventArgs e)
//        {
//            for (int i = 0; i < pts.Length; i++)
//            {
//                if (Math.Abs(pts[i].X - e.X) < rad && Math.Abs(pts[i].Y - e.Y) < rad)
//                {
//                    id = i;
//                    break;
//                }
//            }
//        }

//        void btnDraw_Click(object sender, EventArgs e)
//        {
//            bDrawCurve = !bDrawCurve;
//            (sender as Button).Text = bDrawCurve ? "Erase curve" : "Draw curve";
//            Invalidate();

//        }

//        private void DrawCurve(Graphics g)
//        {
//            g.DrawString("Wannadraw?\r\nOK.", Font, Brushes.Purple, 100, 50);

//            PointF[] pts = {
//                new PointF (20.0F, 150.0F), new PointF (250.0F, 200.0F),
//                new PointF (100.0F, 80.0F), new PointF (100.0F, 250.0F)};

//            g.DrawLines(new Pen(Color.BlueViolet, 1), pts);
//            g.DrawClosedCurve(new Pen(Color.Coral, 3), pts, 1.0F, FillMode.Alternate);
//        }


//        void MyForm_Paint(object sender, PaintEventArgs e)
//        {
//            if (!erased)
//            {

//                Form f = (Form)sender;	// Параметр нам не нужен, но интересно, что в нем. Просто убедитесь, что это — ссылка на объект MyForm
//                Graphics g = e.Graphics;
//                Brush br = new LinearGradientBrush(new Point(10, 10), new Point(300, 10),
//                        Color.Violet, Color.Yellow);
//                g.DrawString("We are painting", new Font("Arial", 28), br, 20, 260);
//                g.DrawBezier(new Pen(br, 10), pts[0], pts[1], pts[2], pts[3]);
//                foreach (Point p in pts)
//                    g.FillEllipse(Brushes.Red, p.X - rad, p.Y - rad, diam, diam);
//                g.DrawLine(Pens.Black, pts[0], pts[1]);
//                g.DrawLine(Pens.Black, pts[2], pts[3]);
//                br.Dispose();
//                if (bDrawCurve)
//                    DrawCurve(g);
//            }
//        }


//        static void Main()
//        {
//            MyForm1 form = new MyForm1();
//            //Application.AddMessageFilter(new Filter(form));
//            Application.Run(form);
//        }


//    }


//}