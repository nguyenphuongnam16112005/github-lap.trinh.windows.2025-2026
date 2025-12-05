using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Buoi03
{
    public partial class frmDemo : Form
    {
        public frmDemo()
        {
            InitializeComponent();

            // 1. Đặt chế độ xem là Details (cần thiết để hiển thị nhiều cột)
            listView.View = View.Details;

            // 2. Cho phép người dùng chọn cả hàng
            listView.FullRowSelect = true;

            // 3. Hiển thị lưới để dễ nhìn hơn (tùy chọn)
            listView.GridLines = true;

            // 4. Thêm các cột theo thứ tự trong hình
            // Lưu ý: Tôi đổi lại thứ tự theo yêu cầu của hình 1: Last Name, First Name, Phone
            // Hình 2 của bạn lại là: First Name, Last Name, Phone. 
            // Tôi sẽ tuân theo Hình 1 (Bài tập): Last Name, First Name, Phone.

            //listView.Columns.Add("Last Name", 100);  // Độ rộng 100 pixels
            //listView.Columns.Add("First Name", 100);
            //listView.Columns.Add("Phone", 100);

            // --- Gắn sự kiện cho ListView (quan trọng cho bước 3) ---
            listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem các ô nhập liệu có rỗng không
            if (string.IsNullOrWhiteSpace(txtLast.Text) ||
                string.IsNullOrWhiteSpace(txtFirst.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin (Last Name, First Name, Phone)."
                    , "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Tạo một ListViewItem mới
            // Mục chính (SubItem[0]) là cột đầu tiên: Last Name
            ListViewItem item = new ListViewItem(txtLast.Text.Trim());

            // 3. Thêm các cột phụ (SubItems)
            // SubItem[1] là cột thứ hai: First Name
            item.SubItems.Add(txtFirst.Text.Trim());
            // SubItem[2] là cột thứ ba: Phone
            item.SubItems.Add(txtPhone.Text.Trim());

            // 4. Thêm mục (Item) vào ListView
            listView.Items.Add(item);

            // 5. Xóa nội dung TextBox sau khi thêm (tùy chọn)
            txtLast.Clear();
            txtFirst.Clear();
            txtPhone.Clear();
            txtLast.Focus(); // Đặt focus vào ô Last Name
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem có mục nào đang được chọn không
            if (listView.SelectedItems.Count > 0)
            {
                // Lấy mục đang được chọn đầu tiên (chỉ 1 mục vì FullRowSelect = true)
                ListViewItem selectedItem = listView.SelectedItems[0];

                // 2. Lấy dữ liệu từ các SubItem và hiển thị ngược lên các TextBox
                // SubItem[0] là Last Name
                txtLast.Text = selectedItem.SubItems[0].Text;

                // SubItem[1] là First Name
                txtFirst.Text = selectedItem.SubItems[1].Text;

                // SubItem[2] là Phone
                txtPhone.Text = selectedItem.SubItems[2].Text;
            }
            else
            {
                // Nếu không có mục nào được chọn, có thể xóa nội dung TextBox (tùy chọn)
                // txtLast.Clear();
                // txtFirst.Clear();
                // txtPhone.Clear();
            }
        }
    }
}
