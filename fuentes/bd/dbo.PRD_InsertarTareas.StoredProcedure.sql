/****** Object:  StoredProcedure [dbo].[PRD_InsertarTareas]    Script Date: 10/02/2021 22:24:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      
-- Create Date: 
-- Description: 
-- =============================================
CREATE PROCEDURE [dbo].[PRD_InsertarTareas] (@codigo_clase VARCHAR(50),
                                            @semana       VARCHAR(50),
                                            @mes       VARCHAR(50),
                                            @nombre_tarea VARCHAR(200),
                                            @usuario      VARCHAR(50))
AS
  BEGIN
           

      UPDATE tbl_tareas
      SET    nombretarea = @nombre_tarea
      WHERE  codigoclase = @codigo_clase
             AND semana = @semana
             AND codigousuario = @usuario

      IF @@rowcount = 0
        BEGIN

            INSERT tbl_tareas
                   (codigo,
                    codigoclase,
                    semana,mes,
                    periodo,
                    nombretarea,
					codigousuario)
            VALUES (( Concat('TAR_', Year(Getdate()), '-', Month (Getdate()),
                      '_',
                      (
                                next value FOR seq_tareas )) ),
                    @codigo_clase,
                    @semana,@mes,
                    Year(Getdate()),
                    @nombre_tarea,
					@usuario)
        END
  END 
   
   -- exec [PRD_InsertarTareas]  'CL2020-00001', '1','Marzo', 'texto asdasd ---asd -asd-as dasd-asd -asd WQEWQEQWe asd', 'AL-74376357'
  -- select * from tbl_tareas
---delete from tbl_tareas
--set tarea = 1,    fechaInicio     =   convert(varchar, getdate(), 120) ,  
--  fechafin =  convert(varchar, getdate() + 1 , 120) --  , select DATEDIFF (MINUTE ,( convert(varchar, getdate() , 120)),  convert(varchar, getdate() + 1, 120)  )
--where semana in (1,2,3,4,10,12)
--select DATEDIFF (HOUR ,  convert(varchar, getdate() , 120) ,  fechafin)  , DATEDIFF (MINUTE,  convert(varchar, getdate() , 120) , fechafin )%60   FROM tbl_material
--SELECT LEFT(CONVERT(VARCHAR(10), fechafin  - getdate() , 108), 8) AS ResultTime   FROM tbl_material 
GO
