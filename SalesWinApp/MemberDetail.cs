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
        public string City { get; set; }

        private void MemberDetail_Load(object sender, EventArgs e)
        {
            txtMemID.Enabled = !InsertOrUpdate;

            if (InsertOrUpdate == true)
            {
                txtEmail.Enabled = false;
                txtPass.Enabled = false;

                txtMemID.Text = Member.MemberId.ToString();     
                txtEmail.Text = Member.Email.ToString();
                txtCompanyName.Text = Member.CompanyName.ToString();
                txtPass.Text = Member.Password.ToString();
                cbCountry.Text = Member.Country.ToString();
                cbCity.Text = City.ToString();
            }
            else
            {
                string Numrd;
                Random rd = new Random();
                Numrd = rd.Next(1, 20000).ToString();
                txtMemID.Text = Numrd;
                
            }
        }
        private Member checkMember(string email)
        {
            FStoreDBContext db = new FStoreDBContext();
            var mem = db.Members.SingleOrDefault(pro => pro.Email.Equals(email));
            if (mem == null)
            {
                return null;
            }
            else
            {
                return mem;
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
                    City = cbCity.Text,
                    Country = cbCountry.SelectedItem.ToString(),
                    Password = txtPass.Text
                };
                if (InsertOrUpdate == false)
                {
                    if (checkMember(mem.Email) != null)
                    {
                        MessageBox.Show("Email is exist !");
                    }
                    else
                    {
                        MemberRepository.SaveMember(mem);
                        Close();
                    }
                }
                else
                {
                    MemberRepository.UpdateMember(mem);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Add new member" : "Update member");
            }
        }

        private void cbCountry_SelectionChangeCommitted(object sender, EventArgs e)
        {
            

            if (cbCountry.Text.Equals("Viet Nam"))
            {
                cbCity.Items.Clear();
                cbCity.Items.Add("Ho Chi Minh");
                cbCity.Items.Add("Ha Noi");
                cbCity.Items.Add("Da Nang");
                cbCity.Items.Add("Can Tho");
            }
            else if (cbCountry.Text.Equals("Japan"))
            {
                cbCity.Items.Clear();
                cbCity.Items.Add("Kimochi");
                cbCity.Items.Add("Tokyo");
                cbCity.Items.Add("Hokido");
                cbCity.Items.Add("Osaka");
            }
            else if (cbCountry.Text.Equals("Campuchia"))
            {
                cbCity.Items.Clear();
                cbCity.Items.Add("Haha");
                cbCity.Items.Add("Hihi");
                cbCity.Items.Add("Hoho");
            }
        }
    }
}
