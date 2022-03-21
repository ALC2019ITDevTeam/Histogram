using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;

namespace Histogram
{
    /// <summary>
    /// 読み込んだ画像をヒストグラムに変換するクラスです
    /// </summary>
    public static class ConvertImageToHistogram
    {
        /// <summary>
        /// ヒストグラムの最大値を取得し、ヒストグラムの画像を生成する
        /// </summary>
        /// <param name="sourceImageItem">ソース画像</param>
        /// <returns>ヒストグラム画像, ヒストグラムの最大値</returns>
        public static (Bitmap, string) GenerateHistogramImage(Bitmap sourceImageItem)
        {
            Bitmap histogramImageItem = new Bitmap(256, 145);
            int brightness;
            List<int> histogram = new int[256].ToList();

            // ピクセルの色情報を読み取り、輝度情報を計算して、ヒストグラムの値をつくる
            BitmapData bitmapData = sourceImageItem.LockBits(new Rectangle(0, 0, sourceImageItem.Width, sourceImageItem.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            byte[] pixelRGB = new byte[sourceImageItem.Width * sourceImageItem.Height * 4];
            Marshal.Copy(bitmapData.Scan0, pixelRGB, 0, pixelRGB.Length);
            for (int i = 0; i < pixelRGB.Length; i += 4)
            {
                brightness = Math.Min((int)Math.Round(0.299f * (float)pixelRGB[i + 2] + 0.587f * (float)pixelRGB[i + 1] + 0.114f * (float)pixelRGB[i]), 255);
                histogram[brightness]++;
            }
            Marshal.Copy(pixelRGB, 0, bitmapData.Scan0, pixelRGB.Length);
            sourceImageItem.UnlockBits(bitmapData);

            // ヒストグラムの最大値を取得する
            int histogramMax = histogram.Max();

            // ヒストグラムをhistogramImageに表示する
            float smoothingPeak, smoothingPeakMax = 0.0f;
            Dictionary<int, int> histogramMaxValue = new Dictionary<int, int>();
            Point smoothingStartPoint = new Point(0, (int)Math.Round((float)histogram[0] / (float)histogramMax * 145.0f) - 1);
            Point smoothingEndPoint;
            Pen histogramPen = new Pen(Color.Yellow, 1.0f);
            Pen smoothingHistogramPen = new Pen(Color.Red, 1.0f);
            Graphics histogramGraphics;
            Graphics smoothingHistogramGraphics;

            for (int i = 0; i < 256; i++)
            {
                histogramGraphics = Graphics.FromImage(histogramImageItem);
                histogramGraphics.DrawLine(histogramPen, new Point(i, (int)(((float)histogram[i] / (float)histogramMax) * 128.0f)), new Point(i, 0));
                histogramGraphics.Dispose();

                if (i > 0 && i < 255)
                {
                    smoothingPeak = (float)(histogram[i - 1] + 2.0f * histogram[i] + histogram[i + 1]) / 4.0f;
                    smoothingEndPoint = new Point(i, (int)Math.Round(smoothingPeak / (float)histogramMax * 128.0f) - 1);
                    if (smoothingStartPoint.Y != -1 || smoothingEndPoint.Y != -1)
                    {
                        smoothingHistogramGraphics = Graphics.FromImage(histogramImageItem);
                        smoothingHistogramGraphics.DrawLine(smoothingHistogramPen, smoothingStartPoint, smoothingEndPoint);
                        smoothingHistogramGraphics.Dispose();
                        if (smoothingPeakMax <= smoothingPeak)
                        {
                            histogramMaxValue.Add(i, (int)smoothingPeak);
                            smoothingPeakMax = smoothingPeak;
                        }
                    }
                    smoothingStartPoint = smoothingEndPoint;
                }
            }
            histogramPen.Dispose();

            // 平滑化したヒストグラムの最大値とそのインデックスを計算・表示する
            int histogramMaxIndex = histogramMaxValue.Max(item => item.Value);
            string peakHistogram = Extensions.HistogramMax(histogramMaxValue, histogramMaxIndex);
            histogramImageItem.RotateFlip(RotateFlipType.RotateNoneFlipY);
            Graphics histogramGraphicsText = Graphics.FromImage(histogramImageItem);
            histogramGraphicsText.DrawString("Peak=" + peakHistogram, new Font("MS UI Gothic", 9, FontStyle.Regular), Brushes.Black, 20, 0);
            histogramGraphicsText.DrawImage(histogramImageItem, 0, 0);
            return (histogramImageItem, peakHistogram);
        }
    }
}
