using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;

namespace WMI
{
    public partial class MainForm : Form
    {
        ManagementEventWatcher watcherCreate;
        public MainForm()
        {
            InitializeComponent();
            wmi.SetNamespaces();

            watcherCreate = new ManagementEventWatcher(
    @"Select * from __Event" );

            watcherCreate.EventArrived += new EventArrivedEventHandler(watcherCreate_EventArrived);
        }

        void watcherCreate_EventArrived(object sender, EventArrivedEventArgs e)
        {

            foreach (var prop in e.NewEvent.Properties)
                logList.Text += e.NewEvent.ClassPath;
        }



    }
}
