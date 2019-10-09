using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.Xml.Linq;
using System.IO;

namespace Library
{
    public partial class WMIControl : UserControl
    {
        int nsCount, nsHidden, nClasses, nProps, nMethods, nQualifiers;
        string nsName, clsName, xmlFile;
        ManagementClass curClass;
        XDocument xDoc;

        public WMIControl()
        {
            InitializeComponent();

            listMethods.SelectedIndexChanged += new EventHandler(listMethods_SelectedIndexChanged);
            listProp.SelectedIndexChanged += new EventHandler(listProp_SelectedIndexChanged);
            listQualifiers.SelectedIndexChanged += new EventHandler(listQualifiers_SelectedIndexChanged);
            btnGetValues.Click += new EventHandler(btnGetValues_Click);
        }

        public void SetNamespaces()
        {
            lblCount.Text = "Filling the tree...";
            treeNS.Enabled = false;
            nsCount = nsHidden = 0;

            if (IsTreeSaved())
            {
                ReadNamespaces();
                lblCount.Text = nsCount + " namespaces";
            }
            else
            {
                QueryNamespaces();
                lblCount.Text = nsCount + " namespaces (" + nsHidden + " hidden)";
            }

            treeNS.Enabled = true;
            treeClasses.Nodes.Add("WMI Classes", "WMI Classes", 0, 0);
            treeNS.AfterSelect += new TreeViewEventHandler(treeNS_AfterSelect);
            treeClasses.AfterSelect += new TreeViewEventHandler(treeClasses_AfterSelect);
        }

        bool IsTreeSaved()
        {
            xmlFile = Globals.FindFolder("Data");
            if (xmlFile != null)
            {
                xmlFile += "WMI.xml";
                if (File.Exists(xmlFile))
                    return true;
            }
            return false;
        }

        void QueryNamespaces()
        {
            FormSplash.ShowForm("Searching for WMI Namespaces... Please, wait");

            RecurseNamespaces("root", treeNS.Nodes.Add("root", "root", 1, 2).Nodes);
            treeNS.Nodes[0].Expand();

            xDoc = new XDocument(new XElement("root"));
            AddXNodeRecursive(xDoc.Root, treeNS.Nodes[0]);
            SaveNamespacesTree();
            FormSplash.CloseForm();
        }

        void RecurseNamespaces(string path, TreeNodeCollection nodes)
        {
            try
            {
                ManagementClass mc = new ManagementClass(
                    new ManagementScope(path),
                    new ManagementPath("__namespace"), null);
                foreach (ManagementObject mo in mc.GetInstances())
                {
                    string name = path + "\\" + mo["Name"].ToString();
                    nsCount++;
                    string s = mo["Name"].ToString();
                    FormSplash.AddItem(name);
                    RecurseNamespaces(name, nodes.Add(s, s, 1, 2).Nodes);
                }
            }
            catch (ManagementException e) { SetError(e.Message, path); }
        }


        void SetError(string msg, string path)
        {
            FormSplash.AddMsg(msg + ":  " + path);
            DeleteNode(path);
        }


        void DeleteNode(string path)
        {
            string[] tokens = path.Split('\\');
            string name = tokens[tokens.Length - 1];
            TreeNodeCollection nodes = treeNS.Nodes;
            foreach (string s in tokens)
            {
                if (s == name)
                    break;
                nodes = nodes[s].Nodes;
            }
            nodes.Remove(nodes[name]);
            nsHidden++;		// Счетчик скрытых пространств имен (доступ к ним запрещен)
        }

        void AddXNodeRecursive(XElement x, TreeNode node)
        {
            foreach (TreeNode n in node.Nodes)
            {
                XElement o = new XElement(n.Text);
                x.Add(o);
                AddXNodeRecursive(o, n);
            }
        }


