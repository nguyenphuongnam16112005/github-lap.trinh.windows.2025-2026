using Dal;
using Dal.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus
{
    public class MajorService
    {
        public List<Major> GetAllByFaculty(int facultyID)
        {
            using (StudentModel context = new StudentModel())
            {
                return context.Majors.Where(p => p.FacultyID == facultyID).ToList();
            }
        }
        public Major FindById(int majorID)
        {
            using (StudentModel context = new StudentModel())
            {
                return context.Majors.FirstOrDefault(p => p.MajorID == majorID);
            }
        }
        public void InsertUpdate(Major m)
        {
            using (StudentModel context = new StudentModel())
            {
                context.Majors.AddOrUpdate(m);
                context.SaveChanges();
            }
        }
        public void Delete(int majorID)
        {
            using (StudentModel context = new StudentModel())
            {
                var major = context.Majors.FirstOrDefault(p => p.MajorID == majorID);
                if (major != null)
                {
                    context.Majors.Remove(major);
                    context.SaveChanges();
                }
            }
        }
    }
}
