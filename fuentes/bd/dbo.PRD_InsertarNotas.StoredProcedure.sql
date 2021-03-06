/****** Object:  StoredProcedure [dbo].[PRD_InsertarNotas]    Script Date: 10/02/2021 22:24:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      
-- Create Date: 
-- Description: 
-- =============================================
CREATE PROCEDURE [dbo].[PRD_InsertarNotas] (@nota    VARCHAR(50),
                                             @clase          VARCHAR(50),
                                             @tipo_nota varchar(20),
											 @eliminar int)
AS
  BEGIN 
	   
      DELETE tbl_Notas 
      WHERE  codigoClaseAlumno = @clase
             AND tipo = @tipo_nota AND @eliminar = 1

 

            INSERT tbl_Notas
                   (codigo,
                    codigoClaseAlumno,
                    nota,
					tipo
                    )
            VALUES (( Concat('NOT', Year(Getdate()), '-', Month (Getdate()), '_'
                      ,
                      (
                                next value FOR SEQ_Notas )) ),
                    @clase,
                    @nota,@tipo_nota
                     )
   
  END

--CREATE SEQUENCE SEQ_Notas 
--    START WITH 1  
--    INCREMENT BY 1 ;  

-- DELETE   tbl_Notas
-- select * from tbl_Notas
GO
