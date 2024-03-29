/****** Object:  Table [dbo].[tbl_Notas]    Script Date: 25/01/2021 16:40:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Notas](
	[codigo] [varchar](50) NOT NULL,
	[codigoClaseAlumno] [varchar](50) NULL,
	[nota] [int] NULL,
	[tipo] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_Notas] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbl_Notas]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Notas_tbl_ClaseAlumno] FOREIGN KEY([codigoClaseAlumno])
REFERENCES [dbo].[tbl_ClaseAlumno] ([codigo])
GO
ALTER TABLE [dbo].[tbl_Notas] CHECK CONSTRAINT [FK_tbl_Notas_tbl_ClaseAlumno]
GO
ALTER TABLE [dbo].[tbl_Notas]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Notas_tbl_NotasTipo] FOREIGN KEY([tipo])
REFERENCES [dbo].[tbl_NotasTipo] ([codigo])
GO
ALTER TABLE [dbo].[tbl_Notas] CHECK CONSTRAINT [FK_tbl_Notas_tbl_NotasTipo]
GO
