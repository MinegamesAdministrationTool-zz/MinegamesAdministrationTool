using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace MinegamesAdministrationTool
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        string hash = "zH/6]V]Ezb}xvDzLxY9iuom]rTxgHV:S]~pCxVDfIA5C/EkDofBLpZ*gxYIwQm/ODUUeU0pe^WJ(rYIZaoXP2CNL8/gXhEOOM#u";

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(textBox1.Text);
            using (MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = MD5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    textBox2.Text = Convert.ToBase64String(results, 0, results.Length);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] data = Convert.FromBase64String(textBox4.Text);
            using (MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = MD5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    textBox3.Text = UTF8Encoding.UTF8.GetString(results);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("it's simple: to encrypt text please put your text in (To Encrypt) textbox and you will find your encrypted text in (Encrypted) textbox same for decryption.", "Guide", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }
    }
}
