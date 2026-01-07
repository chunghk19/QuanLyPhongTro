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
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new Point(3, 125);
            label2.Name = "label2";
            label2.Size = new Size(76, 25);
            label2.TabIndex = 27;
            label2.Text = "Từ ngày";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Location = new Point(456, 125);
            label3.Name = "label3";
            label3.Size = new Size(88, 25);
            label3.TabIndex = 28;
            label3.Text = "Đến ngày";
            // 
            // dpStartDay
            // 
            dpStartDay.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            dpStartDay.Location = new Point(121, 116);
            dpStartDay.Name = "dpStartDay";
            dpStartDay.Size = new Size(266, 31);
            dpStartDay.TabIndex = 29;
            // 
            // dpEndDay
            // 
            dpEndDay.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            dpEndDay.Location = new Point(585, 116);
            dpEndDay.Name = "dpEndDay";
            dpEndDay.Size = new Size(263, 31);
            dpEndDay.TabIndex = 30;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Location = new Point(3, 175);
            label4.Name = "label4";
            label4.Size = new Size(95, 25);
            label4.TabIndex = 31;
            label4.Text = "Số điện cũ";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Location = new Point(456, 175);
            label5.Name = "label5";
            label5.Size = new Size(101, 25);
            label5.TabIndex = 32;
            label5.Text = "Số nước cũ";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label6.AutoSize = true;
            label6.Location = new Point(3, 225);
            label6.Name = "label6";
            label6.Size = new Size(108, 25);
            label6.TabIndex = 33;
            label6.Text = "Số điện mới";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label7.AutoSize = true;
            label7.Location = new Point(456, 225);
            label7.Name = "label7";
            label7.Size = new Size(114, 25);
            label7.TabIndex = 34;
            label7.Text = "Số nước mới";
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnExit.BackColor = Color.Gold;
            btnExit.Location = new Point(121, 331);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(111, 34);
            btnExit.TabIndex = 36;
            btnExit.Text = "Thoát";
            btnExit.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAdd.BackColor = Color.PowderBlue;
            btnAdd.Location = new Point(3, 331);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(100, 34);
            btnAdd.TabIndex = 35;
            btnAdd.Text = "Lưu";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // txtRoomSearch
            // 
            txtRoomSearch.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtRoomSearch.Location = new Point(121, 16);
            txtRoomSearch.Name = "txtRoomSearch";
            txtRoomSearch.PlaceholderText = "Tên phòng,...";
            txtRoomSearch.Size = new Size(329, 31);
            txtRoomSearch.TabIndex = 26;
            txtRoomSearch.TextChanged += textBox1_TextChanged;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button2.BackColor = SystemColors.HotTrack;
            button2.ForeColor = SystemColors.ButtonFace;
            button2.Location = new Point(3, 7);
            button2.Name = "button2";
            button2.Size = new Size(112, 40);
            button2.TabIndex = 25;
            button2.Text = "Tìm kiếm";
            button2.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45.70259F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.59891F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 36.6984978F));
            tableLayoutPanel1.Controls.Add(button2, 0, 0);
            tableLayoutPanel1.Controls.Add(btnExit, 1, 6);
            tableLayoutPanel1.Controls.Add(label1, 0, 1);
            tableLayoutPanel1.Controls.Add(btnAdd, 0, 6);
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
            tableLayoutPanel1.Location = new Point(40, 29);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 7;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.Size = new Size(851, 368);
            tableLayoutPanel1.TabIndex = 37;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(3, 75);
            label1.Name = "label1";
            label1.Size = new Size(96, 25);
            label1.TabIndex = 24;
            label1.Text = "Tên phòng";
            // 
            // cbRoomSearch
            // 
            cbRoomSearch.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cbRoomSearch.FormattingEnabled = true;
            cbRoomSearch.Location = new Point(121, 64);
            cbRoomSearch.Name = "cbRoomSearch";
            cbRoomSearch.Size = new Size(329, 33);
            cbRoomSearch.TabIndex = 27;
            // 
            // txtElectricOld
            // 
            txtElectricOld.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtElectricOld.Location = new Point(121, 166);
            txtElectricOld.Name = "txtElectricOld";
            txtElectricOld.Size = new Size(266, 31);
            txtElectricOld.TabIndex = 37;
            // 
            // txtElectricNew
            // 
            txtElectricNew.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtElectricNew.Location = new Point(121, 216);
            txtElectricNew.Name = "txtElectricNew";
            txtElectricNew.Size = new Size(266, 31);
            txtElectricNew.TabIndex = 38;
            // 
            // txtWaterOld
            // 
            txtWaterOld.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtWaterOld.Location = new Point(585, 166);
            txtWaterOld.Name = "txtWaterOld";
            txtWaterOld.Size = new Size(263, 31);
            txtWaterOld.TabIndex = 39;
            // 
            // txtWaterNew
            // 
            txtWaterNew.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtWaterNew.Location = new Point(585, 216);
            txtWaterNew.Name = "txtWaterNew";
            txtWaterNew.Size = new Size(263, 31);
            txtWaterNew.TabIndex = 40;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label8.AutoSize = true;
            label8.Location = new Point(3, 275);
            label8.Name = "label8";
            label8.Size = new Size(95, 25);
            label8.TabIndex = 41;
            label8.Text = "Số điện TT";
            // 
            // txtElectricCost
            // 
            txtElectricCost.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtElectricCost.Location = new Point(121, 266);
            txtElectricCost.Name = "txtElectricCost";
            txtElectricCost.ReadOnly = true;
            txtElectricCost.Size = new Size(266, 31);
            txtElectricCost.TabIndex = 42;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label9.AutoSize = true;
            label9.Location = new Point(456, 275);
            label9.Name = "label9";
            label9.Size = new Size(101, 25);
            label9.TabIndex = 43;
            label9.Text = "Số nước TT";
            // 
            // txtWaterCost
            // 
            txtWaterCost.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtWaterCost.Location = new Point(585, 266);
            txtWaterCost.Name = "txtWaterCost";
            txtWaterCost.ReadOnly = true;
            txtWaterCost.Size = new Size(263, 31);
            txtWaterCost.TabIndex = 44;
            // 
            // FormConsumption
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(926, 475);
            Controls.Add(tableLayoutPanel1);
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
    }
}