/****** Object:  StoredProcedure [dbo].[obtenerDetalleCurso]    Script Date: 10/02/2021 22:24:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[obtenerDetalleCurso]
(
	@codigo_clase varchar(50),
	@periodo varchar
)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

     select clase.codigo as codigo_clase, clase.enlace, clase.numeroSemanas  as numero_semanas , material.codigo as codigo_material , material.semana, material.nombreMaterial, material.extension  from tbl_Clase clase 
		inner join tbl_material material on clase.codigo = material.codigoClase
	 where clase.codigo = @codigo_clase and material.periodo = @periodo
	 order by semana asc
END
GO