        void SaveNamespacesTree()
        {
            try
            {
                if (xmlFile == null)
                {
                    string dir = Application.StartupPath;
                    dir = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(dir)));
                    dir = Directory.CreateDirectory(dir + "\\Data").FullName;
                    xmlFile = dir + "\\WMI.xml";
                }
                xDoc.Save(xmlFile);
            }
            catch (Exception ex) { new FormMsg(ex.Message, 4000); }
        }

        void ReadNamespaces()
        {
            try
            {
                treeNS.Nodes.Add("root", "root", 1, 2);
                xDoc = XDocument.Load(xmlFile);
                AddTNodeRecursive(xDoc.Root, treeNS.Nodes[0]);
                treeNS.Nodes[0].Expand();
            }
            catch (Exception ex) { new FormMsg("Read Xml Tree:\r\n" + ex.Message, 4000); }
        }

        void AddTNodeRecursive(XElement x, TreeNode node)
        {
            foreach (XElement e in x.Elements())
            {
                string name = e.Name.LocalName;
                nsCount++;
                AddTNodeRecursive(e, node.Nodes.Add(name, name, 1, 2));
            }
        }






        void treeClasses_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == treeClasses.Nodes[0] || treeNS.SelectedNode == null)
                return;
            ClearLists();
            nsName = treeNS.SelectedNode.FullPath;
            clsName = treeClasses.SelectedNode.Text;
            lblMethods.Text = clsName;

            try
            {
                curClass = new ManagementClass(nsName, clsName, null);
                ObjectGetOptions op = new ObjectGetOptions(null, TimeSpan.MaxValue, true);
                curClass.Options.UseAmendedQualifiers = true;

                foreach (MethodData m in curClass.Methods)
                {
                    listMethods.Items.Add(m.Name);
                    nMethods++;
                }
                foreach (PropertyData p in curClass.Properties)
                {
                    listProp.Items.Add(p.Name);
                    nProps++;
                }
                foreach (QualifierData q in curClass.Qualifiers)
                {
                    if (q.Name.Equals("Description"))
                        tDescrClasses.Text = q.Value.ToString();
                    listQualifiers.Items.Add(q.Name);
                    nQualifiers++;
                }
                lblNumProp.Text = nProps + " properties";
                lblNumMethods.Text = nMethods + " methods";
                lblNumQualifiers.Text = nQualifiers + " qualifiers";
            }
            catch (ManagementException) { }
        }


        void treeNS_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ClearLists();
            treeClasses.Nodes[0].Collapse();
            treeClasses.Nodes[0].Nodes.Clear();
            treeClasses.BeginUpdate();
            lblNamespace.Text = "Searching...";
            treeNS.Enabled = treeClasses.Enabled = false;

            string path = e.Node.FullPath; // Выбранное в дереве имя пространства имен
            GetClasses(path);

            treeNS.Enabled = treeClasses.Enabled = true;
            lblNamespace.Text = nClasses + " classes";
            treeClasses.EndUpdate();
            treeClasses.Nodes[0].Expand();
            lblCount.Text = path;
            treeClasses.Sort();
        }

        void GetClasses(string ns)
        {
            FormSplash.ShowForm("Searching for WMI Classes... Please, wait");
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(
                    new ManagementScope(ns),
                    new SelectQuery("meta_class"), null);
                foreach (ManagementClass c in searcher.Get())
                {
                    string name = c["__CLASS"].ToString();
                    nClasses++;
                    AddClass(name, c);
                    FormSplash.AddItem(name);
                }
            }
            catch (Exception e) { SetError(e.Message, ns); }
            FormSplash.CloseForm();
        }

        void AddClass(string name, ManagementClass c)
        {
            TreeNode node = treeClasses.Nodes[0];
            if (c.Derivation.Contains("__Event"))
            {
                Globals.FindOrAddNode("Event-Generating", ref node);
                MyEvents.Classify(name, ref node);
            }
            else
            {
                if (TestForProperties(c, ref node))
                    MyProperties.Classify(name, ref node);
                else
                {
                    Globals.FindOrAddNode("Other", ref node);
                    MyOther.Classify(name, ref node);
                }
            }
            node.Nodes.Add(name, name, 3, 2);
        }

        bool TestForProperties(ManagementClass c, ref TreeNode node)
        {
            foreach (QualifierData qd in c.Qualifiers)
            {
                if (qd.Name.Equals("dynamic") || qd.Name.Equals("static"))
                {
                    Globals.FindOrAddNode("Properties Owners", ref node);
                    return true;
                }
            }
            return false;
        }
        void ClearLists()
        {
            curClass = null;
            nClasses = nMethods = nProps = nQualifiers = 0;
            lblNumMethods.Text = lblNumProp.Text = "Select a class...";
            lblNumQualifiers.Text = "Select a property, method or qualifier...";
            listProp.Items.Clear();
            listMethods.Items.Clear();
            listQualifiers.Items.Clear();
            tDescrClasses.Text = tDescr.Text = "";
            btnGetValues.Visible = false;
        }



        void listProp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (curClass == null)
                return;
            btnGetValues.Visible = true;

            try
            {
                lblDescr.Text = "Property: " + listProp.Text;
                foreach (PropertyData p in curClass.Properties)
                {
                    if (p.Name.Equals(listProp.Text))
                    {
                        foreach (QualifierData q in p.Qualifiers)
                        {
                            if (q.Name.Equals("Description"))
                            {
                                tDescr.Text = curClass.GetPropertyQualifierValue(p.Name, q.Name).ToString();
                                return;
                            }
                        }
                    }
                }
            }
            catch (ManagementException ex)
            {
                tDescr.Text = ex.Message;
            }
        }

        void listMethods_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (curClass == null)
                return;
            btnGetValues.Visible = false;
            try
            {
                lblDescr.Text = "Method: " + listMethods.Text;
                foreach (MethodData m in curClass.Methods)
                {
                    if (m.Name.Equals(listMethods.Text))
                    {
                        foreach (QualifierData q in m.Qualifiers)
                        {
                            if (q.Name.Equals("Description"))
                            {
                                tDescr.Text = q.Value.ToString();
                                return;
                            }
                        }
                    }
                }
            }
            catch (ManagementException ex) { tDescr.Text = ex.Message; }
        }

        void listQualifiers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (curClass == null)
                return;
            btnGetValues.Visible = false;
            try
            {
                lblDescr.Text = "Qualifier: " + listQualifiers.Text;
                foreach (QualifierData q in curClass.Qualifiers)
                {
                    if (q.Name.Equals(listQualifiers.Text))
                    {
                        tDescr.Text = q.Value.ToString();
                        return;
                    }
                }
            }
            catch (ManagementException ex)
            {
                tDescr.Text = ex.Message;
            }
        }

        void btnGetValues_Click(object sender, EventArgs e)
        {
            //FormSplash.ShowForm("Searching for all objects properties... Please, wait");

            List<string[]> list = new List<string[]>();
            foreach (ManagementObject mo in curClass.GetInstances())
            {
                string name;
                try { name = mo["Name"].ToString(); }
                catch
                {
                    name = mo.ToString();
                    name = name.Substring(name.IndexOf('.') + 1);
                }
                //FormSplash.AddItem(name);

                foreach (PropertyData p in curClass.Properties)
                {
                    if (p.Name == listProp.Text)
                    {
                        object o = mo[p.Name];
                        string val = o == null ? "Null" : o.ToString();
                        list.Add(new string[] { name, val });
                        //FormSplash.AddMsg(val);
                    }
                }
            }
            //FormSplash.CloseForm();
            if (list.Count == 0)
                new FormMsg("No oblects of " + curClass.ToString() + " found", 5000);
            else
            {
                FormValues form = new FormValues("Values of property: " + listProp.Text, list);
                form.ShowDialog();
            }
        }



    }
}
