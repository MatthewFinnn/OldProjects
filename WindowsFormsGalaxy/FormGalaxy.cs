using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using ZedGraph;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using System.Reflection;


namespace WindowsFormsGalaxy
{
    public partial class FormGalaxy : Form
    {
        #region Data
        CurrencyManager cm;
        static GalaxyList cl = new GalaxyList();
        string newFind;
        string oldFind;
        DetectList det = new DetectList();
        string oldNum;
        #endregion

        public void FindButt(object sender, EventArgs e)
        {
            newFind = FindString.Text;
            if (newFind != oldFind)
            {
                det.Find(cm, newFind);
            }
            Point celPoint = new Point();
            if (det.Show(grid.Columns, out celPoint))
            {
                DataGridViewCell cell = grid.Rows[celPoint.Y].Cells[celPoint.X];
                cm.Position = celPoint.Y;
                grid.CurrentCell = cell;
            }
            else
            {
                MessageBox dial;
                
            }
            oldFind = newFind;
        }
        

        public FormGalaxy()
        {
            cl.Galax.Add(new Galaxy());
            cl.Galax.Add(new Galaxy());
            InitializeComponent();
            FormGalaxy_Load(new Object(), new EventArgs());
            toolStrip1.ItemClicked +=new ToolStripItemClickedEventHandler(toolStrip1_ItemClicked);
            picBox.DoubleClick +=new EventHandler(picBox_DoubleClick);
            cm.CurrentChanged += new EventHandler(cm_CurrentChanged);
            cm.Refresh();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)//sender
        {
            switch (e.ClickedItem.Text)
            {
                case "First": cm.Position = 0; break;
                case "Prev": cm.Position--; break;
                case "Next": cm.Position++; break;
                case "Last": cm.Position = cl.Galax.Count - 1; break;
                case "Open": toolStripButton5_Click(new Object(), new EventArgs()); break;
                case "Save": toolStripButton7_Click(new Object(), new EventArgs()); break;
                case "Find": FindButt(new Object(), new EventArgs()); break;
            }
        }
        

        private void FormGalaxy_Load(object sender, EventArgs e)
        {
            AddStyle();
            DoBindings();
            
            TopMost = false;
        }

        void DoBindings()
        {
            grid.DataSource = cl.Galax; // Привязываем компонент DataGridView к коллекции данных в памяти
			cm = grid.BindingContext[cl.Galax] as CurrencyManager;
			cm.CurrentChanged += new EventHandler(cm_CurrentChanged);
			propGrid.DataBindings.Clear();		// Этот оператор понадобится при повторной привязке у данным
			propGrid.DataBindings.Add("SelectedObject", cl.Galax, "",true, DataSourceUpdateMode.OnPropertyChanged);
			picBox.DataBindings.Clear();
            picBox.DataBindings.Add("Image", cl.Galax, "Photo", true, DataSourceUpdateMode.OnPropertyChanged);
            graphGh();
        }

        void cm_CurrentChanged(object sender, EventArgs e)
        {
            if (cm.Count > 0) propGrid.SelectedObject = cm.Current;

            zgc1.GraphPane.Title.Text = "Светимость галактики";
            zgc1.GraphPane.XAxis.Title.Text = "Имя";
            zgc1.GraphPane.YAxis.Title.Text = "Светимость";
            string[] names = new string[cl.Galax.Count()];
            double[] luminosity = new double[cl.Galax.Count()];
            for (int i = 0; i < cl.Galax.Count(); i++)
            {
                names[i] = cl.Galax[i].Name;
                luminosity[i] = cl.Galax[i].Luminosity/Galaxy.MinLuminosity;
            }
            zgc1.GraphPane.CurveList.Clear();
            BarItem myBar = zgc1.GraphPane.AddBar("Светимость относительно светимости солнца", null, luminosity, Color.Blue);

            zgc1.GraphPane.XAxis.Title.Text = "Names";
            zgc1.GraphPane.XAxis.Type = AxisType.Text;
            zgc1.GraphPane.GraphObjList.Clear();
            int ind = cm.Position;

            zgc1.AxisChange();
            DoBindings();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            SaveFileDialog sd = new SaveFileDialog();
            sd.Filter = "XML file|*.xml";
            sd.Title = "Сохранить базу данных";
            if (sd.ShowDialog() == DialogResult.OK)
                cl.WriteXml(sd.FileName);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            od.Filter = "XML file|*.xml";
            od.Title = "Открыть базу данных";
            if (od.ShowDialog() == DialogResult.OK)
            {
                cl.ReadXml(od.FileName);
                DoBindings();
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            cl.Galax.Clear();
            cl.Galax.Add(new Galaxy());
            DoBindings();
        }

      

        private void grid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewCell activeCell = (DataGridViewCell)grid.Rows[e.RowIndex].Cells[e.ColumnIndex];
            oldNum = activeCell.Value.ToString();
        }

