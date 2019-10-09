using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Media;
using System.Text.RegularExpressions;
using System.Data.OleDb;

namespace AudioLibrary
{
    public partial class Form1 : Form
    {
        #region Init
        protected DataSet ds = new DataSet();
        BindingSource bsArtist, bsAlbum, bsTrack;
        protected String dir;
        protected String fileName;
        OleDbDataAdapter daArtist, daAlbum, daTracklist;
        OleDbConnection cn;

        bool bFindNext;
        DataGridView activeGrid;
        DataTable activeTable;
        DataGridViewCell lastfoundCell;
        string findWhat;
        
        Form formFound;
        
        #endregion

        public Form1()
        {
            
            dir = FindFolder("AudioLibrary");
            fileName = "AudioLibrary.xml";
            InitializeComponent();

            cn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" +
                    FindFolder("Data") + "AudioLibrary.mdb");

            ConnectAndRead();


           
            gridAlbum.CellEnter += new DataGridViewCellEventHandler(gridAlbum_CellEnter);
            gridArtist.CellEnter += new DataGridViewCellEventHandler(gridArtist_CellEnter);
            gridTracklist.CellEnter += new DataGridViewCellEventHandler(gridTracklist_CellEnter);
            bn.ItemClicked +=new ToolStripItemClickedEventHandler(bn_ItemClicked);
            comboFind.TextUpdate += new EventHandler(comboFind_TextUpdate);
            comboBoxTables.SelectedIndexChanged += new EventHandler(comboBoxTables_SelectedIndexChanged);
            Load += new EventHandler(Form1_Load);
        }

       

