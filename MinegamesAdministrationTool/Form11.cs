using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace MinegamesAdministrationTool
{
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }
        byte[] Encrypt(byte[] data, RSAParameters RSAKey, bool fOAEP)
        {
            byte[] encryptedData;
            using (RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider())
            {
                rSACryptoServiceProvider.ImportParameters(RSAKey);
                encryptedData = rSACryptoServiceProvider.Encrypt(data, fOAEP);
            }
            return encryptedData;
        }
        byte[] Decrypt(byte[] data, RSAParameters RSAKey, bool fOAEP)
        {
            byte[] decryptedData;
            using (RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider())
            {
                rSACryptoServiceProvider.ImportParameters(RSAKey);
                decryptedData = rSACryptoServiceProvider.Decrypt(data, fOAEP);
            }
            return decryptedData;
        }
        UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
        RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider();
        byte[] data;
        byte[] encryptData;
        private void button1_Click(object sender, EventArgs e)
        {
            data = unicodeEncoding.GetBytes(textBox1.Text);
            encryptData = Encrypt(data, rSACryptoServiceProvider.ExportParameters(false), false);
            textBox2.Text = unicodeEncoding.GetString(encryptData);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] data = Decrypt(encryptData, rSACryptoServiceProvider.ExportParameters(true), false);
            textBox4.Text = unicodeEncoding.GetString(data);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Form10().Show();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}