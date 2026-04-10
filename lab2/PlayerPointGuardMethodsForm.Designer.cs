namespace lab2
{
    partial class PlayerPointGuardMethodsForm
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
            console = new RichTextBox();
            PassMethodButton = new Button();
            DribbleMethodButton = new Button();
            PrintInfoMethodButton = new Button();
            TrainMethodButton = new Button();
            PlayMethodButton = new Button();
            ClearButton = new Button();
            SuspendLayout();
            // 
            // console
            // 
            console.BackColor = Color.Black;
            console.Font = new Font("Consolas", 10F);
            console.ForeColor = Color.LightGreen;
            console.Location = new Point(234, 12);
            console.Name = "console";
            console.ReadOnly = true;
            console.Size = new Size(540, 286);
            console.TabIndex = 15;
            console.Text = "";
            // 
            // PassMethodButton
            // 
            PassMethodButton.Location = new Point(13, 187);
            PassMethodButton.Name = "PassMethodButton";
            PassMethodButton.Size = new Size(95, 33);
            PassMethodButton.TabIndex = 12;
            PassMethodButton.Text = "Pass";
            PassMethodButton.UseVisualStyleBackColor = true;
            PassMethodButton.Click += PassMethodButton_Click;
            // 
            // DribbleMethodButton
            // 
            DribbleMethodButton.Location = new Point(13, 148);
            DribbleMethodButton.Name = "DribbleMethodButton";
            DribbleMethodButton.Size = new Size(95, 33);
            DribbleMethodButton.TabIndex = 11;
            DribbleMethodButton.Text = "Dribble";
            DribbleMethodButton.UseVisualStyleBackColor = true;
            DribbleMethodButton.Click += DribbleMethodButton_Click;
            // 
            // PrintInfoMethodButton
            // 
            PrintInfoMethodButton.Location = new Point(13, 90);
            PrintInfoMethodButton.Name = "PrintInfoMethodButton";
            PrintInfoMethodButton.Size = new Size(95, 33);
            PrintInfoMethodButton.TabIndex = 10;
            PrintInfoMethodButton.Text = "PrintInfo";
            PrintInfoMethodButton.UseVisualStyleBackColor = true;
            PrintInfoMethodButton.Click += PrintInfoMethodButton_Click;
            // 
            // TrainMethodButton
            // 
            TrainMethodButton.Location = new Point(13, 51);
            TrainMethodButton.Name = "TrainMethodButton";
            TrainMethodButton.Size = new Size(95, 33);
            TrainMethodButton.TabIndex = 9;
            TrainMethodButton.Text = "Train";
            TrainMethodButton.UseVisualStyleBackColor = true;
            TrainMethodButton.Click += TrainMethodButton_Click;
            // 
            // PlayMethodButton
            // 
            PlayMethodButton.Location = new Point(13, 12);
            PlayMethodButton.Name = "PlayMethodButton";
            PlayMethodButton.Size = new Size(95, 33);
            PlayMethodButton.TabIndex = 8;
            PlayMethodButton.Text = "Play";
            PlayMethodButton.UseVisualStyleBackColor = true;
            PlayMethodButton.Click += PlayMethodButton_Click;
            // 
            // button1
            // 
            ClearButton.Location = new Point(13, 243);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new Size(95, 33);
            ClearButton.TabIndex = 16;
            ClearButton.Text = "Clear";
            ClearButton.UseVisualStyleBackColor = true;
            ClearButton.Click += ClearButton_Click;
            // 
            // PlayerPointGuardMethodsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(802, 324);
            Controls.Add(ClearButton);
            Controls.Add(console);
            Controls.Add(DribbleMethodButton);
            Controls.Add(PassMethodButton);
            Controls.Add(PrintInfoMethodButton);
            Controls.Add(TrainMethodButton);
            Controls.Add(PlayMethodButton);
            Name = "PlayerPointGuardMethodsForm";
            Text = "PlayerPointGuardMethodsForm";
            Load += PlayerPointGuardMethodsForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox console;
        private Button DribbleMethodButton;
        private Button PassMethodButton;
        private Button PrintInfoMethodButton;
        private Button TrainMethodButton;
        private Button PlayMethodButton;
        private Button ClearButton;
    }
}