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
    public partial class DeleteMembershipForm : Form
    {
        public DeleteMembershipForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int memberId = Convert.ToInt32(textBox1.Text);

            DialogResult result = MessageBox.Show("Сигурни ли сте, че искате да изтриете този член?", "Потвърждение", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                try
                {
                    FitnessInfo.memberService.DeleteMember(memberId);
                    MessageBox.Show("Членът е изтрит успешно.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Грешка: " + ex.Message);
                }
            }
        }
    }
}
