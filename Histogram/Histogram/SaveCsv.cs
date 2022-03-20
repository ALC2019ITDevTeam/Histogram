using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Histogram
{
    /// <summary>
    /// CSVファイルを保存するクラスです
    /// </summary>
    public static class SaveCsv
    {
        /// <summary>
        /// CSVファイルを保存する
        /// </summary>
        /// <param name="listView">リストビュー</param>
        /// <param name="fileName">保存するCSVファイルのファイル名</param>
        /// <param name="encoding">保存するCSVファイルのエンコード</param>
        /// <returns>例外メッセージ</returns>
        public static (bool, string) SaveCsvFile(ListView listView, string fileName, string encoding)
        {
            try
            {
                GenerateCsvFile(listView, fileName, encoding);
            }
            catch (Exception ex)
            {
                return (false, ex.ToString());
            }
            return (true, null);
        }

        /// <summary>
        /// CSVファイルを出力する
        /// </summary>
        /// <param name="listView">リストビュー</param>
        /// <param name="fileName">保存するCSVファイルのファイル名</param>
        /// <param name="encoding">保存するCSVファイルのエンコード</param>
        public static void GenerateCsvFile(ListView listView, string fileName, string encoding)
        {
            using (StreamWriter streamWriter = new StreamWriter(fileName, false, Encoding.GetEncoding(encoding)))
            {
                string listHeader = string.Empty;
                for (int i = 0; i < listView.Columns.Count; i++)
                {
                    listHeader += listView.Columns[i].Text + ",";
                }
                streamWriter.WriteLine(listHeader.Remove(listHeader.Length - 1, 1));

                foreach (ListViewItem listViewItem in listView.Items)
                {
                    string listitem = string.Empty;
                    foreach (ListViewItem.ListViewSubItem subItem in listViewItem.SubItems)
                    {
                        listitem += subItem.Text + ",";
                    }
                    streamWriter.WriteLine(listitem.Remove(listitem.Length - 1, 1));
                }
            }
            return;
        }
    }
}
