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
        string firstName = textBoxFirstName.Text.Trim();
        string lastName = textBoxLastName.Text.Trim();
        string password = textBoxPassword.Text;

        public LoginButton()
        {
            InitializeComponent();
        }
         try
        {
                // 1. Вземаме ID по въведени име, фамилия и парола
                int employeeId = FitnessInfo.employeeService.GetEmployeeId(firstName, lastName, password);

               // 2. Проверяваме паролата (по избор, вече я тествахме)
                bool isValid = FitnessInfo.employeeService.TestPassword(employeeId, password);

               if (isValid)
               {
                // Запазваме в LoggedInEmployeeId
                FitnessInfo.employeeService.LoggedInEmployeeId = employeeId;

                // Отваряме нова форма (примерно MainForm)
                LoginForm logged = new LoginForm();
                logged.Show();
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

        private void LoginButton_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
