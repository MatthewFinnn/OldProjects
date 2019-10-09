using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Management;
using System.Collections;

namespace Library
{
    public partial class FileSystemControl : UserControl
    {
        #region Data
        TreeNode root;										// Корневой узел
        List<FileSystemWatcher> watchers;		// Список наблюдателей за объектами файловой системы (по числу дисков)
        ManagementEventWatcher watchUSB, watchCD; // Наблюдатели за портом USB и приводом CDROM
        List<TreeNode> treeExpandedNodes;				// Список раскрытых узлов
        string pathToFind = "";						// Искомый файловый путь
        int hiddenCount;									// Количество скрытых файлов
        bool showHidden;									// Флаг отображения скрытых объектов
        //==== Полезные конствнты: атрибут "скрытые и/или системные", и т. д.
        const FileAttributes hidden = FileAttributes.System | FileAttributes.Hidden;
        const string separator = "   ", rootName = "My Computer";
        public event Action<string> UpdateStatus;	// Событие, возбуждаемое при обнаружении изменений
        #endregion

        public FileSystemControl()
        {
            InitializeComponent();
            watchers = new List<FileSystemWatcher>();
            treeExpandedNodes = new List<TreeNode>();
            fileList.Sorting = SortOrder.Ascending;
            fileList.ListViewItemSorter = new FileComparer();	// Связывание с объектом, управляющим сортировкой
            
            Disposed += new EventHandler(FileSystemControl_Disposed);
            SetFileList();
        }

        void watchCD_EventArrived(object sender, EventArrivedEventArgs e)
        {
            try
            {
                ManagementBaseObject was = e.NewEvent["PreviousInstance"] as ManagementBaseObject;
                ManagementBaseObject now = e.NewEvent["TargetInstance"] as ManagementBaseObject;
                // При вставке диска обработчик вызывается несколько раз.
                // При вставке диска значение now["FileSystem"] == "UDF"

                // При удалении диска значение was["FileSystem"] == "UDF"
                object
                    pFS = was["FileSystem"],
                    nFS = now["FileSystem"];
                string name;
                if (pFS == null && nFS != null)
                {
                    name = was["Name"].ToString();
                    Invoke(new Action<string>(SetMessage), "New disk was loaded " + name);
                    Invoke(new Action<string, string>(OnAddDisk), "5", name);
                }
                else if (pFS != null && nFS == null)
                {
                    name = was["Name"].ToString();
                    Invoke(new Action<string>(SetMessage), "New disk was removed " + name);
                    Invoke(new Action<string, string>(OnRemoveDisk), "5", name);
                }
            }
            catch (Exception ex) { new FormMsg("Win32_VolumeChangeEvent: " + ex.Message, 3000); }
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            showHidden = checkHidden.Checked;
            try
            {
                FillTree();
                SetEventWatchers();
            }
            catch (Exception ex)
            {
                new FormMsg(ex.Message, 3000);
            }
        }


        void SetFileList()
        {
            
            fileList.Columns.Add("Name", 200, HorizontalAlignment.Left);	// Создаем колонки в списке файлов
            fileList.Columns.Add("Size", 100, HorizontalAlignment.Right);
            fileList.Columns.Add("Created", 150, HorizontalAlignment.Left);
            fileList.Columns.Add("Modified", 150, HorizontalAlignment.Left);
            fileList.Sorting = SortOrder.Ascending;
        }

        void FillTree()
        {
            root = new TreeNode(rootName, 0, 1);
            root.Tag = false;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(
                @"\\localhost\root\CIMV2", "SELECT DeviceId, DriveType From Win32_LogicalDisk");
            TreeNodeCollection nodes = root.Nodes;
            foreach (var drive in searcher.Get())
            {
                string
                    name = drive["DeviceId"].ToString(),
                    type = drive["DriveType"].ToString();
                AddWatcher(type, name);
                int id = GetImageID(type, name);
                TreeNode n = new TreeNode(name, id, id + 1);
                n.Tag = false;
                nodes.Add(n);
            }
            tree.BeginUpdate();
            tree.Nodes.Add(root);
            tree.EndUpdate();
            root.Expand();
        }

