using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doanqlchdt
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new GUI.Edit.Editkh());
            //Application.Run(new GUI.Menu());
            //Application.Run(new GUI.Thêm.Themsanpham());
            Application.Run(new GUI.Manager.Manager());
        }
    }
}
