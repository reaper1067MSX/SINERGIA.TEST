USE SINERGIA
GO

-- =============================================
-- Author:		Santiago Arguello Ojedis
-- Create date: 27/01/2021
-- Description:	Consulta de bodegas
-- =============================================
CREATE PROCEDURE sp_sel_bodega_by_Id
	-- Add the parameters for the stored procedure here
	@i_idBodega nvarchar(MAX)
AS
BEGIN
	SELECT B.*
	FROM Bodega B
	Where B.id = @i_idBodega
END
GO