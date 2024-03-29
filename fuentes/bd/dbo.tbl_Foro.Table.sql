/****** Object:  Table [dbo].[tbl_Foro]    Script Date: 10/02/2021 22:24:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Foro](
	[codigo] [varchar](50) NOT NULL,
	[codigoClase] [varchar](50) NULL,
	[tema] [varchar](50) NULL,
	[descripcion] [varchar](max) NULL,
	[temaPadre] [varchar](50) NULL,
	[usuario] [varchar](50) NULL,
	[fechaCreacion] [varchar](20) NULL,
 CONSTRAINT [PK_tbl_Foro] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbl_Foro]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Foro_tbl_Clase] FOREIGN KEY([codigoClase])
REFERENCES [dbo].[tbl_Clase] ([codigo])
GO
ALTER TABLE [dbo].[tbl_Foro] CHECK CONSTRAINT [FK_tbl_Foro_tbl_Clase]
GO
