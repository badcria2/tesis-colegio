/****** Object:  Table [dbo].[tbl_Tareas]    Script Date: 10/02/2021 22:24:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Tareas](
	[codigo] [varchar](50) NOT NULL,
	[codigoClase] [varchar](50) NULL,
	[semana] [int] NULL,
	[periodo] [char](10) NULL,
	[extension] [varchar](10) NULL,
	[nombreTarea] [varchar](200) NULL,
	[codigoUsuario] [varchar](50) NULL,
	[mes] [varchar](20) NULL,
 CONSTRAINT [PK_tbl_Tareas] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbl_Tareas]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Tareas_tbl_Clase] FOREIGN KEY([codigoClase])
REFERENCES [dbo].[tbl_Clase] ([codigo])
GO
ALTER TABLE [dbo].[tbl_Tareas] CHECK CONSTRAINT [FK_tbl_Tareas_tbl_Clase]
GO
