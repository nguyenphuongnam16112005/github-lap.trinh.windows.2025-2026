using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buoi04
{
    public partial class frmQuanLySinhVien : Form
    {
        public frmQuanLySinhVien()
        {
            InitializeComponent();
        }

        private void dgvQLSV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            // Lấy ra dòng đang được chọn
            DataGridViewRow selectedRow = dgvStudent.Rows[e.RowIndex];

            // Bắt đầu chép ngược dữ liệu từ Bảng về Ô nhập
            txtStudentID.Text = selectedRow.Cells[0].Value.ToString(); // MSSV
            txtFullName.Text = selectedRow.Cells[1].Value.ToString();  // Họ Tên

            // Xử lý giới tính
            // Sửa thuộc tính Properties của RadioButton
            // Chọn Checked của btnFemale từ False thành True
            // Để tự động tích chọn mặc định là nữ
            string gender = selectedRow.Cells[2].Value.ToString();
            optMale.Checked = (gender == "Nam");
            optFemale.Checked = (gender == "Nữ");

            txtAverageScore.Text = selectedRow.Cells[3].Value.ToString(); // Điểm TB

            // Xử lý Combobox Khoa (Cần chọn đúng khoa trong danh sách)
            cmbFaculty.Text = selectedRow.Cells[4].Value.ToString();
        }

        private void frmQuanLySinhVien_Load(object sender, EventArgs e)
        {
            cmbFaculty.SelectedIndex = 0;
        }
        private int GetSelectedRow(string studentID)
        {
            for (int i = 0; i < dgvStudent.Rows.Count; i++)
            {
                if (dgvStudent.Rows[i].Cells[0].Value != null &&
                    dgvStudent.Rows[i].Cells[0].Value.ToString() == studentID)
                {
                    return i;
                }
            }
            return -1;
        }
        private void InsertUpdate(int selectedRow)
        {
            dgvStudent.Rows[selectedRow].Cells[0].Value = txtStudentID.Text;
            dgvStudent.Rows[selectedRow].Cells[1].Value = txtFullName.Text;
            dgvStudent.Rows[selectedRow].Cells[2].Value = optFemale.Checked ? "Nữ" : "Nam";
            dgvStudent.Rows[selectedRow].Cells[3].Value = float.Parse(txtAverageScore.Text).ToString();
            dgvStudent.Rows[selectedRow].Cells[4].Value = cmbFaculty.Text;
        }
        private void StudenCount()
        {
            int countMale = 0;
            int countFemale = 0;

            for(int i = 0; i < dgvStudent.Rows.Count;i++)
            {
                if(dgvStudent.Rows[i].IsNewRow) // Bỏ qua dòng mới
                    continue;

                if (dgvStudent.Rows[i].Cells[0].Value != null)
                {
                    // Lấy giới tính ở cột số 2 (cột Giới Tính)
                    string gender = dgvStudent.Rows[i].Cells[2].Value.ToString();

                    if (gender == "Nam")
                    {
                        countMale++; // Thấy Nam thì cộng 1
                    }
                    else
                    {
                        countFemale++; // Thấy Nữ thì cộng 1
                    }
                }
            }
            txtMale.Text = countMale.ToString();
            txtFemale.Text = countFemale.ToString();
        }
        private void btnUpd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtStudentID.Text == "" || txtFullName.Text == "" || txtAverageScore.Text == "")
                    throw new Exception("Vui lòng nhập đầy đủ thông tin!");

                int selectedRow = GetSelectedRow(txtStudentID.Text);
                if (selectedRow == -1) //TH thêm mới DỮ LIỆU
                {
                    selectedRow = dgvStudent.Rows.Add();
                    InsertUpdate(selectedRow);
                    MessageBox.Show("Thêm mới dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK);
                }
                else //TH cập nhật DỮ LIỆU
                {
                    InsertUpdate(selectedRow);
                    MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            StudenCount();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedRow = GetSelectedRow(txtStudentID.Text);
                if (selectedRow == -1)
                {
                    throw new Exception("Thông tìm thấy MSSV cần xóa!");
                } else
                {
                    DialogResult dr = MessageBox.Show("Bạn có muốn xóa ?", "YES/NO", MessageBoxButtons.YesNo);
                    if(dr == DialogResult.Yes)
                    {
                        dgvStudent.Rows.RemoveAt(selectedRow);
                        MessageBox.Show("Xóa Sinh Viên thành công!", "Thông báo", MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            StudenCount();
        }

        private void cmbFaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Sử thuộc tính (Properties) của ComboBox
            //Trong phần: DropDownStyle chọn DropDown -> DropDownList

            //cmbFaculty.DropDownStyle = ComboBoxStyle.DropDownList;
            //cmbFaculty.SelectedIndex = 0;
        }
    }
}
