using lab2.Classes;
using System.Numerics;

namespace lab2
{
    public partial class MainForm : Form
    {
        public MainForm()
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
            dbContext.ReadAll();

            foreach (Player player in dbContext.Players)
            {
                string pgInfo = string.Empty;
                string cInfo = string.Empty;
                string playerInfo = string.Empty;

                if (player.getType() == Type.PointGuard)
                {
                    pgInfo = string.Format("apg: {0}, tpp: {1}", player.getPointGuard()?.getAssistsPerGame(), player.getPointGuard()?.getThreePointPercentage());

                    playerInfo = pgInfo;
                }
                else if (player.getType() == Type.Center)
                {
                    cInfo = string.Format("blocks: {0}, rebounds: {1}, bpg: {2}, rpg: {3}", player.getCenter()?.getBlocks(), player.getCenter()?.getRebounds(), player.getCenter()?.getBlocksPerGame(), player.getCenter()?.getReboundsPerGame());

                    playerInfo = cInfo;
                }

                dataGridView1.Rows.Add(
                    player.getID(),
                    player.getName(),
                    player.getHeight(),
                    player.getJerseyNumber(),
                    player.getType(),
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
            PlayerCreateForm createPlayerForm = new PlayerCreateForm();
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
            Database dbContext = new Database();
            Player playerToEdit = dbContext.ReadOne(playerID);
            PlayerEditForm playerEditForm = new PlayerEditForm(playerToEdit, playerID);
            playerEditForm.ShowDialog();
            LoadDataGridView();
        }

        private void PlayerMethodsButton_Click(object sender, EventArgs e)
        {
            int row = dataGridView1.SelectedCells[0].RowIndex;
            int playerID = (int)dataGridView1.Rows[row].Cells[0].Value;
            Database dbContext = new Database();
            Player player = dbContext.ReadOne(playerID);
            if (player.getType() == Type.Center)
            {
                PlayerCenterMethodsForm playerCenterMethodsForm = new PlayerCenterMethodsForm(player);
                playerCenterMethodsForm.ShowDialog();
            } else if (player.getType() == Type.PointGuard)
            {
                PlayerPointGuardMethodsForm playerPointGuardsMethodsForm = new PlayerPointGuardMethodsForm(player);
                playerPointGuardsMethodsForm.ShowDialog();
            }
            LoadDataGridView();
        }
    }
}
