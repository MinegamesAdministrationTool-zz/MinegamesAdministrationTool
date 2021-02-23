using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;
using System.IO;
using System.Media;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

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
            try
            {

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
                throw;
            }

            Process[] getprocess = Process.GetProcesses();

            foreach (Process proc in getprocess)
            {
                listBox1.Items.Add(Convert.ToString(proc.ProcessName));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
                throw;
            }

            Process[] Termination = Process.GetProcessesByName(listBox1.SelectedItem.ToString());

            foreach (Process process in Termination)
            {
                process.Kill();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
                throw;
            }

            listBox1.Items.Clear();

            Process[] Refresh = Process.GetProcesses();

            foreach (Process process in Refresh)
            {
                listBox1.Items.Add(Convert.ToString(process.ProcessName));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.TopMost = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
                throw;
            }

            this.TopMost = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
                throw;
            }

            new Form4().Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
                throw;
            }

            Console.Beep(32762, 1000000);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new Form6().Show();
        }
    }
}
