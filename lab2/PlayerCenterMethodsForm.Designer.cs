namespace lab2
{
    partial class PlayerCenterMethodsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            PlayMethodButton = new Button();
            TrainMethodButton = new Button();
            PrintInfoMethodButton = new Button();
            BlockMethodButton = new Button();
            ReboundMethodButton = new Button();
            SetScreenMethodButton = new Button();
            PostMethodButton = new Button();
            console = new RichTextBox();
            ClearButton = new Button();
            SuspendLayout();
            // 
            // PlayMethodButton
            // 
            PlayMethodButton.Location = new Point(12, 12);
            PlayMethodButton.Name = "PlayMethodButton";
            PlayMethodButton.Size = new Size(95, 33);
            PlayMethodButton.TabIndex = 0;
            PlayMethodButton.Text = "Play";
            PlayMethodButton.UseVisualStyleBackColor = true;
            PlayMethodButton.Click += PlayMethodButton_Click;
            // 
            // TrainMethodButton
            // 
            TrainMethodButton.Location = new Point(12, 51);
            TrainMethodButton.Name = "TrainMethodButton";
            TrainMethodButton.Size = new Size(95, 33);
            TrainMethodButton.TabIndex = 1;
            TrainMethodButton.Text = "Train";
            TrainMethodButton.UseVisualStyleBackColor = true;
            TrainMethodButton.Click += TrainMethodButton_Click;
            // 
            // PrintInfoMethodButton
            // 
            PrintInfoMethodButton.Location = new Point(12, 90);
            PrintInfoMethodButton.Name = "PrintInfoMethodButton";
            PrintInfoMethodButton.Size = new Size(95, 33);
            PrintInfoMethodButton.TabIndex = 2;
            PrintInfoMethodButton.Text = "PrintInfo";
            PrintInfoMethodButton.UseVisualStyleBackColor = true;
            PrintInfoMethodButton.Click += PrintInfoMethodButton_Click;
            // 
            // BlockMethodButton
            // 
            BlockMethodButton.Location = new Point(12, 148);
            BlockMethodButton.Name = "BlockMethodButton";
            BlockMethodButton.Size = new Size(95, 33);
            BlockMethodButton.TabIndex = 3;
            BlockMethodButton.Text = "Block";
            BlockMethodButton.UseVisualStyleBackColor = true;
            BlockMethodButton.Click += BlockMethodButton_Click;
            // 
            // ReboundMethodButton
            // 
            ReboundMethodButton.Location = new Point(12, 187);
            ReboundMethodButton.Name = "ReboundMethodButton";
            ReboundMethodButton.Size = new Size(95, 33);
            ReboundMethodButton.TabIndex = 4;
            ReboundMethodButton.Text = "Rebound";
            ReboundMethodButton.UseVisualStyleBackColor = true;
            ReboundMethodButton.Click += ReboundMethodButton_Click;
            // 
            // SetScreenMethodButton
            // 
            SetScreenMethodButton.Location = new Point(12, 226);
            SetScreenMethodButton.Name = "SetScreenMethodButton";
            SetScreenMethodButton.Size = new Size(95, 33);
            SetScreenMethodButton.TabIndex = 5;
            SetScreenMethodButton.Text = "setScreen";
            SetScreenMethodButton.UseVisualStyleBackColor = true;
            SetScreenMethodButton.Click += SetScreenMethodButton_Click;
            // 
            // PostMethodButton
            // 
            PostMethodButton.Location = new Point(12, 265);
            PostMethodButton.Name = "PostMethodButton";
            PostMethodButton.Size = new Size(95, 33);
            PostMethodButton.TabIndex = 6;
            PostMethodButton.Text = "Post";
            PostMethodButton.UseVisualStyleBackColor = true;
            PostMethodButton.Click += PostMethodButton_Click;
            // 
            // console
            // 
            console.BackColor = Color.Black;
            console.Font = new Font("Consolas", 10F);
            console.ForeColor = Color.LightGreen;
            console.Location = new Point(233, 12);
            console.Name = "console";
            console.ReadOnly = true;
            console.Size = new Size(540, 342);
            console.TabIndex = 7;
            console.Text = "";
            // 
            // ClearButton
            // 
            ClearButton.Location = new Point(12, 321);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new Size(95, 33);
            ClearButton.TabIndex = 8;
            ClearButton.Text = "Clear";
            ClearButton.UseVisualStyleBackColor = true;
            ClearButton.Click += ClearButton_Click;
            // 
            // PlayerCenterMethodsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 378);
            Controls.Add(ClearButton);
            Controls.Add(console);
            Controls.Add(PostMethodButton);
            Controls.Add(SetScreenMethodButton);
            Controls.Add(ReboundMethodButton);
            Controls.Add(BlockMethodButton);
            Controls.Add(PrintInfoMethodButton);
            Controls.Add(TrainMethodButton);
            Controls.Add(PlayMethodButton);
            Name = "PlayerCenterMethodsForm";
            Text = "Player methods";
            Load += PlayerCenterMethodsForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button PlayMethodButton;
        private Button TrainMethodButton;
        private Button PrintInfoMethodButton;
        private Button BlockMethodButton;
        private Button ReboundMethodButton;
        private Button SetScreenMethodButton;
        private Button PostMethodButton;
        private RichTextBox console;
        private Button ClearButton;
    }
}