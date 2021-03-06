/****** Object:  Table [dbo].[tbl_ClaseAlumno]    Script Date: 25/01/2021 16:40:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_ClaseAlumno](
	[codigo] [varchar](50) NOT NULL,
	[codigoClase] [varchar](50) NULL,
	[codigoAlumno] [varchar](50) NULL,
	[estadoAlumnoClase] [bit] NULL,
	[cantidadFaltas] [int] NULL,
 CONSTRAINT [PK_tbl_ClaseAlumno] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbl_ClaseAlumno] ADD  CONSTRAINT [DF_tbl_ClaseAlumno_estadoAlumnoClase]  DEFAULT ((1)) FOR [estadoAlumnoClase]
GO
ALTER TABLE [dbo].[tbl_ClaseAlumno] ADD  CONSTRAINT [DF_tbl_ClaseAlumno_cantidadFaltas]  DEFAULT ((0)) FOR [cantidadFaltas]
GO
ALTER TABLE [dbo].[tbl_ClaseAlumno]  WITH CHECK ADD  CONSTRAINT [FK_tbl_ClaseAlumno_tbl_Alumno] FOREIGN KEY([codigoAlumno])
REFERENCES [dbo].[tbl_Alumno] ([codigo])
GO
ALTER TABLE [dbo].[tbl_ClaseAlumno] CHECK CONSTRAINT [FK_tbl_ClaseAlumno_tbl_Alumno]
GO
ALTER TABLE [dbo].[tbl_ClaseAlumno]  WITH CHECK ADD  CONSTRAINT [FK_tbl_ClaseAlumno_tbl_Clase] FOREIGN KEY([codigoClase])
REFERENCES [dbo].[tbl_Clase] ([codigo])
GO
ALTER TABLE [dbo].[tbl_ClaseAlumno] CHECK CONSTRAINT [FK_tbl_ClaseAlumno_tbl_Clase]
GO
