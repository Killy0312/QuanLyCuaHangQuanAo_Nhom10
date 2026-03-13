using System;
using System.Windows.Forms;

namespace QuanLyShopQuanAo
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Dòng này gọi đúng tên file frmMain lên
            Application.Run(new frmMain());
        }
    }
}