/****** Object:  StoredProcedure [dbo].[PRD_ObtenerTareasDocente]    Script Date: 10/02/2021 22:24:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      
-- Create Date: 
-- Description: 
-- =============================================
CREATE PROCEDURE [dbo].[PRD_ObtenerTareasDocente] 
										(  @codigo_clase   VARCHAR(50),
                                           @semana        VARCHAR(50),
                                           @mes        VARCHAR(50),
										   @periodo  VARCHAR(50))
AS
  BEGIN
 
      SET nocount ON

      SELECT clase.codigo      AS codigo_clase,
             tarea.codigo      AS codigo_tarea,
             tarea.nombretarea AS nombre_tarea ,  
			 alumno.nombres+ ' ' + alumno.apellidos as alumno
      FROM   tbl_clase clase
             LEFT JOIN tbl_tareas tarea
                    ON clase.codigo = tarea.codigoclase
			 INNER JOIN tbl_Alumno alumno on tarea.codigoUsuario = alumno.codigo
      WHERE  clase.codigo = @codigo_clase
             AND tarea.periodo = @periodo 
			 AND tarea.semana = @semana
			 AND tarea.mes = @mes
  END
 
GO
