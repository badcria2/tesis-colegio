/****** Object:  StoredProcedure [dbo].[PRD_InsertarAsistencia]    Script Date: 10/02/2021 22:24:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      
-- Create Date: 
-- Description: 
-- =============================================
CREATE PROCEDURE [dbo].[PRD_InsertarAsistencia] (@estado    CHAR(1),
                                             @clase          VARCHAR(50),
                                             @codigo_usuario varchar(20),
                                             @fechaRegistro varchar(20)
											 )
AS
  BEGIN 
	   
	  

      update tbl_Asistencia set estado = @estado
      WHERE  usuario = @codigo_usuario
             AND fechaRegistro = @fechaRegistro
			 AND codigoClase = @clase

     IF @@rowcount = 0
        BEGIN

            INSERT tbl_Asistencia
                   (codigo,
                    codigoClase,
                    fechaRegistro,
					estado,
					usuario
                    )
            VALUES (( Concat('ASI', Year(Getdate()), '-', Month (Getdate()), '_'
                      ,
                      (
                                next value FOR SEQ_Asistencia )) ),
                    @clase,
                    @fechaRegistro,@estado , @codigo_usuario
                     )
   END
  END

--CREATE SEQUENCE SEQ_Asistencia
--    START WITH 1  
--   INCREMENT BY 1 ;  

-- DELETE   tbl_Asistencia
-- select * from tbl_Asistencia
GO
