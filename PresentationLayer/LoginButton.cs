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
    public partial class LoginButton : Form
    {
        

        public LoginButton()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string firstName = textBox1.Text.Trim();
            string lastName = textBox2.Text.Trim();
            string password = textBox3.Text;

            try
            {
                int employeeId = FitnessInfo.employeeService.GetEmployeeId(firstName, lastName, password);

                bool isValid = FitnessInfo.employeeService.TestPassword(employeeId, password);

                if (isValid)
                {
                    FitnessInfo.employeeService.LoggedInEmployeeId = employeeId;

                    // Отваряме нова форма (примерно MainForm)
                    MemberControllForm memberControllForm = new MemberControllForm();
                    memberControllForm.Show();
                    this.Hide(); // скриваме login формата
                }
                else
                {
                    MessageBox.Show("Грешна парола.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешни данни за вход: " + ex.Message);
            }
        }
        

    }
}