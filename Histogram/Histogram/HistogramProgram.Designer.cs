namespace Histogram
{
    partial class HistogramProgram
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistogramProgram));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FolderOpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripOpenSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.HistogramSaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PeakSaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSaveSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.FormCloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImageCropToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImageCopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImagePasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sourceImagePanel = new System.Windows.Forms.Panel();
            this.sourceImage = new System.Windows.Forms.PictureBox();
            this.histogramImage = new System.Windows.Forms.PictureBox();
            this.calculation = new System.Windows.Forms.Button();
            this.sourceImageLabel = new System.Windows.Forms.Label();
            this.histogramImageLabel = new System.Windows.Forms.Label();
            this.sourceImageListView = new System.Windows.Forms.ListView();
            this.columnHeaderNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPeak = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip.SuspendLayout();
            this.sourceImagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sourceImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.histogramImage)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.Window;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.EditToolStripMenuItem,
            this.VersionToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(632, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenImageToolStripMenuItem,
            this.FolderOpenToolStripMenuItem,
            this.toolStripOpenSeparator,
            this.HistogramSaveToolStripMenuItem,
            this.PeakSaveToolStripMenuItem,
            this.toolStripSaveSeparator,
            this.FormCloseToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.FileToolStripMenuItem.Text = "ファイル";
            // 
            // OpenImageToolStripMenuItem
            // 
            this.OpenImageToolStripMenuItem.Name = "OpenImageToolStripMenuItem";
            this.OpenImageToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OpenImageToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.OpenImageToolStripMenuItem.Text = "画像ファイルを開く";
            this.OpenImageToolStripMenuItem.Click += new System.EventHandler(this.OpenImageToolStripMenuItem_Click);
            // 
            // FolderOpenToolStripMenuItem
            // 
            this.FolderOpenToolStripMenuItem.Name = "FolderOpenToolStripMenuItem";
            this.FolderOpenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.FolderOpenToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.FolderOpenToolStripMenuItem.Text = "フォルダから読み込む";
            this.FolderOpenToolStripMenuItem.Click += new System.EventHandler(this.FolderOpenToolStripMenuItem_Click);
            // 
            // toolStripOpenSeparator
            // 
            this.toolStripOpenSeparator.Name = "toolStripOpenSeparator";
            this.toolStripOpenSeparator.Size = new System.Drawing.Size(218, 6);
            // 
            // HistogramSaveToolStripMenuItem
            // 
            this.HistogramSaveToolStripMenuItem.Name = "HistogramSaveToolStripMenuItem";
            this.HistogramSaveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.HistogramSaveToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.HistogramSaveToolStripMenuItem.Text = "ヒストグラムを保存";
            this.HistogramSaveToolStripMenuItem.Click += new System.EventHandler(this.HistogramSaveToolStripMenuItem_Click);
            // 
            // PeakSaveToolStripMenuItem
            // 
            this.PeakSaveToolStripMenuItem.Name = "PeakSaveToolStripMenuItem";
            this.PeakSaveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.PeakSaveToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.PeakSaveToolStripMenuItem.Text = "ピーク位置リストを保存";
            this.PeakSaveToolStripMenuItem.Click += new System.EventHandler(this.PeakSaveToolStripMenuItem_Click);
            // 
            // toolStripSaveSeparator
            // 
            this.toolStripSaveSeparator.Name = "toolStripSaveSeparator";
            this.toolStripSaveSeparator.Size = new System.Drawing.Size(218, 6);
            // 
            // FormCloseToolStripMenuItem
            // 
            this.FormCloseToolStripMenuItem.Name = "FormCloseToolStripMenuItem";
            this.FormCloseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.FormCloseToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.FormCloseToolStripMenuItem.Text = "終了";
            this.FormCloseToolStripMenuItem.Click += new System.EventHandler(this.FormCloseToolStripMenuItem_Click);
            // 
            // EditToolStripMenuItem
            // 
            this.EditToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ImageCropToolStripMenuItem,
            this.ImageCopyToolStripMenuItem,
            this.ImagePasteToolStripMenuItem});
            this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            this.EditToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.EditToolStripMenuItem.Text = "編集";
            this.EditToolStripMenuItem.Click += new System.EventHandler(this.EditToolStripMenuItem_Click);
            // 
            // ImageCropToolStripMenuItem
            // 
            this.ImageCropToolStripMenuItem.Name = "ImageCropToolStripMenuItem";
            this.ImageCropToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.ImageCropToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.ImageCropToolStripMenuItem.Text = "画像の切り取り";
            this.ImageCropToolStripMenuItem.Click += new System.EventHandler(this.ImageCropToolStripMenuItem_Click);
            // 
            // ImageCopyToolStripMenuItem
            // 
            this.ImageCopyToolStripMenuItem.Name = "ImageCopyToolStripMenuItem";
            this.ImageCopyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.ImageCopyToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.ImageCopyToolStripMenuItem.Text = "画像のコピー";
            this.ImageCopyToolStripMenuItem.Click += new System.EventHandler(this.ImageCopyToolStripMenuItem_Click);
            // 
            // ImagePasteToolStripMenuItem
            // 
            this.ImagePasteToolStripMenuItem.Name = "ImagePasteToolStripMenuItem";
            this.ImagePasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.ImagePasteToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.ImagePasteToolStripMenuItem.Text = "画像の貼り付け";
            this.ImagePasteToolStripMenuItem.Click += new System.EventHandler(this.ImagePasteToolStripMenuItem_Click);
            // 
            // VersionToolStripMenuItem
            // 
            this.VersionToolStripMenuItem.Name = "VersionToolStripMenuItem";
            this.VersionToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.VersionToolStripMenuItem.Text = "バージョン情報";
            this.VersionToolStripMenuItem.Click += new System.EventHandler(this.VersionToolStripMenuItem_Click);
            // 
            // sourceImagePanel
            // 
            this.sourceImagePanel.AutoScroll = true;
            this.sourceImagePanel.BackColor = System.Drawing.Color.White;
            this.sourceImagePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sourceImagePanel.Controls.Add(this.sourceImage);
            this.sourceImagePanel.Location = new System.Drawing.Point(299, 51);
            this.sourceImagePanel.Name = "sourceImagePanel";
            this.sourceImagePanel.Size = new System.Drawing.Size(321, 321);
            this.sourceImagePanel.TabIndex = 1;
            // 
            // sourceImage
            // 
            this.sourceImage.BackColor = System.Drawing.Color.White;
            this.sourceImage.Location = new System.Drawing.Point(0, 0);
            this.sourceImage.Name = "sourceImage";
            this.sourceImage.Size = new System.Drawing.Size(319, 319);
            this.sourceImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.sourceImage.TabIndex = 0;
            this.sourceImage.TabStop = false;
            // 
            // histogramImage
            // 
            this.histogramImage.BackColor = System.Drawing.Color.White;
            this.histogramImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.histogramImage.Location = new System.Drawing.Point(21, 51);
            this.histogramImage.Name = "histogramImage";
            this.histogramImage.Size = new System.Drawing.Size(258, 147);
            this.histogramImage.TabIndex = 2;
            this.histogramImage.TabStop = false;
            // 
            // calculation
            // 
            this.calculation.Location = new System.Drawing.Point(47, 223);
            this.calculation.Name = "calculation";
            this.calculation.Size = new System.Drawing.Size(205, 28);
            this.calculation.TabIndex = 3;
            this.calculation.Text = "計算";
            this.calculation.UseVisualStyleBackColor = true;
            this.calculation.Click += new System.EventHandler(this.Calculation_Click);
            // 
            // sourceImageLabel
            // 
            this.sourceImageLabel.AutoSize = true;
            this.sourceImageLabel.Location = new System.Drawing.Point(298, 32);
            this.sourceImageLabel.Name = "sourceImageLabel";
            this.sourceImageLabel.Size = new System.Drawing.Size(0, 18);
            this.sourceImageLabel.TabIndex = 5;
            // 
            // histogramImageLabel
            // 
            this.histogramImageLabel.AutoSize = true;
            this.histogramImageLabel.Location = new System.Drawing.Point(21, 32);
            this.histogramImageLabel.Name = "histogramImageLabel";
            this.histogramImageLabel.Size = new System.Drawing.Size(0, 18);
            this.histogramImageLabel.TabIndex = 6;
            // 
            // sourceImageListView
            // 
            this.sourceImageListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderNumber,
            this.columnHeaderFileName,
            this.columnHeaderPeak});
            this.sourceImageListView.Font = new System.Drawing.Font("メイリオ", 9F);
            this.sourceImageListView.FullRowSelect = true;
            this.sourceImageListView.GridLines = true;
            this.sourceImageListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.sourceImageListView.HideSelection = false;
            this.sourceImageListView.Location = new System.Drawing.Point(21, 271);
            this.sourceImageListView.Name = "sourceImageListView";
            this.sourceImageListView.Size = new System.Drawing.Size(258, 100);
            this.sourceImageListView.TabIndex = 7;
            this.sourceImageListView.TileSize = new System.Drawing.Size(188, 20);
            this.sourceImageListView.UseCompatibleStateImageBehavior = false;
            this.sourceImageListView.View = System.Windows.Forms.View.Details;
            this.sourceImageListView.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.SourceImageListView_ColumnWidthChanging);
            this.sourceImageListView.SelectedIndexChanged += new System.EventHandler(this.SourceImageListView_SelectedIndexChanged);
            // 
            // columnHeaderNumber
            // 
            this.columnHeaderNumber.Text = "No.";
            this.columnHeaderNumber.Width = 35;
            // 
            // columnHeaderFileName
            // 
            this.columnHeaderFileName.Text = "FileName";
            this.columnHeaderFileName.Width = 140;
            // 
            // columnHeaderPeak
            // 
            this.columnHeaderPeak.Text = "Peak";
            // 
            // HistogramProgram
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(632, 384);
            this.Controls.Add(this.sourceImageListView);
            this.Controls.Add(this.histogramImageLabel);
            this.Controls.Add(this.sourceImageLabel);
            this.Controls.Add(this.calculation);
            this.Controls.Add(this.histogramImage);
            this.Controls.Add(this.sourceImagePanel);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "HistogramProgram";
            this.Text = "ヒストグラム分析プログラム";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.HistogramProgram_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.HistogramProgram_DragEnter);
            this.DragLeave += new System.EventHandler(this.HistogramProgram_DragLeave);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.HistogramProgram_KeyUp);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.sourceImagePanel.ResumeLayout(false);
            this.sourceImagePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sourceImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.histogramImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HistogramSaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripOpenSeparator;
        private System.Windows.Forms.ToolStripMenuItem FolderOpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PeakSaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSaveSeparator;
        private System.Windows.Forms.ToolStripMenuItem FormCloseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ImageCropToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ImageCopyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ImagePasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem VersionToolStripMenuItem;
        private System.Windows.Forms.Panel sourceImagePanel;
        private System.Windows.Forms.PictureBox sourceImage;
        private System.Windows.Forms.PictureBox histogramImage;
        private System.Windows.Forms.Button calculation;
        private System.Windows.Forms.Label sourceImageLabel;
        private System.Windows.Forms.Label histogramImageLabel;
        private System.Windows.Forms.ListView sourceImageListView;
        private System.Windows.Forms.ColumnHeader columnHeaderNumber;
        private System.Windows.Forms.ColumnHeader columnHeaderFileName;
        private System.Windows.Forms.ColumnHeader columnHeaderPeak;
    }
}
