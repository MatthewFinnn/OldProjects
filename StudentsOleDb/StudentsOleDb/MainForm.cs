using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.Threading;

namespace StudentsOleDb
{
    public partial class MainForm : Form
    {

        #region Init
        DataSet ds;
        OleDbConnection cn;
        string dbFile, dbPath, dbDir;
        string[] tableNames;
        OleDbDataAdapter[] da;
        BindingSource[] bs;
        DataGridView[] grids;
        bool flag;
        #endregion

        public MainForm()
        {
            InitializeComponent();

            dbFile = "Music.mdb";
            tableNames = new string[] { "Artists", "Albums", "Track_List" };
            da = new OleDbDataAdapter[tableNames.Length];
            bs = new BindingSource[tableNames.Length];
            grids = new DataGridView[] { gridArtist, gridAlbum, gridTrack };
            bn.ItemClicked +=new ToolStripItemClickedEventHandler(bn_ItemClicked);
            Load+=new EventHandler(MainForm_Load);
            gridArtist.CellEnter += new DataGridViewCellEventHandler(gridArtistAlbum_CellEnter);
            gridAlbum.CellEnter += new DataGridViewCellEventHandler(gridArtistAlbum_CellEnter);
            pictArtist.DoubleClick += new EventHandler(pictArtist_DoubleClick);
            pictAlbum.DoubleClick += new EventHandler(pictAlbum_DoubleClick);
        }

        void MainForm_Load(object sender, EventArgs e)
        {
            FindDataFile();
            if (dbPath == null)
                return;
            CreateDataSet();
        }


