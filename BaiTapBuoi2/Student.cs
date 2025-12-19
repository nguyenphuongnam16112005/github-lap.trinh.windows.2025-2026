using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

//Bài tập 2A + 2B
namespace Lab01_02
{
    class Student
    {
        //private string ID;
        //private string Name;
        //private int Age;
        //private float AvgScore;
        //private string Faculty;

        public string ID
        {
            get; set;
        }
        public string Name
        {
            get; set;
        }
        public int Age
        {
            get; set;
        }
        public float AvgScore
        {
            get; set;
        }
        public string Faculty
        {
            get; set;
        }
        //Khởi tạo Constructor
        public Student()
        {
        }
        public Student(string iD, string name, int age, float avgScore, string faculty)
        {
            this.ID = iD;
            this.Name = name;
            this.Age = age;
            this.AvgScore = avgScore;
            this.Faculty = faculty;
        }
        //Khởi tạo Methods
        public void Input()
        {
            Console.Write("Nhập MSSV: ");
            ID = Console.ReadLine();
            Console.Write("Nhập họ tên: ");
            Name = Console.ReadLine();
            Console.Write("Nhập điểm TB: ");
            AvgScore = float.Parse(Console.ReadLine());
            Console.Write("Nhập khoa: ");
            Faculty = Console.ReadLine();
        }
        public void Output()
        {
            Console.WriteLine("MSSV:{0} Họ tên:{1} ĐiểmTB:{2} Khoa:{3}", this.ID, this.Name, this.AvgScore, this.Faculty);
        }
        //Case 1:
        static void ThemSV(List<Student> studentList)
        {
            Console.WriteLine("===== Nhap thong tin Sinh Vien ======");
            Student student = new Student();
            student.Input();
            studentList.Add(student);
            Console.WriteLine("Thêm sinh viên thành công");
        }
        //Case 2:
        static void HienThiDanhSachSV(List<Student> studentList)
        {
            Console.WriteLine("==== Danh sách chi tiết thông tin sinh viên ====");
            foreach (Student student in studentList)
            {
                student.Output();
            }
        }
        //Case 3:
        static void HienThiSVKhoa(List<Student> studentList, string Faculty)
        {
            Console.WriteLine("=== Danh sách SV thuộc khoa {0}: ", Faculty);
            var sinhVien = studentList.Where(s => s.Faculty.Equals(Faculty, StringComparison.OrdinalIgnoreCase)).ToList();
            HienThiDanhSachSV(sinhVien);
        }
        //Case 4: Xuất SV có ĐiểmTB >= 5
        static void HienThiSVDiemTBCaoNhat(List<Student> studenList, float minAvgScore)
        {
            Console.WriteLine("=== Danh sách SV có ĐiểmTB >= {0}", minAvgScore);
            var sinhVien = studenList.Where(s => s.AvgScore >= minAvgScore).ToList();
            HienThiDanhSachSV(sinhVien);
        }
        //Case 5: Sắp xếp SV theo ĐiểmTB
        static void SapXepSinhVienDiemTB(List<Student> studenList)
        {
            Console.WriteLine("=== Sắp Xếp SV có ĐiểmTB tăng dần ===");
            var SapXepSV = studenList.OrderBy(s => s.AvgScore).ToList();
            HienThiDanhSachSV(SapXepSV);
        }
        //Case 6: DS SV có ĐiểmTB >= 5 và Thuộc khoa CNTT
        static void HienThiSVkhoaVaDiemTB(List<Student> studentList, string Faculty, float minAvgScore)
        {
            Console.WriteLine("=== Danh sách SV có ĐiểmTB => {0} và thuộc khoa {1}", minAvgScore, Faculty);
            var sinhVien = studentList.Where(s => s.AvgScore >= minAvgScore
            && s.Faculty.Equals(Faculty, StringComparison.OrdinalIgnoreCase)).ToList();
            HienThiDanhSachSV(sinhVien);
        }
        //Case 7: Hiển thị SV có ĐiểmTB cao nhất và thuộc khoa CNTT
        static void HienThiSVDiemTBCaoNhatTheoKhoa(List<Student> studentList, string targetFaculty)
        {
            //Lọc SV theo khoa
            var svTheoKhoa = studentList.Where(s => s.Faculty.Equals(targetFaculty, StringComparison.OrdinalIgnoreCase));
            // Nếu danh sách rỗng, không làm gì tiếp
            if (!svTheoKhoa.Any())
            {
                Console.WriteLine($"\n=== Danh sách SV có ĐiểmTB cao nhất: Không có sinh viên nào thuộc khoa {targetFaculty} trong danh sách.");
                return;
            }

            //Tìm ĐiểmTB cao nhất trong danh sách đã lọc (Sử dụng Max())
            float maxAvgScore = svTheoKhoa.Max(s => s.AvgScore);

            //Lọc lại, lấy tất cả SV có ĐiểmTB BẰNG điểm cao nhất
            var dsSVDiemCaoNhat = svTheoKhoa
                .Where(s => s.AvgScore == maxAvgScore)
                .ToList();
            Console.WriteLine($"\n=== Danh sách SV có ĐiểmTB cao nhất ({maxAvgScore}) và thuộc khoa {targetFaculty} ===");

            HienThiDanhSachSV(dsSVDiemCaoNhat);
        }
        //Case 8: Hiển thị danh sách số lượng SV thuộc loại
        // 9 -> 10: Xuất sắc, 8 -> 9: Giỏi, 7 -> 8: Khá, 5 -> 7: Trung Bình, 4 -> 5: Yếu, <4: Yếu 
        static void HienThidanhSachSLThuocLoai(List<Student> studentList)
        {
            Console.WriteLine("=== Danh sách SL SV thuộc loại: ");
            string XepLoai(float DiemSo)
            {
                if (DiemSo >= 9) return "Xuất sắc";
                if (DiemSo >= 8) return "Giỏi";
                if (DiemSo >= 7) return "Khá";
                if (DiemSo >= 5) return "Trung bình";
                if (DiemSo >= 4) return "Yếu";
                else return "Kém";
            }
            var dsXeploai = studentList.GroupBy(s => XepLoai(s.AvgScore)).Select(group => new
            {
                loai = group.Key,
                soLuong = group.Count()
            }).OrderByDescending(g => g.soLuong).ToList();
            if(dsXeploai.Count == 0)
            {
                Console.WriteLine("DS SV trông, không có dữ liệu");
                return;
            }
            Console.WriteLine("{0, -20} | {1}", "Loại", "Số Lượng");
            foreach(var item in dsXeploai)
            {
                Console.WriteLine("{0, -20} | {1}", item.loai, item.soLuong); 
            }
        }

        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            List<Student> studentList = new List<Student>();
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("===== Menu =====");
                Console.WriteLine("1. Thêm 1 sinh viên");
                Console.WriteLine("2. Hiển thị danh sách sinh viên");
                Console.WriteLine("3. Hiển thị SV thuộc khoa");
                Console.WriteLine("4. Hiển thị DS SV ĐiểmTB >= 5");
                Console.WriteLine("5. Sắp xếp SV theo ĐiểmTB");
                Console.WriteLine("6. Hiển thị SV thuộc khoa và ĐiểmTB");
                Console.WriteLine("7. Hiển thị DS ĐiểmTB cao nhất và theo khoa (CNTT)");
                Console.WriteLine("8. Hiển thị DS SL thuộc loại");
                Console.WriteLine("0. Thoát chương trình");
                Console.Write("Hãy chọn chức năng: ");

                string Choice = Console.ReadLine();

                switch (Choice)
                {
                    case "1":
                        ThemSV(studentList);
                        break;
                    case "2":
                        HienThiDanhSachSV(studentList);
                        break;
            //Bổ sung thêm 3 -> 8
                    case"3":
                        HienThiSVKhoa(studentList, "CNTT");
                        break;
                    case "4":
                        HienThiSVDiemTBCaoNhat(studentList, 5);
                        break;
                    case "5":
                        SapXepSinhVienDiemTB(studentList);
                        break;
                    case "6":
                        HienThiSVkhoaVaDiemTB(studentList, "CNTT", 5);
                        break;
                    case "7":
                        HienThiSVDiemTBCaoNhatTheoKhoa(studentList, "CNTT");
                        break;
                    case "8":
                        HienThidanhSachSLThuocLoai(studentList);
                        break;
                    case "0":
                        exit = true;
                        Console.WriteLine("Đã kết thúc chương trình");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại");
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}
