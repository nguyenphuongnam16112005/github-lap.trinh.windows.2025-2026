using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DataBinding.ShcoolDB
{
    public partial class SchoolContext : DbContext
    {
        public SchoolContext()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
