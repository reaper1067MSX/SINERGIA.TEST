-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

USE SINERGIA
GO

-- =============================================
-- Author:		Santiago Arguello Ojedis
-- Create date: 27/01/2021
-- Description:	Consulta de Productos
-- =============================================
CREATE PROCEDURE sp_sel_producto_by_Id
	-- Add the parameters for the stored procedure here
	@i_idProducto nvarchar(MAX)
AS
BEGIN
	SELECT PR.*
	FROM Producto PR
	Where PR.id = @i_idProducto
END
GO
