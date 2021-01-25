/****** Object:  Table [dbo].[tbl_Curso]    Script Date: 25/01/2021 16:40:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Curso](
	[codigo] [varchar](50) NOT NULL,
	[nombre] [varchar](50) NULL,
	[estilo] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_Curso] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
