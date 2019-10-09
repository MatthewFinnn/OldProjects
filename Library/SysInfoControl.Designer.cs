namespace Library
{
    partial class SysInfoControl
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SysInfoControl));
            this.treeImages = new System.Windows.Forms.ImageList(this.components);
            this.tree = new System.Windows.Forms.TreeView();
            this.bRefresh = new System.Windows.Forms.Button();
            this.boxComputer = new System.Windows.Forms.GroupBox();
            this.rdRemote = new System.Windows.Forms.RadioButton();
            this.rdCurrent = new System.Windows.Forms.RadioButton();
            this.boxAdmin = new System.Windows.Forms.GroupBox();
            this.textPass = new System.Windows.Forms.TextBox();
            this.textUserID = new System.Windows.Forms.TextBox();
            this.textName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.boxComputer.SuspendLayout();
            this.boxAdmin.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeImages
            // 
            this.treeImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeImages.ImageStream")));
            this.treeImages.TransparentColor = System.Drawing.Color.Transparent;
            this.treeImages.Images.SetKeyName(0, "My-Computer.ico");
            this.treeImages.Images.SetKeyName(1, "Computer.png");
            this.treeImages.Images.SetKeyName(2, "Drive - RAM 1.png");
            this.treeImages.Images.SetKeyName(3, "Drive - RAM 2.png");
            this.treeImages.Images.SetKeyName(4, "Hard-Drive.png");
            this.treeImages.Images.SetKeyName(5, "Hard_Drive.png");
            this.treeImages.Images.SetKeyName(6, "Glass-Video.png");
            this.treeImages.Images.SetKeyName(7, "Glass-Video.png");
            this.treeImages.Images.SetKeyName(8, "windows .ico");
            this.treeImages.Images.SetKeyName(9, "Windows-Glass.ico");
            this.treeImages.Images.SetKeyName(10, "BioHazard.ico");
            this.treeImages.Images.SetKeyName(11, "BioHazard.png");
            this.treeImages.Images.SetKeyName(12, "Working Net 2.ico");
            this.treeImages.Images.SetKeyName(13, "Working Net 3.ico");
            this.treeImages.Images.SetKeyName(14, "Clock.ico");
            this.treeImages.Images.SetKeyName(15, "Clock.ico");
            // 
            // tree
            // 
            this.tree.ImageIndex = 0;
            this.tree.ImageList = this.treeImages;
            this.tree.Location = new System.Drawing.Point(3, 3);
            this.tree.Name = "tree";
            this.tree.SelectedImageIndex = 0;
            this.tree.Size = new System.Drawing.Size(541, 477);
            this.tree.TabIndex = 0;
            // 
            // bRefresh
            // 
            this.bRefresh.Location = new System.Drawing.Point(578, 26);
            this.bRefresh.Name = "bRefresh";
            this.bRefresh.Size = new System.Drawing.Size(75, 23);
            this.bRefresh.TabIndex = 1;
            this.bRefresh.Text = "Refresh";
            this.bRefresh.UseVisualStyleBackColor = true;
            this.bRefresh.Click += new System.EventHandler(this.bRefresh_Click);
            // 
            // boxComputer
            // 
            this.boxComputer.Controls.Add(this.rdRemote);
            this.boxComputer.Controls.Add(this.rdCurrent);
            this.boxComputer.Location = new System.Drawing.Point(550, 66);
            this.boxComputer.Name = "boxComputer";
            this.boxComputer.Size = new System.Drawing.Size(149, 134);
            this.boxComputer.TabIndex = 2;
            this.boxComputer.TabStop = false;
            this.boxComputer.Text = "Computer";
            // 
            // rdRemote
            // 
            this.rdRemote.AutoSize = true;
            this.rdRemote.Location = new System.Drawing.Point(7, 44);
            this.rdRemote.Name = "rdRemote";
            this.rdRemote.Size = new System.Drawing.Size(62, 17);
            this.rdRemote.TabIndex = 1;
            this.rdRemote.Text = "Remote";
            this.rdRemote.UseVisualStyleBackColor = true;
            this.rdRemote.CheckedChanged += new System.EventHandler(this.rdRemote_CheckedChanged);
            // 
            // rdCurrent
            // 
            this.rdCurrent.AutoSize = true;
            this.rdCurrent.Checked = true;
            this.rdCurrent.Location = new System.Drawing.Point(7, 20);
            this.rdCurrent.Name = "rdCurrent";
            this.rdCurrent.Size = new System.Drawing.Size(59, 17);
            this.rdCurrent.TabIndex = 0;
            this.rdCurrent.TabStop = true;
            this.rdCurrent.Text = "Current";
            this.rdCurrent.UseVisualStyleBackColor = true;
            // 
            // boxAdmin
            // 
            this.boxAdmin.Controls.Add(this.textPass);
            this.boxAdmin.Controls.Add(this.textUserID);
            this.boxAdmin.Controls.Add(this.textName);
            this.boxAdmin.Controls.Add(this.label3);
            this.boxAdmin.Controls.Add(this.label2);
            this.boxAdmin.Controls.Add(this.label1);
            this.boxAdmin.Location = new System.Drawing.Point(555, 216);
            this.boxAdmin.Name = "boxAdmin";
            this.boxAdmin.Size = new System.Drawing.Size(145, 209);
            this.boxAdmin.TabIndex = 3;
            this.boxAdmin.TabStop = false;
            this.boxAdmin.Text = "Admin";
            this.boxAdmin.Visible = false;
            // 
            // textPass
            // 
            this.textPass.Location = new System.Drawing.Point(6, 163);
            this.textPass.Name = "textPass";
            this.textPass.Size = new System.Drawing.Size(127, 20);
            this.textPass.TabIndex = 5;
            // 
            // textUserID
            // 
            this.textUserID.Location = new System.Drawing.Point(6, 101);
            this.textUserID.Name = "textUserID";
            this.textUserID.Size = new System.Drawing.Size(127, 20);
            this.textUserID.TabIndex = 4;
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(6, 50);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(127, 20);
            this.textName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "UserID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP or Machine Name:";
            // 
            // SysInfoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.boxAdmin);
            this.Controls.Add(this.boxComputer);
            this.Controls.Add(this.bRefresh);
            this.Controls.Add(this.tree);
            this.Name = "SysInfoControl";
            this.Size = new System.Drawing.Size(700, 480);
            this.boxComputer.ResumeLayout(false);
            this.boxComputer.PerformLayout();
            this.boxAdmin.ResumeLayout(false);
            this.boxAdmin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList treeImages;
        private System.Windows.Forms.TreeView tree;
        private System.Windows.Forms.Button bRefresh;
        private System.Windows.Forms.GroupBox boxComputer;
        private System.Windows.Forms.RadioButton rdRemote;
        private System.Windows.Forms.RadioButton rdCurrent;
        private System.Windows.Forms.GroupBox boxAdmin;
        private System.Windows.Forms.TextBox textPass;
        private System.Windows.Forms.TextBox textUserID;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
