/****** Object:  StoredProcedure [dbo].[PRD_InsertarAviso]    Script Date: 10/02/2021 22:24:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      
-- Create Date: 
-- Description: 
-- =============================================
CREATE PROCEDURE [dbo].[PRD_InsertarAviso] (@titulo  VARCHAR(50),
                                            @contenido    VARCHAR(MAX), 
                                            @imagen		  VARCHAR(200),
                                            @codigo_aviso VARCHAR(50),
                                            @fechaInicio VARCHAR(50),
                                            @fechaTermino VARCHAR(50),
											@codigoUsuario VARCHAR(50))
AS
  BEGIN
 
 
      UPDATE tbl_Avisos
      SET    titulo = @titulo , 
			 contenido = @contenido, 
			 imagen = @imagen, 
			 fechaInicio = @fechaInicio,
			 fechaTermino = @fechaTermino,
			 estado = 1
      WHERE  codigo = @codigo_aviso

      IF @@rowcount = 0
        BEGIN

            INSERT tbl_Avisos
                   (codigo,
                    titulo,
                    contenido,imagen,
                    codigoUsuario,
					fechaInicio, fechaTermino, estado)
            VALUES (( Concat('AVI_', Year(Getdate()), '-', Month (Getdate()),
                      '_',
                      (
                                next value FOR SEQ_Aviso )) ),
                    @titulo,
                    @contenido,@imagen,
					@codigoUsuario, 
                    (CONCAT(@fechaInicio,' ',CONVERT(VARCHAR, CAST(SYSDATETIMEOFFSET() AT TIME ZONE 'SA Pacific Standard Time' AS datetime), 14))),
					@fechaTermino,1)
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
