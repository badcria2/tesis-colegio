/****** Object:  StoredProcedure [dbo].[PRD_ObtenerAsistencia]    Script Date: 10/02/2021 22:24:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      
-- Create Date: 
-- Description: 
-- =============================================
CREATE PROCEDURE [dbo].[PRD_ObtenerAsistencia] (@codigo_clase   VARCHAR(50),
                                           @codigo_usuario VARCHAR(50),
                                           @periodo        VARCHAR(50),
                                           @fechaRegistro        VARCHAR(50))
AS
  BEGIN
 

	 

      SELECT clase.codigo      AS codigo_clase,
             asistencia.codigo      AS codigo_asistencia,
             asistencia.usuario,
             asistencia.fechaRegistro AS fecha_registro,
			 asistencia.estado as estado
			 
      FROM   tbl_clase clase
             LEFT JOIN tbl_Asistencia asistencia
                    ON clase.codigo = asistencia.codigoclase and codigoClase = @codigo_clase and clase.periodo = @periodo
			
      WHERE  clase.codigo = @codigo_clase
             AND clase.periodo = @periodo
             AND 1 =  
			  CASE WHEN  @codigo_usuario = '' THEN 
						1 
			       WHEN  asistencia.usuario = @codigo_usuario THEN 
						1 
			  ELSE
				 0
			  END
			  AND 1 =  
			  CASE WHEN  @fechaRegistro = '' THEN 
						0 
			       WHEN  asistencia.fechaRegistro = @fechaRegistro THEN 
						1 
			  ELSE
				 0
			  END
      ORDER  BY asistencia.fechaRegistro DESC

	   select alumno.codigo as codigo_alumno, alumno.nombres, alumno.apellidos , (select count(codigo) from tbl_Asistencia asi where asi.codigoClase  =  cl_alumno.codigoClase  and asi.usuario = alumno.codigo AND( estado = 'F' )) as faltas 
	   from tbl_ClaseAlumno cl_alumno 
	  INNER JOIN tbl_Alumno alumno on cl_alumno.codigoAlumno = alumno.codigo
	  INNER JOIN tbl_Clase clase on cl_alumno.codigoClase = clase.codigo
            
	  where cl_alumno.codigoClase = @codigo_clase  and clase.periodo = @periodo
	--  group by alumno.codigo , alumno.nombres, alumno.apellidos 
  END
  -- SELECT * FROM tbl_ClaseAlumno
  -- exec [PRD_ObtenerAsistencia] 'CL2020-00148','','2021','01/06/2020'
GO
