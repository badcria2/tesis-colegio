/****** Object:  StoredProcedure [dbo].[PRD_ObtenerDetalleCurso]    Script Date: 31/01/2021 10:51:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      
-- Create Date: 
-- Description: 
-- =============================================
CREATE PROCEDURE [dbo].[PRD_ObtenerDetalleCurso] (@codigo_clase VARCHAR(50),
                                                 @periodo      VARCHAR(50))
AS
  BEGIN
      -- SET NOCOUNT ON added to prevent extra result sets from
      -- interfering with SELECT statements.
      SET nocount ON
	  update tbl_material set tarea = 0 
	  where codigoClase = @codigo_clase and 
			periodo = YEAR(GETDATE()) and 
			DATEDIFF (HOUR ,    CONVERT(VARCHAR, CAST(SYSDATETIMEOFFSET() AT TIME ZONE 'SA Pacific Standard Time' as datetime ) , 21) ,   CONVERT(DATETIME, fechaFin , 103)  ) < 0 
 
 

      SELECT clase.codigo AS               codigo_clase,
             clase.enlace,
             clase.numerosemanas AS        numero_semanas,
             material.codigo AS            codigo_material,
             material.semana,
             material.nombrematerial AS    nombre_material,
             material.extension,
             Isnull(material.tarea, 0) AS  tarea_habilitada_temp,  material.fechafin, material.mes,
			 clase.fechaInicio as fecha_inicio_clase,
			 clase.fechaFin as fecha_fin_clase,
			 material.fechaInicio as fecha_inicio_tarea,
			 material.fechaFin as fecha_fin_tarea,
			 CASE WHEN CONVERT(DATETIME  , material.fechaFin,103) >  CONVERT(VARCHAR, CAST(SYSDATETIMEOFFSET() AT TIME ZONE 'SA Pacific Standard Time' as datetime ), 21)  then 'true' else 'false' end as tarea_habilitada,
			 CASE WHEN DATEDIFF (HOUR ,    CONVERT(VARCHAR, CAST(SYSDATETIMEOFFSET() AT TIME ZONE 'SA Pacific Standard Time' as datetime ) , 21) ,   CONVERT(DATETIME, material.fechaFin , 103)  ) < 0 then '00:00:00' else
			 Concat( 
				CONVERT(varchar(10) , DATEDIFF (HOUR ,    CONVERT(VARCHAR, CAST(SYSDATETIMEOFFSET() AT TIME ZONE 'SA Pacific Standard Time' as datetime ) , 21) ,   CONVERT(DATETIME, material.fechaFin , 103)  )), ':',
				CONVERT(varchar(10), DATEDIFF (MINUTE ,    CONVERT(VARCHAR, CAST(SYSDATETIMEOFFSET() AT TIME ZONE 'SA Pacific Standard Time' as datetime ) , 21) ,   CONVERT(DATETIME, material.fechaFin , 103)  ) %60) , ':',
				CONVERT(varchar(10), DATEDIFF (SECOND  ,    CONVERT(VARCHAR, CAST(SYSDATETIMEOFFSET() AT TIME ZONE 'SA Pacific Standard Time' as datetime ) , 21) ,   CONVERT(DATETIME, material.fechaFin , 103)  )) %60) end as tiempo_restante

			 
			 FROM   tbl_clase clase
             LEFT JOIN tbl_material material
                     ON clase.codigo = material.codigoclase
      WHERE  clase.codigo = @codigo_clase
             AND clase.periodo = @periodo
      ORDER  BY semana ASC
  END

 --exec  [PRD_ObtenerDetalleCurso] 'CL2020-00148','2021'
 -- select * from tbl_material
 
-- select 
 
-- CONVERT(VARCHAR, CAST(SYSDATETIMEOFFSET() AT TIME ZONE 'SA Pacific Standard Time' as datetime ) , 21) AS  HH, 
--CONVERT(DATETIME  , fechaFin,103) as  xx ,
--Concat( 
--	CONVERT(varchar(10) , DATEDIFF (HOUR ,    CONVERT(VARCHAR, CAST(SYSDATETIMEOFFSET() AT TIME ZONE 'SA Pacific Standard Time' as datetime ) , 21) ,   CONVERT(DATETIME, fechaFin , 103)  )), ':',
--    CONVERT(varchar(10), DATEDIFF (MINUTE ,    CONVERT(VARCHAR, CAST(SYSDATETIMEOFFSET() AT TIME ZONE 'SA Pacific Standard Time' as datetime ) , 21) ,   CONVERT(DATETIME, fechaFin , 103)  ) %60) , ':',
--    CONVERT(varchar(10), DATEDIFF (SECOND  ,    CONVERT(VARCHAR, CAST(SYSDATETIMEOFFSET() AT TIME ZONE 'SA Pacific Standard Time' as datetime ) , 21) ,   CONVERT(DATETIME, fechaFin , 103)  )) %60) as segunods

-- FROM tbl_material

 --select   CONVERT(DATETIME  , replace(material.fechaFin,  '/','-') , 103) xx ,
 --replace ( CONVERT(VARCHAR, CAST(SYSDATETIMEOFFSET() AT TIME ZONE 'SA Pacific Standard Time' as datetime ), 20), ' PM', ''  ) as fechaActual ,
 -- CONVERT(DATETIME  , replace(material.fechaFin,  '/','-') , 103)  -  replace ( CONVERT(VARCHAR, CAST(SYSDATETIMEOFFSET() AT TIME ZONE 'SA Pacific Standard Time' as datetime ), 20), ' PM', ''  )  as diferencia,
 -- CONVERT(DATETIME  , replace(material.fechaFin,  '/','-') , 103)  - CONVERT(DATETIME  , replace(material.fechaFin,  '/','-') , 103) as diferenciav2  from tbl_material   material

 -- update  tbl_material set fechaInicio     =   convert(varchar, getdate(), 120), fechaFin   =   convert(varchar, getdate() + 10, 120)
--  select  CONVERT(VARCHAR, Getdate(), 20)
  -- SELECT CASE WHEN CONVERT(VARCHAR  ,material.fechafin,20) >  CONVERT(VARCHAR, Getdate(), 20) then 1 else 0  end as xx , *  FROM tbl_material material
 -- SELECT * , CONVERT(VARCHAR, Getdate(), 20) FROM tbl_material
  --EXEC [PRD_ObtenerDetalleCurso] 'CL2020-00148','2021'
--update tbl_material
--set tarea = 1,    fechaInicio     =   convert(varchar, getdate(), 120) ,  
--  fechafin =  convert(varchar, getdate() + 1 , 120) --  , select DATEDIFF (MINUTE ,( convert(varchar, getdate() , 120)),  convert(varchar, getdate() + 1, 120)  )
--where semana in (1,2,3,4,10,12)
--select DATEDIFF (HOUR ,  convert(varchar, getdate() , 120) ,  fechafin)  , DATEDIFF (MINUTE,  convert(varchar, getdate() , 120) , fechafin )%60   FROM tbl_material
--SELECT LEFT(CONVERT(VARCHAR(10), fechafin  - getdate() , 108), 8) AS ResultTime   FROM tbl_material 
GO
