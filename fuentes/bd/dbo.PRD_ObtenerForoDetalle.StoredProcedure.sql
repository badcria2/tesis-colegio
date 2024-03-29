/****** Object:  StoredProcedure [dbo].[PRD_ObtenerForoDetalle]    Script Date: 10/02/2021 22:24:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      
-- Create Date: 
-- Description: 
-- =============================================
CREATE PROCEDURE [dbo].[PRD_ObtenerForoDetalle] (
                                              @codigo_foro    VARCHAR(50))
AS
  BEGIN
      -- obtiene foros   asociado a un usuario 
      WITH persona
           AS (SELECT codigo,
                      nombres,
                      dni,
                      apellidos,
                      sexo
               FROM   [dbo].[tbl_alumno]
               UNION ALL
               SELECT codigo,
                      nombres,
                      dni,
                      apellidos,
                      sexo
               FROM   [dbo].tbl_docente)
      SELECT  
             foro.codigoClase                             AS codigo_clase,
             foro.fechacreacion                      AS fecha_creacion,
             foro.tema,
             foro.descripcion,
             foro.codigo                             AS codigo_foro,
             Concat(per.nombres, ' ', per.apellidos) AS creador,
			 per.sexo
      FROM   tbl_clase clase
             INNER JOIN tbl_foro foro
                     ON clase.codigo = foro.codigoclase
             LEFT JOIN persona per
                    ON foro.usuario = per.codigo
      WHERE  foro.codigo = @codigo_foro
              OR foro.temapadre = @codigo_foro
      ORDER  BY foro.codigo ASC
  END
--  exec [PRD_ObtenerForoDetalle]  'TEM-CL2020-00001' 
GO
