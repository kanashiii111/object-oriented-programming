using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using lab2.Classes;

namespace lab2
{
    public partial class PlayerCreateForm : Form
    {
        public PlayerCreateForm()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
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
        }

        private void CreatePlayerButton_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            int height, jerseyNumber;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Введите имя.");
                return;
            }

            if (!int.TryParse(textBox2.Text, out height))
            {
                MessageBox.Show("Рост должен быть целым числом", "Ошибка");
                textBox2.Focus();
                return;
            }

            if (!int.TryParse(textBox3.Text, out jerseyNumber))
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

            Player? newPlayer = null;
            Database dbContext = new Database();
            dbContext.ReadAll();

            if (comboBox1.SelectedIndex == 0)
            {
                double assists, steals;

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

                newPlayer = new Player(0, name, height, jerseyNumber, Type.PointGuard);

                foreach (Player player in dbContext.Players)
                {
                    if (newPlayer.Equals(player))
                    {
                        MessageBox.Show("Player already exists.");
                        return;
                    }
                }
                PointGuard newPG = new PointGuard(0, name, height, jerseyNumber, Type.PointGuard, assists, steals);
                newPlayer.setPointGuard(newPG);
            }
            else
            {
                int rebounds = 0, blocks = 0;
                double bpg = 0.0f, rpg = 0.0f;
                bool hasRebounds = false, hasBlocks = false, hasBPG = false, hasRPG = false;

                if (!string.IsNullOrWhiteSpace(textBox4.Text))
                {
                    if (!int.TryParse(textBox4.Text, out blocks))
                    {
                        MessageBox.Show("Количество блоков должно быть целым числом", "Ошибка");
                        textBox4.Focus();
                        return;
                    }
                    hasBlocks = true;
                }

                if (!string.IsNullOrWhiteSpace(textBox5.Text))
                {
                    if (!int.TryParse(textBox5.Text, out rebounds))
                    {
                        MessageBox.Show("Количество подборов должно быть целым числом", "Ошибка");
                        textBox5.Focus();
                        return;
                    }
                    hasRebounds = true;
                }

                if (!string.IsNullOrWhiteSpace(textBox6.Text))
                {
                    if (!double.TryParse(textBox6.Text, out bpg))
                    {
                        MessageBox.Show("Блоки за игру должны быть числом", "Ошибка");
                        textBox6.Focus();
                        return;
                    }
                    hasBPG = true;
                }

                if (!string.IsNullOrWhiteSpace(textBox7.Text))
                {
                    if (!double.TryParse(textBox7.Text, out rpg))
                    {
                        MessageBox.Show("Подборы за игру должны быть числом", "Ошибка");
                        textBox7.Focus();
                        return;
                    }
                    hasRPG = true;
                }

                newPlayer = new Player(0, name, height, jerseyNumber, Type.Center);
                foreach (Player player in dbContext.Players)
                {
                    if (newPlayer.Equals(player))
                    {
                        MessageBox.Show("Player already exists.");
                        return;
                    }
                }

                Center newC = null;

                if (hasBlocks && hasRebounds && hasBPG && hasRPG)
                {
                    newC = new Center(0, name, height, jerseyNumber, Type.Center, blocks, rebounds, bpg, rpg);
                }
                else if (hasBlocks && hasBPG && hasRPG)
                {
                    newC = new Center(0, name, height, jerseyNumber, Type.Center, blocks, bpg, rpg);
                }
                else if (hasBPG && hasRPG)
                {
                    newC = new Center(0, name, height, jerseyNumber, Type.Center, bpg, rpg);

                } else {
                    MessageBox.Show("Для центра необходимо заполнить как минимум блоки за игру и подборы за игру (BPG и RPG)");
                    return;
                }

                newPlayer.setCenter(newC);
            }
            dbContext.Add(newPlayer);

            MessageBox.Show("Player added successfully!");
            this.Close();
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
