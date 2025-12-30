using QuanLyPhongTro_1.Common;
namespace QuanLyPhongTro_1
{
    public partial class FormMDI : Form
    {
        public FormMDI()
        {
            InitializeComponent();
        }

        private void FormMDI_Load(object sender, EventArgs e)
        {
            PhanQuyenMenu();

        }
        private void PhanQuyenMenu()
        {
            if (AppSession.Role == "ADMIN")
            {
                // ADMIN: thấy hết
                mnQuanLy.Visible = true;
                mnHoaDon.Visible = true;
                mnBaoCao.Visible = true;
            }
            else if (AppSession.Role == "TENANT")
            {
                // TENANT: chỉ xem hóa đơn, thông tin cá nhân
                mnQuanLy.Visible = false;
                mnBaoCao.Visible = false;

                mnHoaDon.Visible = true;
            }
        }
        private void HienThiThongTinNguoiDung()
        {
            if (AppSession.Username != null)
            {
                lblUserInfo.Text = $"Xin chào: {AppSession.Username} ({AppSession.Role})";
            }
            else
            {
                lblUserInfo.Text = "Chưa đăng nhập";
            }
        }

        private void thôngTinNgườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUserProfile form = new FormUserProfile();
            form.MdiParent = this;
            form.Show();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChangePassword form = new FormChangePassword();
            form.MdiParent = this;
            form.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
           "Bạn có chắc muốn đăng xuất không?",
           "Đăng xuất",
           MessageBoxButtons.YesNo,
           MessageBoxIcon.Question
             );

            if (result == DialogResult.Yes)
            {
                // 1. Xóa session
                AppSession.Clear();

                // 2. Mở lại form đăng nhập
                FormLogin login = new FormLogin();
                login.Show();

                // 3. Đóng form chính (MDI)
                this.Close();
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
           "Bạn có chắc muốn đăng xuất không?",
           "Đăng xuất",
           MessageBoxButtons.YesNo,
           MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                // 1. Xóa session
                AppSession.Clear();

                // 2. Mở lại form đăng nhập
                FormLogin login = new FormLogin();
                login.Show();

                // 3. Đóng form chính (MDI)
                this.Close();
            }
        }

        private void phòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRoom fr = new FormRoom();
            fr.MdiParent = this;
            fr.Show();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }

        private void kháchThuêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTenant fr = new FormTenant();
            fr.MdiParent = this;
            fr.Show();
        }

        private void hợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormContract fr = new FormContract();
            fr.MdiParent = this;
            fr.Show();
        }

        private void dịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormService fr = new FormService();
            fr.MdiParent = this;
            fr.Show();
        }

        private void ghiĐiệnNướcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormConsumption fr = new FormConsumption();
            fr.MdiParent = this;
            fr.Show();
        }

        private void thanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPayment fr = new FormPayment();
            fr.MdiParent = this;
            fr.Show();
        }
    }
}
