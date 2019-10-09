using System;
using System.Windows.Forms;

namespace ConsoleWnd
{
	class Program
	{
		static void Main()
		{
			MyForm f1 = new MyForm(), f2 = new MyForm();
			f1.Text = "First"; f2.Text = "Second";
			f2.Visible = true;
			Application.Run(f1);
			MessageBox.Show("App has ended");

		}
	}
}
