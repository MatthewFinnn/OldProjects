﻿namespace Library
{
    partial class ProcessControl
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
            this.listView = new System.Windows.Forms.ListView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.boxComputer = new System.Windows.Forms.GroupBox();
            this.rbRemote = new System.Windows.Forms.RadioButton();
            this.rbCurrent = new System.Windows.Forms.RadioButton();
            this.group = new System.Windows.Forms.GroupBox();
            this.lbPass = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.lbUserID = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.combo = new System.Windows.Forms.ComboBox();
            this.propt = new System.Windows.Forms.TextBox();
            this.boxComputer.SuspendLayout();
            this.group.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.CheckBoxes = true;
            this.listView.Location = new System.Drawing.Point(3, 3);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(350, 472);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(652, 130);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // boxComputer
            // 
            this.boxComputer.Controls.Add(this.rbRemote);
            this.boxComputer.Controls.Add(this.rbCurrent);
            this.boxComputer.Location = new System.Drawing.Point(652, 226);
            this.boxComputer.Name = "boxComputer";
            this.boxComputer.Size = new System.Drawing.Size(165, 75);
            this.boxComputer.TabIndex = 2;
            this.boxComputer.TabStop = false;
            this.boxComputer.Text = "Computer";
            // 
            // rbRemote
            // 
            this.rbRemote.AutoSize = true;
            this.rbRemote.Location = new System.Drawing.Point(7, 44);
            this.rbRemote.Name = "rbRemote";
            this.rbRemote.Size = new System.Drawing.Size(62, 17);
            this.rbRemote.TabIndex = 1;
            this.rbRemote.Text = "Remote";
            this.rbRemote.UseVisualStyleBackColor = true;
            // 
            // rbCurrent
            // 
            this.rbCurrent.AutoSize = true;
            this.rbCurrent.Checked = true;
            this.rbCurrent.Location = new System.Drawing.Point(7, 20);
            this.rbCurrent.Name = "rbCurrent";
            this.rbCurrent.Size = new System.Drawing.Size(59, 17);
            this.rbCurrent.TabIndex = 0;
            this.rbCurrent.TabStop = true;
            this.rbCurrent.Text = "Current";
            this.rbCurrent.UseVisualStyleBackColor = true;
            // 
            // group
            // 
            this.group.Controls.Add(this.lbPass);
            this.group.Controls.Add(this.lbName);
            this.group.Controls.Add(this.lbUserID);
            this.group.Controls.Add(this.txtPass);
            this.group.Controls.Add(this.txtName);
            this.group.Controls.Add(this.txtUserID);
            this.group.Location = new System.Drawing.Point(651, 307);
            this.group.Name = "group";
            this.group.Size = new System.Drawing.Size(165, 160);
            this.group.TabIndex = 3;
            this.group.TabStop = false;
            this.group.Text = "Admin";
            this.group.Visible = false;
            // 
            // lbPass
            // 
            this.lbPass.AutoSize = true;
            this.lbPass.Location = new System.Drawing.Point(6, 109);
            this.lbPass.Name = "lbPass";
            this.lbPass.Size = new System.Drawing.Size(53, 13);
            this.lbPass.TabIndex = 5;
            this.lbPass.Text = "Password";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(7, 59);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(35, 13);
            this.lbName.TabIndex = 4;
            this.lbName.Text = "Name";
            // 
            // lbUserID
            // 
            this.lbUserID.AutoSize = true;
            this.lbUserID.Location = new System.Drawing.Point(7, 20);
            this.lbUserID.Name = "lbUserID";
            this.lbUserID.Size = new System.Drawing.Size(40, 13);
            this.lbUserID.TabIndex = 3;
            this.lbUserID.Text = "UserID";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(7, 125);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(100, 20);
            this.txtPass.TabIndex = 2;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(10, 75);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 1;
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(10, 36);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(100, 20);
            this.txtUserID.TabIndex = 0;
            // 
            // combo
            // 
            this.combo.FormattingEnabled = true;
            this.combo.Location = new System.Drawing.Point(653, 169);
            this.combo.Name = "combo";
            this.combo.Size = new System.Drawing.Size(121, 21);
            this.combo.TabIndex = 4;
            // 
            // propt
            // 
            this.propt.Location = new System.Drawing.Point(360, 3);
            this.propt.Multiline = true;
            this.propt.Name = "propt";
            this.propt.ReadOnly = true;
            this.propt.Size = new System.Drawing.Size(287, 474);
            this.propt.TabIndex = 5;
            // 
            // ProcessControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.propt);
            this.Controls.Add(this.combo);
            this.Controls.Add(this.group);
            this.Controls.Add(this.boxComputer);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.listView);
            this.Name = "ProcessControl";
            this.Size = new System.Drawing.Size(822, 480);
            this.boxComputer.ResumeLayout(false);
            this.boxComputer.PerformLayout();
            this.group.ResumeLayout(false);
            this.group.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox boxComputer;
        private System.Windows.Forms.RadioButton rbRemote;
        private System.Windows.Forms.RadioButton rbCurrent;
        private System.Windows.Forms.GroupBox group;
        private System.Windows.Forms.ComboBox combo;
        private System.Windows.Forms.Label lbPass;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbUserID;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.TextBox propt;
    }
}
