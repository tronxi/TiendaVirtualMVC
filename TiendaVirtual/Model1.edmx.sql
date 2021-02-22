
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/20/2021 11:09:59
-- Generated from EDMX file: C:\Users\Natalia\Documents\Universidad\MASTER\Ingenieria Web\NET\TiendaVirtual\TiendaVirtual\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [tiendadb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ProductoPedido_Producto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductoPedido] DROP CONSTRAINT [FK_ProductoPedido_Producto];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductoPedido_Pedido]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductoPedido] DROP CONSTRAINT [FK_ProductoPedido_Pedido];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Productos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Productos];
GO
IF OBJECT_ID(N'[dbo].[Pedidos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pedidos];
GO
IF OBJECT_ID(N'[dbo].[ProductoPedido]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductoPedido];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Productos'
CREATE TABLE [dbo].[Productos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Cantidad] int  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [Precio] float  NOT NULL
);
GO

-- Creating table 'Pedidos'
CREATE TABLE [dbo].[Pedidos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ProductoPedido'
CREATE TABLE [dbo].[ProductoPedido] (
    [Producto_Id] int  NOT NULL,
    [Pedido_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Productos'
ALTER TABLE [dbo].[Productos]
ADD CONSTRAINT [PK_Productos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Pedidos'
ALTER TABLE [dbo].[Pedidos]
ADD CONSTRAINT [PK_Pedidos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Producto_Id], [Pedido_Id] in table 'ProductoPedido'
ALTER TABLE [dbo].[ProductoPedido]
ADD CONSTRAINT [PK_ProductoPedido]
    PRIMARY KEY CLUSTERED ([Producto_Id], [Pedido_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Producto_Id] in table 'ProductoPedido'
ALTER TABLE [dbo].[ProductoPedido]
ADD CONSTRAINT [FK_ProductoPedido_Producto]
    FOREIGN KEY ([Producto_Id])
    REFERENCES [dbo].[Productos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Pedido_Id] in table 'ProductoPedido'
ALTER TABLE [dbo].[ProductoPedido]
ADD CONSTRAINT [FK_ProductoPedido_Pedido]
    FOREIGN KEY ([Pedido_Id])
    REFERENCES [dbo].[Pedidos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductoPedido_Pedido'
CREATE INDEX [IX_FK_ProductoPedido_Pedido]
ON [dbo].[ProductoPedido]
    ([Pedido_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------