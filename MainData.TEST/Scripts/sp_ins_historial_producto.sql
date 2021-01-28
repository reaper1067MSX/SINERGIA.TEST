--====================================
--  Create database trigger template 
--====================================
USE SINERGIA
GO

-- Borramos el Trigger si existise
DROP TRIGGER IF EXISTS sp_ins_producto_historico
GO

CREATE TRIGGER sp_ins_producto_historico  
ON Producto  
FOR UPDATE   
AS
	Begin
		SET NOCOUNT ON;

		DECLARE @id uniqueidentifier, @descripcion nvarchar(100), @idProveedor uniqueidentifier, @idCategoria uniqueidentifier, @idMarca uniqueidentifier, @estado char(1), @precio decimal(18,2), @idMedidas uniqueidentifier

		SELECT @id = i.id , @descripcion = i.descripcion, @idProveedor = i.idProveedor, @idCategoria = i.idCategoria, @idMarca = i.idMarca, @estado = i.estado, @precio = i.precio, @idMedidas = i.idMedidas
		FROM inserted i

		INSERT INTO SINERGIA.dbo.Historico_Producto(idProducto, descripcion, idProveedor, idCategoria, idMarca, estado, precio, idMedidas, ultimaModificacion) 
		VALUES(CONVERT(UNIQUEIDENTIFIER, @id)
		,@descripcion,CONVERT(UNIQUEIDENTIFIER, @idProveedor),CONVERT(UNIQUEIDENTIFIER, @idCategoria),CONVERT(UNIQUEIDENTIFIER, @idMarca), @estado, @precio, CONVERT(UNIQUEIDENTIFIER, @idMedidas), GETDATE())

	End
GO  


DROP TRIGGER sp_ins_producto_historico  