using System;
using System.Windows.Forms;

namespace ShannonFano
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ShannonFano());
        }
    }
}
