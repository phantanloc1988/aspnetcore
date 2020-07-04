create proc SPThongKeLoai as
begin
select lo.TenLoai,SUM(cthd.SoLuong*cthd.DonGia*(1-cthd.GiamGia))
from ChiTietHD cthd join HangHoa hh on hh.MaHH = cthd.MaHH
	join Loai lo on lo.MaLoai = hh.MaLoai
group by lo.TenLoai
end