using System;
using System.Windows.Forms;

namespace Histogram
{
    public static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new HistogramProgram());
        }
    }
}
