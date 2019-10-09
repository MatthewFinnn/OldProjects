namespace Library
{
    partial class FormSplash
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblMsg = new System.Windows.Forms.Label();
            this.listItem = new System.Windows.Forms.ListBox();
            this.listMsg = new System.Windows.Forms.ListBox();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(13, 13);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(35, 13);
            this.lblMsg.TabIndex = 0;
            this.lblMsg.Text = "label1";
            // 
            // listItem
            // 
            this.listItem.FormattingEnabled = true;
            this.listItem.Location = new System.Drawing.Point(13, 65);
            this.listItem.Name = "listItem";
            this.listItem.Size = new System.Drawing.Size(306, 173);
            this.listItem.TabIndex = 1;
            // 
            // listMsg
            // 
            this.listMsg.FormattingEnabled = true;
            this.listMsg.Location = new System.Drawing.Point(326, 65);
            this.listMsg.Name = "listMsg";
            this.listMsg.Size = new System.Drawing.Size(331, 173);
            this.listMsg.TabIndex = 2;
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(16, 30);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(641, 23);
            this.progress.TabIndex = 3;
            // 
            // FormSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 256);
            this.ControlBox = false;
            this.Controls.Add(this.progress);
            this.Controls.Add(this.listMsg);
            this.Controls.Add(this.listItem);
            this.Controls.Add(this.lblMsg);
            this.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSplash";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.ListBox listItem;
        private System.Windows.Forms.ListBox listMsg;
        private System.Windows.Forms.ProgressBar progress;
    }
}