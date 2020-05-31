using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Buoi07.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SingleUpload(IFormFile MyFile1)
        {
            //Linux: /DS/User/aadsadasd
            //Window: C:\document\xxaxasddsa
            //=> Dùng path.combine để tạo đường dẫn để hợp mọi hệ điều hành
            //Path.combine để tạo dấu "/"


            if (MyFile1!=null)
            {
                //Tạo Đường Dẫn
                var DuongDan = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data", MyFile1.FileName);

                //// Tạo File Mới nằm ở đường dẫn trên
                //var file = new FileStream(DuongDan, FileMode.Create);

                ////Copy file Upload qua file vừa tạo
                //MyFile1.CopyTo(file);

                ////Đóng file
                //file.Close();

                using (FileStream filestream = new FileStream(DuongDan, FileMode.Create))
                {
                    MyFile1.CopyTo(filestream);
                };
            }
            return RedirectToAction("Index","Demo");
        }

        public IActionResult MultipleUpload(List<IFormFile> MyFile2)
        {
            if (MyFile2!=null)
            {
                foreach (var item in MyFile2)
                {

                    var DuongDan = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data", DateTime.Now.Ticks.ToString() + item.FileName);

                    using (FileStream filestream = new FileStream(DuongDan, FileMode.Create))
                    {
                        item.CopyTo(filestream);
                    };

                }
            }
            
            return RedirectToAction("Index", "Demo");
        }
    }

    
}