/****** Object:  StoredProcedure [dbo].[PRD_EliminarDocumento]    Script Date: 31/01/2021 10:51:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      
-- Create Date: 
-- Description: 
-- =============================================
create PROCEDURE [dbo].[PRD_EliminarDocumento] (@codigo VARCHAR(50),@tipo VARCHAR(50))
AS
  BEGIN
      if(@tipo = 'TAREA') 
		delete from tbl_tareas where codigo = @codigo  
	   ELSE	   
		delete from tbl_Material where codigo = @codigo 
	   

  END 
   
   --exec [PRD_InsertarTareas]  'CL2020-00001', '1', 'texto asdasd ---asd -asd-as dasd-asd -asd WQEWQEQWe asd', 'AL2020-00001'
  -- select * from tbl_tareas
---update tbl_material
--set tarea = 1,    fechaInicio     =   convert(varchar, getdate(), 120) ,  
--  fechafin =  convert(varchar, getdate() + 1 , 120) --  , select DATEDIFF (MINUTE ,( convert(varchar, getdate() , 120)),  convert(varchar, getdate() + 1, 120)  )
--where semana in (1,2,3,4,10,12)
--select DATEDIFF (HOUR ,  convert(varchar, getdate() , 120) ,  fechafin)  , DATEDIFF (MINUTE,  convert(varchar, getdate() , 120) , fechafin )%60   FROM tbl_material
--SELECT LEFT(CONVERT(VARCHAR(10), fechafin  - getdate() , 108), 8) AS ResultTime   FROM tbl_material 
GO
