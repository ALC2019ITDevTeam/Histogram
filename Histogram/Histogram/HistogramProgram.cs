using Microsoft.WindowsAPICodePack.Dialogs;
using Microsoft.WindowsAPICodePack.Dialogs.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Histogram
{
    /// <summary>
    /// メインフォームです
    /// </summary>
    public partial class HistogramProgram : Form
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public HistogramProgram()
        {
            InitializeComponent();
            calculation.Enabled = false;
            HistogramSaveToolStripMenuItem.Enabled = false;
            PeakSaveToolStripMenuItem.Enabled = false;
            ImageCropToolStripMenuItem.Enabled = false;
            ImageCopyToolStripMenuItem.Enabled = false;
            if (ClipboardImage == null)
            {
                ImagePasteToolStripMenuItem.Enabled = false;
            }
        }

        /// <summary>
        /// クリップボードに画像を設定または取得する
        /// </summary>
        private Image ClipboardImage
        {
            get
            {
                return Clipboard.GetImage();
            }
            set
            {
                Clipboard.SetImage(value);
            }
        }

        /// <summary>
        /// 画像データクラス
        /// </summary>
        private List<ImageItem> imageList = new List<ImageItem>();

        /// <summary>
        /// 画像ファイルが読み込み中かどうか
        /// </summary>
        public bool fileLoaded = true;

        /// <summary>
        /// 画像ファイル読み込み中のタイトル
        /// </summary>
        private PictureBox fileLoadTitle = null;

        /// <summary>
        /// フォーム上に画像をドラッグ＆ドロップする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HistogramProgram_DragDrop(object sender, DragEventArgs e)
        {
            if (fileLoaded == true)
            {
                string[] dropData = (string[])e.Data.GetData(DataFormats.FileDrop);

                foreach (string file in dropData)
                {
                    if (!File.Exists(file) || Path.GetExtension(file).ToUpper() != ".BMP")
                    {
                        dropData[dropData.ToList().IndexOf(file)] = null;
                    }
                }

                List<string> dropDataList = new List<string>(dropData);
                dropDataList.RemoveAll(item => item == null);
                fileLoaded = false;

                if (fileLoadTitle != null)
                {
                    fileLoadTitle.Dispose();
                }

                if (dropDataList.Any())
                {
                    OpenImageFile(dropDataList.ToArray());
                }
                fileLoaded = true;
            }
            return;
        }

        /// <summary>
        /// フォーム上でドラッグされていたら、ファイル読み込みアイコンを表示する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HistogramProgram_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) && fileLoaded)
            {
                e.Effect = DragDropEffects.All;
                Bitmap clientSizeBitmap = new Bitmap(ClientSize.Width, ClientSize.Height);
                fileLoadTitle = new PictureBox();
                fileLoadTitle.Image = clientSizeBitmap;
                fileLoadTitle.BackColor = Color.FromArgb(255, 255, 255);
                fileLoadTitle.Size = new Size(ClientSize.Width, ClientSize.Height);
                fileLoadTitle.Parent = this;
                fileLoadTitle.Dock = DockStyle.Fill;
                fileLoadTitle.Location = new Point(0, 0);
                fileLoadTitle.TabStop = false;
                fileLoadTitle.BringToFront();

                PictureBox bitmapIcon = new PictureBox();
                bitmapIcon.Size = new Size(80, 80);
                bitmapIcon.Image = Properties.Resources.imagefile;
                bitmapIcon.Location = new Point(270, 100);
                bitmapIcon.Name = "bitmapIcon";
                bitmapIcon.Parent = fileLoadTitle;
                bitmapIcon.SizeMode = PictureBoxSizeMode.Zoom;

                Label fileLoadTitleLabel = new Label();
                fileLoadTitleLabel.AutoSize = true;
                fileLoadTitleLabel.Font = new Font("メイリオ", 16F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(128)));
                fileLoadTitleLabel.ForeColor = Color.Gray;
                fileLoadTitleLabel.Location = new Point(155, 215);
                fileLoadTitleLabel.Name = "fileLoadTitleLabel";
                fileLoadTitleLabel.Size = new Size(282, 48);
                fileLoadTitleLabel.Text = "ここに画像ファイルをドロップ";
                fileLoadTitleLabel.TextAlign = ContentAlignment.MiddleCenter;
                fileLoadTitleLabel.Parent = fileLoadTitle;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
            return;
        }

        /// <summary>
        /// フォーム上からマウスカーソルが離れたら、ファイル読み込みアイコンを消す
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HistogramProgram_DragLeave(object sender, EventArgs e)
        {
            if (fileLoadTitle != null)
            {
                fileLoadTitle.Dispose();
            }
            return;
        }

        /// <summary>
        /// ファイルタブ ＞ 画像ファイルを開く を選択したときに、画像を開く
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                fileLoaded = false;
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                openFileDialog.Filter = "画像ファイル(*.bmp)|*.bmp";
                openFileDialog.FilterIndex = 1;
                openFileDialog.Title = "画像ファイルを選択してください";
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    OpenImageFile(openFileDialog.FileNames);
                }
                fileLoaded = true;
            }
            return;
        }

        /// <summary>
        /// 画像を開く
        /// </summary>
        /// <param name="fileNames">ファイル名</param>
        private void OpenImageFile(string[] fileNames)
        {
            try
            {
                fileLoaded = false;
                calculation.Enabled = true;
                ListViewItem listViewItem = new ListViewItem();
                sourceImageListView.Items.Clear();
                imageList.Clear();

                foreach (string file in fileNames)
                {
                    int i = fileNames.ToList().IndexOf(file);
                    imageList.Add(new ImageItem(i, file, new Bitmap(file)));
                    listViewItem = sourceImageListView.Items.Add((i + 1).ToString());
                    listViewItem.SubItems.Add(Path.GetFileName(imageList[i].Path));
                    listViewItem.SubItems.Add("");
                }

                sourceImage.Image = imageList[0].SourceImage;
                histogramImageLabel.Text = imageList[0].ImageLabel;
                sourceImageLabel.Text = Extensions.ShortenDirectory(imageList[0].Path);
                sourceImageListView.Items[0].Selected = true;
            }
            catch (Exception ex)
            {
                calculation.Enabled = false;
                sourceImageListView.Items.Clear();
                imageList.Clear();
                sourceImage.Image = null;
                sourceImageLabel.Text = string.Empty;
                histogramImageLabel.Text = string.Empty;
                MessageBox.Show("ファイル読み込み時にエラーが発生しました。\n\n詳細：" + ex.ToString(), "ヒストグラム分析プログラム", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                histogramImage.Image = null;
                ToolStripMenuItemEnabled();
                fileLoaded = true;
            }
            return;
        }

        /// <summary>
        /// ファイルタブ ＞ フォルダから読み込む を選択したときに、フォルダからの画像読み込みを行う
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FolderOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (CommonOpenFileDialog commonOpenFileDialog = new CommonOpenFileDialog("フォルダ選択"))
            {
                fileLoaded = false;
                commonOpenFileDialog.IsFolderPicker = true;
                commonOpenFileDialog.Title = "画像ファイルがあるフォルダを選択してください";
                commonOpenFileDialog.RestoreDirectory = true;
                if (commonOpenFileDialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    try
                    {
                        DirectoryInfo directoryInfo = new DirectoryInfo(commonOpenFileDialog.FileName);
                        FileInfo[] fileInfo = directoryInfo.GetFiles("*.bmp", SearchOption.TopDirectoryOnly);

                        if (!fileInfo.Any())
                        {
                            MessageBox.Show("画像ファイルが見つかりませんでした。", "ヒストグラム分析プログラム", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }

                        calculation.Enabled = true;
                        ListViewItem listViewItem = new ListViewItem();
                        sourceImageListView.Items.Clear();
                        imageList.Clear();

                        foreach (FileInfo file in fileInfo)
                        {
                            int i = fileInfo.ToList().IndexOf(file);
                            imageList.Add(new ImageItem(i, file.FullName, new Bitmap(file.FullName)));
                            listViewItem = sourceImageListView.Items.Add((i + 1).ToString());
                            listViewItem.SubItems.Add(Path.GetFileName(imageList[i].Path));
                            listViewItem.SubItems.Add("");
                        }

                        sourceImage.Image = imageList[0].SourceImage;
                        histogramImageLabel.Text = imageList[0].ImageLabel;
                        sourceImageLabel.Text = Extensions.ShortenDirectory(imageList[0].Path);
                        sourceImageListView.Items[0].Selected = true;
                    }
                    catch (Exception ex)
                    {
                        calculation.Enabled = false;
                        sourceImageListView.Items.Clear();
                        imageList.Clear();
                        sourceImage.Image = null;
                        sourceImageLabel.Text = string.Empty;
                        histogramImageLabel.Text = string.Empty;
                        MessageBox.Show("ファイル読み込み時にエラーが発生しました。\n\n詳細：" + ex.ToString(), "ヒストグラム分析プログラム", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        histogramImage.Image = null;
                        ToolStripMenuItemEnabled();
                    }
                }
                fileLoaded = true;
            }
            return;
        }

        /// <summary>
        /// ファイルタブ ＞ ヒストグラムを保存 を選択したときに、ファイルを保存する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HistogramSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileLoaded = false;
            using (SaveFileDialog saveBitmapFileDialog = new SaveFileDialog())
            {
                
                DateTime dateTime = DateTime.Now;
                saveBitmapFileDialog.FileName = Extensions.HistogramDefaultFileName(sourceImageLabel.Text, DateTime.Now);
                saveBitmapFileDialog.Filter = "画像ファイル(*.bmp)|*.bmp";
                saveBitmapFileDialog.RestoreDirectory = true;

                if (saveBitmapFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Bitmap histogramSaveImage = (Bitmap)histogramImage.Image;
                        Bitmap tempSaveImage = new Bitmap(histogramSaveImage.Width, histogramSaveImage.Height);
                        Graphics g = Graphics.FromImage(tempSaveImage);
                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        g.Clear(Color.White);
                        g.DrawImage(histogramSaveImage, 0, 0, histogramSaveImage.Width, histogramSaveImage.Height);
                        tempSaveImage.Save(saveBitmapFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ファイル保存時にエラーが発生しました。\n\n詳細：" + ex.ToString(), "ヒストグラム分析プログラム", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
            fileLoaded = true;
            return;
        }

        /// <summary>
        /// ファイルタブ ＞ ピーク位置リストを保存 を選択したときに、ファイルを保存する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PeakSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileLoaded = false;
            using (CommonSaveFileDialog saveCsvFileDialog = new CommonSaveFileDialog())
            {
                DateTime dateTime = DateTime.Now;
                CommonFileDialogComboBox commonFileDialogComboBox = new CommonFileDialogComboBox();
                commonFileDialogComboBox.Items.Add(new CommonFileDialogComboBoxItem("Shift-JIS"));
                commonFileDialogComboBox.Items.Add(new CommonFileDialogComboBoxItem("UTF-8"));
                commonFileDialogComboBox.SelectedIndex = 0;
                saveCsvFileDialog.Controls.Add(commonFileDialogComboBox);
                saveCsvFileDialog.DefaultFileName = Extensions.PeakListDefaultFileName(DateTime.Now);
                saveCsvFileDialog.Filters.Add(new CommonFileDialogFilter("csvファイル", "*.csv"));
                saveCsvFileDialog.RestoreDirectory = true;

                if (saveCsvFileDialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    (bool savedCsv, string exceptionText) = SaveCsv.SaveCsvFile(sourceImageListView, saveCsvFileDialog.FileName, commonFileDialogComboBox.Items[commonFileDialogComboBox.SelectedIndex].Text.ToLower());
                    if (!savedCsv)
                    {
                        MessageBox.Show("ファイル保存時にエラーが発生しました。\n\n詳細：" + exceptionText, "ヒストグラム分析プログラム", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            fileLoaded = true;
            return;
        }

        /// <summary>
        /// ファイルタブ ＞ 終了 を選択したときに、終了する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sourceImage.Image != null)
            {
                fileLoaded = false;
                DialogResult dialogResult = MessageBox.Show("終了してよろしいですか？", "ヒストグラム分析プログラム", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                fileLoaded = true;
                if (dialogResult == DialogResult.Yes)
                {
                    if (fileLoadTitle != null)
                    {
                        fileLoadTitle.Dispose();
                    }
                    Close();
                }
            }
            else
            {
                if (fileLoadTitle != null)
                {
                    fileLoadTitle.Dispose();
                }
                Close();
            }
            return;
        }

        /// <summary>
        /// 編集タブ ＞ 画像の切り取り を選択したときに、画像を切り取りする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageCropToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClipboardImage = sourceImage.Image;
            sourceImage.Image = null;
            histogramImage.Image = null;
            sourceImageLabel.Text = string.Empty;
            histogramImageLabel.Text = string.Empty;
            sourceImageListView.Items.Clear();
            imageList.Clear();
            ToolStripMenuItemEnabled();
            return;
        }

        /// <summary>
        /// 編集タブ ＞ 画像のコピー を選択したときに、画像をコピーする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClipboardImage = sourceImage.Image;
            ToolStripMenuItemEnabled();
            return;
        }

        /// <summary>
        /// 編集タブ ＞ 画像の貼り付け を選択したときに、画像を貼り付ける
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImagePasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ClipboardImage != null)
            {
                calculation.Enabled = true;
                sourceImageListView.Items.Clear();
                imageList.Clear();
                imageList.Add(new ImageItem(0, "Clipboard", new Bitmap(ClipboardImage)));
                ListViewItem listViewItem = sourceImageListView.Items.Add("1");
                listViewItem.SubItems.Add("Clipboard");
                listViewItem.SubItems.Add("");
                sourceImage.Image = imageList[0].SourceImage;
                histogramImageLabel.Text = imageList[0].ImageLabel;
                sourceImageLabel.Text = imageList[0].Path;
                histogramImage.Image = null;
                sourceImageListView.Items[0].Selected = true;
            }
            ToolStripMenuItemEnabled();
            return;
        }

        /// <summary>
        /// バージョン情報タブを選択したときに、バージョン情報を表示する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VersionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileLoaded = false;
            MessageBox.Show("ヒストグラム分析プログラム\nバージョン：1.0.2（R3.4.11更新）\n動作環境：.NET Framework 4.7.2以上\n\n©ALC 2019年度会員 近藤 健", "バージョン情報");
            fileLoaded = true;
            return;
        }

        /// <summary>
        /// 編集タブを選択したときに、編集タブの各項目の有効/無効を変更する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItemEnabled();
            return;
        }

        /// <summary>
        /// フォーム上で何かキー操作をしたときに、編集タブの各項目の有効/無効を変更する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HistogramProgram_KeyUp(object sender, KeyEventArgs e)
        {
            ToolStripMenuItemEnabled();
            return;
        }

        /// <summary>
        /// 計算ボタンを左クリックしたときに計算を開始する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Calculation_Click(object sender, EventArgs e)
        {
            if (!imageList.Any())
            {
                return;
            }

            InversionSetValue(false);
            calculation.Text = "計算中";

            foreach (ImageItem item in imageList)
            {
                sourceImageListView.Items[item.Id].SubItems[2].Text = string.Empty;
            }
            await Task.Run(() => {
                try
                {
                    foreach (ImageItem item in imageList)
                    {
                        item.HistogramImage = HistogramCalculation((Bitmap)item.SourceImage, item.Id);
                        string calculationStatus = (Math.Min((int)((float)(item.Id + 1) * 100.0f / (float)imageList.Count), 100)).ToString();
                        if (InvokeRequired)
                        {
                            Invoke((MethodInvoker)(() => calculation.Text = "計算中(" + calculationStatus + "%)"));
                        }
                        else
                        {
                            calculation.Text = "計算中(" + calculationStatus + "%)";
                        }
                    }
                }
                catch (Exception ex)
                {
                    imageList[0].HistogramImage = null;
                    MessageBox.Show("計算中にエラーが発生しました。\n\n詳細：" + ex.ToString(), "ヒストグラム分析プログラム", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
            histogramImage.Image = imageList[0].HistogramImage;

            if (imageList[0].HistogramImage != null && sourceImageListView.Items.Count > 0 && !fileLoaded)
            {
                int index = sourceImageListView.SelectedItems[0].Index;
                sourceImage.Image = imageList[index].SourceImage;
                histogramImageLabel.Text = imageList[index].ImageLabel;
                histogramImage.Image = imageList[index].HistogramImage;
                sourceImageLabel.Text = Extensions.ShortenDirectory(imageList[index].Path);
            }

            ToolStripMenuItemEnabled();
            InversionSetValue(true);
            calculation.Text = "計算";
            return;
        }

        /// <summary>
        /// 設定値を反転する
        /// </summary>
        /// <param name="isEnabled">現在の真偽値</param>
        /// <returns></returns>
        public void InversionSetValue(bool isEnabled)
        {
            fileLoaded = isEnabled;
            calculation.Enabled = isEnabled;
            OpenImageToolStripMenuItem.Enabled = isEnabled;
            FolderOpenToolStripMenuItem.Enabled = isEnabled;
            EditToolStripMenuItem.Enabled = isEnabled;
            HistogramSaveToolStripMenuItem.Enabled = isEnabled;
            PeakSaveToolStripMenuItem.Enabled = isEnabled;
            return;
        }

        /// <summary>
        /// 編集タブの各項目の有効/無効を変更する
        /// </summary>
        private void ToolStripMenuItemEnabled()
        {
            // 画像データが表示されているかどうか
            if (sourceImage.Image != null)
            {
                ImageCropToolStripMenuItem.Enabled = true;
                ImageCopyToolStripMenuItem.Enabled = true;
                calculation.Enabled = true;
            }
            else
            {
                ImageCropToolStripMenuItem.Enabled = false;
                ImageCopyToolStripMenuItem.Enabled = false;
                calculation.Enabled = false;
            }

            // ヒストグラムが表示されているかどうか
            if (histogramImage.Image != null)
            {
                HistogramSaveToolStripMenuItem.Enabled = true;
                PeakSaveToolStripMenuItem.Enabled = true;
            }
            else
            {
                HistogramSaveToolStripMenuItem.Enabled = false;
                PeakSaveToolStripMenuItem.Enabled = false;
            }

            // クリップボードに画像データが存在するかどうか
            if (ClipboardImage != null)
            {
                ImagePasteToolStripMenuItem.Enabled = true;
            }
            else
            {
                ImagePasteToolStripMenuItem.Enabled = false;
            }
            return;
        }

        /// <summary>
        /// リストを選択したとき、その画像と情報に変更する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SourceImageListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sourceImageListView.SelectedItems.Count > 0 && calculation.Enabled == true)
            {
                int index = sourceImageListView.SelectedItems[0].Index;
                sourceImage.Image = imageList[index].SourceImage;
                histogramImageLabel.Text = imageList[index].ImageLabel;
                histogramImage.Image = imageList[index].HistogramImage;
                sourceImageLabel.Text = Extensions.ShortenDirectory(imageList[index].Path);
            }
            return;
        }

        /// <summary>
        /// リストビューの列幅を固定する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SourceImageListView_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = sourceImageListView.Columns[e.ColumnIndex].Width;
            return;
        }

        /// <summary>
        /// ヒストグラムを計算して表示する
        /// </summary>
        /// <param name="sourceImageItem">ソース画像</param>
        /// <param name="listItem">ソース画像のインデックス</param>
        /// <returns>ヒストグラム画像</returns>
        private Bitmap HistogramCalculation(Bitmap sourceImageItem, int listItem)
        {
            (Bitmap histogramImage, string peakHistogram) = ConvertImageToHistogram.GenerateHistogramImage(sourceImageItem);

            if (InvokeRequired)
            {
                Invoke((MethodInvoker)(() => sourceImageListView.Items[listItem].SubItems[2].Text = peakHistogram));
            }
            else
            {
                sourceImageListView.Items[listItem].SubItems[2].Text = peakHistogram;
            }

            return new Bitmap(histogramImage);
        }
    }
}
