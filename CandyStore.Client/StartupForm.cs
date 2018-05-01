using CandyStore.Client.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CandyStore.Client
{
    public partial class StartupForm : Form
    {
        private AdminLoginForm _adminLoginForm;
        private CustomerLoginForm _customerLoginForm;

        public StartupForm()
        {
            InitializeComponent();
        }

        private void HideForms()
        {
            _adminLoginForm?.Hide();
            _customerLoginForm?.Hide();
        }

        private void adminLoginBtn_Click(object sender, EventArgs e)
        {
            HideForms();
            _adminLoginForm = new AdminLoginForm();
            _adminLoginForm.ShowDialog();
        }

        private void browseSweetsBtn_Click(object sender, EventArgs e)
        {
            HideForms();
            _customerLoginForm = new CustomerLoginForm();
            _customerLoginForm.ShowDialog();
        }

        private void StartupForm_Load(object sender, EventArgs e)
        {
            welcomeLabel.BackColor = Color.Transparent;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
