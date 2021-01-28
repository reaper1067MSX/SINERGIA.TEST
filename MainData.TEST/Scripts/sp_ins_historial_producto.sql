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
AFTER UPDATE   
AS
	Begin
		SET NOCOUNT ON;
		
		DECLARE @id nvarchar(MAX), @descripcion nvarchar(100), @idProveedor nvarchar(MAX), @idCategoria nvarchar(MAX), @idMarca nvarchar(MAX), @estado nvarchar(MAX), @precio decimal(18,2), @idMedidas nvarchar(MAX)

		SELECT @id = i.id , @descripcion = i.descripcion, @idProveedor = i.idProveedor, @idCategoria = i.idCategoria, @idMarca = i.idMarca, @estado = i.estado, @precio = i.precio, @idMedidas = i.idMedidas
		FROM inserted i

		INSERT INTO SINERGIA.dbo.Historico_Producto(idProducto, descripcion, idProveedor, idCategoria, idMarca, estado, precio, idMedidas, ultimaModificacion) 
		VALUES(@id,@descripcion,@idProveedor,@idCategoria,@idMarca, @estado, @precio, @idMedidas, GETDATE())

	End
GO  


