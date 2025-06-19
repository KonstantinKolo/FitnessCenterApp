using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServiceLayer;

namespace PresentationLayer
{
    public partial class RegisterButton : Form
    {
        private int selectedFitness;

        public RegisterButton()
        {
            InitializeComponent();
            LoadFitnessCenters();

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private System.Windows.Forms.ComboBox comboBoxFitnessCenters;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.TextBox textBoxPassword;

        private void LoadFitnessCenters()
        {
            var dict = FitnessInfo.fitnessCenterService.LoadFitnessCenterNameAndId();

            comboBox1.DataSource = new BindingSource(dict, null);
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";

        }

        private void RegisterButton_Load(object sender, EventArgs e)
        {
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
            string firstName = textBox1.Text.Trim();
            string lastName = textBox2.Text.Trim();
            string password = textBox3.Text;

            if (selectedFitness == null)
            {
                MessageBox.Show("Моля, изберете фитнес център.");
                return;
            }

            FitnessInfo.employeeService.CreateEmployee(firstName,
                lastName, password, selectedFitness);

            // var selectedCenter = (FitnessCenter)comboBoxFitnessCenters.SelectedItem;

            // var newEmployee = new Employee(firstName, lastName, password, selectedCenter);

            // var context = new EmployeeContext(new FitnessDbContext());

            try
            {
                //context.Create(newEmployee);
                MessageBox.Show("Регистрацията е успешна!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Грешка при регистрация: {ex.Message}", "Грешка");
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int selectedId = ((KeyValuePair<int, string>)comboBox1.SelectedItem).Key;
            selectedFitness = selectedId;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
