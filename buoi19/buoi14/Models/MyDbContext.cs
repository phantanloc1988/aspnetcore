using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace buoi14.Models
{
    public class MyDbContext: DbContext
    {
        //Định nghĩa các thuộc tính (table)
        public DbSet<Loai> loais { get; set; }
        public DbSet<HangHoa> HangHoas { get; set; }
        public MyDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
