/****** Object:  Table [dbo].[tbl_TipoAcceso]    Script Date: 25/01/2021 16:40:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_TipoAcceso](
	[codigo] [varchar](50) NOT NULL,
	[acceso] [varchar](50) NULL,
	[descripcion] [varchar](50) NULL,
	[estado] [bit] NOT NULL,
	[fechaCreacion] [varchar](50) NULL,
	[fechaModificacion] [varchar](50) NULL,
	[usuarioCreacion] [varchar](50) NULL,
	[usuarioModificacion] [varchar](50) NULL,
	[path] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_TipoAcceso] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
