SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<ANTONIO,DAVID,RESTREPO C.>
-- Create date: <18,03,2020>
-- Description:	<Lista de productos>
-- =============================================
CREATE PROCEDURE CrearSpProductoPorIdDesdeNetCore_PruebaWeb_SP
		@Id int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT *
	FROM [dbo].Producto
	WHERE [dbo].Producto.Id = @Id
END;
GO