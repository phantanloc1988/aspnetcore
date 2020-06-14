using buoi10.Models.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace buoi10.Models.Services.Implements
{
    public class TeduServices : ITransientService, IScopedService, ISingletonService
    {
        // tạo giá trị guid mới
        private Guid _guid;

        public TeduServices()
        {
            _guid = Guid.NewGuid();
        }


        public Guid GetID()
        {
            return _guid;
        }
    }
}
