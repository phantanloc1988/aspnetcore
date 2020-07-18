using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace buoi_20.DataModels
{
    public class MyDBContext: DbContext
    {
        public MyDBContext(DbContextOptions option):base(option)
        {

        }

        public DbSet<Loai> Loais { get; set; }
        public DbSet<HangHoa> HangHoas { get; set; }
        public DbSet<Hinh> Hinhs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HangHoa>().Property(p => p.MaHH).IsRequired();
            modelBuilder.Entity<HangHoa>().HasIndex(p => p.MaHH).IsUnique();
        }
    }
}
