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
                BindingSource source = new BindingSource();
                source.DataSource = memList.ToList();

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
        }
    }
}
