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
        }

        private void EditPlayerButton_Click(object sender, EventArgs e)
        {
            string newName = textBox1.Text;
            int newHeight, newJerseyNumber;

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

            if (playerToEdit.getName() == newName && playerToEdit.getHeight() == newHeight && playerToEdit.getJerseyNumber() == newJerseyNumber)
            {
                MessageBox.Show("No changes were made");
                Close();
                return;
            }

            Database dbContext = new Database();
            dbContext.Edit(playerIDToEdit, newName, newHeight, newJerseyNumber);
            MessageBox.Show("Player edited successfully!");
            Close();
        }
    }
}
