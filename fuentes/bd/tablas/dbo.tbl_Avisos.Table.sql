/****** Object:  Table [dbo].[tbl_Avisos]    Script Date: 25/01/2021 16:40:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Avisos](
	[codigo] [varchar](50) NOT NULL,
	[titulo] [varchar](50) NULL,
	[contenido] [varchar](max) NULL,
	[imagen] [varchar](200) NULL,
	[codigoUsuario] [varchar](50) NULL,
	[fechaInicio] [varchar](50) NULL,
	[fechaTermino] [varchar](50) NULL,
	[importancia] [int] NULL,
	[estado] [bit] NULL,
 CONSTRAINT [PK_tbl_Avisos] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbl_Avisos]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Avisos_tbl_Director] FOREIGN KEY([codigoUsuario])
REFERENCES [dbo].[tbl_Director] ([codigo])
GO
ALTER TABLE [dbo].[tbl_Avisos] CHECK CONSTRAINT [FK_tbl_Avisos_tbl_Director]
GO
