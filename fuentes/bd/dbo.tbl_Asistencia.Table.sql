/****** Object:  Table [dbo].[tbl_Asistencia]    Script Date: 10/02/2021 22:24:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Asistencia](
	[codigo] [varchar](50) NOT NULL,
	[codigoClase] [varchar](50) NULL,
	[fechaRegistro] [varchar](20) NULL,
	[estado] [char](1) NULL,
	[usuario] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_Asistencia] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbl_Asistencia]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Asistencia_tbl_Clase] FOREIGN KEY([codigoClase])
REFERENCES [dbo].[tbl_Clase] ([codigo])
GO
ALTER TABLE [dbo].[tbl_Asistencia] CHECK CONSTRAINT [FK_tbl_Asistencia_tbl_Clase]
GO
