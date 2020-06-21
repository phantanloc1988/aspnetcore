using Microsoft.AspNetCore.SignalR.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace buoi13.Helpers
{
    public class SQLConfig
    {
        public string ConnectionString { get; set; }
        public int Timeout { get; set; }
    }
}
