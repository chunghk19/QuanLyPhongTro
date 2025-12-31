namespace QuanLyPhongTro_1
{
    partial class FormContract
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            groupBox1 = new GroupBox();
            cbRoom = new ComboBox();
            txtDeposit = new TextBox();
            label11 = new Label();
            txtCCCD = new TextBox();
            TimeEnd = new DateTimePicker();
            TimeStart = new DateTimePicker();
            txtPrice = new TextBox();
            txtAddress = new TextBox();
            txtSDT = new TextBox();
            txtFullName = new TextBox();
            groupBox2 = new GroupBox();
            txtPassWord = new TextBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            txtUserName = new TextBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            groupBox3 = new GroupBox();
            dgvlistViewContract = new DataGridView();
            button1 = new Button();
            textBox9 = new TextBox();
            button2 = new Button();
            comboBox1 = new ComboBox();
            label12 = new Label();
            label13 = new Label();
            txtNhapLai = new TextBox();
            txtEmail = new TextBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvlistViewContract).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 241);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(78, 20);
            label1.TabIndex = 0;
            label1.Text = "Giá phòng";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 29);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 1;
            label2.Text = "Họ và tên";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(7, 113);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(36, 20);
            label3.TabIndex = 2;
            label3.Text = "SĐT";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(7, 156);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(55, 20);
            label4.TabIndex = 3;
            label4.Text = "Địa chỉ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(7, 199);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(84, 20);
            label5.TabIndex = 4;
            label5.Text = "Phòng thuê";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(7, 283);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(99, 20);
            label6.TabIndex = 5;
            label6.Text = "Ngày bắt đầu";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(7, 325);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(100, 20);
            label7.TabIndex = 6;
            label7.Text = "Ngày kết thúc";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(7, 71);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(47, 20);
            label8.TabIndex = 7;
            label8.Text = "CCCD";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(7, 33);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(73, 20);
            label9.TabIndex = 8;
            label9.Text = "Tài Khoản";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(7, 68);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new Size(70, 20);
            label10.TabIndex = 9;
            label10.Text = "Mật khẩu";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbRoom);
            groupBox1.Controls.Add(txtDeposit);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(txtCCCD);
            groupBox1.Controls.Add(TimeEnd);
            groupBox1.Controls.Add(TimeStart);
            groupBox1.Controls.Add(txtPrice);
            groupBox1.Controls.Add(txtAddress);
            groupBox1.Controls.Add(txtSDT);
            groupBox1.Controls.Add(txtFullName);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(2, 3);
            groupBox1.Margin = new Padding(2, 3, 2, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2, 3, 2, 3);
            groupBox1.Size = new Size(417, 405);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin hợp đồng";
            // 
            // cbRoom
            // 
            cbRoom.FormattingEnabled = true;
            cbRoom.Location = new Point(111, 195);
            cbRoom.Margin = new Padding(3, 4, 3, 4);
            cbRoom.Name = "cbRoom";
            cbRoom.Size = new Size(300, 28);
            cbRoom.TabIndex = 18;
            // 
            // txtDeposit
            // 
            txtDeposit.Location = new Point(111, 363);
            txtDeposit.Margin = new Padding(2, 3, 2, 3);
            txtDeposit.Name = "txtDeposit";
            txtDeposit.Size = new Size(302, 27);
            txtDeposit.TabIndex = 17;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(7, 368);
            label11.Margin = new Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.Size = new Size(64, 20);
            label11.TabIndex = 16;
            label11.Text = "Tiền cọc";
            // 
            // txtCCCD
            // 
            txtCCCD.Location = new Point(111, 67);
            txtCCCD.Margin = new Padding(2, 3, 2, 3);
            txtCCCD.Name = "txtCCCD";
            txtCCCD.Size = new Size(302, 27);
            txtCCCD.TabIndex = 15;
            // 
            // TimeEnd
            // 
            TimeEnd.Location = new Point(111, 321);
            TimeEnd.Margin = new Padding(2, 3, 2, 3);
            TimeEnd.Name = "TimeEnd";
            TimeEnd.Size = new Size(237, 27);
            TimeEnd.TabIndex = 14;
            // 
            // TimeStart
            // 
            TimeStart.Location = new Point(111, 279);
            TimeStart.Margin = new Padding(2, 3, 2, 3);
            TimeStart.Name = "TimeStart";
            TimeStart.Size = new Size(237, 27);
            TimeStart.TabIndex = 13;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(111, 236);
            txtPrice.Margin = new Padding(2, 3, 2, 3);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(302, 27);
            txtPrice.TabIndex = 12;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(111, 151);
            txtAddress.Margin = new Padding(2, 3, 2, 3);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(302, 27);
            txtAddress.TabIndex = 10;
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(111, 109);
            txtSDT.Margin = new Padding(2, 3, 2, 3);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(302, 27);
            txtSDT.TabIndex = 9;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(111, 24);
            txtFullName.Margin = new Padding(2, 3, 2, 3);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(302, 27);
            txtFullName.TabIndex = 8;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtEmail);
            groupBox2.Controls.Add(txtPassWord);
            groupBox2.Controls.Add(btnAdd);
            groupBox2.Controls.Add(btnUpdate);
            groupBox2.Controls.Add(txtNhapLai);
            groupBox2.Controls.Add(btnDelete);
            groupBox2.Controls.Add(label13);
            groupBox2.Controls.Add(txtUserName);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label9);
            groupBox2.Location = new Point(2, 423);
            groupBox2.Margin = new Padding(2, 3, 2, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(2, 3, 2, 3);
            groupBox2.Size = new Size(417, 237);
            groupBox2.TabIndex = 11;
            groupBox2.TabStop = false;
            groupBox2.Text = "Tài khoản đăng nhập hệ thống";
            // 
            // txtPassWord
            // 
            txtPassWord.Location = new Point(111, 62);
            txtPassWord.Margin = new Padding(2, 3, 2, 3);
            txtPassWord.Name = "txtPassWord";
            txtPassWord.Size = new Size(302, 27);
            txtPassWord.TabIndex = 17;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAdd.BackColor = Color.PowderBlue;
            btnAdd.Location = new Point(11, 176);
            btnAdd.Margin = new Padding(2, 3, 2, 3);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(111, 27);
            btnAdd.TabIndex = 15;
            btnAdd.Text = "Thêm mới HĐ";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnUpdate.BackColor = Color.Gold;
            btnUpdate.Location = new Point(150, 176);
            btnUpdate.Margin = new Padding(2, 3, 2, 3);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(106, 27);
            btnUpdate.TabIndex = 16;
            btnUpdate.Text = "Cập Nhập";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDelete.BackColor = Color.Salmon;
            btnDelete.Location = new Point(289, 176);
            btnDelete.Margin = new Padding(2, 3, 2, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(82, 27);
            btnDelete.TabIndex = 17;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(111, 28);
            txtUserName.Margin = new Padding(2, 3, 2, 3);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(302, 27);
            txtUserName.TabIndex = 16;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(groupBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(groupBox2, 0, 1);
            tableLayoutPanel1.Location = new Point(9, 20);
            tableLayoutPanel1.Margin = new Padding(2, 3, 2, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 243F));
            tableLayoutPanel1.Size = new Size(424, 663);
            tableLayoutPanel1.TabIndex = 18;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dgvlistViewContract);
            groupBox3.Location = new Point(447, 93);
            groupBox3.Margin = new Padding(2, 3, 2, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(2, 3, 2, 3);
            groupBox3.Size = new Size(499, 596);
            groupBox3.TabIndex = 19;
            groupBox3.TabStop = false;
            groupBox3.Text = "Danh sách hợp đồng";
            // 
            // dgvlistViewContract
            // 
            dgvlistViewContract.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvlistViewContract.Location = new Point(0, 37);
            dgvlistViewContract.Margin = new Padding(2, 3, 2, 3);
            dgvlistViewContract.Name = "dgvlistViewContract";
            dgvlistViewContract.RowHeadersWidth = 62;
            dgvlistViewContract.Size = new Size(499, 553);
            dgvlistViewContract.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.HotTrack;
            button1.ForeColor = SystemColors.ButtonFace;
            button1.Location = new Point(449, 23);
            button1.Margin = new Padding(2, 3, 2, 3);
            button1.Name = "button1";
            button1.Size = new Size(89, 27);
            button1.TabIndex = 20;
            button1.Text = "Tìm kiếm";
            button1.UseVisualStyleBackColor = false;
            // 
            // textBox9
            // 
            textBox9.Location = new Point(555, 23);
            textBox9.Margin = new Padding(2, 3, 2, 3);
            textBox9.Name = "textBox9";
            textBox9.PlaceholderText = "Tìm kiếm theo tên,SĐT, CCCD";
            textBox9.Size = new Size(372, 27);
            textBox9.TabIndex = 21;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.HotTrack;
            button2.ForeColor = SystemColors.ButtonFace;
            button2.Location = new Point(449, 61);
            button2.Margin = new Padding(2, 3, 2, 3);
            button2.Name = "button2";
            button2.Size = new Size(89, 27);
            button2.TabIndex = 22;
            button2.Text = "Lọc";
            button2.UseVisualStyleBackColor = false;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(555, 63);
            comboBox1.Margin = new Padding(2, 3, 2, 3);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(205, 28);
            comboBox1.TabIndex = 23;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(7, 100);
            label12.Margin = new Padding(2, 0, 2, 0);
            label12.Name = "label12";
            label12.Size = new Size(91, 20);
            label12.TabIndex = 8;
            label12.Text = "Nhập lại MK";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(7, 135);
            label13.Margin = new Padding(2, 0, 2, 0);
            label13.Name = "label13";
            label13.Size = new Size(46, 20);
            label13.TabIndex = 9;
            label13.Text = "Email";
            // 
            // txtNhapLai
            // 
            txtNhapLai.Location = new Point(111, 96);
            txtNhapLai.Margin = new Padding(2, 3, 2, 3);
            txtNhapLai.Name = "txtNhapLai";
            txtNhapLai.Size = new Size(302, 27);
            txtNhapLai.TabIndex = 16;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(111, 130);
            txtEmail.Margin = new Padding(2, 3, 2, 3);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(302, 27);
            txtEmail.TabIndex = 17;
            // 
            // FormContract
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(955, 726);
            Controls.Add(comboBox1);
            Controls.Add(button2);
            Controls.Add(textBox9);
            Controls.Add(button1);
            Controls.Add(groupBox3);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(2, 3, 2, 3);
            Name = "FormContract";
            Text = "FormContract";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvlistViewContract).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private GroupBox groupBox1;
        private TextBox txtCCCD;
        private DateTimePicker TimeEnd;
        private DateTimePicker TimeStart;
        private TextBox txtPrice;
        private TextBox txtAddress;
        private TextBox txtSDT;
        private TextBox txtFullName;
        private GroupBox groupBox2;
        private TextBox txtPassWord;
        private TextBox txtUserName;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox groupBox3;
        private TextBox txtDeposit;
        private Label label11;
        private DataGridView dgvlistViewContract;
        private Button button1;
        private TextBox textBox9;
        private Button button2;
        private ComboBox comboBox1;
        private ComboBox cbRoom;
        private TextBox txtEmail;
        private TextBox txtNhapLai;
        private Label label13;
        private Label label12;
    }
}