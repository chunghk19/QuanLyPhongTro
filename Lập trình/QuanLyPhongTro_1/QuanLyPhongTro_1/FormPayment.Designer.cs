namespace QuanLyPhongTro_1
{
    partial class FormPayment
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
            txtRoomSearch = new TextBox();
            button2 = new Button();
            cbSelectRoom = new ComboBox();
            label2 = new Label();
            txtTenant = new TextBox();
            label3 = new Label();
            label4 = new Label();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            label5 = new Label();
            txtRoomPrice = new TextBox();
            label6 = new Label();
            txtWaterPrice = new TextBox();
            label8 = new Label();
            txtElectricPrice = new TextBox();
            label7 = new Label();
            txtServicePrice = new TextBox();
            groupBox1 = new GroupBox();
            btnExcel = new Button();
            btnExit = new Button();
            btnPayment = new Button();
            cbSelectPayment = new ComboBox();
            label10 = new Label();
            txtTotalPrice = new TextBox();
            label9 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(452, 81);
            label1.Name = "label1";
            label1.Size = new Size(96, 25);
            label1.TabIndex = 28;
            label1.Text = "Tên phòng";
            label1.Click += label1_Click;
            // 
            // txtRoomSearch
            // 
            txtRoomSearch.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtRoomSearch.Location = new Point(132, 75);
            txtRoomSearch.Name = "txtRoomSearch";
            txtRoomSearch.PlaceholderText = "Tên phòng,...";
            txtRoomSearch.Size = new Size(290, 31);
            txtRoomSearch.TabIndex = 30;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button2.BackColor = SystemColors.HotTrack;
            button2.ForeColor = SystemColors.ButtonFace;
            button2.Location = new Point(14, 70);
            button2.Name = "button2";
            button2.Size = new Size(112, 40);
            button2.TabIndex = 29;
            button2.Text = "Tìm kiếm";
            button2.UseVisualStyleBackColor = false;
            // 
            // cbSelectRoom
            // 
            cbSelectRoom.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cbSelectRoom.FormattingEnabled = true;
            cbSelectRoom.Location = new Point(570, 75);
            cbSelectRoom.Name = "cbSelectRoom";
            cbSelectRoom.Size = new Size(323, 33);
            cbSelectRoom.TabIndex = 31;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 135);
            label2.Name = "label2";
            label2.Size = new Size(99, 25);
            label2.TabIndex = 32;
            label2.Text = "Khách thuê";
            // 
            // txtTenant
            // 
            txtTenant.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtTenant.Location = new Point(132, 127);
            txtTenant.Name = "txtTenant";
            txtTenant.ReadOnly = true;
            txtTenant.Size = new Size(290, 31);
            txtTenant.TabIndex = 33;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(452, 135);
            label3.Name = "label3";
            label3.Size = new Size(61, 25);
            label3.TabIndex = 34;
            label3.Text = "Tháng";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(696, 135);
            label4.Name = "label4";
            label4.Size = new Size(50, 25);
            label4.TabIndex = 35;
            label4.Text = "Năm";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(570, 129);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(120, 31);
            textBox2.TabIndex = 36;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(752, 129);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(141, 31);
            textBox3.TabIndex = 37;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(16, 191);
            label5.Name = "label5";
            label5.Size = new Size(102, 25);
            label5.TabIndex = 38;
            label5.Text = "Tiền phòng";
            // 
            // txtRoomPrice
            // 
            txtRoomPrice.Location = new Point(132, 185);
            txtRoomPrice.Name = "txtRoomPrice";
            txtRoomPrice.ReadOnly = true;
            txtRoomPrice.Size = new Size(290, 31);
            txtRoomPrice.TabIndex = 39;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(452, 188);
            label6.Name = "label6";
            label6.Size = new Size(89, 25);
            label6.TabIndex = 40;
            label6.Text = "Tiền nước";
            // 
            // txtWaterPrice
            // 
            txtWaterPrice.Location = new Point(570, 185);
            txtWaterPrice.Name = "txtWaterPrice";
            txtWaterPrice.ReadOnly = true;
            txtWaterPrice.Size = new Size(323, 31);
            txtWaterPrice.TabIndex = 41;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(16, 244);
            label8.Name = "label8";
            label8.Size = new Size(83, 25);
            label8.TabIndex = 42;
            label8.Text = "Tiền điện";
            // 
            // txtElectricPrice
            // 
            txtElectricPrice.Location = new Point(132, 238);
            txtElectricPrice.Name = "txtElectricPrice";
            txtElectricPrice.ReadOnly = true;
            txtElectricPrice.Size = new Size(290, 31);
            txtElectricPrice.TabIndex = 43;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(452, 241);
            label7.Name = "label7";
            label7.Size = new Size(112, 25);
            label7.TabIndex = 44;
            label7.Text = "Dịch vụ khác";
            // 
            // txtServicePrice
            // 
            txtServicePrice.Location = new Point(570, 238);
            txtServicePrice.Name = "txtServicePrice";
            txtServicePrice.ReadOnly = true;
            txtServicePrice.Size = new Size(323, 31);
            txtServicePrice.TabIndex = 45;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnExcel);
            groupBox1.Controls.Add(btnExit);
            groupBox1.Controls.Add(btnPayment);
            groupBox1.Controls.Add(cbSelectPayment);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(txtTotalPrice);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(txtServicePrice);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(txtElectricPrice);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(txtWaterPrice);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(txtRoomPrice);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtTenant);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(cbSelectRoom);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(txtRoomSearch);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(25, 37);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(920, 438);
            groupBox1.TabIndex = 32;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin thanh toán phòng";
            // 
            // btnExcel
            // 
            btnExcel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnExcel.BackColor = Color.Gold;
            btnExcel.Location = new Point(452, 298);
            btnExcel.Name = "btnExcel";
            btnExcel.Size = new Size(111, 34);
            btnExcel.TabIndex = 52;
            btnExcel.Text = "Xuất Excel";
            btnExcel.UseVisualStyleBackColor = false;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnExit.BackColor = Color.Salmon;
            btnExit.Location = new Point(570, 346);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(103, 34);
            btnExit.TabIndex = 51;
            btnExit.Text = "Thoát";
            btnExit.UseVisualStyleBackColor = false;
            // 
            // btnPayment
            // 
            btnPayment.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnPayment.BackColor = Color.PowderBlue;
            btnPayment.Location = new Point(452, 346);
            btnPayment.Name = "btnPayment";
            btnPayment.Size = new Size(112, 34);
            btnPayment.TabIndex = 50;
            btnPayment.Text = "Thanh toán";
            btnPayment.UseVisualStyleBackColor = false;
            // 
            // cbSelectPayment
            // 
            cbSelectPayment.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cbSelectPayment.FormattingEnabled = true;
            cbSelectPayment.Location = new Point(136, 348);
            cbSelectPayment.Name = "cbSelectPayment";
            cbSelectPayment.Size = new Size(286, 33);
            cbSelectPayment.TabIndex = 49;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(16, 351);
            label10.Name = "label10";
            label10.Size = new Size(112, 25);
            label10.TabIndex = 48;
            label10.Text = "Hình thức TT";
            // 
            // txtTotalPrice
            // 
            txtTotalPrice.Location = new Point(136, 297);
            txtTotalPrice.Name = "txtTotalPrice";
            txtTotalPrice.ReadOnly = true;
            txtTotalPrice.Size = new Size(286, 31);
            txtTotalPrice.TabIndex = 47;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(16, 303);
            label9.Name = "label9";
            label9.Size = new Size(94, 25);
            label9.TabIndex = 46;
            label9.Text = "Tổng tiền";
            // 
            // FormPayment
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(965, 515);
            Controls.Add(groupBox1);
            Name = "FormPayment";
            Text = "FormPayment";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private TextBox txtRoomSearch;
        private Button button2;
        private ComboBox cbSelectRoom;
        private Label label2;
        private TextBox txtTenant;
        private Label label3;
        private Label label4;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label label5;
        private TextBox txtRoomPrice;
        private Label label6;
        private TextBox txtWaterPrice;
        private Label label8;
        private TextBox txtElectricPrice;
        private Label label7;
        private TextBox txtServicePrice;
        private GroupBox groupBox1;
        private Label label9;
        private ComboBox cbSelectPayment;
        private Label label10;
        private TextBox txtTotalPrice;
        private Button btnExit;
        private Button btnPayment;
        private Button btnExcel;
    }
}