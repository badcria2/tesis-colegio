/****** Object:  Table [dbo].[tbl_DetalleUsuarioTipoAcceso]    Script Date: 25/01/2021 16:40:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_DetalleUsuarioTipoAcceso](
	[codigo] [varchar](50) NOT NULL,
	[codigoUsuario] [varchar](50) NULL,
	[codigoTipoAcceso] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_DetalleUsuarioTipoAcceso] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbl_DetalleUsuarioTipoAcceso]  WITH CHECK ADD  CONSTRAINT [FK_tbl_DetalleUsuarioTipoAcceso_tbl_TipoAcceso] FOREIGN KEY([codigoTipoAcceso])
REFERENCES [dbo].[tbl_TipoAcceso] ([codigo])
GO
ALTER TABLE [dbo].[tbl_DetalleUsuarioTipoAcceso] CHECK CONSTRAINT [FK_tbl_DetalleUsuarioTipoAcceso_tbl_TipoAcceso]
GO
ALTER TABLE [dbo].[tbl_DetalleUsuarioTipoAcceso]  WITH CHECK ADD  CONSTRAINT [FK_tbl_DetalleUsuarioTipoAcceso_tbl_Usuario] FOREIGN KEY([codigoUsuario])
REFERENCES [dbo].[tbl_Usuario] ([codigo])
GO
ALTER TABLE [dbo].[tbl_DetalleUsuarioTipoAcceso] CHECK CONSTRAINT [FK_tbl_DetalleUsuarioTipoAcceso_tbl_Usuario]
GO
