USE [PruebaWebDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<ANTONIO,DAVID,RESTREPO C.>
-- Create date: <18,03,2020>
-- Description:	<Editar producto>
-- =============================================
CREATE PROCEDURE "EditarProducto_PruebaWeb_SP"
	(
		@Id int,
		@EstaBorrado bit,
		@ImagenURL nvarchar(max),
		@NombreProducto nvarchar(450),
		@Precio decimal
	)
AS
BEGIN
	UPDATE [dbo].Producto
	SET
		[dbo].Producto.EstaBorrado = @EstaBorrado,
		[dbo].Producto.ImagenURL = @ImagenURL,
		[dbo].Producto.NombreProducto = @NombreProducto,
		[dbo].Producto.Precio = @Precio
	WHERE
		([dbo].Producto.Id = @Id)
END
GO