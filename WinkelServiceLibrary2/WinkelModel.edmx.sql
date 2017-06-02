
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/02/2017 11:57:50
-- Generated from EDMX file: C:\Users\wilco\Documents\Visual Studio 2017\Projects\WinkelServiceLibrary2\WinkelServiceLibrary2\WinkelModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [WinkelDatabase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CustomerSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CustomerSet];
GO
IF OBJECT_ID(N'[dbo].[ProductSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CustomerEntitySet'
CREATE TABLE [dbo].[CustomerEntitySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Money] float  NOT NULL,
    [InventoryEntityId] int  NOT NULL
);
GO

-- Creating table 'ProductEntitySet'
CREATE TABLE [dbo].[ProductEntitySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Price] float  NOT NULL,
    [Stock] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'InventoryEntitySet'
CREATE TABLE [dbo].[InventoryEntitySet] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'ProductInventoryEntitySet'
CREATE TABLE [dbo].[ProductInventoryEntitySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [InventoryEntityId] int  NOT NULL,
    [ProductEntityId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'CustomerEntitySet'
ALTER TABLE [dbo].[CustomerEntitySet]
ADD CONSTRAINT [PK_CustomerEntitySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductEntitySet'
ALTER TABLE [dbo].[ProductEntitySet]
ADD CONSTRAINT [PK_ProductEntitySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'InventoryEntitySet'
ALTER TABLE [dbo].[InventoryEntitySet]
ADD CONSTRAINT [PK_InventoryEntitySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductInventoryEntitySet'
ALTER TABLE [dbo].[ProductInventoryEntitySet]
ADD CONSTRAINT [PK_ProductInventoryEntitySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [InventoryEntityId] in table 'CustomerEntitySet'
ALTER TABLE [dbo].[CustomerEntitySet]
ADD CONSTRAINT [FK_CustomerEntityInventoryEntity]
    FOREIGN KEY ([InventoryEntityId])
    REFERENCES [dbo].[InventoryEntitySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerEntityInventoryEntity'
CREATE INDEX [IX_FK_CustomerEntityInventoryEntity]
ON [dbo].[CustomerEntitySet]
    ([InventoryEntityId]);
GO

-- Creating foreign key on [InventoryEntityId] in table 'ProductInventoryEntitySet'
ALTER TABLE [dbo].[ProductInventoryEntitySet]
ADD CONSTRAINT [FK_ProductInventoryEntityInventoryEntity]
    FOREIGN KEY ([InventoryEntityId])
    REFERENCES [dbo].[InventoryEntitySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductInventoryEntityInventoryEntity'
CREATE INDEX [IX_FK_ProductInventoryEntityInventoryEntity]
ON [dbo].[ProductInventoryEntitySet]
    ([InventoryEntityId]);
GO

-- Creating foreign key on [ProductEntityId] in table 'ProductInventoryEntitySet'
ALTER TABLE [dbo].[ProductInventoryEntitySet]
ADD CONSTRAINT [FK_ProductEntityProductInventoryEntity]
    FOREIGN KEY ([ProductEntityId])
    REFERENCES [dbo].[ProductEntitySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductEntityProductInventoryEntity'
CREATE INDEX [IX_FK_ProductEntityProductInventoryEntity]
ON [dbo].[ProductInventoryEntitySet]
    ([ProductEntityId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------