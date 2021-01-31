/****** Object:  StoredProcedure [dbo].[PRD_ObteneComboGrado]    Script Date: 31/01/2021 10:51:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      
-- Create Date: 
-- Description: 
-- =============================================
CREATE PROCEDURE [dbo].[PRD_ObteneComboGrado] (@codigoDocente varchar(50), @perfil VARCHAR(20))
AS
  BEGIN 
      SET nocount ON 
	select   grado + 'º Grado' as descripcion ,  grado as codigo
		from tbl_Clase
		where 1  = (CASE WHEN @perfil = 'Director' THEN 1
			WHEN codigoDocente = @codigoDocente THEN 1
			ELSE 0 END) 
	group by   grado


	 
  END  


   -- exec [PRD_ObteneComboGrado] 'DO-09468871'
GO
