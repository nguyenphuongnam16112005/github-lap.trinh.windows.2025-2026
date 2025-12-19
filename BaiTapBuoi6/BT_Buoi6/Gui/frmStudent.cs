using Bus;
using Dal.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Gui
{
    public partial class frmStudent : Form
    {
        private readonly StudentService studentService = new StudentService();
        private readonly FacultyService facultyService = new FacultyService();

        // Lưu đường dẫn ảnh tạm thời khi người dùng chọn file mới
        private string selectedAvatarPath = "";

        public frmStudent()
        {
            InitializeComponent();
        }

        private void frmStudent_Load(object sender, EventArgs e)
        {
            try
            {
                setGridViewStyle(dgvStudent); // Style cho GridView

                // 1. Load DS Khoa vào ComboBox
                var listFacultys = facultyService.GetAll();
                // 2. Load DS Sinh Viên vào dgvStudent
                var listStudents = studentService.GetAll();

                FillFalcultyCombobox(listFacultys);
                BindGrid(listStudents);

                // 3. Mặc định uncheck checkbox lọc
                chkUnregisterMajor.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message);
            }
        }

        private void FillFalcultyCombobox(List<Faculty> listFacultys)
        {
            // Gán thuộc tính DisplayMember và ValueMember cho ComboBox
            this.cmbFaculty.DisplayMember = "FacultyName";
            this.cmbFaculty.ValueMember = "FacultyID";
            // Binding danh sách khoa vào ComboBox
            this.cmbFaculty.DataSource = listFacultys;
        }

        private void BindGrid(List<Student> listStudent)
        {
            dgvStudent.Rows.Clear();
            foreach (var item in listStudent)
            {
                int index = dgvStudent.Rows.Add();
                dgvStudent.Rows[index].Cells[0].Value = item.StudentID;
                dgvStudent.Rows[index].Cells[1].Value = item.FullName;

                if (item.Faculty != null)
                    dgvStudent.Rows[index].Cells[2].Value = item.Faculty.FacultyName;

                dgvStudent.Rows[index].Cells[3].Value = item.AverageScore + "";

                if (item.Major != null)
                    dgvStudent.Rows[index].Cells[4].Value = item.Major.Name + "";

                // Lưu ý: Không hiển thị cột Avatar trên lưới mà chỉ hiển thị khi click vào dòng
            }
        }
        private void ShowAvatar(string ImageName)
        {
            if (string.IsNullOrEmpty(ImageName))
            {
                pibAvatar.Image = null;
            }
            else
            {
                // Đường dẫn tới thư mục Images trong bin/Debug
                string imagesFolder = Path.Combine(Application.StartupPath, "Images");
                string imagePath = Path.Combine(imagesFolder, ImageName);

                if (File.Exists(imagePath))
                {
                    pibAvatar.Image = Image.FromFile(imagePath);
                    pibAvatar.Refresh();
                }
                else
                {
                    pibAvatar.Image = null;
                }
            }
        }

        public void setGridViewStyle(DataGridView dgview)
        {
            dgview.BorderStyle = BorderStyle.None;
            dgview.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgview.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgview.BackgroundColor = Color.White;
            dgview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        // --- CÁC SỰ KIỆN ---

        // Sự kiện Click vào dòng trong dgvStudent
        private void dgvStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvStudent.Rows[e.RowIndex];
                txtStudentID.Text = row.Cells[0].Value.ToString();
                txtFullName.Text = row.Cells[1].Value.ToString();
                txtAverageScore.Text = row.Cells[3].Value.ToString();

                // Lấy thông tin sinh viên từ CSDL
                var studentID = txtStudentID.Text;
                var student = studentService.FindById(studentID);
                
                if (student != null)
                {
                    // Chọn khoa dựa vào FacultyID (không dùng tên vì dễ bị trùng)
                    if (student.FacultyID.HasValue)
                    {
                        cmbFaculty.SelectedValue = student.FacultyID.Value;
                    }
                    
                    // Hiển thị ảnh đại diện
                    ShowAvatar(student.Avatar);
                }
            }
        }

        private void chkUnregisterMajor_CheckedChanged(object sender, EventArgs e)
        {
            var listStudents = new List<Student>();
            if (this.chkUnregisterMajor.Checked)
                listStudents = studentService.GetAllHasNoMajor(); // Gọi hàm lọc
            else
                listStudents = studentService.GetAll(); // Gọi hàm lấy tất cả

            BindGrid(listStudents);
        }

        // Button Upload ảnh
        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                selectedAvatarPath = open.FileName;
                pibAvatar.Image = Image.FromFile(selectedAvatarPath);
            }
        }

        private void btnAddUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate
                if (string.IsNullOrEmpty(txtStudentID.Text) || string.IsNullOrEmpty(txtFullName.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                    return;
                }

                Student s = new Student();
                s.StudentID = txtStudentID.Text;
                s.FullName = txtFullName.Text;
                if (double.TryParse(txtAverageScore.Text, out double score))
                    s.AverageScore = score;
                s.FacultyID = (int)cmbFaculty.SelectedValue;

                if (!string.IsNullOrEmpty(selectedAvatarPath))
                {
                    string imagesFolder = Path.Combine(Application.StartupPath, "Images");
                    if (!Directory.Exists(imagesFolder)) Directory.CreateDirectory(imagesFolder);

                    string ext = Path.GetExtension(selectedAvatarPath);
                    string fileName = s.StudentID + ext; // Tên file = StudentID.ext

                    string destPath = Path.Combine(imagesFolder, fileName);
                    File.Copy(selectedAvatarPath, destPath, true); // Copy file vào project
                    s.Avatar = fileName;
                }
                else
                {
                    // Giữ ảnh cũ nếu không chọn ảnh mới
                    var oldStudent = studentService.FindById(s.StudentID);
                    if (oldStudent != null) s.Avatar = oldStudent.Avatar;
                }

                // Gọi BUS
                studentService.InsertUpdate(s);

                MessageBox.Show("Lưu thành công!");
                BindGrid(studentService.GetAll());
                selectedAvatarPath = ""; // RESET
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        // Button Delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string studentID = txtStudentID.Text;
                var student = studentService.FindById(studentID);

                if (student == null)
                {
                    MessageBox.Show("Không tìm thấy sinh viên!");
                    return;
                }

                if (MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // Cần bổ sung hàm Delete trong StudentService.
                    // Ở đây dùng tạm DbContext để xóa trực tiếp demo
                    using (var context = new StudentModel())
                    {
                        var dbStudent = context.Students.FirstOrDefault(p => p.StudentID == studentID);
                        if (dbStudent != null)
                        {
                            context.Students.Remove(dbStudent);
                            context.SaveChanges();
                        }
                    }

                    MessageBox.Show("Xóa thành công!");
                    BindGrid(studentService.GetAll());

                    // Xóa file ảnh nếu muốn
                    if (!string.IsNullOrEmpty(student.Avatar))
                    {
                        string imagePath = Path.Combine(Application.StartupPath, "Images", student.Avatar);
                        if (File.Exists(imagePath)) File.Delete(imagePath);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa: " + ex.Message);
            }
        }
    }
}