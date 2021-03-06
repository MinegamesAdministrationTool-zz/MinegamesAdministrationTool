using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace MinegamesAdministrationTool
{
    public partial class Form10 : Form
    {
        byte[] FileEncrypter;
        byte[,] table;

        public Form10()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog browse = new OpenFileDialog();
            browse.Multiselect = false;

            if (browse.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = browse.FileName;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                radioButton2.Checked = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                radioButton1.Checked = false;
            }
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            FileEncrypter = new byte[256];
            for (int i = 0; i < 256; i++)
                FileEncrypter[i] = Convert.ToByte(i);
            table = new byte[256, 256];
            for (int i = 0; i < 256; i++)
                for (int j = 0; j < 256; j++)
                {
                    table[i, j] = FileEncrypter[(i + j) % 256];
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!File.Exists(textBox1.Text))
            {
                MessageBox.Show("File Are not there please check your path", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("You didn't enter any password please enter a password and try again", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            try
            {
                byte[] fileContent = File.ReadAllBytes(textBox1.Text);
                byte[] Passwordtmp = Encoding.ASCII.GetBytes(textBox2.Text);
                byte[] keys = new byte[fileContent.Length];
                for (int i = 0; i < fileContent.Length; i++)
                    keys[i] = Passwordtmp[i % Passwordtmp.Length];
                byte[] result = new byte[fileContent.Length];
                if (radioButton1.Checked)
                {
                    for (int i = 0; i < fileContent.Length; i++)
                    {
                        byte value = fileContent[i];
                        byte key = keys[i];
                        int valueindex = -1, keyIndex = -1;
                        for (int j = 0; j < 256; j++)
                            if (FileEncrypter[j] == value)
                            {
                                valueindex = j;
                                break;
                            }
                        for (int j = 0; j < 256; j++)
                            if (FileEncrypter[j] == key)
                            {
                                keyIndex = j;
                                break;
                            }
                        result[i] = table[keyIndex, valueindex];
                    }
                }
                else
                {
                    for (int i = 0; i < fileContent.Length; i++)
                    {
                        byte value = fileContent[i];
                        byte key = keys[i];
                        int valueindex = -1, keyIndex = -1;
                        for (int j = 0; j < 256; j++)
                            if (FileEncrypter[j] == key)
                            {
                                keyIndex = j;
                                break;
                            }
                        for (int j = 0; j < 256; j++)
                            if (FileEncrypter[j] == value)
                            {
                                keyIndex = j;
                                break;
                            }
                        result[i] = FileEncrypter[valueindex];
                    }
                    String extension = Path.GetExtension(".Minecryptor");
                    SaveFileDialog sd = new SaveFileDialog();
                    sd.Filter = "Files (*" + extension + ") | *" + extension;
                    if (sd.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllBytes(sd.FileName, result);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Please Check if the file is opened and close it.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
