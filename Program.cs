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
<<<<<<< HEAD
            //Application.Run(new GUI.Edit.Editkh());
            //Application.Run(new GUI.Menu());
            //Application.Run(new GUI.Thêm.Themsanpham());
            Application.Run(new GUI.Manager.Manager());
=======
            Application.Run(new GUI.Login());
>>>>>>> 7d37b7b2d53ac482edacc1b20aea44ed80eac356
        }
    }
}
