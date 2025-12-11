namespace QLPhongTro
{
    partial class dgDSHD
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
            this.txtCCCD = new System.Windows.Forms.TextBox();
            this.btnSeach = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvDanhSachHD = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnCapNhap = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachHD)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Căn cước công dân: ";
            // 
            // txtCCCD
            // 
            this.txtCCCD.Location = new System.Drawing.Point(207, 55);
            this.txtCCCD.Name = "txtCCCD";
            this.txtCCCD.Size = new System.Drawing.Size(341, 26);
            this.txtCCCD.TabIndex = 1;
            // 
            // btnSeach
            // 
            this.btnSeach.Location = new System.Drawing.Point(585, 49);
            this.btnSeach.Name = "btnSeach";
            this.btnSeach.Size = new System.Drawing.Size(72, 33);
            this.btnSeach.TabIndex = 2;
            this.btnSeach.Text = "Tìm";
            this.btnSeach.UseVisualStyleBackColor = true;
            this.btnSeach.Click += new System.EventHandler(this.btnSeach_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Danh sách hợp đồng";
            // 
            // dgvDanhSachHD
            // 
            this.dgvDanhSachHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachHD.Location = new System.Drawing.Point(50, 150);
            this.dgvDanhSachHD.Name = "dgvDanhSachHD";
            this.dgvDanhSachHD.RowHeadersWidth = 62;
            this.dgvDanhSachHD.RowTemplate.Height = 28;
            this.dgvDanhSachHD.Size = new System.Drawing.Size(1069, 540);
            this.dgvDanhSachHD.TabIndex = 4;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(50, 712);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(150, 33);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Thêm hợp đồng";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(226, 712);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(150, 33);
            this.btnSua.TabIndex = 6;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnCapNhap
            // 
            this.btnCapNhap.Location = new System.Drawing.Point(398, 712);
            this.btnCapNhap.Name = "btnCapNhap";
            this.btnCapNhap.Size = new System.Drawing.Size(150, 33);
            this.btnCapNhap.TabIndex = 7;
            this.btnCapNhap.Text = "Cập nhập";
            this.btnCapNhap.UseVisualStyleBackColor = true;
            // 
            // dgDSHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1157, 784);
            this.Controls.Add(this.btnCapNhap);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvDanhSachHD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSeach);
            this.Controls.Add(this.txtCCCD);
            this.Controls.Add(this.label1);
            this.Name = "dgDSHD";
            this.Text = "DanhSachHD";
            this.Load += new System.EventHandler(this.DanhSachHD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachHD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCCCD;
        private System.Windows.Forms.Button btnSeach;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvDanhSachHD;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnCapNhap;
    }
}