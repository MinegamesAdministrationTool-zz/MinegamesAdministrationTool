using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Microsoft.Win32;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinegamesAdministrationTool
{
    public partial class Form14 : Form
    {
        public Form14()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                Process[] x64dbg = Process.GetProcessesByName("x64dbg");

                foreach (Process x64 in x64dbg)
                    x64.Kill();

                Process[] x32dbg = Process.GetProcessesByName("x32dbg");

                foreach (Process x32 in x32dbg)
                    x32.Kill();

                Process[] ollydbg = Process.GetProcessesByName("ollydbg");

                foreach (Process x32 in ollydbg)
                    x32.Kill();

                Process[] Windbg = Process.GetProcessesByName("EngHost");

                foreach (Process EngHost in Windbg)
                    EngHost.Kill();

                Process[] CheatEngine = Process.GetProcessesByName("Cheat Engine");

                foreach (Process MemoryDebugger in CheatEngine)
                    MemoryDebugger.Kill();

                Process[] CheatEngine1 = Process.GetProcessesByName("cheatengine-x86_64");

                foreach (Process MemoryDebugger1 in CheatEngine1)
                    MemoryDebugger1.Kill();

                Process[] CheatEngine2 = Process.GetProcessesByName("cheatengine-x86_64-SSE4-AVX2");

                foreach (Process MemoryDebugger2 in CheatEngine2)
                    MemoryDebugger2.Kill();

                Process[] CheatEngine3 = Process.GetProcessesByName("cheatengine-i386");

                foreach (Process MemoryDebugger3 in CheatEngine3)
                    MemoryDebugger3.Kill();

                Process[] dotPeek64 = Process.GetProcessesByName("dotPeek64");

                foreach (Process Decompiler in dotPeek64)
                    Decompiler.Kill();

                Process[] dnSpy = Process.GetProcessesByName("dnSpy");

                foreach (Process Decompiler1 in dnSpy)
                    Decompiler1.Kill();

                Process[] VisualDebugger = Process.GetProcessesByName("vsjitdebugger");

                foreach (Process VisualDebugger1 in VisualDebugger)
                    VisualDebugger1.Kill();

                Process[] ILSpy = Process.GetProcessesByName("ILSpy");

                foreach (Process ILspy in ILSpy)
                    ILspy.Kill();

                Process[] IEProcesses = Process.GetProcessesByName("iexplore.exe");
                foreach (Process CurrentProcess in IEProcesses)
                {
                    if (CurrentProcess.MainWindowTitle.Contains("x64dbg, ILSpy, dnSpy, dotPeek64, cheatengine-i386, cheatengine-x86_64-SSE4-AVX2, cheatengine-x86_64, Cheat Engine, EngHost, ollydbg, x32dbg, vsjitdebugger"))
                    {
                        CurrentProcess.Kill();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error While trying to Enable Debug Process Blocker", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                RegistryKey Disablex32Dbg = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\x32dbg.exe");
                Disablex32Dbg.SetValue("Debugger", @"C:\Users\NoDebug.exe", RegistryValueKind.String);

                RegistryKey DisableOllyDbg = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\ollydbg.exe");
                DisableOllyDbg.SetValue("Debugger", @"C:\Users\NoDebug.exe", RegistryValueKind.String);

                RegistryKey Disablex64dbg = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\x64dbg.exe");
                Disablex64dbg.SetValue("Debugger", @"C:\Users\NoDebug.exe", RegistryValueKind.String);

                RegistryKey DisableEngHost = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\EngHost.exe");
                DisableEngHost.SetValue("Debugger", @"C:\Users\NoDebug.exe", RegistryValueKind.String);

                RegistryKey DisableWindbg = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\DbgX.Shell.exe");
                DisableWindbg.SetValue("Debugger", @"C:\Users\NoDebug.exe", RegistryValueKind.String);

                RegistryKey DisableCheatEngine = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\Cheat Engine.exe");
                DisableCheatEngine.SetValue("Debugger", @"C:\Users\NoDebug.exe", RegistryValueKind.String);

                RegistryKey DisableCheatEngine1 = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\cheatengine-x86_64.exe");
                DisableCheatEngine1.SetValue("Debugger", @"C:\Users\NoDebug.exe", RegistryValueKind.String);

                RegistryKey DisableCheatEngine2 = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\cheatengine-x86_64-SSE4-AVX2.exe");
                DisableCheatEngine2.SetValue("Debugger", @"C:\Users\NoDebug.exe", RegistryValueKind.String);

                RegistryKey DisableCheatEngine3 = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\cheatengine-i386.exe");
                DisableCheatEngine3.SetValue("Debugger", @"C:\Users\NoDebug.exe", RegistryValueKind.String);

                RegistryKey DisabledotPeek64 = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\dotPeek64.exe");
                DisabledotPeek64.SetValue("Debugger", @"C:\Users\NoDebug.exe", RegistryValueKind.String);

                RegistryKey DisablednSpy = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\dnSpy.exe");
                DisablednSpy.SetValue("Debugger", @"C:\Users\NoDebug.exe", RegistryValueKind.String);

                RegistryKey Disablevsjitdebugger = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\vsjitdebugger.exe");
                Disablevsjitdebugger.SetValue("Debugger", @"C:\Users\NoDebug.exe", RegistryValueKind.String);

                timer1.Enabled = true;
                timer1.Start();
            }
            catch
            {
                MessageBox.Show("Error While Writing to Registery.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                RegistryKey Enablex32Dbg = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options");
                Enablex32Dbg.DeleteSubKey("x32dbg.exe");

                RegistryKey EnableOllyDbg = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options");
                EnableOllyDbg.DeleteSubKey("ollydbg.exe");

                RegistryKey Enablex64dbg = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options");
                Enablex64dbg.DeleteSubKey("x64dbg.exe");

                RegistryKey EnableEngHost = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options");
                EnableEngHost.DeleteSubKey("EngHost.exe");

                RegistryKey EnableWindbg = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options");
                EnableWindbg.DeleteSubKey("DbgX.Shell.exe");

                RegistryKey EnableCheatEngine = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options");
                EnableCheatEngine.DeleteSubKey("Cheat Engine.exe");

                RegistryKey EnableCheatEngine1 = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options");
                EnableCheatEngine1.DeleteSubKey("cheatengine-x86_64.exe");

                RegistryKey EnableCheatEngine2 = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options");
                EnableCheatEngine2.DeleteSubKey("cheatengine-x86_64-SSE4-AVX2.exe");

                RegistryKey EnableCheatEngine3 = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options");
                EnableCheatEngine3.DeleteSubKey("cheatengine-i386.exe");

                RegistryKey EnabledotPeek64 = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options");
                EnabledotPeek64.DeleteSubKey("dotPeek64.exe");

                RegistryKey EnablednSpy = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options");
                EnablednSpy.DeleteSubKey("dnSpy.exe");

                RegistryKey Disablevsjitdebugger = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options");
                EnablednSpy.DeleteSubKey("vsjitdebugger.exe");
            }
            catch
            {
                MessageBox.Show("There's an Error are you even enabled this feauture once?", "Are you Even?", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

            timer1.Enabled = false;
            timer1.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This function disables all known Debugging programs and Memory Debuggers and decomilers and prevent it from start by redirecting it to another program and if the program started or the registery repaired the anti debugging will still close the process when it launch you may even see that it didn't show (never) but the Minegames program should be opened to keep closing it (will get updates or a tool alone to be like that).", "Advanced Anti Debugging", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }
    }
}
