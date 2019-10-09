using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ConsoleWnd
{
	class MyForm : Form
	{
		bool 
			bDrawCurve = false, 
			bEraseGrp = false;
		int rad = 5;
		int activ = 5;
		Timer fstTimer = new Timer();
		bool bTimer = false;
		Rectangle clRect = new Rectangle();
		Random r = new Random();

		PointF[] vMove = { new Point(0, 0), new Point(0, 0), new Point(0, 0), new Point(0, 0) };


		PointF[] pts = { new Point(20, 250), new Point(5, 50), new Point(300, 300), new Point(250, 50) };
		PointF[] ptsClosedCurve = { new Point(420, 450), new Point(405, 250), new Point(700, 500), new Point(650, 250) };


		public MyForm()
		{
			Text = "MyForm";
			Width = 1100;
			Height = 600;
			clRect = ClientRectangle;
			BackColor = Color.LavenderBlush;
			DoubleBuffered = true;
			fstTimer.Interval = 30;

			Button btnDraw = new Button();
			btnDraw.Text = "Draw curve";
			btnDraw.Size = new Size(80, 25);
			btnDraw.Location = new Point(5, 10);
			Controls.Add(btnDraw);


			Button btnErase = new Button();
			btnErase.Text = "Erase";
			btnErase.Size = new Size(80, 25);
			btnErase.Location = new Point(5, 40);
			Controls.Add(btnErase);

			Button btnMove = new Button();
			btnMove.Text = "Move";
			btnMove.Size = new Size(80, 25);
			btnMove.Location = new Point(5, 70);
			Controls.Add(btnMove);

			Button btnRegion = new Button();
			btnRegion.Text = "Region";
			btnRegion.Size = new Size(80, 25);
			btnRegion.Location = new Point(5, 100);
			Controls.Add(btnRegion);

			Resize += new EventHandler(MyForm_Resize);
			MouseDown += new MouseEventHandler(MyForm_MouseDown);
			MouseUp += new MouseEventHandler(MyForm_MouseUp);
			MouseMove += new MouseEventHandler(MyForm_MouseMove);
			Paint += new PaintEventHandler(MyForm_PaintHandler); 	// Добавляем делегата
			btnDraw.Click += new EventHandler(btnDraw_Click);
			btnErase.Click += new EventHandler(btnErase_Click);
			btnMove.Click += new EventHandler(btnMove_Click);
			fstTimer.Tick += new EventHandler(fstTimer_Tick);
			btnRegion.Click += new EventHandler(btnRegion_Click);
		}

		void btnRegion_Click(object sender, EventArgs e)
		{
				Region = new Region(GetStringPath());
		}

		GraphicsPath GetStringPath()
		{
			GraphicsPath path = new GraphicsPath();
			path.AddString("Outline", new FontFamily("Sylfaen"), 0, 100,
				new Point(10, -30), StringFormat.GenericTypographic);
			return path;
		}

		protected override bool ProcessKeyPreview(ref Message m)
		{
			if (m.Msg == 0x0100) // 0x0100 - Код сообщения WM_KEYDOWN
				Region = null;
			return base.ProcessKeyPreview(ref m);
		}


		void MyForm_Resize(object sender, EventArgs e)
		{
			clRect = ClientRectangle;
		}

		void btnMove_Click(object sender, EventArgs e)
		{
			bTimer = !bTimer;
			((Button)sender).Text = !bTimer ? "Start" : "Stop";
			if (bTimer)
				fstTimer.Start();
			else
				fstTimer.Stop();

			for (int i = 0; i < 4; i++)
				vMove[i] = new PointF(r.Next(10) - r.Next(10), r.Next(10) - r.Next(10));
		}

		void fstTimer_Tick(object sender, EventArgs e)
		{
			FindOut();
			for (int i = 0; i < 4; i++)
			{
				pts[i].X += vMove[i].X;
				pts[i].Y += vMove[i].Y;
			}
			Invalidate();
		}
		void FindOut()
		{
			for (int i = 0; i < 4; i++)
			{
				if ((pts[i].X + vMove[i].X) <= clRect.Left - rad)
				{
                    vMove[i].X = r.Next(1, 10);
					pts[i].X = clRect.Left + 1;
				}
				if ((pts[i].X + vMove[i].X) >= clRect.Right - rad - 2)
				{
					vMove[i].X = -r.Next(1,10);
					pts[i].X = clRect.Right - 1;
				}
				if ((pts[i].Y + vMove[i].Y) <= clRect.Top - rad - 2)
				{
                    vMove[i].Y = r.Next(1, 10);
					pts[i].Y = clRect.Top + 1;
				}
				if ((pts[i].Y + vMove[i].Y) >= clRect.Bottom - rad - 2)
				{
                    vMove[i].Y = -r.Next(1, 10);
					pts[i].Y = clRect.Bottom - 1;
				}

			}

		}

		void MyForm_MouseMove(object sender, MouseEventArgs e)
		{
			if (activ != 5)
			{
				pts[activ].X = e.X;
				pts[activ].Y = e.Y;
				Invalidate();
			}
		}

		void MyForm_MouseUp(object sender, MouseEventArgs e)
		{
			activ = 5;
		}

		void MyForm_MouseDown(object sender, MouseEventArgs e)
		{
			for (int i = 0; i < 4; i++)
				if (Math.Abs((pts[i].X - e.X) * (pts[i].X - e.X) + (pts[i].Y - e.Y) * (pts[i].Y - e.Y)) <= 25)
					activ = i;
		}

		void btnErase_Click(object sender, EventArgs e)
		{
			((Button)sender).Text = bEraseGrp ? "Erase" : "Draw";
			bEraseGrp = !bEraseGrp;
			Invalidate();

		}

		void DrawCurve(Graphics g)
		{
			g.DrawString("Wannadraw?\r\nOK.", Font, Brushes.Purple, 400, 200);
			g.DrawLines(new Pen(Color.BlueViolet, 1), ptsClosedCurve);
			g.DrawClosedCurve(new Pen(Color.Coral, 3), ptsClosedCurve, 1.0F, FillMode.Alternate);
		}

		void btnDraw_Click(object sender, EventArgs e)
		{
			bDrawCurve = !bDrawCurve;
			((Button)sender).Text = bDrawCurve ? "Erase curve" : "Draw curve";
			Invalidate();
		}

		void MyForm_PaintHandler(object sender, PaintEventArgs e)
		{
		
			if (!bEraseGrp)
			{
				Graphics g = e.Graphics;
				Brush brText = new LinearGradientBrush(new Point(10, 10), new Point(200, 400), Color.Violet, Color.Yellow);
				Brush br = new LinearGradientBrush(pts[1], pts[2], Color.Violet, Color.Yellow);

				g.DrawString("We are painting", new Font("Arial", 28), brText, 120, 10);
				g.DrawBezier(new Pen(br, 10), pts[0], pts[1], pts[2], pts[3]);
				g.DrawLine(new Pen(Color.BlueViolet, 2), pts[0], pts[1]);
				g.DrawLine(new Pen(Color.BlueViolet, 2), pts[2], pts[3]);
				foreach (PointF p in pts)
					g.FillEllipse(Brushes.Red, p.X - rad, p.Y - rad, rad * 2, rad * 2);
				if (bDrawCurve)
					DrawCurve(g);
				br.Dispose();
				brText.Dispose();
			}
		}

		public static void Main()
		{
			Application.Run(new MyForm());
		}


	}


}
