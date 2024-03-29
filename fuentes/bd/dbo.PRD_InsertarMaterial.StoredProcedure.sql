/****** Object:  StoredProcedure [dbo].[PRD_InsertarMaterial]    Script Date: 10/02/2021 22:24:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      
-- Create Date: 
-- Description: 
-- =============================================
CREATE PROCEDURE [dbo].[PRD_InsertarMaterial] (@codigo_clase    VARCHAR(50),
                                             @semana          VARCHAR(50),
                                             @mes varchar(20),
											 @nombre_material varchar(200),
											 @usuario varchar(50))
AS
  BEGIN
      update tbl_Material 
	  set nombreMaterial = @nombre_material
      WHERE  codigoClase = @codigo_clase
             AND semana = @semana  and mes = @mes

      IF @@rowcount = 0
        BEGIN
            SET nocount ON

            INSERT tbl_Material
                   (codigo,
                    codigoClase, semana, periodo, usuario, nombreMaterial, tarea, mes, fechaInicio , fechaFin
             
                    )
            VALUES (( Concat('NOT', Year(Getdate()), '-', Month (Getdate()), '_'
                      ,
                      (
                                next value FOR SEQ_Material )) ),
                    @codigo_clase,
                    @semana,  Year(Getdate()),  @usuario, @nombre_material, 1, @mes, convert(varchar, getdate() , 103) + ' ' + CONVERT(VARCHAR, CAST(SYSDATETIMEOFFSET() AT TIME ZONE 'SA Pacific Standard Time' AS datetime), 108) 
					,convert(varchar, getdate() + 1 , 103) + ' ' + CONVERT(VARCHAR, CAST(SYSDATETIMEOFFSET() AT TIME ZONE 'SA Pacific Standard Time' AS datetime), 108) 
                     )
        END
  END

--CREATE SEQUENCE SEQ_Material 
--    START WITH 1  
--    INCREMENT BY 1 ;  

--  SELECT * FROM tbl_Material
GO
