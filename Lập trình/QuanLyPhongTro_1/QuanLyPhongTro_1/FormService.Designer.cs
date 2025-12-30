namespace QuanLyPhongTro_1
{
    partial class FormService
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
            txtServiceName = new TextBox();
            txtPrice = new TextBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            dgServiceLists = new DataGridView();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgServiceLists).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 52);
            label1.Name = "label1";
            label1.Size = new Size(100, 25);
            label1.TabIndex = 0;
            label1.Text = "Tên dịch vụ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 95);
            label2.Name = "label2";
            label2.Size = new Size(99, 25);
            label2.TabIndex = 1;
            label2.Text = "Giá dịch vụ";
            // 
            // txtServiceName
            // 
            txtServiceName.Location = new Point(120, 52);
            txtServiceName.Name = "txtServiceName";
            txtServiceName.Size = new Size(398, 31);
            txtServiceName.TabIndex = 2;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(120, 95);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(398, 31);
            txtPrice.TabIndex = 3;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAdd.BackColor = Color.PowderBlue;
            btnAdd.Location = new Point(7, 160);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(100, 34);
            btnAdd.TabIndex = 18;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnUpdate.BackColor = Color.Gold;
            btnUpdate.Location = new Point(120, 160);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(111, 34);
            btnUpdate.TabIndex = 19;
            btnUpdate.Text = "Cập Nhập";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDelete.BackColor = Color.Salmon;
            btnDelete.Location = new Point(255, 160);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(103, 34);
            btnDelete.TabIndex = 20;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(btnUpdate);
            groupBox1.Controls.Add(btnAdd);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtPrice);
            groupBox1.Controls.Add(txtServiceName);
            groupBox1.Location = new Point(37, 30);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(644, 224);
            groupBox1.TabIndex = 21;
            groupBox1.TabStop = false;
            groupBox1.Text = "Chi tiết dịch vụ";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgServiceLists);
            groupBox2.Location = new Point(37, 273);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(647, 281);
            groupBox2.TabIndex = 22;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách dịch vụ";
            // 
            // dgServiceLists
            // 
            dgServiceLists.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgServiceLists.Location = new Point(0, 30);
            dgServiceLists.Name = "dgServiceLists";
            dgServiceLists.RowHeadersWidth = 62;
            dgServiceLists.Size = new Size(647, 251);
            dgServiceLists.TabIndex = 0;
            // 
            // FormService
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(713, 566);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FormService";
            Text = "FormService";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgServiceLists).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtServiceName;
        private TextBox txtPrice;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private DataGridView dgServiceLists;
    }
}