/****** Object:  StoredProcedure [dbo].[PRD_ObtenertALumnoPorApoderado]    Script Date: 31/01/2021 10:51:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PRD_ObtenertALumnoPorApoderado](
@codigoApoderado VARCHAR(50))
AS
BEGIN
	SELECT codigo as codigo_alumno, apellidos, nombres FROM tbl_Alumno WHERE codigoApoderado=@codigoApoderado
END
 
GO
