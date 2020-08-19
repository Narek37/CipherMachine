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
        int key;
        public MainForm()
        {
            InitializeComponent();
            this.ActiveControl = StartTextBox;
            CopyButton.Enabled = false;
            SelectComboBox.SelectedIndex = 0;
            textBoxKey.MaxLength = 2;
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
            textBoxKey.Visible = false;
            LabelKey.Visible = false;

            if (SelectComboBox.Text == "MD5")
            {
                CipherTextBox.Text = cipher.MD5(StartTextBox.Text);
            }
            else if (SelectComboBox.Text == "SHA1")
            {
                CipherTextBox.Text = cipher.SHA1(StartTextBox.Text);

            }
            else if (SelectComboBox.Text == "Reverse Alphabet Cipher")
            {
                CipherTextBox.Text = cipher.ReverseAlphabet(StartTextBox.Text);
            }
            else if (SelectComboBox.Text == "Caesar Cipher")
            {
                textBoxKey.Visible = true;
                LabelKey.Visible = true;
                int.TryParse(textBoxKey.Text, out key);
                CipherTextBox.Text = cipher.CaesarCipher(StartTextBox.Text, key);
            }
            else if (SelectComboBox.Text == "Caesar Cipher Decoder")
            {
                textBoxKey.Visible = true;
                LabelKey.Visible = true;
                int.TryParse(textBoxKey.Text, out key);
                CipherTextBox.Text = cipher.CaesarCipherDecode(StartTextBox.Text, key);
            }
            else
            {
                CipherTextBox.Text = "";
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
            CipherReturn();
        }

        private void textBoxKey_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBoxKey_KeyPress(object sender, KeyPressEventArgs e)
        {
            //max length = 2///////////////
            char key = e.KeyChar;

            if (!(char.IsNumber(key) || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
            if (textBoxKey.Text.Length != 0)
            {
                if (!(textBoxKey.Text.Equals("1") || textBoxKey.Text.Equals("2") || e.KeyChar == (char)Keys.Back))
                {
                    e.Handled = true;
                }
            }
        }

        private void textBoxKey_TextChanged(object sender, EventArgs e)
        {
            CipherReturn();
            this.ActiveControl = textBoxKey;
        }
    }

    
}
