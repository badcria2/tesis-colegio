/****** Object:  StoredProcedure [dbo].[PRD_InsertForo]    Script Date: 10/02/2021 22:24:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      
-- Create Date: 
-- Description: 
-- =============================================
CREATE PROCEDURE [dbo].[PRD_InsertForo] (
                                              @codigoClase    VARCHAR(50),
											  @tema    VARCHAR(MAX),
											  @descripcion    VARCHAR(MAX),
											  @temaPadre    VARCHAR(50),
											  @usuario    VARCHAR(50),
											  @codigo_foro varchar(50))
AS
  BEGIN 
	
	if @codigo_foro <> '' and @tema <> '' begin
		update tbl_foro
		set tema = @tema, descripcion = @descripcion 
		where codigo = @codigo_foro and usuario = @usuario
		end
	IF @@rowcount = 0
		  INSERT tbl_foro
                   (codigo, codigoClase, tema, descripcion,temaPadre,usuario,fechaCreacion)
				--   output INSERTED.codigo 
            VALUES (( Concat('TEM-CL', Year(Getdate()), '-', Month (Getdate()),
                      '_',
                      (
                                next value FOR seq_foro )) ),
                    @codigoClase,
                    @tema,
					@descripcion,
					@temaPadre,
					@usuario, 
                   CONVERT(VARCHAR, CAST(SYSDATETIMEOFFSET() AT TIME ZONE 'SA Pacific Standard Time' AS datetime), 120))
  END
 
 --select * from tbl_foro
--CREATE SEQUENCE seq_foro
--    START WITH 1  
--    INCREMENT BY 1 ;  

 
GO
