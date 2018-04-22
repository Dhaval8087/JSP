
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/22/2018 23:28:49
-- Generated from EDMX file: H:\JSP\JSP\DAL\EDMX\JSPModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [JSP];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Client_Details]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Client_Details];
GO
IF OBJECT_ID(N'[dbo].[Client_Invoice]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Client_Invoice];
GO
IF OBJECT_ID(N'[dbo].[Clients]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clients];
GO
IF OBJECT_ID(N'[dbo].[Company_Details]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Company_Details];
GO
IF OBJECT_ID(N'[dbo].[Login]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Login];
GO
IF OBJECT_ID(N'[dbo].[ReturnType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ReturnType];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Client_Details'
CREATE TABLE [dbo].[Client_Details] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AY] varchar(50)  NULL,
    [ClientId] int  NOT NULL
);
GO

-- Creating table 'Client_Invoice'
CREATE TABLE [dbo].[Client_Invoice] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Client_Id] int  NULL,
    [InvoiceNumber] varchar(max)  NULL,
    [Client_DetailsId] int  NOT NULL
);
GO

-- Creating table 'Clients'
CREATE TABLE [dbo].[Clients] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(150)  NULL,
    [Address1] varchar(max)  NULL,
    [Address2] varchar(max)  NULL,
    [City] varchar(50)  NULL,
    [State] varchar(50)  NULL,
    [PinCode] varchar(50)  NULL,
    [Email] nvarchar(150)  NULL,
    [Mobile] varchar(50)  NULL,
    [ReturnTypeId] int  NOT NULL
);
GO

-- Creating table 'Company_Details'
CREATE TABLE [dbo].[Company_Details] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(150)  NULL,
    [Address1] varchar(max)  NULL,
    [Address2] varchar(max)  NULL,
    [City] varchar(50)  NULL,
    [State] varchar(50)  NULL,
    [PinCode] varchar(50)  NULL,
    [Email] nvarchar(150)  NULL,
    [Mobile] varchar(50)  NULL
);
GO

-- Creating table 'Logins'
CREATE TABLE [dbo].[Logins] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Username] varchar(150)  NULL,
    [Password] varchar(150)  NULL
);
GO

-- Creating table 'ReturnTypes'
CREATE TABLE [dbo].[ReturnTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Type] nchar(10)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Client_Details'
ALTER TABLE [dbo].[Client_Details]
ADD CONSTRAINT [PK_Client_Details]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Client_Invoice'
ALTER TABLE [dbo].[Client_Invoice]
ADD CONSTRAINT [PK_Client_Invoice]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [PK_Clients]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Company_Details'
ALTER TABLE [dbo].[Company_Details]
ADD CONSTRAINT [PK_Company_Details]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Logins'
ALTER TABLE [dbo].[Logins]
ADD CONSTRAINT [PK_Logins]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ReturnTypes'
ALTER TABLE [dbo].[ReturnTypes]
ADD CONSTRAINT [PK_ReturnTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ReturnTypeId] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [FK_ReturnTypeClient]
    FOREIGN KEY ([ReturnTypeId])
    REFERENCES [dbo].[ReturnTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ReturnTypeClient'
CREATE INDEX [IX_FK_ReturnTypeClient]
ON [dbo].[Clients]
    ([ReturnTypeId]);
GO

-- Creating foreign key on [ClientId] in table 'Client_Details'
ALTER TABLE [dbo].[Client_Details]
ADD CONSTRAINT [FK_ClientClient_Details]
    FOREIGN KEY ([ClientId])
    REFERENCES [dbo].[Clients]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientClient_Details'
CREATE INDEX [IX_FK_ClientClient_Details]
ON [dbo].[Client_Details]
    ([ClientId]);
GO

-- Creating foreign key on [Client_DetailsId] in table 'Client_Invoice'
ALTER TABLE [dbo].[Client_Invoice]
ADD CONSTRAINT [FK_Client_DetailsClient_Invoice]
    FOREIGN KEY ([Client_DetailsId])
    REFERENCES [dbo].[Client_Details]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Client_DetailsClient_Invoice'
CREATE INDEX [IX_FK_Client_DetailsClient_Invoice]
ON [dbo].[Client_Invoice]
    ([Client_DetailsId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------