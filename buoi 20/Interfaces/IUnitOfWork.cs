using buoi_20.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace buoi_20.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        MyDBContext Context { get; }
        void Commit();
    }
}
