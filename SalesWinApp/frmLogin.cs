using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesWinApp
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            string fileName = "appsettings.json";
            string json = File.ReadAllText(fileName);

            var adminAcc = JsonSerializer.Deserialize<Member>(json, null);

            string email = adminAcc.Email;
            string password = adminAcc.Password;
            if (email.Equals(txtEmail.Text) && password.Equals(txtPass.Text))
            {
                frmMain viewMain = new frmMain();
                viewMain.Show();
                this.Hide();
            }else if (checkMember() != null)
            {
                MainUser mainUser = new MainUser {
                    Email = txtEmail.Text
                };
                mainUser.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Account is invalid !");
            }
        }
        private Member checkMember()
        {
            FStoreDBContext db = new FStoreDBContext();
            var mem = db.Members.SingleOrDefault(pro => pro.Email.Equals(txtEmail.Text) && pro.Password.Equals(txtPass.Text));
            if (mem == null)
            {
                return null;
            }
            else
            {
                return mem;
            }
        }
    }
}
