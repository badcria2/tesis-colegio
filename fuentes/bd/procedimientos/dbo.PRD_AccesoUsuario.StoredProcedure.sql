/****** Object:  StoredProcedure [dbo].[PRD_AccesoUsuario]    Script Date: 31/01/2021 10:51:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      
-- Create Date: 
-- Description: 
-- =============================================
CREATE PROCEDURE [dbo].[PRD_AccesoUsuario] @usuario  VARCHAR(50),
                                          @password VARCHAR(50)
AS
  BEGIN
      WITH persona
           AS (SELECT codigo,
                      nombres,
                      dni,
                      apellidos,
                      sexo
               FROM   [dbo].[tbl_alumno]
               WHERE  codigo = (SELECT codigo
                                FROM   tbl_usuario
                                WHERE  usuario = @usuario)
               UNION ALL
               SELECT codigo,
                      nombres,
                      dni,
                      apellidos,
                      sexo
               FROM   [dbo].tbl_docente
               WHERE  codigo = (SELECT codigo
                                FROM   tbl_usuario
                                WHERE  usuario = @usuario)
			   UNION ALL 
			   SELECT codigo,
                      nombres,
                      dni,
                      apellidos,
                      sexo
               FROM   [dbo].tbl_Apoderado
               WHERE  codigo = (SELECT codigo
                                FROM   tbl_usuario
                                WHERE  usuario = @usuario) 
								
			   UNION ALL 
			   SELECT codigo,
                      nombres,
                      dni,
                      apellidos,
                      sexo
               FROM   [dbo].tbl_Director
               WHERE  codigo = (SELECT codigo
                                FROM   tbl_usuario
                                WHERE  usuario = @usuario)
								
			)					 
      SELECT usu.codigo AS codigoUsuario,
             usu.usuario,
             tpa.acceso,
             usu.estado,
             tpa.codigo AS codigoTipoAcceso,
             per.nombres,
             per.dni,
             per.apellidos,
             per.sexo
      FROM   [dbo].[tbl_usuario] usu
             INNER JOIN [dbo].[tbl_detalleusuariotipoacceso] dtpa
                     ON usu.codigo = dtpa.codigousuario
                        AND usu.usuario = @usuario
                        AND usu.estado = 1
             INNER JOIN [dbo].[tbl_tipoacceso] tpa
                     ON tpa.codigo = dtpa.codigotipoacceso
             LEFT JOIN persona per
                    ON per.codigo = dtpa.codigousuario
      WHERE  usu.usuario = @usuario
             AND usu.password = @password
             AND usu.estado = 1
  END  

  --exec [PRD_AccesoUsuario] 'DI-05437826','DI-05437826'
GO
