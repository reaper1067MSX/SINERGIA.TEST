USE SINERGIA
GO

-- =============================================
-- Author:		Santiago Arguello Ojedis
-- Create date: 27/01/2021
-- Description:	Consulta de Proveedores
-- =============================================
CREATE PROCEDURE sp_sel_Proveedor_by_Id
	-- Add the parameters for the stored procedure here
	@i_idProveedor uniqueidentifier
AS
BEGIN
	SELECT PV.*
	FROM Proveedor PV
	Where PV.id = @i_idProveedor
END
GO