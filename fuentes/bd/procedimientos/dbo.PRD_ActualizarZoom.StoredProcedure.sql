/****** Object:  StoredProcedure [dbo].[PRD_ActualizarZoom]    Script Date: 31/01/2021 10:51:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      
-- Create Date: 
-- Description: 
-- =============================================
CREATE PROCEDURE [dbo].[PRD_ActualizarZoom] (@codigo_clase    VARCHAR(50),
											@enlace varchar(250),
											@periodo varchar(10)
											)
AS
  BEGIN 
	   
      UPDATE tbl_Clase 
		set enlace = @enlace
      WHERE  codigo = @codigo_clase AND periodo = @periodo 
 
  END

--CREATE SEQUENCE SEQ_Notas 
--    START WITH 1  
--    INCREMENT BY 1 ;  

-- DELETE   tbl_Notas
-- select * from tbl_Notas
GO
