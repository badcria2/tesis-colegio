/****** Object:  StoredProcedure [dbo].[PRD_ObtenertALumnoPorApoderado]    Script Date: 10/02/2021 22:24:23 ******/
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
