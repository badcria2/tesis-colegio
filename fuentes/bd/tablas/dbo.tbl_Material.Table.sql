/****** Object:  Table [dbo].[tbl_Material]    Script Date: 25/01/2021 16:40:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Material](
	[codigo] [varchar](50) NOT NULL,
	[codigoClase] [varchar](50) NULL,
	[semana] [int] NULL,
	[periodo] [char](10) NULL,
	[usuario] [varchar](50) NULL,
	[extension] [varchar](10) NULL,
	[nombreMaterial] [varchar](200) NULL,
	[tarea] [bit] NULL,
	[fechaInicio] [varchar](50) NULL,
	[fechaFin] [varchar](50) NULL,
	[mes] [varchar](20) NULL,
 CONSTRAINT [PK_tbl_Material] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbl_Material]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Material_tbl_Clase] FOREIGN KEY([codigoClase])
REFERENCES [dbo].[tbl_Clase] ([codigo])
GO
ALTER TABLE [dbo].[tbl_Material] CHECK CONSTRAINT [FK_tbl_Material_tbl_Clase]
GO
