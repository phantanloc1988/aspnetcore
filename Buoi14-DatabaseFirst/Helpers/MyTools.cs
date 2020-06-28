using Buoi14_DatabaseFirst.Models.MyModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi14_DatabaseFirst.Helpers
{
    public class MyTools
    {
        public static string FullPathFolderImage = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot" ,"Hinh");

        public static string NoImage = "~/Hinh/No-Image.jpg";
        public static string CheckImageExist(string filename, string folder)
        {
            if (File.Exists(Path.Combine(FullPathFolderImage,folder,filename)))
            {
                return $"{folder}/{filename}";
            }
            return NoImage;
        }

        //Paging
        public static List<Paging> Pages
        {
            get
            {
                return new List<Paging>()
                {
                    new Paging{Value= 10, Text="10"},
                    new Paging{Value= 20, Text="20"},
                    new Paging{Value= 50, Text="50"},
                    new Paging{Value= 100, Text="100"},
                };
            }
        }
    }
}
