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
using System.Xml.Linq;

namespace lab2
{
    public partial class PlayerEditForm : Form
    {
        public Player playerToEdit;
        public int playerIDToEdit;
        public PlayerEditForm(Player player, int playerID)
        {
            InitializeComponent();
            playerToEdit = player;
            playerIDToEdit = playerID;
        }

        private void PlayerEditForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = playerToEdit.getName();
            textBox2.Text = playerToEdit.getHeight().ToString();
            textBox3.Text = playerToEdit.getJerseyNumber().ToString();
            if (playerToEdit.getType() == Type.PointGuard) {
                comboBox1.SelectedIndex = 0;
                textBox8.Text = playerToEdit.getPointGuard()?.getAssistsPerGame().ToString();
                textBox9.Text = playerToEdit.getPointGuard()?.getThreePointPercentage().ToString();
            } else
            {
                comboBox1.SelectedIndex = 1;
                textBox4.Text = playerToEdit.getCenter()?.getBlocks().ToString();
                textBox5.Text = playerToEdit.getCenter()?.getRebounds().ToString();
                textBox6.Text = playerToEdit.getCenter()?.getBlocksPerGame().ToString();
                textBox7.Text = playerToEdit.getCenter()?.getReboundsPerGame().ToString();
            }
        }

        private void EditPlayerButton_Click(object sender, EventArgs e)
        {
            string newName = textBox1.Text;
            int newHeight, newJerseyNumber;
            double assists = 0.0f, steals = 0.0f;
            int rebounds = 0, blocks = 0;
            double bpg = 0.0f, rpg = 0.0f;
            Center? center = null;
            PointGuard? pg = null;

            if (string.IsNullOrWhiteSpace(newName))
            {
                MessageBox.Show("Введите имя.");
                return;
            }

            if (!int.TryParse(textBox2.Text, out newHeight))
            {
                MessageBox.Show("Рост должен быть целым числом", "Ошибка");
                textBox2.Focus();
                return;
            }

            if (!int.TryParse(textBox3.Text, out newJerseyNumber))
            {
                MessageBox.Show("Номер майки должен быть целым числом", "Ошибка");
                textBox3.Focus();
                return;
            }

            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите тип игрока", "Ошибка");
                comboBox1.Focus();
                return;
            }

            Type newType = comboBox1.SelectedItem.ToString() == "PointGuard" ? Type.PointGuard : Type.Center;

            MessageBox.Show(newType.ToString());

            if (comboBox1.SelectedIndex == 0)
            {
                if (!double.TryParse(textBox8.Text, out assists))
                {
                    MessageBox.Show("Количество передач должно быть числом", "Ошибка");
                    textBox8.Focus();
                    return;
                }

                if (!double.TryParse(textBox9.Text, out steals))
                {
                    MessageBox.Show("Количество перехватов должно быть числом", "Ошибка");
                    textBox9.Focus();
                    return;
                }

            } else
            {

                if (!int.TryParse(textBox4.Text, out blocks))
                {
                    MessageBox.Show("Количество блоков должно быть целым числом", "Ошибка");
                    textBox4.Focus();
                    return;
                }

                if (!int.TryParse(textBox5.Text, out rebounds))
                {
                    MessageBox.Show("Количество подборов должно быть целым числом", "Ошибка");
                    textBox5.Focus();
                    return;
                }

                if (!double.TryParse(textBox6.Text, out bpg))
                {
                    MessageBox.Show("Блоки за игру должны быть числом", "Ошибка");
                    textBox6.Focus();
                    return;
                }

                if (!double.TryParse(textBox7.Text, out rpg))
                {
                    MessageBox.Show("Подборы за игру должны быть числом", "Ошибка");
                    textBox7.Focus();
                    return;
                }
            }

            //if (playerToEdit.getName() == newName && playerToEdit.getHeight() == newHeight && playerToEdit.getJerseyNumber() == newJerseyNumber)
            //{
            //    MessageBox.Show("No changes were made");
            //    Close();
            //    return;
            //}

            //Database dbContext = new Database();
            //dbContext.ReadAll();
            //foreach (Player playerdb in dbContext.Players)
            //{
            //    if (playerdb.Equals(new Player(0, newName, newHeight, newJerseyNumber, playerToEdit.getType())))
            //    {
            //        MessageBox.Show("Player already exists.");
            //        textBox1.Text = playerToEdit.getName();
            //        textBox2.Text = playerToEdit.getHeight().ToString();
            //        textBox3.Text = playerToEdit.getJerseyNumber().ToString();
            //        return;
            //    }
            //}

            Player player = new Player(playerIDToEdit, newName, newHeight, newJerseyNumber, newType);
            if (newType == Type.Center) {
                center = new Center(playerIDToEdit, newName, newHeight, newJerseyNumber, newType, blocks, rebounds, bpg, rpg);
                player.setCenter(center);
            } else if (newType == Type.PointGuard)
            {
                pg = new PointGuard(playerIDToEdit, newName, newHeight, newJerseyNumber, newType, assists, steals);
                player.setPointGuard(pg);
            }

            Database dbContext = new Database();
            var res = MessageBox.Show($"Edit player with id {playerIDToEdit}?", "Edit", MessageBoxButtons.OKCancel);
            if (res == DialogResult.OK)
            {
                dbContext.Update(player);
                MessageBox.Show("Player edited successfully!");
                Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // First, hide all position-specific fields
            label5.Visible = false;
            textBox4.Enabled = false;
            label6.Visible = false;
            textBox5.Enabled = false;
            label7.Visible = false;
            textBox6.Enabled = false;
            label8.Visible = false;
            textBox7.Enabled = false;
            label9.Visible = false;
            textBox8.Enabled = false;
            label10.Visible = false;
            textBox9.Enabled = false;

            // Then show only the fields for the selected position
            if (comboBox1.SelectedIndex == 0) // PointGuard
            {
                label9.Visible = true;
                textBox8.Enabled = true;
                label10.Visible = true;
                textBox9.Enabled = true;
            }
            else if (comboBox1.SelectedIndex == 1) // Center
            {
                label5.Visible = true;
                textBox4.Enabled = true;
                label6.Visible = true;
                textBox5.Enabled = true;
                label7.Visible = true;
                textBox6.Enabled = true;
                label8.Visible = true;
                textBox7.Enabled = true;
            }
        }
    }
}
