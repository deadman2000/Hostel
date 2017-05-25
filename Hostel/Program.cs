using System;
using System.Windows.Forms;
using Hostel.DB;
using Hostel.UI;

namespace Hostel
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] arg)
        {
            try
            {
                Store.Init();
            }
            catch (Exception e)
            {
                MessageBox.Show("DB Error:\n" + e);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormHostel());
        }
    }
}
