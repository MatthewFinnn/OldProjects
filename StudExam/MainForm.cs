using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using MainForm;
using System.Text.RegularExpressions;

namespace StudExam
{

    public partial class MainForm : Form
    {
        #region Init
        BindingSource bsStuds, bsExams;
        static string[] courses = { "Math", "Mechanics", "Physics", "English", "Oracle", "OpenGL", "History" };
        Random rand = new Random();
        protected String fileName;
        protected String dir;
        protected DataSet ds = new DataSet();
        #endregion


        private void InitTables()
        {
            object[] studs = {
			new object[] {1, "Charlie Parker", "123-4455", "Broadway, 52a"},
			new object[] {2, "Alex Black", "555-1122", "5-th Avenue, 74" },
			new object[] {3, "Andy Williams", "430-5125", "Back st., 22" },
			new object[] {4, "Charley Mingus", "230-1466", "Hi st., 30" },
			new object[] {5, "Chet Baker", "320-8656", "Howard st., 15" },
			new object[] {6, "Lou Rowles", "552-4233", "Basin st., 10" },
		};
            foreach (object[] o in studs)
                ds.Tables[0].Rows.Add(o);



            foreach (object[] stud in studs)
            {
                int num = 0;
                foreach (string c in courses)
                {
                    if (num++ != rand.Next(courses.Length))
                        ds.Tables[1].Rows.Add(CreateRandomExam((int)stud[0], c));
                }
            }

        }
        private object[] CreateRandomExam(int s, string c)
        {
            return new object[] { rand.Next(65000), s, c, rand.Next(10), rand.Next(10), DateTime.Now };
        }
        void studs_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            DataTable exams = ds.Tables[1];		// Ссылка на подчиненную таблицу экзаменов
            if (e.Action == DataRowAction.Add)	// Если в таблице студентов появилась новая строка
            {
                int num = 0;
                foreach (string c in courses)	// Массив с именами предметов должен существовать
                {
                    if (num++ != rand.Next(courses.Length))
                        ds.Tables[1].Rows.Add(CreateRandomExam((int)e.Row["ID"], c));
                }
            }
        }
        private void InitDataSet()
        {
            ds = new DataSet("StudentsSet"); 
            DataTable studs = new DataTable("Studs"); 
            SetPrimaryColumn(studs);	

            //======= Определяем схему таблицы
            studs.Columns.Add("Name");
            studs.Columns.Add("Phone");
            studs.Columns.Add("Addr");
            

            DataTable exam = new DataTable("Exam");
            SetPrimaryColumn(exam);
            exam.Columns.Add("StudID", typeof(int));
            exam.Columns.Add("Course");
            exam.Columns.Add("Credit");
            exam.Columns.Add("Mark", typeof(byte));
            exam.Columns.Add("Date");

            ds.Tables.Add(studs);	
            ds.Tables.Add(exam);


            
            
        }
        void SetPrimaryColumn(DataTable table)
        {
            DataColumn dc = new DataColumn("ID", typeof(int));
            dc.AutoIncrement = true;
            dc.AutoIncrementSeed = 1;
            dc.ReadOnly = true;
            table.Columns.Add(dc);
            table.PrimaryKey = new DataColumn[] { dc };
        }
        void AddStyle(DataGridView grid, int tableID)
        {
            grid.AutoGenerateColumns = false;
            DataColumnCollection cols = ds.Tables[tableID].Columns;
            foreach (DataColumn dc in cols)
            {
                DataGridViewColumn col = null;
                if (dc.DataType == typeof(bool))
                    col = new DataGridViewCheckBoxColumn();
                else if (dc.DataType == typeof(DateTime))
                {
                    col = new CalendarColumn();
                    col.DefaultCellStyle.Format = "d";
                }
                else if (dc.DataType == typeof(decimal))
                {
                    col = new DataGridViewTextBoxColumn();
                    col.DefaultCellStyle.Format = "f2";
                }
                else if (dc.ColumnName == "Course")
                {
                    DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
                    combo.DataSource = courses;
                    col = combo;
                }
                else if (dc.ColumnName == "Mark")
                {
                    dc.DefaultValue = (byte)2;
                    DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
                    combo.Items.Add((byte)2);
                    combo.Items.Add((byte)3);
                    combo.Items.Add((byte)4);
                    combo.Items.Add((byte)5);
                    col = combo;
                }
                else
                    col = new DataGridViewTextBoxColumn();

                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                if (dc == cols[cols.Count - 1])
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.DataPropertyName = dc.ColumnName;
                col.HeaderText = dc.ColumnName;
                grid.Columns.Add(col);
            }
            grid.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
            grid.DefaultCellStyle.SelectionForeColor = Color.Black;
            grid.AlternatingRowsDefaultCellStyle.BackColor = tableID == 0 ? Color.Wheat : Color.FromArgb(200, 255, 200);
        }
      


