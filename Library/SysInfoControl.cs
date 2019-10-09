using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;

namespace Library
{
    public partial class SysInfoControl : UserControl
    {
        public SysInfoControl()
        {
            InitializeComponent();
        }

        void rdRemote_CheckedChanged(object sender, EventArgs e)
        {
            boxAdmin.Visible = rdRemote.Checked;
        }


        void bRefresh_Click(object sender, EventArgs e)
        {
            //SetMessage("Refreshing Computer Information...");
            //FillTree();
            GetSysInfo();
        }

        void GetSysInfo()
        {
            string sMachine = rdCurrent.Checked ? "localhost" : textName.Text; // В зависимости от состояния кнопки rdCurrent создаем имя компьютера

            if (sMachine.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Machine IP address or name is needed");
                return;
            }

            ConnectionOptions co = new ConnectionOptions();
            if (textUserID.Text.Trim().Length > 0)
            {
                co.Username = textUserID.Text;
                co.Password = textPass.Text;
            }
            string[] classes = { "Win32_ComputerSystem", "Win32_Processor", "Win32_LogicalMemoryConfiguration", "Win32_LogicalDisk", "Win32_VideoController", "Win32_OperatingSystem", "Win32_TimeZone", "Win32_Bios", "Win32_NetworkAdapter" };

            //====== Начало блока, который будет повторяться для каждого класса WMI
            
            foreach (string wmi_class in classes)
            {
                int imagindex = SetImageIndex(wmi_class);
                ManagementScope ms = new ManagementScope("\\\\" + sMachine + "\\root\\cimv2", co);
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(ms, new SelectQuery(wmi_class));

                TreeNode nodelevel1 = new TreeNode(SetTreeNodeName(wmi_class), imagindex, imagindex); 
                try
                {
                    foreach (var mo in searcher.Get())
                    {
                        TreeNode treelevel2 = new TreeNode();
                         try
                        {
                            treelevel2 = new TreeNode(mo.Properties["Name"].Value.ToString(), imagindex + 1, imagindex + 1);
                        }
                         catch { treelevel2 = new TreeNode("N/A", imagindex + 1, imagindex + 1); }
                            foreach (var propert in mo.Properties)
                            {
                                if(propert.Value != null)
                                    treelevel2.Nodes.Add(new TreeNode(propert.Name + ": " + propert.Value, imagindex + 1, imagindex+1));
                            }
                            nodelevel1.Nodes.Add(treelevel2);
                            
                        
                    }
                    tree.Nodes.Add(nodelevel1);
                    
                }
                catch { }
            }

        }
        string SetTreeNodeName(string wmi_class)
        {
            return
                wmi_class == "Win32_ComputerSystem" ? "Computer System" :
                wmi_class == "Win32_Processor" ? "Processor" :
                wmi_class == "Win32_LogicalMemoryConfiguration" ? "Logical Memory Configuration" :
                wmi_class == "Win32_LogicalDisk" ? "Logical Disk" :
                wmi_class == "Win32_VideoController" ? "Video Controller" :
                wmi_class == "Win32_OperatingSystem" ? "Operating System" :
                wmi_class == "Win32_TimeZone" ? "Time Zone" :
                wmi_class == "Win32_Bios" ? "Bios" :
                wmi_class == "Win32_NetworkAdapter" ? "Network Adapter" : "";
        
        }

        int SetImageIndex(string wmi_class)
        {
            return
                wmi_class == "Win32_ComputerSystem" ? 0 :
                wmi_class == "Win32_Processor" ? 2 :
                wmi_class == "Win32_LogicalMemoryConfiguration" ? 4 :
                wmi_class == "Win32_LogicalDisk" ? 4 :
                wmi_class == "Win32_VideoController" ? 6 :
                wmi_class == "Win32_OperatingSystem" ? 8 :
                wmi_class == "Win32_TimeZone" ? 14 :
                wmi_class == "Win32_Bios" ? 10 :
                wmi_class == "Win32_NetworkAdapter" ? 12 : 0;
        }


    }
}
