using CandyStore.Client.Messages;
using CandyStore.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CandyStore.Client.Forms
{
    public partial class AdminLoginForm : Form
    {
        public AdminLoginForm()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            var identificationNumber = int.Parse(identificationNumberBox.Text);
            using (var context = new CandyStoreDbContext())
            {
                var userFromDb = context.Employees.FirstOrDefault(u => u.IdentificationNumber == identificationNumber);
                if(userFromDb == null)
                {
                    Logger.ShowError("There is no such employee");
                    return;
                }

                var adminPanelForm = new AdminPanelForm();
                adminPanelForm.Show();
                this.Hide();
                var openedStartupForm = Application.OpenForms.OfType<StartupForm>().FirstOrDefault();
                openedStartupForm?.Hide();
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void AdminLoginForm_Load(object sender, EventArgs e)
        {
            label1.BackColor = Color.Transparent;
        }
    }
}
