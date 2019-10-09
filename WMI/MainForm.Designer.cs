namespace WMI
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnShowHidden = new System.Windows.Forms.ToolStripButton();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabClasses = new System.Windows.Forms.TabPage();
            this.tabFileSystem = new System.Windows.Forms.TabPage();
            this.tabSysInfo = new System.Windows.Forms.TabPage();
            this.tabServices = new System.Windows.Forms.TabPage();
            this.tabProcesses = new System.Windows.Forms.TabPage();
            this.tabNetAdaptConf = new System.Windows.Forms.TabPage();
            this.logList = new System.Windows.Forms.TextBox();
            this.wmi = new Library.WMIControl();
            this.fileSystem = new Library.FileSystemControl();
            this.sysInfoControl1 = new Library.SysInfoControl();
            this.serviceControl1 = new Library.ServiceControl();
            this.processControl1 = new Library.ProcessControl();
            this.irqControl1 = new Library.IRQControl();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabClasses.SuspendLayout();
            this.tabFileSystem.SuspendLayout();
            this.tabSysInfo.SuspendLayout();
            this.tabServices.SuspendLayout();
            this.tabProcesses.SuspendLayout();
            this.tabNetAdaptConf.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnShowHidden});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(868, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnShowHidden
            // 
            this.btnShowHidden.CheckOnClick = true;
            this.btnShowHidden.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnShowHidden.Image = ((System.Drawing.Image)(resources.GetObject("btnShowHidden.Image")));
            this.btnShowHidden.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowHidden.Name = "btnShowHidden";
            this.btnShowHidden.Size = new System.Drawing.Size(82, 22);
            this.btnShowHidden.Text = "Show Hidden";
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 25);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.tabControl);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.logList);
            this.splitContainer.Size = new System.Drawing.Size(868, 627);
            this.splitContainer.SplitterDistance = 527;
            this.splitContainer.TabIndex = 1;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabClasses);
            this.tabControl.Controls.Add(this.tabFileSystem);
            this.tabControl.Controls.Add(this.tabSysInfo);
            this.tabControl.Controls.Add(this.tabServices);
            this.tabControl.Controls.Add(this.tabProcesses);
            this.tabControl.Controls.Add(this.tabNetAdaptConf);
            this.tabControl.Location = new System.Drawing.Point(3, 3);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(861, 516);
            this.tabControl.TabIndex = 0;
            // 
            // tabClasses
            // 
            this.tabClasses.Controls.Add(this.wmi);
            this.tabClasses.Location = new System.Drawing.Point(4, 22);
            this.tabClasses.Name = "tabClasses";
            this.tabClasses.Padding = new System.Windows.Forms.Padding(3);
            this.tabClasses.Size = new System.Drawing.Size(853, 490);
            this.tabClasses.TabIndex = 0;
            this.tabClasses.Text = "WMI Classes";
            this.tabClasses.UseVisualStyleBackColor = true;
            // 
            // tabFileSystem
            // 
            this.tabFileSystem.Controls.Add(this.fileSystem);
            this.tabFileSystem.Location = new System.Drawing.Point(4, 22);
            this.tabFileSystem.Name = "tabFileSystem";
            this.tabFileSystem.Padding = new System.Windows.Forms.Padding(3);
            this.tabFileSystem.Size = new System.Drawing.Size(853, 490);
            this.tabFileSystem.TabIndex = 1;
            this.tabFileSystem.Text = "FileSystem";
            this.tabFileSystem.UseVisualStyleBackColor = true;
            // 
            // tabSysInfo
            // 
            this.tabSysInfo.Controls.Add(this.sysInfoControl1);
            this.tabSysInfo.Location = new System.Drawing.Point(4, 22);
            this.tabSysInfo.Name = "tabSysInfo";
            this.tabSysInfo.Size = new System.Drawing.Size(853, 490);
            this.tabSysInfo.TabIndex = 2;
            this.tabSysInfo.Text = "SysInfo";
            this.tabSysInfo.UseVisualStyleBackColor = true;
            // 
            // tabServices
            // 
            this.tabServices.Controls.Add(this.serviceControl1);
            this.tabServices.Location = new System.Drawing.Point(4, 22);
            this.tabServices.Name = "tabServices";
            this.tabServices.Size = new System.Drawing.Size(853, 490);
            this.tabServices.TabIndex = 3;
            this.tabServices.Text = "Services";
            this.tabServices.UseVisualStyleBackColor = true;
            // 
            // tabProcesses
            // 
            this.tabProcesses.Controls.Add(this.processControl1);
            this.tabProcesses.Location = new System.Drawing.Point(4, 22);
            this.tabProcesses.Name = "tabProcesses";
            this.tabProcesses.Size = new System.Drawing.Size(853, 490);
            this.tabProcesses.TabIndex = 4;
            this.tabProcesses.Text = "Processes";
            this.tabProcesses.UseVisualStyleBackColor = true;
            // 
            // tabNetAdaptConf
            // 
            this.tabNetAdaptConf.Controls.Add(this.irqControl1);
            this.tabNetAdaptConf.Location = new System.Drawing.Point(4, 22);
            this.tabNetAdaptConf.Name = "tabNetAdaptConf";
            this.tabNetAdaptConf.Size = new System.Drawing.Size(853, 490);
            this.tabNetAdaptConf.TabIndex = 5;
            this.tabNetAdaptConf.Text = "NetworcAdapter Configuration";
            this.tabNetAdaptConf.UseVisualStyleBackColor = true;
            // 
            // logList
            // 
            this.logList.Location = new System.Drawing.Point(4, 4);
            this.logList.Multiline = true;
            this.logList.Name = "logList";
            this.logList.Size = new System.Drawing.Size(861, 92);
            this.logList.TabIndex = 0;
            // 
            // wmi
            // 
            this.wmi.BackColor = System.Drawing.SystemColors.Control;
            this.wmi.Location = new System.Drawing.Point(7, 0);
            this.wmi.Name = "wmi";
            this.wmi.Size = new System.Drawing.Size(850, 486);
            this.wmi.TabIndex = 0;
            // 
            // fileSystem
            // 
            this.fileSystem.Location = new System.Drawing.Point(4, 4);
            this.fileSystem.Name = "fileSystem";
            this.fileSystem.Size = new System.Drawing.Size(830, 480);
            this.fileSystem.TabIndex = 0;
            // 
            // sysInfoControl1
            // 
            this.sysInfoControl1.Location = new System.Drawing.Point(0, 0);
            this.sysInfoControl1.Name = "sysInfoControl1";
            this.sysInfoControl1.Size = new System.Drawing.Size(849, 480);
            this.sysInfoControl1.TabIndex = 0;
            // 
            // serviceControl1
            // 
            this.serviceControl1.Location = new System.Drawing.Point(3, 7);
            this.serviceControl1.Name = "serviceControl1";
            this.serviceControl1.Size = new System.Drawing.Size(822, 480);
            this.serviceControl1.TabIndex = 0;
            // 
            // processControl1
            // 
            this.processControl1.Location = new System.Drawing.Point(6, 4);
            this.processControl1.Name = "processControl1";
            this.processControl1.Size = new System.Drawing.Size(843, 483);
            this.processControl1.TabIndex = 0;
            // 
            // irqControl1
            // 
            this.irqControl1.Location = new System.Drawing.Point(3, 0);
            this.irqControl1.Name = "irqControl1";
            this.irqControl1.Size = new System.Drawing.Size(820, 480);
            this.irqControl1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 652);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MainForm";
            this.Text = "MWI";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabClasses.ResumeLayout(false);
            this.tabFileSystem.ResumeLayout(false);
            this.tabSysInfo.ResumeLayout(false);
            this.tabServices.ResumeLayout(false);
            this.tabProcesses.ResumeLayout(false);
            this.tabNetAdaptConf.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnShowHidden;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabClasses;
        private System.Windows.Forms.TabPage tabFileSystem;
        private System.Windows.Forms.TabPage tabSysInfo;
        private System.Windows.Forms.TabPage tabServices;
        private System.Windows.Forms.TabPage tabProcesses;
        private Library.WMIControl wmi;
        private Library.FileSystemControl fileSystem;
        private Library.SysInfoControl sysInfoControl1;
        private Library.ProcessControl processControl1;
        private Library.ServiceControl serviceControl1;
        private System.Windows.Forms.TextBox logList;
        private System.Windows.Forms.TabPage tabNetAdaptConf;
        private Library.IRQControl irqControl1;
    }
}

