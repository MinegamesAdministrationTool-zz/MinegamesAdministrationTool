using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;
using System.IO;
using System.Media;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Principal;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace MinegamesAdministrationTool
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
        if (new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator))
            {
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            else
            {
                MessageBox.Show("Can't start the program because it have been cracked or edited or being debugged.");
            }
        }
    }
}
