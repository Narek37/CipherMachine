using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CipherMachine
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void StartForm_Load(object sender, EventArgs e)
        {
            try
            {
                SoundPlayer player = new SoundPlayer("..//..//..//source//sound.wav");
                player.Play();
            }
            catch 
            {

            };
            
            CloseTimer.Start();
        }



        int i = 10; //for wait 1 second with 100% opacity
        private void CloseTimer_Tick(object sender, EventArgs e)
        {
            if (i < 0)
            {
                this.Opacity -= 0.1;
                if (this.Opacity == 0)
                {
                    Hide();
                    Close();
                    MainForm mainf = new MainForm();
                    mainf.Opacity = 1;
                }
            }
            else
            {
                i--;
            }
        }
    }
}
