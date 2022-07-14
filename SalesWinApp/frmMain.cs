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
    public partial class frmMain : Form
    {

        public frmMain()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProducts viewProduct = new frmProducts();

            viewProduct.Show();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void memberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMembers viewMember = new frmMembers();

            viewMember.Show();
        }

        private void orderDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOrders viewOrders = new frmOrders();

            viewOrders.Show();
        }

 

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void statisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStatistics frmStatistics = new frmStatistics();

            frmStatistics.Show();
        }
    }
}
