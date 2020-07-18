using buoi_20.DataModels;
using buoi_20.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace buoi_20.Implements
{
    public class UnitOfWork : IUnitOfWork
    {
        public MyDBContext Context { get; }


        public UnitOfWork(MyDBContext context)
        {
            Context = context;
        }
        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();

        }
    }
}
