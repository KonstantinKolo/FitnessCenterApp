namespace PresentationLayer
{
    partial class CreateMemberForm
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
            pictureBox1 = new PictureBox();
            firstName = new Label();
            lastName = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources._3;
            pictureBox1.Location = new Point(191, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(138, 120);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // firstName
            // 
            firstName.AutoSize = true;
            firstName.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            firstName.Location = new Point(74, 176);
            firstName.Name = "firstName";
            firstName.Size = new Size(67, 32);
            firstName.TabIndex = 1;
            firstName.Text = "Име:";
            firstName.Click += label1_Click;
            // 
            // lastName
            // 
            lastName.AutoSize = true;
            lastName.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lastName.Location = new Point(23, 225);
            lastName.Name = "lastName";
            lastName.Size = new Size(118, 32);
            lastName.TabIndex = 2;
            lastName.Text = "Фамилия:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(147, 185);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(203, 23);
            textBox1.TabIndex = 3;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(147, 234);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(203, 23);
            textBox2.TabIndex = 4;
            // 
            // button1
            // 
            button1.BackColor = Color.Black;
            button1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button1.ForeColor = Color.White;
            button1.Location = new Point(163, 341);
            button1.Name = "button1";
            button1.Size = new Size(198, 47);
            button1.TabIndex = 5;
            button1.Text = "CREATE";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // CreateMemberForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 255, 128);
            ClientSize = new Size(546, 499);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(lastName);
            Controls.Add(firstName);
            Controls.Add(pictureBox1);
            Name = "CreateMemberForm";
            Text = "CreateMemberForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label firstName;
        private Label lastName;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
    }
}