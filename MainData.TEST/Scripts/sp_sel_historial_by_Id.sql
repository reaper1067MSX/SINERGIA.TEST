USE SINERGIA
GO

-- =============================================
-- Author:		Santiago Arguello Ojedis
-- Create date: 27/01/2021
-- Description:	Consulta de bodegas
-- =============================================
CREATE PROCEDURE sp_sel_historial_by_Id
	-- Add the parameters for the stored procedure here
	@i_idHistorial int
AS
BEGIN
	SELECT H.*
	FROM Historico_Producto H
	Where H.id = @i_idHistorial
END
GO