/****** Object:  Table [dbo].[tbl_Alumno]    Script Date: 10/02/2021 22:24:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Alumno](
	[codigo] [varchar](50) NOT NULL,
	[nombres] [varchar](50) NULL,
	[apellidos] [varchar](50) NULL,
	[dni] [varchar](12) NULL,
	[estado] [bit] NULL,
	[sexo] [char](1) NULL,
	[codigoApoderado] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_Alumno] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbl_Alumno]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Alumno_tbl_Apoderado] FOREIGN KEY([codigoApoderado])
REFERENCES [dbo].[tbl_Apoderado] ([codigo])
GO
ALTER TABLE [dbo].[tbl_Alumno] CHECK CONSTRAINT [FK_tbl_Alumno_tbl_Apoderado]
GO