        private void picBox_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            od.Filter = "jpg file|*.jpg";
            od.Title = "Открыть фото";
            od.ShowDialog();
            string newPictureName = od.FileName;
            newPictureName = newPictureName.Substring(newPictureName.LastIndexOf('\\') + 1);
            newPictureName = newPictureName.Substring(0, newPictureName.LastIndexOf('.'));

            int id = cm.Position;
            cl.list.ElementAt(id).PhotoFile = Path.GetFileName(od.FileName);
            Refresh();
            DoBindings();

        }

        private void propGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            cm.Refresh();
            graphGh();
        }

        private void graphGh()
        {
            zgc1.GraphPane.CurveList.Clear();
            string[] names = new string[cl.Galax.Count()];
            double[] luminosity = new double[cl.Galax.Count()];
            for (int i = 0; i < cl.Galax.Count(); i++)
            {
                names[i] = cl.Galax[i].Name;
                luminosity[i] = cl.Galax[i].Luminosity/Galaxy.MinLuminosity;
            }
            zgc1.GraphPane.AddBar("Светимость", null, luminosity, Color.Aquamarine);
            zgc1.AxisChange();
            zgc1.Refresh();
            grid.Invalidate();



        }


        private void AddStyle()
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.BackColor = Color.Aqua;
            grid.AlternatingRowsDefaultCellStyle = style;

            DataGridViewCellStyle selStyle = new DataGridViewCellStyle();
            selStyle.BackColor = Color.Coral;
            grid.AutoGenerateColumns = false;
            grid.DefaultCellStyle = selStyle;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;


            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();

            
            col.DataPropertyName = "Name";
            col.HeaderText = "Name";
            
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            grid.Columns.Add(col);

            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            combo.DataSource = Enum.GetValues(typeof(GalaxyType));
            combo.DataPropertyName = "Type";
            combo.HeaderText = "Type";
            combo.Width = 60;
            grid.Columns.Add(combo);

            //CalendarColumn
            CalendarColumn colend = new CalendarColumn();
            colend.DataPropertyName = "Discovered";
            colend.HeaderText = "Discovered";
            colend.Width = 110;
            grid.Columns.Add(colend);

            col = new DataGridViewTextBoxColumn();
            col.DataPropertyName = "Rad";
            col.HeaderText = "Rad";
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            grid.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.DataPropertyName = "Thic";
            col.HeaderText = "Thic";
            col.Width = 100;
            grid.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.DataPropertyName = "Luminosity";
            col.HeaderText = "Luminosity";
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            grid.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.DataPropertyName = "PhotoFile";
            col.HeaderText = "Photo File";
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid.Columns.Add(col);



        }



    }
}

        //private void grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{
        //    DataGridViewCell activeCell = (DataGridViewCell)grid.Rows[e.RowIndex].Cells[e.ColumnIndex];
        //    int col = activeCell.ColumnIndex;
        //    string text = activeCell.Value.ToString();
        //    string newTxt = "";
        //    if (col == 0) //Name 
        //    {
        //        Regex regex = new Regex(@"^[А-Я]{1}[а-я]{0,}$");
        //        if (regex.IsMatch(text))
        //            for (int i = 0; i < regex.Matches(text).Count; i++)
        //                newTxt += regex.Matches(text)[i].ToString();
        //        else
        //            newTxt = oldNum;
        //        activeCell.Value = newTxt;
        //    }

        //    if (col == 1)//PhotoFile 
        //    {
        //        Regex regex = new Regex(@"\w+.jpg");
        //        if (regex.IsMatch(text))
        //            for (int i = 0; i < regex.Matches(text).Count; i++)
        //                newTxt += regex.Matches(text)[i].ToString();
        //        else
        //            newTxt = oldNum;
        //        activeCell.Value = newTxt;
        //    }

        //    // 2 - Type

        //    if (col == 3)//Discovered 
        //    {
        //        Regex regex = new Regex(@"^[0-9]{1,2}.[0-9]{1,2}.[0-9]{4}$");
        //        if (regex.IsMatch(text))
        //            for (int i = 0; i < regex.Matches(text).Count; i++)
        //                newTxt += regex.Matches(text)[i].ToString();
        //        else
        //            newTxt = oldNum;
        //        activeCell.Value = newTxt;
        //    }
        //    if (col == 4 || col == 5 || col == 6) //Rad4, Thic5, Luminosity6
        //    {
        //        Regex regex = new Regex(@"^[0-9]{1,}$");
        //        if (regex.IsMatch(text))
        //            for (int i = 0; i < regex.Matches(text).Count; i++)
        //                newTxt += regex.Matches(text)[i].ToString();
        //        else
        //            newTxt = oldNum;
        //        activeCell.Value = newTxt;
        //    }

        //}