        void AddWatcher(string type, string name)
        {
            if (name.StartsWith("A") || type == "5") return; 	// Floppy or CDROM^
            if (name == "Q:") return;
            FileSystemWatcher w = new FileSystemWatcher(name + '\\');
            w.NotifyFilter = NotifyFilters.DirectoryName | NotifyFilters.FileName
                | NotifyFilters.Attributes | NotifyFilters.Size;
            w.IncludeSubdirectories = true;
            w.SynchronizingObject = this;

            w.Created -= new FileSystemEventHandler(w_Created);
            w.Deleted -= new FileSystemEventHandler(w_Deleted);
            w.Renamed -= new RenamedEventHandler(w_Renamed);
            w.Changed -= new FileSystemEventHandler(w_Changed);

            w.Created += new FileSystemEventHandler(w_Created);
            w.Deleted += new FileSystemEventHandler(w_Deleted);
            w.Renamed += new RenamedEventHandler(w_Renamed);
            w.Changed += new FileSystemEventHandler(w_Changed);

            checkHidden.CheckedChanged -= new EventHandler(checkHidden_CheckedChanged);
            checkHidden.CheckedChanged += new EventHandler(checkHidden_CheckedChanged);
            w.EnableRaisingEvents = true;

            watchers.Add(w);
        }

        void w_Changed(object sender, FileSystemEventArgs e)
        {
            try
            {
                if (!InExpandenDir(e.FullPath))
                    return;
                DirectoryInfo dir = new DirectoryInfo(e.FullPath);
                bool isFolder = (uint)(dir.Attributes & FileAttributes.Directory) != 0;
                if (isFolder)
                {
                    TreeNode node = FindNode(e.FullPath);
                    if (node == null)
                    {
                        CreateNewChNode(tree.Nodes[0].Nodes, dir.FullName);
                    }
                    TreeNode par = node.Parent;
                    par.Nodes.Remove(node);
                    FillFolder(par, 2);
                }
                FillFileList(tree.SelectedNode);
                if(tree.SelectedNode != null)
                SetMessage("Changed: " + dir.FullName + ". Attributes: " + dir.Attributes); //GetAttributes(dir)
            }
            catch (Exception ex) { SetMessage("Changed: " + ex.Message); }
        }

       void CreateNewChNode(TreeNodeCollection nodes, string dir)
       {
           if (dir.IndexOf('\\') == -1)
           {
               TreeNode newNode = new TreeNode(dir,14,15);
               nodes.Add(newNode);
           }
           TreeNode node = new TreeNode();
           char slash = '\\';
           string name = dir.Substring(0, dir.IndexOf(slash));
           for(int i = 0; i < nodes.Count; i++)
           {
               if (nodes[i].Text == name)
               {
                   node=nodes[i];
                   break;
               }
           }
           int index = dir.IndexOf(slash) + 1;
           string param = dir.Substring(index , dir.Length - index);
           CreateNewChNode(node.Nodes, param);
       }
        void w_Renamed(object sender, RenamedEventArgs e)
        {
            try
            {
                if (!InExpandenDir(e.FullPath))
                    return;
                TreeNode node = FindNode(e.OldFullPath);
                if (node != null)
                    node.Text = GetFolderName(e.FullPath);
                FillFileList(tree.SelectedNode);
            }
            catch (Exception ex) { SetMessage("Changed: " + ex.Message); }
        }


        void w_Deleted(object sender, FileSystemEventArgs e)
        {
            try
            {
                if (!InExpandenDir(e.FullPath))
                    return;
                TreeNode node = FindNode(e.FullPath);
                if (node != null)
                    tree.Nodes.Remove(node);
                FillFileList(tree.SelectedNode);
            }
            catch (Exception ex) { SetMessage("Changed: " + ex.Message); }
        }



