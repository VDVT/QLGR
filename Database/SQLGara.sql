create database QLGR
GO
use QLGR
GO
create table Users 
(
	MaNV char(20) primary key,
	MatKhau char(20),
	Quyen varchar(20),
	GT bit,
	NgaySinh smalldatetime,
	HoTen nvarchar(40),
	DienThoai char(12),
	DiaChi nvarchar(40)
)

create table Xe
(
	BienSo char(20) primary key,
	TenChuXe nvarchar(40),
	DienThoai char(12),
	Email varchar(40),
	DiaChi nvarchar(40),
	MaHX char(10),
	NgayTN smalldatetime,
	TienNo money
)

create table HieuXe
(
	MaHX char(10) primary key,
	TenHX varchar(20)
)



create table VatTu
(
	MaVT char(10) primary key,
	TenVT nvarchar(20),
	DonGia money,
	SL int
)

create table TienCong
(
	MaTC char(10) primary key,
	TenTC nvarchar(200),
	GiaTien	money
)

create table PhieuSC
(
	MAPSC char(10) primary key,
	BienSo char(20),
	MaNV char(20),
	NgaySC smalldatetime,
	ThanhTien money
)

create table CTPSC
(
	MAPSC char(10),
	MaVT char(10),
	SoLuong int,
	NoiDung nvarchar(100),
	DonGia money,
	MaTC char(10),
	TongTien money,
	primary key(MAPSC,MaVT)
)

create table PhieuTT
(
	MaPTT char(10) primary key,
	BienSo char(20),
	NgayTT smalldatetime,
	SoTienThu money
)

alter table PhieuSC add constraint FK_PSC_Users foreign key (MaNV) references Users(MaNV)
alter table PhieuSC add constraint FK_PSC_Xe foreign key (BienSo) references Xe(BienSo)
alter table PhieuTT add constraint FK_PTT_Xe foreign key (BienSo) references Xe(BienSo)
alter table Xe add constraint FK_Xe_HieuXe foreign key (MaHX) references HieuXe(MaHX)
alter table CTPSC add constraint FK_CTPSC_VT foreign key (MaVT) references VatTu(MaVT)
alter table CTPSC add constraint FK_CTPSC_TC foreign key (MaTC) references TienCong(MaTC)
alter table CTPSC add constraint FK_CTPSC_PSC foreign key (MaPSC) references PhieuSC(MaPSC)

/* TRIGGERS */
create TRIGGER SO_PTN
ON PhieuTN
FOR Insert
As
	Declare @so_ptn int
	Select @so_ptn = COUNT(MaPTN) from PhieuTN group by NgayTN
	IF (@so_ptn > 30) 
	begin
		print('Moi ngay tiep nhan 30 cai thoi!!!')
		rollback tran
	end

/*Procedure getData */
CREATE PROCEDURE GetData 
	@tableName varchar(128)
As
Begin
	Declare @sql nvarchar(max);
	Set @sql = N'Select * from ' + @tableName
	Exec sp_executesql @sql
End

/*Procedure add new row in HieuXe table */
create procedure SP_InsertHX
	@maHx char(10),
	@tenHx varchar(20)
as
begin
	insert into HieuXe values(@maHx,@tenHx)
end

/*Procedure delete row from HieuXe table*/
create proc SP_DelHX
	@maHx char(10)
as
	begin
		delete from HieuXe where MaHX = @maHx
	end

/*Procedure update row in HieuXe table */
create proc SP_UpdateHX
	@maHx char(10),
	@tenHx nvarchar(20)
as
	begin
		update HieuXe
		set TenHX = @tenHx
		where MaHX = @maHx
	end
	

--Procedure insert new TienCong
create proc SP_InsertTC
	@maTc char(10),
	@tenTc nvarchar(20),
	@giaTien money
as
	begin
		insert into TienCong values (@maTc, @tenTc, @giaTien)
	end

--Procedure del TienCong
create proc SP_DelTC
	@maTc char(10)
as
	begin
		delete from TienCong where MaTC = @maTc
	end
--Procedure update TienCong
create proc SP_UpdateTC
	@maTc char(10),
	@tenTc nvarchar(20),
	@giaTien money
as
	begin
		update TienCong
		set TenTC = @tenTc, GiaTien = @giaTien
		where MaTC = @maTc
	end


--Procedure tiep nhan Xe, ngayTN = ngay hien tai
create procedure SP_InsertXe
	@bienSo char(20),
	@tenChuXe nvarchar(40),
	@dt char(12),
	@email varchar(40),
	@diaChi nvarchar(40),
	@maHx char(10)
as
	begin
	declare @ngayTN smalldatetime
	set @ngayTN = GETDATE()
	insert into Xe(BienSo,TenChuXe,DienThoai,NgayTN,Email,DiaChi,MaHX) values(@bienSo,@tenChuXe,@dt,@ngayTN,@email,@diaChi,@maHx)
	end
--Procedure insert VatTu
create proc SP_InsertVT
	@maVt char(10),
	@tenVt nvarchar(20),
	@donGia money,
	@sl int
as
	begin
		insert into VatTu values(@maVt,@tenVt,@donGia,@sl)
	end

--Procedure del Vat tu
create proc SP_DelVT
	@maVt char(10)
as
	begin
		delete from VatTu where MaVT = @maVt
	end

/*Procedure update row in VatTu table */
create proc SP_UpdateVT
	@maVt char(10),
	@tenVT nvarchar(20),
	@sl int,
	@donGia money
as
	begin
		update VatTu
		set TenVT = @tenVT, SL = @sl, DonGia = @donGia
		where MaVT = @maVt

	end
