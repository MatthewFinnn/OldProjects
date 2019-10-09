namespace WindowsFormsGalaxy
{
    partial class FormGalaxy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGalaxy));
            this.grid = new System.Windows.Forms.DataGridView();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.propGrid = new System.Windows.Forms.PropertyGrid();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Del = new System.Windows.Forms.ToolStripButton();
            this.FindString = new System.Windows.Forms.ToolStripTextBox();
            this.Find = new System.Windows.Forms.ToolStripButton();
            this.zgc1 = new ZedGraph.ZedGraphControl();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Location = new System.Drawing.Point(3, 31);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(732, 236);
            this.grid.TabIndex = 0;
            // 
            // picBox
            // 
            this.picBox.Location = new System.Drawing.Point(741, 31);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(254, 236);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox.TabIndex = 1;
            this.picBox.TabStop = false;
            // 
            // propGrid
            // 
            this.propGrid.Location = new System.Drawing.Point(741, 273);
            this.propGrid.Name = "propGrid";
            this.propGrid.Size = new System.Drawing.Size(253, 219);
            this.propGrid.TabIndex = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripButton5,
            this.ToolStripButton7,
            this.toolStripSeparator,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripSeparator1,
            this.Del,
            this.FindString,
            this.Find});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(997, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip";
            // 
            // ToolStripButton5
            // 
            this.ToolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton5.Image")));
            this.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton5.Name = "ToolStripButton5";
            this.ToolStripButton5.Size = new System.Drawing.Size(23, 22);
            this.ToolStripButton5.Text = "Open";
            // 
            // ToolStripButton7
            // 
            this.ToolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton7.Image")));
            this.ToolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton7.Name = "ToolStripButton7";
            this.ToolStripButton7.Size = new System.Drawing.Size(23, 22);
            this.ToolStripButton7.Text = "Save";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "First";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Prev";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "Next";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "Last";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // Del
            // 
            this.Del.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Del.Image = ((System.Drawing.Image)(resources.GetObject("Del.Image")));
            this.Del.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Del.Name = "Del";
            this.Del.Size = new System.Drawing.Size(23, 22);
            this.Del.Text = "Delete";
            // 
            // FindString
            // 
            this.FindString.Name = "FindString";
            this.FindString.Size = new System.Drawing.Size(100, 25);
            // 
            // Find
            // 
            this.Find.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Find.Image = ((System.Drawing.Image)(resources.GetObject("Find.Image")));
            this.Find.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Find.Name = "Find";
            this.Find.Size = new System.Drawing.Size(23, 22);
            this.Find.Text = "Find";
            // 
            // zgc1
            // 
            this.zgc1.EditButtons = System.Windows.Forms.MouseButtons.Left;
            this.zgc1.EditModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.zgc1.IsAutoScrollRange = false;
            this.zgc1.IsEnableHEdit = false;
            this.zgc1.IsEnableHPan = true;
            this.zgc1.IsEnableHZoom = true;
            this.zgc1.IsEnableVEdit = false;
            this.zgc1.IsEnableVPan = true;
            this.zgc1.IsEnableVZoom = true;
            this.zgc1.IsPrintFillPage = true;
            this.zgc1.IsPrintKeepAspectRatio = true;
            this.zgc1.IsScrollY2 = false;
            this.zgc1.IsShowContextMenu = true;
            this.zgc1.IsShowCopyMessage = true;
            this.zgc1.IsShowCursorValues = false;
            this.zgc1.IsShowHScrollBar = false;
            this.zgc1.IsShowPointValues = false;
            this.zgc1.IsShowVScrollBar = false;
            this.zgc1.IsSynchronizeXAxes = false;
            this.zgc1.IsSynchronizeYAxes = false;
            this.zgc1.IsZoomOnMouseCenter = false;
            this.zgc1.LinkButtons = System.Windows.Forms.MouseButtons.Left;
            this.zgc1.LinkModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.zgc1.Location = new System.Drawing.Point(3, 274);
            this.zgc1.Name = "zgc1";
            this.zgc1.PanButtons = System.Windows.Forms.MouseButtons.Left;
            this.zgc1.PanButtons2 = System.Windows.Forms.MouseButtons.Middle;
            this.zgc1.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
            this.zgc1.PanModifierKeys2 = System.Windows.Forms.Keys.None;
            this.zgc1.PointDateFormat = "g";
            this.zgc1.PointValueFormat = "G3";
            this.zgc1.ScrollMaxX = 0D;
            this.zgc1.ScrollMaxY = 0D;
            this.zgc1.ScrollMaxY2 = 0D;
            this.zgc1.ScrollMinX = 0D;
            this.zgc1.ScrollMinY = 0D;
            this.zgc1.ScrollMinY2 = 0D;
            this.zgc1.Size = new System.Drawing.Size(732, 218);
            this.zgc1.TabIndex = 5;
            this.zgc1.ZoomButtons = System.Windows.Forms.MouseButtons.Left;
            this.zgc1.ZoomButtons2 = System.Windows.Forms.MouseButtons.None;
            this.zgc1.ZoomModifierKeys = System.Windows.Forms.Keys.None;
            this.zgc1.ZoomModifierKeys2 = System.Windows.Forms.Keys.None;
            this.zgc1.ZoomStepFraction = 0.1D;
            // 
            // FormGalaxy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 502);
            this.Controls.Add(this.zgc1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.propGrid);
            this.Controls.Add(this.picBox);
            this.Controls.Add(this.grid);
            this.Name = "FormGalaxy";
            this.ShowIcon = false;
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.PropertyGrid propGrid;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ToolStripButton5;
        private System.Windows.Forms.ToolStripButton ToolStripButton7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton Del;
        private System.Windows.Forms.ToolStripTextBox FindString;
        private System.Windows.Forms.ToolStripButton Find;
        private ZedGraph.ZedGraphControl zgc1;
    }
}

