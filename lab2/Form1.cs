using lab2.Classes;
using System.Numerics;

namespace lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        public void LoadDataGridView()
        {

            dataGridView1.Rows.Clear();
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            Database dbContext = new Database();
            dbContext.Read();

            foreach (Player player in dbContext.Players)
            {
                string pgInfo = string.Empty;
                string cInfo = string.Empty;
                string playerInfo = string.Empty;

                if (player.Type == "PointGuard")
                {
                    pgInfo = string.Format("apg: {0}, tpp: {1}", player.PointGuard.assistsPerGame, player.PointGuard.threePointPercentage);

                    playerInfo = pgInfo;
                }
                else if (player.Center != null)
                {
                    cInfo = string.Format("blocks: {0}, rebounds: {1}, bpg: {2}, rpg: {3}", player.Center.blocks, player.Center.rebounds, player.Center.blocksPerGame, player.Center.reboundsPerGame);

                    playerInfo = cInfo;
                }

                dataGridView1.Rows.Add(
                    player.ID,
                    player.Name,
                    player.Height,
                    player.JerseyNumber,
                    player.Type,
                    playerInfo
                );
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void AddPlayerButton_click(object sender, EventArgs e)
        {
            Form2 createPlayerForm = new Form2();
            createPlayerForm.ShowDialog();
            LoadDataGridView();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            int row = dataGridView1.SelectedCells[0].RowIndex;
            int playerID = (int)dataGridView1.Rows[row].Cells[0].Value;
            Database dbContext = new Database();

            var res = MessageBox.Show($"Delete player with id {playerID}?", "Delete", MessageBoxButtons.OKCancel);
            if (res == DialogResult.OK)
            {
                dbContext.Delete(playerID);
                LoadDataGridView();
                MessageBox.Show("Player deleted successfully!");
                return;
            }
            //LoadDataGridView();
        }

        private void PlayerEditButton_Click(object sender, EventArgs e)
        {
            int row = dataGridView1.SelectedCells[0].RowIndex;
            int playerID = (int)dataGridView1.Rows[row].Cells[0].Value;
        }
    }
}
