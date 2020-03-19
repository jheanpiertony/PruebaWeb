USE [PruebaWebDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<ANTONIO,DAVID,RESTREPO C.>
-- Create date: <18,03,2020>
-- Description:	<Crear producto nuevo>
-- =============================================
CREATE PROCEDURE "CrearProducto_PruebaWeb_SP"
	(
		@EstaBorrado bit,
		@ImagenURL nvarchar(max),
		@NombreProducto nvarchar(450),
		@Precio decimal
	)
AS
BEGIN
	INSERT INTO [dbo].Producto
	(
		[dbo].Producto.EstaBorrado,
		[dbo].Producto.ImagenURL,
		[dbo].Producto.NombreProducto,
		[dbo].Producto.Precio
	)
	VALUES
	(
		@EstaBorrado,
		@ImagenURL,
		@NombreProducto,
		@Precio
	)
END
GO