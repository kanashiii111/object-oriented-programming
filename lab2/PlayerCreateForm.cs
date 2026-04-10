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
                newPlayer = new Player(0, name, height, jerseyNumber, Type.PointGuard);
                foreach (Player player in dbContext.Players)
                {
                    if (newPlayer.Equals(player))
                    {
                        MessageBox.Show("Player already exists.");
                        return;
                    }
                }
                PointGuard newPG = new PointGuard(0, name, height, jerseyNumber, Type.PointGuard, 0.0, 0.0);
                newPlayer.PointGuard = newPG;
            } else
            {
                newPlayer = new Player(0, name, height, jerseyNumber, Type.Center);
                foreach (Player player in dbContext.Players)
                {
                    if (newPlayer.Equals(player))
                    {
                        MessageBox.Show("Player already exists.");
                        return;
                    }
                }
                Center newC = new Center(0, name, height, jerseyNumber, Type.Center, 0, 0, 0.0, 0.0);
                newPlayer.Center = newC;
            }
            dbContext.Add(newPlayer);

            MessageBox.Show("Player added successfully!");
            this.Close();
        }
    }
}
