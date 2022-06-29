
namespace SalesWinApp
{
    partial class frmCreateOrder
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
            this.txtOrderID = new System.Windows.Forms.TextBox();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cbProductID = new System.Windows.Forms.ComboBox();
            this.dtOrderDate = new System.Windows.Forms.DateTimePicker();
            this.dtShippedDate = new System.Windows.Forms.DateTimePicker();
            this.dtRequiredFate = new System.Windows.Forms.DateTimePicker();
            this.txtFreight = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.cbMemberName = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtOrderID
            // 
            this.txtOrderID.Location = new System.Drawing.Point(193, 62);
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.Size = new System.Drawing.Size(206, 23);
            this.txtOrderID.TabIndex = 0;
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Location = new System.Drawing.Point(193, 198);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Size = new System.Drawing.Size(206, 23);
            this.txtUnitPrice.TabIndex = 3;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(193, 242);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(206, 23);
            this.txtQuantity.TabIndex = 4;
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(193, 288);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(206, 23);
            this.txtDiscount.TabIndex = 5;
            this.txtDiscount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiscount_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Order ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Member Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "Product ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(64, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "Unit Price";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(64, 245);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "Quantity";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(64, 291);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 15);
            this.label6.TabIndex = 15;
            this.label6.Text = "Discount";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(64, 337);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 15);
            this.label7.TabIndex = 16;
            this.label7.Text = "Order Date";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(64, 382);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 15);
            this.label8.TabIndex = 17;
            this.label8.Text = "Required Date";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(64, 427);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 15);
            this.label9.TabIndex = 18;
            this.label9.Text = "Shipped Date";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(64, 472);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 15);
            this.label10.TabIndex = 19;
            this.label10.Text = "Freight";
            // 
            // cbProductID
            // 
            this.cbProductID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProductID.FormattingEnabled = true;
            this.cbProductID.Location = new System.Drawing.Point(193, 151);
            this.cbProductID.Name = "cbProductID";
            this.cbProductID.Size = new System.Drawing.Size(206, 23);
            this.cbProductID.TabIndex = 20;
            this.cbProductID.SelectedIndexChanged += new System.EventHandler(this.cbProductID_SelectedIndexChanged);
            // 
            // dtOrderDate
            // 
            this.dtOrderDate.Location = new System.Drawing.Point(193, 331);
            this.dtOrderDate.Name = "dtOrderDate";
            this.dtOrderDate.Size = new System.Drawing.Size(206, 23);
            this.dtOrderDate.TabIndex = 21;
            // 
            // dtShippedDate
            // 
            this.dtShippedDate.Location = new System.Drawing.Point(193, 421);
            this.dtShippedDate.Name = "dtShippedDate";
            this.dtShippedDate.Size = new System.Drawing.Size(206, 23);
            this.dtShippedDate.TabIndex = 23;
            // 
            // dtRequiredFate
            // 
            this.dtRequiredFate.Location = new System.Drawing.Point(193, 376);
            this.dtRequiredFate.Name = "dtRequiredFate";
            this.dtRequiredFate.Size = new System.Drawing.Size(206, 23);
            this.dtRequiredFate.TabIndex = 24;
            // 
            // txtFreight
            // 
            this.txtFreight.Location = new System.Drawing.Point(193, 469);
            this.txtFreight.Name = "txtFreight";
            this.txtFreight.Size = new System.Drawing.Size(206, 23);
            this.txtFreight.TabIndex = 25;
            this.txtFreight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFreight_KeyPress);
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(206, 538);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 26;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbMemberName
            // 
            this.cbMemberName.FormattingEnabled = true;
            this.cbMemberName.Location = new System.Drawing.Point(193, 105);
            this.cbMemberName.Name = "cbMemberName";
            this.cbMemberName.Size = new System.Drawing.Size(206, 23);
            this.cbMemberName.TabIndex = 27;
            // 
            // frmCreateOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 606);
            this.Controls.Add(this.cbMemberName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtFreight);
            this.Controls.Add(this.dtRequiredFate);
            this.Controls.Add(this.dtShippedDate);
            this.Controls.Add(this.dtOrderDate);
            this.Controls.Add(this.cbProductID);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.txtUnitPrice);
            this.Controls.Add(this.txtOrderID);
            this.Name = "frmCreateOrder";
            this.Text = "frmCreateOrder";
            this.Load += new System.EventHandler(this.frmCreateOrder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOrderID;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbProductID;
        private System.Windows.Forms.DateTimePicker dtOrderDate;
        private System.Windows.Forms.DateTimePicker dtShippedDate;
        private System.Windows.Forms.DateTimePicker dtRequiredFate;
        private System.Windows.Forms.TextBox txtFreight;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cbMemberName;
    }
}