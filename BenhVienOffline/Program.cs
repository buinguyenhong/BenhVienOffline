using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BenhVienOffline
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
            // Note: Database initialization and newly created forms/services may not yet be included in the project file.
            // To allow building, start the original main form. Add/Include new files into the .csproj to enable the full flow.
            Application.Run(new Form1());
        }
    }
}
