using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using Microsoft.Win32;
using System.Diagnostics;
using System.Media;
using System.Runtime.InteropServices;

namespace MinegamesAdministrationTool
{
    public partial class Form1 : Form
    {
        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern bool CheckRemoteDebuggerPresent(IntPtr hProcess, ref bool isDebuggerPresent);

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsDebuggerPresent();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistryKey EnableTaskManager = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
            EnableTaskManager.SetValue("DisableTaskMgr", 0, RegistryValueKind.DWord);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegistryKey DisableTaskManager = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
            DisableTaskManager.SetValue("DisableTaskMgr", 1, RegistryValueKind.DWord);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RegistryKey EnableRegedit = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
            EnableRegedit.SetValue("DisableRegistryTools", 0, RegistryValueKind.DWord);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RegistryKey DisableRegedit = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
            DisableRegedit.SetValue("DisableRegistryTools", 1, RegistryValueKind.DWord);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RegistryKey EnableCMD = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\System");
            EnableCMD.SetValue("DisableCMD", 0, RegistryValueKind.DWord);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RegistryKey DisableCMD = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\System");
            DisableCMD.SetValue("DisableCMD", 1, RegistryValueKind.DWord);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            RegistryKey EnableWindowsUpdate = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\AU");
            EnableWindowsUpdate.SetValue("NoAutoUpdate", 0, RegistryValueKind.DWord);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            RegistryKey DisableWindowsUpdate = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\AU");
            DisableWindowsUpdate.SetValue("NoAutoUpdate", 1, RegistryValueKind.DWord);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            RegistryKey EnableRun = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer");
            EnableRun.SetValue("NoRun", 0, RegistryValueKind.DWord);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            RegistryKey DisableRun = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer");
            DisableRun.SetValue("NoRun", 1, RegistryValueKind.DWord);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            RegistryKey EnableWSC = Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\wscsvc");
            EnableWSC.SetValue("Start", 0, RegistryValueKind.DWord);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            RegistryKey DisableWSC = Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\wscsvc");
            DisableWSC.SetValue("Start", 1, RegistryValueKind.DWord);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            RegistryKey DisableUAC = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
            DisableUAC.SetValue("EnableLUA", 0, RegistryValueKind.DWord);

            RegistryKey DisableTaskManager = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
            DisableTaskManager.SetValue("DisableTaskMgr", 1, RegistryValueKind.DWord);

            RegistryKey DisableRegedit = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
            DisableRegedit.SetValue("DisableRegistryTools", 1, RegistryValueKind.DWord);

            RegistryKey DisableCMD = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\System");
            DisableCMD.SetValue("DisableCMD", 1, RegistryValueKind.DWord);

            RegistryKey DisableWindowsUpdate = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\AU");
            DisableWindowsUpdate.SetValue("NoAutoUpdate", 1, RegistryValueKind.DWord);

            RegistryKey DisableRun = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer");
            DisableRun.SetValue("NoRun", 1, RegistryValueKind.DWord);

            RegistryKey DisableWSC = Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\wscsvc");
            DisableWSC.SetValue("Start", 1, RegistryValueKind.DWord);

            MessageBox.Show("Restart may require to apply some options", "Restart", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            RegistryKey EnableUAC = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
            EnableUAC.SetValue("EnableLUA", 1, RegistryValueKind.DWord);

            RegistryKey EnableTaskManager = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
            EnableTaskManager.SetValue("DisableTaskMgr", 0, RegistryValueKind.DWord);

            RegistryKey EnableRegedit = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
            EnableRegedit.SetValue("DisableRegistryTools", 0, RegistryValueKind.DWord);

            RegistryKey EnableCMD = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\System");
            EnableCMD.SetValue("DisableCMD", 0, RegistryValueKind.DWord);

            RegistryKey EnableWindowsUpdate = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\AU");
            EnableWindowsUpdate.SetValue("NoAutoUpdate", 0, RegistryValueKind.DWord);

            RegistryKey EnableRun = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer");
            EnableRun.SetValue("NoRun", 0, RegistryValueKind.DWord);

            RegistryKey EnableWSC = Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\wscsvc");
            EnableWSC.SetValue("Start", 0, RegistryValueKind.DWord);

            MessageBox.Show("Restart may require to apply some options", "Restart", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            new Form2().Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            RegistryKey EnableUAC = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
            EnableUAC.SetValue("EnableLUA", 1, RegistryValueKind.DWord);

            MessageBox.Show("Restart may require to apply some options", "Restart", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }
        private void button17_Click(object sender, EventArgs e)
        {
            RegistryKey DisableUAC = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
            DisableUAC.SetValue("EnableLUA", 0, RegistryValueKind.DWord);

            MessageBox.Show("Restart may require to apply some options", "Restart", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            RegistryKey DisableTaskMgr = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
            DisableTaskMgr.SetValue("DisableTaskMgr", 1, RegistryValueKind.DWord);

            RegistryKey TrickTaskMgr = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\Taskmgr.exe");
            TrickTaskMgr.SetValue("Debugger", "calc.exe", RegistryValueKind.String);

            RegistryKey AdditionalProtection = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\calc.exe");
            AdditionalProtection.SetValue("Debugger", "notepad.exe", RegistryValueKind.String);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            try
            {
                RegistryKey EnableTaskManager = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
                EnableTaskManager.SetValue("DisableTaskMgr", 0, RegistryValueKind.DWord);

                RegistryKey DisableTrickTaskMgr = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\Taskmgr.exe");
                DisableTrickTaskMgr.DeleteValue("Debugger");

                RegistryKey DisableAdditionalProtection = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\calc.exe");
                DisableAdditionalProtection.DeleteValue("Debugger");
            }
            catch
            {
                MessageBox.Show("You Didn't Disable task Manager extremly to Disable it.", "Disable Task Manager Extremly not enabled", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            new Form3().Show();
        }

        private void Chatting_Click(object sender, EventArgs e)
        {
            new Form5().Show();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            new Form7().Show();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            new Form8().Show();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            new Form11().Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(@"C:\Users\NoDebug.exe"))
                {
                    WebClient NoDebug = new WebClient();
                    MessageBox.Show("You need to download NoDebug Please Click Ok or Cancel to Download it.", "NoDebug", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    NoDebug.DownloadFile("https://cdn.discordapp.com/attachments/813318804364460032/817531083335008306/NoDebug.exe", @"C:\Users\NoDebug.exe");
                    MessageBox.Show("NoDebug Have been Downloaded.", "NoDebug", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("NoDebug Already Installed.", "NoDebug", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Error while Downloading NoDebug please check your internet connection.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                this.Close();
            }

            bool isDebuggerPresent = false;
            CheckRemoteDebuggerPresent(Process.GetCurrentProcess().Handle, ref isDebuggerPresent);
            MessageBox.Show("are there a debugger?: " + isDebuggerPresent);

            Debugger.Break();
            Debug.Close();

            timer1.Enabled = true;
            timer1.Start();
        }


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void button24_Click(object sender, EventArgs e)
        {
            new Form9().Show();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            new Form12().Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool isDebuggerPresent = false;
            var AreThereADebugger = CheckRemoteDebuggerPresent(Process.GetCurrentProcess().Handle, ref isDebuggerPresent);

            if (Debugger.IsAttached)
            {
                Debugger.Break();
                Application.Exit();
            }

            if (AreThereADebugger && IsDebuggerPresent())
            {
                Debugger.Break();
                Application.Exit();
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            new Form14().Show();
        }
    }
}