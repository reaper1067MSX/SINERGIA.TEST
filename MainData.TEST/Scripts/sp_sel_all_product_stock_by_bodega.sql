USE SINERGIA
GO

-- =============================================
-- Author:		Santiago Arguello Ojedis
-- Create date: 27/01/2021
-- Description:	Consulta de stock de productos por bodegas
-- =============================================
CREATE PROCEDURE sp_sel_all_product_stock_by_bodega
	-- Add the parameters for the stored procedure here
	@i_idBodega nvarchar(MAX)
AS
BEGIN
	SELECT BP.idBodega, B.descripcion, BP.existencia, P.id, P.descripcion, P.estado, P.idCategoria, C.descripcion, P.idMarca, M.descripcion, ME.id, ME.alto, ME.ancho, ME.peso, P.precio
	FROM BodegaPorProducto BP
	JOIN Bodega B
		On B.id = BP.idBodega
	JOIN Producto P
		On BP.idProducto = P.id
	JOIN Categoria C
		On P.idCategoria = C.id
	JOIN Marca M
		On P.idMarca = M.id
	JOIN Medidas ME
		On P.idMedidas = ME.id
	Where BP.idBodega = @i_idBodega
END
GO