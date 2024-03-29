/****** Object:  StoredProcedure [dbo].[PRD_ActualizarDetalleCurso]    Script Date: 10/02/2021 22:24:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      
-- Create Date: 
-- Description: 
-- =============================================
CREATE PROCEDURE [dbo].[PRD_ActualizarDetalleCurso] (@codigo_clase VARCHAR(50),
													@fechaInicio VARCHAR(50),
													@fechaFin VARCHAR(20),
													@enlace    VARCHAR(200),
													@mes  VARCHAR(20), @semana int)
AS
  BEGIN
      if (@codigo_clase <> '')   
			update tbl_Clase set enlace = @enlace
			where codigo = @codigo_clase  
	   
	 if (  @fechaFin <> '')   
			update tbl_material set fechaFin = @fechaFin + ' ' + CONVERT(VARCHAR, CAST(SYSDATETIMEOFFSET() AT TIME ZONE 'SA Pacific Standard Time' AS datetime), 108)
			--, fechaInicio = @fechaInicio + ' ' + CONVERT(VARCHAR, CAST(SYSDATETIMEOFFSET() AT TIME ZONE 'SA Pacific Standard Time' AS datetime), 108) , tarea   = 1
			where codigoClase = @codigo_clase and mes=@mes and semana = @semana
	 
 END
 

 --select CONVERT(VARCHAR, CAST(SYSDATETIMEOFFSET() AT TIME ZONE 'SA Pacific Standard Time' AS datetime), 20)
GO
