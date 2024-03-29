/****** Object:  StoredProcedure [dbo].[PRD_ObtenerRangoFechas]    Script Date: 10/02/2021 22:24:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[PRD_ObtenerRangoFechas]
(
	@codigoClase varchar(50) 
)
AS	
BEGIN
   SET Language 'Spanish'
	DECLARE @fechaInicio varchar(10)
	DECLARE @fechaFin   VARCHAR(10)


     select @fechaInicio = [fechaInicio] ,
	 @fechaFin = [fechaFin]
	 from tbl_Clase where codigo = @codigoClase


   declare @startDate datetime = CONVERT (datetime, @fechaInicio, 103) 
   declare @endDate datetime = CONVERT (datetime, @fechaFin, 103) 
 ;with dateRange as
(
  select dateadd(MONTH, 1, @startDate) fecha , DATEDIFF(WEEK,dateadd(MONTH, 0, @startDate),dateadd(MONTH, 1, @startDate)) WEEKS
  where dateadd(MONTH, 1, @startDate) <= @endDate
  union all
  select dateadd(MONTH, 1, fecha), DATEDIFF(WEEK,dateadd(MONTH, 0, @startDate),dateadd(MONTH, 1, @startDate)) WEEKS
  from dateRange
  where dateadd(MONTH, 1, fecha) <= @endDate
)

select CONVERT (varchar, fecha , 101) as fecha , WEEKS as semanas , datename(MONTH,fecha) as mes
from dateRange


 
END
GO
