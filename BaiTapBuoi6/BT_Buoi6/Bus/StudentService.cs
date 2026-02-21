using Dal;
using Dal.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus
{
    public class StudentService
    {
        public List<Student> GetAll()
        {
            using (StudentModel context = new StudentModel())
            {
                return context.Students.Include(s => s.Faculty).Include(s => s.Major).ToList();
            }
        }

        public List<Student> GetAllHasNoMajor()
        {
            using (StudentModel context = new StudentModel())
            {
                return context.Students.Where(p => p.MajorID == null).Include(s => s.Faculty).Include(s => s.Major).ToList();
            }
        }

        public List<Student> GetAllHasNoMajor(int facultyID)
        {
            using (StudentModel context = new StudentModel())
            {
                return context.Students.Where(p => p.MajorID == null && p.FacultyID == facultyID).Include(s => s.Faculty).Include(s => s.Major).ToList();
            }
        }

        public Student FindById(string studentId)
        {
            using (StudentModel context = new StudentModel())
            {
                return context.Students.Include(s => s.Faculty).Include(s => s.Major).FirstOrDefault(p => p.StudentID == studentId);
            }
        }

        public void InsertUpdate(Student s)
        {
            using (StudentModel context = new StudentModel())
            {
                context.Students.AddOrUpdate(s);
                context.SaveChanges();
            }
        }

        public void Delete(string studentId)
        {
            using (StudentModel context = new StudentModel())
            {
                var student = context.Students.FirstOrDefault(p => p.StudentID == studentId);
                if (student != null)
                {
                    context.Students.Remove(student);
                    context.SaveChanges();
                }
            }
        }
    }
}
