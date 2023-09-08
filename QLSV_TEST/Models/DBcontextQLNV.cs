using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QLSV_TEST.Models
{
    public partial class DBcontextQLNV : DbContext
    {
        public DBcontextQLNV()
            : base("name=DBcontextQLNV1")
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(e => e.EmployeeID)
                .IsUnicode(false);
        }
    }
}
