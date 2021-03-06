using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;

namespace MinegamesAdministrationTool
{
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string subnet = textBox1.Text;
            progressBar1.Maximum = 254;
            progressBar1.Value = 0;
            listView1.Items.Clear();

            Task.Factory.StartNew(new Action(() =>
            {
                for (int i = 2; i < 255; i++)
                {
                    string ip = $"{subnet}.{i}";
                    Ping ping = new Ping();
                    PingReply reply = ping.Send(ip, 100);
                    if (reply.Status == IPStatus.Success)
                    {
                        progressBar1.BeginInvoke(new Action(() =>
                        {
                            try
                            {
                                IPHostEntry host = Dns.GetHostEntry(IPAddress.Parse(ip));
                                listView1.Items.Add(new ListViewItem(new String[] { ip, host.HostName, "Up" }));
                            }
                            catch
                            {
                                MessageBox.Show($"Couldn't retrieve hostname from {ip} maybe because the host have a firewall.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            progressBar1.Value += 1;
                            label6.ForeColor = Color.Blue;
                            label6.Text = $"Scanning: {ip}";
                            if (progressBar1.Value == 253)
                                label6.Text = "Finished";
                        }));
                    }
                    else
                    {
                        progressBar1.BeginInvoke(new Action(() =>
                        {
                            progressBar1.Value += 1;
                            label6.ForeColor = Color.DarkGray;
                            label6.Text = $"Scanning: {ip}";
                            listView1.Items.Add(new ListViewItem(new String[] { ip, "", "Down" }));
                            if (progressBar1.Value == 253)
                                label6.Text = "Finished";
                        }));
                    }
                }
            }));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("simply: put your subnet (maybe it's 192.168.1) to the subnet textbox and the hosts on your network will be scanned.", "Simple", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Some hosts on your network may will not be shown or the program will tell you if the host is using a firewall.", "Firewall", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }
    }
}
