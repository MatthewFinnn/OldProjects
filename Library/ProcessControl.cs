using System;
using System.Collections;
using System.Management;
using System.Windows.Forms;
using System.Diagnostics;

namespace Library
{
    public partial class ProcessControl : UserControl
    {
        #region Data
        string sMachine;
        ConnectionOptions co;
        ProcessListComparer listComparer;
        ManagementEventWatcher watcherCreate, watcherDelete;
        bool removing;
        public event Action<string> UpdateStatus;
        #endregion

        #region Init
        public ProcessControl()
        {
            InitializeComponent();
            Load += new EventHandler(ProcessesControl_Load);

            watcherCreate = new ManagementEventWatcher(
                @"Select * from __InstanceCreationEvent within 1 
				where TargetInstance ISA 'Win32_Process'");
            watcherDelete = new ManagementEventWatcher(
                @"Select * from  __InstanceDeletionEvent within 1
				where TargetInstance ISA 'Win32_Process'");
        }
        #endregion

            void ProcessesControl_Load(object sender, EventArgs e)
            {
                GetSysInfo(); 
                SetProcessList();
                FillProcesses();
                ShowProperty("123");

                combo.Items.AddRange(new object[] {
                    "hh.exe", "notepad.exe", "regedit.exe", "calc.exe", "mmc.exe"});
                watcherCreate.EventArrived +=new EventArrivedEventHandler(watcherCreate_EventArrived);
                watcherDelete.EventArrived +=new EventArrivedEventHandler(watcherDelete_EventArrived);
                Disposed +=new EventHandler(ProcessControl_Disposed);
                combo.SelectedIndexChanged +=new EventHandler(combo_SelectedIndexChanged);
                listView.ItemChecked +=new ItemCheckedEventHandler(listView_ItemChecked);
                listView.ColumnClick +=new ColumnClickEventHandler(listView_ColumnClick);
                listView.ItemSelectionChanged +=new ListViewItemSelectionChangedEventHandler(listView_ItemSelectionChanged);
                btnRefresh.Click +=new EventHandler(btnRefresh_Click);
                rbCurrent.CheckedChanged +=new EventHandler(rbCurrent_CheckedChanged);

                watcherCreate.Start();
                watcherDelete.Start();
            }

            void ProcessControl_Disposed(object sender, EventArgs e)
            {
               
            }

            #region Methods
            void AddItem(ListViewItem item)
            {
                listView.BeginUpdate();
                listView.ItemCheck -= new ItemCheckEventHandler(listView_ItemCheck);
                item.Checked = true;
                listView.Items.Add(item);
                UpdateStatusBar("12345");
                listView.ItemCheck += new ItemCheckEventHandler(listView_ItemCheck);
                listView.EndUpdate();
            }

            void RemoveList(string id)
            {
                foreach (ListViewItem item in listView.Items) // Элемента списка listView)
                {
                    if (item.SubItems[2].Text==id)
                    {
                        UpdateStatusBar("Process " + item.SubItems[1].Text + " num : "
                            + item.SubItems[2].Text + " terminated");
                        item.Remove();
                        break;
                    }
                }
            }

            void  StopProcess(int id)
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(
                    "Select * from Win32_Process Where ProcessId ="+id);
                if (searcher.Get().Count != 0)
                {
                    foreach (ManagementObject mo in searcher.Get())
                    mo.InvokeMethod("Terminate", null);
                }
            }

            void ShowProperty(string s)
            {
                string q = "Select * from  Win32_Process where ProcessId = " + s;
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(q);
                propt.Text = string.Empty;
                foreach (ManagementObject mo in searcher.Get())
                    foreach(var prop in mo.Properties)
                        if(prop.Value != null)
                            propt.Text += prop.Name + ": " + prop.Value + "\r\n";
            }

            void SetProcessList()
            {
                listView.Columns.Add("№  ", 50, HorizontalAlignment.Left);
                listView.Columns.Add("Process", 120, HorizontalAlignment.Left);
                listView.Columns.Add("ID", 80, HorizontalAlignment.Left);
                listView.Sorting = SortOrder.Ascending;
                listComparer = new ProcessListComparer();
                listView.ListViewItemSorter = listComparer;
            }
            void GetSysInfo()
            {
                if (!rbCurrent.Checked)
                {
                    sMachine = lbName.Text.Trim();
                    if (string.IsNullOrEmpty(sMachine))
                    {
                        MessageBox.Show("Machine IP address or name is needed");
                        return;
                    }
                    co = new ConnectionOptions();
                    co.Username = txtUserID.Text.Trim();
                    co.Password = txtPass.Text.Trim();
                }
            }

            void FillProcesses()
            {
                listView.BeginUpdate();
                listView.ItemCheck -= new ItemCheckEventHandler(listView_ItemCheck);
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(
                    "Select * from Win32_Process");
                int n = 0;
                foreach ( var proc in searcher.Get())
                {
                    ListViewItem item = new ListViewItem(new string[] { n++.ToString(), proc["Name"].ToString(), proc["Handle"].ToString()});
                    item.Checked = true;
                    listView.Items.Add(item);
                }
                listView.ItemCheck +=new ItemCheckEventHandler(listView_ItemCheck);
                listView.EndUpdate();
            }
            #endregion

            #region Events
            void listView_ColumnClick(object sender, ColumnClickEventArgs e)
            {
                bool repeated = listComparer.col == e.Column;
                listComparer.col = e.Column;

                if (repeated)
                {
                    // Ваш код. Измените порядок сортировки
                }
                listView.Sort();
            }
            void listView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
            {
                ShowProperty(listView.Items[e.ItemIndex].SubItems[2].Text.ToString());
            }
            void listView_ItemChecked(object sender, ItemCheckedEventArgs e)
            {
                if (removing)
                {
                    UpdateStatusBar("Process " + e.Item.SubItems[1].Text + " PID = "
                        + e.Item.SubItems[2].Text  + " terminated");
                    e.Item.Remove();
                    removing = false;
                }
            }
            void listView_ItemCheck(object sender, ItemCheckEventArgs e)
            {
                ListViewItem item = listView.Items[e.Index];
                int id = int.Parse(item.SubItems[2].Text);
                string what = listView.Items[e.Index].SubItems[1].Text + ", PID = " + id;
                if (MessageBox.Show("Terminate process?\r\n" + what,
                    "Terminating process", MessageBoxButtons.YesNoCancel, 
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    StopProcess(id);
                    removing = true;
                }
                else
                    e.NewValue = CheckState.Checked;
            }
            void btnRefresh_Click(object sender, EventArgs e)
            {
                listView.Items.Clear();
                GetSysInfo();
                FillProcesses();
                string s = listView.Items[0].SubItems[2].Text;
                ShowProperty(s);
            }
            void rbCurrent_CheckedChanged(object sender, EventArgs e)
            {
                group.Visible = rbRemote.Checked;
            }
            void combo_SelectedIndexChanged(object sender, EventArgs e)
            {
                ManagementClass m = new ManagementClass("Win32_Process");
                try
                {
                    m.InvokeMethod("Create", new object[] { combo.Text, 0, 0, 0 });
                }
                catch (Exception)
                {
                    MessageBox.Show("Process: " + combo.Text + " not found");
                }
            }
            void watcherCreate_EventArrived(object sender, EventArrivedEventArgs e)
            {
                ManagementBaseObject mo = e.NewEvent["TargetInstance"] as ManagementBaseObject;
                ListViewItem item = new ListViewItem(new string[] {
                    (listView.Items.Count + 1).ToString(), 
                    mo["Caption"].ToString(), mo["ProcessId"].ToString()});
                listView.Invoke(new Action<ListViewItem>(AddItem), new object[] { item });
            }
            void watcherDelete_EventArrived(object sender, EventArrivedEventArgs e)
            {
                ManagementBaseObject mo = e.NewEvent["TargetInstance"] as ManagementBaseObject;
                string name = mo["ProcessId"].ToString();
                listView.Invoke(new Action<string>(RemoveList), new object[] { name });
            }
            void ProcessesControl_Disposed(object sender, EventArgs e)
            {
                watcherCreate.Stop();
                watcherDelete.Stop();
                watcherCreate.Dispose();
                watcherDelete.Dispose();
            }
            void UpdateStatusBar(string s)
            {
                if (UpdateStatus != null)
                    UpdateStatus(s);
            }
            #endregion
        }

        #region ProcessListComparer Class

        class ProcessListComparer : IComparer
        {
            public int col;		// Номер колонки. Количество нажатий
            public SortOrder order;		// Режим сортировки
            public ProcessListComparer() { col = 0; order = SortOrder.Ascending; }

            public int Compare(object x, object y)
            {
                int res = 0;
                string
                        s1 = ((ListViewItem)x).SubItems[col].Text,
                        s2 = ((ListViewItem)y).SubItems[col].Text;
                switch (col)
                {
                    case 0: res = Int32.Parse(s1).CompareTo(Int32.Parse(s2)); break;
                    case 1: res = s1.CompareTo(s2); break;
                    case 2: res = Int32.Parse(s1).CompareTo(Int32.Parse(s2)); break;
                }
                if (order == SortOrder.Descending)
                    res = -res;

                return res;
            }

        }
        #endregion
    }



