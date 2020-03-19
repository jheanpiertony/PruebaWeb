USE [PruebaWebDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<ANTONIO,DAVID,RESTREPO C.>
-- Create date: <18,03,2020>
-- Description:	<Lista de productos>
-- =============================================
CREATE PROCEDURE "ListadoProducto_PruebaWeb_SP"
AS
BEGIN
	SET NOCOUNT ON;
	SELECT *
	FROM [dbo].Producto
END