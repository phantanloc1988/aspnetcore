using buoi_20.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace buoi_20.ViewModels
{
    public class LoaiDropdownVM
    {
        public List<Loai> Data { get; set; }

        public int? Selected { get; set; }
    }
}
