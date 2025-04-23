using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace connect4UI
{
    public partial class Title : Form
    {
        public Title()
        {
            InitializeComponent();
            PvPStartBtn.Tag = 0; //human v human
            EasyAiStartBtn.Tag = 1; // human v easy ai
            HardAiStartBtn.Tag = 2; // human v hard ai

        }


        // Tick event handler
        private void Timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop(); //If timer is not stopped, timer1_Tick event will be called for every 10 seconds
            lblCredits.Visible = false;
        }


        private void RulesBtn_Click(object sender, EventArgs e)
        {
            Rules form3 = new Rules();
            form3.ShowDialog();
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton?.Tag is int gameMode)
            {
                Connect4PvP form2 = new Connect4PvP(gameMode);
                form2.Show();
                this.Hide(); // Hide the current form
            }
            else
            {
                MessageBox.Show("Unknown game mode selected!");
            }

        }

        private void CreditsBtn_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1500;
            timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            lblCredits.Visible = true;
            timer1.Start();
        }

        
        private void LblCredits(object sender, EventArgs e)
        {
         
        }

        private void lblLoadingGame_Click(object sender, EventArgs e)
        {

        }

        private void Form2(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblCredits_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
