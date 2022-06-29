
namespace SalesWinApp
{
    partial class frmOrders
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.txtOrderID = new System.Windows.Forms.TextBox();
            this.txtMemberName = new System.Windows.Forms.TextBox();
            this.txtOrderDate = new System.Windows.Forms.TextBox();
            this.txtRequiredDate = new System.Windows.Forms.TextBox();
            this.txtShippedDate = new System.Windows.Forms.TextBox();
            this.txtFreight = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtMemID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOrders
            // 
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Location = new System.Drawing.Point(675, 12);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.RowHeadersWidth = 51;
            this.dgvOrders.RowTemplate.Height = 25;
            this.dgvOrders.Size = new System.Drawing.Size(452, 426);
            this.dgvOrders.TabIndex = 0;
            this.dgvOrders.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrders_CellDoubleClick);
            // 
            // txtOrderID
            // 
            this.txtOrderID.Location = new System.Drawing.Point(137, 92);
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.ReadOnly = true;
            this.txtOrderID.Size = new System.Drawing.Size(153, 23);
            this.txtOrderID.TabIndex = 1;
            // 
            // txtMemberName
            // 
            this.txtMemberName.Location = new System.Drawing.Point(454, 92);
            this.txtMemberName.Name = "txtMemberName";
            this.txtMemberName.ReadOnly = true;
            this.txtMemberName.Size = new System.Drawing.Size(153, 23);
            this.txtMemberName.TabIndex = 2;
            // 
            // txtOrderDate
            // 
            this.txtOrderDate.Location = new System.Drawing.Point(137, 140);
            this.txtOrderDate.Name = "txtOrderDate";
            this.txtOrderDate.ReadOnly = true;
            this.txtOrderDate.Size = new System.Drawing.Size(153, 23);
            this.txtOrderDate.TabIndex = 3;
            // 
            // txtRequiredDate
            // 
            this.txtRequiredDate.Location = new System.Drawing.Point(454, 140);
            this.txtRequiredDate.Name = "txtRequiredDate";
            this.txtRequiredDate.ReadOnly = true;
            this.txtRequiredDate.Size = new System.Drawing.Size(153, 23);
            this.txtRequiredDate.TabIndex = 4;
            // 
            // txtShippedDate
            // 
            this.txtShippedDate.Location = new System.Drawing.Point(137, 189);
            this.txtShippedDate.Name = "txtShippedDate";
            this.txtShippedDate.ReadOnly = true;
            this.txtShippedDate.Size = new System.Drawing.Size(153, 23);
            this.txtShippedDate.TabIndex = 5;
            // 
            // txtFreight
            // 
            this.txtFreight.Location = new System.Drawing.Point(454, 189);
            this.txtFreight.Name = "txtFreight";
            this.txtFreight.ReadOnly = true;
            this.txtFreight.Size = new System.Drawing.Size(153, 23);
            this.txtFreight.TabIndex = 6;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(137, 291);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 7;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(454, 292);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 22);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtMemID
            // 
            this.txtMemID.Location = new System.Drawing.Point(148, 189);
            this.txtMemID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMemID.Name = "txtMemID";
            this.txtMemID.Size = new System.Drawing.Size(9, 23);
            this.txtMemID.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Order ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 143);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Order Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "Shipped Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(346, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "Member Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(346, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "Required Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(346, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 15);
            this.label6.TabIndex = 15;
            this.label6.Text = "Freigt";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(295, 291);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 450);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.txtFreight);
            this.Controls.Add(this.txtShippedDate);
            this.Controls.Add(this.txtRequiredDate);
            this.Controls.Add(this.txtOrderDate);
            this.Controls.Add(this.txtMemberName);
            this.Controls.Add(this.txtOrderID);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.txtMemID);
            this.Name = "frmOrders";
            this.Text = "frmOrders";
            this.Load += new System.EventHandler(this.frmOrders_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.TextBox txtOrderID;
        private System.Windows.Forms.TextBox txtMemberName;
        private System.Windows.Forms.TextBox txtOrderDate;
        private System.Windows.Forms.TextBox txtRequiredDate;
        private System.Windows.Forms.TextBox txtShippedDate;
        private System.Windows.Forms.TextBox txtFreight;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtMemID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDelete;
    }
}