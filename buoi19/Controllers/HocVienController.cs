﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using buoi19.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace buoi19.Controllers

{

    [Route("api/[controller]")]
    [ApiController]
    public class HocVienController : ControllerBase
    {
        public static List<HocVien> dsHocVien = new List<HocVien>();

        // GET: api/HocVien
        [HttpGet]
        public IEnumerable<HocVien> Get()
        {
            return dsHocVien;
        }

        // GET: api/HocVien/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            int N = dsHocVien.Count;
            if (id >= N || id < 0)
            {
                return BadRequest();
            }
            return Ok(dsHocVien[id]);
        }

        // POST: api/HocVien
        [HttpPost]
        public IActionResult Post([FromBody] HocVien hocVien)
        {
            if (ModelState.IsValid)
            {
                var hv = Find(hocVien.MaHV);
                if (hv == null)
                {
                    dsHocVien.Add(hocVien);
                    return Ok();

                }

                return BadRequest();
            }
            return BadRequest();
        }

        private HocVien Find(int maHV)
        {
            return dsHocVien.FirstOrDefault(p => p.MaHV == maHV);
        }

        // PUT: api/HocVien/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] HocVien hocVien)
        {
            if (id != hocVien.MaHV)
            {
                return BadRequest();
            }

            var hv = Find(hocVien.MaHV);
            if (hv != null)
            {
                hv.HoTen = hocVien.HoTen;
                hv.Diem = hocVien.Diem;
                return Ok();

            }

            return BadRequest();

        }


        // DELETE: api/ApiWithActions/5

    }

}
