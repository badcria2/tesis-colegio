/****** Object:  StoredProcedure [dbo].[PRD_ObteneCombosSeccion]    Script Date: 10/02/2021 22:24:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      
-- Create Date: 
-- Description: 
-- =============================================
CREATE PROCEDURE [dbo].[PRD_ObteneCombosSeccion] (@codigoDocente varchar(50), 
@grado varchar(2),
@perfil varchar(20))
AS
  BEGIN 
      SET nocount ON 
 

	select  'Sección '+seccion  as descripcion ,  seccion as codigo
		from tbl_Clase
		where 
		1  = (CASE WHEN @perfil = 'Director' THEN 1
			WHEN codigoDocente = @codigoDocente THEN 1
			ELSE 0 END) AND
		 1 = CASE WHEN  @grado = 'Todos' THEN 
				1
			 WHEN  @grado = grado THEN 1
			 WHEN  @grado = '' THEN 1
			  ELSE
				0
			  END
	group by  seccion
	 
  END  


   -- exec [PRD_ObteneCombosSeccion] 'DO-09468871'
GO
