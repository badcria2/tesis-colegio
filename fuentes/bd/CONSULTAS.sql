SET Language 'Spanish'
declare @startDate datetime = CONVERT (datetime, '14/02/2021', 103) 
declare @endDate datetime = CONVERT (datetime, '14/12/2021', 103) 

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


 