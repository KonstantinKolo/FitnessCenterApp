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
    public partial class MemberControllForm : Form
    {
        public MemberControllForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            CreateMemberForm createForm = new CreateMemberForm();
            createForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetMemberIdForm getMemberId = new GetMemberIdForm();
            getMemberId.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CheckMembershipForm checkMembershipForm = new CheckMembershipForm();
            checkMembershipForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RenewMembershipForm renewMembershipForm = new RenewMembershipForm();
            renewMembershipForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DeleteMembershipForm deleteMembershipForm = new DeleteMembershipForm();
            deleteMembershipForm.Show();
        }
    }

    internal class ImageContainer
    {
    }
}
