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
            txtEmail = new TextBox();
            txtPassWord = new TextBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            txtNhapLai = new TextBox();
            btnDelete = new Button();
            label13 = new Label();
            txtUserName = new TextBox();
            label12 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            groupBox3 = new GroupBox();
            dgvlistViewContract = new DataGridView();
            button1 = new Button();
            textBox9 = new TextBox();
            button2 = new Button();
            comboBox1 = new ComboBox();
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
            label1.Location = new Point(6, 181);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 0;
            label1.Text = "Giá phòng";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 22);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 1;
            label2.Text = "Họ và tên";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 85);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(28, 15);
            label3.TabIndex = 2;
            label3.Text = "SĐT";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 117);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(43, 15);
            label4.TabIndex = 3;
            label4.Text = "Địa chỉ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 149);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(69, 15);
            label5.TabIndex = 4;
            label5.Text = "Phòng thuê";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 212);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(78, 15);
            label6.TabIndex = 5;
            label6.Text = "Ngày bắt đầu";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 244);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(81, 15);
            label7.TabIndex = 6;
            label7.Text = "Ngày kết thúc";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 53);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(39, 15);
            label8.TabIndex = 7;
            label8.Text = "CCCD";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 25);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(59, 15);
            label9.TabIndex = 8;
            label9.Text = "Tài Khoản";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(6, 51);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new Size(57, 15);
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
            groupBox1.Location = new Point(2, 2);
            groupBox1.Margin = new Padding(2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2);
            groupBox1.Size = new Size(365, 304);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin hợp đồng";
            // 
            // cbRoom
            // 
            cbRoom.FormattingEnabled = true;
            cbRoom.Location = new Point(97, 146);
            cbRoom.Name = "cbRoom";
            cbRoom.Size = new Size(263, 23);
            cbRoom.TabIndex = 18;
            // 
            // txtDeposit
            // 
            txtDeposit.Location = new Point(97, 272);
            txtDeposit.Margin = new Padding(2);
            txtDeposit.Name = "txtDeposit";
            txtDeposit.Size = new Size(265, 23);
            txtDeposit.TabIndex = 17;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(6, 276);
            label11.Margin = new Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.Size = new Size(52, 15);
            label11.TabIndex = 16;
            label11.Text = "Tiền cọc";
            // 
            // txtCCCD
            // 
            txtCCCD.Location = new Point(97, 50);
            txtCCCD.Margin = new Padding(2);
            txtCCCD.Name = "txtCCCD";
            txtCCCD.Size = new Size(265, 23);
            txtCCCD.TabIndex = 15;
            // 
            // TimeEnd
            // 
            TimeEnd.Location = new Point(97, 241);
            TimeEnd.Margin = new Padding(2);
            TimeEnd.Name = "TimeEnd";
            TimeEnd.Size = new Size(208, 23);
            TimeEnd.TabIndex = 14;
            // 
            // TimeStart
            // 
            TimeStart.Location = new Point(97, 209);
            TimeStart.Margin = new Padding(2);
            TimeStart.Name = "TimeStart";
            TimeStart.Size = new Size(208, 23);
            TimeStart.TabIndex = 13;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(97, 177);
            txtPrice.Margin = new Padding(2);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(265, 23);
            txtPrice.TabIndex = 12;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(97, 113);
            txtAddress.Margin = new Padding(2);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(265, 23);
            txtAddress.TabIndex = 10;
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(97, 82);
            txtSDT.Margin = new Padding(2);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(265, 23);
            txtSDT.TabIndex = 9;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(97, 18);
            txtFullName.Margin = new Padding(2);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(265, 23);
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
            groupBox2.Location = new Point(2, 317);
            groupBox2.Margin = new Padding(2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(2);
            groupBox2.Size = new Size(365, 178);
            groupBox2.TabIndex = 11;
            groupBox2.TabStop = false;
            groupBox2.Text = "Tài khoản đăng nhập hệ thống";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(97, 98);
            txtEmail.Margin = new Padding(2);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(265, 23);
            txtEmail.TabIndex = 17;
            // 
            // txtPassWord
            // 
            txtPassWord.Location = new Point(97, 46);
            txtPassWord.Margin = new Padding(2);
            txtPassWord.Name = "txtPassWord";
            txtPassWord.Size = new Size(265, 23);
            txtPassWord.TabIndex = 17;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAdd.BackColor = Color.PowderBlue;
            btnAdd.Location = new Point(10, 132);
            btnAdd.Margin = new Padding(2);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(97, 32);
            btnAdd.TabIndex = 15;
            btnAdd.Text = "Thêm mới HĐ";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnUpdate.BackColor = Color.Gold;
            btnUpdate.Location = new Point(131, 132);
            btnUpdate.Margin = new Padding(2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(93, 32);
            btnUpdate.TabIndex = 16;
            btnUpdate.Text = "Cập Nhập";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // txtNhapLai
            // 
            txtNhapLai.Location = new Point(97, 72);
            txtNhapLai.Margin = new Padding(2);
            txtNhapLai.Name = "txtNhapLai";
            txtNhapLai.Size = new Size(265, 23);
            txtNhapLai.TabIndex = 16;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDelete.BackColor = Color.Salmon;
            btnDelete.Location = new Point(253, 132);
            btnDelete.Margin = new Padding(2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(72, 32);
            btnDelete.TabIndex = 17;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(6, 101);
            label13.Margin = new Padding(2, 0, 2, 0);
            label13.Name = "label13";
            label13.Size = new Size(36, 15);
            label13.TabIndex = 9;
            label13.Text = "Email";
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(97, 21);
            txtUserName.Margin = new Padding(2);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(265, 23);
            txtUserName.TabIndex = 16;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(6, 75);
            label12.Margin = new Padding(2, 0, 2, 0);
            label12.Name = "label12";
            label12.Size = new Size(72, 15);
            label12.TabIndex = 8;
            label12.Text = "Nhập lại MK";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(groupBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(groupBox2, 0, 1);
            tableLayoutPanel1.Location = new Point(8, 15);
            tableLayoutPanel1.Margin = new Padding(2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 182F));
            tableLayoutPanel1.Size = new Size(371, 497);
            tableLayoutPanel1.TabIndex = 18;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dgvlistViewContract);
            groupBox3.Location = new Point(391, 70);
            groupBox3.Margin = new Padding(2);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(2);
            groupBox3.Size = new Size(671, 447);
            groupBox3.TabIndex = 19;
            groupBox3.TabStop = false;
            groupBox3.Text = "Danh sách hợp đồng";
            // 
            // dgvlistViewContract
            // 
            dgvlistViewContract.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvlistViewContract.Dock = DockStyle.Fill;
            dgvlistViewContract.Location = new Point(2, 18);
            dgvlistViewContract.Margin = new Padding(2);
            dgvlistViewContract.Name = "dgvlistViewContract";
            dgvlistViewContract.RowHeadersWidth = 62;
            dgvlistViewContract.Size = new Size(667, 427);
            dgvlistViewContract.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.HotTrack;
            button1.ForeColor = SystemColors.ButtonFace;
            button1.Location = new Point(393, 17);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(78, 25);
            button1.TabIndex = 20;
            button1.Text = "Tìm kiếm";
            button1.UseVisualStyleBackColor = false;
            // 
            // textBox9
            // 
            textBox9.Location = new Point(486, 17);
            textBox9.Margin = new Padding(2);
            textBox9.Name = "textBox9";
            textBox9.PlaceholderText = "Tìm kiếm theo tên,SĐT, CCCD";
            textBox9.Size = new Size(326, 23);
            textBox9.TabIndex = 21;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.HotTrack;
            button2.ForeColor = SystemColors.ButtonFace;
            button2.Location = new Point(393, 46);
            button2.Margin = new Padding(2);
            button2.Name = "button2";
            button2.Size = new Size(78, 24);
            button2.TabIndex = 22;
            button2.Text = "Lọc";
            button2.UseVisualStyleBackColor = false;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(486, 47);
            comboBox1.Margin = new Padding(2);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(180, 23);
            comboBox1.TabIndex = 23;
            // 
            // FormContract
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1137, 544);
            Controls.Add(comboBox1);
            Controls.Add(button2);
            Controls.Add(textBox9);
            Controls.Add(button1);
            Controls.Add(groupBox3);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(2);
            Name = "FormContract";
            Text = "FormContract";
            Load += FormContract_Load;
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