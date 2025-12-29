using DataBinding.ShcoolDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBinding
{
    public partial class Form1 : Form
    {
        SchoolContext db = new SchoolContext();
        BindingSource bindingSource = new BindingSource();
        
        public Form1()
        {
            InitializeComponent();
            bindingSource.CurrentChanged += (s, e) => BindDataToControls();
        }
        private void LoadData()
        {
            try
            {
                var data = db.Students.Select
                    (s => new
                    {
                        MSSV = s.StudentID,
                        HoTen = s.FullName,
                        Tuoi = s.Age,
                        Khoa = s.Major
                    }).ToList();
                
                bindingSource.DataSource = data;
                dgvSV.DataSource = bindingSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cbbKhoa.Items.AddRange(new string[]
            {
                "Công nghệ thông tin",
                "Ngôn ngữ Anh",
                "Quản trị kinh doanh",
            });

            if(cbbKhoa.Items.Count > 0) cbbKhoa.SelectedIndex = 0; //Chọn mục đầu tiên làm mặc định

            // 1. Khi click vào một ô bất kỳ, nó sẽ chọn cả dòng
            dgvSV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // 2. Chỉ cho phép chọn 1 dòng tại 1 thời điểm (tránh lỗi khi sửa/xóa nhiều dòng)
            dgvSV.MultiSelect = false;

            // 3. Không cho phép người dùng sửa trực tiếp trên lưới (bắt buộc dùng TextBox để sửa)
            dgvSV.ReadOnly = true;

            bindingNavigator1.BindingSource = bindingSource;

            dgvSV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            LoadData();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput())
                    return;

                //Khởi tạo đối tượng Student mới
                Student s = new Student();
                s.FullName = txtTen.Text;

                //Xử lý tuổi
                if (int.TryParse(txtTuoi.Text, out int tuoi)) s.Age = tuoi;
                else s.Age = null;
                s.Major = cbbKhoa.Text; //Lấy giá trị từ ComboBox

                //Thêm vào DBContext
                db.Students.Add(s);

                //Lưu thay đổi xuống CSDL
                db.SaveChanges();

                MessageBox.Show("Thêm Sinh Viên thành công!");
                LoadData(); //Load lại dữ liệu lên DataGridView
                ResetInputs();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm Sinh Viên: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSV.SelectedRows.Count > 0)
                {
                    if (!ValidateInput())
                        return;

                    int id = int.Parse(dgvSV.SelectedRows[0].Cells[0].Value.ToString());

                    Student s = db.Students.Find(id);

                    if (s != null)
                    {
                        s.FullName = txtTen.Text;

                        //Xử lý tuổi
                        if (int.TryParse(txtTuoi.Text, out int tuoi)) s.Age = tuoi;
                        else s.Age = null;
                        s.Major = cbbKhoa.Text; //Lấy giá trị từ ComboBox

                        //Lưu thay đổi xuống CSDL
                        db.SaveChanges();
                        MessageBox.Show("Cập nhật Sinh Viên thành công!");
                        LoadData(); //Load lại dữ liệu lên DataGridView
                        ResetInputs();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn Sinh Viên cần cập nhật!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật Sinh Viên: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSV.SelectedRows.Count > 0)
                {
                    int id = int.Parse(dgvSV.SelectedRows[0].Cells[0].Value.ToString());

                    Student s = db.Students.Find(id);

                    if (s != null)
                    {
                        DialogResult dr = MessageBox.Show(
                            "Bạn có chắc chắn muốn xóa Sinh Viên này không?", "Xác nhận",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            db.Students.Remove(s);

                            db.SaveChanges();

                            MessageBox.Show("Xóa Sinh Viên thành công!");
                            LoadData(); //Load lại dữ liệu lên DataGridView
                            ResetInputs();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn Sinh Viên cần xóa!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa Sinh Viên: " + ex.Message);
            }
        }

        private void ResetInputs()
        {
            txtTen.Clear();
            txtTuoi.Clear();
            cbbKhoa.SelectedIndex = 0; // Reset về mục đầu tiên thay vì -1
        }
        private void BindDataToControls()
        {
            try
            {
                // Kiểm tra xem BindingSource có dữ liệu không
                if (bindingSource.Current != null)
                {
                    if (dgvSV.CurrentRow != null)
                    {
                        // Đảm bảo Grid focus đúng dòng mà BindingSource đang trỏ tới
                        // (Thường BindingSource và Grid tự đồng bộ, nhưng code thêm cho chắc)
                        dgvSV.Rows[bindingSource.Position].Selected = true;

                        var row = dgvSV.Rows[bindingSource.Position];
                        txtTen.Text = row.Cells[1].Value?.ToString();
                        txtTuoi.Text = row.Cells[2].Value?.ToString();
                        cbbKhoa.Text = row.Cells[3].Value?.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex.Message);
            }
        }
        private bool ValidateInput()
        {
            // 1. Kiểm tra để trống tên
            if (string.IsNullOrWhiteSpace(txtTen.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTen.Focus();
                return false;
            }

            // 2. Kiểm tra tên có chứa số hay không
            // Hàm Any(char.IsDigit) sẽ trả về true nếu trong chuỗi có bất kỳ ký tự số nào
            if (txtTen.Text.Any(char.IsDigit))
            {
                MessageBox.Show("Tên sinh viên không được chứa số!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTen.Focus();
                return false;
            }

            // 3. Kiểm tra để trống tuổi
            if (string.IsNullOrWhiteSpace(txtTuoi.Text))
            {
                MessageBox.Show("Vui lòng nhập tuổi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTuoi.Focus();
                return false;
            }

            // 4. Kiểm tra tuổi có phải là số hay không & Tuổi hợp lệ
            if (!int.TryParse(txtTuoi.Text, out int tuoi))
            {
                MessageBox.Show("Tuổi phải là một số nguyên!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTuoi.Focus();
                txtTuoi.SelectAll(); // Bôi đen để người dùng nhập lại nhanh
                return false;
            }

            if (tuoi < 1 || tuoi > 100)
            {
                MessageBox.Show("Tuổi phải nằm trong khoảng từ 1 đến 100!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTuoi.Focus();
                return false;
            }

            // 5. Kiểm tra đã chọn khoa chưa
            if (cbbKhoa.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn chuyên khoa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true; // Nếu vượt qua hết các bước trên thì dữ liệu Hợp lệ
        }
        // Nút <=
        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            bindingSource.MoveFirst();
        }
        // Nút <
        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            bindingSource.MovePrevious();
        }
        // Nút >
        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            bindingSource.MoveNext();
        }
        // Nút =>
        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            bindingSource.MoveLast();
        }
    }
}
