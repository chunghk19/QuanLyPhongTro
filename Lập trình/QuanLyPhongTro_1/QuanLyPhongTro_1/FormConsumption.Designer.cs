namespace QuanLyPhongTro_1
{
    partial class FormConsumption
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
            label2 = new Label();
            label3 = new Label();
            dpStartDay = new DateTimePicker();
            dpEndDay = new DateTimePicker();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            btnExit = new Button();
            btnAdd = new Button();
            txtRoomSearch = new TextBox();
            button2 = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            txtDonGiaDien = new TextBox();
            label1 = new Label();
            cbRoomSearch = new ComboBox();
            txtElectricOld = new TextBox();
            txtElectricNew = new TextBox();
            txtWaterOld = new TextBox();
            txtWaterNew = new TextBox();
            label8 = new Label();
            txtElectricCost = new TextBox();
            label9 = new Label();
            txtWaterCost = new TextBox();
            textBox1 = new TextBox();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            TxtDonGiaNuoc = new TextBox();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new Point(2, 100);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(62, 20);
            label2.TabIndex = 27;
            label2.Text = "Từ ngày";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Location = new Point(381, 100);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(72, 20);
            label3.TabIndex = 28;
            label3.Text = "Đến ngày";
            // 
            // dpStartDay
            // 
            dpStartDay.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            dpStartDay.Location = new Point(127, 91);
            dpStartDay.Margin = new Padding(2);
            dpStartDay.Name = "dpStartDay";
            dpStartDay.Size = new Size(214, 27);
            dpStartDay.TabIndex = 29;
            // 
            // dpEndDay
            // 
            dpEndDay.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            dpEndDay.Location = new Point(488, 91);
            dpEndDay.Margin = new Padding(2);
            dpEndDay.Name = "dpEndDay";
            dpEndDay.Size = new Size(191, 27);
            dpEndDay.TabIndex = 30;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Location = new Point(2, 140);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(78, 20);
            label4.TabIndex = 31;
            label4.Text = "Số điện cũ";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Location = new Point(381, 140);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(82, 20);
            label5.TabIndex = 32;
            label5.Text = "Số nước cũ";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label6.AutoSize = true;
            label6.Location = new Point(2, 180);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(89, 20);
            label6.TabIndex = 33;
            label6.Text = "Số điện mới";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label7.AutoSize = true;
            label7.Location = new Point(381, 180);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(93, 20);
            label7.TabIndex = 34;
            label7.Text = "Số nước mới";
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnExit.BackColor = Color.Gold;
            btnExit.Location = new Point(127, 331);
            btnExit.Margin = new Padding(2);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(89, 27);
            btnExit.TabIndex = 36;
            btnExit.Text = "Thoát";
            btnExit.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAdd.BackColor = Color.PowderBlue;
            btnAdd.Location = new Point(2, 331);
            btnAdd.Margin = new Padding(2);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(80, 27);
            btnAdd.TabIndex = 35;
            btnAdd.Text = "Lưu";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtRoomSearch
            // 
            txtRoomSearch.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtRoomSearch.Location = new Point(127, 11);
            txtRoomSearch.Margin = new Padding(2);
            txtRoomSearch.Name = "txtRoomSearch";
            txtRoomSearch.PlaceholderText = "Tên phòng,...";
            txtRoomSearch.Size = new Size(250, 27);
            txtRoomSearch.TabIndex = 26;
            txtRoomSearch.TextChanged += textBox1_TextChanged;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button2.BackColor = SystemColors.HotTrack;
            button2.ForeColor = SystemColors.ButtonFace;
            button2.Location = new Point(2, 6);
            button2.Margin = new Padding(2);
            button2.Name = "button2";
            button2.Size = new Size(90, 32);
            button2.TabIndex = 25;
            button2.Text = "Tìm kiếm";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45.70259F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.4244614F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34.892086F));
            tableLayoutPanel1.Controls.Add(txtDonGiaDien, 1, 6);
            tableLayoutPanel1.Controls.Add(button2, 0, 0);
            tableLayoutPanel1.Controls.Add(label1, 0, 1);
            tableLayoutPanel1.Controls.Add(txtRoomSearch, 1, 0);
            tableLayoutPanel1.Controls.Add(dpEndDay, 3, 2);
            tableLayoutPanel1.Controls.Add(cbRoomSearch, 1, 1);
            tableLayoutPanel1.Controls.Add(dpStartDay, 1, 2);
            tableLayoutPanel1.Controls.Add(label3, 2, 2);
            tableLayoutPanel1.Controls.Add(label2, 0, 2);
            tableLayoutPanel1.Controls.Add(label4, 0, 3);
            tableLayoutPanel1.Controls.Add(label6, 0, 4);
            tableLayoutPanel1.Controls.Add(label5, 2, 3);
            tableLayoutPanel1.Controls.Add(label7, 2, 4);
            tableLayoutPanel1.Controls.Add(txtElectricOld, 1, 3);
            tableLayoutPanel1.Controls.Add(txtElectricNew, 1, 4);
            tableLayoutPanel1.Controls.Add(txtWaterOld, 3, 3);
            tableLayoutPanel1.Controls.Add(txtWaterNew, 3, 4);
            tableLayoutPanel1.Controls.Add(label8, 0, 5);
            tableLayoutPanel1.Controls.Add(txtElectricCost, 1, 5);
            tableLayoutPanel1.Controls.Add(label9, 2, 5);
            tableLayoutPanel1.Controls.Add(txtWaterCost, 3, 5);
            tableLayoutPanel1.Controls.Add(btnAdd, 0, 8);
            tableLayoutPanel1.Controls.Add(btnExit, 1, 8);
            tableLayoutPanel1.Controls.Add(textBox1, 1, 7);
            tableLayoutPanel1.Controls.Add(label10, 0, 7);
            tableLayoutPanel1.Controls.Add(label11, 0, 6);
            tableLayoutPanel1.Controls.Add(label12, 2, 6);
            tableLayoutPanel1.Controls.Add(TxtDonGiaNuoc, 3, 6);
            tableLayoutPanel1.Location = new Point(31, 36);
            tableLayoutPanel1.Margin = new Padding(2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 9;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.Size = new Size(681, 355);
            tableLayoutPanel1.TabIndex = 37;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // txtDonGiaDien
            // 
            txtDonGiaDien.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtDonGiaDien.Location = new Point(127, 251);
            txtDonGiaDien.Margin = new Padding(2);
            txtDonGiaDien.Name = "txtDonGiaDien";
            txtDonGiaDien.Size = new Size(214, 27);
            txtDonGiaDien.TabIndex = 48;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(2, 60);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(79, 20);
            label1.TabIndex = 24;
            label1.Text = "Tên phòng";
            // 
            // cbRoomSearch
            // 
            cbRoomSearch.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cbRoomSearch.FormattingEnabled = true;
            cbRoomSearch.Location = new Point(127, 50);
            cbRoomSearch.Margin = new Padding(2);
            cbRoomSearch.Name = "cbRoomSearch";
            cbRoomSearch.Size = new Size(250, 28);
            cbRoomSearch.TabIndex = 27;
            cbRoomSearch.SelectedIndexChanged += cbRoomSearch_SelectedIndexChanged;
            // 
            // txtElectricOld
            // 
            txtElectricOld.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtElectricOld.Location = new Point(127, 131);
            txtElectricOld.Margin = new Padding(2);
            txtElectricOld.Name = "txtElectricOld";
            txtElectricOld.Size = new Size(214, 27);
            txtElectricOld.TabIndex = 37;
            // 
            // txtElectricNew
            // 
            txtElectricNew.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtElectricNew.Location = new Point(127, 171);
            txtElectricNew.Margin = new Padding(2);
            txtElectricNew.Name = "txtElectricNew";
            txtElectricNew.Size = new Size(214, 27);
            txtElectricNew.TabIndex = 38;
            // 
            // txtWaterOld
            // 
            txtWaterOld.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtWaterOld.Location = new Point(488, 131);
            txtWaterOld.Margin = new Padding(2);
            txtWaterOld.Name = "txtWaterOld";
            txtWaterOld.Size = new Size(191, 27);
            txtWaterOld.TabIndex = 39;
            // 
            // txtWaterNew
            // 
            txtWaterNew.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtWaterNew.Location = new Point(488, 171);
            txtWaterNew.Margin = new Padding(2);
            txtWaterNew.Name = "txtWaterNew";
            txtWaterNew.Size = new Size(191, 27);
            txtWaterNew.TabIndex = 40;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label8.AutoSize = true;
            label8.Location = new Point(2, 220);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(79, 20);
            label8.TabIndex = 41;
            label8.Text = "Số điện TT";
            // 
            // txtElectricCost
            // 
            txtElectricCost.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtElectricCost.Location = new Point(127, 211);
            txtElectricCost.Margin = new Padding(2);
            txtElectricCost.Name = "txtElectricCost";
            txtElectricCost.ReadOnly = true;
            txtElectricCost.Size = new Size(214, 27);
            txtElectricCost.TabIndex = 42;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label9.AutoSize = true;
            label9.Location = new Point(381, 220);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(83, 20);
            label9.TabIndex = 43;
            label9.Text = "Số nước TT";
            // 
            // txtWaterCost
            // 
            txtWaterCost.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtWaterCost.Location = new Point(488, 211);
            txtWaterCost.Margin = new Padding(2);
            txtWaterCost.Name = "txtWaterCost";
            txtWaterCost.ReadOnly = true;
            txtWaterCost.Size = new Size(191, 27);
            txtWaterCost.TabIndex = 44;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            textBox1.Location = new Point(128, 290);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(213, 27);
            textBox1.TabIndex = 45;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Dock = DockStyle.Bottom;
            label10.Location = new Point(3, 300);
            label10.Name = "label10";
            label10.Size = new Size(119, 20);
            label10.TabIndex = 46;
            label10.Text = "Chi phí phát sinh";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label11.AutoSize = true;
            label11.Location = new Point(2, 260);
            label11.Margin = new Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.Size = new Size(95, 20);
            label11.TabIndex = 31;
            label11.Text = "Đơn giá điện";
            label11.Click += label4_Click;
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label12.AutoSize = true;
            label12.Location = new Point(381, 260);
            label12.Margin = new Padding(2, 0, 2, 0);
            label12.Name = "label12";
            label12.Size = new Size(99, 20);
            label12.TabIndex = 31;
            label12.Text = "Đơn giá nước";
            label12.Click += label4_Click;
            // 
            // TxtDonGiaNuoc
            // 
            TxtDonGiaNuoc.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            TxtDonGiaNuoc.Location = new Point(488, 251);
            TxtDonGiaNuoc.Margin = new Padding(2);
            TxtDonGiaNuoc.Name = "TxtDonGiaNuoc";
            TxtDonGiaNuoc.Size = new Size(191, 27);
            TxtDonGiaNuoc.TabIndex = 39;
            // 
            // FormConsumption
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(741, 449);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(2);
            MaximizeBox = false;
            Name = "FormConsumption";
            Text = "FormConsumption";
            Load += FormConsumption_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label label2;
        private Label label3;
        private DateTimePicker dpStartDay;
        private DateTimePicker dpEndDay;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Button btnExit;
        private Button btnAdd;
        private TextBox txtRoomSearch;
        private Button button2;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private ComboBox cbRoomSearch;
        private TextBox txtElectricOld;
        private TextBox txtElectricNew;
        private TextBox txtWaterOld;
        private TextBox txtWaterNew;
        private Label label8;
        private TextBox txtElectricCost;
        private Label label9;
        private TextBox txtWaterCost;
        private TextBox textBox1;
        private Label label10;
        private TextBox txtDonGiaDien;
        private Label label11;
        private Label label12;
        private TextBox TxtDonGiaNuoc;
    }
}