namespace QuanLyPhongTro_1
{
    partial class FormLogin
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
            tableLayoutPanel1 = new TableLayoutPanel();
            txtMatKhau = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtTaiKhoan = new TextBox();
            btnLogin = new Button();
            btnExit = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 8;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.576086F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 2.173913F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.61413F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.Controls.Add(txtMatKhau, 2, 2);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(txtTaiKhoan, 2, 1);
            tableLayoutPanel1.Controls.Add(btnLogin, 2, 3);
            tableLayoutPanel1.Controls.Add(btnExit, 4, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 56.11111F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 43.88889F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 63F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 84F));
            tableLayoutPanel1.Size = new Size(589, 360);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // txtMatKhau
            // 
            tableLayoutPanel1.SetColumnSpan(txtMatKhau, 5);
            txtMatKhau.Dock = DockStyle.Fill;
            txtMatKhau.Location = new Point(148, 179);
            txtMatKhau.Margin = new Padding(2);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(360, 27);
            txtMatKhau.TabIndex = 4;
            txtMatKhau.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(label1, 8);
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label1.Location = new Point(2, 0);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(585, 99);
            label1.TabIndex = 0;
            label1.Text = "ĐĂNG NHẬP HỆ THỐNG";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(label2, 2);
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(2, 99);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(142, 78);
            label2.TabIndex = 1;
            label2.Text = "Tài khoản:";
            label2.TextAlign = ContentAlignment.TopRight;
            // 
            // label3
            // 
            label3.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(label3, 2);
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(2, 177);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(142, 63);
            label3.TabIndex = 2;
            label3.Text = "Mật khẩu:";
            label3.TextAlign = ContentAlignment.TopRight;
            // 
            // txtTaiKhoan
            // 
            tableLayoutPanel1.SetColumnSpan(txtTaiKhoan, 5);
            txtTaiKhoan.Dock = DockStyle.Fill;
            txtTaiKhoan.Location = new Point(148, 101);
            txtTaiKhoan.Margin = new Padding(2);
            txtTaiKhoan.Name = "txtTaiKhoan";
            txtTaiKhoan.Size = new Size(360, 27);
            txtTaiKhoan.TabIndex = 3;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = SystemColors.HotTrack;
            btnLogin.ForeColor = SystemColors.ButtonHighlight;
            btnLogin.Location = new Point(148, 242);
            btnLogin.Margin = new Padding(2);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(90, 27);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Đăng nhập";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += button1_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Red;
            btnExit.ForeColor = SystemColors.ButtonFace;
            btnExit.Location = new Point(257, 242);
            btnExit.Margin = new Padding(2);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(89, 27);
            btnExit.TabIndex = 6;
            btnExit.Text = "Thoát";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(589, 360);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(2);
            Name = "FormLogin";
            Text = "FormLogin";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtTaiKhoan;
        private TextBox txtMatKhau;
        private Button btnLogin;
        private Button btnExit;
    }
}