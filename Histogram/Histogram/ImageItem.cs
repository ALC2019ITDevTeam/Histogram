using System.Drawing;

namespace Histogram
{
    /// <summary>
    /// 画像データクラスです
    /// </summary>
    public class ImageItem
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="id">読み込まれた画像ファイルのID</param>
        /// <param name="path">読み込まれた画像ファイルのフルパス</param>
        /// <param name="sourceImage">読み込まれた画像</param>
        /// <param name="imageLabel">読み込まれた画像ファイルの大きさ、ピクセル面積</param>
        /// <param name="histogramImage">ヒストグラムの画像</param>
        public ImageItem(int id, string path, Image sourceImage, Image histogramImage = null)
        {
            Id = id;
            Path = path;
            SourceImage = sourceImage;
            ImageLabel = Extensions.ImageLabelSize(sourceImage);
            HistogramImage = histogramImage;
        }

        /// <summary>
        /// 読み込まれた画像ファイルのIDです
        /// </summary>
        public int Id { set; get; }

        /// <summary>
        /// 読み込まれた画像ファイルのフルパスです
        /// </summary>
        public string Path { set; get; }

        /// <summary>
        /// 読み込まれた画像です
        /// </summary>
        public Image SourceImage { set; get; }

        /// <summary>
        /// 読み込まれた画像ファイルの大きさ、ピクセル面積です
        /// </summary>
        public string ImageLabel { set; get; }

        /// <summary>
        /// ヒストグラムの画像です
        /// </summary>
        public Image HistogramImage { set; get; }
    }
}
