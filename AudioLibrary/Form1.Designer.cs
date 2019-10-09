namespace AudioLibrary
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.bn = new System.Windows.Forms.BindingNavigator(this.components);
            this.open = new System.Windows.Forms.ToolStripButton();
            this.save = new System.Windows.Forms.ToolStripButton();
            this.btnShowData = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.lblFind = new System.Windows.Forms.ToolStripLabel();
            this.comboFind = new System.Windows.Forms.ToolStripComboBox();
            this.btnFindNext = new System.Windows.Forms.ToolStripButton();
            this.btnFindList = new System.Windows.Forms.ToolStripButton();
            this.btnFindView = new System.Windows.Forms.ToolStripButton();
            this.btnAverageLow = new System.Windows.Forms.ToolStripLabel();
            this.tAverageLow = new System.Windows.Forms.ToolStripTextBox();
            this.btnAverageHi = new System.Windows.Forms.ToolStripLabel();
            this.tAverageHi = new System.Windows.Forms.ToolStripTextBox();
            this.average = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripFind = new System.Windows.Forms.ToolStrip();
            this.labelColumn = new System.Windows.Forms.ToolStripLabel();
            this.comboBoxColumns = new System.Windows.Forms.ToolStripComboBox();
            this.labelTables = new System.Windows.Forms.ToolStripLabel();
            this.comboBoxTables = new System.Windows.Forms.ToolStripComboBox();
            this.gridArtist = new System.Windows.Forms.DataGridView();
            this.gridAlbum = new System.Windows.Forms.DataGridView();
            this.gridTracklist = new System.Windows.Forms.DataGridView();
            this.albumFoto = new System.Windows.Forms.PictureBox();
            this.labelAlbum = new System.Windows.Forms.Label();
            this.labelArtist = new System.Windows.Forms.Label();
            this.artistFoto = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.bn)).BeginInit();
            this.bn.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStripFind.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridArtist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAlbum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTracklist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.albumFoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.artistFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // bn
            // 
            this.bn.AddNewItem = null;
            this.bn.CountItem = null;
            this.bn.DeleteItem = null;
            this.bn.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.open,
            this.save,
            this.btnShowData,
            this.toolStripSeparator7,
            this.lblFind,
            this.comboFind,
            this.btnFindNext,
            this.btnFindList,
            this.btnFindView,
            this.btnAverageLow,
            this.tAverageLow,
            this.btnAverageHi,
            this.tAverageHi,
            this.average,
            this.toolStripSeparator1,
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.bn.Location = new System.Drawing.Point(0, 0);
            this.bn.MoveFirstItem = null;
            this.bn.MoveLastItem = null;
            this.bn.MoveNextItem = null;
            this.bn.MovePreviousItem = null;
            this.bn.Name = "bn";
            this.bn.PositionItem = null;
            this.bn.Size = new System.Drawing.Size(1143, 25);
            this.bn.TabIndex = 1;
            this.bn.Text = "bindingNavigator1";
            // 
            // open
            // 
            this.open.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.open.Image = ((System.Drawing.Image)(resources.GetObject("open.Image")));
            this.open.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(23, 22);
            this.open.Text = "&Открыть";
            // 
            // save
            // 
            this.save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.save.Image = ((System.Drawing.Image)(resources.GetObject("save.Image")));
            this.save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(23, 22);
            this.save.Text = "&Сохранить";
            // 
            // btnShowData
            // 
            this.btnShowData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnShowData.Image = ((System.Drawing.Image)(resources.GetObject("btnShowData.Image")));
            this.btnShowData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowData.Name = "btnShowData";
            this.btnShowData.Size = new System.Drawing.Size(23, 22);
            this.btnShowData.Text = "Show Data";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // lblFind
            // 
            this.lblFind.Name = "lblFind";
            this.lblFind.Size = new System.Drawing.Size(36, 22);
            this.lblFind.Text = "Find: ";
            // 
            // comboFind
            // 
            this.comboFind.Name = "comboFind";
            this.comboFind.Size = new System.Drawing.Size(121, 25);
            // 
            // btnFindNext
            // 
            this.btnFindNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFindNext.Image = ((System.Drawing.Image)(resources.GetObject("btnFindNext.Image")));
            this.btnFindNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFindNext.Name = "btnFindNext";
            this.btnFindNext.Size = new System.Drawing.Size(23, 22);
            this.btnFindNext.Text = "Find Next";
            // 
            // btnFindList
            // 
            this.btnFindList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFindList.Image = ((System.Drawing.Image)(resources.GetObject("btnFindList.Image")));
            this.btnFindList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFindList.Name = "btnFindList";
            this.btnFindList.Size = new System.Drawing.Size(23, 22);
            this.btnFindList.Text = "Find List";
            // 
            // btnFindView
            // 
            this.btnFindView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFindView.Image = ((System.Drawing.Image)(resources.GetObject("btnFindView.Image")));
            this.btnFindView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFindView.Name = "btnFindView";
            this.btnFindView.Size = new System.Drawing.Size(23, 22);
            this.btnFindView.Text = "Find View ";
            // 
            // btnAverageLow
            // 
            this.btnAverageLow.Name = "btnAverageLow";
            this.btnAverageLow.Size = new System.Drawing.Size(78, 22);
            this.btnAverageLow.Text = "Average low: ";
            // 
            // tAverageLow
            // 
            this.tAverageLow.Name = "tAverageLow";
            this.tAverageLow.Size = new System.Drawing.Size(40, 25);
            // 
            // btnAverageHi
            // 
            this.btnAverageHi.Name = "btnAverageHi";
            this.btnAverageHi.Size = new System.Drawing.Size(20, 22);
            this.btnAverageHi.Text = "hi:";
            // 
            // tAverageHi
            // 
            this.tAverageHi.Name = "tAverageHi";
            this.tAverageHi.Size = new System.Drawing.Size(40, 25);
            // 
            // average
            // 
            this.average.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.average.Image = ((System.Drawing.Image)(resources.GetObject("average.Image")));
            this.average.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.average.Name = "average";
            this.average.Size = new System.Drawing.Size(23, 22);
            this.average.Text = "Average";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Переместить в начало";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Переместить назад";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Положение";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Текущее положение";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(43, 22);
            this.bindingNavigatorCountItem.Text = "для {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Общее число элементов";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Переместить вперед";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Переместить в конец";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Добавить";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Удалить";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 599);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1143, 25);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "toolStripButton3";
            // 
            // toolStripFind
            // 
            this.toolStripFind.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStripFind.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelColumn,
            this.comboBoxColumns,
            this.labelTables,
            this.comboBoxTables});
            this.toolStripFind.Location = new System.Drawing.Point(0, 25);
            this.toolStripFind.Name = "toolStripFind";
            this.toolStripFind.Size = new System.Drawing.Size(120, 574);
            this.toolStripFind.TabIndex = 10;
            this.toolStripFind.Text = "toolStrip2";
            this.toolStripFind.Visible = false;
            // 
            // labelColumn
            // 
            this.labelColumn.Name = "labelColumn";
            this.labelColumn.Size = new System.Drawing.Size(81, 15);
            this.labelColumn.Text = "Column";
            // 
            // comboBoxColumns
            // 
            this.comboBoxColumns.Name = "comboBoxColumns";
            this.comboBoxColumns.Size = new System.Drawing.Size(79, 23);
            // 
            // labelTables
            // 
            this.labelTables.Name = "labelTables";
            this.labelTables.Size = new System.Drawing.Size(81, 15);
            this.labelTables.Text = "Table";
            // 
            // comboBoxTables
            // 
            this.comboBoxTables.Name = "comboBoxTables";
            this.comboBoxTables.Size = new System.Drawing.Size(79, 23);
            // 
            // gridArtist
            // 
            this.gridArtist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridArtist.Location = new System.Drawing.Point(12, 29);
            this.gridArtist.Name = "gridArtist";
            this.gridArtist.Size = new System.Drawing.Size(602, 203);
            this.gridArtist.TabIndex = 0;
            // 
            // gridAlbum
            // 
            this.gridAlbum.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAlbum.Location = new System.Drawing.Point(12, 234);
            this.gridAlbum.Name = "gridAlbum";
            this.gridAlbum.Size = new System.Drawing.Size(603, 177);
            this.gridAlbum.TabIndex = 0;
            // 
            // gridTracklist
            // 
            this.gridTracklist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTracklist.Location = new System.Drawing.Point(12, 417);
            this.gridTracklist.Name = "gridTracklist";
            this.gridTracklist.Size = new System.Drawing.Size(604, 160);
            this.gridTracklist.TabIndex = 0;
            // 
            // albumFoto
            // 
            this.albumFoto.Location = new System.Drawing.Point(872, 47);
            this.albumFoto.Name = "albumFoto";
            this.albumFoto.Size = new System.Drawing.Size(233, 221);
            this.albumFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.albumFoto.TabIndex = 5;
            this.albumFoto.TabStop = false;
            // 
            // labelAlbum
            // 
            this.labelAlbum.AutoSize = true;
            this.labelAlbum.Location = new System.Drawing.Point(866, 25);
            this.labelAlbum.Name = "labelAlbum";
            this.labelAlbum.Size = new System.Drawing.Size(60, 13);
            this.labelAlbum.TabIndex = 7;
            this.labelAlbum.Text = "Album Foto";
            // 
            // labelArtist
            // 
            this.labelArtist.AutoSize = true;
            this.labelArtist.Location = new System.Drawing.Point(629, 29);
            this.labelArtist.Name = "labelArtist";
            this.labelArtist.Size = new System.Drawing.Size(51, 13);
            this.labelArtist.TabIndex = 8;
            this.labelArtist.Text = "Artist foto";
            // 
            // artistFoto
            // 
            this.artistFoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.artistFoto.Location = new System.Drawing.Point(632, 45);
            this.artistFoto.Name = "artistFoto";
            this.artistFoto.Size = new System.Drawing.Size(234, 223);
            this.artistFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.artistFoto.TabIndex = 6;
            this.artistFoto.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 624);
            this.Controls.Add(this.gridTracklist);
            this.Controls.Add(this.gridAlbum);
            this.Controls.Add(this.gridArtist);
            this.Controls.Add(this.labelAlbum);
            this.Controls.Add(this.labelArtist);
            this.Controls.Add(this.albumFoto);
            this.Controls.Add(this.artistFoto);
            this.Controls.Add(this.toolStripFind);
            this.Controls.Add(this.bn);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Audio Library";
            ((System.ComponentModel.ISupportInitialize)(this.bn)).EndInit();
            this.bn.ResumeLayout(false);
            this.bn.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStripFind.ResumeLayout(false);
            this.toolStripFind.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridArtist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAlbum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTracklist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.albumFoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.artistFoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingNavigator bn;
        private System.Windows.Forms.ToolStripButton open;
        private System.Windows.Forms.ToolStripButton save;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripLabel lblFind;
        private System.Windows.Forms.ToolStripComboBox comboFind;
        private System.Windows.Forms.ToolStripButton btnFindNext;
        private System.Windows.Forms.ToolStripButton btnFindList;
        private System.Windows.Forms.ToolStripButton btnFindView;
        private System.Windows.Forms.ToolStripLabel btnAverageLow;
        private System.Windows.Forms.ToolStripTextBox tAverageLow;
        private System.Windows.Forms.ToolStripLabel btnAverageHi;
        private System.Windows.Forms.ToolStripTextBox tAverageHi;
        private System.Windows.Forms.ToolStripButton average;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStrip toolStripFind;
        private System.Windows.Forms.ToolStripComboBox comboBoxColumns;
        private System.Windows.Forms.ToolStripLabel labelColumn;
        private System.Windows.Forms.ToolStripLabel labelTables;
        private System.Windows.Forms.ToolStripComboBox comboBoxTables;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.DataGridView gridArtist;
        private System.Windows.Forms.DataGridView gridAlbum;
        private System.Windows.Forms.DataGridView gridTracklist;
        private System.Windows.Forms.ToolStripButton btnShowData;
        private System.Windows.Forms.PictureBox albumFoto;
        private System.Windows.Forms.Label labelAlbum;
        private System.Windows.Forms.Label labelArtist;
        private System.Windows.Forms.PictureBox artistFoto;
    }
}

