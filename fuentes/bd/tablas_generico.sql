/****** Object:  Table [dbo].[demo]    Script Date: 25/01/2021 16:51:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[demo](
	[codigo] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sysdiagrams]    Script Date: 25/01/2021 16:51:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sysdiagrams](
	[name] [sysname] NOT NULL,
	[principal_id] [int] NOT NULL,
	[diagram_id] [int] IDENTITY(1,1) NOT NULL,
	[version] [int] NULL,
	[definition] [varbinary](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[diagram_id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UK_principal_name] UNIQUE NONCLUSTERED 
(
	[principal_id] ASC,
	[name] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Alumno]    Script Date: 25/01/2021 16:51:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Alumno](
	[codigo] [varchar](50) NOT NULL,
	[nombres] [varchar](50) NULL,
	[apellidos] [varchar](50) NULL,
	[dni] [varchar](12) NULL,
	[estado] [bit] NULL,
	[sexo] [char](1) NULL,
	[codigoApoderado] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_Alumno] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Apoderado]    Script Date: 25/01/2021 16:51:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Apoderado](
	[codigo] [varchar](50) NOT NULL,
	[nombres] [varchar](50) NULL,
	[apellidos] [varchar](50) NULL,
	[dni] [varchar](12) NULL,
	[estado] [bit] NULL,
	[sexo] [char](1) NULL,
 CONSTRAINT [PK_tbl_Apoderado] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Asistencia]    Script Date: 25/01/2021 16:51:56 ******/
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
/****** Object:  Table [dbo].[tbl_Avisos]    Script Date: 25/01/2021 16:51:56 ******/
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
/****** Object:  Table [dbo].[tbl_Clase]    Script Date: 25/01/2021 16:51:56 ******/
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
/****** Object:  Table [dbo].[tbl_ClaseAlumno]    Script Date: 25/01/2021 16:51:56 ******/
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
/****** Object:  Table [dbo].[tbl_Curso]    Script Date: 25/01/2021 16:51:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Curso](
	[codigo] [varchar](50) NOT NULL,
	[nombre] [varchar](50) NULL,
	[estilo] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_Curso] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_DetalleUsuarioTipoAcceso]    Script Date: 25/01/2021 16:51:56 ******/
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
/****** Object:  Table [dbo].[tbl_Director]    Script Date: 25/01/2021 16:51:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Director](
	[codigo] [varchar](50) NOT NULL,
	[nombres] [varchar](50) NULL,
	[apellidos] [varchar](50) NULL,
	[dni] [varchar](15) NULL,
	[estado] [bit] NULL,
	[sexo] [char](1) NULL,
 CONSTRAINT [PK_tbl_Director] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Docente]    Script Date: 25/01/2021 16:51:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Docente](
	[codigo] [varchar](50) NOT NULL,
	[nombres] [varchar](50) NULL,
	[apellidos] [varchar](50) NULL,
	[dni] [varchar](15) NULL,
	[estado] [bit] NULL,
	[sexo] [char](1) NULL,
 CONSTRAINT [PK_tbl_Docente_1] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Foro]    Script Date: 25/01/2021 16:51:56 ******/
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
/****** Object:  Table [dbo].[tbl_Material]    Script Date: 25/01/2021 16:51:56 ******/
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
/****** Object:  Table [dbo].[tbl_Notas]    Script Date: 25/01/2021 16:51:56 ******/
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
/****** Object:  Table [dbo].[tbl_NotasTipo]    Script Date: 25/01/2021 16:51:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_NotasTipo](
	[codigo] [varchar](50) NOT NULL,
	[descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_NotasTipo] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Tareas]    Script Date: 25/01/2021 16:51:56 ******/
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
/****** Object:  Table [dbo].[tbl_TipoAcceso]    Script Date: 25/01/2021 16:51:56 ******/
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
/****** Object:  Table [dbo].[tbl_Usuario]    Script Date: 25/01/2021 16:51:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Usuario](
	[codigo] [varchar](50) NOT NULL,
	[usuario] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[estado] [bit] NOT NULL,
	[fechaCreacion] [varchar](50) NULL,
	[fechaModificacion] [varchar](50) NULL,
	[usuarioCreacion] [varchar](50) NULL,
	[usuarioModificacion] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_Usuario] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbl_ClaseAlumno] ADD  CONSTRAINT [DF_tbl_ClaseAlumno_estadoAlumnoClase]  DEFAULT ((1)) FOR [estadoAlumnoClase]
GO
ALTER TABLE [dbo].[tbl_ClaseAlumno] ADD  CONSTRAINT [DF_tbl_ClaseAlumno_cantidadFaltas]  DEFAULT ((0)) FOR [cantidadFaltas]
GO
ALTER TABLE [dbo].[tbl_Alumno]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Alumno_tbl_Apoderado] FOREIGN KEY([codigoApoderado])
REFERENCES [dbo].[tbl_Apoderado] ([codigo])
GO
ALTER TABLE [dbo].[tbl_Alumno] CHECK CONSTRAINT [FK_tbl_Alumno_tbl_Apoderado]
GO
ALTER TABLE [dbo].[tbl_Asistencia]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Asistencia_tbl_Clase] FOREIGN KEY([codigoClase])
REFERENCES [dbo].[tbl_Clase] ([codigo])
GO
ALTER TABLE [dbo].[tbl_Asistencia] CHECK CONSTRAINT [FK_tbl_Asistencia_tbl_Clase]
GO
ALTER TABLE [dbo].[tbl_Avisos]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Avisos_tbl_Director] FOREIGN KEY([codigoUsuario])
REFERENCES [dbo].[tbl_Director] ([codigo])
GO
ALTER TABLE [dbo].[tbl_Avisos] CHECK CONSTRAINT [FK_tbl_Avisos_tbl_Director]
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
ALTER TABLE [dbo].[tbl_Foro]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Foro_tbl_Clase] FOREIGN KEY([codigoClase])
REFERENCES [dbo].[tbl_Clase] ([codigo])
GO
ALTER TABLE [dbo].[tbl_Foro] CHECK CONSTRAINT [FK_tbl_Foro_tbl_Clase]
GO
ALTER TABLE [dbo].[tbl_Material]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Material_tbl_Clase] FOREIGN KEY([codigoClase])
REFERENCES [dbo].[tbl_Clase] ([codigo])
GO
ALTER TABLE [dbo].[tbl_Material] CHECK CONSTRAINT [FK_tbl_Material_tbl_Clase]
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
ALTER TABLE [dbo].[tbl_Tareas]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Tareas_tbl_Clase] FOREIGN KEY([codigoClase])
REFERENCES [dbo].[tbl_Clase] ([codigo])
GO
ALTER TABLE [dbo].[tbl_Tareas] CHECK CONSTRAINT [FK_tbl_Tareas_tbl_Clase]
GO
EXEC sys.sp_addextendedproperty @name=N'microsoft_database_tools_support', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sysdiagrams'
GO
