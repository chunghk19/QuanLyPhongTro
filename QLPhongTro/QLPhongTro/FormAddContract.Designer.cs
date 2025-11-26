namespace QLPhongTro
{
    partial class FormAddContract
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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtAdd = new System.Windows.Forms.TextBox();
            this.dtpStartDay = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDay = new System.Windows.Forms.DateTimePicker();
            this.btnAddContract = new System.Windows.Forms.Button();
            this.cbSellectRoom = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Họ và tên";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số điện thoại";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Địa chỉ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Chọn phòng";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ngày bắt đầu";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 242);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Ngày kết thúc";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(174, 21);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(345, 26);
            this.txtFullName.TabIndex = 6;
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(174, 63);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(345, 26);
            this.txtSDT.TabIndex = 7;
            // 
            // txtAdd
            // 
            this.txtAdd.Location = new System.Drawing.Point(174, 105);
            this.txtAdd.Name = "txtAdd";
            this.txtAdd.Size = new System.Drawing.Size(345, 26);
            this.txtAdd.TabIndex = 8;
            // 
            // dtpStartDay
            // 
            this.dtpStartDay.Location = new System.Drawing.Point(174, 192);
            this.dtpStartDay.Name = "dtpStartDay";
            this.dtpStartDay.Size = new System.Drawing.Size(249, 26);
            this.dtpStartDay.TabIndex = 10;
            // 
            // dtpEndDay
            // 
            this.dtpEndDay.Location = new System.Drawing.Point(174, 235);
            this.dtpEndDay.Name = "dtpEndDay";
            this.dtpEndDay.Size = new System.Drawing.Size(249, 26);
            this.dtpEndDay.TabIndex = 12;
            // 
            // btnAddContract
            // 
            this.btnAddContract.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAddContract.Location = new System.Drawing.Point(39, 277);
            this.btnAddContract.Name = "btnAddContract";
            this.btnAddContract.Size = new System.Drawing.Size(99, 28);
            this.btnAddContract.TabIndex = 13;
            this.btnAddContract.Text = "Thêm mới";
            this.btnAddContract.UseVisualStyleBackColor = false;
            this.btnAddContract.Click += new System.EventHandler(this.btnAddContract_Click);
            // 
            // cbSellectRoom
            // 
            this.cbSellectRoom.FormattingEnabled = true;
            this.cbSellectRoom.Location = new System.Drawing.Point(174, 147);
            this.cbSellectRoom.Name = "cbSellectRoom";
            this.cbSellectRoom.Size = new System.Drawing.Size(345, 28);
            this.cbSellectRoom.TabIndex = 14;
            // 
            // FormAddContract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 407);
            this.Controls.Add(this.cbSellectRoom);
            this.Controls.Add(this.btnAddContract);
            this.Controls.Add(this.dtpEndDay);
            this.Controls.Add(this.dtpStartDay);
            this.Controls.Add(this.txtAdd);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormAddContract";
            this.Text = "FormAddContract";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TextBox txtAdd;
        private System.Windows.Forms.DateTimePicker dtpStartDay;
        private System.Windows.Forms.DateTimePicker dtpEndDay;
        private System.Windows.Forms.Button btnAddContract;
        private System.Windows.Forms.ComboBox cbSellectRoom;
    }
}