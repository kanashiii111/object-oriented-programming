namespace lab2
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            PlayerID = new DataGridViewTextBoxColumn();
            PlayerName = new DataGridViewTextBoxColumn();
            PlayerHeight = new DataGridViewTextBoxColumn();
            PlayerJerseyNumber = new DataGridViewTextBoxColumn();
            PlayerType = new DataGridViewTextBoxColumn();
            PlayerInfo = new DataGridViewTextBoxColumn();
            AddPlayerButton = new Button();
            DeleteButton = new Button();
            PlayerEditButton = new Button();
            PlayerMethodsButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { PlayerID, PlayerName, PlayerHeight, PlayerJerseyNumber, PlayerType, PlayerInfo });
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(853, 255);
            dataGridView1.TabIndex = 0;
            // 
            // PlayerID
            // 
            PlayerID.HeaderText = "ID";
            PlayerID.MinimumWidth = 6;
            PlayerID.Name = "PlayerID";
            PlayerID.Width = 125;
            // 
            // PlayerName
            // 
            PlayerName.HeaderText = "Name";
            PlayerName.MinimumWidth = 6;
            PlayerName.Name = "PlayerName";
            PlayerName.Width = 125;
            // 
            // PlayerHeight
            // 
            PlayerHeight.HeaderText = "Height";
            PlayerHeight.MinimumWidth = 6;
            PlayerHeight.Name = "PlayerHeight";
            PlayerHeight.Width = 125;
            // 
            // PlayerJerseyNumber
            // 
            PlayerJerseyNumber.HeaderText = "Jersey Number";
            PlayerJerseyNumber.MinimumWidth = 6;
            PlayerJerseyNumber.Name = "PlayerJerseyNumber";
            PlayerJerseyNumber.Width = 125;
            // 
            // PlayerType
            // 
            PlayerType.HeaderText = "Type";
            PlayerType.Name = "PlayerType";
            // 
            // PlayerInfo
            // 
            PlayerInfo.HeaderText = "Info";
            PlayerInfo.Name = "PlayerInfo";
            PlayerInfo.Width = 200;
            // 
            // AddPlayerButton
            // 
            AddPlayerButton.Location = new Point(12, 332);
            AddPlayerButton.Name = "AddPlayerButton";
            AddPlayerButton.Size = new Size(109, 29);
            AddPlayerButton.TabIndex = 1;
            AddPlayerButton.Text = "Add Player";
            AddPlayerButton.UseVisualStyleBackColor = true;
            AddPlayerButton.Click += AddPlayerButton_click;
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(12, 399);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(109, 29);
            DeleteButton.TabIndex = 8;
            DeleteButton.Text = "Delete Player";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // PlayerEditButton
            // 
            PlayerEditButton.Location = new Point(12, 367);
            PlayerEditButton.Name = "PlayerEditButton";
            PlayerEditButton.Size = new Size(109, 26);
            PlayerEditButton.TabIndex = 9;
            PlayerEditButton.Text = "Edit Player";
            PlayerEditButton.UseVisualStyleBackColor = true;
            PlayerEditButton.Click += PlayerEditButton_Click;
            // 
            // PlayerMethodsButton
            // 
            PlayerMethodsButton.Location = new Point(12, 434);
            PlayerMethodsButton.Name = "PlayerMethodsButton";
            PlayerMethodsButton.Size = new Size(109, 27);
            PlayerMethodsButton.TabIndex = 10;
            PlayerMethodsButton.Text = "Player methods";
            PlayerMethodsButton.UseVisualStyleBackColor = true;
            PlayerMethodsButton.Click += PlayerMethodsButton_Click;
            // 
            // Form1
            // 
            ClientSize = new Size(1655, 776);
            Controls.Add(PlayerMethodsButton);
            Controls.Add(PlayerEditButton);
            Controls.Add(DeleteButton);
            Controls.Add(AddPlayerButton);
            Controls.Add(dataGridView1);
            Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private DataGridView dataGridView1;
        private Button AddPlayerButton;
        private Button DeleteButton;
        private DataGridViewTextBoxColumn PlayerID;
        private DataGridViewTextBoxColumn PlayerName;
        private DataGridViewTextBoxColumn PlayerHeight;
        private DataGridViewTextBoxColumn PlayerJerseyNumber;
        private DataGridViewTextBoxColumn PlayerType;
        private DataGridViewTextBoxColumn PlayerInfo;
        private Button PlayerEditButton;
        private Button PlayerMethodsButton;
    }
}
