namespace QuanLyPhongTro_1
{
    partial class FormTenant
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
            label5 = new Label();
            panel1 = new Panel();
            dgTenants = new DataGridView();
            txtCCCD = new TextBox();
            label3 = new Label();
            label4 = new Label();
            txtSearch = new TextBox();
            label2 = new Label();
            txtFullName = new TextBox();
            btnUpdate = new Button();
            label1 = new Label();
            txtAddress = new TextBox();
            btnDelete = new Button();
            txtPhoneNumber = new TextBox();
            btnSearch = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnAdd = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgTenants).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(19, 10);
            label5.Name = "label5";
            label5.Size = new Size(194, 25);
            label5.TabIndex = 0;
            label5.Text = "Danh sách khách hàng:";
            // 
            // panel1
            // 
            panel1.Controls.Add(dgTenants);
            panel1.Controls.Add(label5);
            panel1.Location = new Point(47, 363);
            panel1.Name = "panel1";
            panel1.Size = new Size(757, 413);
            panel1.TabIndex = 16;
            // 
            // dgTenants
            // 
            dgTenants.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgTenants.Location = new Point(27, 48);
            dgTenants.Name = "dgTenants";
            dgTenants.RowHeadersWidth = 62;
            dgTenants.Size = new Size(727, 365);
            dgTenants.TabIndex = 1;
            dgTenants.CellClick += dgTenants_CellClick;
            // 
            // txtCCCD
            // 
            tableLayoutPanel1.SetColumnSpan(txtCCCD, 3);
            txtCCCD.Dock = DockStyle.Bottom;
            txtCCCD.Location = new Point(142, 137);
            txtCCCD.Name = "txtCCCD";
            txtCCCD.Size = new Size(614, 31);
            txtCCCD.TabIndex = 6;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Location = new Point(20, 260);
            label3.Margin = new Padding(20, 0, 3, 0);
            label3.Name = "label3";
            label3.Size = new Size(44, 25);
            label3.TabIndex = 2;
            label3.Text = "SĐT";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Location = new Point(20, 203);
            label4.Margin = new Padding(20, 0, 3, 0);
            label4.Name = "label4";
            label4.Size = new Size(65, 25);
            label4.TabIndex = 3;
            label4.Text = "Địa chỉ";
            // 
            // txtSearch
            // 
            tableLayoutPanel1.SetColumnSpan(txtSearch, 3);
            txtSearch.Dock = DockStyle.Bottom;
            txtSearch.Location = new Point(142, 23);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Nhập tên hoặc số điện thoại.....";
            txtSearch.Size = new Size(614, 31);
            txtSearch.TabIndex = 4;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new Point(20, 146);
            label2.Margin = new Padding(20, 0, 3, 0);
            label2.Name = "label2";
            label2.Size = new Size(58, 25);
            label2.TabIndex = 1;
            label2.Text = "CCCD";
            // 
            // txtFullName
            // 
            tableLayoutPanel1.SetColumnSpan(txtFullName, 3);
            txtFullName.Dock = DockStyle.Bottom;
            txtFullName.Location = new Point(142, 80);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(614, 31);
            txtFullName.TabIndex = 5;
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnUpdate.BackColor = Color.Gold;
            btnUpdate.Location = new Point(270, 288);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(231, 54);
            btnUpdate.TabIndex = 13;
            btnUpdate.Text = "Cập Nhập Thông Tin KH";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(17, 89);
            label1.Margin = new Padding(17, 0, 3, 0);
            label1.Name = "label1";
            label1.Size = new Size(89, 25);
            label1.TabIndex = 0;
            label1.Text = "Họ và tên";
            // 
            // txtAddress
            // 
            tableLayoutPanel1.SetColumnSpan(txtAddress, 3);
            txtAddress.Dock = DockStyle.Bottom;
            txtAddress.Location = new Point(142, 194);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(614, 31);
            txtAddress.TabIndex = 7;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDelete.BackColor = Color.Salmon;
            btnDelete.Location = new Point(529, 288);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(103, 54);
            btnDelete.TabIndex = 14;
            btnDelete.Text = "Xóa KH";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            tableLayoutPanel1.SetColumnSpan(txtPhoneNumber, 2);
            txtPhoneNumber.Location = new Point(142, 251);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(351, 31);
            txtPhoneNumber.TabIndex = 8;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSearch.Location = new Point(3, 21);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(113, 33);
            btnSearch.TabIndex = 0;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.31357F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.864296F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34.123848F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30.698288F));
            tableLayoutPanel1.Controls.Add(btnSearch, 0, 0);
            tableLayoutPanel1.Controls.Add(txtPhoneNumber, 1, 4);
            tableLayoutPanel1.Controls.Add(btnDelete, 3, 5);
            tableLayoutPanel1.Controls.Add(txtAddress, 1, 3);
            tableLayoutPanel1.Controls.Add(label1, 0, 1);
            tableLayoutPanel1.Controls.Add(btnUpdate, 2, 5);
            tableLayoutPanel1.Controls.Add(txtFullName, 1, 1);
            tableLayoutPanel1.Controls.Add(label2, 0, 2);
            tableLayoutPanel1.Controls.Add(txtSearch, 1, 0);
            tableLayoutPanel1.Controls.Add(btnAdd, 1, 5);
            tableLayoutPanel1.Controls.Add(label4, 0, 3);
            tableLayoutPanel1.Controls.Add(label3, 0, 4);
            tableLayoutPanel1.Controls.Add(txtCCCD, 1, 2);
            tableLayoutPanel1.Location = new Point(47, 13);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.Size = new Size(759, 345);
            tableLayoutPanel1.TabIndex = 15;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAdd.BackColor = Color.PowderBlue;
            btnAdd.Location = new Point(142, 288);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(103, 54);
            btnAdd.TabIndex = 12;
            btnAdd.Text = "Thêm KH";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // FormTenant
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(853, 807);
            Controls.Add(panel1);
            Controls.Add(tableLayoutPanel1);
            Name = "FormTenant";
            Text = "FormTenant";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgTenants).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label label5;
        private Panel panel1;
        private DataGridView dgTenants;
        private TextBox txtCCCD;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnSearch;
        private TextBox txtPhoneNumber;
        private Button btnDelete;
        private TextBox txtAddress;
        private Label label1;
        private Button btnUpdate;
        private TextBox txtFullName;
        private Label label2;
        private TextBox txtSearch;
        private Label label4;
        private Label label3;
        private Button btnAdd;
    }
}