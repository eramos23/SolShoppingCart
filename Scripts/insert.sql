USE [ShoppingCart]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 20/10/2023 05:36:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](150) NOT NULL,
	[Vigente] [bit] NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 20/10/2023 05:36:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](150) NOT NULL,
	[Precio] [decimal](5, 2) NOT NULL,
	[Vigente] [bit] NOT NULL,
	[UsuarioCreaId] [int] NOT NULL,
	[FechaCreacion] [datetime2](7) NOT NULL,
	[CategoriaId] [int] NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categoria] ON 

INSERT [dbo].[Categoria] ([Id], [Nombre], [Vigente]) VALUES (1, N'Polos', 1)
INSERT [dbo].[Categoria] ([Id], [Nombre], [Vigente]) VALUES (2, N'Camiza', 1)
INSERT [dbo].[Categoria] ([Id], [Nombre], [Vigente]) VALUES (4, N'Casaca', 1)
SET IDENTITY_INSERT [dbo].[Categoria] OFF
GO
SET IDENTITY_INSERT [dbo].[Producto] ON 

INSERT [dbo].[Producto] ([Id], [Nombre], [Precio], [Vigente], [UsuarioCreaId], [FechaCreacion], [CategoriaId]) VALUES (1, N'Polo Azul 1', CAST(56.20 AS Decimal(5, 2)), 1, 1, CAST(N'2023-10-20T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Producto] ([Id], [Nombre], [Precio], [Vigente], [UsuarioCreaId], [FechaCreacion], [CategoriaId]) VALUES (2, N'Polo Azul xl', CAST(55.50 AS Decimal(5, 2)), 1, 1, CAST(N'2023-10-20T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Producto] ([Id], [Nombre], [Precio], [Vigente], [UsuarioCreaId], [FechaCreacion], [CategoriaId]) VALUES (3, N'Blue Camiza elegante ', CAST(85.00 AS Decimal(5, 2)), 1, 1, CAST(N'2023-10-20T00:00:00.0000000' AS DateTime2), 2)
INSERT [dbo].[Producto] ([Id], [Nombre], [Precio], [Vigente], [UsuarioCreaId], [FechaCreacion], [CategoriaId]) VALUES (4, N'Super abrigador xxl', CAST(350.00 AS Decimal(5, 2)), 1, 1, CAST(N'2023-10-20T00:00:00.0000000' AS DateTime2), 4)
INSERT [dbo].[Producto] ([Id], [Nombre], [Precio], [Vigente], [UsuarioCreaId], [FechaCreacion], [CategoriaId]) VALUES (5, N'Casaca 2', CAST(320.00 AS Decimal(5, 2)), 0, 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 4)
INSERT [dbo].[Producto] ([Id], [Nombre], [Precio], [Vigente], [UsuarioCreaId], [FechaCreacion], [CategoriaId]) VALUES (11, N'string 1212', CAST(34.00 AS Decimal(5, 2)), 0, 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 4)
SET IDENTITY_INSERT [dbo].[Producto] OFF
GO
ALTER TABLE [dbo].[Producto] ADD  DEFAULT (CONVERT([bit],(1))) FOR [Vigente]
GO
ALTER TABLE [dbo].[Producto] ADD  DEFAULT (getdate()) FOR [FechaCreacion]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Categoria_CategoriaId] FOREIGN KEY([CategoriaId])
REFERENCES [dbo].[Categoria] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Categoria_CategoriaId]
GO
