namespace PresentationLayer
{
    partial class GetMemberIdForm
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
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            lastName = new Label();
            firstName = new Label();
            button1 = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(255, 255, 128);
            pictureBox1.Image = Properties.Resources._3;
            pictureBox1.Location = new Point(187, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(147, 111);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(168, 244);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(203, 23);
            textBox2.TabIndex = 8;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(168, 195);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(203, 23);
            textBox1.TabIndex = 7;
            // 
            // lastName
            // 
            lastName.AutoSize = true;
            lastName.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lastName.Location = new Point(44, 235);
            lastName.Name = "lastName";
            lastName.Size = new Size(118, 32);
            lastName.TabIndex = 6;
            lastName.Text = "Фамилия:";
            // 
            // firstName
            // 
            firstName.AutoSize = true;
            firstName.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            firstName.Location = new Point(95, 186);
            firstName.Name = "firstName";
            firstName.Size = new Size(67, 32);
            firstName.TabIndex = 5;
            firstName.Text = "Име:";
            // 
            // button1
            // 
            button1.BackColor = Color.Black;
            button1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button1.ForeColor = Color.White;
            button1.Location = new Point(154, 339);
            button1.Name = "button1";
            button1.Size = new Size(217, 73);
            button1.TabIndex = 9;
            button1.Text = "GetMemberId";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(86, 456);
            label1.Name = "label1";
            label1.Size = new Size(0, 45);
            label1.TabIndex = 10;
            // 
            // GetMemberIdForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 255, 128);
            ClientSize = new Size(518, 567);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(lastName);
            Controls.Add(firstName);
            Controls.Add(pictureBox1);
            Name = "GetMemberIdForm";
            Text = "GetMemberIdForm";
            Load += GetMemberIdForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label lastName;
        private Label firstName;
        private Button button1;
        private Label label1;
    }
}