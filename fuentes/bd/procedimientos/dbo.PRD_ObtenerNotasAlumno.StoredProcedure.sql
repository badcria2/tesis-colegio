/****** Object:  StoredProcedure [dbo].[PRD_ObtenerNotasAlumno]    Script Date: 31/01/2021 10:51:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      
-- Create Date: 
-- Description: 
-- =============================================
CREATE PROCEDURE [dbo].[PRD_ObtenerNotasAlumno] ( 
												 @codigo_alumno VARCHAR(50),
                                                 @periodo      VARCHAR(50))
AS
  BEGIN
      -- SET NOCOUNT ON added to prevent extra result sets from
      -- interfering with SELECT statements.
      SET nocount ON


	   SELECT  curso.codigo as codigo_curso, curso.nombre as nombre_curso
      FROM   tbl_clase clase
		     INNER JOIN tbl_ClaseAlumno cl_Alumno on clase.codigo  = cl_Alumno.codigoClase 
			  and cl_Alumno.codigoAlumno =  @codigo_alumno 
			 RIGHT JOIN tbl_Curso curso on clase.codigoCurso = curso.codigo   
	 WHERE     
			 cl_Alumno.codigoAlumno = @codigo_alumno
             AND clase.periodo = @periodo

	 SELECT tipo.codigo , tipo.descripcion
      FROM   tbl_NotasTipo tipo 


      SELECT  curso.codigo as codigo_curso,nota.nota , nota.tipo 
      FROM   tbl_clase clase
		     INNER JOIN tbl_ClaseAlumno cl_Alumno on clase.codigo  = cl_Alumno.codigoClase 
			  and cl_Alumno.codigoAlumno =  @codigo_alumno
             LEFT JOIN tbl_Notas nota on cl_Alumno.codigo = nota.codigoClaseAlumno
			 RIGHT JOIN tbl_NotasTipo tipo on nota.tipo = tipo.codigo  
			 RIGHT JOIN tbl_Curso curso on clase.codigoCurso = curso.codigo 
      WHERE     
			 cl_Alumno.codigoAlumno = @codigo_alumno
             AND clase.periodo = @periodo
      ORDER  BY NOTA.codigo ASC
  END
  --SELECT * FROM tbl_Notas
--  SELECT * FROM  tbl_ClaseAlumno
  -- EXEC [PRD_ObtenerNotasAlumno] 'AL2020-00002','2020'
--update tbl_material
--set tarea = 1,    fechaInicio     =   convert(varchar, getdate(), 120) ,  
--  fechafin =  convert(varchar, getdate() + 1 , 120) --  , select DATEDIFF (MINUTE ,( convert(varchar, getdate() , 120)),  convert(varchar, getdate() + 1, 120)  )
--where semana in (1,2,3,4,10,12)
--select DATEDIFF (HOUR ,  convert(varchar, getdate() , 120) ,  fechafin)  , DATEDIFF (MINUTE,  convert(varchar, getdate() , 120) , fechafin )%60   FROM tbl_material
--SELECT LEFT(CONVERT(VARCHAR(10), fechafin  - getdate() , 108), 8) AS ResultTime   FROM tbl_material 
GO
