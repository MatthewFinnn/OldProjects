namespace Library
{
    partial class WMIControl
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
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.treeNS = new System.Windows.Forms.TreeView();
            this.lblCount = new System.Windows.Forms.Label();
            this.splitRight = new System.Windows.Forms.SplitContainer();
            this.treeClasses = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNamespace = new System.Windows.Forms.Label();
            this.splitMiddle = new System.Windows.Forms.SplitContainer();
            this.lblMethods = new System.Windows.Forms.Label();
            this.listMethods = new System.Windows.Forms.ListBox();
            this.listQualifiers = new System.Windows.Forms.ListBox();
            this.listProp = new System.Windows.Forms.ListBox();
            this.btnGetValues = new System.Windows.Forms.Button();
            this.lblDescr = new System.Windows.Forms.Label();
            this.lblNumQualifiers = new System.Windows.Forms.Label();
            this.lblNumMethods = new System.Windows.Forms.Label();
            this.lblNumProp = new System.Windows.Forms.Label();
            this.tDescrClasses = new System.Windows.Forms.TextBox();
            this.tDescr = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitRight)).BeginInit();
            this.splitRight.Panel1.SuspendLayout();
            this.splitRight.Panel2.SuspendLayout();
            this.splitRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMiddle)).BeginInit();
            this.splitMiddle.Panel1.SuspendLayout();
            this.splitMiddle.Panel2.SuspendLayout();
            this.splitMiddle.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitMain
            // 
            this.splitMain.BackColor = System.Drawing.SystemColors.Control;
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 0);
            this.splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.treeNS);
            this.splitMain.Panel1.Controls.Add(this.lblCount);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.splitRight);
            this.splitMain.Size = new System.Drawing.Size(850, 490);
            this.splitMain.SplitterDistance = 132;
            this.splitMain.TabIndex = 0;
            // 
            // treeNS
            // 
            this.treeNS.Location = new System.Drawing.Point(7, 51);
            this.treeNS.Name = "treeNS";
            this.treeNS.Size = new System.Drawing.Size(121, 427);
            this.treeNS.TabIndex = 1;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCount.Location = new System.Drawing.Point(4, 4);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(114, 18);
            this.lblCount.TabIndex = 0;
            this.lblCount.Text = "Filling the tree";
            // 
            // splitRight
            // 
            this.splitRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitRight.Location = new System.Drawing.Point(0, 0);
            this.splitRight.Name = "splitRight";
            // 
            // splitRight.Panel1
            // 
            this.splitRight.Panel1.Controls.Add(this.treeClasses);
            this.splitRight.Panel1.Controls.Add(this.label2);
            this.splitRight.Panel1.Controls.Add(this.lblNamespace);
            // 
            // splitRight.Panel2
            // 
            this.splitRight.Panel2.Controls.Add(this.splitMiddle);
            this.splitRight.Size = new System.Drawing.Size(714, 490);
            this.splitRight.SplitterDistance = 171;
            this.splitRight.TabIndex = 0;
            // 
            // treeClasses
            // 
            this.treeClasses.Location = new System.Drawing.Point(6, 51);
            this.treeClasses.Name = "treeClasses";
            this.treeClasses.Size = new System.Drawing.Size(158, 427);
            this.treeClasses.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label2.Location = new System.Drawing.Point(3, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Select namespace:";
            // 
            // lblNamespace
            // 
            this.lblNamespace.AutoSize = true;
            this.lblNamespace.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNamespace.Location = new System.Drawing.Point(3, 8);
            this.lblNamespace.Name = "lblNamespace";
            this.lblNamespace.Size = new System.Drawing.Size(161, 15);
            this.lblNamespace.TabIndex = 0;
            this.lblNamespace.Text = "No namespace selected";
            // 
            // splitMiddle
            // 
            this.splitMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMiddle.Location = new System.Drawing.Point(0, 0);
            this.splitMiddle.Name = "splitMiddle";
            this.splitMiddle.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitMiddle.Panel1
            // 
            this.splitMiddle.Panel1.Controls.Add(this.lblMethods);
            this.splitMiddle.Panel1.Controls.Add(this.listMethods);
            this.splitMiddle.Panel1.Controls.Add(this.listQualifiers);
            this.splitMiddle.Panel1.Controls.Add(this.listProp);
            this.splitMiddle.Panel1.Controls.Add(this.btnGetValues);
            this.splitMiddle.Panel1.Controls.Add(this.lblDescr);
            this.splitMiddle.Panel1.Controls.Add(this.lblNumQualifiers);
            this.splitMiddle.Panel1.Controls.Add(this.lblNumMethods);
            this.splitMiddle.Panel1.Controls.Add(this.lblNumProp);
            // 
            // splitMiddle.Panel2
            // 
            this.splitMiddle.Panel2.Controls.Add(this.tDescrClasses);
            this.splitMiddle.Panel2.Controls.Add(this.tDescr);
            this.splitMiddle.Size = new System.Drawing.Size(539, 490);
            this.splitMiddle.SplitterDistance = 273;
            this.splitMiddle.TabIndex = 0;
            // 
            // lblMethods
            // 
            this.lblMethods.AutoSize = true;
            this.lblMethods.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblMethods.Location = new System.Drawing.Point(3, 10);
            this.lblMethods.Name = "lblMethods";
            this.lblMethods.Size = new System.Drawing.Size(47, 15);
            this.lblMethods.TabIndex = 10;
            this.lblMethods.Text = "label1";
            // 
            // listMethods
            // 
            this.listMethods.FormattingEnabled = true;
            this.listMethods.Location = new System.Drawing.Point(183, 55);
            this.listMethods.Name = "listMethods";
            this.listMethods.Size = new System.Drawing.Size(170, 186);
            this.listMethods.TabIndex = 9;
            // 
            // listQualifiers
            // 
            this.listQualifiers.FormattingEnabled = true;
            this.listQualifiers.Location = new System.Drawing.Point(358, 55);
            this.listQualifiers.Name = "listQualifiers";
            this.listQualifiers.Size = new System.Drawing.Size(170, 186);
            this.listQualifiers.TabIndex = 8;
            // 
            // listProp
            // 
            this.listProp.FormattingEnabled = true;
            this.listProp.Location = new System.Drawing.Point(4, 54);
            this.listProp.Name = "listProp";
            this.listProp.Size = new System.Drawing.Size(173, 186);
            this.listProp.TabIndex = 6;
            // 
            // btnGetValues
            // 
            this.btnGetValues.Location = new System.Drawing.Point(301, 244);
            this.btnGetValues.Name = "btnGetValues";
            this.btnGetValues.Size = new System.Drawing.Size(75, 23);
            this.btnGetValues.TabIndex = 5;
            this.btnGetValues.Text = "Get Values";
            this.btnGetValues.UseVisualStyleBackColor = true;
            // 
            // lblDescr
            // 
            this.lblDescr.AutoSize = true;
            this.lblDescr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDescr.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblDescr.Location = new System.Drawing.Point(11, 247);
            this.lblDescr.Name = "lblDescr";
            this.lblDescr.Size = new System.Drawing.Size(257, 15);
            this.lblDescr.TabIndex = 4;
            this.lblDescr.Text = "Select a property, method or qualifier...";
            // 
            // lblNumQualifiers
            // 
            this.lblNumQualifiers.AutoSize = true;
            this.lblNumQualifiers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNumQualifiers.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblNumQualifiers.Location = new System.Drawing.Point(356, 35);
            this.lblNumQualifiers.Name = "lblNumQualifiers";
            this.lblNumQualifiers.Size = new System.Drawing.Size(96, 15);
            this.lblNumQualifiers.TabIndex = 3;
            this.lblNumQualifiers.Text = "Select a class";
            // 
            // lblNumMethods
            // 
            this.lblNumMethods.AutoSize = true;
            this.lblNumMethods.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNumMethods.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblNumMethods.Location = new System.Drawing.Point(177, 35);
            this.lblNumMethods.Name = "lblNumMethods";
            this.lblNumMethods.Size = new System.Drawing.Size(96, 15);
            this.lblNumMethods.TabIndex = 2;
            this.lblNumMethods.Text = "Select a class";
            // 
            // lblNumProp
            // 
            this.lblNumProp.AutoSize = true;
            this.lblNumProp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNumProp.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblNumProp.Location = new System.Drawing.Point(11, 35);
            this.lblNumProp.Name = "lblNumProp";
            this.lblNumProp.Size = new System.Drawing.Size(96, 15);
            this.lblNumProp.TabIndex = 1;
            this.lblNumProp.Text = "Select a class";
            // 
            // tDescrClasses
            // 
            this.tDescrClasses.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tDescrClasses.Location = new System.Drawing.Point(4, 110);
            this.tDescrClasses.Multiline = true;
            this.tDescrClasses.Name = "tDescrClasses";
            this.tDescrClasses.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tDescrClasses.Size = new System.Drawing.Size(525, 99);
            this.tDescrClasses.TabIndex = 1;
            // 
            // tDescr
            // 
            this.tDescr.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tDescr.CausesValidation = false;
            this.tDescr.Location = new System.Drawing.Point(5, 5);
            this.tDescr.Multiline = true;
            this.tDescr.Name = "tDescr";
            this.tDescr.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tDescr.Size = new System.Drawing.Size(524, 97);
            this.tDescr.TabIndex = 0;
            // 
            // WMIControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.splitMain);
            this.Name = "WMIControl";
            this.Size = new System.Drawing.Size(850, 490);
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel1.PerformLayout();
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.splitRight.Panel1.ResumeLayout(false);
            this.splitRight.Panel1.PerformLayout();
            this.splitRight.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitRight)).EndInit();
            this.splitRight.ResumeLayout(false);
            this.splitMiddle.Panel1.ResumeLayout(false);
            this.splitMiddle.Panel1.PerformLayout();
            this.splitMiddle.Panel2.ResumeLayout(false);
            this.splitMiddle.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMiddle)).EndInit();
            this.splitMiddle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.TreeView treeNS;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.SplitContainer splitRight;
        private System.Windows.Forms.TreeView treeClasses;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNamespace;
        private System.Windows.Forms.SplitContainer splitMiddle;
        private System.Windows.Forms.ListBox listMethods;
        private System.Windows.Forms.ListBox listQualifiers;
        private System.Windows.Forms.ListBox listProp;
        private System.Windows.Forms.Button btnGetValues;
        private System.Windows.Forms.Label lblDescr;
        private System.Windows.Forms.Label lblNumQualifiers;
        private System.Windows.Forms.Label lblNumMethods;
        private System.Windows.Forms.Label lblNumProp;
        private System.Windows.Forms.TextBox tDescrClasses;
        private System.Windows.Forms.TextBox tDescr;
        private System.Windows.Forms.Label lblMethods;
    }
}
