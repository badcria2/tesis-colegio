/****** Object:  StoredProcedure [dbo].[PRD_ObtenerAvisos]    Script Date: 10/02/2021 22:24:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      
-- Create Date: 
-- Description: 
-- =============================================
CREATE PROCEDURE [dbo].[PRD_ObtenerAvisos] 
AS
  BEGIN
      -- SET NOCOUNT ON added to prevent extra result sets from
      -- interfering with SELECT statements.
      SET nocount ON

	  UPDATE tbl_Avisos SET estado = 0 WHERE 
	  CONVERT(DATETIME  , fechaTermino,103) <  CONVERT(VARCHAR, CAST(SYSDATETIMEOFFSET() AT TIME ZONE 'SA Pacific Standard Time' as datetime ), 21) and estado = 1

      SELECT TOP 10 aviso.codigo , aviso.titulo ,aviso.contenido, aviso.codigoUsuario as codigo_usuario, 
				aviso.estado,substring (aviso.fechaInicio , 0 , 11 ) fechaInicio, aviso.fechaTermino, aviso.imagen,
				ISNULL(aviso.importancia,'1')AS importancia, director.nombres, director.apellidos, aviso.estado 
      FROM   tbl_Avisos aviso
	  INNER JOIN tbl_Director director on aviso.codigoUsuario = director.codigo and aviso.estado = 1
 
		WHERE  aviso.estado = 1 AND CONVERT(DATETIME  ,aviso.fechaTermino,103) >= CONVERT(VARCHAR, CAST(SYSDATETIMEOFFSET() AT TIME ZONE 'SA Pacific Standard Time' as datetime ), 21)   
      --where aviso.fechaTermino >= CONVERT(VARCHAR, Getdate(), 103)
	  order by  importancia desc
  END  

    --update tbl_Avisos
    --set fechaTermino =  '04/01/2021'
    --where codigo <> 'AVI_2020_12_1'
  -- exec [PRD_ObtenerAvisos]
  -- select CONVERT(VARCHAR  ,aviso.fechaTermino,111) from tbl_Avisos aviso
   -- SELECT CONVERT(DATETIME,aviso.fechaTermino ,103)  from tbl_Avisos aviso
   -- SELECT * from tbl_Avisos aviso
		--WHERE CODIGO IN ('AVI_2021-1_7', 'AVI_2021-1_8')

		--SELECT CONVERT(varchar,substring (aviso.fechaInicio , 0 , 11 ),103)  from tbl_Avisos aviso

		-- SELECT CONVERT(DATETIME  ,aviso.fechaTermino,103) ,  CONVERT(VARCHAR, CAST(SYSDATETIMEOFFSET() AT TIME ZONE 'SA Pacific Standard Time' as datetime ), 21), 
		-- case when CONVERT(DATETIME  ,aviso.fechaTermino,103)  >=     CONVERT(VARCHAR, CAST(SYSDATETIMEOFFSET() AT TIME ZONE 'SA Pacific Standard Time' as datetime ), 21) 
		-- 		then 0 else 1 end xx FROM   tbl_Avisos aviso

		 
  --select CONVERT(VARCHAR,  CAST('30/12/2020' as date), 111) , CONVERT(VARCHAR, Getdate()-1, 111)
GO
