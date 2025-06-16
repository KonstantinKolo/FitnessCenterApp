using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLayer;
using BusinessLayer;

namespace PresentationLayer
{
    public partial class RegisterButton : Form
    {
        public RegisterButton()
        {
            InitializeComponent();
        }

        private System.Windows.Forms.ComboBox comboBoxFitnessCenters;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.TextBox textBoxPassword;

        private void RegisterButton_Load(object sender, EventArgs e)
        {
            var context = new FitnessCenterContext(new FitnessDbContext());
            var centers = context.ReadAll();

            comboBoxFitnessCenters.DataSource = centers;
            comboBoxFitnessCenters.DisplayMember = "Name";
            comboBoxFitnessCenters.ValueMember = "Id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginButton login = new LoginButton();
            login.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string firstName  = textBoxFirstName.Text.Trim();
            string lastName = textBoxLastName.Text.Trim();
            string password = textBoxPassword.Text;

            if (comboBoxFitnessCenters.SelectedItem == null)
            {
                MessageBox.Show("Моля, изберете фитнес център.");
                return;
            }

            var selectedCenter = (FitnessCenter)comboBoxFitnessCenters.SelectedItem;

            var newEmployee = new Employee(firstName, lastName, password, selectedCenter);

            var context = new EmployeeContext(new FitnessDbContext());

            try
            {
                context.Create(newEmployee);
                MessageBox.Show("Регистрацията е успешна!", "Успех");
                this.Close(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Грешка при регистрация: {ex.Message}", "Грешка");
            }
        }
    }
}
