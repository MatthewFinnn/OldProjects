namespace Library
{
    partial class IRQControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IRQControl));
            this.tree = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.tDescr = new System.Windows.Forms.TextBox();
            this.lbPropDescr = new System.Windows.Forms.Label();
            this.btnDNSDomain = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelIp = new System.Windows.Forms.Label();
            this.textDNSName = new System.Windows.Forms.TextBox();
            this.labelDNS = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSetGateways = new System.Windows.Forms.Button();
            this.textGateways = new System.Windows.Forms.TextBox();
            this.labelGateways = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonPing = new System.Windows.Forms.Button();
            this.textIPPings = new System.Windows.Forms.TextBox();
            this.textHostName = new System.Windows.Forms.TextBox();
            this.labelHostName = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tree
            // 
            this.tree.ImageIndex = 0;
            this.tree.ImageList = this.imageList;
            this.tree.Location = new System.Drawing.Point(3, 3);
            this.tree.Name = "tree";
            this.tree.SelectedImageIndex = 0;
            this.tree.Size = new System.Drawing.Size(360, 474);
            this.tree.TabIndex = 0;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Network 2.ico");
            this.imageList.Images.SetKeyName(1, "Hard Drive light blue.ico");
            this.imageList.Images.SetKeyName(2, "ball_red.png");
            this.imageList.Images.SetKeyName(3, "Yes.ico");
            // 
            // tDescr
            // 
            this.tDescr.Location = new System.Drawing.Point(369, 23);
            this.tDescr.Multiline = true;
            this.tDescr.Name = "tDescr";
            this.tDescr.ReadOnly = true;
            this.tDescr.Size = new System.Drawing.Size(448, 108);
            this.tDescr.TabIndex = 1;
            // 
            // lbPropDescr
            // 
            this.lbPropDescr.AutoSize = true;
            this.lbPropDescr.Location = new System.Drawing.Point(369, 7);
            this.lbPropDescr.Name = "lbPropDescr";
            this.lbPropDescr.Size = new System.Drawing.Size(96, 13);
            this.lbPropDescr.TabIndex = 4;
            this.lbPropDescr.Text = "Proterti Description";
            // 
            // btnDNSDomain
            // 
            this.btnDNSDomain.Location = new System.Drawing.Point(6, 101);
            this.btnDNSDomain.Name = "btnDNSDomain";
            this.btnDNSDomain.Size = new System.Drawing.Size(75, 23);
            this.btnDNSDomain.TabIndex = 5;
            this.btnDNSDomain.Text = "SET";
            this.btnDNSDomain.UseVisualStyleBackColor = true;
            this.btnDNSDomain.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelIp);
            this.groupBox1.Controls.Add(this.textDNSName);
            this.groupBox1.Controls.Add(this.labelDNS);
            this.groupBox1.Controls.Add(this.btnDNSDomain);
            this.groupBox1.Location = new System.Drawing.Point(372, 137);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(202, 131);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Set DNS Domain";
            // 
            // labelIp
            // 
            this.labelIp.AutoSize = true;
            this.labelIp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelIp.Location = new System.Drawing.Point(7, 60);
            this.labelIp.Name = "labelIp";
            this.labelIp.Size = new System.Drawing.Size(27, 13);
            this.labelIp.TabIndex = 8;
            this.labelIp.Text = "IP: ";
            // 
            // textDNSName
            // 
            this.textDNSName.Location = new System.Drawing.Point(10, 37);
            this.textDNSName.Name = "textDNSName";
            this.textDNSName.Size = new System.Drawing.Size(169, 20);
            this.textDNSName.TabIndex = 7;
            // 
            // labelDNS
            // 
            this.labelDNS.AutoSize = true;
            this.labelDNS.Location = new System.Drawing.Point(7, 20);
            this.labelDNS.Name = "labelDNS";
            this.labelDNS.Size = new System.Drawing.Size(59, 13);
            this.labelDNS.TabIndex = 6;
            this.labelDNS.Text = "DNS name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSetGateways);
            this.groupBox2.Controls.Add(this.textGateways);
            this.groupBox2.Controls.Add(this.labelGateways);
            this.groupBox2.Location = new System.Drawing.Point(581, 138);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(236, 130);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Set Gateways";
            // 
            // btnSetGateways
            // 
            this.btnSetGateways.Location = new System.Drawing.Point(10, 100);
            this.btnSetGateways.Name = "btnSetGateways";
            this.btnSetGateways.Size = new System.Drawing.Size(75, 23);
            this.btnSetGateways.TabIndex = 2;
            this.btnSetGateways.Text = "SET";
            this.btnSetGateways.UseVisualStyleBackColor = true;
            this.btnSetGateways.Click += new System.EventHandler(this.btnSetGateways_Click);
            // 
            // textGateways
            // 
            this.textGateways.Location = new System.Drawing.Point(10, 36);
            this.textGateways.Name = "textGateways";
            this.textGateways.Size = new System.Drawing.Size(220, 20);
            this.textGateways.TabIndex = 1;
            // 
            // labelGateways
            // 
            this.labelGateways.AutoSize = true;
            this.labelGateways.Location = new System.Drawing.Point(7, 20);
            this.labelGateways.Name = "labelGateways";
            this.labelGateways.Size = new System.Drawing.Size(73, 13);
            this.labelGateways.TabIndex = 0;
            this.labelGateways.Text = "Set Gateways";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonPing);
            this.groupBox3.Controls.Add(this.textIPPings);
            this.groupBox3.Controls.Add(this.textHostName);
            this.groupBox3.Controls.Add(this.labelHostName);
            this.groupBox3.Location = new System.Drawing.Point(372, 275);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(202, 202);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ping comand";
            // 
            // buttonPing
            // 
            this.buttonPing.Location = new System.Drawing.Point(11, 173);
            this.buttonPing.Name = "buttonPing";
            this.buttonPing.Size = new System.Drawing.Size(75, 23);
            this.buttonPing.TabIndex = 3;
            this.buttonPing.Text = "Ping";
            this.buttonPing.UseVisualStyleBackColor = true;
            this.buttonPing.Click += new System.EventHandler(this.buttonPing_Click);
            // 
            // textIPPings
            // 
            this.textIPPings.Location = new System.Drawing.Point(11, 63);
            this.textIPPings.Multiline = true;
            this.textIPPings.Name = "textIPPings";
            this.textIPPings.ReadOnly = true;
            this.textIPPings.Size = new System.Drawing.Size(168, 101);
            this.textIPPings.TabIndex = 2;
            // 
            // textHostName
            // 
            this.textHostName.Location = new System.Drawing.Point(10, 37);
            this.textHostName.Name = "textHostName";
            this.textHostName.Size = new System.Drawing.Size(169, 20);
            this.textHostName.TabIndex = 1;
            // 
            // labelHostName
            // 
            this.labelHostName.AutoSize = true;
            this.labelHostName.Location = new System.Drawing.Point(8, 20);
            this.labelHostName.Name = "labelHostName";
            this.labelHostName.Size = new System.Drawing.Size(60, 13);
            this.labelHostName.TabIndex = 0;
            this.labelHostName.Text = "Host Name";
            // 
            // IRQControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbPropDescr);
            this.Controls.Add(this.tDescr);
            this.Controls.Add(this.tree);
            this.Name = "IRQControl";
            this.Size = new System.Drawing.Size(820, 480);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tree;
        private System.Windows.Forms.TextBox tDescr;
        private System.Windows.Forms.Label lbPropDescr;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Button btnDNSDomain;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textDNSName;
        private System.Windows.Forms.Label labelDNS;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textGateways;
        private System.Windows.Forms.Label labelGateways;
        private System.Windows.Forms.Button btnSetGateways;
        private System.Windows.Forms.Label labelIp;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonPing;
        private System.Windows.Forms.TextBox textIPPings;
        private System.Windows.Forms.TextBox textHostName;
        private System.Windows.Forms.Label labelHostName;
    }
}
