using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Library
{
    public partial class FormValues : Form
    {
        public FormValues(string msg, List<string[]> list)
        {
            InitializeComponent();
            lblCaption.Text = msg;
            foreach(string[] s in list)
            listValues.Items.Add(new ListViewItem( new string[] {s[0], s[1]})); 
        }

    }
}
