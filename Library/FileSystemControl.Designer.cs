namespace Library
{
    partial class FileSystemControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileSystemControl));
            this.treeImages = new System.Windows.Forms.ImageList(this.components);
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.splitLeft = new System.Windows.Forms.SplitContainer();
            this.checkHidden = new System.Windows.Forms.CheckBox();
            this.tree = new System.Windows.Forms.TreeView();
            this.splitRight = new System.Windows.Forms.SplitContainer();
            this.lblDirInfo = new System.Windows.Forms.Label();
            this.fileList = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitLeft)).BeginInit();
            this.splitLeft.Panel1.SuspendLayout();
            this.splitLeft.Panel2.SuspendLayout();
            this.splitLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitRight)).BeginInit();
            this.splitRight.Panel1.SuspendLayout();
            this.splitRight.Panel2.SuspendLayout();
            this.splitRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeImages
            // 
            this.treeImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeImages.ImageStream")));
            this.treeImages.TransparentColor = System.Drawing.Color.Transparent;
            this.treeImages.Images.SetKeyName(0, "Ahhhh_blue smiles.Png");
            this.treeImages.Images.SetKeyName(1, "Alien_blue smiles_111_111.Png");
            this.treeImages.Images.SetKeyName(2, "Hard Drive blue.ico");
            this.treeImages.Images.SetKeyName(3, "Hard Drive green.ico");
            this.treeImages.Images.SetKeyName(4, "CD Drive.ico");
            this.treeImages.Images.SetKeyName(5, "CD Drive2.ico");
            this.treeImages.Images.SetKeyName(6, "tour 3D.ico");
            this.treeImages.Images.SetKeyName(7, "tour 3D.ico");
            this.treeImages.Images.SetKeyName(8, "Floppy Disk Blue.ico");
            this.treeImages.Images.SetKeyName(9, "Floppy Disk Green.ico");
            this.treeImages.Images.SetKeyName(10, "NetDriveON.png");
            this.treeImages.Images.SetKeyName(11, "NetDriveOFF.ico");
            this.treeImages.Images.SetKeyName(12, "Drive - RAM 1.png");
            this.treeImages.Images.SetKeyName(13, "Drive - RAM 2.png");
            this.treeImages.Images.SetKeyName(14, "Closed Folder green.ico");
            this.treeImages.Images.SetKeyName(15, "Open Folder green.ico");
            this.treeImages.Images.SetKeyName(16, "Open Folder.ico");
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 0);
            this.splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.splitLeft);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.splitRight);
            this.splitMain.Size = new System.Drawing.Size(740, 480);
            this.splitMain.SplitterDistance = 232;
            this.splitMain.TabIndex = 0;
            // 
            // splitLeft
            // 
            this.splitLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitLeft.Location = new System.Drawing.Point(0, 0);
            this.splitLeft.Name = "splitLeft";
            this.splitLeft.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitLeft.Panel1
            // 
            this.splitLeft.Panel1.Controls.Add(this.checkHidden);
            // 
            // splitLeft.Panel2
            // 
            this.splitLeft.Panel2.Controls.Add(this.tree);
            this.splitLeft.Size = new System.Drawing.Size(232, 480);
            this.splitLeft.SplitterDistance = 49;
            this.splitLeft.TabIndex = 0;
            // 
            // checkHidden
            // 
            this.checkHidden.AutoSize = true;
            this.checkHidden.BackColor = System.Drawing.SystemColors.Info;
            this.checkHidden.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkHidden.Location = new System.Drawing.Point(4, 18);
            this.checkHidden.Margin = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.checkHidden.Name = "checkHidden";
            this.checkHidden.Size = new System.Drawing.Size(118, 20);
            this.checkHidden.TabIndex = 0;
            this.checkHidden.Text = "Show Hidden";
            this.checkHidden.UseVisualStyleBackColor = false;
            // 
            // tree
            // 
            this.tree.ImageIndex = 0;
            this.tree.ImageList = this.treeImages;
            this.tree.Location = new System.Drawing.Point(4, 3);
            this.tree.Name = "tree";
            this.tree.SelectedImageIndex = 0;
            this.tree.Size = new System.Drawing.Size(221, 420);
            this.tree.TabIndex = 0;
            this.tree.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tree_BeforeExpand);
            this.tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_AfterSelect);
            // 
            // splitRight
            // 
            this.splitRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitRight.Location = new System.Drawing.Point(0, 0);
            this.splitRight.Name = "splitRight";
            this.splitRight.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitRight.Panel1
            // 
            this.splitRight.Panel1.Controls.Add(this.lblDirInfo);
            // 
            // splitRight.Panel2
            // 
            this.splitRight.Panel2.Controls.Add(this.fileList);
            this.splitRight.Size = new System.Drawing.Size(504, 480);
            this.splitRight.SplitterDistance = 47;
            this.splitRight.TabIndex = 0;
            // 
            // lblDirInfo
            // 
            this.lblDirInfo.BackColor = System.Drawing.SystemColors.Info;
            this.lblDirInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDirInfo.Location = new System.Drawing.Point(7, 15);
            this.lblDirInfo.Name = "lblDirInfo";
            this.lblDirInfo.Size = new System.Drawing.Size(485, 23);
            this.lblDirInfo.TabIndex = 0;
            this.lblDirInfo.Text = "label1";
            // 
            // fileList
            // 
            this.fileList.FullRowSelect = true;
            this.fileList.GridLines = true;
            this.fileList.Location = new System.Drawing.Point(3, 3);
            this.fileList.Name = "fileList";
            this.fileList.Size = new System.Drawing.Size(498, 422);
            this.fileList.TabIndex = 0;
            this.fileList.UseCompatibleStateImageBehavior = false;
            this.fileList.View = System.Windows.Forms.View.Details;
            this.fileList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.fileList_ColumnClick);
            // 
            // FileSystemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitMain);
            this.Name = "FileSystemControl";
            this.Size = new System.Drawing.Size(740, 480);
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.splitLeft.Panel1.ResumeLayout(false);
            this.splitLeft.Panel1.PerformLayout();
            this.splitLeft.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitLeft)).EndInit();
            this.splitLeft.ResumeLayout(false);
            this.splitRight.Panel1.ResumeLayout(false);
            this.splitRight.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitRight)).EndInit();
            this.splitRight.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList treeImages;
        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.SplitContainer splitLeft;
        private System.Windows.Forms.TreeView tree;
        private System.Windows.Forms.SplitContainer splitRight;
        private System.Windows.Forms.CheckBox checkHidden;
        private System.Windows.Forms.Label lblDirInfo;
        private System.Windows.Forms.ListView fileList;
    }
}
