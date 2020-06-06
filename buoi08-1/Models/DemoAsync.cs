using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace buoi08_1.Models
{
    public class DemoAsync
    {
        public string Test01()
        {
            Thread.Sleep(3000);
            return "Nhất Nghệ";
        }


        public int Test02()
        {
            Thread.Sleep(5000);
            return new Random().Next(10000);
        }

        public void Test03()
        {
            Thread.Sleep(2000);
        }


        public async Task<string>  Test01Async()
        {
             Thread.Sleep(3000);
            return "Nhất Nghệ";
        }

        public async Task<int> Test02Async()
        {
            Thread.Sleep(5000);
            return new Random().Next(10000);
        }

        public async Task Test03Async()
        {
            Thread.Sleep(2000);
        }
    }
}
