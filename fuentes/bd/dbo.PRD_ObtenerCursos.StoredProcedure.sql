/****** Object:  StoredProcedure [dbo].[PRD_ObtenerCursos]    Script Date: 10/02/2021 22:24:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      
-- Create Date: 
-- Description: 
-- =============================================
CREATE PROCEDURE [dbo].[PRD_ObtenerCursos] (@codigo_usuario VARCHAR(50),
                                           @periodo        VARCHAR(50),
										   @perfil		   VARCHAR(50),
										   @grado			varchar(5),
										   @seccion   varchar(5))
AS
  BEGIN
      -- SET NOCOUNT ON added to prevent extra result sets from
      -- interfering with SELECT statements.
      SET nocount ON

	IF @perfil = 'Alumno' 	 BEGIN 
      SELECT clase.codigo               AS codigo_clase,
             curso.codigo               AS codigo_curso,
             curso.nombre               AS nombre_curso,
             clase.grado,
             clase.seccion,
             curso.estilo,
             clase.periodo,
             clAlumno.estadoalumnoclase AS estado_curso_alumno
      FROM   tbl_alumno al
             INNER JOIN tbl_clasealumno clAlumno
                     ON al.codigo = clAlumno.codigoalumno
                        AND al.codigo = @codigo_usuario
             INNER JOIN tbl_clase clase
                     ON clAlumno.codigoclase = clase.codigo
             INNER JOIN tbl_curso curso
                     ON clase.codigocurso = curso.codigo
      WHERE  clAlumno.codigoalumno = @codigo_usuario 
             AND clase.periodo = @periodo
	END 
	ELSE IF @perfil = 'Docente' BEGIN
		 SELECT clase.codigo               AS codigo_clase,
             curso.codigo               AS codigo_curso,
             curso.nombre               AS nombre_curso,
             clase.grado,
             clase.seccion,
             curso.estilo,
             clase.periodo,
             '' AS estado_curso_alumno
      FROM   tbl_clase clase
             INNER JOIN tbl_curso curso
                     ON clase.codigocurso = curso.codigo
      WHERE  clase.codigoDocente = @codigo_usuario 
             AND clase.periodo = @periodo and
			 	  clase.grado like CASE WHEN  @grado = 'Todos' THEN 
				'%' 
			  ELSE
				'%' + @grado + '%'
			  END
			  and 
			  clase.seccion like CASE WHEN  @seccion = 'Todos' THEN 
					'%' 
			  ELSE
				'%' + @seccion + '%'
			  END 
	 END 
	 ELSE IF  @perfil = 'Director' BEGIN
		 SELECT clase.codigo               AS codigo_clase,
             curso.codigo               AS codigo_curso,
             curso.nombre               AS nombre_curso,
             clase.grado,
             clase.seccion,
             curso.estilo,
             clase.periodo,
             clase.enlace AS estado_curso_alumno
      FROM   tbl_clase clase 
             INNER JOIN tbl_curso curso
                     ON clase.codigocurso = curso.codigo
      WHERE  clase.periodo = @periodo and   
			  clase.grado like CASE WHEN  @grado = 'Todos' THEN 
				'%' 
		  ELSE
			'%' + @grado + '%'
		  END
	      and 
		  clase.seccion like CASE WHEN  @seccion = 'Todos' THEN 
				'%' 
		  ELSE
			'%' + @seccion + '%'
		  END 
	 END
  END  


   -- exec [PRD_ObtenerCursos] '','2021','Director','Todos','Todos'
GO
