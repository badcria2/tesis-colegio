/****** Object:  Table [dbo].[tbl_Clase]    Script Date: 10/02/2021 22:24:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Clase](
	[codigo] [varchar](50) NOT NULL,
	[codigoCurso] [varchar](50) NULL,
	[codigoDocente] [varchar](50) NULL,
	[enlace] [varchar](250) NULL,
	[seccion] [char](1) NULL,
	[grado] [char](1) NULL,
	[periodo] [char](10) NULL,
	[numeroSemanas] [int] NULL,
	[fechaInicio] [varchar](10) NULL,
	[fechaFin] [varchar](10) NULL,
 CONSTRAINT [PK_tbl_Clase] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbl_Clase]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Clase_tbl_Curso] FOREIGN KEY([codigoCurso])
REFERENCES [dbo].[tbl_Curso] ([codigo])
GO
ALTER TABLE [dbo].[tbl_Clase] CHECK CONSTRAINT [FK_tbl_Clase_tbl_Curso]
GO
ALTER TABLE [dbo].[tbl_Clase]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Clase_tbl_Docente] FOREIGN KEY([codigoDocente])
REFERENCES [dbo].[tbl_Docente] ([codigo])
GO
ALTER TABLE [dbo].[tbl_Clase] CHECK CONSTRAINT [FK_tbl_Clase_tbl_Docente]
GO
