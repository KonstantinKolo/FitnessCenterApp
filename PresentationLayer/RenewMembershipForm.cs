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
    public partial class RenewMembershipForm : Form
    {
        public RenewMembershipForm()
        {
            InitializeComponent();
        }

        private void RenewMembershipForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int memberId = Convert.ToInt32(textBox1.Text);
            int days = Convert.ToInt32(numericUpDown1.Value); 

            try
            {
                FitnessInfo.memberService.RenewMembership(memberId, days);
                MessageBox.Show("Абонаментът е подновен.");
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка: " + ex.Message);
            }
        }
    }
}
