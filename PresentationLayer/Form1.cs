using Microsoft.VisualBasic.Logging;

namespace PresentationLayer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginButton login = new LoginButton();
            login.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegisterButton register = new RegisterButton();
            register.Show();
        }
    }
}
