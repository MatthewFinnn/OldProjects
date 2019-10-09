using System;
using System.Windows.Forms;
using System.Management;
using System.Net.NetworkInformation;


namespace Library
{
    public partial class IRQControl : UserControl
    {
        #region Data
        ManagementObjectSearcher searcher;
        ManagementClass curClass;
        TreeNode adap;

        #endregion

        public IRQControl()
        {
            InitializeComponent();
            SetTree();
            tree.NodeMouseClick += new TreeNodeMouseClickEventHandler(tree_NodeMouseClick);
            tree.AfterSelect += new TreeViewEventHandler(tree_AfterSelect);
            curClass = new ManagementClass("\\\\localhost\\root\\cimv2", "Win32_NetworkAdapterConfiguration", null);
            curClass.Options.UseAmendedQualifiers = true;
            Load += new EventHandler(IRQControl_Load);
        }

        void IRQControl_Load(object sender, EventArgs e)
        {
            tree.Nodes[0].Expand();
            tree.Nodes[0].Nodes[11].Expand();
            adap = tree.Nodes[0].Nodes[11];
        }

        void tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            tDescr.Text = curClass.Qualifiers["Description"].Value.ToString();

            TreeNode propNode = new TreeNode();
            if (e.Node.Level == 3)
                propNode = e.Node.Parent;
            if (e.Node.Level == 2)
                propNode = e.Node;
            adap = propNode.Parent;
            try
            {
                foreach (PropertyData p in curClass.Properties)
                {
                    if (p.Name == propNode.Name)
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
            catch
            {

            }

        }

        void tree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

        }



        void SetTree()
        {
            tree.Nodes.Clear();
            tree.Nodes.Add("net", "Networc Adapter Configuration", 0, 0);


            searcher = new ManagementObjectSearcher(
                "Select * from Win32_NetworkAdapterConfiguration");

            foreach (var process in searcher.Get())
            {
                int imgind = process["IpEnabled"].ToString() == "True" ? 1 : 2;
                TreeNode added = new TreeNode(process["Description"].ToString(), imgind, imgind);
                foreach (var propert in process.Properties)
                {
                    TreeNode propnode = new TreeNode("", 3, 3);
                    if (propert.IsArray && propert.Value != null)
                    {
                        string[] t = propert.Value as string[];
                        propnode.Name = propert.Name;
                        propnode.Text = propert.Name;
                        try
                        {
                            for (int i = 0; ; i++)
                            {
                                propnode.Nodes.Add(t[i], t[i], 3, 3);
                            }
                        }
                        catch
                        {
                            if (propnode.Nodes.Count == 0)
                                propnode.Nodes.Add("n/a", "N/A", 3, 3);

                            added.Nodes.Add(propnode);
                        }
                    }
                    //if (propert.Name.IndexOf("TcpWin") != -1)
                    //{ string.Empty.ToString(); }
                    else if (propert.Value != null)
                        added.Nodes.Add(propert.Name, propert.Name + ": " + propert.Value, 3, 3);
                }
                tree.Nodes[0].Nodes.Add(added);

            }

        }

        void SetDNSSuffixSearchOrderMethod(object[] DNSDomain, string adapterID)
        {

            ManagementObjectSearcher searcher = new ManagementObjectSearcher(
                        "Select * from Win32_NetworkAdapterConfiguration Where  Index =" + adapterID);
            if (searcher.Get().Count != 0)
            {
                uint t;
                foreach (ManagementObject mo in searcher.Get())
                {
                    object o = mo.InvokeMethod("SetDNSDomain", DNSDomain);
                    t = (uint)o;
                    //t = (int)mo.InvokeMethod("SetDNSDomain", DNSDomain);
                }
            }

        }



        private void button1_Click(object sender, EventArgs e)
        {
            string[] arr = { textDNSName.Text };
            SetDNSSuffixSearchOrderMethod(arr, adap.Index.ToString());
            SetTree();
            Ping ping = new Ping();
            PingReply reply;
            try
            {
                reply = ping.Send(arr[0]);
                if (reply.Status == IPStatus.Success)
                    labelIp.Text = "IP: " + reply.Address.ToString();
            }
            catch { labelIp.Text = "N/A"; }

            tree.Nodes[0].Expand();
            tree.Nodes[0].Nodes[adap.Index].Expand();
        }

        private void btnSetGateways_Click(object sender, EventArgs e)
        {
            string arr = textGateways.Text;
            SetGateways(arr, adap.Index.ToString());
            SetTree();
            tree.Nodes[0].Expand();
            tree.Nodes[0].Nodes[adap.Index].Expand();
        }

        void SetGateways(string DNSDomain, string adapterID)
        {

            ManagementObjectSearcher searcher = new ManagementObjectSearcher(
                        "Select * from Win32_NetworkAdapterConfiguration Where  Index =" + adapterID);
            if (searcher.Get().Count != 0)
            {
                ManagementBaseObject t;
                foreach (ManagementObject mo in searcher.Get())
                {
                    ManagementBaseObject newGate = mo.GetMethodParameters("SetGateways");
                    newGate["DefaultIPGateway"] = new string[] { DNSDomain };
                    newGate["GatewayCostMetric"] = new int[] { 1 };

                    object o = mo.InvokeMethod("SetGateways", newGate, null);
                    t = (ManagementBaseObject)o;
                    //t = (int)mo.InvokeMethod("SetDNSDomain", DNSDomain);
                }
            }

        }

        private void buttonPing_Click(object sender, EventArgs e)
        {
            textIPPings.Text = string.Empty;
            MyPing(textHostName.Text);
        }

        string MyPing(string hostName)
        {
            try
            {
                Ping ping = new Ping();
                PingReply reply = ping.Send(hostName);
                if (reply.Status == IPStatus.Success)
                {
                    textIPPings.Text += "Address: " + reply.Address.ToString() + "\r\n";
                    textIPPings.Text += "RoundTrip time: " + reply.RoundtripTime.ToString() + "\r\n";
                    textIPPings.Text += "Time to live: " + reply.Options.Ttl.ToString() + "\r\n";
                    textIPPings.Text += "Don't fragment: " + reply.Options.DontFragment.ToString() + "\r\n";
                    textIPPings.Text += "Buffer size: " + reply.Buffer.Length.ToString() + "\r\n";

                }
                return reply.Address.ToString();
            }
            catch { textIPPings.Text = "Error"; return "N/A"; }

        }

        private void buttonTTL_Click(object sender, EventArgs e)
        {

        }



    }
}








