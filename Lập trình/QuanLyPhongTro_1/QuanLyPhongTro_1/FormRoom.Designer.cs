namespace QuanLyPhongTro_1
{
    partial class FormRoom
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
            dgRoomLists = new DataGridView();
            label9 = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtRoomName = new TextBox();
            txtArea = new TextBox();
            txtRoomRate = new TextBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnSearch = new Button();
            txtSearch = new TextBox();
            label5 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            cbStatus = new ComboBox();
            panel1 = new Panel();
            clService = new CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)dgRoomLists).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgRoomLists
            // 
            dgRoomLists.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgRoomLists.Location = new Point(3, 28);
            dgRoomLists.Name = "dgRoomLists";
            dgRoomLists.RowHeadersWidth = 62;
            dgRoomLists.Size = new Size(861, 418);
            dgRoomLists.TabIndex = 0;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(0, 0);
            label9.Name = "label9";
            label9.Size = new Size(156, 25);
            label9.TabIndex = 1;
            label9.Text = "Danh sách phòng:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Bottom;
            label1.Location = new Point(12, 83);
            label1.Margin = new Padding(12, 0, 3, 0);
            label1.Name = "label1";
            label1.Size = new Size(104, 25);
            label1.TabIndex = 0;
            label1.Text = "Tên Phòng";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(14, 137);
            label2.Margin = new Padding(3, 0, 10, 0);
            label2.Name = "label2";
            label2.Size = new Size(95, 25);
            label2.TabIndex = 1;
            label2.Text = "Giá phòng";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Bottom;
            label3.Location = new Point(499, 83);
            label3.Name = "label3";
            label3.Size = new Size(103, 25);
            label3.TabIndex = 2;
            label3.Text = "Diện tích";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Bottom;
            label4.Location = new Point(499, 137);
            label4.Name = "label4";
            label4.Size = new Size(103, 25);
            label4.TabIndex = 3;
            label4.Text = "Trạng thái";
            label4.Click += label4_Click;
            // 
            // txtRoomName
            // 
            txtRoomName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtRoomName.Location = new Point(122, 74);
            txtRoomName.Name = "txtRoomName";
            txtRoomName.Size = new Size(342, 31);
            txtRoomName.TabIndex = 4;
            // 
            // txtArea
            // 
            txtArea.Dock = DockStyle.Bottom;
            txtArea.Location = new Point(608, 74);
            txtArea.Name = "txtArea";
            txtArea.Size = new Size(250, 31);
            txtArea.TabIndex = 5;
            // 
            // txtRoomRate
            // 
            txtRoomRate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtRoomRate.Location = new Point(122, 128);
            txtRoomRate.Name = "txtRoomRate";
            txtRoomRate.Size = new Size(342, 31);
            txtRoomRate.TabIndex = 7;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.PowderBlue;
            btnAdd.Dock = DockStyle.Bottom;
            btnAdd.Location = new Point(499, 179);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(103, 34);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.Gold;
            btnUpdate.Dock = DockStyle.Bottom;
            btnUpdate.Location = new Point(499, 233);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(103, 34);
            btnUpdate.TabIndex = 9;
            btnUpdate.Text = "Sửa";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Salmon;
            btnDelete.Dock = DockStyle.Bottom;
            btnDelete.Location = new Point(499, 291);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(103, 34);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.MediumBlue;
            btnSearch.Dock = DockStyle.Bottom;
            btnSearch.ForeColor = SystemColors.ButtonFace;
            btnSearch.Location = new Point(3, 17);
            btnSearch.Margin = new Padding(3, 3, 10, 3);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(106, 34);
            btnSearch.TabIndex = 11;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            tableLayoutPanel1.SetColumnSpan(txtSearch, 3);
            txtSearch.Dock = DockStyle.Bottom;
            txtSearch.Location = new Point(122, 20);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Nhập tên phòng cần tìm......";
            txtSearch.Size = new Size(736, 31);
            txtSearch.TabIndex = 12;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Location = new Point(15, 191);
            label5.Margin = new Padding(15, 0, 3, 0);
            label5.Name = "label5";
            label5.Size = new Size(71, 25);
            label5.TabIndex = 14;
            label5.Text = "Dịch vụ";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.9372826F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 43.90244F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.7758417F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 29.616724F));
            tableLayoutPanel1.Controls.Add(cbStatus, 3, 2);
            tableLayoutPanel1.Controls.Add(btnSearch, 0, 0);
            tableLayoutPanel1.Controls.Add(btnDelete, 2, 5);
            tableLayoutPanel1.Controls.Add(txtSearch, 1, 0);
            tableLayoutPanel1.Controls.Add(label5, 0, 3);
            tableLayoutPanel1.Controls.Add(btnUpdate, 2, 4);
            tableLayoutPanel1.Controls.Add(label1, 0, 1);
            tableLayoutPanel1.Controls.Add(txtRoomName, 1, 1);
            tableLayoutPanel1.Controls.Add(btnAdd, 2, 3);
            tableLayoutPanel1.Controls.Add(label2, 0, 2);
            tableLayoutPanel1.Controls.Add(txtRoomRate, 1, 2);
            tableLayoutPanel1.Controls.Add(label3, 2, 1);
            tableLayoutPanel1.Controls.Add(txtArea, 3, 1);
            tableLayoutPanel1.Controls.Add(label4, 2, 2);
            tableLayoutPanel1.Controls.Add(clService, 1, 3);
            tableLayoutPanel1.Location = new Point(45, 31);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(861, 328);
            tableLayoutPanel1.TabIndex = 15;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // cbStatus
            // 
            cbStatus.Dock = DockStyle.Bottom;
            cbStatus.FormattingEnabled = true;
            cbStatus.Location = new Point(608, 126);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(250, 33);
            cbStatus.TabIndex = 16;
            // 
            // panel1
            // 
            panel1.Controls.Add(label9);
            panel1.Controls.Add(dgRoomLists);
            panel1.Location = new Point(45, 381);
            panel1.Name = "panel1";
            panel1.Size = new Size(861, 449);
            panel1.TabIndex = 16;
            // 
            // clService
            // 
            clService.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            clService.FormattingEnabled = true;
            clService.Location = new Point(122, 181);
            clService.Name = "clService";
            tableLayoutPanel1.SetRowSpan(clService, 3);
            clService.Size = new Size(342, 144);
            clService.TabIndex = 17;
            // 
            // FormRoom
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(950, 842);
            Controls.Add(panel1);
            Controls.Add(tableLayoutPanel1);
            Name = "FormRoom";
            Text = "FormRoom";
            Load += FormRoom_Load;
            ((System.ComponentModel.ISupportInitialize)dgRoomLists).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgRoomLists;
        private Label label9;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtRoomName;
        private TextBox txtArea;
        private TextBox txtRoomRate;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnSearch;
        private TextBox txtSearch;
        private Label label5;
        private TableLayoutPanel tableLayoutPanel1;
        private ComboBox cbStatus;
        private Panel panel1;
        private CheckedListBox clService;
    }
}