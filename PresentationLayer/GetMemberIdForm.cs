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
    public partial class GetMemberIdForm : Form
    {
        public GetMemberIdForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string firstName = textBox1.Text.Trim();
            string lastName = textBox2.Text.Trim();

            try
            {
                int memberId = FitnessInfo.memberService.GetMemberId(firstName, lastName);
                label1.Text = "ID: " + memberId.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка: " + ex.Message);
            }
        }

        private void GetMemberIdForm_Load(object sender, EventArgs e)
        {

        }
    }
}
