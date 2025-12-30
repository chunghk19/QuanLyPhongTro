namespace QuanLyPhongTro_1
{
    partial class FormUserProfile
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
            txtNgayTao = new TextBox();
            txtTrangThai = new TextBox();
            txtVaiTro = new TextBox();
            txtEmail = new TextBox();
            label2 = new Label();
            label1 = new Label();
            txtTenDangNhap = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            button1 = new Button();
            button2 = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80.5F));
            tableLayoutPanel1.Controls.Add(button2, 0, 5);
            tableLayoutPanel1.Controls.Add(txtNgayTao, 1, 4);
            tableLayoutPanel1.Controls.Add(txtTrangThai, 1, 3);
            tableLayoutPanel1.Controls.Add(txtVaiTro, 1, 2);
            tableLayoutPanel1.Controls.Add(txtEmail, 1, 1);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(txtTenDangNhap, 1, 0);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(label4, 0, 3);
            tableLayoutPanel1.Controls.Add(label5, 0, 4);
            tableLayoutPanel1.Controls.Add(button1, 1, 5);
            tableLayoutPanel1.Location = new Point(21, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.Size = new Size(715, 383);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // txtNgayTao
            // 
            txtNgayTao.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtNgayTao.Location = new Point(142, 281);
            txtNgayTao.Name = "txtNgayTao";
            txtNgayTao.ReadOnly = true;
            txtNgayTao.Size = new Size(485, 31);
            txtNgayTao.TabIndex = 9;
            // 
            // txtTrangThai
            // 
            txtTrangThai.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtTrangThai.Location = new Point(142, 218);
            txtTrangThai.Name = "txtTrangThai";
            txtTrangThai.ReadOnly = true;
            txtTrangThai.Size = new Size(485, 31);
            txtTrangThai.TabIndex = 8;
            // 
            // txtVaiTro
            // 
            txtVaiTro.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtVaiTro.Location = new Point(142, 155);
            txtVaiTro.Name = "txtVaiTro";
            txtVaiTro.ReadOnly = true;
            txtVaiTro.Size = new Size(485, 31);
            txtVaiTro.TabIndex = 7;
            // 
            // txtEmail
            // 
            txtEmail.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtEmail.Location = new Point(142, 92);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(485, 31);
            txtEmail.TabIndex = 6;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new Point(3, 101);
            label2.Name = "label2";
            label2.Size = new Size(58, 25);
            label2.TabIndex = 2;
            label2.Text = "Email:";
            label2.TextAlign = ContentAlignment.BottomRight;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(3, 38);
            label1.Name = "label1";
            label1.Size = new Size(133, 25);
            label1.TabIndex = 0;
            label1.Text = "Tên đăng nhập:";
            label1.TextAlign = ContentAlignment.BottomRight;
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtTenDangNhap.Location = new Point(142, 29);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.ReadOnly = true;
            txtTenDangNhap.Size = new Size(485, 31);
            txtTenDangNhap.TabIndex = 1;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Location = new Point(3, 164);
            label3.Name = "label3";
            label3.Size = new Size(67, 25);
            label3.TabIndex = 3;
            label3.Text = "Vai trò:";
            label3.TextAlign = ContentAlignment.BottomRight;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Location = new Point(3, 227);
            label4.Name = "label4";
            label4.Size = new Size(89, 25);
            label4.TabIndex = 4;
            label4.Text = "Trạng thái";
            label4.TextAlign = ContentAlignment.BottomRight;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Location = new Point(3, 290);
            label5.Name = "label5";
            label5.Size = new Size(85, 25);
            label5.TabIndex = 5;
            label5.Text = "Ngày tạo";
            label5.TextAlign = ContentAlignment.BottomRight;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button1.BackColor = Color.Red;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(142, 346);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 10;
            button1.Text = "Thoát";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button2.BackColor = SystemColors.MenuHighlight;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.ButtonHighlight;
            button2.Location = new Point(3, 346);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 11;
            button2.Text = "Cập nhập";
            button2.UseVisualStyleBackColor = false;
            // 
            // FormUserProfile
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(748, 448);
            Controls.Add(tableLayoutPanel1);
            Name = "FormUserProfile";
            Text = "FormUserProfile";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private TextBox txtNgayTao;
        private TextBox txtTrangThai;
        private TextBox txtVaiTro;
        private TextBox txtEmail;
        private Label label2;
        private TextBox txtTenDangNhap;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button button1;
        private Button button2;
    }
}