        void comboBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxTables.Text)
            {
                case "Artists": activeGrid = gridArtist; break;
                case "Albums": activeGrid = gridAlbum; break;
                case "TrackList": activeGrid = gridTracklist; break;
            }
            foreach (DataColumn c in ds.Tables[comboBoxTables.Text].Columns)
            { comboBoxColumns.Items.Add(c.ColumnName); }
        }

        void comboFind_TextUpdate(object sender, EventArgs e)
        {
            toolStripFind.Visible = btnFindNext.Enabled = btnFindList.Enabled = btnFindView.Enabled = Trim(comboFind.Text) != "";
            int delt = toolStripFind.Visible == true ? 120 : 0;

            labelArtist.Left = 630 + delt;
            artistFoto.Left = 630 + delt;
            labelAlbum.Left = 870 + delt;
            albumFoto.Left = 870 + delt;
            gridAlbum.Left = 5 + delt;
            gridArtist.Left = 5 + delt;
            gridTracklist.Left = 5 + delt;

        }
        string Trim(string s)
        {
            return new Regex(@"\s{2,}").Replace(s.Trim(), " ");
        }

        void gridArtist_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (!bFindNext)
                lastfoundCell = null;
           
            try
            {
                artistFoto.Image = new Bitmap(dir + "\\Artist\\" + gridArtist.Rows[e.RowIndex].Cells[3].Value);
            }
            catch (Exception ex)
            {
                artistFoto.Image = new Bitmap(dir + "\\Artist\\" + "Def.jpg");
            }
            finally
            {
                gridAlbum_CellEnter(new object(), new DataGridViewCellEventArgs(0, 0));
            }
        }
        void gridAlbum_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (!bFindNext)
                lastfoundCell = null;
            try
            {
                albumFoto.Image = new Bitmap(dir + "\\Album\\" + gridAlbum.Rows[e.RowIndex].Cells[5].Value);
            }
            catch (Exception ex)
            {
                albumFoto.Image = new Bitmap(dir + "\\Album\\" + "Def.jpg");
            }
        }
        void gridTracklist_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (!bFindNext)
                lastfoundCell = null;
        }

        void Form1_Load(object sender, EventArgs e)
        {
            gridArtist_CellEnter(new object(), new DataGridViewCellEventArgs(0,0));
            foreach (DataTable t in ds.Tables)
                comboBoxTables.Items.Add(t.TableName);
        }




        #region InitDataSet_Tables_CreateRelations
        

        private void ConnectAndRead()
        {
            ds = new DataSet();
            //==== Создание построителя, который автоматизирует процесс создания команд (Insert, Delete и Update)
            daArtist = new OleDbDataAdapter("Select * from Artists", cn);
            daArtist.Fill(ds, "Artists");
            AddStyle(gridArtist,0);
            gridArtist.DataSource = ds;
            gridArtist.DataMember = ds.Tables[0].TableName;

            daAlbum = new OleDbDataAdapter("Select * from Albums", cn);
            daAlbum.Fill(ds, "Albums");
            AddStyle(gridAlbum, 1);
            gridAlbum.DataSource = ds;
            gridAlbum.DataMember = ds.Tables[1].TableName;

            daTracklist = new OleDbDataAdapter("Select * from Tracklist", cn);
            daTracklist.Fill(ds, "Tracklist");
            AddStyle(gridTracklist, 2);
            gridTracklist.DataSource = ds;
            gridTracklist.DataMember = ds.Tables[2].TableName;

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
                
                else
                    col = new DataGridViewTextBoxColumn();
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                if (dc == cols[cols.Count - 1])
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.DataPropertyName = dc.ColumnName;
                col.HeaderText = dc.ColumnName;
                col.Name = dc.ColumnName;
                grid.Columns.Add(col);
            }
            grid.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
            grid.DefaultCellStyle.SelectionForeColor = Color.Black;
            grid.AlternatingRowsDefaultCellStyle.BackColor = tableID == 0 ? Color.Wheat : Color.FromArgb(200, 255, 200);
        }
        private void RelateAndBind()
        {

            ForeignKeyConstraint cs = new ForeignKeyConstraint("StudExam", ds.Tables[0].Columns[0], ds.Tables[1].Columns[1]);
            cs.DeleteRule = Rule.Cascade;
            cs.UpdateRule = Rule.Cascade;
            ds.Tables[1].Constraints.Add(cs);
            ds.EnforceConstraints = true;
            ds.Relations.Add(new DataRelation("ArtistAlbum", ds.Tables[0].Columns[0], ds.Tables[1].Columns[1]));
            ds.Relations.Add(new DataRelation("AlbumTrack", ds.Tables[1].Columns[0], ds.Tables[2].Columns[1]));


            bsArtist = new BindingSource(ds, ds.Tables[0].TableName);
            bsAlbum = new BindingSource(bsArtist, ds.Relations[0].RelationName);
            bsTrack = new BindingSource(bsAlbum, ds.Relations[1].RelationName);

            gridArtist.DataSource = bsArtist;
            gridAlbum.DataSource = bsAlbum;
            gridTracklist.DataSource = bsTrack;
            bn.BindingSource = bsArtist;
        }
        #endregion

        void bn_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "&Открыть": Open(FileDlg(true)); break;
                case "&Сохранить": UpdateDB(); break;
                case "Find Next": Find(); break;
                case "Find List": ShowList(GetSearchCriteria()); break;
                case "Show Data": ConnectAndRead(); break;
            }
        }
        private void UpdateDB()
        {
            try { daArtist.Update(ds.Tables[0]); daAlbum.Update(ds.Tables[1]); daTracklist.Update(ds.Tables[2]); }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region FindNext
        void Find()
        {
            bFindNext = true;
            int row, col;
            if (lastfoundCell == null)
            {
                findWhat = Trim(comboFind.Text);
                switch (comboBoxTables.Text)
                {
                    case "Artists": activeGrid = gridArtist; break;
                    case "Albums": activeGrid = gridAlbum; break;
                    case "TrackList": activeGrid = gridTracklist; break;
                }
                row = 0; col = activeGrid.Columns[comboBoxColumns.Text].Index;
            }
            else
            {
                row = lastfoundCell.RowIndex+1;
                col = lastfoundCell.ColumnIndex;
            }

            if (!FindNext(row, col))
            { lastfoundCell = null; new FormMsg("End Found", 2000); }
            bFindNext = false;
        }
        bool FindNext(int row, int col)
        {
            for (int i = row; i < activeGrid.Rows.Count; i++ )		// Цикл поиска
            {
                object o = activeGrid[col, i].Value;
                if (o != null)		// Если ячейка в строке i и столбце col не пуста
                {
                    string val = o.ToString();
                    //===== Если текст в ячейке начинается с искомой строки
                    if (val.IndexOf(findWhat) != -1)	// Если текст в ячейке начинается с искомой строки
                    {
                        activeGrid.CurrentCell = lastfoundCell = activeGrid[col, i];
                        return true;
                    }
                }
            }
            return false;
        }
        void SetErrorMsg(string criteria, string colName)
        {
            string msg = "Could not find:  '" + criteria + "'";
            if (colName != null)
                msg += "  in column:  " + colName;
            else
                msg += ".   Select a column to search";
            new FormMsg(msg, 2000);
        }

        #endregion


        #region FindList
        string GetSearchCriteria()
        {
            string criteria = null;
            try
            {
                activeTable = ds.Tables[comboBoxTables.Text];
                string findWhat = Trim(comboFind.Text);

                DataColumn dc = activeTable.Columns[comboBoxColumns.Text];
                Type type = dc.DataType;

                switch (type.Name)
                {
                    case "String": criteria = " LIKE '" + findWhat + "*'"; break;
                    case "Decimal":
                    case "Byte":
                    case "SByte":
                    case "Int16":
                    case "UInt16":
                    case "Int64":
                    case "UInt64":
                    case "UInt32":
                    case "Boolean":
                    case "Int32": criteria = "=" + findWhat; break;
                    case "DateTime":
                        DateTime dt;
                        bool ok = DateTime.TryParse(findWhat, out dt);
                        if (ok)
                            criteria = "=#" + dt.ToShortDateString() + "#"; // ToShortDateString
                        else
                            throw new Exception();
                        break;
                }
                return criteria;
            }
            catch { }
            SetErrorMsg(criteria, null);
            return null;
        }

        void ShowList(string criteria)
        {
            DataRow[] rows = null;
            string colName = null;
            try
            {
                colName = comboBoxColumns.Text;
                string filter = colName + criteria;
                rows = activeTable.Select(filter);
                if (rows.Length != 0)
                {
                    if (!comboFind.Items.Contains(comboFind.Text))
                        comboFind.Items.Add(comboFind.Text);
                    CreateFormFound(CreateList(rows), criteria);
                    return;
                }
            }
            catch { }
            SetErrorMsg(criteria, colName);
        }

        Control CreateList(DataRow[] rows)
        {
            ListView list = new ListView();
            list.View = View.Details;
            list.FullRowSelect = true;
            list.GridLines = true;
            DataColumnCollection cols = rows[0].Table.Columns;
            list.Columns.Add(cols[0].ColumnName, 30);
            list.Columns.Add(cols[1].ColumnName, 100);
            list.Columns.Add(cols[2].ColumnName, 100);

            foreach (DataRow row in rows)
                list.Items.Add(new ListViewItem(new string[] {
					row[0].ToString(), row[1].ToString(), row[2].ToString() 
				}));

            list.Width = 280;
            list.Height = 330;
            list.SelectedIndexChanged += new EventHandler(list_SelectedIndexChanged);
            return list;
        }

        void list_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView list = sender as ListView;
            if (list.SelectedItems.Count == 0)
                return;

            
            foreach (System.Windows.Forms.ListViewItem.ListViewSubItem c in list.SelectedItems[0].SubItems)
            {
                int album = -1, artist = -1, id = -1;
                switch(c.Text)
                {
                    case "ArtistID": artist = Int32.Parse(c.Text); break;
                    case "AlbumID":  album = Int32.Parse(c.Text); break;
                        case "ID":  id = Int32.Parse(c.Text); break;
                }
                if (artist != -1)
                {
                    SelectRow(artist, gridArtist);
                    SelectRow(id, gridAlbum);

                }
                else if (album != -1)
                {
                    SelectRow(album, gridAlbum);
                    SelectRow(id, gridTracklist);
                }
                else
                    SelectRow(id, gridTracklist);


            }
            for (int i = 0; i < activeGrid.Rows.Count-1; i++)
            {
                if (activeGrid.Rows[i].Cells[0].Value.ToString() == list.SelectedItems[0].Text)
                { activeGrid.CurrentCell = activeGrid[activeGrid.CurrentCellAddress.X, i]; break; }
                
            }
        }

        void SelectRow(int id, DataGridView grid)
        {
            for (int i = 0; i < grid.Rows.Count - 1; i++)
            {
                if (grid.Rows[i].Cells[0].Value.ToString() == id.ToString())
                {
                    grid.CurrentCell = grid[grid.CurrentCell.ColumnIndex, i];
                    grid.Rows[i].Selected = true;
                }
            }
        }
        void CreateFormFound(Control control, string text)
        {
            // Здесь ваш код. Создайте метку msg с текстом "Ищу то-то в такой-то таблице"
            Label msg = new Label();
            msg.Text = "Find " + comboFind.Text + " in table " + comboBoxTables.Text;

            if (formFound != null)
                formFound.Dispose();
            formFound = new Form();
            formFound.Controls.Add(msg);
            formFound.Text = "Search results";
            formFound.MinimizeBox = false;
            formFound.MaximizeBox = false;
            formFound.Owner = this;
            formFound.Width = Math.Max(msg.Width, control.Width) + 24;
            formFound.Height = msg.Height + control.Height + 50;
            control.Location = new Point(3, msg.Height + 5);
            formFound.Controls.Add(control);
            formFound.Visible = true;
            formFound.Location = new Point(Location.X + Width, Location.Y);
        }
        #endregion
        #region SaveOpenData


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






    }
}
