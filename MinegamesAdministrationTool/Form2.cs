using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace MinegamesAdministrationTool
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            Process[] getit = Process.GetProcesses();

            foreach (Process proc in getit)
            {
                listBox1.Items.Add(Convert.ToString(proc.ProcessName));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process[] Termination = Process.GetProcessesByName(listBox1.SelectedItem.ToString());

            foreach (Process process in Termination)
            {
                process.Kill();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            Process[] Refresh = Process.GetProcesses();

            foreach (Process process in Refresh)
            {
                listBox1.Items.Add(Convert.ToString(process.ProcessName));
            }
        }
    }
}
