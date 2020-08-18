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

namespace CipherMachine
{
    public partial class MainForm : Form
    {
        Cipher cipher = new Cipher();
         
        public MainForm()
        {
            InitializeComponent();
            this.ActiveControl = StartTextBox;
            CopyButton.Enabled = false;
            SelectComboBox.SelectedIndex = 0;

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //this.Opacity = 0;
            StartForm startForm = new StartForm();
            startForm.ShowDialog();
        }

        ///////do all dirty work!!!!
        public void CipherReturn()
        {
            switch (SelectComboBox.SelectedIndex)
            {
                case 0:
                    CipherTextBox.Text = cipher.MD5(StartTextBox.Text);
                    break;
                case 1:
                    CipherTextBox.Text = cipher.SHA1(StartTextBox.Text);
                    break;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutProgramForm aboutPr = new AboutProgramForm();
            aboutPr.ShowDialog();
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        /////////Nice exit
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(this.Opacity > 0)
            {
                this.Opacity -= 0.1;
            }
            else
            {
                Hide();
                Close();
            }
        }

        private void StartTextBox_TextChanged(object sender, EventArgs e)
        {
            CipherReturn();
            CopyedLabel.Text = "";
            if ((StartTextBox.Text.Length != 0) && (CipherTextBox.Text.Length != 0))
            {
                CopyButton.Enabled = true;
            }
            else
            {
                CopyButton.Enabled = false;
            }
        }

        private void CopyButton_Click(object sender, EventArgs e)
        {
                Clipboard.SetText(CipherTextBox.Text);
                CopyedLabel.Text = "Copied!";
                CopyButton.Enabled = false;
                this.ActiveControl = StartTextBox;

        }

        private void SelectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

    class Cipher
    {
        const string alphabet = "abcdefghijklmnopqrstuvwxyz";
        const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string revalphabet = "zyxwvutsrqponmlkjihgfedcba";
        const string RevAlphabet = "ZYXWVUTSRQPONMLKJIHGFEDCBA";

        //////returns SHA1 hash
        public string SHA1(string text)
        {
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            sha1.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] result = sha1.Hash;
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                str.Append(result[i].ToString("x2"));
            }

            return str.ToString();
        }

        ///////returns MD5 hash
        public string MD5(string text)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] result = md5.Hash;
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                str.Append(result[i].ToString("x2"));
            }

            return str.ToString();
        }

        ////Caesar cipher///Method gets text and key then returns cipher////////////
        public string CaesarCipher(string text, int key)
        {
            char[] cipher = text.ToCharArray();

            for (int i = 0; i < cipher.Length; i++)
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (cipher[i] == alphabet[j])
                    {
                        if (j + key > alphabet.Length - 1)
                        {
                            cipher[i] = alphabet[j + key - alphabet.Length];
                            break;
                        }
                        else
                        {
                            cipher[i] = alphabet[j + key];
                            break;
                        }
                    }
                    else

                    if (cipher[i] == Alphabet[j])
                    {
                        if (j + key > Alphabet.Length - 1)
                        {
                            cipher[i] = Alphabet[j + key - Alphabet.Length];
                            break;
                        }
                        else
                        {
                            cipher[i] = Alphabet[j + key];
                            break;
                        }
                    }

                }
            }

            text = new string(cipher);
            return text;
        }

        ////Caesar cipher decoder///Method gets cipher and key then returns text////////////
        public string CaesarCipherDecode(string text, int key)
        {
            char[] cipher = text.ToCharArray();

            for (int i = 0; i < cipher.Length; i++)
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (cipher[i] == alphabet[j])
                    {
                        if (j - key < 0)
                        {
                            cipher[i] = alphabet[alphabet.Length - key + j];
                            break;
                        }
                        else
                        {
                            cipher[i] = alphabet[j - key];
                            break;
                        }
                    }
                    else if (cipher[i] == Alphabet[j])
                    {
                        if (j - key < 0)
                        {
                            cipher[i] = Alphabet[Alphabet.Length - key + j];
                            break;
                        }
                        else
                        {
                            cipher[i] = Alphabet[j - key];
                            break;
                        }
                    }




                }
            }

            text = new string(cipher);
            return text;
        }

        //////Reverse alphabet/////////////////////////////////
        public string ReverseAlphabet(string text)
        {
            char[] cipher = text.ToCharArray();


            for (int i = 0; i < cipher.Length; i++)
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (cipher[i] == alphabet[j])
                    {
                        cipher[i] = revalphabet[j];
                        break;
                    }
                    else
                        if (cipher[i] == Alphabet[j])
                    {
                        cipher[i] = RevAlphabet[j];
                        break;
                    }
                }
            }


            text = new string(cipher);
            return text;
        }


    }
}
