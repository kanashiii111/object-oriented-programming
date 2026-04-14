using lab2.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2
{
    public partial class PlayerCenterMethodsForm : Form
    {
        public Player player;
        public PlayerCenterMethodsForm(Player player)
        {
            InitializeComponent();
            this.player = player;
        }

        private void PlayerCenterMethodsForm_Load(object sender, EventArgs e)
        {

        }

        private void PlayMethodButton_Click(object sender, EventArgs e)
        {
            console.AppendText(player.getCenter()?.play() + Environment.NewLine);
            console.ScrollToCaret();
        }

        private void TrainMethodButton_Click(object sender, EventArgs e)
        {
            console.AppendText(player.getCenter()?.train() + Environment.NewLine);
            console.ScrollToCaret();
        }

        private void PrintInfoMethodButton_Click(object sender, EventArgs e)
        {
            console.AppendText(player.getCenter()?.printInfo() + Environment.NewLine);
            console.ScrollToCaret();
        }

        private void BlockMethodButton_Click(object sender, EventArgs e)
        {
            console.AppendText(player.getCenter()?.block() + Environment.NewLine);
            console.ScrollToCaret();
            Database dbContext = new Database();
            dbContext.Update(player);
        }

        private void ReboundMethodButton_Click(object sender, EventArgs e)
        {
            console.AppendText(player.getCenter()?.rebound() + Environment.NewLine);
            console.ScrollToCaret();
            Database dbContext = new Database();
            dbContext.Update(player);
        }

        private void SetScreenMethodButton_Click(object sender, EventArgs e)
        {
            console.AppendText(player.getCenter()?.setScreen() + Environment.NewLine);
            console.ScrollToCaret();
        }

        private void PostMethodButton_Click(object sender, EventArgs e)
        {
            console.AppendText(player.getCenter()?.post() + Environment.NewLine);
            console.ScrollToCaret();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            console.Text = string.Empty;
        }
    }
}
