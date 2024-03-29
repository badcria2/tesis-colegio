/****** Object:  StoredProcedure [dbo].[PRD_ObtenerForo]    Script Date: 31/01/2021 10:51:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      
-- Create Date: 
-- Description: 
-- =============================================
CREATE PROCEDURE [dbo].[PRD_ObtenerForo] (@codigo_usuario VARCHAR(50),
                                         @codigo_clase   VARCHAR(50))
AS
  BEGIN
      -- obtiene foros y estado de respuesta asociado a un usuario alumno
      SET nocount ON

      SELECT clase.codigo					AS codigo_clase,
             foro.fechacreacion				AS fecha_creacion,
             foro.tema,
             foro.descripcion,
             foro.codigo					AS codigo_foro,
             (SELECT Count(codigo)
              FROM   tbl_foro foro_temp
              WHERE  foro_temp.temapadre = foro.codigo)	AS cantidad_respuestas,
             (SELECT Count(codigo)
              FROM   tbl_foro foro_temp
              WHERE  foro_temp.temapadre = foro.codigo
                     AND foro_temp.usuario = @codigo_usuario) AS respondido,
             (SELECT Concat(nombres, ' ', apellidos)
              FROM   tbl_docente doc
              WHERE  doc.codigo = foro.usuario)            AS creador
      FROM   tbl_clase clase
             INNER JOIN tbl_foro foro
                     ON clase.codigo = foro.codigoclase AND foro.codigoclase = @codigo_clase
      WHERE  foro.temapadre IS NULL
              OR foro.temapadre = ''
                 AND foro.codigoclase = @codigo_clase
  END
--  exec [PRD_ObtenerForo] 'AL2020-00001','CL2020-00010'

--select *from tbl_clase
--select *from tbl_foro
GO
