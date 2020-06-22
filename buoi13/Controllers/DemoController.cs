using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using buoi13.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace buoi13.Controllers
{
    public class DemoController : Controller
    {
        private readonly SQLConfig _sqlConfig;

        public DemoController(IOptions<SQLConfig> sqlConfig)
        {
            _sqlConfig = sqlConfig.Value;
        }

        public IActionResult Demo()
        {
            SqlConnection connection = new SqlConnection(_sqlConfig.ConnectionString);

            string sql = "select top 100 MaHH, TenHH, DonGia, Hinh from HangHoa";

            SqlDataAdapter da = new SqlDataAdapter(sql, connection);
            DataTable dtHangHoa = new DataTable();
            da.Fill(dtHangHoa);
            return View(dtHangHoa);
        }

        public IActionResult DemoInsert()
        {
            //tạo đối tượng kết nối
            SqlConnection connection = new SqlConnection(_sqlConfig.ConnectionString);

            string sqlInsert = "insert into Loai(TenLoai) values(N'Bia - nước ngọt')";
            SqlCommand command = new SqlCommand(sqlInsert, connection);
            command.Connection.Open();
            int result = command.ExecuteNonQuery();
            command.Connection.Close();
            return Content($"{result} effected row(s).");
        }


        public IActionResult DemoDelete()
        {
            SqlConnection connection = new SqlConnection(_sqlConfig.ConnectionString);

            string sql = "delete from HangHoa Where MaHH='ABC'";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Connection.Open();
            int ketqua = command.ExecuteNonQuery();
            command.Connection.Close();
            return Content($"{ketqua} hàng bị xóa");
        }

        public IActionResult Index() //Lấy dữ liệu trực tiếp từ Json không qua model
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("myAppSetting.json");
            var congfig = builder.Build();
            var ngaykg = congfig["NgayKhaiGiang"];
            var tentt = congfig["TrungTam:Ten"]; //nhiều lớp dùng ":"
            var conhd = congfig["TrungTam:ConHoatDong"];
            var myDBCon = congfig.GetConnectionString("MyDB"); //Chuỗi kết nối database

            // cách lấy khác
            var trungtam = congfig.GetSection("TrungTam");
            var dienthoai = trungtam["DienThoai"];



            var ketqua = $"{tentt}, đang hoạt động: {conhd},{dienthoai}. chuỗi kết nối: {myDBCon}";

            return Content(ketqua);
        }

       
    }
}