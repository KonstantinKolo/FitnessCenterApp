namespace PresentationLayer
{
    partial class RenewMembershipForm
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
            button1 = new Button();
            label1 = new Label();
            textBox1 = new TextBox();
            numericUpDown1 = new NumericUpDown();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources._3;
            pictureBox1.Location = new Point(168, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(169, 140);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.BackColor = Color.Black;
            button1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button1.ForeColor = Color.White;
            button1.Location = new Point(135, 293);
            button1.Name = "button1";
            button1.Size = new Size(238, 58);
            button1.TabIndex = 1;
            button1.Text = "RenewMembership";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(162, 212);
            label1.Name = "label1";
            label1.Size = new Size(34, 25);
            label1.TabIndex = 6;
            label1.Text = "ID:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(202, 214);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(135, 23);
            textBox1.TabIndex = 5;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(202, 253);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(135, 23);
            numericUpDown1.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(140, 251);
            label2.Name = "label2";
            label2.Size = new Size(56, 25);
            label2.TabIndex = 8;
            label2.Text = "Days:";
            // 
            // RenewMembershipForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 255, 128);
            ClientSize = new Size(523, 535);
            Controls.Add(label2);
            Controls.Add(numericUpDown1);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Name = "RenewMembershipForm";
            Text = "RenewMembershipForm";
            Load += RenewMembershipForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button button1;
        private Label label1;
        private TextBox textBox1;
        private NumericUpDown numericUpDown1;
        private Label label2;
    }
}