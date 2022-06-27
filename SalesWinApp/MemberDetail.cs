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
    public partial class MemberDetail : Form
    {
        public MemberDetail()
        {
            InitializeComponent();
        }
        public IMemberRepository MemberRepository { get; set; }
        public bool InsertOrUpdate { get; set; }
        public Member Member { get; set; }

        private void MemberDetail_Load(object sender, EventArgs e)
        {
            txtMemID.Enabled = !InsertOrUpdate;

            if (InsertOrUpdate == true)
            {
                txtMemID.Text = Member.MemberId.ToString();     
                txtEmail.Text = Member.Email.ToString();
                txtCompanyName.Text = Member.CompanyName.ToString();
                txtCity.Text = Member.City.ToString();
                txtCountry.Text = Member.Country.ToString();
                txtPass.Text = Member.Password.ToString();
            }
            else
            {
                string Numrd;
                Random rd = new Random();
                Numrd = rd.Next(1, 20000).ToString();
                txtMemID.Text = Numrd;

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {             
                var mem = new Member
                {
                    MemberId = int.Parse(txtMemID.Text),
                    Email = txtEmail.Text,
                    CompanyName = txtCompanyName.Text,
                    City = txtCity.Text,
                    Country = txtCountry.Text,
                    Password = txtPass.Text
                };
                if (InsertOrUpdate == false)
                {

                    MemberRepository.SaveMember(mem);

                }
                else
                {
                    MemberRepository.UpdateMember(mem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Add new member" : "Update member");
            }
        }
    }
}
