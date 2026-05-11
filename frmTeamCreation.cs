using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace BRCSS_BasketballStats
{
    public partial class frmLogin : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public frmLogin()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Royals Basketball Database.accdb; Persist Security Info=False";
            try
            {
                connection.Open();
                lblConnectionValue.Text = "Connected";
                connection.Close();
            }
            catch
            {
                MessageBox.Show("Warning : Unable to Establish Connection to the Microsoft Access Database! Please make sure the Microsoft Access Database (labelled 'Royals Basketball Database') is placed in bin/debug/ of this program, then restart the program. Thank you.");
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "redingbasketball" && txtPassword.Text == "werbr")
            {
                bool guestCheck = false;
                this.Hide();
                frmAdminInterface frmAdminInterface = new frmAdminInterface(guestCheck);
                frmAdminInterface.Show();
            }
            if (txtUsername.Text == "guest" && txtPassword.Text == "guest")
            {
                bool guestCheck = true;
                this.Hide();
                frmAdminInterface frmAdminInterface = new frmAdminInterface(guestCheck);
                frmAdminInterface.Show();
            }
            else if (txtUsername.Text != "guest" && txtUsername.Text != "redingbasketball" && txtPassword.Text != "werbr" && txtPassword.Text != "guest")
            {
                MessageBox.Show("Warning : Invalid Login Data entered! Please retry with the correct login details, thank you.");
            }
        }
    }
}
