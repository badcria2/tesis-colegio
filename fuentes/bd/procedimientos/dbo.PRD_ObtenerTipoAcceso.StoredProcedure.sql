/****** Object:  StoredProcedure [dbo].[PRD_ObtenerTipoAcceso]    Script Date: 31/01/2021 10:51:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      
-- Create Date: 
-- Description: 
-- =============================================
CREATE PROCEDURE [dbo].[PRD_ObtenerTipoAcceso] (@perfil VARCHAR(50))
AS
  BEGIN
      SELECT codigo,
             acceso,
             estado,
			 path
      FROM   [dbo].[tbl_tipoacceso]
      WHERE  descripcion = @perfil
             AND estado = 1
  END  
GO