        void w_Created(object sender, FileSystemEventArgs e)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(e.FullPath);
                if (!InExpandenDir(e.FullPath))
                    return;
                bool isFolder = (uint)(dir.Attributes & FileAttributes.Directory) != 0;
                if (isFolder)
                {
                    bool bHidden = (uint)(dir.Attributes & hidden) != 0;
                    TreeNode node = FindNode(e.FullPath.Substring(0, e.FullPath.IndexOf(e.Name)));
                    FillFolder(node, 2);
                }
                else
                    FillFileList(tree.SelectedNode);
            }
            catch (Exception ex) { SetMessage(ex.Message); }
        }

        bool InExpandenDir(string dir)
        {
            if (dir.IndexOf("Temp") != -1 || dir.IndexOf("avast") != -1 || dir.IndexOf("Mozilla") != -1 || dir.IndexOf("Microsoft") != -1)
                return false;
            dir = "My Computer\\" + dir.Substring(0, dir.LastIndexOf('\\'));
            foreach (TreeNode node in treeExpandedNodes)
            {
                if (node.FullPath.IndexOf(dir) != -1)
                    return true;
            }
            return false;
        }

        void checkHidden_CheckedChanged(object sender, EventArgs e)
        {
            showHidden = checkHidden.Checked;
            ToggleHidden();
        }

        public void ToggleHidden()
        {
            tree.BeginUpdate();
            if (showHidden)
            {
                foreach (TreeNode node in treeExpandedNodes)
                {
                    FillFolder(node, 2);
                }
            }
            else
            {
                foreach (TreeNode node in treeExpandedNodes)	// По всем узлам, вложенным в корневой узел дерева
                {
                    List<TreeNode> delNods = new List<TreeNode>();
                    foreach(TreeNode no in node.Nodes)
                    {
                        if ((bool)no.Tag)
                            delNods.Add(no);
                    }
                    foreach (TreeNode no in delNods)
                        node.Nodes.Remove(no);
                }
            }
            FillFileList(tree.SelectedNode);
            RestoreExpanded();	// Восстанавливаем коллекцию раскрытых узлов
            tree.EndUpdate();
        }

        void RestoreExpanded()
        {
            foreach (TreeNode node in treeExpandedNodes)
                if(node.IsExpanded)
                    node.Expand();
        }

        string GetPathToFolder(TreeNode node) { return node.FullPath.Substring(rootName.Length + 1) + '\\'; }

        string GetFolderName(string path) { return path.TrimEnd('\\').Remove(0, path.LastIndexOf('\\') + 1); }

        void FillFolder(TreeNode node, int depth)
        {

            if (depth == 0) return;

            try
            {
                string path = GetPathToFolder(node);
                if (path != null)
                {
                    TreeNodeCollection nodes = node.Nodes; // Получите коллекцию вложенных узлов;
                    string[] folders = Directory.GetDirectories(path); //Получите коллекцию вложенных папок (используйте Directory);
                    foreach (string folder in folders)
                    {
                        DirectoryInfo dir = new DirectoryInfo(folder); // Получите информацию о папке с именем folder;

                        bool usual = (dir.Attributes & hidden) == 0;

                        if (usual || showHidden)
                        {
                            int imgID = usual ? 14 : 16;
                            TreeNode n = new TreeNode(GetFolderName(folder), imgID, imgID + 1);
                            n.Tag = false;
                            if (!usual)
                                n.Tag = true;
                            bool innodes = false;
                            foreach (TreeNode nn in nodes)
                            {
                                if (GetFolderName(nn.FullPath) == n.Text)
                                    innodes = true;
                            }

                            if (!innodes)
                                nodes.Add(n);
                            FillFolder(n, depth - 1);
                        }
                    }
                }
            }
            catch (Exception ex) { SetMessage(ex.Message); }
        }

        void fileList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            FileComparer cmp = fileList.ListViewItemSorter as FileComparer;
            bool repeat = cmp.col == e.Column;
            cmp.col = e.Column;
            if (repeat)
                cmp.order = cmp.order == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            fileList.Sort();
        }

        void tree_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (!treeExpandedNodes.Contains(e.Node))
                treeExpandedNodes.Add(e.Node);
            if (e.Node.Parent != null)
            {
                new FormMsg("Please, wait...", 1000);
                FillFolder(e.Node, 2);
            }
        }


        void tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent != null)
            {
                if (!treeExpandedNodes.Contains(e.Node))
                    treeExpandedNodes.Add(e.Node);
                new FormMsg("Please, wait...", 1000);
                FillFolder(e.Node, 2);
                FillFileList(e.Node);
            }
        }

        void FillFileList(TreeNode node)
        {
            fileList.Items.Clear();
            if (node.Parent != null)
            {
                lblDirInfo.Text = node.Text;
                DirectoryInfo dir = new DirectoryInfo(GetPathToFolder(node));// Получите информацию о папке, соответствующей узлу node
                if (dir != null)
                {
                    lblDirInfo.Text = dir.Name;
                    FileInfo[] files;
                    try { files = dir.GetFiles(); }
                    catch (Exception ex) { lblDirInfo.Text += separator + ex.Message; return; }
                    hiddenCount = 0;

                    List<ListViewItem> items = new List<ListViewItem>();
                    foreach (FileInfo file in files)
                    {
                        ListViewItem item = CreateFileListItem(file);
                        if (item != null)
                            items.Add(item);
                    }
                    
                    fileList.Items.AddRange(items.ToArray());
                    lblDirInfo.Text += separator + files.Length + " files";
                    if (hiddenCount > 0)
                        lblDirInfo.Text += separator + "(" + hiddenCount + " hidden)";
                }
            }
        }



        ListViewItem CreateFileListItem(FileInfo file)
        {
            bool bHidden = (file.Attributes & hidden) != 0;
            if (bHidden)
                hiddenCount++;
            if (!bHidden || showHidden)
            {
                long len = file.Length;
                string size =
                    len > 1073741823 ? (len / 1073741824.0).ToString("f2") + "  G" :
                    len > 1048575 ? (len / 1048576.0).ToString("f2") + "  M" :
                    len > 1024 ? (len / 1024.0).ToString("f2") + "  K" : len.ToString();

                Color clr = bHidden ? Color.FromArgb(150, 150, 255) : Color.Black;
                return new ListViewItem(new string[]
				{
					file.Name,
					size,
					file.CreationTime.ToShortDateString() + separator + file.CreationTime.ToShortTimeString(),
					file.LastWriteTime.ToShortDateString() + separator + file.LastWriteTime.ToShortTimeString()
				}, 0, clr, Color.White, fileList.Font);
            }
            return null;
        }
        
        void SetEventWatchers()
        {
            try
            {
                watchUSB = new ManagementEventWatcher("SELECT * FROM Win32_VolumeChangeEvent");
                watchUSB.EventArrived += new EventArrivedEventHandler(watchUSB_EventArrived);
                watchUSB.Start();

                watchCD = new ManagementEventWatcher(new WqlEventQuery(
                    "__InstanceModificationEvent", TimeSpan.FromSeconds(1),
                    "TargetInstance isa 'Win32_LogicalDisk'"));
                watchCD.EventArrived += new EventArrivedEventHandler(watchCD_EventArrived);
                watchCD.Start();
            }
            catch (ManagementException ex)
            {
                new FormMsg("Win32_VolumeChangeEvent: " + ex.Message, 3000);
            }
        }

        void FileSystemControl_Disposed(object sender, EventArgs e)
        {
            if (watchUSB != null)
            {
                watchUSB.Stop();
                watchUSB.Dispose();
            }
            if (watchUSB != null)
            {
                watchCD.Stop();
                watchCD.Dispose();
            }
            foreach (var w in watchers)
                w.Dispose();
            watchers.Clear();
        }

        void watchUSB_EventArrived(object sender, EventArrivedEventArgs e)
        {
            try
            {
                ManagementBaseObject mo = e.NewEvent as ManagementBaseObject;
                ushort type = (ushort)mo["EventType"];
                string name = mo["DriveName"].ToString(), msg = "";

                switch (type)
                {
                    case 1: msg = " Changed Configuration"; break;
                    case 2: msg = " added";
                        Invoke(new Action<string, string>(OnAddDisk), new object[] { "6", name });
                        break;
                    case 3: msg = " removed";
                        Invoke(new Action<string, string>(OnRemoveDisk), new object[] { "6", name });
                        break;
                    case 4: msg = " docking"; break;
                }
                msg = name + msg;
                Invoke(new Action<string>(SetMessage), new object[] { msg });
            }
            catch (Exception ex) { new FormMsg(ex.Message, 4000); }
        }

        void OnAddDisk(string type, string name)
        {
            SetMessage("New drive " + name + " was attached.");
            TreeNode node = null;
            if (name.StartsWith("A:") || type == "5")
                node = FindNode(name);
            else
            {
                int id = GetImageID(type, name);
                node = new TreeNode(name, id, id + 1);
                int pos = FindNodeIndex(node);
                root.Nodes.Insert(pos, node);
                AddWatcher(type, name);
            }
            FillFolder(node, 2);
        }

        int FindNodeIndex(string name) // Not used now (maybe later...)
        {
            int pos = 0;
            foreach (TreeNode n in root.Nodes)
            {
                if (name.CompareTo(n.Text) == 0)
                    break;
                pos++;
            }
            return pos;
        }

        int FindNodeIndex(TreeNode node)
        {
            int pos = 0;
            foreach (TreeNode n in root.Nodes)
            {
                if (node.Text.CompareTo(n.Text) < 0)
                    break;
                pos++;
            }
            return pos;
        }

        void OnRemoveDisk(string type, string name)
        {
            SetMessage("Disk " + name + " was removed.");
            if (name.StartsWith("A:") || type == "5")
            {
                TreeNode node = FindNode(name);
                node.Nodes.Clear();
                node.Tag = null;
            }
            else
            {
                int pos = FindNodeIndex(name);
                if (pos != -1)
                {
                    FileSystemWatcher w = watchers.Find(c => c.Path.StartsWith(name));
                    if (w != null)
                    {
                        watchers.Remove(w);
                        w.Dispose();
                    }
                    root.Nodes.RemoveAt(pos);
                }
            }
        }

        TreeNode FindNode(string path)
        {
            pathToFind = (rootName + '\\' + path).TrimEnd('\\');
            return FindRecursive(tree.Nodes[0]);
        }

        TreeNode FindRecursive(TreeNode node)
        {
            foreach (TreeNode n in node.Nodes)
            {
                if (pathToFind.Equals(n.FullPath, StringComparison.InvariantCultureIgnoreCase))
                    return n;

                if (pathToFind.StartsWith(n.FullPath + '\\') && n.Tag != null)
                    return FindRecursive(n);
            }
            return null;
        }

        void SetMessage(string s)
        {
            if (UpdateStatus != null)
                UpdateStatus(s);
        }

        int GetImageID(string type, string name)
        {
            return
                type == "3" ? 2 :  // LocalDiskDrive
                type == "5" ? 4 :  // CDROMDrive
                type == "2" ? name.StartsWith("A:") ? 8 : 6 : // RemovableDrive
                type == "4" ? 10 : // NetworkDrive
                type == "6" ? 12 : 0; // RAMDrive
        }

            }

    class FileComparer : IComparer
    {
        public int col;
        public SortOrder order;
        public FileComparer() { col = 0; order = SortOrder.Ascending; }

        public string MyTrim(string s)
        {
            if (col == 1)
            {
                if (s.LastIndexOf('K') != -1)
                {
                    s = s.TrimEnd('K', ' ');
                    s = (double.Parse(s) * 1024).ToString();
                }
                else if (s.LastIndexOf('M') != -1) //Справа есть символ 'M')
                {
                    s = s.TrimEnd('M', ' ');
                    s = (double.Parse(s) * 1048576).ToString();
                }
                else if (s.LastIndexOf('G') != -1)
                {
                    s = s.TrimEnd('G', ' ');
                    s = (double.Parse(s) * 1073741824).ToString();
                }
            }
            return s;
        }
        public int Compare(object x, object y)
        {
            int res = 0;
            string
                s1 = MyTrim(((ListViewItem)x).SubItems[col].Text),
                s2 = MyTrim(((ListViewItem)y).SubItems[col].Text);
            switch (col)
            {
                case 0: res = s1.CompareTo(s2); break;
                case 1: res = double.Parse(s1).CompareTo(double.Parse(s2)); break; //Повторите проверку для типа double;
                case 2:
                case 3: res = DateTime.Parse(s1).CompareTo(DateTime.Parse(s2)); break;// Повторите проверку для типа DateTime;
            }
            if (order == SortOrder.Descending)
                res *= -1;
            return res;
        }
    }
}
