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
    public partial class CheckMembershipForm : Form
    {
        public CheckMembershipForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int memberId = Convert.ToInt32(textBox1.Text);

            try
            {
                bool isValid = FitnessInfo.memberService.IsMembershipValid(memberId);
                MessageBox.Show(isValid ? "Абонаментът е валиден" : "Абонаментът е НЕвалиден");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка: " + ex.Message);
            }
        }
    }
}