        void pictAlbum_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.InitialDirectory = dbDir;
            dlg.Filter = "Image files(*.jpg)|*.jpg;*.png";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                DataRowView view = bs[1].Current as DataRowView;
                if (view == null || view.IsNew)
                {
                    new FormMsg("Create a row first", 2000);
                    return;
                }
                view["Photo"] = File.ReadAllBytes(dlg.FileName);
                pictAlbum.DataBindings[0].ReadValue();

            }
        }

        void pictArtist_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.InitialDirectory = dbDir;
            dlg.Filter = "Image files(*.jpg)|*.jpg;*.png";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                DataRowView view =  bs[0].Current as DataRowView;
                if (view == null || view.IsNew)
                {
                    new FormMsg("Create a row first", 2000);
                    return;
                }
                view["Photo"] = File.ReadAllBytes(dlg.FileName);
                pictArtist.DataBindings[0].ReadValue();

            }

        }
        
        void gridArtistAlbum_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (!flag)
                return;
            DataGridView grid = sender as DataGridView;

        }

        void bn_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.ToolTipText)
            {
                case "Reject Changes": RejectChanges(); break;
                case "Save": UpdateDB(); break;
                case "Open DB":
                    OpenDB();
                    if (dbPath != null)
                        CreateDataSet();
                    break;
            }
        }

        void grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            new FormMsg(e.Exception.Message + "\r\n\r\nСтрока: " + e.RowIndex +
                ",  Колонка: " + e.ColumnIndex, 4000);
        }

        void RejectChanges()
        {
            bs[0].EndEdit(); bs[1].EndEdit();
            ds.RejectChanges();
        }


        void CreateDataSet()
        {
            ClearDataSet();
            ds = new DataSet();
            cn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + dbPath);
            for (int i = 0; i < tableNames.Length; i++)
            {
                da[i] = new OleDbDataAdapter("Select * from " + tableNames[i], cn);
                
                new OleDbCommandBuilder(da[i]);
                
                da[i].Fill(ds, tableNames[i]);
                AddStyle(i);
            }
            Relate(0, 1);
            Relate(1, 2);
            bs[0] = new BindingSource(ds, ds.Tables[0].TableName);
            bs[1] = new BindingSource(bs[0], ds.Relations[0].RelationName);
            bs[2] = new BindingSource(bs[1], ds.Relations[1].RelationName);

            for (int i = 0; i < tableNames.Length; i++)
            {
                SetPrimaryColumn(ds.Tables[i], ds.Tables[i].Columns[0].ColumnName);
                grids[i].DataSource = bs[i];
                grids[i].DataError += new DataGridViewDataErrorEventHandler(grid_DataError);

            }
            pictArtist.DataBindings.Add("Image", bs[0], "Photo", true);
            pictAlbum.DataBindings.Add("Image", bs[1], "Photo", true);
            bn.BindingSource = bs[0];
            flag = true;
        }

        void ClearDataSet()
        {
            if (ds != null)
            {
                ds.Dispose();
                for (int i = 0; i < grids.Length; i++)
                {
                    grids[i].Columns.Clear();
                    grids[i].DataError -= new DataGridViewDataErrorEventHandler(grid_DataError);
                    if (bs[i] != null)
                        bs[i].Dispose();
                }
            }
        }
     
        void Relate (int i1, int i2)
		{
			string name = tableNames[i1] + tableNames[i2];		// Имя связи

            ForeignKeyConstraint cs = new ForeignKeyConstraint(name, ds.Tables[i1].Columns[0], ds.Tables[i2].Columns[1]); // Создайте ограничение;
			cs.DeleteRule = Rule.Cascade;
            cs.UpdateRule = Rule.Cascade;
            ds.Tables[i2].Constraints.Add(cs);
            ds.EnforceConstraints = true;
            ds.Relations.Add(new DataRelation(name, ds.Tables[i1].Columns[0], ds.Tables[i2].Columns[1]));// Создайте объект DataRelation (используйте name));

		}

        void AddStyle (int id)
		{
			DataGridView grid =	grids[id];	// Выберите из массива нужный DataGridView
			grid.AutoGenerateColumns = false;

			foreach (DataColumn colum in ds.Tables[id].Columns)// колонки из нужной таблицы DataSet)
			{
				DataGridViewColumn col = new DataGridViewColumn();		// Создаем колонку DataGridView
				if (col.CellType == typeof(bool))
					col = new DataGridViewCheckBoxColumn();
                else if (colum.DataType == typeof(DateTime))
                {
                    col = new CalendarColumn();
                    col.DefaultCellStyle.Format = "d";
                }
				else
					col = new DataGridViewTextBoxColumn();
				col.Name = colum.ColumnName;
				if (colum.ColumnName.IndexOf("ID") != -1)
					col.ReadOnly = true;
                
                col.DataPropertyName = "";
                col.HeaderText = colum.ColumnName;
                col.DataPropertyName = colum.ColumnName;


				// Установите важные свойства колонки: DataPropertyName, HeaderText AutoSizeMode
                if(colum.DataType != typeof(byte[]))
				    grid.Columns.Add(col);
                // Добавьте колонку в коллекцию колонок DataGridView
			}
            grid.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
            grid.DefaultCellStyle.SelectionForeColor = Color.Black;
            grid.AlternatingRowsDefaultCellStyle.BackColor = id == 0 ? Color.Wheat : Color.FromArgb(200, 255, 200);
        
			// Установите свойства DataGridView: AlternatingRowsDefaultCellStyle, SelectionBackColor и SelectionForeColor
		}
        
        void FindDataFile()
		{
			dbDir = FindFolder("Data");
			if (dbDir != null)
				dbPath = dbDir + dbFile;
			if (!File.Exists (dbPath))
			{
				new FormMsg ( "Could not find Data file: " + dbFile, 2000);
				dbPath = null;
				Thread.Sleep(2000);
				OpenDB();
			}
			Text = typeof(MainForm).Assembly.GetName().Name + ":  " + dbFile;
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

        void OpenDB()
        {
            OpenFileDialog dlg = new OpenFileDialog(); // Создайте стандартный диалог
            
            dlg.Title = "Find Database file: " + dbFile;
            dlg.InitialDirectory = dbPath;
            dlg.CheckFileExists = true;

            Text = typeof(MainForm).Assembly.GetName().Name;
            
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                dbPath = dlg.FileName;
                dbDir = Path.GetDirectoryName(dbPath);
                Text += ":  " + dbFile;
            }
            if (Path.GetFileName(dlg.FileName) != dbFile)
            {
                dbPath = dbDir = null;
                new FormMsg( dbFile + " is needed.", 2000);
            }
        }

        void UpdateDB()
        {
            if(cn.State == ConnectionState.Closed)
                cn.Open();
            try
            {
                for (int t = ds.Tables.Count - 1; t >= 0; t--)
                {
                    TableDelete(t);
                }

                for (int t = 0; t < ds.Tables.Count; t++)
                {
                    TableInsert(t);
                    TableUpdate(t);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
        }

        void TableUpdate(int tableID)
        {

            DataTable table = ds.Tables[tableID];
            DataColumnCollection cols = table.Columns;
            string s = @"Update " + table.TableName + " Set ";

            for (int i = 1; i < cols.Count; i++)
            {
                s += "[" + cols[i] + "]=?";
                if (i != cols.Count - 1)
                    s += ", ";
            }
            s += " WHERE [" + cols[0] + "]=?";
            OleDbCommand cmd = new OleDbCommand(s, cn);

            DataRow[] rows = table.Select("", "", DataViewRowState.ModifiedCurrent);
            foreach (DataRow row in rows)
            {
                cmd.Parameters.Clear();
                for (int i = 1; i < cols.Count; i++)
                {
                    object data = row[i];

                    OleDbParameter p = new OleDbParameter("?", GetOleDbType(cols[i].DataType.Name), cols[i].MaxLength,
                        ParameterDirection.Input, cols[i].AllowDBNull, 0, 0, cols[i].ColumnName, DataRowVersion.Proposed, data);
                    cmd.Parameters.Add(p);

                    if (i == cols.Count - 1)
                    {
                        data = row[0];
                    p = new OleDbParameter("?", GetOleDbType(cols[0].DataType.Name), cols[0].MaxLength,
                        ParameterDirection.Input, cols[0].AllowDBNull, 0, 0, cols[0].ColumnName, DataRowVersion.Proposed, data);
                    cmd.Parameters.Add(p);
                    }
                }


                int n = cmd.ExecuteNonQuery();
                row.AcceptChanges();
            }
        }

        void TableInsert(int tableID)
        {
            DataTable dt = ds.Tables[tableID];

            OleDbCommand cmd = new OleDbCommand("", cn);
            DataColumnCollection cols = dt.Columns;

            DataRow[] added = dt.Select(null, null, DataViewRowState.Added);

            if (added.Length > 0)
            {
                string s = "INSERT INTO " + dt.TableName + " (";
                for (int i = 1; i < cols.Count; i++)
                    s += "[" + cols[i].ColumnName + "],";
                s = s.TrimEnd(',') + ") Values (";
                for (int i = 1; i < cols.Count; i++)
                    s += "?,";
                s = s.TrimEnd(',') + ")";

                foreach (DataRow row in added)
                {
                    cmd.Parameters.Clear();
                    for (int i = 1; i < cols.Count; i++)
                    {
                        object data = row[i];
                        OleDbParameter p = new OleDbParameter("?",
                            GetOleDbType(cols[i].DataType.Name), cols[i].MaxLength,
                                 ParameterDirection.Input, cols[i].AllowDBNull, 0, 0,
                                 cols[i].ColumnName, DataRowVersion.Current, data);
                        cmd.Parameters.Add(p);
                    }

                    cmd.CommandText = s;
                    int n = cmd.ExecuteNonQuery();

                    cmd.CommandText = "SELECT @@IDENTITY";
                    int id = (int)cmd.ExecuteScalar();
                    row[0] = id;
                    row.AcceptChanges();
                }
            }
        
        }

        void TableDelete(int tableID)
        {
            DataTable table = ds.Tables[tableID];
            DataColumnCollection cols = table.Columns;
            string s = @"Delete From " + table.TableName + " WHERE [" + cols[0] + "]=";

            OleDbCommand cmd = new OleDbCommand(s, cn);

            DataRow[] rows = table.Select("", "", DataViewRowState.Deleted);
            foreach (DataRow row in rows)
            {
                cmd.CommandText = s + row[0, DataRowVersion.Original];
                int n = cmd.ExecuteNonQuery();
                row.AcceptChanges();
            }
        }

        void SetPrimaryColumn(DataTable table, string colName)
        {
            int max = 0;
            try
            {
                foreach (DataRow row in table.Rows)
                    max = int.Parse(row[0].ToString()) > max ? int.Parse(row[0].ToString()) : max;
            }
            catch { }
            DataColumn dc = table.Columns[colName];
            dc.AutoIncrement = true;
            dc.AutoIncrementSeed = max + 1;
            dc.AutoIncrementStep = 1;
            table.PrimaryKey = new DataColumn[] { dc };
        }


        OleDbType GetOleDbType(string name)
        {
            switch (name)
            {
                case "String": return OleDbType.VarChar;
                case "DateTime": return OleDbType.Date;
                case "Byte[]": return OleDbType.VarBinary;
                case "Int32": return OleDbType.Integer;
                default: throw new TypeLoadException("GetSQlType: " + name + ". No sql type counterpart");
            }
        }

        object HandleEmptyFields(string typeName)
        {
            switch (typeName)
            {
                case "Boolean": return bool.FalseString;
                case "DateTime": return DateTime.MinValue;
                case "Byte": return byte.MinValue;
                default: return "N/A"; // DBNull.Value не работает
            }
        }
    }
}
