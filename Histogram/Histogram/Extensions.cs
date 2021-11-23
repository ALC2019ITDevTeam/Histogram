using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Histogram
{
    /// <summary>
    /// 静的メソッドを定義するクラスです
    /// </summary>
    static public class Extensions
    {
        /// <summary>
        /// ヒストグラム画像デフォルトファイル名を設定する
        /// </summary>
        /// <param name="filePath">ファイルパス</param>
        /// <param name="dateTime">日時</param>
        /// <returns>ファイル名</returns>
        static public string HistogramDefaultFileName(string filePath, DateTime dateTime)
        {
            if (filePath != "Clipboard")
            {
                if (filePath.Contains("\\...\\"))
                {
                    filePath.Replace("\\...\\", "\\");
                }
                filePath = Path.GetFileName(filePath);
                filePath = filePath.Remove(filePath.Length - 4);
            }
            return @"Histogram(" + filePath + ")_" + dateTime.ToString("yyyyMMddHHmm") + ".bmp";
        }

        /// <summary>
        /// CSVデフォルトファイル名を設定する
        /// </summary>
        /// <param name="dateTime">日時</param>
        /// <returns>ファイル名</returns>
        static public string PeakListDefaultFileName(DateTime dateTime)
        {
            return @"PeakList_" + dateTime.ToString("yyyyMMddHHmm") + ".csv";
        }

        /// <summary>
        /// 長いファイルパスを短縮する
        /// </summary>
        /// <param name="path">ファイルパス</param>
        /// <returns>ファイルパス</returns>
        static public string ShortenDirectory(string path)
        {
            Bitmap canvas = new Bitmap(15 * path.Length, 20);
            Graphics graphics = Graphics.FromImage(canvas);
            Font fontStyle = new Font("メイリオ", 9F);
            TextRenderer.DrawText(graphics, path, fontStyle, new Point(0, 0), Color.Black);
            Size stringSize = TextRenderer.MeasureText(graphics, path, fontStyle);

            string labelText = path;
            if (stringSize.Width >= 325)
            {
                labelText = Path.GetPathRoot(path) + "...\\" + Path.GetFileName(Path.GetDirectoryName(path)) + "\\" + Path.GetFileName(path);
                graphics.Dispose();
                canvas = new Bitmap(15 * labelText.Length, 20);
                graphics = Graphics.FromImage(canvas);
                TextRenderer.DrawText(graphics, labelText, fontStyle, new Point(0, 0), Color.Black);
                stringSize = TextRenderer.MeasureText(graphics, labelText, fontStyle);

                if (stringSize.Width >= 325)
                {
                    labelText = Path.GetPathRoot(path) + "...\\" + Path.GetFileName(path);
                }
            }
            return labelText;
        }

        /// <summary>
        /// イメージの大きさ・面積を計算する
        /// </summary>
        /// <param name="image">イメージ</param>
        /// <returns>イメージの大きさ・面積</returns>
        static public string ImageLabelSize(Image image)
        {
            return "X=" + image.Width + ", Y=" + image.Height + "　" + (image.Width * image.Height) + " Points";
        }

        /// <summary>
        /// ヒストグラムの最大値を文字列に変換する
        /// </summary>
        /// <param name="histogramMaxValue">ヒストグラムの最大値の候補</param>
        /// <param name="histogramMaxIndex">ヒストグラムの最大値</param>
        /// <returns>ヒストグラムの最大値</returns>
        static public string HistogramMax(Dictionary<int, int> histogramMaxValue, int histogramMaxIndex)
        {
            string peakHistogram = string.Empty;
            foreach (KeyValuePair<int, int> item in histogramMaxValue)
            {
                if (item.Value == histogramMaxIndex)
                {
                    peakHistogram += item.Key + "，";
                }
            }
            return peakHistogram.Remove(peakHistogram.Length - 1);
        }
    }
}
