using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace buoi10.Models
{
    public class MyMapper:Profile
    {
        public MyMapper()
        {
            //Khai báo Map
            CreateMap<ProductModel, Product>(); //map tu A sang B 1 chiều
            CreateMap<ProductModel, Product>().ReverseMap(); //map 2 chiều
        }
    }
}
