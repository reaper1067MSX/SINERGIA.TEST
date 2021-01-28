USE SINERGIA
GO

-- =============================================
-- Author:		Santiago Arguello Ojedis
-- Create date: 27/01/2021
-- Description:	Consulta de Categoria
-- =============================================
CREATE PROCEDURE sp_sel_categoria_by_id
	-- Add the parameters for the stored procedure here
	@i_idCategoria nvarchar(MAX)
AS
BEGIN
	SELECT C.*
	FROM Categoria C
	Where C.id = @i_idCategoria
END
GO