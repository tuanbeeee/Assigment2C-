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
    public partial class frmMembers : Form
    {
        IMemberRepository resp = new MemberRepository();
        BindingSource source;
        public frmMembers()
        {
            InitializeComponent();
        }
        public void LoadMember()
        {
            try
            {
                FStoreDBContext db = new FStoreDBContext();
                var memList = from c in db.Members
                                select new
                                {
                                    MemberId = c.MemberId,
                                    Email = c.Email,
                                    CompanyName = c.CompanyName,
                                    City = c.City,
                                    Country = c.Country,
                                    Password = c.Password
                                };
                source = new BindingSource();
                source.DataSource = memList.ToList();

                txtMemID.DataBindings.Clear();
                txtEmail.DataBindings.Clear();
                txtCompanyName.DataBindings.Clear();
                txtCity.DataBindings.Clear();
                txtCountry.DataBindings.Clear();               
                txtPass.DataBindings.Clear();

                txtMemID.DataBindings.Add("Text", source, "MemberId");
                txtEmail.DataBindings.Add("Text", source, "Email");
                txtCompanyName.DataBindings.Add("Text", source, "CompanyName");
                txtCity.DataBindings.Add("Text", source, "City");
                txtCountry.DataBindings.Add("Text", source, "Country");
                txtPass.DataBindings.Add("Text", source, "Password");

                dgvMembers.DataSource = null;
                dgvMembers.DataSource = source;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of members!");
            }
        }

        private void frmMembers_Load(object sender, EventArgs e)
        {
            LoadMember();
            dgvMembers.CellDoubleClick += dgvMembers_CellDoubleClick;
        }

        public Member GetMemberObject()
        {
            Member mem = null;
            try
            {
                mem = new Member
                {
                    MemberId = int.Parse(txtMemID.Text),
                    Email = txtEmail.Text,
                    CompanyName = txtCompanyName.Text,
                    City = txtCity.Text,
                    Country = txtCountry.Text,
                    Password = txtPass.Text
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get member");
            }
            return mem;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            MemberDetail memberDetail = new MemberDetail
            {
                Text = "Add new member",
                InsertOrUpdate = false,
                MemberRepository = resp
            };
            if (memberDetail.ShowDialog() == DialogResult.OK)
            {
                LoadMember();
                source.Position = source.Count - 1;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var mem = GetMemberObject();
                resp.DeleteMember(mem);
                LoadMember();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete one member");
            }
        }

        private void dgvMembers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            MemberDetail memberDetail = new MemberDetail
            {
                Text = "Update Member",
                InsertOrUpdate = true,
                Member = GetMemberObject(),
                MemberRepository = resp
            };
            if (memberDetail.ShowDialog() == DialogResult.OK)
            {
                LoadMember();
                source.Position = source.Count - 1;

            }
        }
    }
}
