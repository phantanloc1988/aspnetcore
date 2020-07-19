using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using buoi_20.DataModels;
using System.IO;
using OfficeOpenXml;
using System.ComponentModel;
using LicenseContext = OfficeOpenXml.LicenseContext;
using Microsoft.AspNetCore.Http;
using buoi_20.ViewModels;

namespace buoi_20.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoaiController : Controller
    {
        private readonly MyDBContext _context;

        public LoaiController(MyDBContext context)
        {
            _context = context;
        }

        // GET: Admin/Loai
        public async Task<IActionResult> Index()
        {
            var myDBContext = _context.Loais.Include(l => l.LoaiCha);
            return View(await myDBContext.ToListAsync());
        }

        // GET: Admin/Loai/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loai = await _context.Loais
                .Include(l => l.LoaiCha)
                .FirstOrDefaultAsync(m => m.MaLoai == id);
            if (loai == null)
            {
                return NotFound();
            }

            return View(loai);
        }

        // GET: Admin/Loai/Create
        public IActionResult Create()
        {
            ViewData["MaLoaiCha"] = new SelectList(_context.Loais, "MaLoai", "TenLoai");

            ViewBag.DataLoai = new LoaiDropdownVM { Data = _context.Loais.ToList() };
            return View();
        }

        // POST: Admin/Loai/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaLoai,TenLoai,MaLoaiCha")] Loai loai)
        {
            try
            {
                _context.Add(loai);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ViewData["MaLoaiCha"] = new SelectList(_context.Loais, "MaLoai", "TenLoai", loai.MaLoaiCha);
                return View(loai);
            }
            
        }

        // GET: Admin/Loai/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loai = await _context.Loais.FindAsync(id);
            if (loai == null)
            {
                return NotFound();
            }
            ViewData["MaLoaiCha"] = new SelectList(_context.Loais, "MaLoai", "TenLoai", loai.MaLoaiCha);
            return View(loai);
        }

        // POST: Admin/Loai/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaLoai,TenLoai,MaLoaiCha")] Loai loai)
        {
            if (id != loai.MaLoai)
            {
                return NotFound();
            }

           
                try
                {
                    _context.Update(loai);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaiExists(loai.MaLoai))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
         
            ViewData["MaLoaiCha"] = new SelectList(_context.Loais, "MaLoai", "TenLoai", loai.MaLoaiCha);
            return View(loai);
        }

        // GET: Admin/Loai/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loai = await _context.Loais
                .Include(l => l.LoaiCha)
                .FirstOrDefaultAsync(m => m.MaLoai == id);
            if (loai == null)
            {
                return NotFound();
            }

            return View(loai);
        }

        // POST: Admin/Loai/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loai = await _context.Loais.FindAsync(id);
            _context.Loais.Remove(loai);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoaiExists(int id)
        {
            return _context.Loais.Any(e => e.MaLoai == id);
        }



        public IActionResult ImportExcel()
        {

            return View();
        }
        

        [HttpPost]
        public IActionResult ImportExcel(IFormFile file)
        {
           
            if (file==null|| file.Length <=0)
            {
                return View();
            }
            //Đọc File trả ra list
            var dsLoai = new List<Loai>();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var memoryStream = new MemoryStream()) //Lưu tạm
            {
                file.CopyTo(memoryStream);

                using (var excel = new ExcelPackage())
                {
                    var sheet1 = excel.Workbook.Worksheets["Loai"];
                    int rowCount = sheet1.Dimension.Rows;

                    for (int i = 2; i < rowCount; i++)
                    {
                        var loaiTemp = new Loai
                        {
                            MaLoai = int.Parse(sheet1.Cells[i, 1].Value.ToString()),
                            TenLoai = sheet1.Cells[i,2].Value.ToString(),
                        };
                        if (int.TryParse(sheet1.Cells[i,3].Value.ToString(),out int maloaiCha))
                        {
                            loaiTemp.MaLoaiCha = maloaiCha;
                        }

                        dsLoai.Add(loaiTemp);
                    }
                }
            };

            // Xử lý data
            foreach (var loai in dsLoai)
            {
                // dựa vào tên tìm xem loại có chưa
                var loaidb = _context.Loais.SingleOrDefault(p => p.TenLoai == p.TenLoai);
                //nếu có, update
                if (loaidb!=null)
                {

                }
                //nếu chưa, tạo mới
                else
                {

                }
            }

            return View();
        }

        public IActionResult ExportExcel()
        {
            var dataLoai = _context.Loais.ToList();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            //File Stream Giữ data
            var stream = new MemoryStream();
            
            using (var package = new ExcelPackage())
            {
                //tạo workbook và Sheet trong Excel
                var sheet1 = package.Workbook.Worksheets.Add("Loai");
                var sheet2 = package.Workbook.Worksheets.Add("Demo");
                // đổ data vào Sheet;
                sheet1.Cells.LoadFromCollection(dataLoai, true);//true là cho dong đậu tiên là tiêu đề

                Random rd = new Random();
                sheet2.Cells[1, 1].Value = "Danh sách loại";
                sheet2.Cells[1, 2].Value = rd.Next(); //B1
                sheet2.Cells[1, 3].Value = rd.Next();//C1
                sheet2.Cells[1, 4].Formula = "B1+C1";


                package.Save();
            }
            stream.Position = 0;

            var fileName = $"DSLoai_{DateTime.Now:dd/mm/yyyy HHmmss}.xlxs";
                return File(stream,"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",fileName);
        }
    }
}