        public MainForm()
        {
            InitializeComponent();
            fileName = "Students.xml"; // Имя файла по умолчанию
            dir = FindFolder("Data");
            SetDesktopLocation(100, 80); 	// Позиция формы на рабочем столе
            InitDataSet();		// 
            InitTables();		// Заполнение таблиц DataTable 
            RelateAndBind();	// Связывание таблиц DataTable 

            bn.ItemClicked += new ToolStripItemClickedEventHandler(bn_ItemClicked);
            ds.Tables[0].RowChanged += new DataRowChangeEventHandler(studs_RowChanged);
            ds.Tables[0].RowChanged += new DataRowChangeEventHandler(MainForm_RowChanged);
            comboFind.TextUpdate +=new EventHandler(comboFind_TextUpdate);
            comboFind.KeyDown +=new KeyEventHandler(comboFind_KeyDown);
        }

        void MainForm_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            ds.Tables[0].RowChanged -= new DataRowChangeEventHandler(MainForm_RowChanged);
            e.Row["Name"] = Trim(e.Row["Name"].ToString());
            ds.Tables[0].RowChanged += new DataRowChangeEventHandler(MainForm_RowChanged);
        }

        void bn_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "&Открыть": Open(FileDlg(true)); break;
                case "&Сохранить": Save(FileDlg(false)); break;
                case "Find Next": Find(); break;
                //case "Find List": ShowList(GetSearchCriteria()); break;
                //case "Find View": ShowGrid(GetSearchCriteria()); break;
                //case "Average": ShowAverage(); break;
            }
        }

        string Trim(string s)
        {
            return new Regex(@"\s{2,}").Replace(s.Trim(), " ");
        }




        //Запись и чтение данных
        #region SaveReadData
        void Save(string fn)
        {
            if (fn != null && ds.Tables[0].Rows.Count != 0)
            {
                ds.WriteXml(fn);
                SetPath(fn);
            }
        }

        string FileDlg(bool bOpen)
        {
            FileDialog dlg = bOpen ? (FileDialog)new OpenFileDialog() : (FileDialog)new SaveFileDialog();
            dlg.InitialDirectory = dir;
            dlg.Filter = "XML files (*.xml)|*.xml";
            dlg.FileName = fileName;
            return dlg.ShowDialog() == DialogResult.OK ? dlg.FileName : null;
        }

        void Open(string fn)
        {
            if (fn != null)
            {
                ds.Clear();
                ds.ReadXml(fn);
                SetPath(fn);
                ds.AcceptChanges();
            }
        }

        void SetPath(string fn)
        {
            Text = fn;
            dir = Path.GetDirectoryName(fn);
            fileName = Path.GetFileName(fn);
        }

        string FindFolder(string name)
        {
            string dir = Application.StartupPath;
            for (char slash = '\\'; dir != null; dir = Path.GetDirectoryName(dir))
            {
                string res = dir.TrimEnd(slash) + slash + name;
                if (Directory.Exists(res))
                    return res + slash;
            }
            return null;
        }

        #endregion

        #region FIND

        void Find()
        {
            string what = Trim(comboFind.Text);
            DataRow[] rows = ds.Tables[0].Select("Name LIKE '" + what + "*'");
            if (rows.Length == 0)
            {
                new FormMsg("Could not find Name LIKE " + what, 2000);
                return;
            }
            if (!comboFind.Items.Contains(what))
                comboFind.Items.Add(what);	// Запоминаем искомую строку в ComboBox ObjectCollection
            int i;   // Ищем индекс строки по факту совпадения реальной ячейки с полем найденной строки
            for (i = 0; i < gridStud.Rows.Count; i++)
            {
                if (gridStud[1, i].Value.ToString() == rows[0]["Name"].ToString())
                    break;
            }
            gridStud.CurrentCell = gridStud[1, i];	// Выделяем первую ячейку в первой из найденных строк
            gridStud.Rows[i].Selected = true;			// Выделяем всю строку
        }

        
        
        void comboFind_TextUpdate(object sender, EventArgs e)
        {
            btnFindNext.Enabled = btnFindList.Enabled = btnFindView.Enabled = Trim(comboFind.Text) != "";
        }
        void comboFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Find();
        }
        //void comboFind_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    btnFindNext.Enabled = // Здесь ваш код
        //    // Здесь ваш код
        //}

        #endregion

        private void RelateAndBind()
        {

            ForeignKeyConstraint cs = new ForeignKeyConstraint("StudExam", ds.Tables[0].Columns[0], ds.Tables[1].Columns[1]);
            cs.DeleteRule = Rule.Cascade;
            cs.UpdateRule = Rule.Cascade;
            ds.Tables[1].Constraints.Add(cs);
            ds.EnforceConstraints = true;
            ds.Relations.Add(new DataRelation("StudExam", ds.Tables[0].Columns[0], ds.Tables[1].Columns[1]));

            
            bsStuds = new BindingSource(ds, ds.Tables[0].TableName);
            bsExams = new BindingSource(bsStuds, ds.Relations[0].RelationName);
            gridStud.DataSource = bsStuds;
            gridExam.DataSource = bsExams;
            

            bn.BindingSource = bsStuds;
            AddStyle(gridStud, 0);
        }





    }
}
