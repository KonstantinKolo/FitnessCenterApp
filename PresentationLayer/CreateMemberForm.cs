using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class CreateMemberForm : Form
    {
        public CreateMemberForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string firstName = textBox1.Text.Trim();
            string lastName = textBox2.Text.Trim();

            try
            {
                FitnessInfo.memberService.CreateMember(firstName, lastName);
                MessageBox.Show("Членът е създаден успешно!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка: " + ex.Message);
            }
        }
    }
}
