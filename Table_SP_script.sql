-- development.dbo.produk definition

-- Drop table

-- DROP TABLE development.dbo.produk;

CREATE TABLE development.dbo.produk (
	id int IDENTITY(1,1) NOT NULL,
	nama_barang varchar(200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	kode_barang varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	jumlah_barang int NOT NULL,
	tanggal datetime NOT NULL,
	CONSTRAINT PK__produk__3213E83FAA1A0C95 PRIMARY KEY (id)
);
GO

--IF OBJECT_ID ( 'development.dob.produk_get', 'P' ) IS NOT NULL
--    DROP PROCEDURE development.dob.produk_get;
--GO
CREATE PROCEDURE dbo.produk_add
    @nama NVARCHAR(200),
    @kode NVARCHAR(50),
    @jumlah int,
    @tgl datetime
AS
	INSERT INTO dbo.produk(nama_barang, kode_barang, jumlah_barang, tanggal)
	VALUES (@nama, @kode, @jumlah, @tgl);
GO
--IF OBJECT_ID ( 'development.dob.produk_get', 'P' ) IS NOT NULL
--    DROP PROCEDURE development.dob.produk_get;
--GO
CREATE PROCEDURE dbo.produk_del
	@id int
AS
	DELETE FROM dbo.produk
	WHERE id = @id;
GO
--IF OBJECT_ID ( 'development.dob.produk_get', 'P' ) IS NOT NULL
--    DROP PROCEDURE development.dob.produk_get;
--GO
CREATE PROCEDURE dbo.produk_edit
	@id int,
	 @nama NVARCHAR(200),
	 @kode NVARCHAR(50),
	 @jumlah int,
	 @tgl datetime
AS
	UPDATE dbo.produk
	SET nama_barang = @nama,
		kode_barang = @kode,
		jumlah_barang = @jumlah,
		tanggal = @tgl
	WHERE id = @id;
GO
CREATE PROCEDURE dbo.produk_get
	 @id int
AS
    SET NOCOUNT ON;
    SELECT id, nama_barang, kode_barang, jumlah_barang, tanggal 
    FROM development.dbo.produk p 
    WHERE p.id = @id
    ORDER BY p.nama_barang;
GO
CREATE PROCEDURE dbo.produk_search
    @nama_barang NVARCHAR(200) = null,
    @kode_barang NVARCHAR(50) = null
AS
    SET NOCOUNT ON;
    SELECT id, nama_barang, kode_barang, jumlah_barang, tanggal 
    FROM development.dbo.produk p 
    WHERE 
    (p.nama_barang IS NULL OR LOWER(p.nama_barang) like LOWER('%'+@nama_barang+'%'))
    	AND (p.kode_barang IS NULL OR LOWER(p.kode_barang) like LOWER('%'+@kode_barang+'%'))
    ORDER BY p.nama_barang ;
GO