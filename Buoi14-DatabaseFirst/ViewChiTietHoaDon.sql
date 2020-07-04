create view ChiThietHoaDonView as
select lo.TenLoai, hh.TenHH,cthd.DonGia, cthd.SoLuong, cthd.GiamGia,cthd.DonGia*cthd.SoLuong*(1-cthd.GiamGia) as ThanhTien
from ChiTietHD cthd join HangHoa hh
	on hh.MaHH=cthd.MaHH
	join Loai lo on lo.MaLoai=hh.MaLoai
