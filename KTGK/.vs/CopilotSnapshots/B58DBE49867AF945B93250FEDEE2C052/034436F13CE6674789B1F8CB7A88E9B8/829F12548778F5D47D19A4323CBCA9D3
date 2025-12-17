using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KiemTraGiuaKy.QLTinhHinh;

namespace KiemTraGiuaKy
{
    public partial class Form2 : Form
    {
        private QLTinhHinh.QLTinhHinh dbContext;

        public Form2(QLTinhHinh.QLTinhHinh context = null)
        {
            InitializeComponent();
            dbContext = context;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (dbContext != null)
            {
                LoadReport();
            }
        }

        private void LoadReport()
        {
            var report = dbContext.DiaPhuong
                        .Join(dbContext.TrangThai,
                              d => d.MaTT,
                              t => t.MaTT,
                              (d, t) => new
                              {
                                  MaDP = d.MaDP,
                                  TenDP = d.TenDP,
                                  SoCaNhiem = d.SoCaNhiemMoi,
                                  TenTT = t.TenTT
                              })
                        .OrderByDescending(x => x.SoCaNhiem)
                        .ToList();

            // Hiển thị trên DataGridView nếu có
            if (this.Controls.OfType<DataGridView>().FirstOrDefault() is DataGridView dgv)
            {
                dgv.DataSource = report;
                dgv.Columns["MaDP"].HeaderText = "Mã ĐP";
                dgv.Columns["TenDP"].HeaderText = "Tên Địa Phương";
                dgv.Columns["SoCaNhiem"].HeaderText = "Số Ca Nhiễm";
                dgv.Columns["TenTT"].HeaderText = "Trạng Thái";
            }
        }
    }
}
