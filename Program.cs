using Medivest_BarCodePrinter.Models.Login.Medivest;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace Medivest_BarCodePrinter
{
    static class Program
    {
        public static string SvrBaseAddress {get; set;} = "http://www.ftsap.com:82/medivest";
        public static UserProfile LogonUser { get; set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AppConfig();
            Application.Run(new Form_Login());
        }

        static void AppConfig ()
        {
            SvrBaseAddress = ConfigurationManager.AppSettings["svr"];
            if (string.IsNullOrWhiteSpace(SvrBaseAddress))
            {
                SvrBaseAddress = "http://www.ftsap.com:82/medivest";
            }
        }
    }
}
