using Histogram;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace HistogramTests
{
    /// <summary>
    /// 単体テストです
    /// </summary>
    [TestClass]
    public class UnitTest
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public UnitTest()
        {
            HistogramProgram = new HistogramProgram();
        }

        /// <summary>
        /// ヒストグラム分析プログラムメインフォーム
        /// </summary>
        HistogramProgram HistogramProgram { get; set; }

        [TestMethod]
        public void イメージの大きさと面積を正常に計算できる()
        {
            var image = new Bitmap(256, 145);
            var imageSize = Extensions.ImageLabelSize(image);

            Assert.AreEqual(imageSize, "X=256, Y=145　37120 Points");
            return;
        }

        [TestMethod]
        public void 設定値を設定できる()
        {
            HistogramProgram.InversionSetValue(false);

            Assert.AreEqual(HistogramProgram.fileLoaded, false);
            return;
        }

        [TestMethod]
        public void 一つのヒストグラムの最大値を出力できる()
        {
            var histogramMaxValue = new Dictionary<int, int>();
            histogramMaxValue.Add(5, 100);
            histogramMaxValue.Add(10, 255); // 最大値
            histogramMaxValue.Add(35, 250);
            var histogramMaxIndex = 255;
            string peakHistogram = Extensions.HistogramMax(histogramMaxValue, histogramMaxIndex);

            Assert.AreEqual(peakHistogram, "10");
            return;
        }

        [TestMethod]
        public void 複数のヒストグラムの最大値を出力できる()
        {
            var histogramMaxValue = new Dictionary<int, int>();
            histogramMaxValue.Add(10, 255); // 最大値
            histogramMaxValue.Add(25, 15);
            histogramMaxValue.Add(125, 255); // 最大値
            histogramMaxValue.Add(150, 215);
            histogramMaxValue.Add(219, 255); // 最大値
            var histogramMaxIndex = 255;
            string peakHistogram = Extensions.HistogramMax(histogramMaxValue, histogramMaxIndex);

            Assert.AreEqual(peakHistogram, "10，125，219");
            return;
        }

        [TestMethod]
        public void 現在時刻を含んだCSVデフォルトファイル名を生成できる()
        {
            DateTime dateTime = DateTime.Now;
            var defaultFileName = Extensions.PeakListDefaultFileName(dateTime);

            Assert.AreEqual(defaultFileName, "PeakList_" + dateTime.ToString("yyyyMMddHHmm") + ".csv");
            return;
        }

        [TestMethod]
        public void 現在時刻を含んだヒストグラム画像デフォルトファイル名を生成できる()
        {
            var fileName = "test";
            var filePath = "C:\\Program Files\\test.bmp";
            DateTime dateTime = DateTime.Now;
            var defaultFileName = Extensions.HistogramDefaultFileName(filePath, dateTime);

            Assert.AreEqual(defaultFileName, "Histogram(" + fileName + ")_" + dateTime.ToString("yyyyMMddHHmm") + ".bmp");
            return;
        }

        [TestMethod]
        public void 現在時刻を含んだヒストグラム画像デフォルトファイル名を省略パスで生成できる()
        {
            var fileName = "test";
            var filePath = "C:\\Program Files\\...\\test.bmp";
            DateTime dateTime = DateTime.Now;
            var defaultFileName = Extensions.HistogramDefaultFileName(filePath, dateTime);

            Assert.AreEqual(defaultFileName, "Histogram(" + fileName + ")_" + dateTime.ToString("yyyyMMddHHmm") + ".bmp");
            return;
        }

        [TestMethod]
        public void 画像ファイルパスを出力できる()
        {
            var filePath = "C:\\Users\\test\\Desktop\\TestHistogram.bmp";
            filePath = Extensions.ShortenDirectory(filePath);

            Assert.AreEqual(filePath, "C:\\Users\\test\\Desktop\\TestHistogram.bmp");
            return;
        }

        [TestMethod]
        public void 画像ファイルパスを短縮して出力できる()
        {
            var filePath = "C:\\Users\\TestUser\\Desktop\\NewFolder\\TestHistogram.bmp";
            filePath = Extensions.ShortenDirectory(filePath);

            Assert.AreEqual(filePath, "C:\\...\\NewFolder\\TestHistogram.bmp");
            return;
        }

        [TestMethod]
        public void 画像ファイルパスをさらに短縮して出力できる()
        {
            var filePath = "C:\\Users\\TestUser\\Desktop\\NewFolder_TestHistogram\\NewTestHistogram_TestFile.bmp";
            filePath = Extensions.ShortenDirectory(filePath);

            Assert.AreEqual(filePath, "C:\\...\\NewTestHistogram_TestFile.bmp");
            return;
        }
    }
}
