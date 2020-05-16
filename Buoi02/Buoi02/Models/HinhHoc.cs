using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi02.Models
{
    public class HinhHoc
    {
        public static string RandomKey()
        {
            return $"NN - {new Random().Next()}";
        }
        public double DienTich { get; set; }
        public double ChuVi { get; set; }
        public virtual void TinhDienTichChuVi()
        {

        }

        public virtual double TinhDienTich(double dai, double rong)
        {
            var S = dai * rong;
            return S;
        }

        public override string ToString()
        {
            return $"S={DienTich}, P={ChuVi}";
        }
    }

    public class HinhChuNhat : HinhHoc
    {
        public double Dai { get; set; }
        public double Rong { get; set; }

        public override void TinhDienTichChuVi()
        {

            DienTich = Dai * Rong;
            ChuVi = 2 * (Dai + Rong);
        }
    }
}
