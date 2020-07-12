using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyeStoreProject.Models;
using MyeStoreProject.ViewModels;
using SQLitePCL;

namespace MyeStoreProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly eStore20Context _context;
        private readonly AppSettings _appSettings;

        public UserController(eStore20Context ct, IOptions<AppSettings> optionSettings)
        {
            _context = ct;
            _appSettings = optionSettings.Value;
        }

        [HttpPost("Login")] //hhttps://localhost:44361/api/User/login
        public IActionResult Login(LoginVm model)
        {

            var kh = _context.KhachHang.SingleOrDefault(p => p.MaKh == model.UserName & p.MatKhau == model.Password);
            if (kh == null)
            {
                return Ok(new ApiResult
                {
                    Success = false,
                    Message = "Invalid username or password"
                });
            }

            #region
            var tokenHandler = new JwtSecurityTokenHandler();
            var keyBytes = Encoding.UTF8.GetBytes(_appSettings.MaHoaSecret);
            var tokenInfo = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {

                    new Claim(ClaimTypes.Name,kh.HoTen),
                    new Claim(ClaimTypes.Email,kh.Email),
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha512)
            };
            var token = tokenHandler.CreateToken(tokenInfo);
            #region


            return Ok(new ApiResultData<string>
            {
                Success = true,
                Message = "Login Success",
                Data = tokenHandler.WriteToken(token)
            });
        }
    }
}