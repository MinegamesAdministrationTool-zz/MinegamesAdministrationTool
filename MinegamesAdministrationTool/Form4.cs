using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace MinegamesAdministrationTool
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ProcessText = textBox1.Text;
            Process UserProcess = new Process();
            UserProcess.StartInfo.FileName = ProcessText;
            UserProcess.Start();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
           
        }
    }
}
