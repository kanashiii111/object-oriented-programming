namespace lab2
{
    partial class PlayerEditForm
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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            EditPlayerButton = new Button();
            comboBox1 = new ComboBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            textBox7 = new TextBox();
            textBox6 = new TextBox();
            textBox5 = new TextBox();
            label5 = new Label();
            textBox4 = new TextBox();
            label10 = new Label();
            label9 = new Label();
            textBox9 = new TextBox();
            textBox8 = new TextBox();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(171, 37);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(171, 94);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(171, 152);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(171, 19);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 3;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(171, 76);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 4;
            label2.Text = "Height";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(171, 134);
            label3.Name = "label3";
            label3.Size = new Size(85, 15);
            label3.TabIndex = 5;
            label3.Text = "Jersey Number";
            // 
            // EditPlayerButton
            // 
            EditPlayerButton.Location = new Point(171, 234);
            EditPlayerButton.Name = "EditPlayerButton";
            EditPlayerButton.Size = new Size(100, 28);
            EditPlayerButton.TabIndex = 6;
            EditPlayerButton.Text = "Save";
            EditPlayerButton.UseVisualStyleBackColor = true;
            EditPlayerButton.Click += EditPlayerButton_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "PointGuard", "Center" });
            comboBox1.Location = new Point(171, 193);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(100, 23);
            comboBox1.TabIndex = 7;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(317, 175);
            label8.Name = "label8";
            label8.Size = new Size(105, 15);
            label8.TabIndex = 27;
            label8.Text = "reboundsPerGame";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(317, 134);
            label7.Name = "label7";
            label7.Size = new Size(84, 15);
            label7.TabIndex = 26;
            label7.Text = "blockPerGame";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(317, 76);
            label6.Name = "label6";
            label6.Size = new Size(57, 15);
            label6.TabIndex = 25;
            label6.Text = "rebounds";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(314, 193);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(100, 23);
            textBox7.TabIndex = 24;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(314, 152);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(100, 23);
            textBox6.TabIndex = 23;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(314, 94);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(100, 23);
            textBox5.TabIndex = 22;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(314, 19);
            label5.Name = "label5";
            label5.Size = new Size(41, 15);
            label5.TabIndex = 21;
            label5.Text = "blocks";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(314, 37);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(100, 23);
            textBox4.TabIndex = 20;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(21, 76);
            label10.Name = "label10";
            label10.Size = new Size(121, 15);
            label10.TabIndex = 31;
            label10.Text = "threePointPercentage";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(21, 19);
            label9.Name = "label9";
            label9.Size = new Size(88, 15);
            label9.TabIndex = 30;
            label9.Text = "assistsPerGame";
            // 
            // textBox9
            // 
            textBox9.Location = new Point(21, 94);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(100, 23);
            textBox9.TabIndex = 29;
            // 
            // textBox8
            // 
            textBox8.Location = new Point(21, 37);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(100, 23);
            textBox8.TabIndex = 28;
            // 
            // PlayerEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(450, 434);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(textBox9);
            Controls.Add(textBox8);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(textBox7);
            Controls.Add(textBox6);
            Controls.Add(textBox5);
            Controls.Add(label5);
            Controls.Add(textBox4);
            Controls.Add(comboBox1);
            Controls.Add(EditPlayerButton);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "PlayerEditForm";
            Text = "Edit Player";
            Load += PlayerEditForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button EditPlayerButton;
        private ComboBox comboBox1;
        private Label label8;
        private Label label7;
        private Label label6;
        private TextBox textBox7;
        private TextBox textBox6;
        private TextBox textBox5;
        private Label label5;
        private TextBox textBox4;
        private Label label10;
        private Label label9;
        private TextBox textBox9;
        private TextBox textBox8;
    }
}