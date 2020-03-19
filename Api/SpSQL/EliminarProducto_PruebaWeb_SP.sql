USE [PruebaWebDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<ANTONIO,DAVID,RESTREPO C.>
-- Create date: <18,03,2020>
-- Description:	<Eliminar producto>
-- =============================================
CREATE PROCEDURE "EliminarProducto_PruebaWeb_SP"
	(
		@Id int
	)
AS
BEGIN
	DELETE [dbo].Producto
	WHERE
		([dbo].Producto.Id = @Id)
END