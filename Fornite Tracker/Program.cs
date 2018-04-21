using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fornite_Tracker
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //----------------------------------------------------
            //Vérification que l'application n'est pas déja lancée
            //----------------------------------------------------
            Process[] process = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);

            if (process.Length > 1)
            {
                MessageBox.Show("L'application est déjà en cours d'exécution");
                Application.Exit();
                Environment.Exit(1);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormStat());
        }
    }
}
