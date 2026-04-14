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
    public partial class PlayerPointGuardMethodsForm : Form
    {
        public Player player;
        public PlayerPointGuardMethodsForm(Player player)
        {
            InitializeComponent();
            this.player = player;
        }

        private void PlayerPointGuardMethodsForm_Load(object sender, EventArgs e)
        {

        }

        private void PlayMethodButton_Click(object sender, EventArgs e)
        {
            console.AppendText(player.getPointGuard()?.play() + Environment.NewLine);
            console.ScrollToCaret();
        }

        private void TrainMethodButton_Click(object sender, EventArgs e)
        {
            console.AppendText(player.getPointGuard()?.train() + Environment.NewLine);
            console.ScrollToCaret();
        }

        private void PrintInfoMethodButton_Click(object sender, EventArgs e)
        {
            console.AppendText(player.getPointGuard()?.printInfo() + Environment.NewLine);
            console.ScrollToCaret();
        }

        private void DribbleMethodButton_Click(object sender, EventArgs e)
        {
            console.AppendText(player.getPointGuard()?.dribble() + Environment.NewLine);
            console.ScrollToCaret();
        }

        private void PassMethodButton_Click(object sender, EventArgs e)
        {
            console.AppendText(player.getPointGuard()?.pass() + Environment.NewLine);
            console.ScrollToCaret();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            console.Text = string.Empty;
        }
    }
}
