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
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace MinegamesAdministrationTool
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        string hash = "zH/6]V]Ezb}xvDzLxY9iuom]rTxgHV:S]~pCxVDfIA5C/EkDofBLpZ*gxYIwQm/ODUUeU0pe^WJ(rYIZaoXP2CNL8/gXhEOOM#u";

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Well yes there is......this method here will make the text more encrypted (This method includes CBC Cipher and SHA256 hash and AES-256 encryption so it's more safe, the other text encryptor was using triple DES and MD5 hash and ECB Cipher which is not enough protection.) but sadly we (and i mean with we me) can't provide a decryptor right now.", "More Safer", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(textBox1.Text);
            using (SHA256CryptoServiceProvider SHA256 = new SHA256CryptoServiceProvider())
            {
                byte[] keys = SHA256.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (AesCryptoServiceProvider AES = new AesCryptoServiceProvider() { KeySize = 256, BlockSize = 128, Key = keys, Mode = CipherMode.CBC, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = AES.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    textBox2.Text = Convert.ToBase64String(results, 0, results.Length);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Form10().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Form11().Show();
        }
    }
}
