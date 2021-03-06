/****** Object:  StoredProcedure [dbo].[PRD_ObtenerNotasDocente]    Script Date: 31/01/2021 10:51:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      
-- Create Date: 
-- Description: 
-- =============================================
CREATE PROCEDURE [dbo].[PRD_ObtenerNotasDocente] ( 
												 @codigo_docente VARCHAR(50),
												 @codigo_clase VARCHAR(50),
                                                 @periodo      VARCHAR(50))
AS
  BEGIN
      -- SET NOCOUNT ON added to prevent extra result sets from
      -- interfering with SELECT statements.
      SET nocount ON


	  SELECT cl_Alumno.codigo as codigo_alumno, alumno.nombres as nombres, alumno.apellidos
      FROM   tbl_clase clase
		     INNER JOIN tbl_ClaseAlumno cl_Alumno on clase.codigo  = cl_Alumno.codigoClase 
			 INNER JOIN tbl_Alumno alumno on cl_Alumno.codigoAlumno = alumno.codigo
	 WHERE   
		     clase.periodo = @periodo
			 AND clase.codigo = @codigo_clase

	 SELECT tipo.codigo , tipo.descripcion
      FROM   tbl_NotasTipo tipo 


      SELECT  cl_Alumno.codigo as codigo_alumno ,nota.nota , nota.tipo 
      FROM   tbl_clase clase
		     INNER JOIN tbl_ClaseAlumno cl_Alumno on 
					clase.codigo  = cl_Alumno.codigoClase and 
					clase.codigo =  @codigo_clase			  
			 INNER JOIN tbl_Curso curso on clase.codigoCurso = curso.codigo 
             LEFT JOIN tbl_Notas nota on cl_Alumno.codigo = nota.codigoClaseAlumno
			 INNER JOIN tbl_NotasTipo tipo on nota.tipo = tipo.codigo        
		WHERE     
			 clase.codigoDocente = @codigo_docente
             AND clase.periodo = @periodo
			 AND clase.codigo = @codigo_clase
      ORDER  BY NOTA.codigo ASC
  END


  -- exec [PRD_ObtenerNotasDocente] 'DO-09468871','CL2020-00148','2021'
GO
