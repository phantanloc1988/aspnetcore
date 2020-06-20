use eStore20


-- ví dụ 1
select concat(MaHH,' - ',TenHH,' - ',MoTa) as HangHoa,
	   DonGia,
	   ISNULL(NgaySX,DATEADD(year,-10,GETDATE())) as NgaySX,
	   case	
			when DonGia<50 then N'giá ok'
			when DonGia<100 then N'Mắc'
			else N'Quá Đắt'	
		end as phanLoai
from HangHoa

order by DonGia


-- ví dụ 2 (thống kê hàng hóa bán)
select hh.MaHH, TenHH ,sum(SoLuong * cthd.DonGia) ThanhTien
from ChiTietHD cthd JOIN HangHoa hh ON cthd.MaHH = hh.MaHH
group by hh.MaHH, TenHH


--======================================
------VIEW (bảng ảo - khung nhìn)
create view vChiTietHoaDon as
select MaHD, hh.MaHH, TenHH, SoLuong, cthd.DonGia, cthd.GiamGia,
		SoLuong*cthd.DonGia * (1- cthd.GiamGia) as ThanhTien
from ChiTietHD cthd join HangHoa hh on cthd.MaHH = hh.MaHH

--Demo lấy thông tin hóa đơn MaHD = 10248
select * from vChiTietHoaDon
where MaHD = 10248

--=====================
-- VIEW -Lấy thông tin hàng hóa 
create view View_HangHoa as
select hh.MaHH, TenHH, DonGia, GiamGia, hh.Hinh, hh.MaLoai, TenLoai, hh.MaNCC, TenCongTy as NhaCungCap
from HangHoa hh join Loai lo ON hh.MaLoai = lo.MaLoai
				join NhaCungCap ncc On ncc.MaNCC = hh.MaNCC

--demo
select * from View_HangHoa
where DonGia between 15 and 155
order by TenLoai Desc


-----Store Procedure----------
--create
create proc sp_LayHoaDon
	@MaHD int
as
begin
	select * from vChiTietHoaDon
	where MaHD = @MaHD
end

-- Demo
sp_LayHoaDon 10248
exec sp_LayHoaDon 10248


--=========ví dụ Procedure mục số 3 Lab-06---=======
--Tạo mới loại
create proc sp_ThemLoai
	@MaLoai int output,
	@TenLoai nvarchar(50),
	@MoTa nvarchar(max),
	@Hinh nvarchar(50)
as begin
	--chèn
	insert into Loai(TenLoai,MoTa,Hinh)
	values (@TenLoai,@MoTa,@Hinh)
	--Láy giá trị MAloai vừa sinh ra
	Set @MaLoai = @@IDENTITY
end

--demo
declare @Ma int
exec sp_ThemLoai @Ma output, N'Bia', null, null
print concat(N'Mã loại tự sinh:',@Ma)

-- store sửa loại
create proc sp_SuaLoai
	@MaLoai int output,
	@TenLoai nvarchar(50),
	@MoTa nvarchar(max),
	@Hinh nvarchar(50)
as begin
	update Loai
	Set TenLoai = @TenLoai, MoTa = @MoTa
	where maloai = @MaLoai
	if @Hinh is not null
	begin
		update loai set Hinh=@Hinh
		where MaLoai = @MaLoai
	end	
End

--store xóa loại
create proc sp_XoaLoai
	@Maloai int
as begin
	delete from Loai where MaLoai = @Maloai
end

--store Lây Loại
create proc sp_Layloai
	@MaLoai int
as begin
	select * from Loai where MaLoai=@MaLoai
end

--store tìm loại
create proc sp_TimLoai
	@TuKhoa nvarchar(50)
as begin
	select * from Loai
	where TenLoai like N'%' + @TuKhoa + N'%'
end


----===Function--============
-- hám tính doanh số theo khách hàng
create function f_DoanhSoTheoKhachHang
(
	@MaKH nvarchar(20)
)

returns float
as begin
	declare @DoanhSo float 

	select @DoanhSo= sum(SoLuong * DonGia * (1 - GiamGia))
	from ChiTietHD ctdh join HoaDon hd On hd.MaHD = ctdh.MaHD
	where MaKH=@MaKH
	return @DoanhSo
end

--demo
select dbo.f_DoanhSoTheoKhachHang('ANTON') doanhThu
select MaKH, Hoten, dbo.f_DoanhSoTheoKhachHang(MaKH)
	from KhachHang


--==Function trả về bảng
create function ThongKeTheoDoanhThuTheoLoai
(
	@Year int
)
returns table
as return
	select lo.MaLoai, lo.TenLoai,sum(SoLuong * cthd.DonGia * (1 - cthd.GiamGia)) DoanhThu
	from ChiTietHD cthd join HangHoa hh on hh.MaHH=cthd.MaHH
		join Loai lo on lo.MaLoai = hh.MaLoai
		join HoaDon hd on hd.MaHD=cthd.MaHD
	where YEAR(NgayDat) = @Year
	group by lo.MaLoai, lo.TenLoai

--demo
select * from dbo.ThongKeTheoDoanhThuTheoLoai(1996)


create function ThongKeTheoDoanhThuTheoNamThang
(
	@Year int, @Month int
)
returns @tmp table
(
	MaLoai int, TenLoai nvarchar(50), DoanhThu float
)

as begin
	insert into @tmp
	select lo.MaLoai, lo.TenLoai,sum(SoLuong * cthd.DonGia * (1 - cthd.GiamGia)) DoanhThu
	from ChiTietHD cthd join HangHoa hh on hh.MaHH=cthd.MaHH
		join Loai lo on lo.MaLoai = hh.MaLoai
		join HoaDon hd on hd.MaHD=cthd.MaHD
	where YEAR(NgayDat) = @Year
	group by lo.MaLoai, lo.TenLoai

	return
end