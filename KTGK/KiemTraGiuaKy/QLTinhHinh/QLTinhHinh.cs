using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace KiemTraGiuaKy.QLTinhHinh
{
    public partial class QLTinhHinh : DbContext
    {
        public QLTinhHinh()
            : base("name=QLTinhHinh")
        {
        }

        public virtual DbSet<DiaPhuong> DiaPhuong { get; set; }
        public virtual DbSet<TrangThai> TrangThai { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrangThai>()
                .HasMany(e => e.DiaPhuongs)
                .WithRequired(e => e.TrangThai)
                .WillCascadeOnDelete(false);
        }
    }
}
