/****** Object:  StoredProcedure [dbo].[PRD_ObtenerTareas]    Script Date: 31/01/2021 10:51:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      
-- Create Date: 
-- Description: 
-- =============================================
CREATE PROCEDURE [dbo].[PRD_ObtenerTareas] (@codigo_clase   VARCHAR(50),
                                           @codigo_usuario VARCHAR(50),
                                           @periodo        VARCHAR(50))
AS
  BEGIN
      -- SET NOCOUNT ON added to prevent extra result sets from
      -- interfering with SELECT statements.
      SET nocount ON

      SELECT clase.codigo      AS codigo_clase,
             tarea.codigo      AS codigo_tarea,
             tarea.semana,
             tarea.nombretarea AS nombre_tarea
      FROM   tbl_clase clase
             LEFT JOIN tbl_tareas tarea
                    ON clase.codigo = tarea.codigoclase
      WHERE  clase.codigo = @codigo_clase
             AND tarea.periodo = @periodo
             AND tarea.codigousuario = @codigo_usuario
      ORDER  BY semana ASC
  END

  --select * from tbl_material
  --   --update tbl_material
	 --set semana = 5
	 --where codigo = 'MAT2020-00002'

--set tarea = 1,    fechaInicio     =   convert(varchar, getdate(), 120) ,  
--  fechafin =  convert(varchar, getdate() + 1 , 120) --  , select DATEDIFF (MINUTE ,( convert(varchar, getdate() , 120)),  convert(varchar, getdate() + 1, 120)  )
--where semana in (1,2,3,4,10,12)
--select DATEDIFF (HOUR ,  convert(varchar, getdate() , 120) ,  fechafin)  , DATEDIFF (MINUTE,  convert(varchar, getdate() , 120) , fechafin )%60   FROM tbl_material
--SELECT LEFT(CONVERT(VARCHAR(10), fechafin  - getdate() , 108), 8) AS ResultTime   FROM tbl_material 
GO
