USE SINERGIA
GO

-- =============================================
-- Author:		Santiago Arguello Ojedis
-- Create date: 27/01/2021
-- Description:	Consulta de Marca
-- =============================================
CREATE PROCEDURE sp_sel_Marca_by_Id
	-- Add the parameters for the stored procedure here
	@i_idMarca nvarchar(MAX)
AS
BEGIN
	SELECT M.*
	FROM Marca M
	Where M.id = @i_idMarca
END
GO