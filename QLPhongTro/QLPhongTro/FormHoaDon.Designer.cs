namespace QLPhongTro
{
    partial class FormHoaDon
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtTime = new System.Windows.Forms.DateTimePicker();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.cbPhong = new System.Windows.Forms.ComboBox();
            this.btnHienThi = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSoDienCu = new System.Windows.Forms.TextBox();
            this.txtSoDienMoi = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSoNuocCu = new System.Windows.Forms.TextBox();
            this.txtSoNuocMoi = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtGiaDien = new System.Windows.Forms.TextBox();
            this.txtGiaNuoc = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(269, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Phòng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(269, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Thời Gian";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(269, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 25);
            this.label3.TabIndex = 2;
            // 
            // dtTime
            // 
            this.dtTime.Location = new System.Drawing.Point(421, 154);
            this.dtTime.Name = "dtTime";
            this.dtTime.Size = new System.Drawing.Size(438, 31);
            this.dtTime.TabIndex = 4;
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDon.Location = new System.Drawing.Point(12, 423);
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.RowHeadersWidth = 82;
            this.dgvHoaDon.RowTemplate.Height = 33;
            this.dgvHoaDon.Size = new System.Drawing.Size(1763, 493);
            this.dgvHoaDon.TabIndex = 5;
            // 
            // cbPhong
            // 
            this.cbPhong.FormattingEnabled = true;
            this.cbPhong.Location = new System.Drawing.Point(421, 80);
            this.cbPhong.Name = "cbPhong";
            this.cbPhong.Size = new System.Drawing.Size(121, 33);
            this.cbPhong.TabIndex = 6;
            // 
            // btnHienThi
            // 
            this.btnHienThi.Location = new System.Drawing.Point(274, 355);
            this.btnHienThi.Name = "btnHienThi";
            this.btnHienThi.Size = new System.Drawing.Size(255, 50);
            this.btnHienThi.TabIndex = 7;
            this.btnHienThi.Text = "Hiển Thị";
            this.btnHienThi.UseVisualStyleBackColor = true;
            this.btnHienThi.Click += new System.EventHandler(this.btnHienThi_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(273, 235);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "Số điện cũ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(590, 232);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "Số điện mới";
            // 
            // txtSoDienCu
            // 
            this.txtSoDienCu.Location = new System.Drawing.Point(421, 229);
            this.txtSoDienCu.Name = "txtSoDienCu";
            this.txtSoDienCu.Size = new System.Drawing.Size(121, 31);
            this.txtSoDienCu.TabIndex = 10;
            // 
            // txtSoDienMoi
            // 
            this.txtSoDienMoi.Location = new System.Drawing.Point(726, 229);
            this.txtSoDienMoi.Name = "txtSoDienMoi";
            this.txtSoDienMoi.Size = new System.Drawing.Size(121, 31);
            this.txtSoDienMoi.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(272, 288);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 25);
            this.label6.TabIndex = 12;
            this.label6.Text = "Số nước cũ";
            // 
            // txtSoNuocCu
            // 
            this.txtSoNuocCu.Location = new System.Drawing.Point(421, 286);
            this.txtSoNuocCu.Name = "txtSoNuocCu";
            this.txtSoNuocCu.Size = new System.Drawing.Size(121, 31);
            this.txtSoNuocCu.TabIndex = 14;
            // 
            // txtSoNuocMoi
            // 
            this.txtSoNuocMoi.Location = new System.Drawing.Point(727, 287);
            this.txtSoNuocMoi.Name = "txtSoNuocMoi";
            this.txtSoNuocMoi.Size = new System.Drawing.Size(121, 31);
            this.txtSoNuocMoi.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(885, 235);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 25);
            this.label7.TabIndex = 16;
            this.label7.Text = "Giá điện";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(885, 293);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 25);
            this.label8.TabIndex = 17;
            this.label8.Text = "Giá nước";
            // 
            // txtGiaDien
            // 
            this.txtGiaDien.Location = new System.Drawing.Point(981, 227);
            this.txtGiaDien.Name = "txtGiaDien";
            this.txtGiaDien.Size = new System.Drawing.Size(100, 31);
            this.txtGiaDien.TabIndex = 18;
            this.txtGiaDien.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtGiaNuoc
            // 
            this.txtGiaNuoc.Location = new System.Drawing.Point(983, 285);
            this.txtGiaNuoc.Name = "txtGiaNuoc";
            this.txtGiaNuoc.Size = new System.Drawing.Size(100, 31);
            this.txtGiaNuoc.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(595, 287);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(131, 25);
            this.label9.TabIndex = 20;
            this.label9.Text = "Số nước mới";
            // 
            // FormHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2134, 1435);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtGiaNuoc);
            this.Controls.Add(this.txtGiaDien);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtSoNuocMoi);
            this.Controls.Add(this.txtSoNuocCu);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSoDienMoi);
            this.Controls.Add(this.txtSoDienCu);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnHienThi);
            this.Controls.Add(this.cbPhong);
            this.Controls.Add(this.dgvHoaDon);
            this.Controls.Add(this.dtTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormHoaDon";
            this.Text = "FormHoaDon";
            this.Load += new System.EventHandler(this.FormHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtTime;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.ComboBox cbPhong;
        private System.Windows.Forms.Button btnHienThi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSoDienCu;
        private System.Windows.Forms.TextBox txtSoDienMoi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSoNuocCu;
        private System.Windows.Forms.TextBox txtSoNuocMoi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtGiaDien;
        private System.Windows.Forms.TextBox txtGiaNuoc;
        private System.Windows.Forms.Label label9;
    }
}