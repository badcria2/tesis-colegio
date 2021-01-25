/****** Object:  Table [dbo].[tbl_Docente]    Script Date: 25/01/2021 16:40:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Docente](
	[codigo] [varchar](50) NOT NULL,
	[nombres] [varchar](50) NULL,
	[apellidos] [varchar](50) NULL,
	[dni] [varchar](15) NULL,
	[estado] [bit] NULL,
	[sexo] [char](1) NULL,
 CONSTRAINT [PK_tbl_Docente_1] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
