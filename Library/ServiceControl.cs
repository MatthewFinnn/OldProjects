using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.Collections;

namespace Library
{
    public partial class ServiceControl : UserControl
    {

        #region Data
        string sMachine;
        ConnectionOptions co;
        ServiceListComparer listComparer;
        ManagementEventWatcher watcherCreate, watcherDelete;
        bool removing;
        string lastselectedServise;
        public event Action<string> UpdateStatus;
        #endregion

        #region Init
        public ServiceControl()
        {
            InitializeComponent();
            Load += new EventHandler(ServiceControl_Load);

            watcherCreate = new ManagementEventWatcher(
                @"Select * from __InstanceCreationEvent within 1 
				where TargetInstance ISA 'Win32_Process'");
            watcherDelete = new ManagementEventWatcher(
                @"Select * from  __InstanceDeletionEvent within 1
				where TargetInstance ISA 'Win32_Process'");
        }

        void ServiceControl_Load(object sender, EventArgs e)
        {
            GetSysInfo();
            SetProcessList();
            FillService();
            ShowProperty("123");

            watcherCreate.EventArrived += new EventArrivedEventHandler(watcherCreate_EventArrived);
            watcherDelete.EventArrived += new EventArrivedEventHandler(watcherDelete_EventArrived);
            
            listView.ItemChecked += new ItemCheckedEventHandler(listView_ItemChecked);
            listView.ColumnClick += new ColumnClickEventHandler(listView_ColumnClick);
            listView.ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler(listView_ItemSelectionChanged);
            btnRefresh.Click += new EventHandler(btnRefresh_Click);
            rbCurrent.CheckedChanged += new EventHandler(rbCurrent_CheckedChanged);
            

            watcherCreate.Start();
            watcherDelete.Start();
        }
        #endregion

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
                if (item.SubItems[2].Text == id)
                {
                    UpdateStatusBar("Process " + item.SubItems[1].Text + " num : "
                        + item.SubItems[2].Text + " terminated");
                    item.Remove();
                    break;
                }
            }
        }

        void StopService(int id)
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(
                "Select * from Win32_Service");
            if (searcher.Get().Count != 0)
            {
                foreach (ManagementObject mo in searcher.Get())
                    mo.InvokeMethod("Terminate", null);
            }
        }

        void ShowProperty(string s)
        {
            if (s == lastselectedServise)
                return;
            lastselectedServise = s;
            string q = "Select * from  Win32_Service where Name Like '%" + s + "%'"; 
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(q);
            propt.Text = string.Empty;
            foreach (ManagementObject mo in searcher.Get())
                foreach (var prop in mo.Properties)
                    if (prop.Value != null)
                        propt.Text += prop.Name + ": " + prop.Value + "\r\n";
        }

        void SetProcessList()
        {
            listView.Columns.Add("№  ", 50, HorizontalAlignment.Left);
            listView.Columns.Add("Name", 120, HorizontalAlignment.Left);
            listView.Columns.Add("ProcessID", 80, HorizontalAlignment.Left);
            listView.Columns.Add("State", 80, HorizontalAlignment.Left);
            listView.Sorting = SortOrder.Ascending;
            listComparer = new ServiceListComparer();
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

        void FillService()
        {
            listView.BeginUpdate();
            listView.ItemCheck -= new ItemCheckEventHandler(listView_ItemCheck);
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(
                "Select * from Win32_Service");
            int n = 0;
            foreach (var proc in searcher.Get())
            {
                ListViewItem item = new ListViewItem(new string[] {n++.ToString(), proc["Name"].ToString(), proc["ProcessID"].ToString(), proc["State"].ToString() });
                item.Checked = true;
                listView.Items.Add(item);
            }
            listView.ItemCheck += new ItemCheckEventHandler(listView_ItemCheck);
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
                listComparer.order = SortOrder.Descending;// Ваш код. Измените порядок сортировки
            }
            listView.Sort();
        }
        void listView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            ShowProperty(listView.Items[e.ItemIndex].SubItems[1].Text.ToString());
        }
        void listView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (removing)
            {
                UpdateStatusBar("Process " + e.Item.SubItems[1].Text + " PID = "
                    + e.Item.SubItems[2].Text + " terminated");
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
                StopService(id);
                removing = true;
            }
            else
                e.NewValue = CheckState.Checked;
        }
        void btnRefresh_Click(object sender, EventArgs e)
        {
            listView.Items.Clear();
            GetSysInfo();
            FillService();
            string s = listView.Items[0].SubItems[2].Text;
            ShowProperty(s);
        }
        void rbCurrent_CheckedChanged(object sender, EventArgs e)
        {
            group.Visible = rbRemote.Checked;
        }
        
        void watcherCreate_EventArrived(object sender, EventArrivedEventArgs e)
        {
            ManagementBaseObject mo = e.NewEvent["TargetInstance"] as ManagementBaseObject;
            ListViewItem item = new ListViewItem(new string[] {
                    (listView.Items.Count + 1).ToString(), 
                    mo["Caption"].ToString(), mo["ServiceId"].ToString()});
            listView.Invoke(new Action<ListViewItem>(AddItem), new object[] { item });
        }
        void watcherDelete_EventArrived(object sender, EventArrivedEventArgs e)
        {
            ManagementBaseObject mo = e.NewEvent["TargetInstance"] as ManagementBaseObject;
            string name = mo["ServiceId"].ToString();
            listView.Invoke(new Action<string>(RemoveList), new object[] { name });
        }
        void ServiceControl_Disposed(object sender, EventArgs e)
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

    class ServiceListComparer : IComparer
    {
        public int col;		// Номер колонки. Количество нажатий
        public SortOrder order;		// Режим сортировки
        public ServiceListComparer() { col = 0; order = SortOrder.Ascending; }

        public int Compare(object x, object y)
        {
            int res = 0;
            string
                    s1 = ((ListViewItem)x).SubItems[col].Text,
                    s2 = ((ListViewItem)y).SubItems[col].Text;
            switch (col)
            {
                case 0: res = s1.CompareTo(s2); break;
                case 1: res = s1.CompareTo(s2); break;
                case 2: res = s1.CompareTo(s2); break;
            }
            if (order == SortOrder.Descending)
                res = 2-res;

            return res;
        }

    }
    #endregion
}



