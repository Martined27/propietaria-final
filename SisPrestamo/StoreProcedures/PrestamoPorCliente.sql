USE [prestamodb]
GO

/****** Object:  StoredProcedure [dbo].[PrestamoPorCliente]    Script Date: 8/7/16 5:10:13 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PrestamoPorCliente] (@clientId as int)
AS
BEGIN
	SELECT        p.id, (c.Nombre + ' ' + c.Apellido) as Cliente, Importe, Tasa, Plazo, tp.tipo as tipo_prestamo
FROM            Prestamos p 
INNER JOIN Clientes c on p.ClienteId = c.Id
INNER JOIN tipo_prestamo tp on p.tipo_prestamoId = tp.id
WHERE        (ClienteId = @clientId)
END


GO