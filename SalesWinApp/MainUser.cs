using BusinessObject.Repository;
using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesWinApp
{
    public partial class MainUser : Form
    {
        IMemberRepository memberRepository = new MemberRepository();
        public string Email { get; set; }
        public MainUser()
        {
            InitializeComponent();
        }

        private void editMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void orderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserOrder frmUserOrder = new frmUserOrder
            {
                Text = "User Detail",
                Email = Email,
                member = checkMember()
            };
            frmUserOrder.ShowDialog();
        }

        private Member checkMember()
        {
            var mem = memberRepository.GetMembers();
            var acc = mem.SingleOrDefault(pro => pro.Email.Equals(Email) );
            if (acc == null)
            {
                return null;
            }
            else
            {
                return acc;
            }
        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MemberDetail memberDetail = new MemberDetail
            {
                Text = "User Detail",
                InsertOrUpdate = true,
                Member = checkMember(),
                City = checkMember().City,
                MemberRepository = memberRepository
            };
            memberDetail.ShowDialog();
            MessageBox.Show("Change Successfully! Please Login Again!");
            frmLogin frmLogin = new frmLogin();
            this.Hide();
            frmLogin.Show();
        }
    }
}
