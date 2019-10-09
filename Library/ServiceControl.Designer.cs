namespace Library
{
    partial class ServiceControl
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
            this.propt = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.boxComputer = new System.Windows.Forms.GroupBox();
            this.rbRemote = new System.Windows.Forms.RadioButton();
            this.rbCurrent = new System.Windows.Forms.RadioButton();
            this.group = new System.Windows.Forms.GroupBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.lbPass = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.lbUserID = new System.Windows.Forms.Label();
            this.boxComputer.SuspendLayout();
            this.group.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.Location = new System.Drawing.Point(4, 4);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(385, 473);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // propt
            // 
            this.propt.Location = new System.Drawing.Point(395, 4);
            this.propt.Multiline = true;
            this.propt.Name = "propt";
            this.propt.ReadOnly = true;
            this.propt.Size = new System.Drawing.Size(280, 473);
            this.propt.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(682, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(137, 32);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // boxComputer
            // 
            this.boxComputer.Controls.Add(this.rbRemote);
            this.boxComputer.Controls.Add(this.rbCurrent);
            this.boxComputer.Location = new System.Drawing.Point(682, 43);
            this.boxComputer.Name = "boxComputer";
            this.boxComputer.Size = new System.Drawing.Size(137, 100);
            this.boxComputer.TabIndex = 3;
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
            this.group.Controls.Add(this.txtPass);
            this.group.Controls.Add(this.txtName);
            this.group.Controls.Add(this.txtUserID);
            this.group.Controls.Add(this.lbPass);
            this.group.Controls.Add(this.lbName);
            this.group.Controls.Add(this.lbUserID);
            this.group.Location = new System.Drawing.Point(682, 150);
            this.group.Name = "group";
            this.group.Size = new System.Drawing.Size(137, 214);
            this.group.TabIndex = 4;
            this.group.TabStop = false;
            this.group.Text = "Admin";
            this.group.Visible = false;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(6, 119);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(100, 20);
            this.txtPass.TabIndex = 5;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(6, 80);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 4;
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(7, 32);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(100, 20);
            this.txtUserID.TabIndex = 3;
            // 
            // lbPass
            // 
            this.lbPass.AutoSize = true;
            this.lbPass.Location = new System.Drawing.Point(6, 103);
            this.lbPass.Name = "lbPass";
            this.lbPass.Size = new System.Drawing.Size(53, 13);
            this.lbPass.TabIndex = 2;
            this.lbPass.Text = "Password";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(6, 64);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(35, 13);
            this.lbName.TabIndex = 1;
            this.lbName.Text = "Name";
            // 
            // lbUserID
            // 
            this.lbUserID.AutoSize = true;
            this.lbUserID.Location = new System.Drawing.Point(6, 16);
            this.lbUserID.Name = "lbUserID";
            this.lbUserID.Size = new System.Drawing.Size(40, 13);
            this.lbUserID.TabIndex = 0;
            this.lbUserID.Text = "UserID";
            // 
            // ServiceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.group);
            this.Controls.Add(this.boxComputer);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.propt);
            this.Controls.Add(this.listView);
            this.Name = "ServiceControl";
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
        private System.Windows.Forms.TextBox propt;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox boxComputer;
        private System.Windows.Forms.RadioButton rbRemote;
        private System.Windows.Forms.RadioButton rbCurrent;
        private System.Windows.Forms.GroupBox group;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Label lbPass;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbUserID;
    }
}
