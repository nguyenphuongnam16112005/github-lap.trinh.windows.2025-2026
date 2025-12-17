using KiemTraGiuaKy.QLTinhHinh;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace KiemTraGiuaKy
{
    public partial class Form1 : Form
    {
        private QLTinhHinh.QLTinhHinh dbContext;
        private string previousMaDP = string.Empty;
        public Form1()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private bool ValidateAndGetInput(out string MaDP, out string TenDP, out int SoCaNhiemMoi)
        {
            MaDP = null;
            TenDP = null;
            SoCaNhiemMoi = 0;

            if (string.IsNullOrWhiteSpace(txtMDP.Text) || string.IsNullOrWhiteSpace(txtTDP.Text) || string.IsNullOrWhiteSpace(txtSCN.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (txtMDP.Text.Length != 3)
            {
                MessageBox.Show("Mã Địa Phương phải có đúng 3 ký tự!",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (!int.TryParse(txtSCN.Text, out int soCA) || soCA < 0)
            {
                MessageBox.Show("Số ca nhiễm phải là số nguyên >= 0!",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            MaDP = txtMDP.Text;
            TenDP = txtTDP.Text;
            SoCaNhiemMoi = soCA;
            return true;
        }
        private void dgvTinhHinhDiaPhuong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvTinhHinhDiaPhuong.Rows.Count)
            {
                var row = dgvTinhHinhDiaPhuong.Rows[e.RowIndex];

                string MaDP = row.Cells["MaDP"].Value?.ToString();
                previousMaDP = MaDP;

                txtMDP.Text = MaDP;
                txtTDP.Text = row.Cells["TenDP"].Value?.ToString();
                txtSCN.Text = row.Cells["SoCaNhiemMoi"].Value?.ToString();

                var MaTTValue = row.Cells["MaTT"].Value;
                if (MaTTValue != null)
                {
                    cbxTrangThai.SelectedValue = MaTTValue;
                }
            }
        }
        private void BindGrid()
        {
            var qlth = dbContext.DiaPhuong
                        .Select(d => new
                        {
                            MaDP = d.MaDP,
                            TenDP = d.TenDP,
                            SoCaNhiemMoi = d.SoCaNhiemMoi,
                            MaTT = d.MaTT,
                        })
                        .ToList();

            dgvTinhHinhDiaPhuong.DataSource = qlth;

            dgvTinhHinhDiaPhuong.Columns["MaDP"].HeaderText = "MDP";
            dgvTinhHinhDiaPhuong.Columns["TenDP"].HeaderText = "Tên ĐP";
            dgvTinhHinhDiaPhuong.Columns["SoCaNhiemMoi"].HeaderText = "Ca nhiễm";
            dgvTinhHinhDiaPhuong.Columns["MaTT"].HeaderText = "Trạng thái";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dbContext = new QLTinhHinh.QLTinhHinh();

            var trangThaiList = dbContext.TrangThai.ToList();
            cbxTrangThai.DataSource = trangThaiList;
            cbxTrangThai.DisplayMember = "TenTT";
            cbxTrangThai.ValueMember = "MaTT";

            BindGrid();

            // Đăng ký các phím tắt
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                e.Handled = true;
                SapXepTheoSoCaNhiem();
            }
            else if (e.KeyCode == Keys.F2)
            {
                e.Handled = true;
                HienThiDiaPhuong_NhomNguyCo();
            }

            // Ctrl + R
            if (e.Control && e.KeyCode == Keys.R)
            {
                e.Handled = true;
                XuatBaoCao();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateAndGetInput(out string MaDP, out string TenDP, out int SoCaNhiemMoi)) return;

            // Kiểm tra xem MaDP đã tồn tại chưa
            var existingDP = dbContext.DiaPhuong.Find(MaDP);
            if (existingDP != null)
            {
                MessageBox.Show("Mã Địa Phương này đã tồn tại!",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var newDP = new DiaPhuong
            {
                MaDP = MaDP,
                TenDP = TenDP,
                SoCaNhiemMoi = SoCaNhiemMoi,
                MaTT = (int)cbxTrangThai.SelectedValue
            };

            dbContext.DiaPhuong.Add(newDP);
            dbContext.SaveChanges();

            BindGrid();
            ClearInputs();
            MessageBox.Show("Thêm mới thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMDP.Text))
            {
                MessageBox.Show("Vui lòng chọn Địa Phương cần sửa",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (!ValidateAndGetInput(out var MaDP, out var TenDP, out var SoCaNhiemMoi)) return;

            var DPToUpdate = dbContext.DiaPhuong.Find(MaDP);
            if (DPToUpdate == null)
            {
                MessageBox.Show("Không tìm thấy Địa Phương cần sửa trong CSDL!",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                BindGrid();
                return;
            }

            DPToUpdate.TenDP = TenDP;
            DPToUpdate.SoCaNhiemMoi = SoCaNhiemMoi;
            DPToUpdate.MaTT = (int)cbxTrangThai.SelectedValue;

            dbContext.SaveChanges();

            BindGrid();
            ClearInputs();
            MessageBox.Show("Cập nhật thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void ClearInputs()
        {
            txtMDP.Text = "";
            txtTDP.Text = "";
            txtSCN.Text = "";
            cbxTrangThai.SelectedIndex = 0;
            previousMaDP = string.Empty;
        }

        private void SapXepTheoSoCaNhiem()
        {
            var diaPhương = dbContext.DiaPhuong
                        .OrderByDescending(d => d.SoCaNhiemMoi)
                        .Select(d => new
                        {
                            MaDP = d.MaDP,
                            TenDP = d.TenDP,
                            SoCaNhiemMoi = d.SoCaNhiemMoi,
                            MaTT = d.MaTT,
                        })
                        .ToList();

            dgvTinhHinhDiaPhuong.DataSource = diaPhương;
            MessageBox.Show("Đã sắp xếp theo số ca nhiễm (từ cao đến thấp)", "Thông báo");
        }

        private void HienThiDiaPhuong_NhomNguyCo()
        {
            var nguyCo = dbContext.DiaPhuong
                        .Where(d => d.SoCaNhiemMoi > 50)
                        .Select(d => new
                        {
                            MaDP = d.MaDP,
                            TenDP = d.TenDP,
                            SoCaNhiemMoi = d.SoCaNhiemMoi,
                            MaTT = d.MaTT,
                        })
                        .ToList();

            if (nguyCo.Count == 0)
            {
                MessageBox.Show("Không có địa phương nào trong nhóm nguy cơ cao", "Thông báo");
                return;
            }

            dgvTinhHinhDiaPhuong.DataSource = nguyCo;
            MessageBox.Show($"Hiển thị {nguyCo.Count} địa phương có nguy cơ cao", "Thông báo");
        }

        private void XuatBaoCao()
        {
            Form2 form2 = new Form2(dbContext);
            form2.ShowDialog();
        }

        private void sắpXếpTheoSốCaNhiễmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SapXepTheoSoCaNhiem();
        }

        private void cácĐịaPhươngNhómNguyCơToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HienThiDiaPhuong_NhomNguyCo();
        }

        private void xuấtBáoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XuatBaoCao();
        }
    }
}
